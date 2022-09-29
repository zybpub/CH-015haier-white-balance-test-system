namespace Test_Automation.Setup
{
    partial class Form_Setup_Mysql
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
            this.cb_mysql_used = new System.Windows.Forms.CheckBox();
            this.groupBox_mysql = new System.Windows.Forms.GroupBox();
            this.mysql_yielddata_table = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.mysql_database_name = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.mysql_testdata_table = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.Mysql_User = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.Mysql_Port = new System.Windows.Forms.TextBox();
            this.Mysql_Pass = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.Mysql_IP = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox_mysql.SuspendLayout();
            this.SuspendLayout();
            // 
            // cb_mysql_used
            // 
            this.cb_mysql_used.AutoSize = true;
            this.cb_mysql_used.Location = new System.Drawing.Point(161, 97);
            this.cb_mysql_used.Name = "cb_mysql_used";
            this.cb_mysql_used.Size = new System.Drawing.Size(84, 16);
            this.cb_mysql_used.TabIndex = 85;
            this.cb_mysql_used.Text = "使用数据库";
            this.cb_mysql_used.UseVisualStyleBackColor = true;
            this.cb_mysql_used.CheckedChanged += new System.EventHandler(this.cb_mysql_used_CheckedChanged);
            // 
            // groupBox_mysql
            // 
            this.groupBox_mysql.Controls.Add(this.button1);
            this.groupBox_mysql.Controls.Add(this.mysql_yielddata_table);
            this.groupBox_mysql.Controls.Add(this.label7);
            this.groupBox_mysql.Controls.Add(this.mysql_database_name);
            this.groupBox_mysql.Controls.Add(this.label19);
            this.groupBox_mysql.Controls.Add(this.mysql_testdata_table);
            this.groupBox_mysql.Controls.Add(this.label24);
            this.groupBox_mysql.Controls.Add(this.Mysql_User);
            this.groupBox_mysql.Controls.Add(this.label26);
            this.groupBox_mysql.Controls.Add(this.Mysql_Port);
            this.groupBox_mysql.Controls.Add(this.Mysql_Pass);
            this.groupBox_mysql.Controls.Add(this.label27);
            this.groupBox_mysql.Controls.Add(this.label28);
            this.groupBox_mysql.Controls.Add(this.Mysql_IP);
            this.groupBox_mysql.Controls.Add(this.label29);
            this.groupBox_mysql.Enabled = false;
            this.groupBox_mysql.Location = new System.Drawing.Point(161, 119);
            this.groupBox_mysql.Name = "groupBox_mysql";
            this.groupBox_mysql.Size = new System.Drawing.Size(322, 269);
            this.groupBox_mysql.TabIndex = 86;
            this.groupBox_mysql.TabStop = false;
            this.groupBox_mysql.Text = "Mysql数据库配置";
            // 
            // mysql_yielddata_table
            // 
            this.mysql_yielddata_table.Location = new System.Drawing.Point(147, 209);
            this.mysql_yielddata_table.Name = "mysql_yielddata_table";
            this.mysql_yielddata_table.Size = new System.Drawing.Size(143, 21);
            this.mysql_yielddata_table.TabIndex = 37;
            this.mysql_yielddata_table.Text = "hw_colorgamut_data";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 212);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 12);
            this.label7.TabIndex = 36;
            this.label7.Text = "生产统计表名：";
            // 
            // mysql_database_name
            // 
            this.mysql_database_name.Location = new System.Drawing.Point(147, 151);
            this.mysql_database_name.Name = "mysql_database_name";
            this.mysql_database_name.Size = new System.Drawing.Size(113, 21);
            this.mysql_database_name.TabIndex = 35;
            this.mysql_database_name.Text = "jczx_mysql_db";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(43, 154);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(65, 12);
            this.label19.TabIndex = 34;
            this.label19.Text = "数据库名：";
            // 
            // mysql_testdata_table
            // 
            this.mysql_testdata_table.Location = new System.Drawing.Point(147, 181);
            this.mysql_testdata_table.Name = "mysql_testdata_table";
            this.mysql_testdata_table.Size = new System.Drawing.Size(143, 21);
            this.mysql_testdata_table.TabIndex = 33;
            this.mysql_testdata_table.Text = "hw_colorgamut_data";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(19, 184);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(89, 12);
            this.label24.TabIndex = 32;
            this.label24.Text = "测试数据表名：";
            // 
            // Mysql_User
            // 
            this.Mysql_User.Location = new System.Drawing.Point(147, 87);
            this.Mysql_User.Name = "Mysql_User";
            this.Mysql_User.Size = new System.Drawing.Size(113, 21);
            this.Mysql_User.TabIndex = 30;
            this.Mysql_User.Text = "root";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(31, 90);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(77, 12);
            this.label26.TabIndex = 29;
            this.label26.Text = "Mysql_User：";
            // 
            // Mysql_Port
            // 
            this.Mysql_Port.Location = new System.Drawing.Point(147, 57);
            this.Mysql_Port.Name = "Mysql_Port";
            this.Mysql_Port.Size = new System.Drawing.Size(113, 21);
            this.Mysql_Port.TabIndex = 26;
            this.Mysql_Port.Text = "3306";
            // 
            // Mysql_Pass
            // 
            this.Mysql_Pass.Location = new System.Drawing.Point(147, 117);
            this.Mysql_Pass.Name = "Mysql_Pass";
            this.Mysql_Pass.PasswordChar = '*';
            this.Mysql_Pass.Size = new System.Drawing.Size(113, 21);
            this.Mysql_Pass.TabIndex = 28;
            this.Mysql_Pass.Text = "jczx";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(43, 60);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(65, 12);
            this.label27.TabIndex = 25;
            this.label27.Text = "Mysql_Port";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(31, 120);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(77, 12);
            this.label28.TabIndex = 27;
            this.label28.Text = "Mysql_Pass：";
            // 
            // Mysql_IP
            // 
            this.Mysql_IP.Location = new System.Drawing.Point(147, 27);
            this.Mysql_IP.Name = "Mysql_IP";
            this.Mysql_IP.Size = new System.Drawing.Size(113, 21);
            this.Mysql_IP.TabIndex = 24;
            this.Mysql_IP.Text = "localhost";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(43, 30);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(65, 12);
            this.label29.TabIndex = 23;
            this.label29.Text = "Mysql_IP：";
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(348, 456);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 87;
            this.btn_save.Text = "保存";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(429, 456);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 88;
            this.btn_cancel.Text = "关闭";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(166, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(317, 40);
            this.label1.TabIndex = 89;
            this.label1.Text = "Mysql数据库设置";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(199, 237);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 38;
            this.button1.Text = "备份数据";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form_Setup_Mysql
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 537);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.cb_mysql_used);
            this.Controls.Add(this.groupBox_mysql);
            this.Name = "Form_Setup_Mysql";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mysql数据库设置";
            this.Load += new System.EventHandler(this.Form_Setup_Mysql_Load);
            this.groupBox_mysql.ResumeLayout(false);
            this.groupBox_mysql.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cb_mysql_used;
        private System.Windows.Forms.GroupBox groupBox_mysql;
        private System.Windows.Forms.TextBox mysql_yielddata_table;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox mysql_database_name;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox mysql_testdata_table;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox Mysql_User;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox Mysql_Port;
        private System.Windows.Forms.TextBox Mysql_Pass;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox Mysql_IP;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}