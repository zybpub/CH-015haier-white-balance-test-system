namespace Test_Automation.Setup
{
    partial class Form_Setup_CA410
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
            this.groupBox_ca410 = new System.Windows.Forms.GroupBox();
            this.lb_message = new System.Windows.Forms.Label();
            this.btn_search_serial_no = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.CA410_Machine_Keywords = new System.Windows.Forms.TextBox();
            this.CA410_SerialPort_PortName = new System.Windows.Forms.ComboBox();
            this.CA410_SerialPort_Parity = new System.Windows.Forms.ComboBox();
            this.CA410_SerialPort_StopBits = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.CA410_SerialPort_DataBits = new System.Windows.Forms.TextBox();
            this.CA410_SerialPort_BaudRate = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.CA410_TestChannel = new System.Windows.Forms.TextBox();
            this.CA410_SerialPort_Used = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox_ca410.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_ca410
            // 
            this.groupBox_ca410.Controls.Add(this.label3);
            this.groupBox_ca410.Controls.Add(this.lb_message);
            this.groupBox_ca410.Controls.Add(this.btn_search_serial_no);
            this.groupBox_ca410.Controls.Add(this.label2);
            this.groupBox_ca410.Controls.Add(this.CA410_Machine_Keywords);
            this.groupBox_ca410.Controls.Add(this.CA410_SerialPort_PortName);
            this.groupBox_ca410.Controls.Add(this.CA410_SerialPort_Parity);
            this.groupBox_ca410.Controls.Add(this.CA410_SerialPort_StopBits);
            this.groupBox_ca410.Controls.Add(this.label15);
            this.groupBox_ca410.Controls.Add(this.CA410_SerialPort_DataBits);
            this.groupBox_ca410.Controls.Add(this.CA410_SerialPort_BaudRate);
            this.groupBox_ca410.Controls.Add(this.label20);
            this.groupBox_ca410.Controls.Add(this.label21);
            this.groupBox_ca410.Controls.Add(this.label22);
            this.groupBox_ca410.Controls.Add(this.label25);
            this.groupBox_ca410.Controls.Add(this.label30);
            this.groupBox_ca410.Controls.Add(this.CA410_TestChannel);
            this.groupBox_ca410.Enabled = false;
            this.groupBox_ca410.Location = new System.Drawing.Point(55, 123);
            this.groupBox_ca410.Name = "groupBox_ca410";
            this.groupBox_ca410.Size = new System.Drawing.Size(440, 305);
            this.groupBox_ca410.TabIndex = 111;
            this.groupBox_ca410.TabStop = false;
            this.groupBox_ca410.Text = "CA410色彩分析仪配置";
            // 
            // lb_message
            // 
            this.lb_message.AutoSize = true;
            this.lb_message.Location = new System.Drawing.Point(191, 276);
            this.lb_message.Name = "lb_message";
            this.lb_message.Size = new System.Drawing.Size(0, 12);
            this.lb_message.TabIndex = 108;
            // 
            // btn_search_serial_no
            // 
            this.btn_search_serial_no.Location = new System.Drawing.Point(305, 235);
            this.btn_search_serial_no.Name = "btn_search_serial_no";
            this.btn_search_serial_no.Size = new System.Drawing.Size(75, 23);
            this.btn_search_serial_no.TabIndex = 107;
            this.btn_search_serial_no.Text = "查找串口";
            this.btn_search_serial_no.UseVisualStyleBackColor = true;
            this.btn_search_serial_no.Click += new System.EventHandler(this.btn_search_serial_no_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 213);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(263, 12);
            this.label2.TabIndex = 105;
            this.label2.Text = "设备管理器关键字（用于自动查找串口编号 ）：";
            // 
            // CA410_Machine_Keywords
            // 
            this.CA410_Machine_Keywords.Location = new System.Drawing.Point(122, 238);
            this.CA410_Machine_Keywords.Name = "CA410_Machine_Keywords";
            this.CA410_Machine_Keywords.Size = new System.Drawing.Size(176, 21);
            this.CA410_Machine_Keywords.TabIndex = 106;
            this.CA410_Machine_Keywords.Text = "Measuring Instruments";
            // 
            // CA410_SerialPort_PortName
            // 
            this.CA410_SerialPort_PortName.FormattingEnabled = true;
            this.CA410_SerialPort_PortName.Location = new System.Drawing.Point(122, 24);
            this.CA410_SerialPort_PortName.Name = "CA410_SerialPort_PortName";
            this.CA410_SerialPort_PortName.Size = new System.Drawing.Size(64, 20);
            this.CA410_SerialPort_PortName.TabIndex = 104;
            // 
            // CA410_SerialPort_Parity
            // 
            this.CA410_SerialPort_Parity.FormattingEnabled = true;
            this.CA410_SerialPort_Parity.Items.AddRange(new object[] {
            "Even"});
            this.CA410_SerialPort_Parity.Location = new System.Drawing.Point(122, 147);
            this.CA410_SerialPort_Parity.Name = "CA410_SerialPort_Parity";
            this.CA410_SerialPort_Parity.Size = new System.Drawing.Size(55, 20);
            this.CA410_SerialPort_Parity.TabIndex = 103;
            this.CA410_SerialPort_Parity.Text = "None";
            // 
            // CA410_SerialPort_StopBits
            // 
            this.CA410_SerialPort_StopBits.Location = new System.Drawing.Point(122, 116);
            this.CA410_SerialPort_StopBits.Name = "CA410_SerialPort_StopBits";
            this.CA410_SerialPort_StopBits.Size = new System.Drawing.Size(32, 21);
            this.CA410_SerialPort_StopBits.TabIndex = 102;
            this.CA410_SerialPort_StopBits.Text = "2";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(51, 119);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 101;
            this.label15.Text = "停止位：";
            // 
            // CA410_SerialPort_DataBits
            // 
            this.CA410_SerialPort_DataBits.Location = new System.Drawing.Point(122, 84);
            this.CA410_SerialPort_DataBits.Name = "CA410_SerialPort_DataBits";
            this.CA410_SerialPort_DataBits.Size = new System.Drawing.Size(32, 21);
            this.CA410_SerialPort_DataBits.TabIndex = 100;
            this.CA410_SerialPort_DataBits.Text = "7";
            // 
            // CA410_SerialPort_BaudRate
            // 
            this.CA410_SerialPort_BaudRate.Location = new System.Drawing.Point(122, 54);
            this.CA410_SerialPort_BaudRate.Name = "CA410_SerialPort_BaudRate";
            this.CA410_SerialPort_BaudRate.Size = new System.Drawing.Size(63, 21);
            this.CA410_SerialPort_BaudRate.TabIndex = 99;
            this.CA410_SerialPort_BaudRate.Text = "38400";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(39, 150);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(65, 12);
            this.label20.TabIndex = 98;
            this.label20.Text = "奇偶校验：";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(51, 87);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(53, 12);
            this.label21.TabIndex = 97;
            this.label21.Text = "数据位：";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(51, 57);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(53, 12);
            this.label22.TabIndex = 96;
            this.label22.Text = "波特率：";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(51, 27);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(53, 12);
            this.label25.TabIndex = 95;
            this.label25.Text = "端口号：";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(39, 185);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(65, 12);
            this.label30.TabIndex = 93;
            this.label30.Text = "测试通道：";
            // 
            // CA410_TestChannel
            // 
            this.CA410_TestChannel.Location = new System.Drawing.Point(122, 176);
            this.CA410_TestChannel.Name = "CA410_TestChannel";
            this.CA410_TestChannel.Size = new System.Drawing.Size(45, 21);
            this.CA410_TestChannel.TabIndex = 94;
            this.CA410_TestChannel.Text = "84";
            // 
            // CA410_SerialPort_Used
            // 
            this.CA410_SerialPort_Used.AutoSize = true;
            this.CA410_SerialPort_Used.Location = new System.Drawing.Point(55, 101);
            this.CA410_SerialPort_Used.Name = "CA410_SerialPort_Used";
            this.CA410_SerialPort_Used.Size = new System.Drawing.Size(78, 16);
            this.CA410_SerialPort_Used.TabIndex = 110;
            this.CA410_SerialPort_Used.Text = "使用CA410";
            this.CA410_SerialPort_Used.UseVisualStyleBackColor = true;
            this.CA410_SerialPort_Used.CheckedChanged += new System.EventHandler(this.CA410_SerialPort_Used_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(156, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 40);
            this.label1.TabIndex = 112;
            this.label1.Text = "CA410设置";
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(248, 449);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 114;
            this.btn_cancel.Text = "关闭";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(158, 449);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 113;
            this.btn_save.Text = "保存";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(220, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 12);
            this.label3.TabIndex = 109;
            this.label3.Text = "标准：38400，7，2，None";
            // 
            // Form_Setup_CA410
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 502);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox_ca410);
            this.Controls.Add(this.CA410_SerialPort_Used);
            this.Name = "Form_Setup_CA410";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CA410设置";
            this.Load += new System.EventHandler(this.Form_Setup_CA410_Load);
            this.groupBox_ca410.ResumeLayout(false);
            this.groupBox_ca410.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_ca410;
        private System.Windows.Forms.ComboBox CA410_SerialPort_PortName;
        private System.Windows.Forms.ComboBox CA410_SerialPort_Parity;
        private System.Windows.Forms.TextBox CA410_SerialPort_StopBits;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox CA410_SerialPort_DataBits;
        private System.Windows.Forms.TextBox CA410_SerialPort_BaudRate;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox CA410_TestChannel;
        private System.Windows.Forms.CheckBox CA410_SerialPort_Used;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox CA410_Machine_Keywords;
        private System.Windows.Forms.Label lb_message;
        private System.Windows.Forms.Button btn_search_serial_no;
        private System.Windows.Forms.Label label3;
    }
}