using System;
using System.Windows.Forms;

namespace Test_Automation
{
    public partial class Form_password_change_technician : Form
    {
        public Form_password_change_technician()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void Form_password_change_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //验证原密码
            if (textBox1.Text == Class_Mysql.Exexute_Sql2Str("select pass from user_technician where code='" + config_json.login_code + "'")) {
                //检查新密码是否一致

                if (textBox2.Text == textBox3.Text) {
                    //修改新密码
                    Class_Mysql.Exexute_Sql("update user_technician set pass='" + textBox2.Text+ "' where code='" + config_json.login_code + "'");
                    MessageBox.Show("密码修改成功！");
                }
                else
                {
                    MessageBox.Show("两次输入的新密码不一致！");
                }
            }
            else
            {
                MessageBox.Show("原密码输入不正确！");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
