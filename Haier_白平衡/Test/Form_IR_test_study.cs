using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace Test_Automation
{
    public partial class Form_IR_test_and_study : Form
    {
        public Form_IR_test_and_study()
        {
            InitializeComponent();
        }
        //控制红外遥控发送键码： F15、工厂模式M
        byte[] IR_SendStr_F15 = new byte[] { 0x50, 0xfa, 0x50, 0x01, 0x00, 0x51 };  //1遥控器F15，打开白平衡调试开关
        byte[] IR_SendStr_Factory = new byte[] { 0x50, 0xfa, 0x50, 0x02, 0x00, 0x52 }; //2打开工厂模式
        byte[] IR_SendStr_HDMI = new byte[] { 0x50, 0xfa, 0x50, 0x03, 0x00, 0x53 };  //3
        byte[] IR_SendStr_F10 = new byte[] { 0x50, 0xfa, 0x50, 0x04, 0x00, 0x54 };   //4
        byte[] IR_SendStr_F3 = new byte[] { 0x50, 0xfa, 0x50, 0x05, 0x00, 0x55 };    //5
        byte[] IR_SendStr_OK = new byte[] { 0x50, 0xfa, 0x50, 0x06, 0x00, 0x56};    //6

        public bool Com_IR_inited { get; private set; }
        public SerialPort com_IR { get; private set; }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }
        private void IR_Send(byte[] sendstr)
        {
            ir_init();
            com_IR.DiscardInBuffer();
            com_IR.DiscardOutBuffer();
            com_IR.Write(sendstr, 0, sendstr.Length);  //发送F15
            tbmemo.AppendText("红外发送:"+ byteToHexStr(sendstr)+"\r\n");
            tbmemo.ScrollToCaret();
        }

        #region 打开红外遥控器通讯串口:bool ir_init()
        /// <summary>
        /// 打开红外遥控器通讯串口
        /// </summary>
        /// <returns></returns>
        private bool ir_init()
        {
            if (Com_IR_inited == false)
                try
                {
                    com_IR = new System.IO.Ports.SerialPort();
                    com_IR.PortName = cbb_IR.Text;
                    com_IR.BaudRate = Convert.ToInt32(config_json.IR_BaudRate);
                    com_IR.DataBits = Convert.ToInt16(config_json.IR_DataBits);
                    com_IR.StopBits = System.IO.Ports.StopBits.One;
                    com_IR.Parity = System.IO.Ports.Parity.None;
                    com_IR.DataReceived += com_IR_DataReceived;

                    if (com_IR.IsOpen == false)
                    {
                        com_IR.Open();
                        Com_IR_inited = true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;
                }
            return true;
        }

        private void com_IR_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //休眠100ms等待接收完数据
            System.Threading.Thread.Sleep(100);

            this.Invoke((EventHandler)delegate
            {
                Byte[] receivedData = new Byte[com_IR.BytesToRead]; //创建接收字节数组 
                com_IR.Read(receivedData, 0, receivedData.Length);  //读取数据 

                string showstr;
                showstr = byteToHexStr(receivedData);

                tbmemo.AppendText(">> IR Rec:" + showstr + Environment.NewLine);
                tbmemo.ScrollToCaret();
                //IR Rec:50FC03000003
               // if (showstr == "50FC03000003")
               // {
                   // tbmemo.AppendText("红外指令F15发送成功！");
                  //  tbmemo.ScrollToCaret();
                //}
            });
        }
        #endregion

        #region 字节数组转16进制字符串:string byteToHexStr(byte[] bytes)
        /// <summary> 
        /// 字节数组转16进制字符串 
        /// </summary> 
        /// <param name="bytes"></param> 
        /// <returns></returns> 
        public static string byteToHexStr(byte[] bytes)
        {
            string returnStr = "";
            if (bytes != null)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    returnStr += bytes[i].ToString("X2");
                }
            }
            return returnStr;
        }
        #endregion

        private void Form_IR_test_Load(object sender, EventArgs e)
        {
            btn_port_open.Enabled = true;
            btn_port_close.Enabled = false;
            foreach (string com in System.IO.Ports.SerialPort.GetPortNames()) //自动获取串行口名称
            {
                cbb_IR.Items.Add(com);
            }
            try { cbb_IR.Text = config_json.IR_PortName; } catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IR_Send(IR_SendStr_F15);  //打开白平衡调试开关
        }

        private void btn_hdmi_Click(object sender, EventArgs e)
        {
            IR_Send(IR_SendStr_HDMI);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                IR_Send(IR_SendStr_Factory);  //进入工厂模式
                System.Threading.Thread.Sleep(500);
                IR_Send(IR_SendStr_HDMI);  //打开白平衡调试开关

                System.Threading.Thread.Sleep(500);
                IR_Send(IR_SendStr_F3);  //打开白平衡调试开关
                System.Threading.Thread.Sleep(500);
                IR_Send(IR_SendStr_OK);  //打开白平衡调试开关

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            IR_Send(IR_SendStr_F3);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_send1_Click(object sender, EventArgs e)
        {
            IR_Send(IR_SendStr_F15);  //打开白平衡调试开关
        }

        private void btn_send2_Click(object sender, EventArgs e)
        {
            IR_Send(IR_SendStr_Factory);  //进入工厂模式
        }

        private void btn_send3_Click(object sender, EventArgs e)
        {

            IR_Send(IR_SendStr_HDMI);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            IR_Send(IR_SendStr_F10);
            
        }

        private void btn_send4_Click(object sender, EventArgs e)
        {

            IR_Send(IR_SendStr_HDMI);
        }

        private void btn_send5_Click(object sender, EventArgs e)
        {
            IR_Send(IR_SendStr_F3);
        }

        private void btn_send6_Click(object sender, EventArgs e)
        {
            IR_Send(IR_SendStr_OK); 
        }

        private void btn_learn1_Click(object sender, EventArgs e)
        {
            IR_Send(new byte[] { 0x50, 0xfa, 0x05, 0x01, 0x00, 0x04 });// 50 fa 05 01 00 04

            //reply: 50 fc 01 00 00 01(学习成功)     50 fc 05 00 00 05(学习超时)     50 fc 02 00 00 02(学习失败)
        }

        private void btn_learn2_Click(object sender, EventArgs e)
        {
            IR_Send(new byte[] { 0x50, 0xfa, 0x05, 0x02, 0x00, 0x05 ^ 0x02 });
        }

        private void btn_learn3_Click(object sender, EventArgs e)
        {
            IR_Send(new byte[] { 0x50, 0xfa, 0x05, 0x03, 0x00, 0x05 ^ 0x03 });
        }

        private void btn_learn4_Click(object sender, EventArgs e)
        {
            IR_Send(new byte[] { 0x50, 0xfa, 0x05, 0x04, 0x00, 0x05 ^ 0x04 });
        }

        private void btn_learn5_Click(object sender, EventArgs e)
        {
            IR_Send(new byte[] { 0x50, 0xfa, 0x05, 0x05, 0x00, 0x05 ^ 0x05 });
        }

        private void btn_learn6_Click(object sender, EventArgs e)
        {
            IR_Send(new byte[] { 0x50, 0xfa, 0x05, 0x06, 0x00, 0x05 ^ 0x06 });
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_port_close_Click(object sender, EventArgs e)
        {
            if (com_IR.IsOpen) com_IR.Close();
            btn_port_open.Enabled = true ;
            btn_port_close.Enabled = false;
            Com_IR_inited = false;
        }

        private void btn_port_open_Click(object sender, EventArgs e)
        {
            ir_init();
            btn_port_open.Enabled = false;
            btn_port_close.Enabled = true;
        }

        private void Form_IR_test_and_study_FormClosing(object sender, FormClosingEventArgs e)
        {
          if (  Com_IR_inited == true)
            if (com_IR.IsOpen) com_IR.Close();
        }
    }
}
