using System;
using System.Windows.Forms;

namespace Test_Automation.admin
{
    public partial class Form_admin : Form
    {
        public Form_admin()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private MySql.Data.MySqlClient.MySqlConnection conn;
        MySql.Data.MySqlClient.MySqlDataAdapter mysql_da_operater;
        System.Data.DataSet dataset;

        private void Form_admin_Load(object sender, EventArgs e)
        {
            config_json.config_json_readall();
            dataset = new System.Data.DataSet();
            ts1.Text = config_json.login_name;
            conn = config_json.get_mysqlconn();
            datagrid_operater_load();
            datagrid_technician_load();
        }

        void datagrid_operater_load()
        {
            mysql_da_operater = new MySql.Data.MySqlClient.MySqlDataAdapter("SELECT * FROM `user_operater`", conn);

            try
            {
                conn.Open();
             
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

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataset.HasChanges())
            {
                try
                {
                    MySql.Data.MySqlClient.MySqlCommandBuilder commondbuilder = new MySql.Data.MySqlClient.MySqlCommandBuilder(mysql_da_operater);
                    mysql_da_operater.Update(dataset.Tables["table1"]);
                    dataset.Tables["table1"].AcceptChanges();
                    MessageBox.Show("数据已保存");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("数据保存出错：" + ex.Message);
                }
            }
        }

        MySql.Data.MySqlClient.MySqlDataAdapter mysql_da_technician;
        void datagrid_technician_load()
        {
            mysql_da_technician = new MySql.Data.MySqlClient.MySqlDataAdapter("SELECT * FROM `user_technician`", conn);

            try
            {
                conn.Open();
            
                mysql_da_technician.Fill(dataset, "table2");
                System.Data.DataTable dtable;
                dtable = dataset.Tables["table2"];
                dataGridView2.DataSource = dtable;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据打开出错:" + ex.Message);
            }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataset.HasChanges())
            {
                try
                {
                    MySql.Data.MySqlClient.MySqlCommandBuilder commondbuilder = new MySql.Data.MySqlClient.MySqlCommandBuilder(mysql_da_technician);
                    mysql_da_technician.Update(dataset.Tables["table2"]);
                    dataset.Tables["table2"].AcceptChanges();
                    MessageBox.Show("数据已保存");
                }
                catch (Exception ex){
                    MessageBox.Show("数据保存出错："+ex.Message);
                }
            }
        }

        private void Form_admin_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                try
                {
                    string query = "update user_admin set pass=@pass where code=@code";//向数据库服务器发送指令
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@code", config_json.login_code);
                    cmd.Parameters.AddWithValue("@pass", textBox1.Text);
                    int i= cmd.ExecuteNonQuery();
                    if (i ==1)
                    {
                        MessageBox.Show("密码修改成功");
                    }
                    else
                    {
                        MessageBox.Show("密码修改失败");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("密码修改失败："+ex.Message);
                }
                conn.Close();
            }
            catch
            {
                MessageBox.Show( "数据库连接失败");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form_UserLoginLog fuser = new Form_UserLoginLog();
            fuser.ShowDialog();
        }
    }
}
