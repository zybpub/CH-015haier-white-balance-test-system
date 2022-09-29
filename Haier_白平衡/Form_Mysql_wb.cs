using System;
using System.Data;
using System.Windows.Forms;

namespace Test_Automation
{
    public partial class Form_Mysql_wb : Form
    {
        public Form_Mysql_wb()
        {
            InitializeComponent();
        }
        private MySql.Data.MySqlClient.MySqlConnection Conn;

       
        //  string connectionString;
        private void Form_Mysql_Load(object sender, EventArgs e)
        {
            Conn = new MySql.Data.MySqlClient.MySqlConnection("Database=" 
                + config_json.mysql_database_name + ";Data Source=" + config_json.Mysql_IP
                + ";User Id=" + config_json.Mysql_User + ";Password=" + config_json.Mysql_Pass+";charset=utf8");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                Conn = new MySql.Data.MySqlClient.MySqlConnection("Database="
          + config_json.mysql_database_name + ";Data Source=" + config_json.Mysql_IP
          + ";User Id=" + config_json.Mysql_User + ";Password=" + config_json.Mysql_Pass + ";charset=utf8");
                MySql.Data.MySqlClient.MySqlDataAdapter Da = 
                    new MySql.Data.MySqlClient.MySqlDataAdapter("select  * from " + config_json.mysql_testdata_table
                    + " order by id desc limit 0,100", Conn);
                DataSet ds = new DataSet();
                Da.Fill(ds, "wb");
                // 建立DataTable对象(相当于建立前台的虚拟数据库中的数据表)
                DataTable dtable;
                //将数据表tabuser的数据复制到DataTable对象（取数据）
                dtable = ds.Tables["wb"];
                DataRowCollection coldrow;
                coldrow = dtable.Rows;
                dataGridView1.DataSource = dtable;
           
         
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            MySql.Data.MySqlClient.MySqlDataAdapter Da = 
                new MySql.Data.MySqlClient.MySqlDataAdapter("select  * from " + config_json.mysql_testdata_table
                + " order by id", Conn);

            DataSet ds = new DataSet();

            Da.Fill(ds, config_json.mysql_testdata_table);

            // 建立DataTable对象(相当于建立前台的虚拟数据库中的数据表)
            DataTable dtable;
            //将数据表tabuser的数据复制到DataTable对象（取数据）
            dtable = ds.Tables[config_json.mysql_testdata_table];

            //建立DataRowCollection对象(相当于表的行的集合)
            DataRowCollection coldrow;
            //用DataRowCollection对象获取这个数据表的所有数据行
            coldrow = dtable.Rows;

            dataGridView1.DataSource = dtable;
        }

        private void btn_toexcel_Click(object sender, EventArgs e)
        {
            ExportToExcel(dataGridView1);
        }
        public static bool ExportToExcel(DataGridView dgvData)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Execl files (*.xls)|*.xls";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.CreatePrompt = true;
            saveFileDialog.Title = "Export Excel File To";
            DialogResult dr = saveFileDialog.ShowDialog();
            if (dr != DialogResult.OK)
            {
                return false;
            }

            System.IO.Stream myStream;
            myStream = saveFileDialog.OpenFile();
            //StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding("gb2312"));
            System.IO.StreamWriter sw = new System.IO.StreamWriter(myStream, System.Text.Encoding.GetEncoding(-0));
            string str = "";
            try
            {
                //写标题
                for (int i = 0; i < dgvData.ColumnCount; i++)
                {
                    if (i > 0)
                    {
                        str += "\t";
                    }
                    str += dgvData.Columns[i].HeaderText;
                }
                sw.WriteLine(str);
                //写内容
                for (int j = 0; j < dgvData.Rows.Count - 1; j++)
                {
                    string tempStr = "";
                    for (int k = 0; k < dgvData.Columns.Count; k++)
                    {
                        if (k > 0)
                        {
                            tempStr += "\t";
                        }
                        string cellValue = dgvData.Rows[j].Cells[k].Value.ToString();
                        cellValue = cellValue.Replace(" ", "");
                        cellValue = cellValue.Replace("\r", "");
                        cellValue = cellValue.Replace("\n", "");
                        cellValue = cellValue.Replace("\r\n", "");
                        tempStr += cellValue;
                        // tempStr += dgvData.Rows[j].Cells[k].Value.ToString();
                    }

                    sw.WriteLine(tempStr);
                }
                sw.Close();
                myStream.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
            finally
            {
                sw.Close();
                myStream.Close();
            }

            return true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySql.Data.MySqlClient.MySqlDataAdapter Da =
                new MySql.Data.MySqlClient.MySqlDataAdapter("select  * from " + config_json.mysql_testdata_table
                + " where sn='" + textBox1.Text.Trim() + "'", Conn);

            DataSet ds = new DataSet();

            Da.Fill(ds, "gamma");
            DataTable dtable;
            dtable = ds.Tables["gamma"];
            DataRowCollection coldrow;
            coldrow = dtable.Rows;
            dataGridView1.DataSource = dtable;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(config_json.Mysql_IP);
        }
    }
}
