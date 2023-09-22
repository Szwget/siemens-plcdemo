namespace SiemensPLCDemo
{
    partial class Form1
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
            ConnectPLCButton = new Button();
            label1 = new Label();
            IPTxt = new TextBox();
            WriteDBNoTxt = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            WriteDBValue = new TextBox();
            label6 = new Label();
            ReadDBNoTxt = new TextBox();
            ReadDBValue = new TextBox();
            WriteModelLabel = new Label();
            label8 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // ConnectPLCButton
            // 
            ConnectPLCButton.Location = new Point(204, 26);
            ConnectPLCButton.Name = "ConnectPLCButton";
            ConnectPLCButton.Size = new Size(111, 29);
            ConnectPLCButton.TabIndex = 0;
            ConnectPLCButton.Text = "连接PLC";
            ConnectPLCButton.UseVisualStyleBackColor = true;
            ConnectPLCButton.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 32);
            label1.Name = "label1";
            label1.Size = new Size(72, 17);
            label1.TabIndex = 1;
            label1.Text = "PLC_IP地址:";
            // 
            // IPTxt
            // 
            IPTxt.Location = new Point(90, 29);
            IPTxt.Name = "IPTxt";
            IPTxt.Size = new Size(97, 23);
            IPTxt.TabIndex = 2;
            IPTxt.Text = "127.0.0.1";
            // 
            // WriteDBNoTxt
            // 
            WriteDBNoTxt.Location = new Point(12, 91);
            WriteDBNoTxt.Name = "WriteDBNoTxt";
            WriteDBNoTxt.Size = new Size(97, 23);
            WriteDBNoTxt.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 71);
            label3.Name = "label3";
            label3.Size = new Size(97, 17);
            label3.TabIndex = 6;
            label3.Text = "写入DB块编号：";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 134);
            label4.Name = "label4";
            label4.Size = new Size(88, 17);
            label4.TabIndex = 7;
            label4.Text = "读取DB块编号:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(140, 71);
            label5.Name = "label5";
            label5.Size = new Size(47, 17);
            label5.TabIndex = 8;
            label5.Text = "写入值:";
            // 
            // WriteDBValue
            // 
            WriteDBValue.Location = new Point(140, 91);
            WriteDBValue.Name = "WriteDBValue";
            WriteDBValue.Size = new Size(97, 23);
            WriteDBValue.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(140, 134);
            label6.Name = "label6";
            label6.Size = new Size(47, 17);
            label6.TabIndex = 10;
            label6.Text = "读取值:";
            // 
            // ReadDBNoTxt
            // 
            ReadDBNoTxt.Location = new Point(12, 154);
            ReadDBNoTxt.Name = "ReadDBNoTxt";
            ReadDBNoTxt.Size = new Size(97, 23);
            ReadDBNoTxt.TabIndex = 11;
            // 
            // ReadDBValue
            // 
            ReadDBValue.Location = new Point(140, 154);
            ReadDBValue.Name = "ReadDBValue";
            ReadDBValue.Size = new Size(97, 23);
            ReadDBValue.TabIndex = 12;
            // 
            // WriteModelLabel
            // 
            WriteModelLabel.AutoSize = true;
            WriteModelLabel.Location = new Point(12, 193);
            WriteModelLabel.Name = "WriteModelLabel";
            WriteModelLabel.Size = new Size(129, 17);
            WriteModelLabel.TabIndex = 13;
            WriteModelLabel.Text = "整体模型写入://TODO";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(140, 193);
            label8.Name = "label8";
            label8.Size = new Size(129, 17);
            label8.TabIndex = 14;
            label8.Text = "整体模型读取://TODO";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 213);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(88, 23);
            textBox1.TabIndex = 15;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(140, 213);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(97, 23);
            textBox2.TabIndex = 16;
            // 
            // button1
            // 
            button1.Location = new Point(257, 91);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 17;
            button1.Text = "写入";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // button2
            // 
            button2.Location = new Point(257, 154);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 18;
            button2.Text = "读取";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(321, 26);
            button3.Name = "button3";
            button3.Size = new Size(91, 28);
            button3.TabIndex = 19;
            button3.Text = "断开连接";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(431, 193);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label8);
            Controls.Add(WriteModelLabel);
            Controls.Add(ReadDBValue);
            Controls.Add(ReadDBNoTxt);
            Controls.Add(label6);
            Controls.Add(WriteDBValue);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(WriteDBNoTxt);
            Controls.Add(IPTxt);
            Controls.Add(label1);
            Controls.Add(ConnectPLCButton);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button ConnectPLCButton;
        private Label label1;
        private TextBox IPTxt;
        private TextBox WriteDBNoTxt;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox WriteDBValue;
        private Label label6;
        private TextBox ReadDBNoTxt;
        private TextBox ReadDBValue;
        private Label WriteModelLabel;
        private Label label8;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}