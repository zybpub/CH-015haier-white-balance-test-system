using System;

namespace Test_Automation
{
    class class_Haier_wb_data
    {
       public string WORKSTATIONID { get; internal set; }
        public string SOFT_VER { get; internal set; }
        public string MO { get; set; }
        public string SN { get; set; }
        public string RESULT { get; set; }

        public string ERROR_CODE = "";       //错误代码
        public string ERROR_SPOT = "";   //错误点

        public string prex { get; set; }
        public string prey { get; set; }
        public string pret { get; set; }

        public string coolx { get; set; }
        public string cooly { get; set; }
        public string coolr { get; set; }
        public string coolg { get; set; }
        public string coolb { get; set; }

        public string standx { get; set; }
        public string standy { get; set; }
        public string standr { get; set; }
        public string standg { get; set; }
        public string standb { get; set; }

        public string warmx { get; set; }
        public string warmy { get; set; }
        public string warmr { get; set; }
        public string warmg { get; set; }
        public string warmb { get; set; }


        public string lastx { get; set; }
        public string lasty { get; set; }
        public string lastt { get; set; }

        public string uploaddatetime { get; set; }
        public string memo { get; set; }
        public string mesreply { get; set; }
        public DateTime testdate { get; internal set; }
   
        public string testseconds { get; internal set; }
      

    }
}
