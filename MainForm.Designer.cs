namespace fAmv
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            groupBox1 = new GroupBox();
            button8 = new Button();
            button7 = new Button();
            button6 = new Button();
            groupBox3 = new GroupBox();
            textBox2 = new TextBox();
            groupBox2 = new GroupBox();
            button5 = new Button();
            textBox1 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            groupBox4 = new GroupBox();
            button12 = new Button();
            button11 = new Button();
            dataGridView1 = new DataGridView();
            button10 = new Button();
            button9 = new Button();
            groupBox5 = new GroupBox();
            progressBar1 = new ProgressBar();
            groupBox6 = new GroupBox();
            progressBar2 = new ProgressBar();
            openFileDialog1 = new OpenFileDialog();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox5.SuspendLayout();
            groupBox6.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button8);
            groupBox1.Controls.Add(button7);
            groupBox1.Controls.Add(button6);
            groupBox1.Controls.Add(groupBox3);
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Location = new Point(12, 36);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(460, 199);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "转换任务设置";
            // 
            // button8
            // 
            button8.Image = (Image)resources.GetObject("button8.Image");
            button8.ImageAlign = ContentAlignment.MiddleLeft;
            button8.Location = new Point(62, 142);
            button8.Name = "button8";
            button8.Padding = new Padding(15, 0, 0, 0);
            button8.Size = new Size(190, 46);
            button8.TabIndex = 5;
            button8.Text = "批量任务";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button7
            // 
            button7.Image = (Image)resources.GetObject("button7.Image");
            button7.ImageAlign = ContentAlignment.MiddleLeft;
            button7.Location = new Point(258, 142);
            button7.Name = "button7";
            button7.Padding = new Padding(10, 0, 0, 0);
            button7.Size = new Size(196, 46);
            button7.TabIndex = 4;
            button7.Text = "添加任务到待进行区";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button6
            // 
            button6.Image = (Image)resources.GetObject("button6.Image");
            button6.Location = new Point(6, 142);
            button6.Name = "button6";
            button6.Size = new Size(50, 46);
            button6.TabIndex = 3;
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(textBox2);
            groupBox3.Location = new Point(6, 82);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(448, 54);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "输出文件名";
            // 
            // textBox2
            // 
            textBox2.ForeColor = SystemColors.ControlText;
            textBox2.Location = new Point(6, 22);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(436, 23);
            textBox2.TabIndex = 0;
            textBox2.TextAlign = HorizontalAlignment.Center;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button5);
            groupBox2.Controls.Add(textBox1);
            groupBox2.Location = new Point(6, 22);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(448, 54);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "目标文件路径";
            // 
            // button5
            // 
            button5.Location = new Point(341, 22);
            button5.Name = "button5";
            button5.Size = new Size(101, 23);
            button5.TabIndex = 1;
            button5.Text = "选择";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // textBox1
            // 
            textBox1.ForeColor = Color.Yellow;
            textBox1.Location = new Point(6, 22);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(329, 23);
            textBox1.TabIndex = 0;
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // button1
            // 
            button1.Location = new Point(12, 7);
            button1.Name = "button1";
            button1.Size = new Size(127, 23);
            button1.TabIndex = 1;
            button1.Text = "跳转使用教程页面";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(145, 7);
            button2.Name = "button2";
            button2.Size = new Size(119, 23);
            button2.TabIndex = 2;
            button2.Text = "项目GitHub主页";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(270, 7);
            button3.Name = "button3";
            button3.Size = new Size(83, 23);
            button3.TabIndex = 3;
            button3.Text = "给作者捐赠";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(359, 7);
            button4.Name = "button4";
            button4.Size = new Size(113, 23);
            button4.TabIndex = 4;
            button4.Text = "打开Amv播放器";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(button12);
            groupBox4.Controls.Add(button11);
            groupBox4.Controls.Add(dataGridView1);
            groupBox4.Controls.Add(button10);
            groupBox4.Controls.Add(button9);
            groupBox4.Location = new Point(12, 241);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(460, 391);
            groupBox4.TabIndex = 5;
            groupBox4.TabStop = false;
            groupBox4.Text = "任务管理区";
            // 
            // button12
            // 
            button12.Location = new Point(329, 22);
            button12.Name = "button12";
            button12.Size = new Size(119, 23);
            button12.TabIndex = 4;
            button12.Text = "开始选中的任务";
            button12.UseVisualStyleBackColor = true;
            button12.Click += button12_Click;
            // 
            // button11
            // 
            button11.Location = new Point(229, 22);
            button11.Name = "button11";
            button11.Size = new Size(94, 23);
            button11.TabIndex = 3;
            button11.Text = "开始所有任务";
            button11.UseVisualStyleBackColor = true;
            button11.Click += button11_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(6, 51);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(448, 334);
            dataGridView1.TabIndex = 2;
            // 
            // button10
            // 
            button10.Location = new Point(107, 22);
            button10.Name = "button10";
            button10.Size = new Size(116, 23);
            button10.TabIndex = 1;
            button10.Text = "删除选中的任务";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click_1;
            // 
            // button9
            // 
            button9.Location = new Point(6, 22);
            button9.Name = "button9";
            button9.Size = new Size(95, 23);
            button9.TabIndex = 0;
            button9.Text = "清除所有任务";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click_1;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(progressBar1);
            groupBox5.Location = new Point(12, 638);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(460, 70);
            groupBox5.TabIndex = 6;
            groupBox5.TabStop = false;
            groupBox5.Text = "单次转换进度";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(6, 22);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(448, 42);
            progressBar1.TabIndex = 0;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(progressBar2);
            groupBox6.Location = new Point(12, 714);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(460, 70);
            groupBox6.TabIndex = 7;
            groupBox6.TabStop = false;
            groupBox6.Text = "总进度";
            // 
            // progressBar2
            // 
            progressBar2.Location = new Point(6, 22);
            progressBar2.Name = "progressBar2";
            progressBar2.Size = new Size(448, 42);
            progressBar2.TabIndex = 1;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 791);
            Controls.Add(groupBox6);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(groupBox1);
            Name = "MainForm";
            Text = "AmvConverter";
            groupBox1.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox5.ResumeLayout(false);
            groupBox6.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button button1;
        private Button button2;
        private Button button3;
        private GroupBox groupBox2;
        private TextBox textBox1;
        private Button button4;
        private Button button6;
        private GroupBox groupBox3;
        private TextBox textBox2;
        private Button button5;
        private Button button7;
        private Button button8;
        private GroupBox groupBox4;
        private Button button12;
        private Button button11;
        private DataGridView dataGridView1;
        private Button button10;
        private Button button9;
        private GroupBox groupBox5;
        private ProgressBar progressBar1;
        private GroupBox groupBox6;
        private ProgressBar progressBar2;
        private OpenFileDialog openFileDialog1;
    }
}
