namespace fAmv.Forms
{
    partial class ConvertSettingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            groupBox1 = new GroupBox();
            button4 = new Button();
            textBox1 = new TextBox();
            button2 = new Button();
            button3 = new Button();
            groupBox2 = new GroupBox();
            button6 = new Button();
            button5 = new Button();
            label1 = new Label();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            groupBox3 = new GroupBox();
            textBox4 = new TextBox();
            groupBox4 = new GroupBox();
            textBox5 = new TextBox();
            groupBox5 = new GroupBox();
            textBox6 = new TextBox();
            groupBox6 = new GroupBox();
            textBox7 = new TextBox();
            folderBrowserDialog1 = new FolderBrowserDialog();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox6.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(108, 23);
            button1.TabIndex = 0;
            button1.Text = "打开设置帮助页";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button4);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Location = new Point(12, 41);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(386, 58);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "输出目录设置";
            // 
            // button4
            // 
            button4.Location = new Point(305, 22);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 1;
            button4.Text = "选择";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(6, 22);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(293, 23);
            textBox1.TabIndex = 0;
            // 
            // button2
            // 
            button2.Location = new Point(241, 12);
            button2.Name = "button2";
            button2.Size = new Size(157, 23);
            button2.TabIndex = 2;
            button2.Text = "保存设置并退出";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(126, 12);
            button3.Name = "button3";
            button3.Size = new Size(109, 23);
            button3.TabIndex = 3;
            button3.Text = "恢复默认设置";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button6);
            groupBox2.Controls.Add(button5);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(textBox3);
            groupBox2.Controls.Add(textBox2);
            groupBox2.Location = new Point(12, 105);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(386, 58);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "输出分辨率设置";
            // 
            // button6
            // 
            button6.Location = new Point(280, 22);
            button6.Name = "button6";
            button6.Size = new Size(100, 23);
            button6.TabIndex = 7;
            button6.Text = "切换到1.5寸";
            button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(178, 22);
            button5.Name = "button5";
            button5.Size = new Size(96, 23);
            button5.TabIndex = 5;
            button5.Text = "切换到1.8寸";
            button5.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(82, 25);
            label1.Name = "label1";
            label1.Size = new Size(14, 17);
            label1.TabIndex = 5;
            label1.Text = "x";
            label1.Click += label1_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(102, 22);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(70, 23);
            textBox3.TabIndex = 6;
            textBox3.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(6, 22);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(70, 23);
            textBox2.TabIndex = 5;
            textBox2.TextAlign = HorizontalAlignment.Center;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(textBox4);
            groupBox3.Location = new Point(12, 169);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(172, 56);
            groupBox3.TabIndex = 5;
            groupBox3.TabStop = false;
            groupBox3.Text = "帧率设置";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(6, 22);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(160, 23);
            textBox4.TabIndex = 7;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(textBox5);
            groupBox4.Location = new Point(198, 169);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(200, 56);
            groupBox4.TabIndex = 6;
            groupBox4.TabStop = false;
            groupBox4.Text = "音频块大小设置";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(6, 22);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(188, 23);
            textBox5.TabIndex = 8;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(textBox6);
            groupBox5.Location = new Point(12, 231);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(124, 56);
            groupBox5.TabIndex = 7;
            groupBox5.TabStop = false;
            groupBox5.Text = "线程数限制";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(6, 22);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(112, 23);
            textBox6.TabIndex = 7;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(textBox7);
            groupBox6.Location = new Point(142, 231);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(256, 56);
            groupBox6.TabIndex = 8;
            groupBox6.TabStop = false;
            groupBox6.Text = "音频采样率设置（单位Hz）";
            // 
            // textBox7
            // 
            textBox7.Location = new Point(6, 22);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(244, 23);
            textBox7.TabIndex = 7;
            // 
            // ConvertSettingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(404, 291);
            Controls.Add(groupBox6);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(groupBox1);
            Controls.Add(button1);
            Name = "ConvertSettingForm";
            Text = "转换设置（推荐默认或观看帮助页后进行设置）";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private GroupBox groupBox1;
        private Button button4;
        private TextBox textBox1;
        private Button button2;
        private Button button3;
        private GroupBox groupBox2;
        private TextBox textBox3;
        private TextBox textBox2;
        private Label label1;
        private Button button6;
        private Button button5;
        private GroupBox groupBox3;
        private TextBox textBox4;
        private GroupBox groupBox4;
        private TextBox textBox5;
        private GroupBox groupBox5;
        private TextBox textBox6;
        private GroupBox groupBox6;
        private TextBox textBox7;
        private FolderBrowserDialog folderBrowserDialog1;
    }
}