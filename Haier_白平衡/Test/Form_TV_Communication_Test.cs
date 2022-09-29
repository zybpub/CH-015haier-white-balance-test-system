using System;
using System.Windows.Forms;

namespace Test_Automation
{
    public partial class Form_TV_Communication_Test : Form
    {
        public byte[] WholeOutstr { get; private set; }
        public string WholeSendStr { get; private set; }
        public string TVRecData { get; private set; }

        private System.IO.Ports.SerialPort com_CA410;

        private byte[] cmd;

        public Form_TV_Communication_Test()
        {
            InitializeComponent();
        }
        bool ca410_inited = false;
        /// <summary>
        /// 获取当前x,y值
        /// </summary>
        /// <returns></returns>
        private bool Testxyt()
        {
            if (ca410_inited == false)
            {
                ca410_inited= ca410_init();
            }

            if (ca410_inited)
            {
                com_CA410.DiscardInBuffer();
                com_CA410.DiscardOutBuffer();
                com_CA410.WriteLine("MES,1");
            }
            return true;
        }
        /// <summary>
        /// 连接CA410并进行校零
        /// </summary>
        private bool ca410_init()
        {
            if (ca410_inited == false)
            {
                try
                {
                    com_CA410 = new System.IO.Ports.SerialPort();
                    com_CA410.PortName = config_json.CA410_SerialPort_PortName;
                    com_CA410.BaudRate = Convert.ToInt32(config_json.CA410_SerialPort_BaudRate);
                    com_CA410.DataBits = Convert.ToInt16(config_json.CA410_SerialPort_DataBits);
                    com_CA410.Parity = System.IO.Ports.Parity.Even;
                    com_CA410.StopBits = System.IO.Ports.StopBits.Two;

                    if (com_CA410.IsOpen == false) com_CA410.Open();
                }
                catch
                {
                    addmemo("ca410端口" + config_json.CA410_SerialPort_PortName +"打开失败！");
                    return false;
                }

                com_CA410.WriteLine("COM,1");       //发起连接
                System.Threading.Thread.Sleep(100);
                com_CA410.DiscardOutBuffer();
                com_CA410.WriteLine("MDS,0");  //选择x,y,Lv模式，设置成功返回：OK00
                System.Threading.Thread.Sleep(100);
                com_CA410.DiscardOutBuffer();
                com_CA410.WriteLine("MCH," +config_json.CA410_TestChannel);  //选择通道CH1，设置成功返回：OK00
                System.Threading.Thread.Sleep(100);
                com_CA410.DiscardOutBuffer();
                com_CA410.WriteLine("ZRC");    //校零，约3秒，完成时返回：OK00
                System.Threading.Thread.Sleep(3000);
                com_CA410.DiscardOutBuffer();
                com_CA410.DiscardInBuffer();
                com_CA410.DiscardOutBuffer();
                com_CA410.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(com_CA410_DataReceived);
                ca410_inited = true;
                return true;
            }
            return true;
        }
        bool com_CA410_BeginDataRec = false;
        /// <summary>
        /// CA410 串口接收处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void com_CA410_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            ///*
            if (com_CA410_BeginDataRec == false)
            {
                com_CA410.DiscardOutBuffer();
                return;
            }
            try
            {
                int n = com_CA410.BytesToRead;
                byte[] buf = new byte[n];
                com_CA410.Read(buf, 0, n);


                //触发外部处理接收消息事件
              string  checkCA410_result = System.Text.Encoding.Default.GetString(buf);

                Invoke(new EventHandler(delegate
                {
                    //WholeSendStr = "ca410 received:" + checkCA410_result;
                    //addmemo(WholeSendStr);

                    //OK00,P1,0,-0.063188,0.4563044,6.6227164,-0.23,-99999999
                    //56个字符，结尾有一个0x0D换行符
                    string[] CA410RecData = checkCA410_result.Split(',');
                    if (CA410RecData.Length == 8)
                    {
                        
                        tb_x.Text = CA410RecData[3];
                        tb_y.Text = CA410RecData[4];
                        tb_t.Text= CA410RecData[5];
                        tb_result.Text += "获取色坐标及亮度xyt:" + tb_x.Text + "," + tb_y.Text + "," + tb_t.Text+"\r\n";
                    }

                }));
            }
            catch { }
        }
        private void Form_TV_Communication_Test_Load(object sender, EventArgs e)
        {
            config_json.config_json_readall();
            foreach (string com in System.IO.Ports.SerialPort.GetPortNames()) //自动获取串行口名称
            {
                cbb_tv.Items.Add(com);
            }
            WholeOutstr = new byte[7];
            try { cbb_tv.Text = config_json.TV_SerialPort_PortName; } catch { }
            tb_baut.Text = config_json.TV_SerialPort_BaudRate;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            com_TV.PortName = cbb_tv.Text;
            com_TV.BaudRate = Convert.ToInt32(tb_baut.Text);
            try
            {
                if (com_TV.IsOpen == false)
                {
                    com_TV.Open();
                    addmemo("TV串口打开成功");
                }
            }
            catch (Exception ex){
                addmemo("TV串口打开失败："+ex.Message);
            }
           
        }


        private void addmemo(string memo)
        {
            try
            {
                string txt = DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss.fff] ") + memo + Environment.NewLine;
                tbmemo.AppendText(txt);
                tbmemo.ScrollToCaret();
                // System.IO.StreamWriter sw2 = new System.IO.StreamWriter(logfile, true);
                // sw2.Write(txt);
                //  sw2.Close();
            }
            catch { }
        }


        //todo Test 电视串口接收数据处理
        /// <summary>
        /// 电视串口接收数据处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void com_TV_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            int n = com_TV.BytesToRead;
            byte[] buf = new byte[n];
            com_TV.Read(buf, 0, n);
            TVRecData =helper.stringhandle.ByteArrayToHexString(buf); ;
            addmemo("TV rec:" + TVRecData);
        }
     
        private void count_checkcode() {
            //int ucCheckNum = 0x100;
            //for (int i = 1; i < cmd.Length - 2; i++)
            //{
            //    if (ucCheckNum < 0)
            //    {
            //        ucCheckNum += 0x100;
            //        ucCheckNum -= cmd[i];
            //    }
            //    else
            //        ucCheckNum -= cmd[i];
            //}
            //if (ucCheckNum < 0)
            //    ucCheckNum += 0x100;
            //cmd[10] = Convert.ToByte(ucCheckNum);
        }


 
        private void btn_sendr_Click(object sender, EventArgs e)
        {
            if (com_TV.IsOpen == false) { button2_Click(null, null); }
            if (com_TV.IsOpen == false) return;
            cmd = CMD.SET_USR_R_GAIN;

            //cmd[4] = Convert.ToByte(Convert.ToInt16(tb_r.Text));
            cmd[3] = Convert.ToByte(Convert.ToInt16(tb_r.Text)/256);
            cmd[4] = Convert.ToByte(Convert.ToInt16(tb_r.Text)%256);

            count_checkcode();
            com_TV.Write(cmd, 0, cmd.Length);
            tbmemo.Text += "send to tv:" + helper.stringhandle.ByteArrayToHexString(cmd) + "\r\n";
        }
        private void btn_sendg_Click(object sender, EventArgs e)
        {
            if (com_TV.IsOpen == false) { button2_Click(null, null); }
            if (com_TV.IsOpen == false) return;
            cmd = CMD.SET_USR_G_GAIN;

           // cmd[4] = Convert.ToByte(Convert.ToInt16(tb_g.Text));
            cmd[3] = Convert.ToByte(Convert.ToInt16(tb_g.Text) / 256);
            cmd[4] = Convert.ToByte(Convert.ToInt16(tb_g.Text) % 256);
            count_checkcode();
            com_TV.Write(cmd, 0, cmd.Length);
            tbmemo.Text += "send to tv:" + helper.stringhandle.ByteArrayToHexString(cmd) + "\r\n";
        }
        private void btn_sendb_Click(object sender, EventArgs e)
        {
            if (com_TV.IsOpen == false) { button2_Click(null, null); }
            if (com_TV.IsOpen == false) return;
            cmd = CMD.SET_USR_B_GAIN;

            // cmd[4] = Convert.ToByte(Convert.ToInt16(tb_b.Text));
            cmd[3] = Convert.ToByte(Convert.ToInt16(tb_b.Text) / 256);
            cmd[4] = Convert.ToByte(Convert.ToInt16(tb_b.Text) % 256);

            count_checkcode();
            com_TV.Write(cmd, 0, cmd.Length);
            tbmemo.Text += "send to tv:" + helper.stringhandle.ByteArrayToHexString(cmd) + "\r\n";
        }

        private void btn_port_close_Click(object sender, EventArgs e)
        {
            if (com_TV.IsOpen) {
                com_TV.Close();
                addmemo("TV串口关闭成功");
            } 
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            com_CA410_BeginDataRec = true;
            Testxyt();
        }

        private void btn_r_add_Click(object sender, EventArgs e)
        {
            tb_r.Text = (Convert.ToInt16(tb_r.Text) + 1).ToString();
        }

        private void btn_r_minus_Click(object sender, EventArgs e)
        {
            tb_r.Text = (Convert.ToInt16(tb_r.Text) - 1).ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tb_g.Text = (Convert.ToInt16(tb_g.Text) + 1).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tb_g.Text = (Convert.ToInt16(tb_g.Text) -1).ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tb_b.Text = (Convert.ToInt16(tb_b.Text) + 1).ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tb_b.Text = (Convert.ToInt16(tb_b.Text) - 1).ToString();
        }

        private void btn_sendall_Click(object sender, EventArgs e)
        {
            if (com_TV.IsOpen == false) { button2_Click(null, null); }
            if (com_TV.IsOpen == false) return;

            tb_result.Text += "send RGB:"+ tb_r.Text+ ","+ tb_g.Text+"," + tb_b.Text + "\r\n";

            cmd = CMD.SET_USR_RGB_GAIN;
            cmd[3] =Convert.ToByte( Convert.ToInt16(tb_r.Text)/256);
            cmd[4] = Convert.ToByte(Convert.ToInt16(tb_r.Text)%256);
            cmd[5] = Convert.ToByte(Convert.ToInt16(tb_g.Text)/256);
            cmd[6] = Convert.ToByte(Convert.ToInt16(tb_g.Text)%256);
            cmd[7] = Convert.ToByte(Convert.ToInt16(tb_b.Text)/256);
            cmd[8] = Convert.ToByte(Convert.ToInt16(tb_b.Text)%256);
            count_checkcode();
            com_TV.Write(cmd, 0, cmd.Length);
            tbmemo.Text+="send to tv:" + helper.stringhandle.ByteArrayToHexString(cmd)+"\r\n";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = tb_cmd.Text.Trim().Replace(" ", ",0x");
            textBox1.Text = "{0x" + textBox1.Text + "}";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (com_TV.IsOpen == false) { button2_Click(null, null); }
            if (com_TV.IsOpen == false) return;
            tb_result.Text += "cool:\r\n";
            cmd = CMD.SetCoolTemp;
            com_TV.Write(cmd, 0, cmd.Length);
            tbmemo.Text += "send to tv:" + helper.stringhandle.ByteArrayToHexString(cmd) + "\r\n";
        }

        private void btn_stand_Click(object sender, EventArgs e)
        {
            if (com_TV.IsOpen == false) { button2_Click(null, null); }
            if (com_TV.IsOpen == false) return;
            tb_result.Text += "stand:\r\n";
            cmd = CMD.SetStandardTemp;
            com_TV.Write(cmd, 0, cmd.Length);
            tbmemo.Text += "send to tv:" + helper.stringhandle.ByteArrayToHexString(cmd) + "\r\n";
        }

        private void btn_warm_Click(object sender, EventArgs e)
        {
            if (com_TV.IsOpen == false) { button2_Click(null, null); }
            if (com_TV.IsOpen == false) return;
            tb_result.Text += "warm:\r\n";

            cmd = CMD.SetWarmTemp;
            com_TV.Write(cmd, 0, cmd.Length);
            tbmemo.Text += "send to tv:" + helper.stringhandle.ByteArrayToHexString(cmd) + "\r\n";
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            if (com_TV.IsOpen == false) { button2_Click(null, null); }
            if (com_TV.IsOpen == false) return;
            cmd = CMD.Close;
            com_TV.Write(cmd, 0, cmd.Length);
            tbmemo.Text += "send to tv:" + helper.stringhandle.ByteArrayToHexString(cmd) + "\r\n";
        }

        private void btn_80_Click(object sender, EventArgs e)
        {
            if (com_TV.IsOpen == false) { button2_Click(null, null); }
            if (com_TV.IsOpen == false) return;
            cmd = CMD.White80;
            com_TV.Write(cmd, 0, cmd.Length);
            tbmemo.Text += "send to tv:" + helper.stringhandle.ByteArrayToHexString(cmd) + "\r\n";
        }

        private void btn_20_Click(object sender, EventArgs e)
        {
            if (com_TV.IsOpen == false) { button2_Click(null, null); }
            if (com_TV.IsOpen == false) return;
            cmd = CMD.White20;
            com_TV.Write(cmd, 0, cmd.Length);
            tbmemo.Text += "send to tv:" + helper.stringhandle.ByteArrayToHexString(cmd) + "\r\n";
        }

        private void btn_100_Click(object sender, EventArgs e)
        {
            if (com_TV.IsOpen == false) { button2_Click(null, null); }
            if (com_TV.IsOpen == false) return;
            cmd = CMD.White100;
            com_TV.Write(cmd, 0, cmd.Length);
            tbmemo.Text += "send to tv:" + helper.stringhandle.ByteArrayToHexString(cmd) + "\r\n";

        }

        private void btn_GET_USR_R_GAN_Click(object sender, EventArgs e)
        {
            if (com_TV.IsOpen == false) { button2_Click(null, null); }
            if (com_TV.IsOpen == false) return;
            cmd = CMD.GET_USR_R_GAIN;
            com_TV.Write(cmd, 0, cmd.Length);
            tbmemo.Text += "send to tv:" + helper.stringhandle.ByteArrayToHexString(cmd) + "\r\n";
        }

        private void btn_GET_USR_G_GAN_Click(object sender, EventArgs e)
        {
            if (com_TV.IsOpen == false) { button2_Click(null, null); }
            if (com_TV.IsOpen == false) return;
            cmd = CMD.GET_USR_G_GAIN;
            com_TV.Write(cmd, 0, cmd.Length);
            tbmemo.Text += "send to tv:" + helper.stringhandle.ByteArrayToHexString(cmd) + "\r\n";
        }

        private void btn_GET_USR_B_GAN_Click(object sender, EventArgs e)
        {
            if (com_TV.IsOpen == false) { button2_Click(null, null); }
            if (com_TV.IsOpen == false) return;
            cmd = CMD.GET_USR_B_GAIN;
            com_TV.Write(cmd, 0, cmd.Length);
            tbmemo.Text += "send to tv:" + helper.stringhandle.ByteArrayToHexString(cmd) + "\r\n";
        }

        private void Form_TV_Communication_Test_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (com_TV.IsOpen)
            {
                com_TV.Close();
            }
            try
            {
                if (com_CA410.IsOpen) com_CA410.Close();
            }
            catch { }
           
        }

        private void btn_dtv_Click(object sender, EventArgs e)
        {
            if (com_TV.IsOpen == false) { button2_Click(null, null); }
            if (com_TV.IsOpen == false) return;
            cmd = CMD.DTV;
            com_TV.Write(cmd, 0, cmd.Length);
            tbmemo.Text += "send to tv:" + helper.stringhandle.ByteArrayToHexString(cmd) + "\r\n";
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
