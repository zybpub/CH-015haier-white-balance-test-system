namespace Test_Automation.Setup
{
    partial class Form_Setup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Setup));
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.btn_colortempset = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_tv_set = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(202, 101);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(163, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "系统设置";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(202, 218);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(163, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Mysql数据库设置";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(202, 268);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(163, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "PLC设置";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(195, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 40);
            this.label2.TabIndex = 91;
            this.label2.Text = "软件设置";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(202, 308);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(163, 23);
            this.button5.TabIndex = 92;
            this.button5.Text = "修改登录密码";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(473, 351);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 93;
            this.button6.Text = "关闭";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // btn_colortempset
            // 
            this.btn_colortempset.Location = new System.Drawing.Point(202, 169);
            this.btn_colortempset.Name = "btn_colortempset";
            this.btn_colortempset.Size = new System.Drawing.Size(163, 23);
            this.btn_colortempset.TabIndex = 94;
            this.btn_colortempset.Text = "色坐标设置";
            this.btn_colortempset.UseVisualStyleBackColor = true;
            this.btn_colortempset.Click += new System.EventHandler(this.btn_colortempset_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(202, 133);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(163, 23);
            this.button2.TabIndex = 95;
            this.button2.Text = "CA410设置";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // btn_tv_set
            // 
            this.btn_tv_set.Location = new System.Drawing.Point(420, 132);
            this.btn_tv_set.Name = "btn_tv_set";
            this.btn_tv_set.Size = new System.Drawing.Size(152, 23);
            this.btn_tv_set.TabIndex = 96;
            this.btn_tv_set.Text = "TV通讯设置";
            this.btn_tv_set.UseVisualStyleBackColor = true;
            this.btn_tv_set.Click += new System.EventHandler(this.btn_tv_set_Click);
            // 
            // Form_Setup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 402);
            this.Controls.Add(this.btn_tv_set);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_colortempset);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Setup";
            this.Text = "软件设置";
            this.Load += new System.EventHandler(this.Form_Setup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button btn_colortempset;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_tv_set;
    }
}