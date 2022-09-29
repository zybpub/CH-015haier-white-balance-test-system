namespace colortv_test_automation
{
    partial class Form_PLC
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
            this.lb_connect_info = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbPLC_station = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbPLC_port = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPLC_ip = new System.Windows.Forms.TextBox();
            this.lb_reg_write_message = new System.Windows.Forms.Label();
            this.lb_reg = new System.Windows.Forms.Label();
            this.btn_reg_read = new System.Windows.Forms.Button();
            this.tb_control_register = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_value = new System.Windows.Forms.TextBox();
            this.btn_reg_write = new System.Windows.Forms.Button();
            this.btn_client_disconnect = new System.Windows.Forms.Button();
            this.btn_client_connect = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.btn_write1 = new System.Windows.Forms.Button();
            this.btn_write3 = new System.Windows.Forms.Button();
            this.tb_light_register = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_light2 = new System.Windows.Forms.Button();
            this.btn_light3 = new System.Windows.Forms.Button();
            this.btn_light1 = new System.Windows.Forms.Button();
            this.lb_start = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.tb_start_reg = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tb_startregvalue = new System.Windows.Forms.TextBox();
            this.button9 = new System.Windows.Forms.Button();
            this.lb_sn = new System.Windows.Forms.Label();
            this.btn_sn_read = new System.Windows.Forms.Button();
            this.tb_sn = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tb_snvalue = new System.Windows.Forms.TextBox();
            this.button12 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.lb_type = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.tb_type_addr = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.tb_type_writevalue = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lb_tvpass_readvalue = new System.Windows.Forms.Label();
            this.btn_tvpass_read = new System.Windows.Forms.Button();
            this.tb_tvpass_addr = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.tb_tvpass_writevalue = new System.Windows.Forms.TextBox();
            this.btn_tvpass_write = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.lb_light_readvalue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb_connect_info
            // 
            this.lb_connect_info.AutoSize = true;
            this.lb_connect_info.Location = new System.Drawing.Point(377, 160);
            this.lb_connect_info.Name = "lb_connect_info";
            this.lb_connect_info.Size = new System.Drawing.Size(59, 12);
            this.lb_connect_info.TabIndex = 36;
            this.lb_connect_info.Text = "未连接PLC";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(50, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 35;
            this.label6.Text = "Station：";
            // 
            // tbPLC_station
            // 
            this.tbPLC_station.Location = new System.Drawing.Point(116, 164);
            this.tbPLC_station.Name = "tbPLC_station";
            this.tbPLC_station.Size = new System.Drawing.Size(80, 21);
            this.tbPLC_station.TabIndex = 34;
            this.tbPLC_station.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(68, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 33;
            this.label5.Text = "Port：";
            // 
            // tbPLC_port
            // 
            this.tbPLC_port.Location = new System.Drawing.Point(116, 133);
            this.tbPLC_port.Name = "tbPLC_port";
            this.tbPLC_port.Size = new System.Drawing.Size(80, 21);
            this.tbPLC_port.TabIndex = 32;
            this.tbPLC_port.Text = "502";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(78, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 31;
            this.label4.Text = "IP：";
            // 
            // tbPLC_ip
            // 
            this.tbPLC_ip.Location = new System.Drawing.Point(116, 106);
            this.tbPLC_ip.Name = "tbPLC_ip";
            this.tbPLC_ip.Size = new System.Drawing.Size(101, 21);
            this.tbPLC_ip.TabIndex = 30;
            this.tbPLC_ip.Text = "10.52.99.132";
            // 
            // lb_reg_write_message
            // 
            this.lb_reg_write_message.AutoSize = true;
            this.lb_reg_write_message.Location = new System.Drawing.Point(225, 391);
            this.lb_reg_write_message.Name = "lb_reg_write_message";
            this.lb_reg_write_message.Size = new System.Drawing.Size(47, 12);
            this.lb_reg_write_message.TabIndex = 29;
            this.lb_reg_write_message.Text = "message";
            // 
            // lb_reg
            // 
            this.lb_reg.AutoSize = true;
            this.lb_reg.Location = new System.Drawing.Point(501, 215);
            this.lb_reg.Name = "lb_reg";
            this.lb_reg.Size = new System.Drawing.Size(11, 12);
            this.lb_reg.TabIndex = 28;
            this.lb_reg.Text = "0";
            // 
            // btn_reg_read
            // 
            this.btn_reg_read.Enabled = false;
            this.btn_reg_read.Location = new System.Drawing.Point(424, 210);
            this.btn_reg_read.Name = "btn_reg_read";
            this.btn_reg_read.Size = new System.Drawing.Size(71, 22);
            this.btn_reg_read.TabIndex = 27;
            this.btn_reg_read.Text = "读取";
            this.btn_reg_read.UseVisualStyleBackColor = true;
            this.btn_reg_read.Click += new System.EventHandler(this.btn_reg_read_Click);
            // 
            // tb_control_register
            // 
            this.tb_control_register.Location = new System.Drawing.Point(145, 210);
            this.tb_control_register.Name = "tb_control_register";
            this.tb_control_register.Size = new System.Drawing.Size(45, 21);
            this.tb_control_register.TabIndex = 26;
            this.tb_control_register.Text = "4099";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 12);
            this.label3.TabIndex = 25;
            this.label3.Text = "线体控制寄存器：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(209, 213);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 24;
            this.label2.Text = "值：";
            // 
            // tb_value
            // 
            this.tb_value.Location = new System.Drawing.Point(257, 211);
            this.tb_value.Name = "tb_value";
            this.tb_value.Size = new System.Drawing.Size(62, 21);
            this.tb_value.TabIndex = 23;
            this.tb_value.Text = "1";
            // 
            // btn_reg_write
            // 
            this.btn_reg_write.Location = new System.Drawing.Point(334, 211);
            this.btn_reg_write.Name = "btn_reg_write";
            this.btn_reg_write.Size = new System.Drawing.Size(75, 23);
            this.btn_reg_write.TabIndex = 22;
            this.btn_reg_write.Text = "写入";
            this.btn_reg_write.UseVisualStyleBackColor = true;
            this.btn_reg_write.Click += new System.EventHandler(this.btn_reg_write_Click);
            // 
            // btn_client_disconnect
            // 
            this.btn_client_disconnect.Enabled = false;
            this.btn_client_disconnect.Location = new System.Drawing.Point(227, 150);
            this.btn_client_disconnect.Name = "btn_client_disconnect";
            this.btn_client_disconnect.Size = new System.Drawing.Size(137, 47);
            this.btn_client_disconnect.TabIndex = 20;
            this.btn_client_disconnect.Text = "断开服务端";
            this.btn_client_disconnect.UseVisualStyleBackColor = true;
            // 
            // btn_client_connect
            // 
            this.btn_client_connect.Location = new System.Drawing.Point(227, 97);
            this.btn_client_connect.Name = "btn_client_connect";
            this.btn_client_connect.Size = new System.Drawing.Size(137, 47);
            this.btn_client_connect.TabIndex = 21;
            this.btn_client_connect.Text = "连接服务端";
            this.btn_client_connect.UseVisualStyleBackColor = true;
            this.btn_client_connect.Click += new System.EventHandler(this.btn_client_connect_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(475, 269);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 23);
            this.button1.TabIndex = 42;
            this.button1.Text = "写入2(松开到位)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(334, 240);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(123, 23);
            this.button2.TabIndex = 43;
            this.button2.Text = "写入4(合上对接)";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(334, 269);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(123, 23);
            this.button3.TabIndex = 44;
            this.button3.Text = "写入5(松开对接)";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(334, 299);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(121, 23);
            this.button7.TabIndex = 44;
            this.button7.Text = "写入6(未使用)";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button3_Click);
            // 
            // btn_write1
            // 
            this.btn_write1.Location = new System.Drawing.Point(475, 240);
            this.btn_write1.Name = "btn_write1";
            this.btn_write1.Size = new System.Drawing.Size(105, 23);
            this.btn_write1.TabIndex = 42;
            this.btn_write1.Text = "写入1(合上到位)";
            this.btn_write1.UseVisualStyleBackColor = true;
            this.btn_write1.Click += new System.EventHandler(this.btn_write1_Click);
            // 
            // btn_write3
            // 
            this.btn_write3.Location = new System.Drawing.Point(475, 299);
            this.btn_write3.Name = "btn_write3";
            this.btn_write3.Size = new System.Drawing.Size(105, 23);
            this.btn_write3.TabIndex = 42;
            this.btn_write3.Text = "写入3(未使用)";
            this.btn_write3.UseVisualStyleBackColor = true;
            this.btn_write3.Click += new System.EventHandler(this.btn_write3_Click);
            // 
            // tb_light_register
            // 
            this.tb_light_register.Location = new System.Drawing.Point(146, 361);
            this.tb_light_register.Name = "tb_light_register";
            this.tb_light_register.Size = new System.Drawing.Size(45, 21);
            this.tb_light_register.TabIndex = 51;
            this.tb_light_register.Text = "4119";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(39, 367);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 12);
            this.label8.TabIndex = 50;
            this.label8.Text = "信号灯控制寄存器：";
            // 
            // btn_light2
            // 
            this.btn_light2.Location = new System.Drawing.Point(343, 362);
            this.btn_light2.Name = "btn_light2";
            this.btn_light2.Size = new System.Drawing.Size(93, 23);
            this.btn_light2.TabIndex = 52;
            this.btn_light2.Text = "写入2（红）";
            this.btn_light2.UseVisualStyleBackColor = true;
            this.btn_light2.Click += new System.EventHandler(this.btn_light2_Click);
            // 
            // btn_light3
            // 
            this.btn_light3.Location = new System.Drawing.Point(460, 362);
            this.btn_light3.Name = "btn_light3";
            this.btn_light3.Size = new System.Drawing.Size(93, 23);
            this.btn_light3.TabIndex = 53;
            this.btn_light3.Text = "写入3（黄）";
            this.btn_light3.UseVisualStyleBackColor = true;
            this.btn_light3.Click += new System.EventHandler(this.btn_light3_Click);
            // 
            // btn_light1
            // 
            this.btn_light1.Location = new System.Drawing.Point(227, 362);
            this.btn_light1.Name = "btn_light1";
            this.btn_light1.Size = new System.Drawing.Size(93, 23);
            this.btn_light1.TabIndex = 54;
            this.btn_light1.Text = "写入1（绿）";
            this.btn_light1.UseVisualStyleBackColor = true;
            this.btn_light1.Click += new System.EventHandler(this.btn_light1_Click);
            // 
            // lb_start
            // 
            this.lb_start.AutoSize = true;
            this.lb_start.Location = new System.Drawing.Point(474, 437);
            this.lb_start.Name = "lb_start";
            this.lb_start.Size = new System.Drawing.Size(11, 12);
            this.lb_start.TabIndex = 61;
            this.lb_start.Text = "0";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(397, 432);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(71, 22);
            this.button8.TabIndex = 60;
            this.button8.Text = "读取";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // tb_start_reg
            // 
            this.tb_start_reg.Location = new System.Drawing.Point(141, 431);
            this.tb_start_reg.Name = "tb_start_reg";
            this.tb_start_reg.Size = new System.Drawing.Size(45, 21);
            this.tb_start_reg.TabIndex = 59;
            this.tb_start_reg.Text = "5000";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 437);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(125, 12);
            this.label10.TabIndex = 58;
            this.label10.Text = "测试开始控制寄存器：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(192, 434);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 57;
            this.label11.Text = "值：";
            // 
            // tb_startregvalue
            // 
            this.tb_startregvalue.Location = new System.Drawing.Point(240, 432);
            this.tb_startregvalue.Name = "tb_startregvalue";
            this.tb_startregvalue.Size = new System.Drawing.Size(62, 21);
            this.tb_startregvalue.TabIndex = 56;
            this.tb_startregvalue.Text = "1";
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(317, 432);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(74, 23);
            this.button9.TabIndex = 55;
            this.button9.Text = "写入";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // lb_sn
            // 
            this.lb_sn.AutoSize = true;
            this.lb_sn.Location = new System.Drawing.Point(317, 583);
            this.lb_sn.Name = "lb_sn";
            this.lb_sn.Size = new System.Drawing.Size(23, 12);
            this.lb_sn.TabIndex = 68;
            this.lb_sn.Text = "SN:";
            // 
            // btn_sn_read
            // 
            this.btn_sn_read.Location = new System.Drawing.Point(240, 578);
            this.btn_sn_read.Name = "btn_sn_read";
            this.btn_sn_read.Size = new System.Drawing.Size(71, 22);
            this.btn_sn_read.TabIndex = 67;
            this.btn_sn_read.Text = "读取sn";
            this.btn_sn_read.UseVisualStyleBackColor = true;
            this.btn_sn_read.Click += new System.EventHandler(this.button11_Click);
            // 
            // tb_sn
            // 
            this.tb_sn.Location = new System.Drawing.Point(141, 550);
            this.tb_sn.Name = "tb_sn";
            this.tb_sn.Size = new System.Drawing.Size(45, 21);
            this.tb_sn.TabIndex = 66;
            this.tb_sn.Text = "5022";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(61, 555);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 65;
            this.label12.Text = "SN寄存器：";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(192, 553);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 12);
            this.label13.TabIndex = 64;
            this.label13.Text = "值：";
            // 
            // tb_snvalue
            // 
            this.tb_snvalue.Location = new System.Drawing.Point(240, 551);
            this.tb_snvalue.Name = "tb_snvalue";
            this.tb_snvalue.Size = new System.Drawing.Size(315, 21);
            this.tb_snvalue.TabIndex = 63;
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(561, 550);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(75, 23);
            this.button12.TabIndex = 62;
            this.button12.Text = "写入sn";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(117, 391);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 69;
            this.label1.Text = "默认值：4119";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(100, 234);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 70;
            this.label9.Text = "默认值：4099";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(102, 455);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 12);
            this.label14.TabIndex = 71;
            this.label14.Text = "默认值：5000";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(97, 575);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(77, 12);
            this.label15.TabIndex = 72;
            this.label15.Text = "默认值：5022";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(505, 437);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(131, 12);
            this.label16.TabIndex = 73;
            this.label16.Text = "1:mes下达启动测试信号";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(597, 660);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 27);
            this.button4.TabIndex = 41;
            this.button4.Text = "关闭";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(97, 512);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(77, 12);
            this.label17.TabIndex = 81;
            this.label17.Text = "默认值：5002";
            // 
            // lb_type
            // 
            this.lb_type.AutoSize = true;
            this.lb_type.Location = new System.Drawing.Point(317, 520);
            this.lb_type.Name = "lb_type";
            this.lb_type.Size = new System.Drawing.Size(35, 12);
            this.lb_type.TabIndex = 80;
            this.lb_type.Text = "Type:";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(240, 515);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(71, 22);
            this.button5.TabIndex = 79;
            this.button5.Text = "读取type";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // tb_type_addr
            // 
            this.tb_type_addr.Location = new System.Drawing.Point(141, 487);
            this.tb_type_addr.Name = "tb_type_addr";
            this.tb_type_addr.Size = new System.Drawing.Size(45, 21);
            this.tb_type_addr.TabIndex = 78;
            this.tb_type_addr.Text = "5002";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(61, 492);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(77, 12);
            this.label19.TabIndex = 77;
            this.label19.Text = "型号寄存器：";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(192, 490);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(29, 12);
            this.label20.TabIndex = 76;
            this.label20.Text = "值：";
            // 
            // tb_type_writevalue
            // 
            this.tb_type_writevalue.Location = new System.Drawing.Point(240, 488);
            this.tb_type_writevalue.Name = "tb_type_writevalue";
            this.tb_type_writevalue.Size = new System.Drawing.Size(315, 21);
            this.tb_type_writevalue.TabIndex = 75;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(561, 487);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 74;
            this.button6.Text = "写入type";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click_1);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(235, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(216, 27);
            this.label7.TabIndex = 82;
            this.label7.Text = "PLC读写控制测试";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(543, 618);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(59, 12);
            this.label18.TabIndex = 91;
            this.label18.Text = "写入1放行";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(102, 639);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(77, 12);
            this.label21.TabIndex = 90;
            this.label21.Text = "默认值：5001";
            // 
            // lb_tvpass_readvalue
            // 
            this.lb_tvpass_readvalue.AutoSize = true;
            this.lb_tvpass_readvalue.Location = new System.Drawing.Point(474, 621);
            this.lb_tvpass_readvalue.Name = "lb_tvpass_readvalue";
            this.lb_tvpass_readvalue.Size = new System.Drawing.Size(11, 12);
            this.lb_tvpass_readvalue.TabIndex = 89;
            this.lb_tvpass_readvalue.Text = "0";
            // 
            // btn_tvpass_read
            // 
            this.btn_tvpass_read.Location = new System.Drawing.Point(397, 616);
            this.btn_tvpass_read.Name = "btn_tvpass_read";
            this.btn_tvpass_read.Size = new System.Drawing.Size(71, 22);
            this.btn_tvpass_read.TabIndex = 88;
            this.btn_tvpass_read.Text = "读取";
            this.btn_tvpass_read.UseVisualStyleBackColor = true;
            this.btn_tvpass_read.Click += new System.EventHandler(this.btn_tvpass_read_Click);
            // 
            // tb_tvpass_addr
            // 
            this.tb_tvpass_addr.Location = new System.Drawing.Point(141, 615);
            this.tb_tvpass_addr.Name = "tb_tvpass_addr";
            this.tb_tvpass_addr.Size = new System.Drawing.Size(45, 21);
            this.tb_tvpass_addr.TabIndex = 87;
            this.tb_tvpass_addr.Text = "5001";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(61, 616);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(65, 12);
            this.label23.TabIndex = 86;
            this.label23.Text = "产品放行：";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(192, 618);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(29, 12);
            this.label24.TabIndex = 85;
            this.label24.Text = "值：";
            // 
            // tb_tvpass_writevalue
            // 
            this.tb_tvpass_writevalue.Location = new System.Drawing.Point(240, 616);
            this.tb_tvpass_writevalue.Name = "tb_tvpass_writevalue";
            this.tb_tvpass_writevalue.Size = new System.Drawing.Size(62, 21);
            this.tb_tvpass_writevalue.TabIndex = 84;
            this.tb_tvpass_writevalue.Text = "1";
            // 
            // btn_tvpass_write
            // 
            this.btn_tvpass_write.Location = new System.Drawing.Point(317, 616);
            this.btn_tvpass_write.Name = "btn_tvpass_write";
            this.btn_tvpass_write.Size = new System.Drawing.Size(74, 23);
            this.btn_tvpass_write.TabIndex = 83;
            this.btn_tvpass_write.Text = "写入";
            this.btn_tvpass_write.UseVisualStyleBackColor = true;
            this.btn_tvpass_write.Click += new System.EventHandler(this.btn_tvpass_write_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(561, 362);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(71, 22);
            this.button10.TabIndex = 92;
            this.button10.Text = "读取";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // lb_light_readvalue
            // 
            this.lb_light_readvalue.AutoSize = true;
            this.lb_light_readvalue.Location = new System.Drawing.Point(638, 367);
            this.lb_light_readvalue.Name = "lb_light_readvalue";
            this.lb_light_readvalue.Size = new System.Drawing.Size(11, 12);
            this.lb_light_readvalue.TabIndex = 93;
            this.lb_light_readvalue.Text = "0";
            // 
            // Form_PLC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 699);
            this.Controls.Add(this.lb_light_readvalue);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.lb_tvpass_readvalue);
            this.Controls.Add(this.btn_tvpass_read);
            this.Controls.Add(this.tb_tvpass_addr);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.tb_tvpass_writevalue);
            this.Controls.Add(this.btn_tvpass_write);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.lb_type);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.tb_type_addr);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.tb_type_writevalue);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lb_sn);
            this.Controls.Add(this.btn_sn_read);
            this.Controls.Add(this.tb_sn);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.tb_snvalue);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.lb_start);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.tb_start_reg);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tb_startregvalue);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.btn_light2);
            this.Controls.Add(this.btn_light3);
            this.Controls.Add(this.btn_light1);
            this.Controls.Add(this.tb_light_register);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_write3);
            this.Controls.Add(this.btn_write1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.lb_connect_info);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbPLC_station);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbPLC_port);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbPLC_ip);
            this.Controls.Add(this.lb_reg_write_message);
            this.Controls.Add(this.lb_reg);
            this.Controls.Add(this.btn_reg_read);
            this.Controls.Add(this.tb_control_register);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_value);
            this.Controls.Add(this.btn_reg_write);
            this.Controls.Add(this.btn_client_disconnect);
            this.Controls.Add(this.btn_client_connect);
            this.Name = "Form_PLC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PLC测试";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_PLC_FormClosing);
            this.Load += new System.EventHandler(this.Form_PLC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_connect_info;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbPLC_station;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbPLC_port;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbPLC_ip;
        private System.Windows.Forms.Label lb_reg_write_message;
        private System.Windows.Forms.Label lb_reg;
        private System.Windows.Forms.Button btn_reg_read;
        private System.Windows.Forms.TextBox tb_control_register;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_value;
        private System.Windows.Forms.Button btn_reg_write;
        private System.Windows.Forms.Button btn_client_disconnect;
        private System.Windows.Forms.Button btn_client_connect;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button btn_write1;
        private System.Windows.Forms.Button btn_write3;
        private System.Windows.Forms.TextBox tb_light_register;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_light2;
        private System.Windows.Forms.Button btn_light3;
        private System.Windows.Forms.Button btn_light1;
        private System.Windows.Forms.Label lb_start;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.TextBox tb_start_reg;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tb_startregvalue;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label lb_sn;
        private System.Windows.Forms.Button btn_sn_read;
        private System.Windows.Forms.TextBox tb_sn;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tb_snvalue;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lb_type;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox tb_type_addr;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox tb_type_writevalue;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lb_tvpass_readvalue;
        private System.Windows.Forms.Button btn_tvpass_read;
        private System.Windows.Forms.TextBox tb_tvpass_addr;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox tb_tvpass_writevalue;
        private System.Windows.Forms.Button btn_tvpass_write;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Label lb_light_readvalue;
    }
}