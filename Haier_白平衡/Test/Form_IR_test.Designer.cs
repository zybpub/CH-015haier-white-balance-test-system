namespace Test_Automation
{
    partial class Form_IR_test
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tbmemo = new System.Windows.Forms.TextBox();
            this.cbb_IR = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_hdmi = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(359, 55);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "工厂模式";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(359, 113);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(133, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "打开白平衡调试";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tbmemo
            // 
            this.tbmemo.Location = new System.Drawing.Point(70, 223);
            this.tbmemo.Multiline = true;
            this.tbmemo.Name = "tbmemo";
            this.tbmemo.Size = new System.Drawing.Size(534, 251);
            this.tbmemo.TabIndex = 2;
            // 
            // cbb_IR
            // 
            this.cbb_IR.FormattingEnabled = true;
            this.cbb_IR.Location = new System.Drawing.Point(166, 55);
            this.cbb_IR.Name = "cbb_IR";
            this.cbb_IR.Size = new System.Drawing.Size(79, 20);
            this.cbb_IR.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(82, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "红外遥控器";
            // 
            // btn_hdmi
            // 
            this.btn_hdmi.Location = new System.Drawing.Point(359, 84);
            this.btn_hdmi.Name = "btn_hdmi";
            this.btn_hdmi.Size = new System.Drawing.Size(122, 23);
            this.btn_hdmi.TabIndex = 8;
            this.btn_hdmi.Text = "HDMI";
            this.btn_hdmi.UseVisualStyleBackColor = true;
            this.btn_hdmi.Click += new System.EventHandler(this.btn_hdmi_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(359, 142);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(133, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "F3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(506, 55);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(133, 23);
            this.button4.TabIndex = 11;
            this.button4.Text = "重复发送工厂模式";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form_IR_test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 501);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btn_hdmi);
            this.Controls.Add(this.cbb_IR);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbmemo);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form_IR_test";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "红外测试";
            this.Load += new System.EventHandler(this.Form_IR_test_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tbmemo;
        private System.Windows.Forms.ComboBox cbb_IR;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_hdmi;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button4;
    }
}