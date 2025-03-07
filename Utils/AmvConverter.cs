using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;

public class AmvConverter
{
    // 默认参数
    private string _inputFilePath = "input.mp4";
    private string _outputFilePath = "output.amv";
    private string _resolution = "160x128";
    private int _frameRate = 18;
    private int _audioSampleRate = 22050;
    private int _audioChannels = 1;
    private int _blockSize = 1225;
    private bool _showConsole = false; // 是否显示任务栏终端，默认为不显示
    private int _threadCount = 0; // 线程数，默认为0（不限制）

    // 进度事件
    public event Action<double> OnProgressChanged;

    // 构造函数
    public AmvConverter()
    {
    }

    // 可调参数的属性
    public string InputFilePath
    {
        get => _inputFilePath;
        set => _inputFilePath = value;
    }

    public string OutputFilePath
    {
        get => _outputFilePath;
        set => _outputFilePath = value;
    }

    public string Resolution
    {
        get => _resolution;
        set => _resolution = value;
    }

    public int FrameRate
    {
        get => _frameRate;
        set => _frameRate = value;
    }

    public int AudioSampleRate
    {
        get => _audioSampleRate;
        set => _audioSampleRate = value;
    }

    public int AudioChannels
    {
        get => _audioChannels;
        set => _audioChannels = value;
    }

    public int BlockSize
    {
        get => _blockSize;
        set => _blockSize = value;
    }

    public bool ShowConsole
    {
        get => _showConsole;
        set => _showConsole = value;
    }

    public int ThreadCount
    {
        get => _threadCount;
        set => _threadCount = value;
    }

    // 启动转换任务
    public void StartConversion(string ffmpegPath, string ffprobePath)
    {
        double totalDuration = GetTotalDuration(ffprobePath, _inputFilePath);

        string command = $"-y -i \"{_inputFilePath}\" -c:v amv -c:a adpcm_ima_amv -s {_resolution} -r {_frameRate} -ar {_audioSampleRate} -ac {_audioChannels} -block_size {_blockSize} \"{_outputFilePath}\"";

        if (_threadCount > 0)
        {
            command = $"-threads {_threadCount} " + command;
        }

        ProcessStartInfo startInfo = new ProcessStartInfo
        {
            FileName = ffmpegPath,
            Arguments = command,
            RedirectStandardError = true,  // 只重定向错误流
            UseShellExecute = false,
            CreateNoWindow = !_showConsole,
            StandardErrorEncoding = Encoding.UTF8
        };

        using (Process process = new Process())
        {
            process.StartInfo = startInfo;
            process.ErrorDataReceived += (sender, e) =>
            {
                if (!string.IsNullOrEmpty(e.Data))
                {
                    ProcessErrorDataReceived(e.Data, totalDuration);
                    Debug.WriteLine("[FFmpeg] " + e.Data);  // 调试输出
                }
            };

            process.Start();

            // 必须异步读取错误流
            process.BeginErrorReadLine();

            // 等待进程退出（必须放在BeginErrorReadLine之后）
            process.WaitForExit();

            // 检查退出代码
            if (process.ExitCode != 0)
            {
                throw new Exception($"FFmpeg exited with code {process.ExitCode}");
            }
        }
    }

    // 获取目标文件的总时长
    private double GetTotalDuration(string ffprobePath, string inputFilePath)
    {
        ProcessStartInfo startInfo = new ProcessStartInfo
        {
            FileName = ffprobePath,
            Arguments = $"-v error -show_entries format=duration -of default=noprint_wrappers=1:nokey=1 \"{inputFilePath}\"",
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using (Process process = Process.Start(startInfo))
        {
            process.WaitForExit();
            string output = process.StandardOutput.ReadToEnd();
            return double.Parse(output);
        }
    }

    // 处理 FFmpeg 输出数据
    private void ProcessErrorDataReceived(string output, double totalDuration)
    {
        if (string.IsNullOrEmpty(output)) return;

        // 匹配 ffmpeg 的进度行格式（包含time=）
        if (output.Contains("time="))
        {
            // 使用正则表达式匹配时间格式
            var match = Regex.Match(output, @"time=(\d{2,}:\d{2}:\d{2}\.\d{2})");
            if (match.Success)
            {
                string timeStr = match.Groups[1].Value;

                // 将时间字符串转换为总秒数
                var timeComponents = timeStr.Split(':', '.');
                int hours = int.Parse(timeComponents[0]);
                int minutes = int.Parse(timeComponents[1]);
                int seconds = int.Parse(timeComponents[2]);
                int milliseconds = int.Parse(timeComponents[3].PadRight(3, '0')); // 补全毫秒位数

                double totalSeconds = hours * 3600 + minutes * 60 + seconds + milliseconds / 1000.0;

                // 计算进度百分比
                double progress = (totalSeconds / totalDuration) * 100;
                if (progress > 100) progress = 100;

                // 触发进度更新
                OnProgressChanged?.Invoke(progress);
            }
        }
    }
}