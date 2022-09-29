using System;
using System.Windows.Forms;

namespace Test_Automation.Setup
{
    public partial class Form_Setup_TV : Form
    {
        public Form_Setup_TV()
        {
            InitializeComponent();
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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

            jsonObj["TV_Connect_Used"] = TV_Connect_Used.Checked.ToString();
            jsonObj["TV_IP"] = TV_IP.Text;
            jsonObj["TV_Port"] = TV_Port.Text;
            jsonObj["TV_SerialPort_PortName"] = TV_SerialPort_PortName.Text;
            jsonObj["TV_SerialPort_BaudRate"] = TV_SerialPort_BaudRate.Text;
            jsonObj["TV_SerialPort_DataBits"] = TV_SerialPort_DataBits.Text;
            jsonObj["TV_SerialPort_StopBits"] = TV_SerialPort_StopBits.Text;
            jsonObj["TV_SerialPort_Parity"]   =   TV_SerialPort_Parity.Text;

            string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
            System.IO.File.WriteAllText(config_json.config_file_path, output);
            config_json.config_json_readall();
           // fmain1.window_init();
            MessageBox.Show("保存成功！");
        }

        private void Form_Setup_TV_Load(object sender, EventArgs e)
        {

            TV_Connect_Used.Checked = config_json.TV_Connect_Used;

            foreach (string com in System.IO.Ports.SerialPort.GetPortNames()) //自动获取串行口名称
            {
                TV_SerialPort_PortName.Items.Add(com);
            }
            TV_SerialPort_PortName.Text = config_json.TV_SerialPort_PortName;


            if (TV_Connect_Used.Checked) groupBox_tv_connect.Enabled = true;
            else groupBox_tv_connect.Enabled = false;

            TV_IP.Text = config_json.TV_IP;
            TV_Port.Text = config_json.TV_Port;

            TV_SerialPort_PortName.Text = config_json.TV_SerialPort_PortName;
            TV_SerialPort_BaudRate.Text = config_json.TV_SerialPort_BaudRate;
            TV_SerialPort_DataBits.Text = config_json.TV_SerialPort_DataBits;
            TV_SerialPort_StopBits.Text = config_json.TV_SerialPort_StopBits;
            TV_SerialPort_Parity.Text = config_json.TV_SerialPort_Parity;
        }

        private void btn_search_serial_no_Click(object sender, EventArgs e)
        {
            string comNum = Class_Serial.GetComNum(TV_Machine_Keywords.Text);

            if (comNum == "") { lb_message.Text = "未找到符合要求的串口号！"; }
            else
            {
                lb_message.Text = "找到串口号:" + comNum;
            }
        }

        private void radioButton_网口_CheckedChanged(object sender, EventArgs e)
        {
            groupBox_tv网口.Enabled = radioButton_网口.Checked;
        }

        private void radioButton_串口_CheckedChanged(object sender, EventArgs e)
        {
            groupBox_tv串口.Enabled = radioButton_串口.Checked;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TV_Connect_Used_CheckedChanged(object sender, EventArgs e)
        {
            groupBox_tv_connect.Enabled = TV_Connect_Used.Checked;
        }
    }
}
