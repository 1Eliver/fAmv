using fAmv.Models;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Diagnostics;
using System.Security.Policy;

namespace fAmv
{
    /*
     button6: 转换设置按钮
     button8: 批量任务按钮
     button2: 打开项目主页按钮
     */
    public partial class MainForm : Form
    {
        private DataTable _task_list = new DataTable("任务列表");
        private String _target_file_path = "";
        private String _save_file_name = "";
        private List<TaskItem> _tasks = new List<TaskItem>();
        private List<AmvConverter> converters = new List<AmvConverter>();
        private bool is_handling_task = false;
        private static string ffprobePath = "./bin/ffprobe.exe";
        private static string ffmpegPath = "./bin/ffmpeg.exe";
        private static string amvPlayerPath = "./bin/AMVplayer/AMVPlayer.exe";

        private void bind()
        {
            // 绑定数据到界面（除了进度条）
            textBox1.Text = _target_file_path;
            textBox2.Text = _save_file_name;
        }
        public MainForm()
        {
            InitializeComponent();
            init_path();
            init_task_list();
            init_data_grid_view();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // 当转换设置按钮被点击时，打开转换设置窗口
            var _setting_form = new Forms.ConvertSettingForm();
            _setting_form.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // 当批量任务按钮被点击时，打开批量任务添加窗口
            var _batch_task_form = new Forms.BatchTaskForm();
            _batch_task_form.AddTask += () =>
            {
                add_task(_batch_task_form.OutputName, _batch_task_form.TargetPath, TaskType.Batch);
            };
            _batch_task_form.ShowDialog();
        }

        private void init_data_grid_view()
        {
            // 用于初始化DataGridView（任务管理列表）的数据绑定
            dataGridView1.DataSource = _task_list;
        }

        private void init_path()
        {
            // 初始化默认的output path
            if (!Directory.Exists("./output"))
            {
                Directory.CreateDirectory("./output");
            }
        }

        private void init_task_list()
        {
            // 用于初始化task_list的数据
            _task_list.Columns.Add("任务ID", typeof(string));
            _task_list.Columns.Add("任务类型", typeof(string));
            _task_list.Columns.Add("任务目标文件", typeof(string));
            _task_list.Columns.Add("任务目标输出目录", typeof(string));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 当打开项目主页按钮被点击时，通过系统默认行为打开项目的github主页
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/1Eliver/fAmv",
                UseShellExecute = true
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 跳转使用教程
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://1eliver.github.io/Elimir.github.io/2025/03/04/fAmv项目文档/",
                UseShellExecute = true
            });
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // 选择目标转换文件路径
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                _target_file_path = openFileDialog1.FileName;
                _save_file_name = Path.ChangeExtension(Path.GetFileName(openFileDialog1.FileName), "amv");
                bind();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // 添加任务单个任务
            if (_save_file_name == "")
            {
                MessageBox.Show("必须有文件名", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_target_file_path == "")
            {
                MessageBox.Show("必须选择文件", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            add_task(_save_file_name, _target_file_path, TaskType.Single);
        }

        private void add_task(string target_path, string input_path, TaskType type)
        {
            if (type is TaskType.Single)
            {
                // 处理添加为单个任务时
                var t = new TaskItem
                {
                    OutPut = Path.Combine(Path.GetFullPath(Settings.OutputPath), target_path),
                    Target = { input_path },
                    Type = type
                };

                _tasks.Add(t);

                _task_list.Rows.Add($"{t.Id}", "单独任务", t.Target[0], t.OutPut);
            }
            else
            {
                // 处理复数任务时
                var t = new TaskItem
                {
                    OutPut = Path.Combine(Path.GetFullPath(Settings.OutputPath), target_path),
                    Target = Directory.GetFiles(input_path).ToList<string>(),
                    Type = type
                };
                _tasks.Add(t);
                _task_list.Rows.Add($"{t.Id}", "批量任务", $"{t.Target[0]}......", t.OutPut);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // 方法弃用（不知道为什么这个方法不能成功捕捉到按钮点击事件）
        }

        private void button10_Click(object sender, EventArgs e)
        {
            // 方法弃用（不知道为什么这个方法不能成功捕捉到按钮点击事件）
        }

        private List<string> GetSelectedTastId()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var res = new List<string>();
                foreach (DataGridViewRow item in dataGridView1.SelectedRows)
                {
                    res.Add((string)item.Cells["任务ID"].Value);
                }
                return res;
            }
            return new List<string>();
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            // 点击删除全部任务时
            _tasks.Clear();
            _task_list.Rows.Clear();
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            // 点击删除选中的任务时
            var delete = GetSelectedTastId();
            foreach (var item in delete)
            {
                _tasks.Remove(_tasks.First(x => x.Id == item));
                _task_list.Rows.Remove(_task_list.Select($"任务ID = '{item}'")[0]);
            }
        }

        private void _start_task(string tast_id)
        {
            // 这个方法用于把任务从待处理转为待开始

            // 先删除任务列表里的本任务
            _task_list.Rows.Remove(_task_list.Select($"任务ID = '{tast_id}'")[0]);
            // 从任务列表里取出本任务
            var t = _tasks.First(x => x.Id == tast_id);
            if (t.Type is TaskType.Single)
            {
                // 如果启动的是单例任务
                converters.Add(new AmvConverter
                {
                    AudioSampleRate = Settings.AudioSampleRate,
                    ThreadCount = Settings.ThreadCount,
                    BlockSize = Settings.BlockSize,
                    FrameRate = Settings.FrameRate,
                    Resolution = Settings.Resolution,
                    InputFilePath = t.Target[0],
                    OutputFilePath = t.OutPut
                });
            }
            else
            {
                // 2025-03-07 error - 这里需要先确定路径是否存在
                if (!Directory.Exists(t.OutPut))
                {
                    Directory.CreateDirectory(t.OutPut);
                }

                // 处理启动批量任务
                foreach (var p in t.Target)
                {
                    converters.Add(new AmvConverter
                    {
                        AudioSampleRate = Settings.AudioSampleRate,
                        ThreadCount = Settings.ThreadCount,
                        BlockSize = Settings.BlockSize,
                        FrameRate = Settings.FrameRate,
                        Resolution = Settings.Resolution,
                        InputFilePath = p,
                        OutputFilePath = Path.Combine(t.OutPut, Path.GetFileName(Path.ChangeExtension(p, "amv")))
                    });
                }
            }
            _tasks.Remove(t);
        }

        private async Task StartConversionsSequentially(
            List<AmvConverter> converters,
            ProgressBar progressBarIndividual,
            ProgressBar progressBarTotal,
            string ffmpegPath,
            string ffprobePath)
        {
            // 这个方法用于开启转换并捕捉进度

            int totalConverters = converters.Count;
            int completedConverters = 0;

            foreach (var converter in converters)
            {
                // 定义一个局部变量来存储事件处理程序
                Action<double> progressHandler = (progress) =>
                {
                    // 更新当前任务进度条
                    progressBarIndividual.Invoke(new Action(() =>
                    {
                        progressBarIndividual.Value = (int)progress;
                    }));
                };

                // 订阅当前转换器的进度事件
                converter.OnProgressChanged += progressHandler;

                // 启动转换器并等待当前转换器完成
                await Task.Run(() =>
                {
                    converter.StartConversion(ffmpegPath, ffprobePath);
                });

                // 取消订阅当前转换器的进度事件
                converter.OnProgressChanged -= progressHandler;

                // 更新已完成的任务数量
                completedConverters++;

                // 更新总进度条
                progressBarTotal.Invoke(new Action(() =>
                {
                    progressBarTotal.Value = (int)((double)completedConverters / totalConverters * 100);
                }));
            }

            converters.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // 处理点击打开Amv播放器
            Process.Start(new ProcessStartInfo
            {
                FileName = Path.GetFullPath(amvPlayerPath),
                UseShellExecute = true
            });
        }

        private void button11_Click(object sender, EventArgs e)
        {
            // 处理开始所有任务
            if (!is_handling_task)
            {
                if (_tasks.Count > 0)
                {
                    is_handling_task = true;
                    var ids = _tasks.Select(x => x.Id).ToList();
                    foreach (var item in ids)
                    {
                        _start_task(item);
                    }

                    Task.Run(async () =>
                    {
                        // 这里是真正将任务开始运行了
                        await StartConversionsSequentially(converters, progressBar1, progressBar2, Path.GetFullPath(ffmpegPath), Path.GetFullPath(ffprobePath));

                        // 运行完了弹弹窗
                        MessageBox.Show("转换已完成", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        progressBar1.Invoke(new Action(() =>
                        {
                            progressBar1.Value = 0;
                        }));
                        progressBar2.Invoke(new Action(() =>
                        {
                            progressBar2.Value = 0;
                        }));
                        is_handling_task = false;
                    });
                }
            }
            else
            {
                MessageBox.Show("有任务正在进行，请等待任务结束在开启新的任务", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            // 处理开始选中的任务
            if (!is_handling_task)
            {
                if (_tasks.Count > 0)
                {
                    is_handling_task = true;
                    var ids = GetSelectedTastId();
                    foreach (var item in ids)
                    {
                        _start_task(item);
                    }

                    Task.Run(async () =>
                    {
                        // 这里是真正将任务开始运行了
                        await StartConversionsSequentially(converters, progressBar1, progressBar2, Path.GetFullPath(ffmpegPath), Path.GetFullPath(ffprobePath));

                        // 运行完了弹弹窗
                        MessageBox.Show("转换已完成", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        progressBar1.Invoke(new Action(() =>
                        {
                            progressBar1.Value = 0;
                        }));
                        progressBar2.Invoke(new Action(() =>
                        {
                            progressBar2.Value = 0;
                        }));
                        is_handling_task = false;
                    });
                }
            }
            else
            {
                MessageBox.Show("有任务正在进行，请等待任务结束在开启新的任务", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
