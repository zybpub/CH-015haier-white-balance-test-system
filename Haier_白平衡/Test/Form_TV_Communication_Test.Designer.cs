namespace Test_Automation
{
    partial class Form_TV_Communication_Test
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
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbmemo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_baut = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbb_tv = new System.Windows.Forms.ComboBox();
            this.com_TV = new System.IO.Ports.SerialPort(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.tb_r = new System.Windows.Forms.TextBox();
            this.btn_sendr = new System.Windows.Forms.Button();
            this.btn_sendg = new System.Windows.Forms.Button();
            this.tb_g = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_sendb = new System.Windows.Forms.Button();
            this.tb_b = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tb_t = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_y = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tb_x = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_port_close = new System.Windows.Forms.Button();
            this.btn_r_add = new System.Windows.Forms.Button();
            this.btn_r_minus = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.btn_sendall = new System.Windows.Forms.Button();
            this.tb_result = new System.Windows.Forms.TextBox();
            this.tb_cmd = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_cool = new System.Windows.Forms.Button();
            this.btn_stand = new System.Windows.Forms.Button();
            this.btn_warm = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.btn_20 = new System.Windows.Forms.Button();
            this.btn_80 = new System.Windows.Forms.Button();
            this.btn_100 = new System.Windows.Forms.Button();
            this.btn_GET_USR_B_GAN = new System.Windows.Forms.Button();
            this.btn_GET_USR_G_GAN = new System.Windows.Forms.Button();
            this.btn_GET_USR_R_GAN = new System.Windows.Forms.Button();
            this.btn_dtv = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(267, 31);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 28);
            this.button2.TabIndex = 1;
            this.button2.Text = "打开端口";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 327);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "接收";
            // 
            // tbmemo
            // 
            this.tbmemo.Location = new System.Drawing.Point(44, 352);
            this.tbmemo.Multiline = true;
            this.tbmemo.Name = "tbmemo";
            this.tbmemo.Size = new System.Drawing.Size(429, 212);
            this.tbmemo.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "端口号：";
            // 
            // tb_baut
            // 
            this.tb_baut.Location = new System.Drawing.Point(101, 79);
            this.tb_baut.Name = "tb_baut";
            this.tb_baut.Size = new System.Drawing.Size(104, 21);
            this.tb_baut.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "波特率：";
            // 
            // cbb_tv
            // 
            this.cbb_tv.FormattingEnabled = true;
            this.cbb_tv.Location = new System.Drawing.Point(101, 35);
            this.cbb_tv.Name = "cbb_tv";
            this.cbb_tv.Size = new System.Drawing.Size(104, 20);
            this.cbb_tv.TabIndex = 8;
            // 
            // com_TV
            // 
            this.com_TV.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.com_TV_DataReceived);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(521, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "R：";
            // 
            // tb_r
            // 
            this.tb_r.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_r.Location = new System.Drawing.Point(542, 29);
            this.tb_r.Name = "tb_r";
            this.tb_r.Size = new System.Drawing.Size(53, 26);
            this.tb_r.TabIndex = 11;
            this.tb_r.Text = "1024";
            // 
            // btn_sendr
            // 
            this.btn_sendr.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_sendr.Location = new System.Drawing.Point(693, 29);
            this.btn_sendr.Name = "btn_sendr";
            this.btn_sendr.Size = new System.Drawing.Size(93, 27);
            this.btn_sendr.TabIndex = 12;
            this.btn_sendr.Text = "发送R到TV";
            this.btn_sendr.UseVisualStyleBackColor = true;
            this.btn_sendr.Click += new System.EventHandler(this.btn_sendr_Click);
            // 
            // btn_sendg
            // 
            this.btn_sendg.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_sendg.Location = new System.Drawing.Point(693, 56);
            this.btn_sendg.Name = "btn_sendg";
            this.btn_sendg.Size = new System.Drawing.Size(93, 29);
            this.btn_sendg.TabIndex = 15;
            this.btn_sendg.Text = "发送G到TV";
            this.btn_sendg.UseVisualStyleBackColor = true;
            this.btn_sendg.Click += new System.EventHandler(this.btn_sendg_Click);
            // 
            // tb_g
            // 
            this.tb_g.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_g.Location = new System.Drawing.Point(542, 56);
            this.tb_g.Name = "tb_g";
            this.tb_g.Size = new System.Drawing.Size(53, 26);
            this.tb_g.TabIndex = 14;
            this.tb_g.Text = "1024";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(521, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 16);
            this.label5.TabIndex = 13;
            this.label5.Text = "G：";
            // 
            // btn_sendb
            // 
            this.btn_sendb.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_sendb.Location = new System.Drawing.Point(693, 85);
            this.btn_sendb.Name = "btn_sendb";
            this.btn_sendb.Size = new System.Drawing.Size(93, 29);
            this.btn_sendb.TabIndex = 18;
            this.btn_sendb.Text = "发送B到TV";
            this.btn_sendb.UseVisualStyleBackColor = true;
            this.btn_sendb.Click += new System.EventHandler(this.btn_sendb_Click);
            // 
            // tb_b
            // 
            this.tb_b.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_b.Location = new System.Drawing.Point(542, 85);
            this.tb_b.Name = "tb_b";
            this.tb_b.Size = new System.Drawing.Size(53, 26);
            this.tb_b.TabIndex = 17;
            this.tb_b.Text = "1024";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(521, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 16);
            this.label6.TabIndex = 16;
            this.label6.Text = "B：";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(862, 131);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 26);
            this.button1.TabIndex = 19;
            this.button1.Text = "获取亮度值";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // tb_t
            // 
            this.tb_t.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_t.Location = new System.Drawing.Point(762, 131);
            this.tb_t.Name = "tb_t";
            this.tb_t.Size = new System.Drawing.Size(77, 26);
            this.tb_t.TabIndex = 25;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(741, 136);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 16);
            this.label7.TabIndex = 24;
            this.label7.Text = "t：";
            // 
            // tb_y
            // 
            this.tb_y.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_y.Location = new System.Drawing.Point(646, 131);
            this.tb_y.Name = "tb_y";
            this.tb_y.Size = new System.Drawing.Size(73, 26);
            this.tb_y.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(625, 136);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 16);
            this.label8.TabIndex = 22;
            this.label8.Text = "y：";
            // 
            // tb_x
            // 
            this.tb_x.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_x.Location = new System.Drawing.Point(542, 131);
            this.tb_x.Name = "tb_x";
            this.tb_x.Size = new System.Drawing.Size(66, 26);
            this.tb_x.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(521, 136);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 16);
            this.label9.TabIndex = 20;
            this.label9.Text = "x：";
            // 
            // btn_port_close
            // 
            this.btn_port_close.Location = new System.Drawing.Point(267, 72);
            this.btn_port_close.Name = "btn_port_close";
            this.btn_port_close.Size = new System.Drawing.Size(80, 28);
            this.btn_port_close.TabIndex = 29;
            this.btn_port_close.Text = "关闭端口";
            this.btn_port_close.UseVisualStyleBackColor = true;
            this.btn_port_close.Click += new System.EventHandler(this.btn_port_close_Click);
            // 
            // btn_r_add
            // 
            this.btn_r_add.Location = new System.Drawing.Point(610, 30);
            this.btn_r_add.Name = "btn_r_add";
            this.btn_r_add.Size = new System.Drawing.Size(23, 26);
            this.btn_r_add.TabIndex = 30;
            this.btn_r_add.Text = "+";
            this.btn_r_add.UseVisualStyleBackColor = true;
            this.btn_r_add.Click += new System.EventHandler(this.btn_r_add_Click);
            // 
            // btn_r_minus
            // 
            this.btn_r_minus.Location = new System.Drawing.Point(639, 30);
            this.btn_r_minus.Name = "btn_r_minus";
            this.btn_r_minus.Size = new System.Drawing.Size(23, 26);
            this.btn_r_minus.TabIndex = 31;
            this.btn_r_minus.Text = "-";
            this.btn_r_minus.UseVisualStyleBackColor = true;
            this.btn_r_minus.Click += new System.EventHandler(this.btn_r_minus_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(639, 59);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(23, 26);
            this.button3.TabIndex = 33;
            this.button3.Text = "-";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(610, 59);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(23, 26);
            this.button4.TabIndex = 32;
            this.button4.Text = "+";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(639, 88);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(23, 26);
            this.button5.TabIndex = 35;
            this.button5.Text = "-";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(610, 88);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(23, 26);
            this.button6.TabIndex = 34;
            this.button6.Text = "+";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // btn_sendall
            // 
            this.btn_sendall.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_sendall.Location = new System.Drawing.Point(823, 31);
            this.btn_sendall.Name = "btn_sendall";
            this.btn_sendall.Size = new System.Drawing.Size(98, 83);
            this.btn_sendall.TabIndex = 36;
            this.btn_sendall.Text = "全部发送";
            this.btn_sendall.UseVisualStyleBackColor = true;
            this.btn_sendall.Click += new System.EventHandler(this.btn_sendall_Click);
            // 
            // tb_result
            // 
            this.tb_result.Location = new System.Drawing.Point(499, 178);
            this.tb_result.Multiline = true;
            this.tb_result.Name = "tb_result";
            this.tb_result.Size = new System.Drawing.Size(462, 325);
            this.tb_result.TabIndex = 37;
            // 
            // tb_cmd
            // 
            this.tb_cmd.Location = new System.Drawing.Point(59, 258);
            this.tb_cmd.Name = "tb_cmd";
            this.tb_cmd.Size = new System.Drawing.Size(288, 21);
            this.tb_cmd.TabIndex = 38;
            this.tb_cmd.Text = "55 02 01 00 00 00 00 00 00 00 FD FE";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(81, 287);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(107, 29);
            this.button7.TabIndex = 39;
            this.button7.Text = "转换为byte数组";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(195, 290);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(278, 21);
            this.textBox1.TabIndex = 40;
            // 
            // btn_cool
            // 
            this.btn_cool.Location = new System.Drawing.Point(59, 121);
            this.btn_cool.Name = "btn_cool";
            this.btn_cool.Size = new System.Drawing.Size(72, 24);
            this.btn_cool.TabIndex = 41;
            this.btn_cool.Text = "cool";
            this.btn_cool.UseVisualStyleBackColor = true;
            this.btn_cool.Click += new System.EventHandler(this.button8_Click);
            // 
            // btn_stand
            // 
            this.btn_stand.Location = new System.Drawing.Point(165, 121);
            this.btn_stand.Name = "btn_stand";
            this.btn_stand.Size = new System.Drawing.Size(75, 23);
            this.btn_stand.TabIndex = 42;
            this.btn_stand.Text = "stand";
            this.btn_stand.UseVisualStyleBackColor = true;
            this.btn_stand.Click += new System.EventHandler(this.btn_stand_Click);
            // 
            // btn_warm
            // 
            this.btn_warm.Location = new System.Drawing.Point(267, 121);
            this.btn_warm.Name = "btn_warm";
            this.btn_warm.Size = new System.Drawing.Size(75, 23);
            this.btn_warm.TabIndex = 43;
            this.btn_warm.Text = "warm";
            this.btn_warm.UseVisualStyleBackColor = true;
            this.btn_warm.Click += new System.EventHandler(this.btn_warm_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(370, 152);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 44;
            this.button8.Text = "close";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click_1);
            // 
            // btn_20
            // 
            this.btn_20.Location = new System.Drawing.Point(165, 151);
            this.btn_20.Name = "btn_20";
            this.btn_20.Size = new System.Drawing.Size(75, 23);
            this.btn_20.TabIndex = 46;
            this.btn_20.Text = "20white";
            this.btn_20.UseVisualStyleBackColor = true;
            this.btn_20.Click += new System.EventHandler(this.btn_20_Click);
            // 
            // btn_80
            // 
            this.btn_80.Location = new System.Drawing.Point(59, 151);
            this.btn_80.Name = "btn_80";
            this.btn_80.Size = new System.Drawing.Size(72, 24);
            this.btn_80.TabIndex = 45;
            this.btn_80.Text = "80%white";
            this.btn_80.UseVisualStyleBackColor = true;
            this.btn_80.Click += new System.EventHandler(this.btn_80_Click);
            // 
            // btn_100
            // 
            this.btn_100.Location = new System.Drawing.Point(267, 152);
            this.btn_100.Name = "btn_100";
            this.btn_100.Size = new System.Drawing.Size(75, 23);
            this.btn_100.TabIndex = 47;
            this.btn_100.Text = "100white";
            this.btn_100.UseVisualStyleBackColor = true;
            this.btn_100.Click += new System.EventHandler(this.btn_100_Click);
            // 
            // btn_GET_USR_B_GAN
            // 
            this.btn_GET_USR_B_GAN.Location = new System.Drawing.Point(316, 182);
            this.btn_GET_USR_B_GAN.Name = "btn_GET_USR_B_GAN";
            this.btn_GET_USR_B_GAN.Size = new System.Drawing.Size(111, 23);
            this.btn_GET_USR_B_GAN.TabIndex = 50;
            this.btn_GET_USR_B_GAN.Text = "GET_USR_B_GAN";
            this.btn_GET_USR_B_GAN.UseVisualStyleBackColor = true;
            this.btn_GET_USR_B_GAN.Click += new System.EventHandler(this.btn_GET_USR_B_GAN_Click);
            // 
            // btn_GET_USR_G_GAN
            // 
            this.btn_GET_USR_G_GAN.Location = new System.Drawing.Point(195, 181);
            this.btn_GET_USR_G_GAN.Name = "btn_GET_USR_G_GAN";
            this.btn_GET_USR_G_GAN.Size = new System.Drawing.Size(96, 23);
            this.btn_GET_USR_G_GAN.TabIndex = 49;
            this.btn_GET_USR_G_GAN.Text = "GET_USR_G_GAN";
            this.btn_GET_USR_G_GAN.UseVisualStyleBackColor = true;
            this.btn_GET_USR_G_GAN.Click += new System.EventHandler(this.btn_GET_USR_G_GAN_Click);
            // 
            // btn_GET_USR_R_GAN
            // 
            this.btn_GET_USR_R_GAN.Location = new System.Drawing.Point(59, 181);
            this.btn_GET_USR_R_GAN.Name = "btn_GET_USR_R_GAN";
            this.btn_GET_USR_R_GAN.Size = new System.Drawing.Size(112, 24);
            this.btn_GET_USR_R_GAN.TabIndex = 48;
            this.btn_GET_USR_R_GAN.Text = "GET_USR_R_GAN";
            this.btn_GET_USR_R_GAN.UseVisualStyleBackColor = true;
            this.btn_GET_USR_R_GAN.Click += new System.EventHandler(this.btn_GET_USR_R_GAN_Click);
            // 
            // btn_dtv
            // 
            this.btn_dtv.Location = new System.Drawing.Point(59, 216);
            this.btn_dtv.Name = "btn_dtv";
            this.btn_dtv.Size = new System.Drawing.Size(145, 24);
            this.btn_dtv.TabIndex = 51;
            this.btn_dtv.Text = "发送切DTV指令";
            this.btn_dtv.UseVisualStyleBackColor = true;
            this.btn_dtv.Click += new System.EventHandler(this.btn_dtv_Click);
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(862, 535);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 23);
            this.btn_close.TabIndex = 52;
            this.btn_close.Text = "关闭";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // Form_TV_Communication_Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 600);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_dtv);
            this.Controls.Add(this.btn_GET_USR_B_GAN);
            this.Controls.Add(this.btn_GET_USR_G_GAN);
            this.Controls.Add(this.btn_GET_USR_R_GAN);
            this.Controls.Add(this.btn_100);
            this.Controls.Add(this.btn_20);
            this.Controls.Add(this.btn_80);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.btn_warm);
            this.Controls.Add(this.btn_stand);
            this.Controls.Add(this.btn_cool);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.tb_cmd);
            this.Controls.Add(this.tb_result);
            this.Controls.Add(this.btn_sendall);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btn_r_minus);
            this.Controls.Add(this.btn_r_add);
            this.Controls.Add(this.btn_port_close);
            this.Controls.Add(this.tb_t);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tb_y);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tb_x);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_sendb);
            this.Controls.Add(this.tb_b);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_sendg);
            this.Controls.Add(this.tb_g);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_sendr);
            this.Controls.Add(this.tb_r);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbb_tv);
            this.Controls.Add(this.tb_baut);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbmemo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Name = "Form_TV_Communication_Test";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TV通讯测试与手动发送RGB";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_TV_Communication_Test_FormClosing);
            this.Load += new System.EventHandler(this.Form_TV_Communication_Test_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbmemo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_baut;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbb_tv;
        private System.IO.Ports.SerialPort com_TV;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_r;
        private System.Windows.Forms.Button btn_sendr;
        private System.Windows.Forms.Button btn_sendg;
        private System.Windows.Forms.TextBox tb_g;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_sendb;
        private System.Windows.Forms.TextBox tb_b;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tb_t;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_y;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tb_x;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btn_port_close;
        private System.Windows.Forms.Button btn_r_add;
        private System.Windows.Forms.Button btn_r_minus;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button btn_sendall;
        private System.Windows.Forms.TextBox tb_result;
        private System.Windows.Forms.TextBox tb_cmd;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_cool;
        private System.Windows.Forms.Button btn_stand;
        private System.Windows.Forms.Button btn_warm;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button btn_20;
        private System.Windows.Forms.Button btn_80;
        private System.Windows.Forms.Button btn_100;
        private System.Windows.Forms.Button btn_GET_USR_B_GAN;
        private System.Windows.Forms.Button btn_GET_USR_G_GAN;
        private System.Windows.Forms.Button btn_GET_USR_R_GAN;
        private System.Windows.Forms.Button btn_dtv;
        private System.Windows.Forms.Button btn_close;
    }
}