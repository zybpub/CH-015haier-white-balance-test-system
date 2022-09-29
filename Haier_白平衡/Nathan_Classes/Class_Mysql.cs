//V1.0

using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Test_Automation
{
    class Class_Mysql
    { 
        public static MySql.Data.MySqlClient.MySqlConnection conn =
             new MySql.Data.MySqlClient.MySqlConnection(
                 "Database=" + config_json.mysql_database_name + ";" +
                 "Data Source=" + config_json.Mysql_IP + ";User Id=" + config_json.Mysql_User + ";Password=" + config_json.Mysql_Pass + ";charset=utf8;");

        public Class_Mysql()
        {
        }
       
        public static string Exexute_Sql(string sql)
        {
            string result = "OK";
            conn.Open();
              MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            conn.Close();
            return result;
        }

        public static string Exexute_Sql2Str(string sql)
        {
            string result = "";
            conn.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
            MySql.Data.MySqlClient.MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                result = dr[0].ToString();
            }

            conn.Close();
            return result;
        }
        public static string check_mysql()
        {
            string result = "OK";
            try
            {
                // 判断默认用户名和密码能否正常连接数据库
                conn.Open();
                conn.Close();
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Access denied") > -1)
                {
                    //password incorrect,set to destin password  
                    //set password =password('')
                    result = Class_Mysql.create_password();  //在默认密码无法连接到数据库的情况下，认为密码为空，装密码改为默认密码
                    //change pass failed
                    if (result != "OK") //更改为默认密码出错
                    {
                        return "密码有误或原密码不为空（创建密码失败，原密码必须为空）";
                    }
                }
            }
                
            try
            {
                if (create_database() != "OK")
                {
                    return "连接数据库失败，请检查是否已安装wampserver并且已启动服务！";
                }
            }
            catch (Exception exx)
            {
                return exx.Message;
            }

            try
            {
                //检查各表是否存在，不存在则进行创建
                if (create_testdata_table_haier() == "OK") { } else { result = "创建测试数据表失败"; }
                if (create_tongji_table() == "OK") { } else { result = "创建统计表失败"; }
                if (!check_table_is_exist(config_json.mysql_database_name, "user_admin")) { create_user_admin(); }
                if (!check_table_is_exist(config_json.mysql_database_name, "user_operater")) { create_user_operator(); }
                if (!check_table_is_exist(config_json.mysql_database_name, "user_technician")) { create_user_technician(); }
                create_user_user_login_log();
            }
            catch (Exception exx)
            {
                result = exx.Message;
            }
            return result;
        }

        public static bool check_table_column_isexist(string tablename, string columnname) {
            bool b = false;
            conn.Open();
            string query = @"SELECT count(*) FROM information_schema.COLUMNS WHERE table_name = '"+config_json.mysql_testdata_table + "' AND column_name = 'operator'";
            //string query = @"SELECT count(*) FROM information_schema.COLUMNS WHERE table_name = 'jyny_testdataV3' AND column_name = 'operator'";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
            MySql.Data.MySqlClient.MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr[0].ToString() == "1") b = true;
            }
          
            conn.Close();
            return b;

        }
        public static string add_column(string tablename, string columnname)
        {
            string result = "OK";
            string query = "ALTER TABLE `" + tablename + "` ADD `" + columnname + "` VARCHAR(50) NULL";
            conn.Open();
            //create command and assign the query and connection from the constructor
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);

            //Execute command
            try
            {
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            conn.Close();
            return result;
        }
        public static bool check_table_is_exist(string database_name, string table_name)
        {
            bool b = false;

            //MySql.Data.MySqlClient.MySqlConnection conn =
            //new MySql.Data.MySqlClient.MySqlConnection(
            //    "Database=" + config_json.mysql_database_name + ";" +
            //    "Data Source=" + config_json.Mysql_IP + ";User Id=" + config_json.Mysql_User + ";Password=" + config_json.Mysql_Pass + ";charset=utf8;");

            conn.Open();
            string query = "select `TABLE_NAME` from `INFORMATION_SCHEMA`.`TABLES` where `TABLE_SCHEMA`= '"+ database_name + "' and `TABLE_NAME`= '"+ table_name+"'";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
            MySql.Data.MySqlClient.MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr[0].ToString()== table_name)
                b = true;
            }
            else
            {
                b = false;
            }
            conn.Close();
            return b;
        }

        public static string check_table_is_exist( string table_name)
        {
            string str = "";
            conn.Open();
            string query = "select `TABLE_NAME` from `INFORMATION_SCHEMA`.`TABLES` where `TABLE_SCHEMA`= '" + config_json.mysql_database_name+ "' and `TABLE_NAME`= '" + table_name + "'";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
            MySql.Data.MySqlClient.MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                str = dr[0].ToString();
            }
            conn.Close();
            return str;
        }

        public static string create_user_admin()
        {
            string result = "OK";
            string query = @"CREATE TABLE  IF NOT EXISTS `user_admin` (
                             `id` int(5) NOT NULL AUTO_INCREMENT,
                            `code` varchar(50) NOT NULL,
                             `name` varchar(50) NOT NULL,
                             `pass` varchar(50) NOT NULL,
                             `memo` varchar(50) DEFAULT NULL,
                             PRIMARY KEY (`id`),
                             UNIQUE KEY `code` (`code`)
                            ) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COMMENT='超级管理员';

                            INSERT INTO `user_admin` (`code`,`name`, `pass`, `memo`) VALUES
                            ('admin','张三', 'admin', '超级管理员');";
            conn.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
            }
            conn.Close();
            return result;
        }

        public static string create_user_operator()
        {
            string result = "OK";
            string query = @"CREATE TABLE  IF NOT EXISTS `user_operater` (
                             `id` int(5) NOT NULL AUTO_INCREMENT,
                            `code` varchar(50) NOT NULL,
                             `name` varchar(50) NOT NULL,
                             `pass` varchar(50) NOT NULL,
                             `memo` varchar(50) DEFAULT NULL,
                             PRIMARY KEY (`id`),
                             UNIQUE KEY `code` (`code`)
                            ) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COMMENT='操作工';

                            INSERT INTO `user_operater` (`code`, `name`, `pass`, `memo`) VALUES
                            ('op','张三', 'op', '操作工');";
            conn.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
            }
            conn.Close();
            return result;
        }

        public static string create_user_technician()
        {
            string result = "OK";
            string query = @"
                            CREATE TABLE  IF NOT EXISTS `user_technician` (
                             `id` int(5) NOT NULL AUTO_INCREMENT,
                             `code` varchar(50) NOT NULL,
                             `name` varchar(50) NOT NULL,
                             `pass` varchar(50) NOT NULL,
                             `memo` varchar(50) DEFAULT NULL,
                             PRIMARY KEY (`id`),
                             UNIQUE KEY `code` (`code`)
                            ) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COMMENT='工艺（修改设置）';

                            INSERT INTO `user_technician` (`code`,`name`, `pass`, `memo`) VALUES
                            ('gy','张三', 'gy', '工艺');";
            conn.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
            }
            conn.Close();
            return result;
        }
        public static string create_user_user_login_log()
        {
            string result = "OK";
            string query = @" CREATE TABLE   IF NOT EXISTS  `user_login_log` ( 
                                `id` INT NOT NULL AUTO_INCREMENT , 
                                `login_user_type` VARCHAR(50) NOT NULL , 
                                `login_name` VARCHAR(50) NOT NULL , 
                                `login_datetime` DATETIME NOT NULL , 
                                 `logout_datetime` datetime DEFAULT NULL,
                                 `online_hours` decimal(5,2) DEFAULT NULL,

                                PRIMARY KEY (`id`)) ENGINE = MyISAM; ";
            conn.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
            }
            conn.Close();
            return result;
        }
        public static string add_logout_log(string id,string hours)
        {
            return Exexute_Sql2Str("update user_login_log set logout_datetime=now(),online_hours="+hours+" where id="+id);
        }
        public static string add_login_login(string user_type, string name)
        {
            return Exexute_Sql2Str("insert into user_login_log(login_user_type, login_name, login_datetime) values('"+ user_type + "', '" + name + "', now()); select last_insert_id();");
        }
        public static string login_operater(string code, string pass)
        {
            string b = "";
            try
            {
                conn.Open();
                try
                {
                    string query = "select * from user_operater where code=@code and pass=@pass";//向数据库服务器发送指令
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@code", code);
                    cmd.Parameters.AddWithValue("@pass", pass);
                    MySql.Data.MySqlClient.MySqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        b = "OK";
                    }
                    else
                    {
                        b = "用户名或密码有误";
                    }
                }
                catch(Exception ex)
                {
                    b = "数据读取失败:"+ex.Message;
                }
                conn.Close();
            }
            catch
            {
                b = "数据库连接失败";
            }
            return b;
        }
        public static string login_technician(string code, string pass)
        {
            string b = "";
            try
            {
                conn.Open();
                try
                {
                    string query = "select * from user_technician where code=@code and pass=@pass";//向数据库服务器发送指令
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@code", code);
                    cmd.Parameters.AddWithValue("@pass", pass);
                    MySql.Data.MySqlClient.MySqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        b = "OK";
                    }
                    else
                    {
                        b = "用户名或密码有误";
                    }
                }
                catch (Exception ex)
                {
                    b = "数据读取失败:" + ex.Message;
                }
                conn.Close();
            }
            catch
            {
                b = "数据库连接失败";
            }
            return b;
        }
        public static string login_admin(string code, string pass)
        {
            string b = "";
            try
            {
                conn.Open();
                try
                {
                    string query = "select * from user_admin where code=@code and pass=@pass";//向数据库服务器发送指令
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@code", code);
                    cmd.Parameters.AddWithValue("@pass", pass);
                    MySql.Data.MySqlClient.MySqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        b = "OK";
                    }
                    else
                    {
                        b = "用户名或密码有误";
                    }
                }
                catch (Exception ex)
                {
                    b = "数据读取失败:" + ex.Message;
                }
                conn.Close();
            }
            catch
            {
                b = "数据库连接失败";
            }
            return b;
        }

        public static string check_and_start_mysql_service()
        {
            string result = "";

            System.ServiceProcess.ServiceController service = new System.ServiceProcess.ServiceController();//创建服务控制对象

            string[] services = config_json.start_services.Split(',');
            foreach (string str_service in services)
            {
                service.ServiceName = str_service;//启动apache服务
                                                  //判断当前服务状态
                if (service == null)
                { result += str_service + "服务不存在 "; }
                else
                {
                    try
                    {
                        if (service.Status == System.ServiceProcess.ServiceControllerStatus.Running)
                        {
                            result += str_service + "服务原来已是启动状态 ";

                        }
                        else if (service.Status == System.ServiceProcess.ServiceControllerStatus.Stopped)
                        {
                            service.Start();// 启动服务
                            service.WaitForStatus(System.ServiceProcess.ServiceControllerStatus.Running);
                            result += str_service + "服务启动成功 ";
                        }
                    }
                    catch (Exception ex)
                    {
                        result += ex.Message;
                    }
                }

            }
            return result;
        }



        public static string create_password()
        {
            MySql.Data.MySqlClient.MySqlConnection con =
               new MySql.Data.MySqlClient.MySqlConnection(
                   //"Database=" + config_json.mysql_database_name + ";"+
                   "Data Source=" + config_json.Mysql_IP + ";User Id=" + config_json.Mysql_User + ";Password=;charset=utf8;");
            try
            {
                con.Open();
                //set password =password('')
                string query = "set password =password('" + config_json.Mysql_Pass + "');";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                return "初始密码不为空，无法更改密码！";
            }
            return "OK";
        }
        public static string create_database()
        {
            MySql.Data.MySqlClient.MySqlConnection con =
               new MySql.Data.MySqlClient.MySqlConnection("Database=mysql;Data Source=" +
               config_json.Mysql_IP + ";User Id=" + config_json.Mysql_User + ";Password=" + config_json.Mysql_Pass + ";charset=utf8;");
            try
            {
                con.Open();

                string query = "CREATE DATABASE IF NOT EXISTS " + config_json.mysql_database_name + " DEFAULT CHARACTER SET utf8 DEFAULT COLLATE utf8_general_ci";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                return "OK";
            }
            catch (Exception ex)
            { return ex.Message; }
        }

        public static string create_tongji_table()
        {
            MySql.Data.MySqlClient.MySqlConnection con =
               new MySql.Data.MySqlClient.MySqlConnection("Database=" + config_json.mysql_database_name + ";Data Source=" +
               config_json.Mysql_IP + ";User Id=" + config_json.Mysql_User + ";Password=" + config_json.Mysql_Pass + ";charset=utf8;");
            con.Open();

            string query = "CREATE TABLE IF NOT EXISTS `" + config_json.mysql_yielddata_table + @"` (  
                            `id` int(11) NOT NULL AUTO_INCREMENT,  
                            `测试日期` varchar(100) DEFAULT NULL,  
                            `一次直通数量` int(11) DEFAULT '0',  
                            `一次直通率` varchar(100) DEFAULT '0',  
                            `通过数量` int(11) DEFAULT '0', 
                            `通过率` varchar(100) DEFAULT '0',  
                            `误测数量` int(11) DEFAULT '0',  
                            `误测率` varchar(100) DEFAULT '0',  
                            `不合格数量` int(11) DEFAULT '0',  
                            `不合格率` varchar(100) DEFAULT '0',  
                            `备注` varchar(500) DEFAULT '0', 
                            PRIMARY KEY (`id`)) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COMMENT='测试统计'";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            return "OK";
        }

        public static int[] get_produce_data() {
            int[] result = new int[4];
            MySql.Data.MySqlClient.MySqlConnection con =
              new MySql.Data.MySqlClient.MySqlConnection("Database=" + config_json.mysql_database_name + ";Data Source=" +
              config_json.Mysql_IP + ";User Id=" + config_json.Mysql_User + ";Password=" + config_json.Mysql_Pass + ";charset=utf8;");
            try
            {
                con.Open();
                try
                {
                    string query = "select * from " + config_json.mysql_yielddata_table + " where testdate='" + DateTime.Now.ToString("yyyy-MM-dd") + "'";//向数据库服务器发送指令
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, con);
                    MySql.Data.MySqlClient.MySqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        result[0] = Convert.ToInt16(dr["first_pass_num"]);
                        result[1] = Convert.ToInt16(dr["pass_num"]);
                        result[2] = Convert.ToInt16(dr["faulttest_num"]);
                        result[3] = Convert.ToInt16(dr["ng_num"]);
                    }
                    else
                    {
                        con.Close();
                        con.Open();
                        string insertstr = "insert into " + config_json.mysql_yielddata_table + " (`testdate`) values('" + DateTime.Now.ToString("yyyy-MM-dd") + "')";//插入今天日期并加载默认值0
                        MySql.Data.MySqlClient.MySqlCommand insertcmd = new MySql.Data.MySqlClient.MySqlCommand(insertstr, con);
                        insertcmd.ExecuteNonQuery();
                        result[0] = result[1] = result[2] = result[3] = 0;
                    }
                    dr.Close();
                    con.Close();
                    return result;
                }
                catch
                {
                    return null;
                }
            }
            catch  {
                return null;
            }
        }

        public static int[] get_produce_data_cn()
        {
            int[] result = new int[4];
            MySql.Data.MySqlClient.MySqlConnection con =
              new MySql.Data.MySqlClient.MySqlConnection("Database=" + config_json.mysql_database_name + ";Data Source=" +
              config_json.Mysql_IP + ";User Id=" + config_json.Mysql_User + ";Password=" + config_json.Mysql_Pass + ";charset=utf8;");
            try
            {
                con.Open();
                try
                {
                    string query = "select * from " + config_json.mysql_yielddata_table + " where 测试日期='" + DateTime.Now.ToString("yyyy-MM-dd") + "'";//向数据库服务器发送指令
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, con);
                    MySql.Data.MySqlClient.MySqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        result[0] = Convert.ToInt16(dr["一次直通数量"]);
                        result[1] = Convert.ToInt16(dr["通过数量"]);
                        result[2] = Convert.ToInt16(dr["误测数量"]);
                        result[3] = Convert.ToInt16(dr["不合格数量"]);
                    }
                    else
                    {
                        con.Close();
                        con.Open();
                        string insertstr = "insert into " + config_json.mysql_yielddata_table + " (`测试日期`) values('" + DateTime.Now.ToString("yyyy-MM-dd") + "')";//插入今天日期并加载默认值0
                        MySql.Data.MySqlClient.MySqlCommand insertcmd = new MySql.Data.MySqlClient.MySqlCommand(insertstr, con);
                        insertcmd.ExecuteNonQuery();
                        result[0] = result[1] = result[2] = result[3] = 0;
                    }
                    dr.Close();
                    con.Close();
                    return result;
                }
                catch
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }
        public static string create_testdata_table_jyny()
        {
            string result = "";
            conn.Open();
            string query = "CREATE TABLE if not exists `"+config_json.mysql_testdata_table+@"` (
                              `id` int(11) NOT NULL AUTO_INCREMENT,
                              `operator` varchar(100) DEFAULT NULL,
                              `testdatetime` varchar(200) DEFAULT NULL COMMENT '测试时间',
                              `MO` varchar(100) DEFAULT NULL,
                              `SN` varchar(200) DEFAULT NULL COMMENT '产品序列号',
                              `SOFT_VER` varchar(20) NOT NULL,
                              `ACW_RESULT` varchar(50) DEFAULT NULL,
                              `ACW_VOL` varchar(20) DEFAULT NULL,
                              `ACW_CUR` varchar(20) DEFAULT NULL,
                              `ACW_TIME` varchar(20) DEFAULT NULL,
                              `IR_RESULT` varchar(50) DEFAULT NULL,
                              `IR_VOL` varchar(20) DEFAULT NULL,
                              `IR_RES` varchar(20) DEFAULT NULL,
                              `IR_TIME` varchar(20) DEFAULT NULL,
                              `TEST_TIMES` varchar(10) DEFAULT NULL,
                              `RESULT` varchar(200) DEFAULT NULL COMMENT '测试结果',
                              `uploaddatetime` datetime DEFAULT NULL COMMENT '上传服务器时间',
                              `memo` varchar(200) DEFAULT NULL COMMENT '备注',
                              `mesreply` varchar(500) DEFAULT NULL,
                              `ERROR_CODE` varchar(100) DEFAULT NULL,
                              `ERROR_SPOT` varchar(100) DEFAULT NULL,
                              `WORKSTATIONID` varchar(100) DEFAULT NULL,
                              PRIMARY KEY(`id`)
                             ) ENGINE = InnoDB DEFAULT CHARSET = utf8";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
            try
            {
                cmd.ExecuteNonQuery();
                result = "OK";
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            conn.Close();
            return result;
        }

        public static string create_testdata_table_haier()
        {
            string result = "";
            conn.Open();
            string query = "CREATE TABLE if not exists `" + config_json.mysql_testdata_table + @"` (
                              `id` int(11) NOT NULL AUTO_INCREMENT,
                            `MO` varchar(100) DEFAULT NULL,
                            `SN` varchar(100) NOT NULL,
                            `WORKSTATIONID` varchar(100) NOT NULL,
                            `SOFT_VER` varchar(100) NOT NULL,
                            `ERROR_CODE` varchar(100) DEFAULT NULL,
                            `ERROR_SPOT` varchar(100) DEFAULT NULL,
                            `testdate` varchar(50) DEFAULT NULL,
                            `testseconds` varchar(50) DEFAULT NULL,
                            `prex` varchar(50) DEFAULT NULL,
                            `prey` varchar(50) DEFAULT NULL,
                            `pret` varchar(50) DEFAULT NULL,
                            `coolx` varchar(50) DEFAULT NULL,
                            `cooly` varchar(50) DEFAULT NULL,
                            `coolr` varchar(50) DEFAULT NULL,
                            `coolg` varchar(50) DEFAULT NULL,
                            `coolb` varchar(50) DEFAULT NULL,
                            `standx` varchar(50) DEFAULT NULL,
                            `standy` varchar(50) DEFAULT NULL,
                            `standr` varchar(50) DEFAULT NULL,
                            `standg` varchar(50) DEFAULT NULL,
                            `standb` varchar(50) DEFAULT NULL,
                            `warmx` varchar(50) DEFAULT NULL,
                            `warmy` varchar(50) DEFAULT NULL,
                            `warmr` varchar(50) DEFAULT NULL,
                            `warmg` varchar(50) DEFAULT NULL,
                            `warmb` varchar(50) DEFAULT NULL,
                            `lastx` varchar(50) DEFAULT NULL,
                            `lasty` varchar(50) DEFAULT NULL,
                            `lastt` varchar(50) DEFAULT NULL,
                            `result` varchar(50) DEFAULT NULL,
                            `mesreply` varchar(200) DEFAULT NULL,
                            `memo` varchar(200) DEFAULT NULL,
                            PRIMARY KEY (`id`)
                        ) ENGINE=MyISAM AUTO_INCREMENT=59 DEFAULT CHARSET=utf8";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
            try
            {
                cmd.ExecuteNonQuery();
                result = "OK";
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            conn.Close();
            return result;
        }
        public static string create_testdata_table2()
        {
            MySql.Data.MySqlClient.MySqlConnection con =
              new MySql.Data.MySqlClient.MySqlConnection("Database=" + config_json.mysql_database_name + ";Data Source=" +
              config_json.Mysql_IP + ";User Id=" + config_json.Mysql_User + ";Password=" + config_json.Mysql_Pass + ";charset=utf8;");
            con.Open();
            string query =" CREATE TABLE `" + config_json.mysql_testdata_table + @"` ( `id` int(11)  AUTO_INCREMENT, 
                            `MO` varchar(100) DEFAULT NULL COMMENT '模组型号', 
                            `SN` varchar(100)  DEFAULT 0 COMMENT '序列号',  
                            `result` varchar(100)  NULL COMMENT 'OK/TSNG/TXNG', 
                            `isgood` bit(1)  NULL COMMENT '0不良品 1良品', 
                            `mesreply` varchar(200) DEFAULT NULL, 
                            `WORKSTATIONID` varchar(100)  DEFAULT 0 COMMENT '工作站ID', 
                            `SOFT_VER` varchar(100)  DEFAULT 0 COMMENT '软件版本', 
                            `ERROR_CODE` varchar(100)  DEFAULT 0 COMMENT '错误代码', 
                            `ERROR_SPOT` varchar(100) DEFAULT NULL COMMENT '错误点', 
                            `testdate` datetime DEFAULT NULL COMMENT '调试时间', 
                            `testseconds` int(11) DEFAULT NULL COMMENT '调试时长',
                            `test_times` int(11) DEFAULT NULL, 
                            `memo` varchar(500) DEFAULT NULL, 
                            PRIMARY KEY (`id`) ) ENGINE=MyISAM AUTO_INCREMENT=13 DEFAULT CHARSET=utf8";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, con);
            try
            {
                cmd.ExecuteNonQuery();
                con.Close();
                return "OK";
            }
            catch
            {
                con.Close();
                return "FAIL";
            }
        }
        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                conn.Open();
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

        //Count statement
        public int Count()
        {
            string query = "SELECT Count(*) FROM tableinfo";
            int Count = -1;

            //Open Connection
            if (this.OpenConnection() == true)
            {
                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(query, conn);

                //ExecuteScalar will return one value
                Count = int.Parse(cmd.ExecuteScalar() + "");

                //close Connection
               // this.CloseConnection();

                return Count;
            }
            else
            {
                return Count;
            }
        }
  
    }
}















