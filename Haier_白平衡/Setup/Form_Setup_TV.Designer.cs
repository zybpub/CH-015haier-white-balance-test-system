namespace Test_Automation.Setup
{
    partial class Form_Setup_TV
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
            this.TV_Connect_Used = new System.Windows.Forms.CheckBox();
            this.groupBox_tv_connect = new System.Windows.Forms.GroupBox();
            this.radioButton_串口 = new System.Windows.Forms.RadioButton();
            this.radioButton_网口 = new System.Windows.Forms.RadioButton();
            this.label35 = new System.Windows.Forms.Label();
            this.groupBox_tv串口 = new System.Windows.Forms.GroupBox();
            this.lb_message = new System.Windows.Forms.Label();
            this.btn_search_serial_no = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.TV_Machine_Keywords = new System.Windows.Forms.TextBox();
            this.TV_SerialPort_PortName = new System.Windows.Forms.ComboBox();
            this.TV_SerialPort_Parity = new System.Windows.Forms.ComboBox();
            this.TV_SerialPort_StopBits = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.TV_SerialPort_DataBits = new System.Windows.Forms.TextBox();
            this.TV_SerialPort_BaudRate = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.groupBox_tv网口 = new System.Windows.Forms.GroupBox();
            this.TV_IP = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.TV_Port = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox_tv_connect.SuspendLayout();
            this.groupBox_tv串口.SuspendLayout();
            this.groupBox_tv网口.SuspendLayout();
            this.SuspendLayout();
            // 
            // TV_Connect_Used
            // 
            this.TV_Connect_Used.AutoSize = true;
            this.TV_Connect_Used.Location = new System.Drawing.Point(35, 75);
            this.TV_Connect_Used.Name = "TV_Connect_Used";
            this.TV_Connect_Used.Size = new System.Drawing.Size(108, 16);
            this.TV_Connect_Used.TabIndex = 119;
            this.TV_Connect_Used.Text = "使用TV连接配置";
            this.TV_Connect_Used.UseVisualStyleBackColor = true;
            this.TV_Connect_Used.CheckedChanged += new System.EventHandler(this.TV_Connect_Used_CheckedChanged);
            // 
            // groupBox_tv_connect
            // 
            this.groupBox_tv_connect.Controls.Add(this.radioButton_串口);
            this.groupBox_tv_connect.Controls.Add(this.radioButton_网口);
            this.groupBox_tv_connect.Controls.Add(this.label35);
            this.groupBox_tv_connect.Controls.Add(this.groupBox_tv串口);
            this.groupBox_tv_connect.Controls.Add(this.groupBox_tv网口);
            this.groupBox_tv_connect.Location = new System.Drawing.Point(32, 95);
            this.groupBox_tv_connect.Name = "groupBox_tv_connect";
            this.groupBox_tv_connect.Size = new System.Drawing.Size(769, 423);
            this.groupBox_tv_connect.TabIndex = 118;
            this.groupBox_tv_connect.TabStop = false;
            this.groupBox_tv_connect.Text = "TV连接配置";
            // 
            // radioButton_串口
            // 
            this.radioButton_串口.AutoSize = true;
            this.radioButton_串口.Location = new System.Drawing.Point(329, 44);
            this.radioButton_串口.Name = "radioButton_串口";
            this.radioButton_串口.Size = new System.Drawing.Size(47, 16);
            this.radioButton_串口.TabIndex = 115;
            this.radioButton_串口.TabStop = true;
            this.radioButton_串口.Text = "串口";
            this.radioButton_串口.UseVisualStyleBackColor = true;
            this.radioButton_串口.CheckedChanged += new System.EventHandler(this.radioButton_串口_CheckedChanged);
            // 
            // radioButton_网口
            // 
            this.radioButton_网口.AutoSize = true;
            this.radioButton_网口.Checked = true;
            this.radioButton_网口.Location = new System.Drawing.Point(261, 44);
            this.radioButton_网口.Name = "radioButton_网口";
            this.radioButton_网口.Size = new System.Drawing.Size(47, 16);
            this.radioButton_网口.TabIndex = 114;
            this.radioButton_网口.TabStop = true;
            this.radioButton_网口.Text = "网口";
            this.radioButton_网口.UseVisualStyleBackColor = true;
            this.radioButton_网口.CheckedChanged += new System.EventHandler(this.radioButton_网口_CheckedChanged);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(170, 46);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(77, 12);
            this.label35.TabIndex = 113;
            this.label35.Text = "TV连接方式：";
            // 
            // groupBox_tv串口
            // 
            this.groupBox_tv串口.Controls.Add(this.label2);
            this.groupBox_tv串口.Controls.Add(this.lb_message);
            this.groupBox_tv串口.Controls.Add(this.btn_search_serial_no);
            this.groupBox_tv串口.Controls.Add(this.label7);
            this.groupBox_tv串口.Controls.Add(this.TV_Machine_Keywords);
            this.groupBox_tv串口.Controls.Add(this.TV_SerialPort_PortName);
            this.groupBox_tv串口.Controls.Add(this.TV_SerialPort_Parity);
            this.groupBox_tv串口.Controls.Add(this.TV_SerialPort_StopBits);
            this.groupBox_tv串口.Controls.Add(this.label36);
            this.groupBox_tv串口.Controls.Add(this.TV_SerialPort_DataBits);
            this.groupBox_tv串口.Controls.Add(this.TV_SerialPort_BaudRate);
            this.groupBox_tv串口.Controls.Add(this.label37);
            this.groupBox_tv串口.Controls.Add(this.label43);
            this.groupBox_tv串口.Controls.Add(this.label44);
            this.groupBox_tv串口.Controls.Add(this.label45);
            this.groupBox_tv串口.Enabled = false;
            this.groupBox_tv串口.Location = new System.Drawing.Point(297, 117);
            this.groupBox_tv串口.Name = "groupBox_tv串口";
            this.groupBox_tv串口.Size = new System.Drawing.Size(442, 286);
            this.groupBox_tv串口.TabIndex = 112;
            this.groupBox_tv串口.TabStop = false;
            this.groupBox_tv串口.Text = "TV 串口连接配置";
            // 
            // lb_message
            // 
            this.lb_message.AutoSize = true;
            this.lb_message.Location = new System.Drawing.Point(199, 256);
            this.lb_message.Name = "lb_message";
            this.lb_message.Size = new System.Drawing.Size(0, 12);
            this.lb_message.TabIndex = 115;
            // 
            // btn_search_serial_no
            // 
            this.btn_search_serial_no.Location = new System.Drawing.Point(280, 219);
            this.btn_search_serial_no.Name = "btn_search_serial_no";
            this.btn_search_serial_no.Size = new System.Drawing.Size(75, 23);
            this.btn_search_serial_no.TabIndex = 114;
            this.btn_search_serial_no.Text = "查找串口";
            this.btn_search_serial_no.UseVisualStyleBackColor = true;
            this.btn_search_serial_no.Click += new System.EventHandler(this.btn_search_serial_no_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 197);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(263, 12);
            this.label7.TabIndex = 112;
            this.label7.Text = "设备管理器关键字（用于自动查找串口编号 ）：";
            // 
            // TV_Machine_Keywords
            // 
            this.TV_Machine_Keywords.Location = new System.Drawing.Point(97, 222);
            this.TV_Machine_Keywords.Name = "TV_Machine_Keywords";
            this.TV_Machine_Keywords.Size = new System.Drawing.Size(176, 21);
            this.TV_Machine_Keywords.TabIndex = 113;
            this.TV_Machine_Keywords.Text = "CH340";
            // 
            // TV_SerialPort_PortName
            // 
            this.TV_SerialPort_PortName.FormattingEnabled = true;
            this.TV_SerialPort_PortName.Location = new System.Drawing.Point(97, 25);
            this.TV_SerialPort_PortName.Name = "TV_SerialPort_PortName";
            this.TV_SerialPort_PortName.Size = new System.Drawing.Size(64, 20);
            this.TV_SerialPort_PortName.TabIndex = 104;
            // 
            // TV_SerialPort_Parity
            // 
            this.TV_SerialPort_Parity.FormattingEnabled = true;
            this.TV_SerialPort_Parity.Items.AddRange(new object[] {
            "Even"});
            this.TV_SerialPort_Parity.Location = new System.Drawing.Point(97, 148);
            this.TV_SerialPort_Parity.Name = "TV_SerialPort_Parity";
            this.TV_SerialPort_Parity.Size = new System.Drawing.Size(55, 20);
            this.TV_SerialPort_Parity.TabIndex = 103;
            this.TV_SerialPort_Parity.Text = "None";
            // 
            // TV_SerialPort_StopBits
            // 
            this.TV_SerialPort_StopBits.Location = new System.Drawing.Point(97, 117);
            this.TV_SerialPort_StopBits.Name = "TV_SerialPort_StopBits";
            this.TV_SerialPort_StopBits.Size = new System.Drawing.Size(32, 21);
            this.TV_SerialPort_StopBits.TabIndex = 102;
            this.TV_SerialPort_StopBits.Text = "1";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(26, 120);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(53, 12);
            this.label36.TabIndex = 101;
            this.label36.Text = "停止位：";
            // 
            // TV_SerialPort_DataBits
            // 
            this.TV_SerialPort_DataBits.Location = new System.Drawing.Point(97, 85);
            this.TV_SerialPort_DataBits.Name = "TV_SerialPort_DataBits";
            this.TV_SerialPort_DataBits.Size = new System.Drawing.Size(32, 21);
            this.TV_SerialPort_DataBits.TabIndex = 100;
            this.TV_SerialPort_DataBits.Text = "8";
            // 
            // TV_SerialPort_BaudRate
            // 
            this.TV_SerialPort_BaudRate.Location = new System.Drawing.Point(97, 55);
            this.TV_SerialPort_BaudRate.Name = "TV_SerialPort_BaudRate";
            this.TV_SerialPort_BaudRate.Size = new System.Drawing.Size(63, 21);
            this.TV_SerialPort_BaudRate.TabIndex = 99;
            this.TV_SerialPort_BaudRate.Text = "115200";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(14, 151);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(65, 12);
            this.label37.TabIndex = 98;
            this.label37.Text = "奇偶校验：";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(26, 88);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(53, 12);
            this.label43.TabIndex = 97;
            this.label43.Text = "数据位：";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(26, 58);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(53, 12);
            this.label44.TabIndex = 96;
            this.label44.Text = "波特率：";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(26, 28);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(53, 12);
            this.label45.TabIndex = 95;
            this.label45.Text = "端口号：";
            // 
            // groupBox_tv网口
            // 
            this.groupBox_tv网口.Controls.Add(this.TV_IP);
            this.groupBox_tv网口.Controls.Add(this.label23);
            this.groupBox_tv网口.Controls.Add(this.TV_Port);
            this.groupBox_tv网口.Controls.Add(this.label16);
            this.groupBox_tv网口.Location = new System.Drawing.Point(26, 117);
            this.groupBox_tv网口.Name = "groupBox_tv网口";
            this.groupBox_tv网口.Size = new System.Drawing.Size(212, 100);
            this.groupBox_tv网口.TabIndex = 111;
            this.groupBox_tv网口.TabStop = false;
            this.groupBox_tv网口.Text = "TV 网口连接设置";
            // 
            // TV_IP
            // 
            this.TV_IP.Location = new System.Drawing.Point(82, 26);
            this.TV_IP.Name = "TV_IP";
            this.TV_IP.Size = new System.Drawing.Size(100, 21);
            this.TV_IP.TabIndex = 88;
            this.TV_IP.Text = "192.168.1.101";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(14, 31);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(65, 12);
            this.label23.TabIndex = 85;
            this.label23.Text = "电视机IP：";
            // 
            // TV_Port
            // 
            this.TV_Port.Location = new System.Drawing.Point(82, 60);
            this.TV_Port.Name = "TV_Port";
            this.TV_Port.Size = new System.Drawing.Size(47, 21);
            this.TV_Port.TabIndex = 90;
            this.TV_Port.Text = "9100";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(23, 66);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 12);
            this.label16.TabIndex = 89;
            this.label16.Text = "端口号：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(296, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 40);
            this.label1.TabIndex = 120;
            this.label1.Text = "TV通讯设置";
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(696, 524);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 122;
            this.btn_cancel.Text = "关闭";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(606, 524);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 121;
            this.btn_save.Text = "保存";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(220, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 12);
            this.label2.TabIndex = 116;
            this.label2.Text = "标准配置：115200,8,1,None";
            // 
            // Form_Setup_TV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 559);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TV_Connect_Used);
            this.Controls.Add(this.groupBox_tv_connect);
            this.Name = "Form_Setup_TV";
            this.Text = "TV通讯设置";
            this.Load += new System.EventHandler(this.Form_Setup_TV_Load);
            this.groupBox_tv_connect.ResumeLayout(false);
            this.groupBox_tv_connect.PerformLayout();
            this.groupBox_tv串口.ResumeLayout(false);
            this.groupBox_tv串口.PerformLayout();
            this.groupBox_tv网口.ResumeLayout(false);
            this.groupBox_tv网口.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox TV_Connect_Used;
        private System.Windows.Forms.GroupBox groupBox_tv_connect;
        private System.Windows.Forms.RadioButton radioButton_串口;
        private System.Windows.Forms.RadioButton radioButton_网口;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.GroupBox groupBox_tv串口;
        private System.Windows.Forms.ComboBox TV_SerialPort_PortName;
        private System.Windows.Forms.ComboBox TV_SerialPort_Parity;
        private System.Windows.Forms.TextBox TV_SerialPort_StopBits;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TextBox TV_SerialPort_DataBits;
        private System.Windows.Forms.TextBox TV_SerialPort_BaudRate;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.GroupBox groupBox_tv网口;
        private System.Windows.Forms.TextBox TV_IP;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox TV_Port;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_search_serial_no;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TV_Machine_Keywords;
        private System.Windows.Forms.Label lb_message;
        private System.Windows.Forms.Label label2;
    }
}