using System;
using System.Windows.Forms;

namespace Test_Automation
{
    public partial class Form_Login : Form
    {
        public Form_Login()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void Form_Login_Load(object sender, EventArgs e)
        {
            SOFT_VER.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            config_json.config_json_readall();
            if (config_json.login_remember)
            {
                cb_remember.Checked = true;
                textBox1.Text = config_json.login_code;
                textBox2.Text = config_json.login_pass;
            }

            string result = Class_Mysql.check_mysql();
            if (result != "OK")
            { MessageBox.Show(result);
                ts1.Text = "数据库无法连接！";
                return;
            }
            check_config_file();
            update_database();

            Register_Check();
        }
        bool Register_Check()
        {
            int res = Class_SoftRegister.InitRegedit();

            if (res == 0)
            {
                return true;
            }
            if (res == 1)
            {
                MessageBox.Show("软件尚未注册，请注册软件！");
            }
            if (res == 2)
            {
                MessageBox.Show("注册信息有误,请重新注册！");
                Form_SoftRegister f = new Form_SoftRegister();
                f.ShowDialog();
                this.Close();
            }
            if (res == 3) //软件已过期
            {
                MessageBox.Show("软件已过期，请注册！");
                Form_SoftRegister f = new Form_SoftRegister();
                f.ShowDialog();
                this.Close();
            }
            if (res >= 100 && res < 131)
            {
                MessageBox.Show("软件剩余天数：" + ((int)res - 100).ToString());
                // this.Close();
            }
            return false;
        }
        private void update_database()
        {
            if (Class_Mysql.check_table_column_isexist(config_json.mysql_testdata_table, "operator") == false)
            {
                Class_Mysql.add_column(config_json.mysql_testdata_table, "operator");
            }
        }

        void check_config_file()
        {
            if (System.IO.File.Exists(config_json.config_file_path)==false)
            {
                config_json.config_json_generate_default();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cb_login_changed)
            {
                if (cb_remember.Checked)
                {
                    config_json.save("login_remember", "true");
                    config_json.save("login_code", textBox1.Text);
                    config_json.save("login_pass", textBox2.Text);
                }
                else
                {
                    config_json.save("login_remember", "false");
                }
            }
            string result;
           // 
            config_json.login_name = textBox1.Text;
            switch (comboBox1.Text) {
                case "操作员":
                    result = Class_Mysql.login_operater(textBox1.Text, textBox2.Text);
                    if (result == "OK")
                    {
                        config_json.login_code = textBox1.Text;
                        config_json.login_id=   Class_Mysql.add_login_login("操作员登录", textBox1.Text);
                        config_json.login_datetime = DateTime.Now;
                        this.Visible = false;
                        Form_Main fm = new Form_Main();
                        fm.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("登录失败:"+ result);
                    }
                    break;
                case "工艺员":
                    result = Class_Mysql.login_technician(textBox1.Text, textBox2.Text);
                    if (result == "OK")
                    {
                        config_json.login_code = textBox1.Text;
                        config_json.login_id = Class_Mysql.add_login_login("工艺员登录", textBox1.Text);
                        config_json.login_datetime = DateTime.Now;
                        this.Visible = false;
                        var fm = new Setup.Form_Setup();
                        fm.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("登录失败:" + result);
                    }
                    break;
                case "超级管理员":
                    result = Class_Mysql.login_admin(textBox1.Text, textBox2.Text);
                    if (result == "OK")
                    {
                        config_json.login_code = textBox1.Text;
                        config_json.login_id = Class_Mysql.add_login_login("超级管理员登录", textBox1.Text);
                        config_json.login_datetime = DateTime.Now;
                        this.Visible = false;
                        var fm = new admin.Form_admin();
                        fm.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("登录失败:" + result);
                    }
                    break;
            }
          
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                button1_Click(null, null);
            }
        }

        private const int WM_HOTKEY = 0x312; //窗口消息：热键
        private const int WM_CREATE = 0x1; //窗口消息：创建
        private const int WM_DESTROY = 0x2; //窗口消息：销毁

        private const int HotKeyID = 1; //热键ID（自定义）

        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, KeyModifiers fsModifiers, System.Windows.Forms.Keys vk);

        /// <summary>
        /// 注销热键
        /// </summary>
        /// <param name="hWnd">要取消热键的窗口的句柄</param>
        /// <param name="id">要取消热键的ID</param>
        /// <returns></returns>
        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        /// <summary>
        /// 辅助键名称。
        /// Alt, Ctrl, Shift, WindowsKey
        /// </summary>
        [Flags()]
        public enum KeyModifiers { None = 0, Alt = 1, Ctrl = 2, Shift = 4, WindowsKey = 8 }

        /// <summary>
        /// 注册热键
        /// </summary>
        /// <param name="hwnd">窗口句柄</param>
        /// <param name="hotKey_id">热键ID</param>
        /// <param name="keyModifiers">组合键</param>
        /// <param name="key">热键</param>
        public static string RegHotKey(IntPtr hwnd, int hotKeyId, KeyModifiers keyModifiers, System.Windows.Forms.Keys key)
        {
            if (!RegisterHotKey(hwnd, hotKeyId, keyModifiers, key))
            {
                int errorCode = System.Runtime.InteropServices.Marshal.GetLastWin32Error();
                if (errorCode == 1409)
                {
                    return "热键被占用 ！";
                }
                else
                {
                    return "注册热键失败！错误代码：" + errorCode;
                }
            }
            return "";
        }

        /// <summary>
        /// 注销热键
        /// </summary>
        /// <param name="hwnd">窗口句柄</param>
        /// <param name="hotKey_id">热键ID</param>
        public static void UnRegHotKey(IntPtr hwnd, int hotKeyId)
        {
            //注销指定的热键
            UnregisterHotKey(hwnd, hotKeyId);
        }

        protected override void WndProc(ref Message msg)
        {
            base.WndProc(ref msg);
            switch (msg.Msg)
            {
                case WM_HOTKEY: //窗口消息：热键
                    int tmpWParam = msg.WParam.ToInt32();
                    if (tmpWParam == HotKeyID)
                    {
                        //System.Windows.Forms.SendKeys.Send("^v");
                        //MessageBox.Show("F7按下");
                        //按下热键后要执行的代码
                        //button3.Visible = true;
                        //MessageBox.Show("Hot Key Pressed!");
                        Form_Main f = new Form_Main();
                        f.ShowDialog();
                    }
                    break;
                case WM_CREATE: //窗口消息：创建 下面使用F6作热键
                    RegHotKey(this.Handle, HotKeyID, KeyModifiers.None, Keys.F6);
                    break;
                case WM_DESTROY: //窗口消息：销毁
                    UnRegHotKey(this.Handle, HotKeyID); //销毁热键
                    break;
                default:
                    break;
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (Class_Mysql.check_table_column_isexist(config_json.mysql_testdata_table, "operator") == false)
            {
                Class_Mysql.add_column(config_json.mysql_testdata_table, "operator");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           MessageBox.Show( Class_Mysql.check_table_is_exist("user_operater"));

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Class_Mysql.check_table_is_exist("user_operater2"));
        }
        bool cb_login_changed = false;
        private void cb_remember_CheckedChanged(object sender, EventArgs e)
        {
            cb_login_changed = true;
        }
    }
}
