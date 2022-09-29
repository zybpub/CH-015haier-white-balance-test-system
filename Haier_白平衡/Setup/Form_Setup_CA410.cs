using System;
using System.Windows.Forms;

namespace Test_Automation.Setup
{
    public partial class Form_Setup_CA410 : Form
    {
        public Form_Setup_CA410()
        {
            InitializeComponent();
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        }

        private void Form_Setup_CA410_Load(object sender, EventArgs e)
        {

            CA410_SerialPort_Used.Checked = (bool)config_json.CA410_SerialPort_Used;
            foreach (string com in System.IO.Ports.SerialPort.GetPortNames()) //自动获取串行口名称
            {
                CA410_SerialPort_PortName.Items.Add(com);
            }
            CA410_SerialPort_PortName.Text = config_json.CA410_SerialPort_PortName; 

            CA410_SerialPort_PortName.Text = config_json.CA410_SerialPort_PortName;
            CA410_SerialPort_BaudRate.Text = config_json.CA410_SerialPort_BaudRate;
            CA410_SerialPort_DataBits.Text = config_json.CA410_SerialPort_DataBits;
            CA410_SerialPort_StopBits.Text = config_json.CA410_SerialPort_StopBits;
            CA410_SerialPort_Parity.Text = config_json.CA410_SerialPort_Parity;
            CA410_Machine_Keywords.Text = config_json.CA410_Machine_Keywords;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {

            if (!System.IO.File.Exists(config_json.config_file_path))
            {
                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo("c:\\软件配置");
                if (di.Exists == false) di.Create();

                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(config_json.config_file_path, true))
                {
                    writer.WriteLine("{}");
                    writer.Close();
                }
            }

            string json = System.IO.File.ReadAllText(config_json.config_file_path);
            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

            jsonObj["CA410_SerialPort_Used"] = CA410_SerialPort_Used.Checked.ToString();
            jsonObj["CA410_SerialPort_PortName"] = CA410_SerialPort_PortName.Text;

            jsonObj["CA410_TestChannel"] = CA410_TestChannel.Text;
            jsonObj["CA410_Machine_Keywords"] = CA410_Machine_Keywords.Text;


            string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
            System.IO.File.WriteAllText(config_json.config_file_path, output);
            config_json.config_json_readall();
            MessageBox.Show("保存成功！");
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_search_serial_no_Click(object sender, EventArgs e)
        {
            string comNum = Class_Serial.GetComNum(CA410_Machine_Keywords.Text);
          
            if (comNum == "") { lb_message.Text = "未找到符合要求的串口号！"; }
            else
            {
                lb_message.Text ="找到串口号:"+ comNum;
            }
            
        }

        private void CA410_SerialPort_Used_CheckedChanged(object sender, EventArgs e)
        {
            groupBox_ca410.Enabled = CA410_SerialPort_Used.Checked;
        }
    }
}
