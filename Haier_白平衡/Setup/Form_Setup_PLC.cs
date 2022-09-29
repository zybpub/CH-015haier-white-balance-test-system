using System;
using System.Windows.Forms;

namespace Test_Automation.Setup
{
    public partial class Form_Setup_PLC : Form
    {

        //https://www.cnblogs.com/dathlin/p/7703805.html

        public Form_Setup_PLC()
        {
            InitializeComponent();
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        }

        private void Form_Setup_PLC_Load(object sender, EventArgs e)
        {
            
            PLC_Used.Checked = (bool)config_json.PLC_Used;
            Adapter_on_check.Checked = (bool)config_json.Adapter_on_check;
            Adapter_off_check.Checked = (bool)config_json.Adapter_off_check;
            PLC_IP.Text = config_json.PLC_IP;
            PLC_Port.Text = config_json.PLC_Port;
            PLC_Station.Text = config_json.PLC_Station;
            PLC_LetTVPass_Register.Text = config_json.PLC_LetTVPass_Register;
            PLC_Light_Register.Text = config_json.PLC_Light_Register;
            PLC_Adapter_Register.Text = config_json.PLC_Adapter_Register;
            PLC_Light_GREEN.Text = config_json.PLC_Light_GREEN;
            PLC_Light_RED.Text = config_json.PLC_Light_RED;
            PLC_Light_YELLOW.Text = config_json.PLC_Light_YELLOW;
            PLC_Type_Register.Text = config_json.PLC_Type_Register;
            PLC_SN_Register.Text = config_json.PLC_SN_Register;
            PLC_StartTest_Register.Text = config_json.PLC_StartTest_Register;
            ShakeHand_OK_Code.Text = config_json.ShakeHand_OK_Code;
            groupBox_PLC.Enabled = PLC_Used.Checked;
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
            jsonObj["PLC_Used"] = PLC_Used.Checked.ToString();
            jsonObj["Adapter_on_check"] = Adapter_on_check.Checked.ToString();
            jsonObj["Adapter_off_check"] = Adapter_off_check.Checked.ToString();
            jsonObj["PLC_IP"] = PLC_IP.Text;
            jsonObj["PLC_IP"] = PLC_IP.Text;
            jsonObj["PLC_Port"] = PLC_Port.Text;
            jsonObj["PLC_Station"] = PLC_Station.Text;
            jsonObj["PLC_LetTVPass_Register"] = PLC_LetTVPass_Register.Text;
            jsonObj["PLC_Adapter_Register"] = PLC_Adapter_Register.Text;
            jsonObj["PLC_Light_Register"] = PLC_Light_Register.Text;
            jsonObj["PLC_Light_GREEN"] = PLC_Light_GREEN.Text;
            jsonObj["PLC_Light_RED"] = PLC_Light_RED.Text;
            jsonObj["PLC_Light_YELLOW"] = PLC_Light_YELLOW.Text;
            jsonObj["PLC_Type_Register"] = PLC_Type_Register.Text;
            jsonObj["PLC_SN_Register"] = PLC_SN_Register.Text;
            jsonObj["PLC_StartTest_Register"] = PLC_StartTest_Register.Text;
            jsonObj["ShakeHand_OK_Code"] = ShakeHand_OK_Code.Text;

            string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
            System.IO.File.WriteAllText(config_json.config_file_path, output);
            config_json.config_json_readall();
            MessageBox.Show("保存成功！");
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PLC_Used_CheckedChanged(object sender, EventArgs e)
        {
            groupBox_PLC.Enabled = PLC_Used.Checked;

        }
    }
}
