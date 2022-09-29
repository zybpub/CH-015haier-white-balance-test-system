using System;
using System.Windows.Forms;

namespace Test_Automation
{
    public partial class Form_UserLoginLog : Form
    {
        public Form_UserLoginLog()
        {
            InitializeComponent();
            this.CenterToScreen();
        }
        private MySql.Data.MySqlClient.MySqlConnection conn;
        MySql.Data.MySqlClient.MySqlDataAdapter mysql_da_operater;
        System.Data.DataSet dataset;
        private void Form_UserLoginLog_Load(object sender, EventArgs e)
        {
            config_json.config_json_readall();

            data_load();
        }

        void data_load() {
            conn = config_json.get_mysqlconn();

            mysql_da_operater = new MySql.Data.MySqlClient.MySqlDataAdapter("SELECT * FROM `user_login_log`", conn);

            try
            {
                conn.Open();
                dataset = new System.Data.DataSet();
                mysql_da_operater.Fill(dataset, "table1");
                System.Data.DataTable dtable;
                dtable = dataset.Tables["table1"];
                dataGridView1.DataSource = dtable;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据打开出错:" + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string result = Class_Mysql.Exexute_Sql("delete  from user_login_log");
            if (result == "OK")
            {
                MessageBox.Show("清空成功");
                data_load();
            }
            else
            {
                MessageBox.Show("清空失败：" + result);
            }
        }
    }
}
