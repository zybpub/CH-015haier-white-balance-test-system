using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Test_Automation
{
    class Mysql_Class
    {
        //方法一：Visual Studio,在 项目(右键)-管理NuGet程序包(N)  然后在浏览里面搜索MySql.Data并进行安装。

        //方法二：安装数据库MySQL时要选中Connector.NET 6.9的安装，将C:\Program Files(x86)\MySQL\Connector.NET 6.9\Assemblies里v4.0或v4.5中的MySql.Data.dll添加到项目的引用。
        //v4.0和v4.5，对应Visual Studio具体项目 属性-应用程序-目标框架 里的.NET Framework的版本号。
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public Mysql_Class()
        {
            Initialize();
        }
        public static bool create_tongji_table() {
            string query;
            query = "CREATE TABLE tongji_haier_wb("
                      +"`id` int(11) NOT NULL AUTO_INCREMENT,"
                     + " `testdate` varchar(100) DEFAULT NULL,"
                     + " `first_pass_num` int(11) DEFAULT '0', "
                    + "  `first_pass_rate` varchar(100) DEFAULT '0', "
                     + " `pass_num` int(11) DEFAULT '0', "
                     + " `pass_rate` varchar(100) DEFAULT '0', "
                     + " `faulttest_num` int(11) DEFAULT '0', "
                     + " `faulttest_rate` varchar(100) DEFAULT '0', "
                     + " `ng_num` int(11) DEFAULT '0', "
                     + " `ng_rate` varchar(100) DEFAULT '0', "
                     + " `memo` varchar(500) DEFAULT '0', "
                     + " PRIMARY KEY(`id`)"
                    + " ) ENGINE = InnoDB AUTO_INCREMENT = 4 DEFAULT CHARSET = utf8 COMMENT = '测试统计'";

            MySql.Data.MySqlClient.MySqlConnection Conn =
               new MySql.Data.MySqlClient.MySqlConnection("Database=" + config_json.mysql_database_name + ";Data Source=" +
               config_json.Mysql_IP + ";User Id=" + config_json.Mysql_User + ";Password=" + config_json.Mysql_Pass + ";charset=utf8");
            Conn.Open();

            //create command and assign the query and connection from the constructor
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SET NAMES 'utf8';", Conn);
            cmd.ExecuteNonQuery();

              
            cmd = new MySql.Data.MySqlClient.MySqlCommand(query, Conn);
            //Execute command
            cmd.ExecuteNonQuery();
            Conn.Close();
           
            return true;
        }

        //Initialize values
        private void Initialize()
        {
            server = config_json.Mysql_IP;
            database = config_json.mysql_database_name;
            uid = config_json.Mysql_User;
            password = config_json.Mysql_Pass;

            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }


        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        //Insert statement
        public void Insert()
        {
            string query = "INSERT INTO tableinfo (id,name, age) VALUES('11','John Smith', '33')";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Backup
        public void Backup()
        {
            try
            {
                DateTime Time = DateTime.Now;
                int year = Time.Year;
                int month = Time.Month;
                int day = Time.Day;
                int hour = Time.Hour;
                int minute = Time.Minute;
                int second = Time.Second;
                int millisecond = Time.Millisecond;

                //Save file to C:\ with the current date as a filename
                string path;
                path = "C:\\" + year + "-" + month + "-" + day + "-" + hour + "-" + minute + "-" + second + "-" + millisecond + ".sql";
                StreamWriter file = new StreamWriter(path);


                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "mysqldump";
                psi.RedirectStandardInput = false;
                psi.RedirectStandardOutput = true;
                psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}", uid, password, server, database);
                psi.UseShellExecute = false;

                Process process = Process.Start(psi);

                string output;
                output = process.StandardOutput.ReadToEnd();
                file.WriteLine(output);
                process.WaitForExit();
                file.Close();
                process.Close();
            }
            catch 
            {
                MessageBox.Show("Error , unable to backup!");
            }
        }

        //Restore
        public void Restore()
        {
            try
            {
                //Read file from C:\
                string path;
                path = "C:\\MySqlBackup.sql";
                StreamReader file = new StreamReader(path);
                string input = file.ReadToEnd();
                file.Close();


                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "mysql";
                psi.RedirectStandardInput = true;
                psi.RedirectStandardOutput = false;
                psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}", uid, password, server, database);
                psi.UseShellExecute = false;


                Process process = Process.Start(psi);
                process.StandardInput.WriteLine(input);
                process.StandardInput.Close();
                process.WaitForExit();
                process.Close();
            }
            catch
            {
                MessageBox.Show("Error , unable to Restore!");
            }
        }
        public static bool create_testdata_table() {
            string create_table = "CREATE TABLE " + config_json.mysql_testdata_table + "(" +
                         "`id` int(11) NOT NULL AUTO_INCREMENT," +
                         "`MO` varchar(100) DEFAULT NULL," +
                         "`SN` varchar(100) NOT NULL," +
                         "`WORKSTATIONID` varchar(100) NOT NULL," +
                         "`SOFT_VER` varchar(100) NOT NULL," +
                        " `ERROR_CODE` varchar(100) DEFAULT NULL," +
                         "`ERROR_SPOT` varchar(100) DEFAULT NULL," +
                         "`testdate` varchar(50) DEFAULT NULL," +
                         "`testseconds` varchar(50) DEFAULT NULL," +
                         "`prex` varchar(50) DEFAULT NULL," +
                         "`prey` varchar(50) DEFAULT NULL," +
                         "`pret` varchar(50) DEFAULT NULL," +
                         "`coolx` varchar(50) DEFAULT NULL," +
                         "`cooly` varchar(50) DEFAULT NULL," +
                         "`coolr` varchar(50) DEFAULT NULL," +
                        " `coolg` varchar(50) DEFAULT NULL," +
                         "`coolb` varchar(50) DEFAULT NULL," +
                         "`standx` varchar(50) DEFAULT NULL," +
                         "`standy` varchar(50) DEFAULT NULL," +
                         "`standr` varchar(50) DEFAULT NULL," +
                        " `standg` varchar(50) DEFAULT NULL," +
                         "`standb` varchar(50) DEFAULT NULL," +
                         "`warmx` varchar(50) DEFAULT NULL," +
                        " `warmy` varchar(50) DEFAULT NULL," +
                         "`warmr` varchar(50) DEFAULT NULL," +
                         "`warmg` varchar(50) DEFAULT NULL," +
                         "`warmb` varchar(50) DEFAULT NULL," +
                        " `lastx` varchar(50) DEFAULT NULL," +
                         "`lasty` varchar(50) DEFAULT NULL," +
                        " `lastt` varchar(50) DEFAULT NULL," +
                        " `result` varchar(50) DEFAULT NULL," +
                         "`mesreply` varchar(200) DEFAULT NULL," +
                         "`memo` varchar(200) DEFAULT NULL," +
                         "PRIMARY KEY(`id`)" +
                        ") ENGINE = MyISAM AUTO_INCREMENT = 59 DEFAULT CHARSET = utf8";
            MySql.Data.MySqlClient.MySqlConnection Conn =
            new MySql.Data.MySqlClient.MySqlConnection("Database=" + config_json.mysql_database_name + ";Data Source=" +
            config_json.Mysql_IP + ";User Id=" + config_json.Mysql_User + ";Password=" + config_json.Mysql_Pass + ";charset=utf8");

            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SET NAMES 'utf8';", Conn);
            cmd.ExecuteNonQuery();

            cmd = new MySql.Data.MySqlClient.MySqlCommand(create_table, Conn);
            //Execute command
            cmd.ExecuteNonQuery();
            return true;
        }

        internal static string  InsertData(class_Haier_wb_data wbdata)
        {
            string query;
            
                query = "insert into "+ config_json.mysql_testdata_table +
                    "(`testdate`,`WORKSTATIONID`,`MO`,`sn`,`result`,"
                    + "`prex`,`prey`,`pret`,"
                    +"`coolx`,`cooly`,`coolr`,`coolg`,`coolb`,"
                    + "`standx`,`standy`,`standr`,`standg`,`standb`,"
                    + "`warmx`,`warmy`,`warmr`,`warmg`,`warmb`,"
                    + "`lastx`,`lasty`,`lastt`,"
                    + "`memo`,`mesreply`,`SOFT_VER`,`testseconds`)"
                    + " values('" 
                    + wbdata.testdate + "','" + wbdata.WORKSTATIONID + "','" + wbdata.MO + "','" + wbdata.SN + "','" + wbdata.RESULT + "','" 
                        + wbdata.prex +"','" + wbdata.prey +"','" + wbdata.pret +"','"
                          + wbdata.coolx +"','" + wbdata.cooly +"','" + wbdata.coolr +"','" + wbdata.coolg +"','" + wbdata.coolb +"','"
                           + wbdata.standx +"','" + wbdata.standy +"','" + wbdata.standr +"','" + wbdata.standg +"','" + wbdata.standb +"','"
                            + wbdata.warmx +"','" + wbdata.warmy +"','" + wbdata.warmr +"','" + wbdata.warmg +"','" + wbdata.warmb +"','"
                             + wbdata.lastx +"','" + wbdata.lastx +"','" + wbdata.lastt + "','"
                                + wbdata.memo + "','" + wbdata.mesreply + "','"+wbdata.SOFT_VER + "','" + wbdata.testseconds + "')";

            MySql.Data.MySqlClient.MySqlConnection Conn =
               new MySql.Data.MySqlClient.MySqlConnection("Database=" + config_json.mysql_database_name + ";Data Source=" +
               config_json.Mysql_IP + ";User Id=" + config_json.Mysql_User + ";Password=" + config_json.Mysql_Pass + ";charset=utf8");
            Conn.Open();

            //create command and assign the query and connection from the constructor
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SET NAMES 'utf8';", Conn);
            cmd.ExecuteNonQuery();

            try
            {
                cmd = new MySql.Data.MySqlClient.MySqlCommand(query, Conn);
                //Execute command
                cmd.ExecuteNonQuery();
                Conn.Close();
            }
            catch {
                create_testdata_table();
                try
                {
                    cmd = new MySql.Data.MySqlClient.MySqlCommand(query, Conn);
                    //Execute command
                    cmd.ExecuteNonQuery();
                    Conn.Close();
                    return "本地数据保存成功";
                }
                catch (Exception ex) {
                    Conn.Close();
                    return "本地数据保存失败：" + query+"\r\n"+ex.Message; }
               
            }
            return "本地数据保存成功";

        }
    }
}















