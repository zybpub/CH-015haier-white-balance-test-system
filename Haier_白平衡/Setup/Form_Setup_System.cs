using System;
using System.Windows.Forms;

namespace Test_Automation.Setup
{
    public partial class Form_Setup_System : Form
    {
        public Form_Setup_System()
        {
            InitializeComponent();
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        }

        private void Form_Setup_System_Load(object sender, EventArgs e)
        {
            Workstationid.Text = config_json.Workstationid;
            form_title.Text = config_json.form_title;

            test_max_seconds.Text = config_json.test_max_seconds;
            cb_autorun.Checked = Convert.ToBoolean(config_json.auto_run);
            cb_retryafterfail.Checked = Convert.ToBoolean(config_json.retryafterfail);
            cb_stopafterfail.Checked = Convert.ToBoolean(config_json.stopafterfail);
            cb_sendtomes.Checked = Convert.ToBoolean(config_json.sendtomes);
            cb_prefailsnotomes.Checked = Convert.ToBoolean(config_json.prefailsnotomes);
            cb_lettvpassafterfail_notsendng.Checked = Convert.ToBoolean(config_json.lettvpassafterfail_notsendng);

            MES_URL.Text = config_json.MES_URL;
            MES_Abnormal_Keywords.Text = config_json.MES_Abnormal_Keywords;
            pass.Text = Encrypt.DES.DesDecrypt(config_json.pass);
            start_services.Text = config_json.start_services;

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


            jsonObj["auto_run"] = cb_autorun.Checked.ToString();
            jsonObj["retryafterfail"] = cb_retryafterfail.Checked.ToString();
            jsonObj["stopafterfail"] = cb_stopafterfail.Checked.ToString();
            jsonObj["sendtomes"] = cb_sendtomes.Checked.ToString();
            jsonObj["prefailsnotomes"] = cb_prefailsnotomes.Checked.ToString();
            jsonObj["lettvpassafterfail_notsendng"] = cb_lettvpassafterfail_notsendng.Checked.ToString();

            jsonObj["pass"] = Encrypt.DES.DesEncrypt(pass.Text);
            jsonObj["test_max_seconds"] = test_max_seconds.Text;
            jsonObj["MES_URL"] = MES_URL.Text;
            jsonObj["MES_Abnormal_Keywords"] = MES_Abnormal_Keywords.Text;

            jsonObj["Workstationid"] = Workstationid.Text;

            jsonObj["form_title"] = form_title.Text;
            jsonObj["start_services"] = start_services.Text;
            

            string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
            System.IO.File.WriteAllText(config_json.config_file_path, output);
            config_json.config_json_readall();
            MessageBox.Show("保存成功！");
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
