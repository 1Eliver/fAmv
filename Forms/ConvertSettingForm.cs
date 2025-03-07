using fAmv.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fAmv.Forms
{
    public partial class ConvertSettingForm : Form
    {
        private int resolution_x;
        private int resolution_y;
        private int frameRate;
        private int audioSampleRate;
        private int blockSize;
        private int threadCount;
        private string outputPath;

        public ConvertSettingForm()
        {
            InitializeComponent();
            init();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // 手滑加的
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // 点击选择输出目录
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                // 获取用户选择的路径
                outputPath = folderBrowserDialog1.SelectedPath;

                // 更新 UI
                bind();
            }
        }

        private void init()
        {
            // 读取绑定并显示
            read_settings();
            bind();
        }

        private void read_settings()
        {
            // 读取设置并绑定到数据绑定
            outputPath = Settings.OutputPath;
            audioSampleRate = Settings.AudioSampleRate;
            blockSize = Settings.BlockSize;
            threadCount = Settings.ThreadCount;
            frameRate = Settings.FrameRate;
            resolution_x = int.Parse(Settings.Resolution.Split('x')[0]);
            resolution_y = int.Parse(Settings.Resolution.Split("x")[1]);
        }

        private void bind()
        {
            // 绑定数据到组件
            textBox1.Text = outputPath;
            textBox2.Text = resolution_x.ToString();
            textBox3.Text = resolution_y.ToString();
            textBox4.Text = frameRate.ToString();
            textBox7.Text = audioSampleRate.ToString();
            textBox5.Text = blockSize.ToString();
            textBox6.Text = threadCount.ToString();
        }

        private void save_settings()
        {
            Settings.OutputPath = outputPath;
            Settings.AudioSampleRate = audioSampleRate;
            Settings.BlockSize = blockSize;
            Settings.ThreadCount = threadCount;
            Settings.FrameRate = frameRate;
            Settings.Resolution = $"{resolution_x}x{resolution_y}";
        }

        private void sync()
        {
            // 将文本框设置同步到内部属性
            outputPath = textBox1.Text;
            resolution_x = int.Parse(textBox2.Text);
            resolution_y = int.Parse(textBox3.Text);
            frameRate = int.Parse(textBox4.Text);
            audioSampleRate = int.Parse(textBox7.Text);
            blockSize = int.Parse(textBox5.Text);
            threadCount = int.Parse(textBox6.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //同步属性
            sync();
            // 保存设置
            save_settings();
            // 退出
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 使用设置的恢复函数，并read然后bind
            Settings.RestoreDefaultSettings();
            read_settings();
            bind();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 打开教程页面
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://1eliver.github.io/Elimir.github.io/2025/03/04/fAmv项目文档/",
                UseShellExecute = true
            });
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // 切换到 1.8英寸mp3 屏幕分辨率

            resolution_x = 160;
            resolution_y = 128;

            bind();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // 切换到 1.5英寸mp3 屏幕分辨率

            resolution_x = 160;
            resolution_y = 96;

            bind();
        }
    }
}
