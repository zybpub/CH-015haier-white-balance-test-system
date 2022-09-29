namespace Test_Automation.Setup
{
    partial class Form_Setup_PLC
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
            this.PLC_Used = new System.Windows.Forms.CheckBox();
            this.groupBox_PLC = new System.Windows.Forms.GroupBox();
            this.Adapter_off_check = new System.Windows.Forms.CheckBox();
            this.Adapter_on_check = new System.Windows.Forms.CheckBox();
            this.label71 = new System.Windows.Forms.Label();
            this.PLC_Type_Register = new System.Windows.Forms.TextBox();
            this.label72 = new System.Windows.Forms.Label();
            this.PLC_Station = new System.Windows.Forms.TextBox();
            this.label70 = new System.Windows.Forms.Label();
            this.PLC_Port = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.ShakeHand_OK_Code = new System.Windows.Forms.TextBox();
            this.PLC_Light_YELLOW = new System.Windows.Forms.TextBox();
            this.label73 = new System.Windows.Forms.Label();
            this.label69 = new System.Windows.Forms.Label();
            this.PLC_Light_RED = new System.Windows.Forms.TextBox();
            this.label68 = new System.Windows.Forms.Label();
            this.PLC_Light_GREEN = new System.Windows.Forms.TextBox();
            this.label67 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.PLC_SN_Register = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.PLC_StartTest_Register = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.PLC_Adapter_Register = new System.Windows.Forms.TextBox();
            this.PLC_LetTVPass_Register = new System.Windows.Forms.TextBox();
            this.label53 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.PLC_Light_Register = new System.Windows.Forms.TextBox();
            this.label55 = new System.Windows.Forms.Label();
            this.PLC_IP = new System.Windows.Forms.TextBox();
            this.label56 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.groupBox_PLC.SuspendLayout();
            this.SuspendLayout();
            // 
            // PLC_Used
            // 
            this.PLC_Used.AutoSize = true;
            this.PLC_Used.Location = new System.Drawing.Point(77, 91);
            this.PLC_Used.Name = "PLC_Used";
            this.PLC_Used.Size = new System.Drawing.Size(66, 16);
            this.PLC_Used.TabIndex = 83;
            this.PLC_Used.Text = "使用PLC";
            this.PLC_Used.UseVisualStyleBackColor = true;
            this.PLC_Used.CheckedChanged += new System.EventHandler(this.PLC_Used_CheckedChanged);
            // 
            // groupBox_PLC
            // 
            this.groupBox_PLC.Controls.Add(this.Adapter_off_check);
            this.groupBox_PLC.Controls.Add(this.Adapter_on_check);
            this.groupBox_PLC.Controls.Add(this.label71);
            this.groupBox_PLC.Controls.Add(this.PLC_Type_Register);
            this.groupBox_PLC.Controls.Add(this.label72);
            this.groupBox_PLC.Controls.Add(this.PLC_Station);
            this.groupBox_PLC.Controls.Add(this.label70);
            this.groupBox_PLC.Controls.Add(this.PLC_Port);
            this.groupBox_PLC.Controls.Add(this.label40);
            this.groupBox_PLC.Controls.Add(this.ShakeHand_OK_Code);
            this.groupBox_PLC.Controls.Add(this.PLC_Light_YELLOW);
            this.groupBox_PLC.Controls.Add(this.label73);
            this.groupBox_PLC.Controls.Add(this.label69);
            this.groupBox_PLC.Controls.Add(this.PLC_Light_RED);
            this.groupBox_PLC.Controls.Add(this.label68);
            this.groupBox_PLC.Controls.Add(this.PLC_Light_GREEN);
            this.groupBox_PLC.Controls.Add(this.label67);
            this.groupBox_PLC.Controls.Add(this.label31);
            this.groupBox_PLC.Controls.Add(this.label32);
            this.groupBox_PLC.Controls.Add(this.label38);
            this.groupBox_PLC.Controls.Add(this.label39);
            this.groupBox_PLC.Controls.Add(this.PLC_SN_Register);
            this.groupBox_PLC.Controls.Add(this.label41);
            this.groupBox_PLC.Controls.Add(this.PLC_StartTest_Register);
            this.groupBox_PLC.Controls.Add(this.label42);
            this.groupBox_PLC.Controls.Add(this.PLC_Adapter_Register);
            this.groupBox_PLC.Controls.Add(this.PLC_LetTVPass_Register);
            this.groupBox_PLC.Controls.Add(this.label53);
            this.groupBox_PLC.Controls.Add(this.label54);
            this.groupBox_PLC.Controls.Add(this.PLC_Light_Register);
            this.groupBox_PLC.Controls.Add(this.label55);
            this.groupBox_PLC.Controls.Add(this.PLC_IP);
            this.groupBox_PLC.Controls.Add(this.label56);
            this.groupBox_PLC.Enabled = false;
            this.groupBox_PLC.Location = new System.Drawing.Point(69, 111);
            this.groupBox_PLC.Name = "groupBox_PLC";
            this.groupBox_PLC.Size = new System.Drawing.Size(345, 333);
            this.groupBox_PLC.TabIndex = 84;
            this.groupBox_PLC.TabStop = false;
            this.groupBox_PLC.Text = "PLC配置";
            // 
            // Adapter_off_check
            // 
            this.Adapter_off_check.AutoSize = true;
            this.Adapter_off_check.Location = new System.Drawing.Point(112, 298);
            this.Adapter_off_check.Name = "Adapter_off_check";
            this.Adapter_off_check.Size = new System.Drawing.Size(144, 16);
            this.Adapter_off_check.TabIndex = 38;
            this.Adapter_off_check.Text = "启用夹具收回到位检测";
            this.Adapter_off_check.UseVisualStyleBackColor = true;
            // 
            // Adapter_on_check
            // 
            this.Adapter_on_check.AutoSize = true;
            this.Adapter_on_check.Location = new System.Drawing.Point(111, 266);
            this.Adapter_on_check.Name = "Adapter_on_check";
            this.Adapter_on_check.Size = new System.Drawing.Size(144, 16);
            this.Adapter_on_check.TabIndex = 37;
            this.Adapter_on_check.Text = "启用夹具合上到位检测";
            this.Adapter_on_check.UseVisualStyleBackColor = true;
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.Location = new System.Drawing.Point(168, 208);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(89, 12);
            this.label71.TabIndex = 36;
            this.label71.Text = "读取向后的20位";
            // 
            // PLC_Type_Register
            // 
            this.PLC_Type_Register.Location = new System.Drawing.Point(116, 203);
            this.PLC_Type_Register.Name = "PLC_Type_Register";
            this.PLC_Type_Register.Size = new System.Drawing.Size(41, 21);
            this.PLC_Type_Register.TabIndex = 35;
            this.PLC_Type_Register.Text = "0";
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Location = new System.Drawing.Point(9, 206);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(89, 12);
            this.label72.TabIndex = 34;
            this.label72.Text = "型号起始地址：";
            // 
            // PLC_Station
            // 
            this.PLC_Station.Location = new System.Drawing.Point(206, 52);
            this.PLC_Station.Name = "PLC_Station";
            this.PLC_Station.Size = new System.Drawing.Size(25, 21);
            this.PLC_Station.TabIndex = 33;
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.Location = new System.Drawing.Point(155, 55);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(53, 12);
            this.label70.TabIndex = 32;
            this.label70.Text = "Station:";
            // 
            // PLC_Port
            // 
            this.PLC_Port.Location = new System.Drawing.Point(111, 52);
            this.PLC_Port.Name = "PLC_Port";
            this.PLC_Port.Size = new System.Drawing.Size(41, 21);
            this.PLC_Port.TabIndex = 31;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(63, 55);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(35, 12);
            this.label40.TabIndex = 30;
            this.label40.Text = "Port:";
            // 
            // ShakeHand_OK_Code
            // 
            this.ShakeHand_OK_Code.Location = new System.Drawing.Point(243, 142);
            this.ShakeHand_OK_Code.Name = "ShakeHand_OK_Code";
            this.ShakeHand_OK_Code.Size = new System.Drawing.Size(23, 21);
            this.ShakeHand_OK_Code.TabIndex = 29;
            this.ShakeHand_OK_Code.Text = "0";
            // 
            // PLC_Light_YELLOW
            // 
            this.PLC_Light_YELLOW.Location = new System.Drawing.Point(305, 82);
            this.PLC_Light_YELLOW.Name = "PLC_Light_YELLOW";
            this.PLC_Light_YELLOW.Size = new System.Drawing.Size(23, 21);
            this.PLC_Light_YELLOW.TabIndex = 29;
            this.PLC_Light_YELLOW.Text = "1";
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.Location = new System.Drawing.Point(213, 147);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(29, 12);
            this.label73.TabIndex = 28;
            this.label73.Text = "开始";
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.Location = new System.Drawing.Point(283, 85);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(23, 12);
            this.label69.TabIndex = 28;
            this.label69.Text = "黄 ";
            // 
            // PLC_Light_RED
            // 
            this.PLC_Light_RED.Location = new System.Drawing.Point(244, 82);
            this.PLC_Light_RED.Name = "PLC_Light_RED";
            this.PLC_Light_RED.Size = new System.Drawing.Size(23, 21);
            this.PLC_Light_RED.TabIndex = 27;
            this.PLC_Light_RED.Text = "1";
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.Location = new System.Drawing.Point(222, 85);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(17, 12);
            this.label68.TabIndex = 26;
            this.label68.Text = "红";
            // 
            // PLC_Light_GREEN
            // 
            this.PLC_Light_GREEN.Location = new System.Drawing.Point(190, 82);
            this.PLC_Light_GREEN.Name = "PLC_Light_GREEN";
            this.PLC_Light_GREEN.Size = new System.Drawing.Size(23, 21);
            this.PLC_Light_GREEN.TabIndex = 25;
            this.PLC_Light_GREEN.Text = "1";
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.Location = new System.Drawing.Point(168, 85);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(23, 12);
            this.label67.TabIndex = 24;
            this.label67.Text = "绿 ";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(168, 234);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(89, 12);
            this.label31.TabIndex = 23;
            this.label31.Text = "读取向后的50位";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(166, 147);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(41, 12);
            this.label32.TabIndex = 22;
            this.label32.Text = "0等待 ";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(166, 177);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(35, 12);
            this.label38.TabIndex = 21;
            this.label38.Text = "1放行";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(166, 117);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(71, 12);
            this.label39.TabIndex = 20;
            this.label39.Text = "4连接 5松开";
            // 
            // PLC_SN_Register
            // 
            this.PLC_SN_Register.Location = new System.Drawing.Point(116, 229);
            this.PLC_SN_Register.Name = "PLC_SN_Register";
            this.PLC_SN_Register.Size = new System.Drawing.Size(41, 21);
            this.PLC_SN_Register.TabIndex = 18;
            this.PLC_SN_Register.Text = "0";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(-3, 232);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(101, 12);
            this.label41.TabIndex = 17;
            this.label41.Text = "序列号起始地址：";
            // 
            // PLC_StartTest_Register
            // 
            this.PLC_StartTest_Register.Location = new System.Drawing.Point(114, 142);
            this.PLC_StartTest_Register.Name = "PLC_StartTest_Register";
            this.PLC_StartTest_Register.Size = new System.Drawing.Size(41, 21);
            this.PLC_StartTest_Register.TabIndex = 16;
            this.PLC_StartTest_Register.Text = "0";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(9, 145);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(89, 12);
            this.label42.TabIndex = 15;
            this.label42.Text = "开始测试地址：";
            // 
            // PLC_Adapter_Register
            // 
            this.PLC_Adapter_Register.Location = new System.Drawing.Point(114, 112);
            this.PLC_Adapter_Register.Name = "PLC_Adapter_Register";
            this.PLC_Adapter_Register.Size = new System.Drawing.Size(41, 21);
            this.PLC_Adapter_Register.TabIndex = 12;
            this.PLC_Adapter_Register.Text = "0";
            // 
            // PLC_LetTVPass_Register
            // 
            this.PLC_LetTVPass_Register.Location = new System.Drawing.Point(114, 172);
            this.PLC_LetTVPass_Register.Name = "PLC_LetTVPass_Register";
            this.PLC_LetTVPass_Register.Size = new System.Drawing.Size(41, 21);
            this.PLC_LetTVPass_Register.TabIndex = 14;
            this.PLC_LetTVPass_Register.Text = "0";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(21, 115);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(77, 12);
            this.label53.TabIndex = 11;
            this.label53.Text = "对接器地址：";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(9, 175);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(89, 12);
            this.label54.TabIndex = 13;
            this.label54.Text = "产品放行地址：";
            // 
            // PLC_Light_Register
            // 
            this.PLC_Light_Register.Location = new System.Drawing.Point(114, 82);
            this.PLC_Light_Register.Name = "PLC_Light_Register";
            this.PLC_Light_Register.Size = new System.Drawing.Size(41, 21);
            this.PLC_Light_Register.TabIndex = 10;
            this.PLC_Light_Register.Text = "0";
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(21, 85);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(77, 12);
            this.label55.TabIndex = 9;
            this.label55.Text = "指示灯地址：";
            // 
            // PLC_IP
            // 
            this.PLC_IP.Location = new System.Drawing.Point(111, 27);
            this.PLC_IP.Name = "PLC_IP";
            this.PLC_IP.Size = new System.Drawing.Size(96, 21);
            this.PLC_IP.TabIndex = 8;
            this.PLC_IP.Text = "0";
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(21, 28);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(77, 12);
            this.label56.TabIndex = 7;
            this.label56.Text = "远程PLC IP：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(154, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 40);
            this.label1.TabIndex = 90;
            this.label1.Text = "PLC设置";
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(388, 450);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 92;
            this.btn_cancel.Text = "关闭";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(307, 450);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 91;
            this.btn_save.Text = "保存";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // Form_Setup_PLC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 499);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PLC_Used);
            this.Controls.Add(this.groupBox_PLC);
            this.Name = "Form_Setup_PLC";
            this.Text = "PLC设置";
            this.Load += new System.EventHandler(this.Form_Setup_PLC_Load);
            this.groupBox_PLC.ResumeLayout(false);
            this.groupBox_PLC.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox PLC_Used;
        private System.Windows.Forms.GroupBox groupBox_PLC;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.TextBox PLC_Type_Register;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.TextBox PLC_Station;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.TextBox PLC_Port;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.TextBox ShakeHand_OK_Code;
        private System.Windows.Forms.TextBox PLC_Light_YELLOW;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.TextBox PLC_Light_RED;
        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.TextBox PLC_Light_GREEN;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.TextBox PLC_SN_Register;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.TextBox PLC_StartTest_Register;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.TextBox PLC_Adapter_Register;
        private System.Windows.Forms.TextBox PLC_LetTVPass_Register;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.TextBox PLC_Light_Register;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.TextBox PLC_IP;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.CheckBox Adapter_off_check;
        private System.Windows.Forms.CheckBox Adapter_on_check;
    }
}