using System;
using System.Windows.Forms;

namespace Test_Automation
{
    public partial class Form_colortemp_set : Form
    {
        public Form_colortemp_set()
        {
            InitializeComponent();
        }

        private void Form_colortemp_set_Load(object sender, EventArgs e)
        {
            colortemp1x.Text = config_json.colortemp1x.ToString();
            colortemp1y.Text = config_json.colortemp1y.ToString();

            colortemp2x.Text = config_json.colortemp2x.ToString();
            colortemp2y.Text = config_json.colortemp2y.ToString();

            colortemp3x.Text = config_json.colortemp3x.ToString();
            colortemp3y.Text = config_json.colortemp3y.ToString();

            offx.Text = config_json.offx.ToString();
            offy.Text = config_json.offy.ToString();

            tb_c1_pre_r.Text = config_json.colortemp1r.ToString();
            tb_c1_pre_g.Text = config_json.colortemp1g.ToString();
            tb_c1_pre_b.Text = config_json.colortemp1b.ToString();

            tb_c2_pre_r.Text = config_json.colortemp2r.ToString();
            tb_c2_pre_g.Text = config_json.colortemp2g.ToString();
            tb_c2_pre_b.Text = config_json.colortemp2b.ToString();

            tb_c3_pre_r.Text = config_json.colortemp3r.ToString();
            tb_c3_pre_g.Text = config_json.colortemp3g.ToString();
            tb_c3_pre_b.Text = config_json.colortemp3b.ToString();

            EditRGainMin.Text = config_json.RGainMin.ToString();
            EditRGainMax.Text = config_json.RGainMax.ToString();
            EditBGainMin.Text = config_json.BGainMin.ToString();
            EditBGainMax.Text = config_json.BGainMax.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
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


            jsonObj["colortemp1x"] = colortemp1x.Text;
            jsonObj["colortemp1y"] = colortemp1y.Text;
            jsonObj["colortemp2x"] = colortemp2x.Text;
            jsonObj["colortemp2y"] = colortemp2y.Text;
            jsonObj["colortemp3x"] = colortemp3x.Text;
            jsonObj["colortemp3y"] = colortemp3y.Text;
            jsonObj["Offx"] = offx.Text;
            jsonObj["Offy"] = offx.Text;

            jsonObj["colortemp1r"] = tb_c1_pre_r.Text;
            jsonObj["colortemp1g"] = tb_c1_pre_g.Text;
            jsonObj["colortemp1b"] = tb_c1_pre_b.Text;

            jsonObj["colortemp2r"] = tb_c2_pre_r.Text;
            jsonObj["colortemp2g"] = tb_c2_pre_g.Text;
            jsonObj["colortemp2b"] = tb_c2_pre_b.Text;

            jsonObj["colortemp3r"] = tb_c3_pre_r.Text;
            jsonObj["colortemp3g"] = tb_c3_pre_g.Text;
            jsonObj["colortemp3b"] = tb_c3_pre_b.Text;

            jsonObj["RGainMin"] = EditRGainMin.Text;
            jsonObj["RGainMax"] = EditRGainMax.Text;
            jsonObj["BGainMin"] = EditBGainMin.Text;
            jsonObj["BGainMax"] = EditBGainMax.Text;

            string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
            System.IO.File.WriteAllText(config_json.config_file_path, output);

            //update config content to variant
            config_json.config_json_readall();
            MessageBox.Show("保存成功！");
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
    }
}
