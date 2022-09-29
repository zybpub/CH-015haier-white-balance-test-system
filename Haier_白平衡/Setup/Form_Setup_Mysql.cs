using System;
using System.Windows.Forms;

namespace Test_Automation.Setup
{
    public partial class Form_Setup_Mysql : Form
    {
        public Form_Setup_Mysql()
        {
            InitializeComponent();
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        }

        private void Form_Setup_Mysql_Load(object sender, EventArgs e)
        {

            cb_mysql_used.Checked = (bool)config_json.mysql_used;
            Mysql_IP.Text = config_json.Mysql_IP;
            Mysql_Port.Text = config_json.Mysql_Port;
            Mysql_User.Text = config_json.Mysql_User;
            Mysql_Pass.Text = config_json.Mysql_Pass;
            mysql_database_name.Text = config_json.mysql_database_name;
            mysql_testdata_table.Text = config_json.mysql_testdata_table;
            // mysql_yielddata_table.Text = config_json.mysql_yielddata_table;
            mysql_yielddata_table.Text = config_json.mysql_tongji_table;
            if (cb_mysql_used.Checked) {
                groupBox_mysql.Enabled = true;
            }
            else
                groupBox_mysql.Enabled = false;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists(config_json.config_file_path))
            {
                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo("d:\\软件配置");
                if (di.Exists == false) di.Create();

                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(config_json.config_file_path, true))
                {
                    writer.WriteLine("{}");
                    writer.Close();
                }
            }
            string json = System.IO.File.ReadAllText(config_json.config_file_path);
            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            jsonObj["mysql_used"] = cb_mysql_used.Checked.ToString();
            jsonObj["Mysql_IP"] = Mysql_IP.Text;
            jsonObj["Mysql_Port"] = Mysql_Port.Text;
            jsonObj["Mysql_User"] = Mysql_User.Text;
            jsonObj["Mysql_Pass"] = Mysql_Pass.Text;
            jsonObj["mysql_database_name"] = mysql_database_name.Text;
            jsonObj["mysql_testdata_table"] = mysql_testdata_table.Text;
            //jsonObj["mysql_yielddata_table"] = mysql_yielddata_table.Text;
            jsonObj["mysql_tongji_table"] = mysql_yielddata_table.Text;
            
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
            System.IO.File.WriteAllText(config_json.config_file_path, output);
            config_json.config_json_readall();
            MessageBox.Show("保存成功！");
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cb_mysql_used_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_mysql_used.Checked)
            {
                groupBox_mysql.Enabled = true;
            }
            else
                groupBox_mysql.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mysql_Class mc = new Mysql_Class();
            mc.Backup();
        }
    }
}
