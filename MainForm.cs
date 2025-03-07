using fAmv.Models;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Diagnostics;
using System.Security.Policy;

namespace fAmv
{
    /*
     button6: ת�����ð�ť
     button8: ��������ť
     button2: ����Ŀ��ҳ��ť
     */
    public partial class MainForm : Form
    {
        private DataTable _task_list = new DataTable("�����б�");
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
            // �����ݵ����棨���˽�������
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
            // ��ת�����ð�ť�����ʱ����ת�����ô���
            var _setting_form = new Forms.ConvertSettingForm();
            _setting_form.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // ����������ť�����ʱ��������������Ӵ���
            var _batch_task_form = new Forms.BatchTaskForm();
            _batch_task_form.AddTask += () =>
            {
                add_task(_batch_task_form.OutputName, _batch_task_form.TargetPath, TaskType.Batch);
            };
            _batch_task_form.ShowDialog();
        }

        private void init_data_grid_view()
        {
            // ���ڳ�ʼ��DataGridView����������б������ݰ�
            dataGridView1.DataSource = _task_list;
        }

        private void init_path()
        {
            // ��ʼ��Ĭ�ϵ�output path
            if (!Directory.Exists("./output"))
            {
                Directory.CreateDirectory("./output");
            }
        }

        private void init_task_list()
        {
            // ���ڳ�ʼ��task_list������
            _task_list.Columns.Add("����ID", typeof(string));
            _task_list.Columns.Add("��������", typeof(string));
            _task_list.Columns.Add("����Ŀ���ļ�", typeof(string));
            _task_list.Columns.Add("����Ŀ�����Ŀ¼", typeof(string));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // ������Ŀ��ҳ��ť�����ʱ��ͨ��ϵͳĬ����Ϊ����Ŀ��github��ҳ
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/1Eliver/fAmv",
                UseShellExecute = true
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ��תʹ�ý̳�
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://1eliver.github.io/Elimir.github.io/2025/03/04/fAmv��Ŀ�ĵ�/",
                UseShellExecute = true
            });
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // ѡ��Ŀ��ת���ļ�·��
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                _target_file_path = openFileDialog1.FileName;
                _save_file_name = Path.ChangeExtension(Path.GetFileName(openFileDialog1.FileName), "amv");
                bind();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // ������񵥸�����
            if (_save_file_name == "")
            {
                MessageBox.Show("�������ļ���", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_target_file_path == "")
            {
                MessageBox.Show("����ѡ���ļ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            add_task(_save_file_name, _target_file_path, TaskType.Single);
        }

        private void add_task(string target_path, string input_path, TaskType type)
        {
            if (type is TaskType.Single)
            {
                // �������Ϊ��������ʱ
                var t = new TaskItem
                {
                    OutPut = Path.Combine(Path.GetFullPath(Settings.OutputPath), target_path),
                    Target = { input_path },
                    Type = type
                };

                _tasks.Add(t);

                _task_list.Rows.Add($"{t.Id}", "��������", t.Target[0], t.OutPut);
            }
            else
            {
                // ����������ʱ
                var t = new TaskItem
                {
                    OutPut = Path.Combine(Path.GetFullPath(Settings.OutputPath), target_path),
                    Target = Directory.GetFiles(input_path).ToList<string>(),
                    Type = type
                };
                _tasks.Add(t);
                _task_list.Rows.Add($"{t.Id}", "��������", $"{t.Target[0]}......", t.OutPut);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // �������ã���֪��Ϊʲô����������ܳɹ���׽����ť����¼���
        }

        private void button10_Click(object sender, EventArgs e)
        {
            // �������ã���֪��Ϊʲô����������ܳɹ���׽����ť����¼���
        }

        private List<string> GetSelectedTastId()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var res = new List<string>();
                foreach (DataGridViewRow item in dataGridView1.SelectedRows)
                {
                    res.Add((string)item.Cells["����ID"].Value);
                }
                return res;
            }
            return new List<string>();
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            // ���ɾ��ȫ������ʱ
            _tasks.Clear();
            _task_list.Rows.Clear();
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            // ���ɾ��ѡ�е�����ʱ
            var delete = GetSelectedTastId();
            foreach (var item in delete)
            {
                _tasks.Remove(_tasks.First(x => x.Id == item));
                _task_list.Rows.Remove(_task_list.Select($"����ID = '{item}'")[0]);
            }
        }

        private void _start_task(string tast_id)
        {
            // ����������ڰ�����Ӵ�����תΪ����ʼ

            // ��ɾ�������б���ı�����
            _task_list.Rows.Remove(_task_list.Select($"����ID = '{tast_id}'")[0]);
            // �������б���ȡ��������
            var t = _tasks.First(x => x.Id == tast_id);
            if (t.Type is TaskType.Single)
            {
                // ����������ǵ�������
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
                // 2025-03-07 error - ������Ҫ��ȷ��·���Ƿ����
                if (!Directory.Exists(t.OutPut))
                {
                    Directory.CreateDirectory(t.OutPut);
                }

                // ����������������
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
            // ����������ڿ���ת������׽����

            int totalConverters = converters.Count;
            int completedConverters = 0;

            foreach (var converter in converters)
            {
                // ����һ���ֲ��������洢�¼��������
                Action<double> progressHandler = (progress) =>
                {
                    // ���µ�ǰ���������
                    progressBarIndividual.Invoke(new Action(() =>
                    {
                        progressBarIndividual.Value = (int)progress;
                    }));
                };

                // ���ĵ�ǰת�����Ľ����¼�
                converter.OnProgressChanged += progressHandler;

                // ����ת�������ȴ���ǰת�������
                await Task.Run(() =>
                {
                    converter.StartConversion(ffmpegPath, ffprobePath);
                });

                // ȡ�����ĵ�ǰת�����Ľ����¼�
                converter.OnProgressChanged -= progressHandler;

                // ��������ɵ���������
                completedConverters++;

                // �����ܽ�����
                progressBarTotal.Invoke(new Action(() =>
                {
                    progressBarTotal.Value = (int)((double)completedConverters / totalConverters * 100);
                }));
            }

            converters.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // ��������Amv������
            Process.Start(new ProcessStartInfo
            {
                FileName = Path.GetFullPath(amvPlayerPath),
                UseShellExecute = true
            });
        }

        private void button11_Click(object sender, EventArgs e)
        {
            // ����ʼ��������
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
                        // ����������������ʼ������
                        await StartConversionsSequentially(converters, progressBar1, progressBar2, Path.GetFullPath(ffmpegPath), Path.GetFullPath(ffprobePath));

                        // �������˵�����
                        MessageBox.Show("ת�������", "�ɹ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("���������ڽ��У���ȴ���������ڿ����µ�����", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            // ����ʼѡ�е�����
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
                        // ����������������ʼ������
                        await StartConversionsSequentially(converters, progressBar1, progressBar2, Path.GetFullPath(ffmpegPath), Path.GetFullPath(ffprobePath));

                        // �������˵�����
                        MessageBox.Show("ת�������", "�ɹ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("���������ڽ��У���ȴ���������ڿ����µ�����", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
