namespace Test_Automation.Setup
{
    partial class Form_Setup_System
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.MES_Abnormal_Keywords = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_lettvpassafterfail_notsendng = new System.Windows.Forms.CheckBox();
            this.cb_autorun = new System.Windows.Forms.CheckBox();
            this.cb_retryafterfail = new System.Windows.Forms.CheckBox();
            this.cb_stopafterfail = new System.Windows.Forms.CheckBox();
            this.cb_sendtomes = new System.Windows.Forms.CheckBox();
            this.cb_prefailsnotomes = new System.Windows.Forms.CheckBox();
            this.label58 = new System.Windows.Forms.Label();
            this.MES_URL = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.test_max_seconds = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.pass = new System.Windows.Forms.TextBox();
            this.label59 = new System.Windows.Forms.Label();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Workstationid = new System.Windows.Forms.TextBox();
            this.label57 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.form_title = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.start_services = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.MES_Abnormal_Keywords);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cb_lettvpassafterfail_notsendng);
            this.groupBox2.Controls.Add(this.cb_autorun);
            this.groupBox2.Controls.Add(this.cb_retryafterfail);
            this.groupBox2.Controls.Add(this.cb_stopafterfail);
            this.groupBox2.Controls.Add(this.cb_sendtomes);
            this.groupBox2.Controls.Add(this.cb_prefailsnotomes);
            this.groupBox2.Controls.Add(this.label58);
            this.groupBox2.Controls.Add(this.MES_URL);
            this.groupBox2.Location = new System.Drawing.Point(65, 77);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(318, 393);
            this.groupBox2.TabIndex = 115;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "测试配置";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 359);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(287, 12);
            this.label4.TabIndex = 106;
            this.label4.Text = "当MES回复的内容中出现上述关键字后会再次重发MES.";
            // 
            // MES_Abnormal_Keywords
            // 
            this.MES_Abnormal_Keywords.Location = new System.Drawing.Point(24, 319);
            this.MES_Abnormal_Keywords.Name = "MES_Abnormal_Keywords";
            this.MES_Abnormal_Keywords.Size = new System.Drawing.Size(283, 21);
            this.MES_Abnormal_Keywords.TabIndex = 105;
            this.MES_Abnormal_Keywords.Text = "接口异常";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 291);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 12);
            this.label3.TabIndex = 104;
            this.label3.Text = "MES回复异常关键字：";
            // 
            // cb_lettvpassafterfail_notsendng
            // 
            this.cb_lettvpassafterfail_notsendng.AutoSize = true;
            this.cb_lettvpassafterfail_notsendng.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_lettvpassafterfail_notsendng.Location = new System.Drawing.Point(22, 170);
            this.cb_lettvpassafterfail_notsendng.Name = "cb_lettvpassafterfail_notsendng";
            this.cb_lettvpassafterfail_notsendng.Size = new System.Drawing.Size(108, 28);
            this.cb_lettvpassafterfail_notsendng.TabIndex = 103;
            this.cb_lettvpassafterfail_notsendng.Text = "重测失败后放行\r\n（不发NG）";
            this.cb_lettvpassafterfail_notsendng.UseVisualStyleBackColor = true;
            // 
            // cb_autorun
            // 
            this.cb_autorun.AutoSize = true;
            this.cb_autorun.Location = new System.Drawing.Point(22, 25);
            this.cb_autorun.Name = "cb_autorun";
            this.cb_autorun.Size = new System.Drawing.Size(156, 16);
            this.cb_autorun.TabIndex = 96;
            this.cb_autorun.Text = "启动程序后自动开始测试";
            this.cb_autorun.UseVisualStyleBackColor = true;
            // 
            // cb_retryafterfail
            // 
            this.cb_retryafterfail.AutoSize = true;
            this.cb_retryafterfail.Location = new System.Drawing.Point(21, 52);
            this.cb_retryafterfail.Name = "cb_retryafterfail";
            this.cb_retryafterfail.Size = new System.Drawing.Size(84, 16);
            this.cb_retryafterfail.TabIndex = 100;
            this.cb_retryafterfail.Text = "失败后重测";
            this.cb_retryafterfail.UseVisualStyleBackColor = true;
            // 
            // cb_stopafterfail
            // 
            this.cb_stopafterfail.AutoSize = true;
            this.cb_stopafterfail.Location = new System.Drawing.Point(22, 81);
            this.cb_stopafterfail.Name = "cb_stopafterfail";
            this.cb_stopafterfail.Size = new System.Drawing.Size(108, 16);
            this.cb_stopafterfail.TabIndex = 99;
            this.cb_stopafterfail.Text = "重测失败后停机";
            this.cb_stopafterfail.UseVisualStyleBackColor = true;
            // 
            // cb_sendtomes
            // 
            this.cb_sendtomes.AutoSize = true;
            this.cb_sendtomes.Location = new System.Drawing.Point(22, 112);
            this.cb_sendtomes.Name = "cb_sendtomes";
            this.cb_sendtomes.Size = new System.Drawing.Size(102, 16);
            this.cb_sendtomes.TabIndex = 101;
            this.cb_sendtomes.Text = "发送数据到MES";
            this.cb_sendtomes.UseVisualStyleBackColor = true;
            // 
            // cb_prefailsnotomes
            // 
            this.cb_prefailsnotomes.AutoSize = true;
            this.cb_prefailsnotomes.Location = new System.Drawing.Point(21, 134);
            this.cb_prefailsnotomes.Name = "cb_prefailsnotomes";
            this.cb_prefailsnotomes.Size = new System.Drawing.Size(120, 28);
            this.cb_prefailsnotomes.TabIndex = 102;
            this.cb_prefailsnotomes.Text = "不发送前两次失败\r\n数据到MES";
            this.cb_prefailsnotomes.UseVisualStyleBackColor = true;
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(19, 210);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(83, 12);
            this.label58.TabIndex = 97;
            this.label58.Text = "MES发送网址：";
            // 
            // MES_URL
            // 
            this.MES_URL.Location = new System.Drawing.Point(22, 233);
            this.MES_URL.Multiline = true;
            this.MES_URL.Name = "MES_URL";
            this.MES_URL.Size = new System.Drawing.Size(285, 40);
            this.MES_URL.TabIndex = 98;
            this.MES_URL.Text = "http://10.52.88.17:8080/N2/http/interface.ms?model=IntoScgz&method=intoScgzSaveIn" +
    "fo";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(659, 193);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(17, 12);
            this.label18.TabIndex = 2;
            this.label18.Text = "秒";
            // 
            // test_max_seconds
            // 
            this.test_max_seconds.Location = new System.Drawing.Point(602, 188);
            this.test_max_seconds.Name = "test_max_seconds";
            this.test_max_seconds.Size = new System.Drawing.Size(45, 21);
            this.test_max_seconds.TabIndex = 1;
            this.test_max_seconds.Text = "20";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(537, 191);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(53, 12);
            this.label17.TabIndex = 0;
            this.label17.Text = "超时设置";
            // 
            // pass
            // 
            this.pass.Location = new System.Drawing.Point(576, 347);
            this.pass.Name = "pass";
            this.pass.PasswordChar = '*';
            this.pass.Size = new System.Drawing.Size(100, 21);
            this.pass.TabIndex = 114;
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(492, 350);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(65, 12);
            this.label59.TabIndex = 113;
            this.label59.Text = "管理员密码";
            // 
            // btn_close
            // 
            this.btn_close.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_close.Location = new System.Drawing.Point(587, 436);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(104, 34);
            this.btn_close.TabIndex = 112;
            this.btn_close.Text = "关闭";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_save
            // 
            this.btn_save.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_save.Location = new System.Drawing.Point(466, 436);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(104, 34);
            this.btn_save.TabIndex = 111;
            this.btn_save.Text = "保存";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(254, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 40);
            this.label1.TabIndex = 122;
            this.label1.Text = "系统设置";
            // 
            // Workstationid
            // 
            this.Workstationid.Location = new System.Drawing.Point(567, 84);
            this.Workstationid.Name = "Workstationid";
            this.Workstationid.Size = new System.Drawing.Size(118, 21);
            this.Workstationid.TabIndex = 123;
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(453, 79);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(107, 24);
            this.label57.TabIndex = 124;
            this.label57.Text = "测试点名称\r\n(WORKSTATIONID)：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(442, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 127;
            this.label2.Text = "主窗体名称：";
            // 
            // form_title
            // 
            this.form_title.Location = new System.Drawing.Point(513, 129);
            this.form_title.Name = "form_title";
            this.form_title.Size = new System.Drawing.Size(178, 21);
            this.form_title.TabIndex = 128;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(432, 232);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(257, 12);
            this.label5.TabIndex = 129;
            this.label5.Text = "测试前检查和启动服务（多个服务已逗号分隔）";
            // 
            // start_services
            // 
            this.start_services.Location = new System.Drawing.Point(470, 254);
            this.start_services.Name = "start_services";
            this.start_services.Size = new System.Drawing.Size(221, 21);
            this.start_services.TabIndex = 130;
            // 
            // Form_Setup_System
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 491);
            this.Controls.Add(this.start_services);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.form_title);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.test_max_seconds);
            this.Controls.Add(this.Workstationid);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label57);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pass);
            this.Controls.Add(this.label59);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_save);
            this.Name = "Form_Setup_System";
            this.Text = "系统设置";
            this.Load += new System.EventHandler(this.Form_Setup_System_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cb_lettvpassafterfail_notsendng;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.CheckBox cb_autorun;
        private System.Windows.Forms.TextBox test_max_seconds;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.CheckBox cb_retryafterfail;
        private System.Windows.Forms.CheckBox cb_stopafterfail;
        private System.Windows.Forms.CheckBox cb_sendtomes;
        private System.Windows.Forms.CheckBox cb_prefailsnotomes;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.TextBox MES_URL;
        private System.Windows.Forms.TextBox pass;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Workstationid;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox form_title;
        private System.Windows.Forms.TextBox MES_Abnormal_Keywords;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox start_services;
    }
}