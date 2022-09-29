using System;

namespace Test_Automation
{
    class config_json
    {
        public config_json() {
        }
        public static string login_code = "";
        public static dynamic login_pass = "";
        public static dynamic login_remember = false;

        public static string TV_Type = "";
        public static bool CA410_SerialPort_Used =true;
        public static string CA410_SerialPort_PortName = "COM11";           //CA410串口端口号
        public static string CA410_SerialPort_BaudRate = "38400";           //CA410串口波特率
        public static string CA410_SerialPort_DataBits = "7";           //CA410串口数据位
        public static string CA410_SerialPort_StopBits = "1";
        public static string CA410_SerialPort_Parity = "None";
        public static string CA410_TestChannel = "84";
        public static string CA410_Machine_Keywords = "Measuring Instruments";
        public static bool CA410_ZERO_CAL = true;     //是否需要校零

        public static bool TV_Connect_Used = true;
        public static string TV_IP = "192.168.1.100";
        public static string TV_Port = "100";

        public static string TV_SerialPort_PortName = "COM2";           //TV串口端口号
        public static string TV_SerialPort_BaudRate = "115200";           //TV串口波特率
        public static string TV_SerialPort_DataBits = "8";           //TV串口数据位

        public static string TV_SerialPort_StopBits { get; internal set; }
        public static string TV_SerialPort_Parity { get; internal set; }

        public static bool IR_used = false;
        public static string IR_PortName= "COM1";           //IR红外 串口端口号
        public static string IR_BaudRate= "115200";           //IR红外 串口波特率
        public static string IR_DataBits= "8";           //IR红外 串口数据位

        public static bool mysql_used=true;    //是否启用数据库
        public static string Mysql_IP="127.0.0.1";       //Mysql IP 地址
        public static string Mysql_Port="3306";      //Mysql 端口号
        public static string Mysql_User="root";      //Mysql 用户名 需要有写入权限
        public static string Mysql_Pass="jczx";      //Mysql 密码
        public static string mysql_database_name= "jczx_mysql_HaierV3";  //数据库名
        public static string mysql_tongji_table = "tongji_haier_wb";//统计表名 程序中统计仍然使用的是这个表，未更新到tongji_haierV3
        public static string mysql_testdata_table = "haier_wb_dataV3";
        public static string mysql_yielddata_table = "tongji_haierV3"; //统计表名

        public static string ConfigPath = "d:\\软件配置";
        public static string LogPath = "D:\\logs\\";
        public static string config_file_path = "d:\\软件配置\\haier_wb_config.json";

        public static string Workstationid="HC1-BPHTS";
        public static string pass = "QWQ/r3FGnyU=";    //999

        public static bool PLC_Used = true;    //是否启用PLC
        public static string PLC_IP="192.168.1.5";              //PLC IP地址
        public static string PLC_Port = "502";             //PLC 端口 默认：502
        public static string PLC_Station = "1";             //PLC 站号  默认：1
        public static string PLC_StartTest_Register = "5000";   //PLC控制是否测试可以开始 0不测试 1 测试
        public static string PLC_LetTVPass_Register = "5001";
        public static string PLC_Type_Register = "5002";
        public static string PLC_SN_Register = "5022";    //PLC读取sn地址
        public static string PLC_Adapter_Register = "4099";
        public static string PLC_Light_Register = "4119";     //PLC红绿黄灯控制寄存器地址
        public static string PLC_Light_GREEN = "1";
        public static string PLC_Light_RED = "2";
        public static string PLC_Light_YELLOW = "3";
        public static string ShakeHand_OK_Code = "2";  //启动测试信号值


        public static string MES_URL = "http://10.52.88.17:8080/N2/http/interface.ms?model=IntoScgz&method=intoScgzSaveInfo";
        internal static string MES_Abnormal_Keywords = "接口异常";

        public static double colortemp1x = 0.268;
        public static double colortemp1y = 0.274;
        public static int colortemp1r = 120;
        public static int colortemp1g = 128;
        public static int colortemp1b = 118;

        public static double colortemp2x = 0.277;
        public static double colortemp2y = 0.278;
        public static int colortemp2r = 128;
        public static int colortemp2g = 128;
        public static int colortemp2b = 118;

        public static double colortemp3x = 0.313;
        public static double colortemp3y = 0.329;
        public static int colortemp3r = 130;
        public static int colortemp3g = 128;
        public static int colortemp3b = 98;

        public static int RGainMin = 100;
        public static int RGainMax = 145;

        public static int BGainMin = 100;
        public static int BGainMax = 145;
    
        public static double offx =0.004;
        public static double offy = 0.004;
        public static int RStepLen =2;
        public static int BStepLen =2;
        public static int Delay410 = 200;
        public static string myStyle { get; private set; }
        public static string login_id { get; internal set; }
        public static DateTime login_datetime { get; internal set; }
        public static string login_name { get; internal set; }
        public static string form_title = "白平衡自动化调试系统";
        public static string TestTimeOutSeconds { get; internal set; }


        public static bool Adapter_on_check = true;
        public static bool Adapter_off_check = true;

        public static string start_services = "wampapache64,wampmysqld64";

        public static string test_max_seconds = "60";
        public static bool auto_run = false;
        public static bool sendtomes = true;
        public static bool prefailsnotomes = true;
        public static bool stopafterfail = true;
        public static bool retryafterfail = true;
        public static bool lettvpassafterfail_notsendng = true;

        public static MySql.Data.MySqlClient.MySqlConnection get_mysqlconn()
        {
            MySql.Data.MySqlClient.MySqlConnection mySqlConnection =
                   new MySql.Data.MySqlClient.MySqlConnection(
                       "Database=" + config_json.mysql_database_name
                       + ";Data Source=" + config_json.Mysql_IP
                       + ";User Id=" + config_json.Mysql_User
                       + ";Password=" + config_json.Mysql_Pass + ";charset=utf8");
            return mySqlConnection;
        }

        public static bool save(string key,string value) {
            try
            {
                string json = System.IO.File.ReadAllText(config_file_path);
                dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                jsonObj[key] =value;
                string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
                System.IO.File.WriteAllText(config_file_path, output);
                return true;
            }
            catch 
            {
                return false;
            }
        }
        public static bool config_json_generate_default() {
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

            jsonObj["colortemp1x"] = colortemp1x;
            jsonObj["colortemp1y"] = colortemp1y;
            jsonObj["colortemp2x"] = colortemp2x;
            jsonObj["colortemp2y"] = colortemp2y;
            jsonObj["colortemp3x"] = colortemp3x;
            jsonObj["colortemp3y"] = colortemp3y;
            jsonObj["Offx"] = offx;
            jsonObj["Offy"] = offx;

            jsonObj["colortemp1r"] = colortemp1r;
            jsonObj["colortemp1g"] = colortemp1g;
            jsonObj["colortemp1b"] = colortemp1b;

            jsonObj["colortemp2r"] = colortemp2r;
            jsonObj["colortemp2g"] = colortemp2g;
            jsonObj["colortemp2b"] = colortemp2b;

            jsonObj["colortemp3r"] = colortemp3r;
            jsonObj["colortemp3g"] = colortemp3g;
            jsonObj["colortemp3b"] = colortemp3b;

            jsonObj["RGainMin"] = RGainMin;
            jsonObj["RGainMax"] = RGainMax;
            jsonObj["BGainMin"] = BGainMin;
            jsonObj["BGainMax"] = BGainMax;

            jsonObj["CA410_SerialPort_Used"] = CA410_SerialPort_Used;
            jsonObj["CA410_SerialPort_PortName"] = CA410_SerialPort_PortName;

            jsonObj["CA410_TestChannel"] = CA410_TestChannel;
            jsonObj["CA410_Machine_Keywords"] = CA410_Machine_Keywords;

            jsonObj["mysql_used"] = mysql_used;
            jsonObj["Mysql_IP"] = Mysql_IP;
            jsonObj["Mysql_Port"] = Mysql_Port;
            jsonObj["Mysql_User"] = Mysql_User;
            jsonObj["Mysql_Pass"] = Mysql_Pass;
            jsonObj["mysql_database_name"] = mysql_database_name;
            jsonObj["mysql_testdata_table"] = mysql_testdata_table;
            //jsonObj["mysql_yielddata_table"] = mysql_yielddata_table.Text;
            jsonObj["mysql_tongji_table"] = mysql_yielddata_table;

            jsonObj["PLC_Used"] = PLC_Used;
            jsonObj["Adapter_on_check"] = Adapter_on_check;
            jsonObj["Adapter_off_check"] = Adapter_off_check;
            jsonObj["PLC_IP"] = PLC_IP;
            jsonObj["PLC_IP"] = PLC_IP;
            jsonObj["PLC_Port"] = PLC_Port;
            jsonObj["PLC_Station"] = PLC_Station;
            jsonObj["PLC_LetTVPass_Register"] = PLC_LetTVPass_Register;
            jsonObj["PLC_Adapter_Register"] = PLC_Adapter_Register;
            jsonObj["PLC_Light_Register"] = PLC_Light_Register;
            jsonObj["PLC_Light_GREEN"] = PLC_Light_GREEN;
            jsonObj["PLC_Light_RED"] = PLC_Light_RED;
            jsonObj["PLC_Light_YELLOW"] = PLC_Light_YELLOW;
            jsonObj["PLC_Type_Register"] = PLC_Type_Register;
            jsonObj["PLC_SN_Register"] = PLC_SN_Register;
            jsonObj["PLC_StartTest_Register"] = PLC_StartTest_Register;
            jsonObj["ShakeHand_OK_Code"] = ShakeHand_OK_Code;

            jsonObj["TV_Connect_Used"] = TV_Connect_Used;
            jsonObj["TV_IP"] = TV_IP;
            jsonObj["TV_Port"] = TV_Port;
            jsonObj["TV_SerialPort_PortName"] = TV_SerialPort_PortName;
            jsonObj["TV_SerialPort_BaudRate"] = TV_SerialPort_BaudRate;
            jsonObj["TV_SerialPort_DataBits"] = TV_SerialPort_DataBits;
            jsonObj["TV_SerialPort_StopBits"] = TV_SerialPort_StopBits;
            jsonObj["TV_SerialPort_Parity"] = TV_SerialPort_Parity;

            string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
            System.IO.File.WriteAllText(config_json.config_file_path, output);
            return true;
        }
        public static bool config_json_readall()
        {
            System.IO.FileInfo fi = new System.IO.FileInfo(config_file_path);
            if (fi.Exists == false) return false;

           
            System.IO.StreamReader file = System.IO.File.OpenText(config_file_path);
            Newtonsoft.Json.JsonTextReader reader = new Newtonsoft.Json.JsonTextReader(file);
            Newtonsoft.Json.Linq.JObject jsonObject =
                            (Newtonsoft.Json.Linq.JObject)Newtonsoft.Json.Linq.JToken.ReadFrom(reader);

            if (jsonObject["login_code"] != null) login_code = (string)jsonObject["login_code"];
            if (jsonObject["login_pass"] != null) login_pass = (string)jsonObject["login_pass"];
            if (jsonObject["login_remember"] != null) login_remember = (bool)jsonObject["login_remember"];

            if (jsonObject["form_title"] != null) form_title = (string)jsonObject["form_title"];

            if (jsonObject["Workstationid"] != null) Workstationid = (string)jsonObject["Workstationid"];
            if (jsonObject["start_services"] != null) start_services = (string)jsonObject["start_services"];
            if (jsonObject["TV_Type"] != null) TV_Type = (string)jsonObject["TV_Type"];

            if (jsonObject["CA410_SerialPort_PortName"] != null) CA410_SerialPort_PortName = (string)jsonObject["CA410_SerialPort_PortName"];
            if (jsonObject["CA410_SerialPort_BaudRate"] != null) CA410_SerialPort_BaudRate = (string)jsonObject["CA410_SerialPort_BaudRate"];
            if (jsonObject["CA410_SerialPort_DataBits"] != null) CA410_SerialPort_DataBits = (string)jsonObject["CA410_SerialPort_DataBits"];
            if (jsonObject["CA410_TestChannel"] != null) CA410_TestChannel = (string)jsonObject["CA410_TestChannel"];
            if (jsonObject["CA410_ZERO_CAL"] != null) CA410_ZERO_CAL = (bool)jsonObject["CA410_ZERO_CAL"];
            if (jsonObject["Delay410"] != null) Delay410 = (int)jsonObject["Delay410"];
            if (jsonObject["CA410_Machine_Keywords"] != null) CA410_Machine_Keywords = (string)jsonObject["CA410_Machine_Keywords"];
            

            if (jsonObject["TV_Connect_Used"] != null) TV_Connect_Used = (bool)jsonObject["TV_Connect_Used"];
            if (jsonObject["TV_SerialPort_PortName"] != null) TV_SerialPort_PortName = (string)jsonObject["TV_SerialPort_PortName"];
            if (jsonObject["TV_SerialPort_BaudRate"] != null) TV_SerialPort_BaudRate = (string)jsonObject["TV_SerialPort_BaudRate"];
            if (jsonObject["TV_SerialPort_DataBits"] != null) TV_SerialPort_DataBits = (string)jsonObject["TV_SerialPort_DataBits"];

            if (jsonObject["IR_used"] != null) IR_used = (bool)jsonObject["IR_used"];
            if (jsonObject["IR_PortName"] != null) IR_PortName = (string)jsonObject["IR_PortName"];
            if (jsonObject["IR_BaudRate"] != null) IR_BaudRate = (string)jsonObject["IR_BaudRate"];
            if (jsonObject["IR_DataBits"] != null) IR_DataBits = (string)jsonObject["IR_DataBits"];

            
            if (jsonObject["PLC_Used"] != null) PLC_Used = (bool)jsonObject["PLC_Used"];
            if (jsonObject["PLC_IP"] != null) PLC_IP = (string)jsonObject["PLC_IP"];
            if (jsonObject["PLC_Port"] != null) PLC_Port = (string)jsonObject["PLC_Port"];
            if (jsonObject["PLC_Station"] != null) PLC_Station = (string)jsonObject["PLC_Station"];
            if (jsonObject["PLC_LetTVPass_Register"] != null) PLC_LetTVPass_Register = (string)jsonObject["PLC_LetTVPass_Register"];  //产品放行地址
            if (jsonObject["PLC_Adapter_Register"] != null) PLC_Adapter_Register = (string)jsonObject["PLC_Adapter_Register"];
            if (jsonObject["PLC_Light_Register"] != null) PLC_Light_Register = (string)jsonObject["PLC_Light_Register"];
            if (jsonObject["PLC_Light_GREEN"] != null) PLC_Light_GREEN = (string)jsonObject["PLC_Light_GREEN"];
            if (jsonObject["PLC_Light_RED"] != null) PLC_Light_RED = (string)jsonObject["PLC_Light_RED"];
            if (jsonObject["PLC_Light_YELLOW"] != null) PLC_Light_YELLOW = (string)jsonObject["PLC_Light_YELLOW"];
            if (jsonObject["PLC_Type_Register"] != null) PLC_Type_Register = (string)jsonObject["PLC_Type_Register"];
            if (jsonObject["PLC_SN_Register"] != null) PLC_SN_Register = (string)jsonObject["PLC_SN_Register"];
            if (jsonObject["PLC_StartTest_Register"] != null) PLC_StartTest_Register = (string)jsonObject["PLC_StartTest_Register"];
            if (jsonObject["ShakeHand_OK_Code"] != null) ShakeHand_OK_Code = (string)jsonObject["ShakeHand_OK_Code"];

            if (jsonObject["mysql_used"] != null) mysql_used = (bool)jsonObject["mysql_used"];
            if (jsonObject["Mysql_IP"] != null) Mysql_IP = (string)jsonObject["Mysql_IP"];
            if (jsonObject["Mysql_Port"] != null) Mysql_Port = (string)jsonObject["Mysql_Port"];
            if (jsonObject["Mysql_User"] != null) Mysql_User = (string)jsonObject["Mysql_User"];
            if (jsonObject["Mysql_Pass"] != null) Mysql_Pass = (string)jsonObject["Mysql_Pass"];
            if (jsonObject["mysql_database_name"] != null) mysql_database_name = (string)jsonObject["mysql_database_name"];

            if (jsonObject["colortemp1x"] != null) colortemp1x = (double)jsonObject["colortemp1x"];
            if (jsonObject["colortemp1y"] != null) colortemp1y = (double)jsonObject["colortemp1y"];
            if (jsonObject["colortemp1r"] != null) colortemp1r = (int)jsonObject["colortemp1r"];
            if (jsonObject["colortemp1g"] != null) colortemp1g = (int)jsonObject["colortemp1g"];
            if (jsonObject["colortemp1b"] != null) colortemp1b = (int)jsonObject["colortemp1b"];

            if (jsonObject["colortemp2x"] != null) colortemp2x = (double)jsonObject["colortemp2x"];
            if (jsonObject["colortemp2y"] != null) colortemp2y = (double)jsonObject["colortemp2y"];
            if (jsonObject["colortemp2r"] != null) colortemp2r = (int)jsonObject["colortemp2r"];
            if (jsonObject["colortemp2g"] != null) colortemp2g = (int)jsonObject["colortemp2g"];
            if (jsonObject["colortemp2b"] != null) colortemp2b = (int)jsonObject["colortemp2b"];

            if (jsonObject["colortemp3x"] != null) colortemp3x = (double)jsonObject["colortemp3x"];
            if (jsonObject["colortemp3y"] != null) colortemp3y = (double)jsonObject["colortemp3y"];
            if (jsonObject["colortemp3r"] != null) colortemp3r = (int)jsonObject["colortemp3r"];
            if (jsonObject["colortemp3g"] != null) colortemp3g = (int)jsonObject["colortemp3g"];
            if (jsonObject["colortemp3b"] != null) colortemp3b = (int)jsonObject["colortemp3b"];



            if (jsonObject["Offx"] != null) offx = (double)jsonObject["Offx"];
            if (jsonObject["Offy"] != null) offy = (double)jsonObject["Offy"];
            if (jsonObject["RGainMin"] != null) RGainMin = (int)jsonObject["RGainMin"];
            if (jsonObject["RGainMax"] != null) RGainMax = (int)jsonObject["RGainMax"];
            if (jsonObject["BGainMin"] != null) BGainMin = (int)jsonObject["BGainMin"];
            if (jsonObject["BGainMax"] != null) BGainMax = (int)jsonObject["BGainMax"];

            if (jsonObject["RStepLen"] != null) RStepLen = (int)jsonObject["RStepLen"];
            if (jsonObject["BStepLen"] != null) BStepLen = (int)jsonObject["BStepLen"];


            

            if (jsonObject["myStyle"] != null) myStyle = (string)jsonObject["myStyle"];

            if (jsonObject["test_max_seconds"] != null) test_max_seconds = (string)jsonObject["test_max_seconds"];


            if (jsonObject["auto_run"] != null) auto_run = (bool)jsonObject["auto_run"];
            if (jsonObject["sendtomes"] != null) sendtomes = (bool)jsonObject["sendtomes"];
            if (jsonObject["prefailsnotomes"] != null) prefailsnotomes = (bool)jsonObject["prefailsnotomes"];
            if (jsonObject["stopafterfail"] != null) stopafterfail = (bool)jsonObject["stopafterfail"];
            if (jsonObject["retryafterfail"] != null) retryafterfail = (bool)jsonObject["retryafterfail"];
            if (jsonObject["lettvpassafterfail_notsendng"] != null) lettvpassafterfail_notsendng = (bool)jsonObject["lettvpassafterfail_notsendng"];
            if (jsonObject["pass"] != null) pass = (string)jsonObject["pass"];

            if (jsonObject["MES_URL"] != null) MES_URL = (string)jsonObject["MES_URL"];
            if (jsonObject["MES_Abnormal_Keywords"] != null) MES_Abnormal_Keywords = (string)jsonObject["MES_Abnormal_Keywords"];
            
            file.Close();
      
            return true;
        }
        /// <summary>
        /// 读取指定键名的值
        /// </summary>
        /// <param name="key">输入要获取值的键名</param>
        /// <returns></returns>
        public static string config_json_read(string key)
        {
            string result = "";
            try
            {
                System.IO.StreamReader file = System.IO.File.OpenText(config_file_path);
                Newtonsoft.Json.JsonTextReader reader = new Newtonsoft.Json.JsonTextReader(file);
                Newtonsoft.Json.Linq.JObject jsonObject =
                                (Newtonsoft.Json.Linq.JObject)Newtonsoft.Json.Linq.JToken.ReadFrom(reader);
                if (jsonObject[key] != null)
                    result = (string)jsonObject[key];
                file.Close();
            }
            catch { }
            return result;
        }
    }
}
