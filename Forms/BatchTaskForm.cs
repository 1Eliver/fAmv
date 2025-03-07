using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fAmv.Forms
{
    public partial class BatchTaskForm : Form
    {
        public string TargetPath { get; set; }
        public string OutputName { get; set; }
        public event Action AddTask;

        public BatchTaskForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 选择目标文件所在文件夹按钮被点击时
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                TargetPath = folderBrowserDialog1.SelectedPath;
                bind();
            }
        }

        private void bind()
        {
            // 绑定数据显示到窗口中
            textBox1.Text = TargetPath;
            textBox2.Text = OutputName;
        }

        private void save()
        {
            // 把窗口中修改的数据保存到属性
            OutputName = textBox2.Text;
        }

        private void BatchTaskForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 当用户点击添加任务时
            save();
            AddTask.Invoke();
            Close();
        }
    }
}
