using colortv_test_automation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Test_Automation
{
    public partial class Form_Main : Form
    {
        #region 公共变量定义
        class_Haier_wb_data data;
        HslCommunication.ModBus.ModbusTcpNet PLC;

        System.Timers.Timer timer_plc;  //间隔1秒时间检测plc的值，为1时开始测试 事件：tm_plc_Tick
        System.Timers.Timer TestTimeTimer;
        System.Timers.Timer Timer_TestTimeOut;

        int RealRGain, RealGGain, RealBGain;

        float destinx, destiny,destinx_min,destinx_max,destiny_min,destiny_max; //目标x,y

        float Realx, Realy;

        DateTime starttime;//测试开始时间

        string checkCA410_result = "";
        List<byte> buffer = new List<byte>(4096);

        bool ca410_inited = false;   //ca410是否已校零标识 false未校零 true 已校零
        bool Com_TV_inited = false;
        bool com_CA410_BeginDataRec = false;

        bool com_TV_BeginDataRec = false;

     
        int plc_reg_5000_value;
         #endregion
        //todo main 电视串口接收数据处理
        private void Com_TV_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            if (com_CA410_BeginDataRec == false)
            {
                com_TV.DiscardOutBuffer();
                return;
            } 
            System.Threading.Thread.Sleep(100);

            int n = com_TV.BytesToRead;
            addmemo("接收到数据长度:"+n.ToString());

            byte[] buf = new byte[n];
            com_TV.Read(buf, 0, n);
            addmemo("TV收到的数据:" + byteToHexStr(buf));

            if (com_TV_BeginDataRec == false)
            {
                addmemo("当前为不接收电视数据处理状态。");
                return;
            }

            if (n != 12)
            {
                TestNG();
                return;
            }
            if (adjusting == false) {
                tv_command_delay();
                autoreset_manual_adjust.Set();
                return;
            }
         }


       void  tv_command_delay()
        {
            System.Threading.Thread.Sleep(100);
        }


        // Pass()  放行，寄存器5001中写入1
        private void let_tvpass()
        {
     
            //PLC 5001 写入1  放行
            adapter_off();
            System.Threading.Thread.Sleep(500);
            if (config_json.PLC_Used)
            {
                PLC.Write("5001", Convert.ToInt16(1));  //放行
                addmemo("TV放行(set plc 5001=1)");
            }
        }

        private string data_restore()
        {
            addmemo("恢复生产数据");
            MySql.Data.MySqlClient.MySqlConnection con =
                    new MySql.Data.MySqlClient.MySqlConnection("Database=" + config_json.mysql_database_name
                    + ";Data Source=" + config_json.Mysql_IP
                    + ";User Id=" + config_json.Mysql_User
                    + ";Password=" + config_json.Mysql_Pass);
            try
            {
                con.Open();
            }
            catch (Exception ex)
            {
                return "数据库连接失败：" + ex.Message;
            }

            try
            {
               string query = "select * from "+ config_json.mysql_tongji_table + " where testdate='" + DateTime.Now.ToString("yyyy-MM-dd") + "'";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, con);
                MySql.Data.MySqlClient.MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    first_pass_num = Convert.ToInt16(dr["first_pass_num"]);

                    pass_num = Convert.ToInt16(dr["pass_num"]);

                    faulttest_num = Convert.ToInt16(dr["faulttest_num"]);

                    ng_num = Convert.ToInt16(dr["ng_num"].ToString());
                    tongji_update();
                }
                else
                {
                    con.Close();
                    con.Open();
                    string insertstr = "insert into "+ config_json.mysql_tongji_table + " (`testdate`) values('" + DateTime.Now.ToString("yyyy-MM-dd") + "')";
                    MySql.Data.MySqlClient.MySqlCommand insertcmd = new MySql.Data.MySqlClient.MySqlCommand(insertstr, con);
                    insertcmd.ExecuteNonQuery();
                }
                con.Close();

            }
            catch 
            {
                Mysql_Class.create_tongji_table();
                addmemo("统计数据表不存在，已创建新的统计表。");
            }
            return "OK";
        }

        /// <summary>
        ///  保存产品统计信息到数据库
        /// </summary>
        /// <returns></returns>
        private string update_pronum()
        {
            try
            {
                
                MySql.Data.MySqlClient.MySqlConnection Conn = new MySql.Data.MySqlClient.MySqlConnection("Database="
                + config_json.mysql_database_name + ";Data Source=" + config_json.Mysql_IP
                + ";User Id=" + config_json.Mysql_User + ";Password=" + config_json.Mysql_Pass + ";charset=utf8");
                Conn.Open();
                string updatestr = "UPDATE "+ config_json.mysql_tongji_table + " SET `first_pass_num`='" + lb_first_pass_num.Text
                    + "',`first_pass_rate`='" + lb_first_pass_rate.Text
                    + "',`pass_num`='" + lb_pass_num.Text
                    + "',`pass_rate`='" + lb_pass_rate.Text
                    + "',`faulttest_num`='" + lb_faulttest_num.Text
                    + "',`faulttest_rate`='" + lb_faulttest_rate.Text
                    + "',`ng_num`='" + lb_ng_num.Text
                    + "',`ng_rate`='" + lb_ng_rate.Text
                    + "',`memo`='" + ""
                    + "' WHERE `testdate`='" + DateTime.Now.ToString("yyyy-MM-dd") + "'";//插入今天日期并加载默认值0
                MySql.Data.MySqlClient.MySqlCommand insertcmd =
                    new MySql.Data.MySqlClient.MySqlCommand(updatestr, Conn);
                // tbmemo.Text = updatestr;

                insertcmd.ExecuteNonQuery();
                Conn.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// toto tongji_update()
        /// </summary>
        void tongji_update()
        {
            lb_first_pass_num.Text = first_pass_num.ToString();
            lb_pass_num.Text = pass_num.ToString();
            lb_faulttest_num.Text = faulttest_num.ToString();
            lb_ng_num.Text = ng_num.ToString();

            double totalnum = pass_num + ng_num;
            double rate = (first_pass_num / totalnum) * 100;
            lb_first_pass_rate.Text = Convert.ToString(Math.Round(rate, 2));

            rate = (pass_num / totalnum) * 100;
            lb_pass_rate.Text = Convert.ToString(Math.Round(rate, 2));

            rate = (faulttest_num / totalnum) * 100;
            lb_faulttest_rate.Text = Convert.ToString(Math.Round(rate, 2));

            rate = (ng_num / totalnum) * 100;
            lb_ng_rate.Text = Convert.ToString(Math.Round(rate, 2));
        }

      
       public  void window_init()
        {
            lb_title.Text = config_json.form_title;
            this.Text = config_json.form_title;

            lb_workstationid.Text = config_json.Workstationid;
            lb_plcip.Text = config_json.PLC_IP;
            cb_plc_used.Checked = config_json.PLC_Used;
            ts_username.Text = config_json.login_name;

            lb_TV_PortName.Text = config_json.TV_SerialPort_PortName;
            lb_ca410_portname.Text = config_json.CA410_SerialPort_PortName;

            cb_autorun.Checked = config_json.auto_run;
            cb_retryafterfail.Checked =config_json.retryafterfail;
            cb_stopafterfail.Checked = config_json.stopafterfail;
            cb_sendtomes.Checked =config_json.sendtomes;
            cb_prefailsnotomes.Checked =config_json.prefailsnotomes;
            cb_lettvpassafterfail_notsendng.Checked =config_json.lettvpassafterfail_notsendng;

            tb_coolx.Text = config_json.colortemp1x.ToString();
            tb_cooly.Text = config_json.colortemp1y.ToString();
            tb_standx.Text = config_json.colortemp2x.ToString();
            tb_standy.Text = config_json.colortemp2y.ToString();
            tb_warmx.Text = config_json.colortemp3x.ToString();
            tb_warmy.Text = config_json.colortemp3y.ToString();

            tb_c1_pre_r.Text = config_json.colortemp1r.ToString();
            tb_c1_pre_g.Text = config_json.colortemp1g.ToString();
            tb_c1_pre_b.Text = config_json.colortemp1b.ToString();

            tb_c2_pre_r.Text = config_json.colortemp2r.ToString();
            tb_c2_pre_g.Text = config_json.colortemp2g.ToString();
            tb_c2_pre_b.Text = config_json.colortemp2b.ToString();

            tb_c3_pre_r.Text = config_json.colortemp3r.ToString();
            tb_c3_pre_g.Text = config_json.colortemp3g.ToString();
            tb_c3_pre_b.Text = config_json.colortemp3b.ToString();

            tb_offx.Text = config_json.offx.ToString();
            tb_offy.Text = config_json.offy.ToString();

            tb_type.Text = config_json.TV_Type.ToString();
        }


        string[] step_name = {
            "伸出夹具",
           // "设置标准色温",
           // "设置白场100%亮度",
            // "获取调试前色坐标和亮度值",
            "切DTV通道",

             "设置白场80%亮度",
             "设置冷色温",
              "发送冷色温预设值",
              "调整冷色温",

              "设置暖色温",
              "发送暖色温预设值",
              "调整暖色温",

               "设置标准色温",
              "发送标准色温预设值",
              "调整标准色温",

             // "设置标准色温",
             //  "设置白场80%亮度",
         //   "获取调试后色坐标和亮度值",
            "SendToMes",
        };

        int current_step = 0;
        bool adjusting = false;
       byte[] tv_commmand;
       //int tv_command_delay=500;

  
        /// <summary>
        ///  tcp 发送指令tcp_send_command 
        /// </summary>
        void tv_send_command()
        {
            addmemo("发送到TV:" +byteToHexStr( tv_commmand));
            try
            {
                if (com_TV.IsOpen == false) com_TV.Open();
                com_TV.Write(tv_commmand, 0, tv_commmand.Length);
            }
            catch
            {
                addmemo("发送指令到TV失败");
            }
        }

        #region 窗体初始化:Form1_Load()
        /// <summary>
        /// 窗体初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            //config_file_path = "d:\\软件配置\\jyny_config.json";
            SOFT_VER.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

            System.IO.DirectoryInfo di_config = new System.IO.DirectoryInfo(config_json.ConfigPath);
            if (di_config.Exists == false) di_config.Create();

            
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(config_json.LogPath);
            if (di.Exists == false) di.Create();
            logfile = config_json.LogPath + DateTime.Now.ToString("yyyyMMddHHmmss") + ".log";
            addmemo("指定日志文件：" + logfile);
            addmemo("测试软件版本：" + SOFT_VER.Text);
            addmemo("读取配置文件：" + config_json.config_file_path);
            config_json.config_json_readall();
            progressBar1.Maximum =Convert.ToInt16( config_json.test_max_seconds);



            lb_title.BackColor = Color.Transparent;  //设备标题文字背景透明
            lb_title.Parent = pictureBox1;//将pictureBox1设为标签的父控件
            //pictureBox1.Controls.Add(label1);
            lb_title.Location = new Point(200, 15);//重新设定标签的位置，这个位置时相对于父控件的左上角

            TextBox.CheckForIllegalCrossThreadCalls = false;

            window_init();
            string data_restore_result = data_restore();
            if ("OK" != data_restore_result)//读取已保存生产数据
            {
                addmemo(data_restore_result);
             }  

            if (config_json.PLC_Used) PLC = new HslCommunication.ModBus.ModbusTcpNet(config_json.PLC_IP,
                  Convert.ToInt16(config_json.PLC_Port),
                  Convert.ToByte(config_json.PLC_Station));

            data = new class_Haier_wb_data();

            timer_plc = new System.Timers.Timer(1000);//实例化Timer类，设置间隔时间为1000毫秒；
            timer_plc.Elapsed += new System.Timers.ElapsedEventHandler(timer_plc_Tick);//到时间的时候执行事件；
            timer_plc.AutoReset = false;//设置是执行一次（false）还是一直执行(true)，默认值为False
            timer_plc.Enabled = false;//是否执行System.Timers.Timer.Elapsed事件；

            TestTimeTimer = new System.Timers.Timer(1000);  //测试时间显示 
            TestTimeTimer.Elapsed += new System.Timers.ElapsedEventHandler(TimerTestTime_Tick);//到时间的时候执行事件；
            TestTimeTimer.AutoReset = true;//设置是执行一次（false）还是一直执行(true)；
            TestTimeTimer.Enabled = false;//是否执行System.Timers.Timer.Elapsed事件；

            Timer_TestTimeOut = new System.Timers.Timer(Convert.ToInt16(  config_json.test_max_seconds)*1000);  //测试超时50
            Timer_TestTimeOut.Elapsed += new System.Timers.ElapsedEventHandler(Timer_TestTimeOut_Tick);//到时间的时候执行事件；
            Timer_TestTimeOut.AutoReset = false;//设置是执行一次（false）还是一直执行(true)；
            Timer_TestTimeOut.Enabled = false;//是否执行System.Timers.Timer.Elapsed事件；

            timer_check_adapter_is_on = new System.Timers.Timer(1000);
            timer_check_adapter_is_on.AutoReset = false;
            timer_check_adapter_is_on.Elapsed += new System.Timers.ElapsedEventHandler(timer_check_adapter_is_on_Tick);
            timer_check_adapter_is_on.Enabled = false;

            timer_check_adapter_is_off = new System.Timers.Timer(500);
            timer_check_adapter_is_off.AutoReset = false;
            timer_check_adapter_is_off.Elapsed += new System.Timers.ElapsedEventHandler(timer500_check_adapter_is_off_Tick);
            timer_check_adapter_is_off.Enabled = false;

            timer3s = new System.Timers.Timer(3000);  //自动开始延时
            timer3s.AutoReset = false;
            timer3s.Elapsed += new System.Timers.ElapsedEventHandler(timer3s_Tick);
            timer3s.Enabled = false;

            //根据设置执行是否自动开始进行测试
            if (config_json.auto_run == true) timer_start.Enabled = true;

          //  addmemo("获取标准值：x=" + tb_standx.Text + " y=" + tb_standy.Text);
          //  Standardx = Convert.ToSingle(tb_standx.Text);
          //  Standardy = Convert.ToSingle(tb_standy.Text);
        }

        #endregion


        #region  获取TV型号
        /// <summary>
        /// 获取电视机机型信息，读取PLC寄存器5002~5021
        /// </summary>
        String[] TV_type = new String[20];
        private string Get_TV_Type()
        {
            // return PLC.ReadString(config_json.PLC_Type_Register, 20).Content;
            String[] TV_type = new String[20];
            string plc_reg_5002 = config_json.PLC_Type_Register;
            HslCommunication.OperateResult<byte[]> read = PLC.Read(plc_reg_5002, 1);

            if (read.IsSuccess)
            {
                for (int i = 0; i < 20; i++)
                {
                    HslCommunication.OperateResult<byte[]> reg_value = PLC.Read(Convert.ToString(5002 + i), 1);
                    short value1 = PLC.ByteTransform.TransInt16(reg_value.Content, 0);

                    TV_type[i] = AsciiToStr(value1);
                }
                return string.Join("", TV_type);
            }
            else
            {
                MessageBox.Show(read.ToMessageShowString());
                return "";
            }
        }
        #endregion

        #region 获取电视机SN
        /// <summary>
        /// 获取电视机SN，读取PLC寄存器5022~5071
        /// </summary>
        String[] TV_SN = new String[50];
        private string  Get_TV_SN()
        {
            // return PLC.ReadString(config_json.PLC_SN_Register, 50).Content;
            int plc_reg = 5022;
            HslCommunication.OperateResult<byte[]> read = PLC.Read("5022", 1);

            if (read.IsSuccess)
            {
                for (int i = 0; i < 50; i++)
                {
                    HslCommunication.OperateResult<byte[]> reg_value = PLC.Read(Convert.ToString(plc_reg + i), 1);
                    short value = PLC.ByteTransform.TransInt16(reg_value.Content, 0);

                    TV_SN[i] = AsciiToStr(value);
                }
                return string.Join("", TV_SN);
            }
            else
            {
                return "";
            }
        }

        //清除PLC中SN，条码框清空
        private bool Clear_SN()
        {
            if (config_json.PLC_Used)
            {
                int clear = 5022;
                try
                {
                    for (int i = 0; i < 50; i++)
                    {
                        clear = clear + i;
                        PLC.Write(clear.ToString(), Convert.ToInt16(0));
                    }
                    tb_sn.Text = "";
                    return true;
                }
                catch (Exception ex)
                {
                    addmemo("清除SN失败： " + ex);
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region  ASCII码转Str
        /// <summary>
        /// ASCII码转Str
        /// </summary>
        /// <param name="asciiCode"></param>
        /// <returns></returns>
        public static string AsciiToStr(int asciiCode)
        {
            if (asciiCode >= 0 && asciiCode <= 255)
            {
                System.Text.ASCIIEncoding asciiEncoding = new System.Text.ASCIIEncoding();
                byte[] byteArray = new byte[] { (byte)asciiCode };
                string strCharacter = asciiEncoding.GetString(byteArray);
                return (strCharacter);
            }
            else
            {
                throw new Exception("ASCII Code is not valid.");
            }
        }
        #endregion


        System.Timers.Timer timer3s;

        private void timer3s_Tick(object sender, ElapsedEventArgs e)
        {
            timer_plc.Enabled = true;
        }


        #region 获取当前x,y值:bool Testxyt()
        /// <summary>
        /// 获取当前x,y值
        /// </summary>
        /// <returns></returns>
        private bool Testxyt()
        {
            if (ca410_inited == false)
            {
                com_CA410_BeginDataRec = false;
                ca410_init();
            }
            com_CA410_BeginDataRec = true;
            try
            {
                if (com_CA410.IsOpen == false) com_CA410.Open();
            }
            catch {
                addmemo("CA410串口打开失败");
                return false;
            }
           
            com_CA410.DiscardInBuffer();
            com_CA410.DiscardOutBuffer();
            com_CA410.WriteLine("MES,1");
            addmemo("发送指令到CA410:MES,1");
            return true;
            //com_CA410_DataReceived
        }
        #endregion



        //HC4-BPHTS-001   与TV通讯失败
        //HC4-BPHTS-002   调试超时
        //HC4-BPHTS-003   调试失败
        //HC4-BPHTS-004   电视不出图


        #region 显示调试时间:CalTime()
        /// <summary>
        /// 显示调试时间
        /// </summary>
        private void CalTime()
        {
            TimeSpan span = DateTime.Now - starttime;
            lb_testseconds.Text = Convert.ToString(Math.Round(span.TotalSeconds)); //只显示整数 秒
            try
            {
                progressBar1.Value += 1;
            }
            catch { }
        }
        #endregion


        #region 连接CA410并进行校零:bool ca410_init()
        /// <summary>
        /// 连接CA410并进行校零
        /// </summary>
        private bool ca410_init()
        {
            if (ca410_inited == false)
            {
                try
                {
                    com_CA410 = Serial_Class.get_serial_port_CA410();
                    if (com_CA410.IsOpen == false) com_CA410.Open();
                }
                catch
                {
                    MessageBox.Show("ca410端口打开失败！");
                    return false;
                }
                com_CA410.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(com_CA410_DataReceived);
                com_CA410_BeginDataRec = true;
                ca410_inited = true;
                return true;
            }
            return true;
        }
        #endregion

        bool ca410_retry = false;

        #region CA410 串口接收处理
        /// <summary>
        ///todo  CA410 串口接收处理
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
            System.Threading.Thread.Sleep(100);
            try
            {
                int n = com_CA410.BytesToRead;
                byte[] buf = new byte[n];
                com_CA410.Read(buf, 0, n);


                //触发外部处理接收消息事件
                checkCA410_result = System.Text.Encoding.Default.GetString(buf);

                Invoke(new EventHandler(delegate
                {
                    //WholeSendStr = "ca410 received:" + checkCA410_result;
                    //addmemo(WholeSendStr);

                    //OK00,P1,0,-0.063188,0.4563044,6.6227164,-0.23,-99999999
                    //56个字符，结尾有一个0x0D换行符
                    string[] CA410RecData = checkCA410_result.Split(',');
                    if (CA410RecData.Length == 8)
                    {
                        ca410_retry = false;
                        Realx = Convert.ToSingle(CA410RecData[3]);
                        Realy = Convert.ToSingle(CA410RecData[4]);
                        EditRealx.Text = Realx.ToString();
                        EditRealy.Text = Realy.ToString();
                        EditRealt.Text = CA410RecData[5];
                        addmemo("CA410实测x,y,t：  " + Realx + "," + Realy + "," + EditRealt.Text);
                    }
                    else {
                        ca410_retry = true;
                        com_CA410.DiscardInBuffer();
                        com_CA410.DiscardOutBuffer();
                        com_CA410.WriteLine("MES,1");
                        addmemo("CA410接收数据异常，重发MS,1");
                        return;
                    }

                    if (ca410_retry == true) return;

                    if (adjusting == false)
                    {
                        autoreset_manual_adjust.Set();
                    }
                    else
                    {
                        #region //色坐标调试
                        if (Realx >= destinx_min && Realx <= destinx_max && Realy >= destiny_min && Realy <= destiny_max) {

                            if ((Realy - Realx)>=0.003) //y-x>0.003
                            {    
                                //调试完成
                                addmemo("本色温调试完成，进入下一步骤");
                                save_current_data2();
                                autoreset_manual_adjust.Set();
                                return;
                            } else
                            {
                                //增加y值
                                tv_commmand = CMD.SET_USR_B_GAIN;
                                RealBGain -= config_json.BStepLen;
                                if (RealBGain < config_json.BGainMin)
                                {
                                    addmemo("B值低于下限");
                                    TestNG();
                                    return;
                                }
                                addmemo("(Realy - Realx)<0.003,发送新的B值：" + RealBGain.ToString());
                                EditRealBGain.Text = RealBGain.ToString();
                                tv_commmand[3] = Convert.ToByte(RealBGain / 256);
                                tv_commmand[4] = Convert.ToByte(RealBGain % 256);
                                tv_send_command();
                                System.Threading.Thread.Sleep(config_json.Delay410);
                                Testxyt();
                                return;
                            }
                        }

                        if (Realy < destiny_min) {
                            tv_commmand = CMD.SET_USR_B_GAIN;
                            RealBGain -= config_json.BStepLen;
                            if (RealBGain < config_json.BGainMin) {
                                addmemo("B值低于下限");
                                TestNG();
                                return;
                            }
                            addmemo("发送新的B值："+RealBGain.ToString());
                            EditRealBGain.Text = RealBGain.ToString();
                            //tv_commmand[4] = Convert.ToByte(RealBGain);
                            tv_commmand[3] = Convert.ToByte(RealBGain / 256);
                            tv_commmand[4] = Convert.ToByte(RealBGain % 256);
                            tv_send_command();
                        }
                        else if (Realy > destiny_max)
                        {
                            tv_commmand = CMD.SET_USR_B_GAIN;
                            RealBGain += config_json.BStepLen;
                            if (RealBGain > config_json.BGainMax)
                            {
                                addmemo("B值大于上限");
                                TestNG();
                                return;
                            }
                            EditRealBGain.Text = RealBGain.ToString();
                            addmemo("发送新的B值：" + RealBGain.ToString());
                            // tv_commmand[4] = Convert.ToByte(RealBGain);
                            tv_commmand[3] = Convert.ToByte(RealBGain / 256);
                            tv_commmand[4] = Convert.ToByte(RealBGain % 256);
                            tv_send_command();
                        }
                        else if (Realx < destinx_min)
                        {
                            tv_commmand = CMD.SET_USR_R_GAIN;
                            RealRGain += config_json.RStepLen;
                            if (RealRGain > config_json.RGainMax)
                            {
                                addmemo("R值高于上限");
                                TestNG();
                                return;
                            }
                            EditRealRGain.Text = RealRGain.ToString();
                            addmemo("发送新的R值：" + RealRGain.ToString());
                             tv_commmand[3] = Convert.ToByte(RealRGain / 256);
                            tv_commmand[4] = Convert.ToByte(RealRGain % 256);
                            tv_send_command();
                        }
                        else if (Realx > destinx_max)
                        {
                            tv_commmand = CMD.SET_USR_R_GAIN;
                            RealRGain -= config_json.RStepLen; ;
                            if (RealRGain < config_json.RGainMin)
                            {
                                addmemo("R值低于下限");
                                TestNG();
                                return;
                            }
                            EditRealRGain.Text = RealRGain.ToString();
                            addmemo("发送新的R值：" + RealRGain.ToString());
                              tv_commmand[3] = Convert.ToByte(RealRGain / 256);
                            tv_commmand[4] = Convert.ToByte(RealRGain % 256);
                            tv_send_command();
                        }
                        System.Threading.Thread.Sleep(config_json.Delay410);
                        Testxyt();
                        #endregion
                    }


                }));
            }
            catch {
                addmemo("ca410接收数据处理异常");
            }
        }
        #endregion

        private void save_current_data()
        {
            if (current_step > step_name.Length)
            {
                addmemo("测试步骤异常");
                TestStop();
                return;
            }

          
            switch (step_name[current_step])
            {
                case "调整冷色温":  //色温120

                    data.coolx = EditRealx.Text;
                    data.cooly = EditRealy.Text;
                    data.coolr = RealRGain.ToString();
                    data.coolg = RealGGain.ToString();
                    data.coolb = RealBGain.ToString();
                    lb_coolrealx.Text = "x=" + EditRealx.Text;
                    lb_coolrealy.Text = "y=" + EditRealy.Text;
                    lb_coolrgb.Text = "rgb=" + RealRGain.ToString() + "," + RealGGain.ToString() + "," + RealBGain.ToString();
                    break;
                case "调整标准色温":  //色温120

                    data.standx = EditRealx.Text;
                    data.standy = EditRealy.Text;
                    data.standr = RealRGain.ToString();
                    data.standg = RealGGain.ToString();
                    data.standb = RealBGain.ToString();
                    lb_standrealx.Text = "x=" + EditRealx.Text;
                    lb_standrealy.Text = "y=" + EditRealy.Text;
                    lb_standrgb.Text = "rgb=" + RealRGain.ToString() + "," + RealGGain.ToString() + "," + RealBGain.ToString();
                    break;
                case "调整暖色温":  //色温120

                    data.warmx = EditRealx.Text;
                    data.warmy = EditRealy.Text;
                    data.warmr = RealRGain.ToString();
                    data.warmg = RealGGain.ToString();
                    data.warmb = RealBGain.ToString();
                    lb_warmrealx.Text = "x=" + EditRealx.Text;
                    lb_warmrealy.Text = "y=" + EditRealy.Text;
                    lb_warmrgb.Text = "rgb=" + RealRGain.ToString() + "," + RealGGain.ToString() + "," + RealBGain.ToString();
                    break;


            }
        }
        private void save_current_data2()
        {
            switch (color)
            {
                case "cool":  //色温120

                    data.coolx = EditRealx.Text;
                    data.cooly = EditRealy.Text;
                    data.coolr = RealRGain.ToString();
                    data.coolg = RealGGain.ToString();
                    data.coolb = RealBGain.ToString();
                    lb_coolrealx.Text = "x=" + EditRealx.Text;
                    lb_coolrealy.Text = "y=" + EditRealy.Text;
                    lb_coolrgb.Text = "rgb=" + RealRGain.ToString() + "," + RealGGain.ToString() + "," + RealBGain.ToString();
                    break;
                case "stand":  //色温120

                    data.standx = EditRealx.Text;
                    data.standy = EditRealy.Text;
                    data.standr = RealRGain.ToString();
                    data.standg = RealGGain.ToString();
                    data.standb = RealBGain.ToString();
                    lb_standrealx.Text = "x=" + EditRealx.Text;
                    lb_standrealy.Text = "y=" + EditRealy.Text;
                    lb_standrgb.Text = "rgb=" + RealRGain.ToString() + "," + RealGGain.ToString() + "," + RealBGain.ToString();
                    break;
                case "warm":  //色温120

                    data.warmx = EditRealx.Text;
                    data.warmy = EditRealy.Text;
                    data.warmr = RealRGain.ToString();
                    data.warmg = RealGGain.ToString();
                    data.warmb = RealBGain.ToString();
                    lb_warmrealx.Text = "x=" + EditRealx.Text;
                    lb_warmrealy.Text = "y=" + EditRealy.Text;
                    lb_warmrgb.Text = "rgb=" + RealRGain.ToString() + "," + RealGGain.ToString() + "," + RealBGain.ToString();
                    break;


            }
        }


        public Form_Main()
        {
            InitializeComponent();
        }

        bool btn_start_pressed = false;

        private void btn_start_Click(object sender, EventArgs e)
        {
            lb_workmode.Text = "自动";
            com_TV_BeginDataRec = true;
            test_stopped = false;
            Task.Run(
             () =>
             {
                 ca410_zerocalibration();
                 autoresetevent_result = autoreset_manual_adjust.WaitOne(10000);
                 if (!autoresetevent_result)
                 {
                     addmemo("ca410初始化及校零超时10s！");
                     return;
                 }

                 tv_init();
                 autoresetevent_result = autoreset_manual_adjust.WaitOne(5000);
                 if (!autoresetevent_result)
                 {
                     addmemo("电视打开串口超时5s！");
                     return;
                 }

                 addmemo("PLC 使用：" + config_json.PLC_Used);
                 if (config_json.PLC_Used)
                 {
                     addmemo("连接PLC:" + config_json.PLC_IP + "-" + config_json.PLC_Station + "-" + config_json.PLC_Port);
                     HslCommunication.OperateResult resut = PLC.ConnectServer();
                     if (resut.IsSuccess)
                     {
                         addmemo("PLC连接成功！");
                         //todo 1　启动timer_plc
                         timer_plc.Enabled = true;
                     }
                     else
                     {
                         addmemo("PLC连接失败！");
                         return;
                     }
                 }
                
             });
        
        }


        #region PLC事件：tm_plc_Tick()
        //todo 2 tm_plc_Tick()
        private void timer_plc_Tick(object sender, ElapsedEventArgs e)
        {
            timer_plc.Enabled = false;

            if (config_json.PLC_Used == false)
            {
                timer_plc.Enabled = true;
                return;
            }
            plc_reg_5000_value = Convert.ToInt16(plc_read(config_json.PLC_StartTest_Register));
            if (plc_reg_5000_value == 0)
            {
                timer_plc.Enabled = true;
                lb_mes_info.Text = "0";
                lb_mes_status.Text = "等待产品";
                return;
            }
            else
            {
                tbmemo.Text = "";
            }

            lb_mes_info.Text = plc_reg_5000_value.ToString();
           
            switch (plc_reg_5000_value)
            {
                case 1:
                    lb_mes_status.Text = "NG";
                    break;
                case 2:
                    lb_mes_status.Text = "NG";
                    break;
                case 4:
                    lb_mes_status.Text = "空板";
                    break;
                case 8:
                    lb_mes_status.Text = "流程异常";
                    break;
                case 16:
                    lb_mes_info.Text = "条码异常";

                    break;
                default:
                    break;
            }

            if (config_json.ShakeHand_OK_Code == lb_mes_info.Text)
            {
                lb_mes_status.Text = "OK";
            }

            addmemo("mes状态：5000=" + plc_reg_5000_value + " " + lb_mes_status.Text);

            //对不测试但获取了sn的电视机信息保存到本地数据库
            if (tb_sn.Text != "" && lb_mes_status.Text != "OK")
            {
                try
                {
                    class_Haier_wb_data wbdata = new class_Haier_wb_data();
                    wbdata.SN = tb_sn.Text;
                    wbdata.MO = tb_type.Text;
                    wbdata.testdate = DateTime.Now;
                    wbdata.WORKSTATIONID = lb_workstationid.Text;
                    wbdata.memo = "MES 信息：" + lb_mes_info.Text + "-" + lb_mes_status.Text;
                    wbdata.SOFT_VER = SOFT_VER.Text;
                    addmemo("保存到本地数据库");
                    Mysql_Class.InsertData(wbdata);
                }
                catch { }
            }

            if (lb_mes_status.Text != "OK")
            {
                addmemo("握手信号清零：5000=0");
                PLC.Write("5000", Convert.ToInt16(0));
                timer_plc.Enabled = true;
                return;
            }

            System.Threading.Thread.Sleep(100);

            //todo 3 获取机型与SN信息
            addmemo("获取机型与SN信息......");

            tb_sn.Text = Get_TV_SN();
            tb_type.Text = Get_TV_Type();

            if (tb_sn.Text.Length < 2)
            {
                addmemo("1秒后再次获取机型与SN信息......");
                System.Threading.Thread.Sleep(1000);
                tb_sn.Text = Get_TV_SN();
                tb_type.Text = Get_TV_Type();
            }

            if (tb_sn.Text.Length < 2)
            {
                addmemo("1秒后再次获取机型与SN信息！");
                System.Threading.Thread.Sleep(1000);
                tb_sn.Text = Get_TV_SN();
                tb_type.Text = Get_TV_Type();
            }

            if (tb_sn.Text.Length < 2)
            {
                addmemo("1秒后再次获取机型与SN信息！");
                System.Threading.Thread.Sleep(1000);
                tb_sn.Text = Get_TV_SN();
                tb_type.Text = Get_TV_Type();
            }

            if (tb_sn.Text.Length < 2)
            {
                fail_info = "3次获取机型与SN信息失败";
                addmemo(fail_info);
                TestStop();
                return;
            }
            addmemo("成功获取机型：" + tb_type.Text + " SN:" + tb_sn.Text);

            //需要进行测试
            Invoke(new EventHandler(delegate
            {
                fail_times = 0;
                //tbmemo.Text = "";
                progressBar1.Value = 0;
                starttime = DateTime.Now;
                lb_result.Text = "调试中";
                TestTimeTimer.Enabled = true;

                //todo 4 开始测试前初始化数据
                TestBegin();

                //todo 5 执行测试步骤
                //do_main_steps();
                adapter_on();

               
            }));

        }
        #endregion

        //todo 6 各测试步骤汇总
        // 这里是自动测试，手动输条码测试使用的是Manual_Adjust
        //2021 1201 这个函数已经被Manual_Adjust代替
        void do_main_steps()
        {
            if (test_stopped == true) return;

            if (current_step > step_name.Length - 1)
            {
                //addmemo("step 超出范围");
                return;
            }

            lb_step.Text = step_name[current_step];
            addmemo("当前测试步骤：" + current_step.ToString() + "-" + lb_step.Text);

            switch (step_name[current_step])
            {

                case "伸出夹具":
                    adjusting = false;
                    adapter_on();
                    break;

                //case "设置白场100%亮度":
                //    adjusting = false;
                //    tv_commmand = CMD.White100;
                //    tv_send_command();   //Com_TV_DataReceived
                //    break;

                case "切DTV通道":
                    adjusting = false;
                    tv_commmand = CMD.DTV;
                    tv_send_command();   //Com_TV_DataReceived
                    break;

                //case "获取调试前色坐标和亮度值":
                //    adjusting = false;
                //    Testxyt();
                //    break;

                case "设置白场80%亮度":
                    adjusting = false;
                    tv_commmand = CMD.White80;
                    tv_send_command();   //Com_TV_DataReceived
                    break;

                case "设置冷色温":
                    adjusting = false;//发送指令到tv收到响应后会调用dosteps
                    tv_commmand = CMD.SetCoolTemp;
                    tv_send_command();
                    break;
                case "发送冷色温预设值":
                    adjusting = false;//发送指令到tv收到响应后会调用dosteps
                    tv_commmand = CMD.SET_USR_RGB_GAIN;
                    RealRGain = config_json.colortemp1r;
                    RealGGain = config_json.colortemp1g;
                    RealBGain = config_json.colortemp1b;
                    EditRealRGain.Text = RealRGain.ToString();
                    EditRealGGain.Text = RealGGain.ToString();
                    EditRealBGain.Text = RealBGain.ToString();
                    addmemo(EditRealRGain.Text + "," + EditRealGGain.Text + "," + EditRealBGain.Text);
                    tv_commmand[3] = Convert.ToByte(RealRGain / 256);
                    tv_commmand[4] = Convert.ToByte(RealRGain % 256);
                    tv_commmand[5] = Convert.ToByte(RealGGain / 256);
                    tv_commmand[6] = Convert.ToByte(RealGGain % 256);
                    tv_commmand[7] = Convert.ToByte(RealBGain / 256);
                    tv_commmand[8] = Convert.ToByte(RealBGain % 256);
                      addmemo("发送到TV:" + byteToHexStr(tv_commmand));
                    tv_send_command();
                    break;

                case "调整冷色温":
                    adjusting = true;
                    destinx = Convert.ToSingle(tb_coolx.Text);
                    destiny = Convert.ToSingle(tb_cooly.Text);
                    destinx_min = destinx - Convert.ToSingle(tb_offx.Text);
                    destinx_max = destinx + Convert.ToSingle(tb_offx.Text);
                    destiny_min = destiny - Convert.ToSingle(tb_offy.Text);
                    destiny_max = destiny + Convert.ToSingle(tb_offy.Text);
                    addmemo("调试目标值x：" + destinx.ToString() + " y:" + destiny.ToString() + " 允许偏差：" + tb_offx.Text);
                    Testxyt();
                    break;

                case "设置标准色温":
                    adjusting = false;//发送指令到tv收到响应后会调用dosteps
                    tv_commmand = CMD.SetStandardTemp;
                    tv_send_command();
                    break;
                case "发送标准色温预设值":
                    adjusting = false;//发送指令到tv收到响应后会调用dosteps
                    tv_commmand = CMD.SET_USR_RGB_GAIN;
                    RealRGain = config_json.colortemp2r;
                    RealGGain = config_json.colortemp2g;
                    RealBGain = config_json.colortemp2b;
                    EditRealRGain.Text = RealRGain.ToString();
                    EditRealGGain.Text = RealGGain.ToString();
                    EditRealBGain.Text = RealBGain.ToString();
                    addmemo(EditRealRGain.Text + "," + EditRealGGain.Text + "," + EditRealBGain.Text);
                    tv_commmand[3] = Convert.ToByte(RealRGain / 256);
                    tv_commmand[4] = Convert.ToByte(RealRGain % 256);
                    tv_commmand[5] = Convert.ToByte(RealGGain / 256);
                    tv_commmand[6] = Convert.ToByte(RealGGain % 256);
                    tv_commmand[7] = Convert.ToByte(RealBGain / 256);
                    tv_commmand[8] = Convert.ToByte(RealBGain % 256);
                    tv_send_command();
                    break;

                case "调整标准色温":
                    adjusting = true;
                    destinx = Convert.ToSingle(tb_standx.Text);
                    destiny = Convert.ToSingle(tb_standy.Text);
                    destinx_min = destinx - Convert.ToSingle(tb_offx.Text);
                    destinx_max = destinx + Convert.ToSingle(tb_offx.Text);
                    destiny_min = destiny - Convert.ToSingle(tb_offy.Text);
                    destiny_max = destiny + Convert.ToSingle(tb_offy.Text);
                    addmemo("调试目标值x：" + destinx.ToString() + " y:" + destiny.ToString() + " 允许偏差：" + tb_offx.Text);
                    Testxyt();
                    break;
                case "设置暖色温":
                    adjusting = false;//发送指令到tv收到响应后会调用dosteps
                    tv_commmand = CMD.SetWarmTemp;
                    tv_send_command();
                    break;
                case "发送暖色温预设值":
                    adjusting = false;//发送指令到tv收到响应后会调用dosteps
                    tv_commmand = CMD.SET_USR_RGB_GAIN;
                    RealRGain = config_json.colortemp3r;
                    RealGGain = config_json.colortemp3g;
                    RealBGain = config_json.colortemp3b;
                    EditRealRGain.Text = RealRGain.ToString();
                    EditRealGGain.Text = RealGGain.ToString();
                    EditRealBGain.Text = RealBGain.ToString();
                    addmemo(EditRealRGain.Text + "," + EditRealGGain.Text + "," + EditRealBGain.Text);
                    tv_commmand[3] = Convert.ToByte(RealRGain / 256);
                    tv_commmand[4] = Convert.ToByte(RealRGain % 256);
                    tv_commmand[5] = Convert.ToByte(RealGGain / 256);
                    tv_commmand[6] = Convert.ToByte(RealGGain % 256);
                    tv_commmand[7] = Convert.ToByte(RealBGain / 256);
                    tv_commmand[8] = Convert.ToByte(RealBGain % 256);
                    tv_send_command();
                    break;

                case "调整暖色温":
                    adjusting = true;
                    destinx = Convert.ToSingle(tb_warmx.Text);
                    destiny = Convert.ToSingle(tb_warmy.Text);
                    destinx_min = destinx - Convert.ToSingle(tb_offx.Text);
                    destinx_max = destinx + Convert.ToSingle(tb_offx.Text);
                    destiny_min = destiny - Convert.ToSingle(tb_offy.Text);
                    destiny_max = destiny + Convert.ToSingle(tb_offy.Text);
                    addmemo("调试目标值x：" + destinx.ToString() + " y:" + destiny.ToString() + " 允许偏差：" + tb_offx.Text);
                    Testxyt();
                    break;

                case "获取调试后色坐标和亮度值":
                    adjusting = false;
                    Testxyt();
                    break;
                case "SendToMes":
                    //保存到本地数据库
                    TestTimeTimer.Enabled = false;
                    Timer_TestTimeOut.Enabled = false;
                    lb_result.ForeColor = Color.Green;
                    lb_result.Text = "OK";
                    data.testdate = DateTime.Now;
                    TestOK();
                    break;
                default:
                    break;
            }
        }
        //todo 7 TestOK()
        #region 测试成功处理:TestOK()
        /// <summary>
        /// 测试成功处理
        /// </summary>
        private void TestOK()
        {
            data.ERROR_CODE = "";
            data.ERROR_SPOT = "";
            // lb_result.BackColor = Color.LawnGreen;
            //  light_green_on(); //绿灯   

            lb_result.ForeColor = Color.Green;
            lb_result.Text = "OK";
            fail_info = "";
            // if (config_json.PLC_Used) PLC.Write(config_json.PLC_Light_Register, config_json.PLC_Light_GREEN);//测试OK，亮绿灯
            TestEnd();
        }

        //todo 8 TestNG()
        private void TestNG()
        {
            lb_result.ForeColor = Color.Red;
            lb_result.Text = "NG";
            if (config_json.PLC_Used) light_red_on();  //测试NG，亮红灯

            if (cb_retryafterfail.Checked == true)
            {
                if (fail_times == 2)
                {
                    fail_info = "已经测试两次失败";
                    addmemo(fail_info);


                    if (cb_lettvpassafterfail_notsendng.Checked)
                    {
                        addmemo("测试失败后放行，不发NG");
                        TestEnd();
                    }
                    else
                    {
                        if (cb_stopafterfail.Checked)
                        {
                            TestStop();
                        }
                        else
                        {
                            TestEnd();
                        }
                    }

                    return;
                }

                if (fail_times == 3)
                {
                    addmemo("手动测试仍失败，提交MES");
                    TestEnd();
                    savetolog();
                    return;
                }
                if (cb_prefailsnotomes.Checked) //前两次NG不发MES
                {
                }
                else
                {  //前两次NG仍发MES
                    if (cb_sendtomes.Checked)
                    {
                        string json = SendDataToMes.Data_To_Json(data);
                        addmemo("发送到MES:" + json);  //显示发送的数据
                        data.mesreply = SendDataToMes.SendData(json);
                        if (data.mesreply.IndexOf("message") == -1)
                        {
                            addmemo("MES未响应，再次重发...");
                            //mes send error Retry
                            System.Threading.Thread.Sleep(3000);
                            data.mesreply = SendDataToMes.SendData(json);
                        }
                        if (data.mesreply.IndexOf("message") == -1)
                        {
                            //mes send error Retry
                            addmemo("MES未响应，再次重发...");
                            System.Threading.Thread.Sleep(3000);
                            data.mesreply = SendDataToMes.SendData(json);
                        }
                        if (data.mesreply.IndexOf("message") == -1)
                        {

                            fail_info = "发送数据到MES失败3次";
                            addmemo(fail_info);
                            TestStop();
                            return;
                        }
                        addmemo("MES回复:" + data.mesreply);  //发送到MES
                        tb_mesreply.Text = tb_sn.Text + ":" + data.mesreply;

                    }
                }

                fail_times++;
                addmemo("开始重测:" + fail_times.ToString());
                TestBegin();
                Manual_Adjust();
                //if (lb_workmode.Text == "手动")
                //{
                //    Manual_Adjust();
                //}
                //else
                //{
                //    do_main_steps();
                //}

            }
        }
        #endregion

        //todo 9 TestEnd()
        /// <summary>
        /// 单台设备测试结束（不论pass or fail）
        /// </summary>
        void TestEnd()
        {
            com_TV_BeginDataRec = false;

            if (lb_result.Text == "OK" && fail_times == 0)
            {
                if (config_json.PLC_Used) light_green_on();
                first_pass_num++;
                pass_num++;
            }
            if (lb_result.Text == "OK" && fail_times > 0)
            {
                if (config_json.PLC_Used) light_green_on();
                pass_num++;
            }

            if (lb_result.Text == "NG")
            {
                if (config_json.PLC_Used) light_red_on();
                ng_num++;
            }
            data.testdate = DateTime.Now;
            data.MO = tb_type.Text;
            data.SN = tb_sn.Text;
            data.WORKSTATIONID = lb_workstationid.Text;
            data.SOFT_VER = SOFT_VER.Text;
            data.RESULT = lb_result.Text;
            data.testseconds = lb_testseconds.Text;

            TestTimeTimer.Enabled = false;

            tongji_update();

            addmemo("生产数据更新：" + update_pronum());

            #region sendtomes
            if (cb_sendtomes.Checked)
            {
                if (cb_lettvpassafterfail_notsendng.Checked && lb_result.Text == "NG") //重测失败后放行（不发NG）
                {

                }
                else
                {
                    string json = SendDataToMes.Data_To_Json(data);
                    addmemo("发送到MES:" + json);  //显示发送的数据
                    data.mesreply = SendDataToMes.SendData(json);
                    if (data.mesreply.IndexOf("message") == -1)
                    {
                        addmemo("MES未响应，再次重发...");
                        //mes send error Retry
                        System.Threading.Thread.Sleep(3000);
                        data.mesreply = SendDataToMes.SendData(json);
                    }
                    if (data.mesreply.IndexOf("message") == -1)
                    {
                        //mes send error Retry
                        addmemo("MES未响应，再次重发...");
                        System.Threading.Thread.Sleep(3000);
                        data.mesreply = SendDataToMes.SendData(json);
                    }
                    if (data.mesreply.IndexOf("message") == -1)
                    {

                        fail_info = "发送数据到MES失败3次";
                        addmemo(fail_info);
                        TestStop();
                        return;
                    }
                    addmemo("MES回复:" + data.mesreply);  //发送到MES
                    tb_mesreply.Text = tb_sn.Text + ":" + data.mesreply;

                }
            }
            else
            {
                addmemo("系统设置不发送mes信息。");
            }
            #endregion
            //保存到本地数据库


            try
            {
                // if (config_json.mysql_used)
                if (true)
                {
                    addmemo("保存本地数据");
                    addmemo(Mysql_Class.InsertData(data));
                }
                else
                {
                    addmemo("系统设置未保存本地数据。");
                }
            }
            catch { }


            if (lb_workmode.Text == "自动")
            {
                tb_sn.Text = "";
                if (config_json.PLC_Used)
                {
                    let_tvpass();
                    addmemo("sn清零");
                    Clear_SN();
                    addmemo("握手信号清零：5000=0");
                    PLC.Write("5000", Convert.ToInt16(0));
                    addmemo("等待下一台产品到位");
                    timer_plc.Enabled = true;
                }
            }
            tb_sn.Text = "";
            savetolog();
        }
        bool check_adapter_on = true;
        private void adapter_on()
        {
            if (config_json.PLC_Used)
            {
                if (check_adapter_on)
                {
                    if (plc_read(config_json.PLC_Adapter_Register) == "1")
                    {
                        adapter_on_try_times = 0;
                        adapter_is_on = true;
                        addmemo("夹具已合上");
                        lb_adapter_status.Text = "已合上";
                        // current_step++;
                        // do_main_steps();
                        Manual_Adjust();
                    }
                    else
                    {
                        adapter_on_try_times = 0;
                        PLC.Write(config_json.PLC_Adapter_Register, Convert.ToInt16(4));
                        addmemo("伸出夹具（PLC写入：" + config_json.PLC_Adapter_Register + "=" + 4.ToString() + ")");
                        timer_check_adapter_is_on.Enabled = true;

                    }
                }
                else
                {
                    PLC.Write(config_json.PLC_Adapter_Register, Convert.ToInt16(4));
                    lb_adapter_status.Text = "已合上";
                    // current_step++;
                    // do_main_steps();
                    Manual_Adjust();
                }
            }
        }

        #region CA410 操作
        private bool ca410_zerocalibration()
        {
            if (ca410_zerocalibrated == false)
            {
                com_CA410_zerocalibrate = Serial_Class.get_serial_port_CA410();
                com_CA410_zerocalibrate.DataReceived +=
                   new System.IO.Ports.SerialDataReceivedEventHandler(com_CA410_zerocalibrate_DataReceived);
                try
                {
                    com_CA410_zerocalibrate.Open();
                    addmemo("ca410串口打开成功");
                }
                catch (Exception)
                {

                    addmemo("ca410串口打开失败");
                    return false;
                }

                ca410_zerocalibration_dosteps();
            }
            else
            {
                addmemo("已进行初始设置和校零检测");
                autoreset_manual_adjust.Set();
            }
            return true;
        }

        string ca410_command = "";
        string ca410_reply = "";
        private void com_CA410_zerocalibrate_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            timer_ca410_timeout.Enabled = false;
            int n = com_CA410_zerocalibrate.BytesToRead;
            byte[] buf = new byte[n];
            com_CA410_zerocalibrate.Read(buf, 0, n);

            //触发外部处理接收消息事件
            ca410_reply = System.Text.Encoding.Default.GetString(buf);

            this.BeginInvoke(new EventHandler(delegate
            {
                addmemo("ca410 返回信息：" + ca410_reply);
                if (ca410_reply.IndexOf("OK00") == -1)
                {
                    fail_info = "ca410 校零失败";
                    addmemo(fail_info);
                    TestStop();
                }
                else
                {
                    //执行下一步
                    ca410_zero_event.Set();
                }
            }));
        }

        AutoResetEvent ca410_zero_event = new AutoResetEvent(false);
        private bool ca410_zerocalibration_dosteps()
        {
            Task.Run(
                () =>
                {
                    com_CA410_zerocalibrate.WriteLine("COM,1");       //发起连接
                   addmemo("COM,1:ca410发起连接");
                    ca410_zero_event.WaitOne();

                    com_CA410_zerocalibrate.WriteLine("MDS,0");  //选择x,y,Lv模式，设置成功返回：OK00
                   addmemo("MDS,0:ca410选择x,y,Lv模式");
                    ca410_zero_event.WaitOne();

                    com_CA410_zerocalibrate.WriteLine("MCH," + config_json.CA410_TestChannel);  //选择通道CH1，设置成功返回：OK00
                   addmemo("MCH," + config_json.CA410_TestChannel + ":ca410选择通道" + config_json.CA410_TestChannel);
                    ca410_zero_event.WaitOne();

                    com_CA410_zerocalibrate.WriteLine("STR,23");  //选择通道CH1，设置成功返回：OK00
                    addmemo("查询CA410是否需要校零：STR,23");   //OK00,2 无需校零 
                    ca410_zero_event.WaitOne();

                    if (ca410_reply.IndexOf("OK00,2") > -1) //2代表无需校零
                    {
                        addmemo("无需校零");
                    }
                    else {
                        com_CA410_zerocalibrate.WriteLine("ZRC");    //校零，约3秒，完成时返回：OK00
                        addmemo("ZRC:ca410校零");
                        ca410_zero_event.WaitOne();
                    }


                    ca410_zerocalibrated = true;
                    addmemo("关闭ca410连接...");
                    com_CA410_zerocalibrate.Close();
                    System.Threading.Thread.Sleep(1000);

                    if (com_CA410_zerocalibrate.IsOpen)
                    {
                        addmemo("再次关闭ca410连接...");
                        com_CA410_zerocalibrate.Close();
                    }
                    else
                    {
                        addmemo("关闭ca410连接成功");
                    }

                    addmemo("CA410初始化设置及校零完成");
                    autoreset_manual_adjust.Set();
                }
             );
            return true;
        }

        #endregion

        #region 打开TV通讯串口:bool tv_init()
        /// <summary>
        /// 打开TV通讯串口
        /// </summary>
        /// <returns></returns>
        private bool tv_init()
        {
            if (Com_TV_inited == true)
            {
                autoreset_manual_adjust.Set();
                return true;
            }
            com_TV = Serial_Class.get_serial_port_TV();
            com_TV.DataReceived += Com_TV_DataReceived;
            if (com_TV.IsOpen == false)
            {
                try
                {
                    com_TV.Open();
                    Com_TV_inited = true;
                    autoreset_manual_adjust.Set();
                    addmemo("电视串口打开成功");
                }
                catch (Exception ex)
                {
                    addmemo("电视串口打开失败：" + ex.Message);
                    return false;
                }
            }
            return true;
        }

        #endregion

        private void button3_Click(object sender, EventArgs e)
        {
            Get_TV_Type();
            Get_TV_SN();
            if (tb_sn.Text.Length < 2)
            {
                addmemo("无SN");
            }
        }

        private void btn_manual_Click(object sender, EventArgs e)
        {
            if (btn_start_pressed == false)
            {
                addmemo("等待初始化及ca410校零");
                btn_start_Click(null, null);
                System.Threading.Thread.Sleep(8000);
            }
            timer_plc.Enabled = false;
            lb_workmode.Text = "手动";
            // TestBegin();
        }

        void TestBegin()
        {
            com_TV_BeginDataRec = true;
           if (config_json.PLC_Used) light_green_on();
            data = new class_Haier_wb_data();
            data.ERROR_CODE = "";
            data.ERROR_SPOT = "";

            tb_mesreply.Text = "";
           
            lb_result.Text = "调试中";
            adapter_on_try_times = 0;
            tbmemo.Text = "";
            com_CA410_BeginDataRec = true;
            current_step = 0;
            addmemo("测试软件版本："+SOFT_VER.Text);
           
            addmemo("开始测试");
            progressBar1.Value = 0;
            starttime = DateTime.Now;
           // lb_result.BackColor = Color.Blue;
            lb_result.ForeColor = Color.Blue;
            lb_result.Text = "测试中";
            TestTimeTimer.Enabled = true;
            Timer_TestTimeOut.Enabled = true;
            fail_info = "";

            lb_coolrealx.Text = lb_coolrealy.Text = lb_coolrgb.Text = "";
            lb_warmrealx.Text = lb_warmrealy.Text = lb_warmrgb.Text = "";
            lb_standrealx.Text = lb_standrealy.Text = lb_standrgb.Text = "";
        }

        bool autoresetevent_result = false;
        private void tb_sn_KeyDown(object sender, KeyEventArgs e)
        {
            com_TV_BeginDataRec = true;
            if (e.KeyCode == Keys.Enter)
            {
                lb_workmode.Text = "手动";
                Task.Run(
              () =>
              {
                  config_json.PLC_Used = false;
                  ca410_zerocalibration();
                  autoresetevent_result= autoreset_manual_adjust.WaitOne(10000);
                  if (!autoresetevent_result) {
                      addmemo("ca410初始化及校零超时10s！");
                      return;
                  }

                  tv_init();
                  autoresetevent_result = autoreset_manual_adjust.WaitOne(5000);
                  if (!autoresetevent_result)
                  {
                      addmemo("电视打开串口超时5s！");
                      return;
                  }

                  fail_times = 0;
                  TestBegin();
                  Manual_Adjust();
              });
            }
        }


        bool tv_replay_timeout = false;
        AutoResetEvent autoreset_manual_adjust = new AutoResetEvent(false);
        string color = "";
        //todo 手动调试
        void Manual_Adjust()
        {
            addmemo("发送切DTV指令");
            adjusting = false;
            tv_commmand = CMD.DTV;
            tv_send_command();   //Com_TV_DataReceived
            tv_replay_timeout = autoreset_manual_adjust.WaitOne(3000);
            if (!tv_replay_timeout)
            {
                addmemo("TV 响应超时");
                return;
            }

            addmemo("");
            addmemo("设置白场80%亮度");
            adjusting = false;
            tv_commmand = CMD.White80;
            tv_send_command();   //Com_TV_DataReceived
            tv_replay_timeout= autoreset_manual_adjust.WaitOne(3000);
            if (!tv_replay_timeout) {
                addmemo("TV 响应超时");
                return;
            }

            addmemo("");

           addmemo("设置冷色温");
            adjusting = false;//发送指令到tv收到响应后会调用dosteps
            tv_commmand = CMD.SetCoolTemp;
            tv_send_command();
            tv_replay_timeout = autoreset_manual_adjust.WaitOne(3000);
            if (!tv_replay_timeout)
            {
                addmemo("TV 响应超时");
                return;
            }

            addmemo("");
            addmemo("发送冷色温预设值");
            adjusting = false;//发送指令到tv收到响应后会调用dosteps
            tv_commmand = CMD.SET_USR_RGB_GAIN;
            RealRGain = config_json.colortemp1r;
            RealGGain = config_json.colortemp1g;
            RealBGain = config_json.colortemp1b;
            EditRealRGain.Text = RealRGain.ToString();
            EditRealGGain.Text = RealGGain.ToString();
            EditRealBGain.Text = RealBGain.ToString();
            addmemo(EditRealRGain.Text + "," + EditRealGGain.Text + "," + EditRealBGain.Text);
            tv_commmand[3] = Convert.ToByte(RealRGain / 256);
            tv_commmand[4] = Convert.ToByte(RealRGain % 256);
            tv_commmand[5] = Convert.ToByte(RealGGain / 256);
            tv_commmand[6] = Convert.ToByte(RealGGain % 256);
            tv_commmand[7] = Convert.ToByte(RealBGain / 256);
            tv_commmand[8] = Convert.ToByte(RealBGain % 256);
            tv_send_command();
            tv_replay_timeout = autoreset_manual_adjust.WaitOne(3000);
            if (!tv_replay_timeout)
            {
                addmemo("TV 响应超时");
                return;
            }

            addmemo("");
            addmemo("调整冷色温");
            color = "cool";
            adjusting = true;
            destinx = Convert.ToSingle(tb_coolx.Text);
            destiny = Convert.ToSingle(tb_cooly.Text);
            destinx_min = destinx - Convert.ToSingle(tb_offx.Text);
            destinx_max = destinx + Convert.ToSingle(tb_offx.Text);
            destiny_min = destiny - Convert.ToSingle(tb_offy.Text);
            destiny_max = destiny + Convert.ToSingle(tb_offy.Text);
            addmemo("调试目标值x：" + destinx.ToString() + " y:" + destiny.ToString() + " 允许偏差：" + tb_offx.Text);
            Testxyt();
            tv_replay_timeout = autoreset_manual_adjust.WaitOne(20000);
            if (!tv_replay_timeout)
            {
                addmemo("调试超时20S");
                return;
            }

            addmemo("");
            addmemo("设置暖色温");
            adjusting = false;//发送指令到tv收到响应后会调用dosteps
            tv_commmand = CMD.SetWarmTemp;
            tv_send_command();
            tv_replay_timeout = autoreset_manual_adjust.WaitOne(3000);
            if (!tv_replay_timeout)
            {
                addmemo("TV 响应超时");
                return;
            }

            addmemo("");
            addmemo("发送暖色温预设值");
            adjusting = false;//发送指令到tv收到响应后会调用dosteps
            tv_commmand = CMD.SET_USR_RGB_GAIN;
            RealRGain = config_json.colortemp3r;
            RealGGain = config_json.colortemp3g;
            RealBGain = config_json.colortemp3b;
            EditRealRGain.Text = RealRGain.ToString();
            EditRealGGain.Text = RealGGain.ToString();
            EditRealBGain.Text = RealBGain.ToString();
            addmemo(EditRealRGain.Text + "," + EditRealGGain.Text + "," + EditRealBGain.Text);
            tv_commmand[3] = Convert.ToByte(RealRGain / 256);
            tv_commmand[4] = Convert.ToByte(RealRGain % 256);
            tv_commmand[5] = Convert.ToByte(RealGGain / 256);
            tv_commmand[6] = Convert.ToByte(RealGGain % 256);
            tv_commmand[7] = Convert.ToByte(RealBGain / 256);
            tv_commmand[8] = Convert.ToByte(RealBGain % 256);
            tv_send_command();
            tv_replay_timeout = autoreset_manual_adjust.WaitOne(3000);
            if (!tv_replay_timeout)
            {
                addmemo("TV 响应超时");
                return;
            }

            addmemo("");
            addmemo("调整暖色温");
            color = "warm";
            adjusting = true;
            destinx = Convert.ToSingle(tb_warmx.Text);
            destiny = Convert.ToSingle(tb_warmy.Text);
            destinx_min = destinx - Convert.ToSingle(tb_offx.Text);
            destinx_max = destinx + Convert.ToSingle(tb_offx.Text);
            destiny_min = destiny - Convert.ToSingle(tb_offy.Text);
            destiny_max = destiny + Convert.ToSingle(tb_offy.Text);
            addmemo("调试目标值x：" + destinx.ToString() + " y:" + destiny.ToString() + " 允许偏差：" + tb_offx.Text);
            Testxyt();
            tv_replay_timeout = autoreset_manual_adjust.WaitOne(20000);
            if (!tv_replay_timeout)
            {
                addmemo("调试超时20S");
                return;
            }

            addmemo("");
            addmemo("设置标准色温");
            adjusting = false;//发送指令到tv收到响应后会调用dosteps
            tv_commmand = CMD.SetStandardTemp;
            tv_send_command();
            tv_replay_timeout = autoreset_manual_adjust.WaitOne(3000);
            if (!tv_replay_timeout)
            {
                addmemo("TV 响应超时3S");
                return;
            }

            addmemo("");
            addmemo("发送标准色温预设值");
            adjusting = false;//发送指令到tv收到响应后会调用dosteps
            tv_commmand = CMD.SET_USR_RGB_GAIN;
            RealRGain = config_json.colortemp2r;
            RealGGain = config_json.colortemp2g;
            RealBGain = config_json.colortemp2b;
            EditRealRGain.Text = RealRGain.ToString();
            EditRealGGain.Text = RealGGain.ToString();
            EditRealBGain.Text = RealBGain.ToString();
            addmemo(EditRealRGain.Text + "," + EditRealGGain.Text + "," + EditRealBGain.Text);
            tv_commmand[3] = Convert.ToByte(RealRGain / 256);
            tv_commmand[4] = Convert.ToByte(RealRGain % 256);
            tv_commmand[5] = Convert.ToByte(RealGGain / 256);
            tv_commmand[6] = Convert.ToByte(RealGGain % 256);
            tv_commmand[7] = Convert.ToByte(RealBGain / 256);
            tv_commmand[8] = Convert.ToByte(RealBGain % 256);
            tv_send_command();
            tv_replay_timeout = autoreset_manual_adjust.WaitOne(3000);
            if (!tv_replay_timeout)
            {
                addmemo("TV 响应超时3S");
                return;
            }

            addmemo("");
            addmemo("调整标准色温");
            color = "stand";
            adjusting = true;
            destinx = Convert.ToSingle(tb_standx.Text);
            destiny = Convert.ToSingle(tb_standy.Text);
            destinx_min = destinx - Convert.ToSingle(tb_offx.Text);
            destinx_max = destinx + Convert.ToSingle(tb_offx.Text);
            destiny_min = destiny - Convert.ToSingle(tb_offy.Text);
            destiny_max = destiny + Convert.ToSingle(tb_offy.Text);
            addmemo("调试目标值x：" + destinx.ToString() + " y:" + destiny.ToString() + " 允许偏差：" + tb_offx.Text);
            Testxyt();
            tv_replay_timeout = autoreset_manual_adjust.WaitOne(20000);
            if (!tv_replay_timeout)
            {
                addmemo("调试超时20S");
                return;
            }

            addmemo("SendToMes");
            //保存到本地数据库
            TestTimeTimer.Enabled = false;
            Timer_TestTimeOut.Enabled = false;
            lb_result.ForeColor = Color.Green;
            lb_result.Text = "OK";
            data.testdate = DateTime.Now;
            TestOK();
        }
        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 ab = new AboutBox1();
            ab.Show();
        }
        string fail_info = "";
        #region 停止测试:StopTest()
        /// <summary>
        /// 停止测试
        /// </summary>
        private void TestStop()
        {
            addmemo("测试已停止");
            TestTimeTimer.Enabled = false;
            if (config_json.PLC_Used)
            {
                light_red_on();
                timer_plc.Enabled = false;
                btn_start.Enabled = true;
                //btn_stop.Enabled = false;

             
                adapter_off();
                try
                {
                    HslCommunication.OperateResult resut = PLC.ConnectClose();
                    if (resut.IsSuccess)
                    {
                        addmemo("PLC断开连接");
                    }
                }
                catch { }
                if (manual_stopped == true)
                {
                    addmemo("测试已人工停止");
                }
                else
                {
                    MessageBox.Show("测试已停止：" + fail_info, ",等待人工处理");
                }
            }
        }

        #endregion

        int ComCount = 0;

　       /// <summary>
        /// 显示调试时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerTestTime_Tick(object sender, EventArgs e)
        {
            CalTime();
        }

        #region 调试超时:imerTest_Tick()
        /// <summary>
        /// 显示调试超时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_TestTimeOut_Tick(object sender, EventArgs e)
        {
            Timer_TestTimeOut.Enabled = false;
         //126   TimerTVCom.Enabled = false;
            TestTimeTimer.Enabled = false;
            CalTime();
            StaticTextResult.Text = "调试超时";

          
            //PLC.Write(config_json.PLC_Control_Register,Convert.ToInt16(3));
            lb_result.ForeColor = Color.Red;
            lb_result.Text = "NG";
            addmemo("调试超时");
           // fail_times++;
            //BPHTS_001 与TV通讯失败
            //BPHTS_002 调试超时
            //BPHTS_003 调试超限
            //BPHTS_004 Normal 调试失败
            //BPHTS_005 Warm 调试失败
            //BPHTS_006 Cool 调试失败

            data.ERROR_CODE = lb_workstationid.Text + "-002";
            TestNG();

            //PLC.Write(config_json.PLC_Control_Register, Convert.ToInt16(3));

            //timer_plc.Enabled = true;
        }
        #endregion

        bool manual_stopped = false;

        private void btn_stop_Click(object sender, EventArgs e)
        {
            manual_stopped = true;
            lb_workmode.Text = "停止";
            TestStop();
            if (config_json.PLC_Used) light_yellow_on();
        }

        public string logfile { get; private set; }
        public bool ca410_zerocalibrated { get; private set; }
        public SerialPort com_CA410_zerocalibrate { get; private set; }
        public int ca410_zerocalibration_dostep { get; private set; }
        public bool plc_connnected { get; private set; }
        public string PLC_LetTVPass_Register { get; private set; }
        public string PLC_Control_Register { get; private set; }
        public string PLC_Light_Register { get; private set; }
        public string PLC_Light_YELLOW { get; private set; }
        public string PLC_Light_GREEN { get; private set; }
        public string PLC_Light_RED { get; private set; }

        public int fail_times = 0;
        public bool test_stopped = false;  //测试是否停止标志 true 停止 false 继续

        int first_pass_num = 0; //一次测试通过
        int pass_num = 0;     //测试通过数量，包括重测
        int ng_num = 0;       //fail 数量
        int faulttest_num = 0;  //误测数量


        string logdir = "d:\\日志\\白平衡\\";
        /// <summary>
        /// savetolog() 保存日志
        /// </summary>
        /// <param name="result"></param>
        void savetolog()
        {
            addmemo("保存日志");
            if (tb_sn.Text == "") return;
            string dir = logdir + DateTime.Now.ToString("yyyyMMdd") + "\\" + lb_result.Text + "\\";

            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(dir);
            if (di.Exists == false) di.Create();
            string filename = tb_sn.Text + "_" + starttime.ToString("HHmmss") + ".txt";
            string path = dir + "\\" + filename;
            if (!System.IO.File.Exists(path))
            {
                System.IO.FileStream stream = System.IO.File.Create(path);
                stream.Close();
                stream.Dispose();
            }
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(path, true))
            {
                writer.WriteLine(tbmemo.Text);
                writer.Close();
            }
            
        }

        private void cb_retryafterfail_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pLC测试ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form_PLC formplc = new Form_PLC();
            formplc.Show();
        }

        private void 红外测试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (com_IR.IsOpen) com_IR.Close();
            Form_IR_test fir = new Form_IR_test();
            fir.ShowDialog();
        }

        private void tV测试ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (com_TV.IsOpen) com_TV.Close();
            if (com_CA410.IsOpen) com_CA410.Close();
            Form_TV_Communication_Test ftt = new Form_TV_Communication_Test();
            ftt.ShowDialog();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_sendtomes_Click(object sender, EventArgs e)
        {
            //todo sendtomes
            string json = SendDataToMes.Data_To_Json(data);
            addmemo("发送到MES:" + json);  //显示发送的数据
            data.mesreply = SendDataToMes.SendData(json);
            if (data.mesreply.IndexOf("message") == -1)
            {
                addmemo("MES未响应，再次重发...");
                //mes send error Retry
                System.Threading.Thread.Sleep(3000);
                data.mesreply = SendDataToMes.SendData(json);
            }
            if (data.mesreply.IndexOf("message") == -1)
            {
                //mes send error Retry
                addmemo("MES未响应，再次重发...");
                System.Threading.Thread.Sleep(3000);
                data.mesreply = SendDataToMes.SendData(json);
            }
            if (data.mesreply.IndexOf("message") == -1)
            {
                fail_info = "发送数据到MES失败3次";
                addmemo(fail_info);
                TestStop();
                return;
            }
            addmemo("MES回复:" + data.mesreply);  //发送到MES
            tb_mesreply.Text = tb_sn.Text + ":" + data.mesreply;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(config_json.RStepLen.ToString());
        }

        private void btn_manualafterfail_Click(object sender, EventArgs e)
        {
            test_stopped = false;
            addmemo("开始进行白平衡调整");
            fail_times = 3;
            // do_main_steps();
            Manual_Adjust();
        }


        #region 加一行显示：addmemo(string memo)

        private void addmemo(string memo)
        {
            try
            {
                string txt = DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss.fff] ") + memo + Environment.NewLine;
                tbmemo.AppendText(txt);
                tbmemo.ScrollToCaret();
                System.IO.StreamWriter sw2 = new System.IO.StreamWriter(logfile, true);
                sw2.Write(txt);
                sw2.Close();
            }
            catch { }
        }

        private void timer_ca410_timeout_Tick(object sender, EventArgs e)
        {
            addmemo("ca410校零响应超时，请检查连线。");
            timer_ca410_timeout.Enabled = false;
        }

        public string command=  "";
        private void EditStanx_TextChanged(object sender, EventArgs e)
        {
        }

        private void lb_adapter_status_Click(object sender, EventArgs e)
        {
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void 测试数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Mysql_wb fm = new Form_Mysql_wb();
            fm.Show();
        }

        private void 生产统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_tongji_wb ftw = new Form_tongji_wb();
            ftw.Show();
        }
        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
        #endregion


        #region 下压、松开夹具:btn_down_Click();btn_up_Click();
        /// <summary>
        /// 下压夹具
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_down_Click(object sender, EventArgs e)
        {
            if (config_json.PLC_Used)
            {
                PLC.Write(config_json.PLC_Adapter_Register, Convert.ToInt16(5));
                addmemo("松开夹具（PLC写入：" + config_json.PLC_Adapter_Register + "=5)");
            }
        }

        private void btn_up_Click(object sender, EventArgs e)
        {
            if (config_json.PLC_Used)
            {
                PLC.Write(config_json.PLC_Adapter_Register, Convert.ToInt16(4));
                addmemo("伸出夹具（PLC写入：" + config_json.PLC_Adapter_Register + "=4)");
            }
        }
        #endregion

        #region 人工放行:btn_manualpass_Click()
        /// <summary>
        /// 人工放行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_manualpass_Click(object sender, EventArgs e)
        {
            //let_tvpass();
            tb_sn.Text = "";
            Clear_SN();
           // TestStop();
            lb_result.Text = "等待中";
          //  lb_result.BackColor = Color.Blue;
            lb_result.ForeColor = Color.White;
            addmemo("人工放行");
            PLC.Write(config_json.PLC_Adapter_Register, Convert.ToInt16(5));
            System.Threading.Thread.Sleep(500);
            PLC.Write(config_json.PLC_LetTVPass_Register, Convert.ToInt16(1));
            addmemo("握手信号清零");
            PLC.Write(config_json.PLC_StartTest_Register, Convert.ToInt16(0));
            timer_plc.Enabled = true;
        }
        #endregion

        private void tb_type_TextChanged(object sender, EventArgs e)
        {
            if (lb_workmode.Text != "自动") {
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


                jsonObj["TV_Type"] = tb_type.Text;
               
                string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
                System.IO.File.WriteAllText(config_json.config_file_path, output);
            }
        }

        #region timer_start_Tick()
        /// <summary>
        /// 点击开始测试按钮，开始测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_start_Tick(object sender, EventArgs e)
        {
            timer_start.Enabled = false;
            btn_start_Click(null, null);
        }

        private void 使用手册ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void timer8S_Tick(object sender, EventArgs e)
        {
            timer8S.Enabled = false;
           
            //每500ms刷新一次当前PLC的值
            if (config_json.PLC_Used)
            {
                if (lb_workmode.Text=="自动")
                addmemo("开始检测5000");
                timer_plc.Enabled = true;
            }
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
                    returnStr += bytes[i].ToString("X2")+" ";
                }
            }
            return returnStr;
        }
        #endregion

        #region 菜单:ToolStripMenuItem_Click
        private void 数据库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        #endregion
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (com_CA410.IsOpen) com_CA410.Close();
        }

        #region PLC 操作
        /// <summary>
        /// 亮绿灯
        /// </summary>
        void light_green_on()
        {
            if (config_json.PLC_Used)
            {
                if (plc_connnected == false) plc_connect();
                PLC.Write(config_json.PLC_Light_Register, Convert.ToInt16(config_json.PLC_Light_GREEN));
            }
            addmemo("亮绿灯(PLC写入：" + config_json. PLC_Light_Register + "=" + config_json.PLC_Light_GREEN + ")");
        }
        /// <summary>
        /// todo 亮红灯
        /// </summary>
        void light_red_on()
        {
            if (config_json.PLC_Used)
            {
                if (plc_connnected == false) plc_connect();
                addmemo("亮红灯（PLC写入：" + config_json.PLC_Light_Register + "=" + config_json.PLC_Light_RED + ")");
                PLC.Write(config_json.PLC_Light_Register, Convert.ToInt16(config_json.PLC_Light_RED));
            }
        }
        /// <summary>
        /// 亮黄灯
        /// </summary>
        void light_yellow_on()
        {
            if (config_json.PLC_Used)
            {
                if (plc_connnected == false) plc_connect();
                addmemo("亮黄灯(PLC写入：" + config_json.PLC_Light_Register + "=" + config_json.PLC_Light_YELLOW + ")");
                PLC.Write(config_json.PLC_Light_Register, Convert.ToInt16(config_json.PLC_Light_YELLOW));
            }
        }
        /// <summary>
        /// 放行电视
        /// </summary>
        private void tv_letpass()
        {
            if (config_json.PLC_Used)
            {
                adapter_off();
                System.Threading.Thread.Sleep(500);
                addmemo("TV 放行(PLC写入：" + config_json.PLC_LetTVPass_Register + "=" + 1.ToString() + ")");
                PLC.Write(config_json.PLC_LetTVPass_Register, Convert.ToInt16(1));
            }
        }

        int adapter_on_try_times = 0;
        System.Timers.Timer timer_check_adapter_is_on;
      bool adapter_is_on = false;  //此变量已使用
        private void timer_check_adapter_is_on_Tick(object sender, ElapsedEventArgs e)
        {
            timer_check_adapter_is_on.Enabled = false;
            if (plc_read(config_json.PLC_Adapter_Register) == "1")
            {
                adapter_on_try_times = 0;
                adapter_is_on = true;
                addmemo("夹具已合上");
                lb_adapter_status.Text = "已合上";
                // do_main_steps();
                Manual_Adjust();
            }
            else
            {

                if (adapter_on_try_times == 10)
                {
                    fail_info = "夹具未合上，10次检测仍失败";
                    addmemo(fail_info);
                    TestStop();
                    return;
                }

                adapter_on_try_times++;
                addmemo("plc 4099="+plc_read(config_json.PLC_Adapter_Register) +"夹具未合上，1秒后重试");
                timer_check_adapter_is_on.Enabled = true;
            }
        }

        private void cA410校零ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addmemo("手动校零");
            ca410_zerocalibrated = false;
            ca410_zerocalibration();
        }

        private void tb_sn_TextChanged(object sender, EventArgs e)
        {

        }

        private void 软件注册ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_SoftRegister fsr = new Form_SoftRegister();
            fsr.ShowDialog();
        }

        string adapter_value = "";
        System.Timers.Timer timer_check_adapter_is_off;
        int adapter_off_try_times = 0;
        public bool adapter_is_off = true;

        /// <summary>
        /// 松连线夹具
        /// </summary>
        private void adapter_off()
        {
            //4099 5
            if (config_json.PLC_Used)
            {
                if (plc_read(config_json.PLC_Adapter_Register) == "2" || plc_read(config_json.PLC_Adapter_Register) == "0")
                {
                    adapter_off_try_times = 0;
                    adapter_is_on = false;
                    addmemo("夹具已收回");
                    lb_adapter_status.Text = "已收回";
                }
                else {
                    adapter_off_try_times = 0;
                    PLC.Write(config_json.PLC_Adapter_Register, Convert.ToInt16(5));
                    addmemo("收回夹具(PLC写入：" + config_json.PLC_Adapter_Register + "=5)");
                    timer_check_adapter_is_off.Enabled = true;
                }

            }
        }

        private void timer500_check_adapter_is_off_Tick(object sender, ElapsedEventArgs e)
        {
            timer_check_adapter_is_off.Enabled = false;

            adapter_value = plc_read(config_json.PLC_Adapter_Register);

            if (adapter_value == "2" || adapter_value == "0")
            {
                adapter_off_try_times = 0;
                adapter_is_on = false;
                addmemo("夹具已收回");
                lb_adapter_status.Text = "已收回";
            }
            else
            {
                if (adapter_off_try_times == 10)
                {
                    fail_info = "夹具收回未到位，10检测仍失败";
                    addmemo(fail_info);
                    //TestStop();
                    return;
                }
                adapter_off_try_times++;
                addmemo("夹具收回未到位，0.5秒后重试:" + config_json.PLC_Adapter_Register+"="+ adapter_value);
                timer_check_adapter_is_off.Enabled = true;
            }
        }

        string plc_read(string register)
        {
            HslCommunication.OperateResult<byte[]> read = PLC.Read(register, 1);
            if (read.IsSuccess)
            {
                short value1 = PLC.ByteTransform.TransInt16(read.Content, 0);
                return value1.ToString();
            }
            else
            {
                return "";
            }
        }

        bool plc_connect()
        {
            if (plc_connnected == false)
            {
                HslCommunication.OperateResult resut = PLC.ConnectServer();
                if (resut.IsSuccess)
                {
                    plc_connnected = true;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        #endregion
    }
}

// 3696800000004C
// 3696800000004C