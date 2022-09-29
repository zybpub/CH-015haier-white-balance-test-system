using System;

namespace Test_Automation
{
    class SendDataToMes
    {
        public static string Data_To_Json(class_Haier_wb_data wb)
            {
                //整理将要提交的数据data
                System.IO.StringWriter sw = new System.IO.StringWriter();
                using (Newtonsoft.Json.JsonWriter writer = new Newtonsoft.Json.JsonTextWriter(sw))
                {
                    writer.Formatting = Newtonsoft.Json.Formatting.Indented;
                    writer.WriteStartObject();

                    writer.WritePropertyName("TESTS");
                    writer.WriteStartArray();

                //cool
                writer.WriteStartObject();
                    writer.WritePropertyName("KEY");
                    writer.WriteValue("coolx");
                    writer.WritePropertyName("VALUE");
                    writer.WriteValue(wb.coolx);
                    writer.WriteEndObject();

                    writer.WriteStartObject();
                    writer.WritePropertyName("KEY");
                    writer.WriteValue("cooly");
                    writer.WritePropertyName("VALUE");
                    writer.WriteValue(wb.cooly);
                    writer.WriteEndObject();
                writer.WriteStartObject();
                writer.WritePropertyName("KEY");
                writer.WriteValue("coolr");
                writer.WritePropertyName("VALUE");
                writer.WriteValue(wb.coolr);
                writer.WriteEndObject();

                writer.WriteStartObject();
                writer.WritePropertyName("KEY");
                writer.WriteValue("coolg");
                writer.WritePropertyName("VALUE");
                writer.WriteValue(wb.coolg);
                writer.WriteEndObject(); writer.WriteStartObject();
                writer.WritePropertyName("KEY");
                writer.WriteValue("coolb");
                writer.WritePropertyName("VALUE");
                writer.WriteValue(wb.coolb);
                writer.WriteEndObject();

                //stand
                writer.WriteStartObject();
                writer.WritePropertyName("KEY");
                writer.WriteValue("standx");
                writer.WritePropertyName("VALUE");
                writer.WriteValue(wb.standx);
                writer.WriteEndObject();

                writer.WriteStartObject();
                writer.WritePropertyName("KEY");
                writer.WriteValue("standy");
                writer.WritePropertyName("VALUE");
                writer.WriteValue(wb.standy);
                writer.WriteEndObject();
                writer.WriteStartObject();
                writer.WritePropertyName("KEY");
                writer.WriteValue("standr");
                writer.WritePropertyName("VALUE");
                writer.WriteValue(wb.standr);
                writer.WriteEndObject();

                writer.WriteStartObject();
                writer.WritePropertyName("KEY");
                writer.WriteValue("standg");
                writer.WritePropertyName("VALUE");
                writer.WriteValue(wb.standg);
                writer.WriteEndObject(); writer.WriteStartObject();
                writer.WritePropertyName("KEY");
                writer.WriteValue("standb");
                writer.WritePropertyName("VALUE");
                writer.WriteValue(wb.standb);
                writer.WriteEndObject();

                //warm
                writer.WriteStartObject();
                writer.WritePropertyName("KEY");
                writer.WriteValue("warmx");
                writer.WritePropertyName("VALUE");
                writer.WriteValue(wb.warmx);
                writer.WriteEndObject();

                writer.WriteStartObject();
                writer.WritePropertyName("KEY");
                writer.WriteValue("warmy");
                writer.WritePropertyName("VALUE");
                writer.WriteValue(wb.warmy);
                writer.WriteEndObject();
                writer.WriteStartObject();
                writer.WritePropertyName("KEY");
                writer.WriteValue("warmr");
                writer.WritePropertyName("VALUE");
                writer.WriteValue(wb.warmr);
                writer.WriteEndObject();

                writer.WriteStartObject();
                writer.WritePropertyName("KEY");
                writer.WriteValue("warmg");
                writer.WritePropertyName("VALUE");
                writer.WriteValue(wb.warmg);
                writer.WriteEndObject(); writer.WriteStartObject();
                writer.WritePropertyName("KEY");
                writer.WriteValue("warmb");
                writer.WritePropertyName("VALUE");
                writer.WriteValue(wb.warmb);
                writer.WriteEndObject();

                writer.WriteEndArray();


                writer.WritePropertyName("MO");
                writer.WriteValue(wb.MO);
                writer.WritePropertyName("SN");
                    writer.WriteValue(wb.SN);
                writer.WritePropertyName("RESULT");
                writer.WriteValue(wb.RESULT);

                writer.WritePropertyName("SOFT_VER");
                writer.WriteValue(wb.SOFT_VER);


                writer.WritePropertyName("WORKSTATIONID");
                    writer.WriteValue(wb.WORKSTATIONID);

                if (wb.ERROR_CODE != "")
                {
                    writer.WritePropertyName("ERRORS");
                    writer.WriteStartArray();
                    writer.WriteStartObject();
                    writer.WritePropertyName("ERROR_CODE");
                    writer.WriteValue(wb.ERROR_CODE);
                    writer.WritePropertyName("ERROR_SPOT");
                    writer.WriteValue(wb.ERROR_SPOT);
                    writer.WriteEndObject();
                    writer.WriteEndArray();
                }

                writer.WriteEndObject();
                    writer.Flush();
                }
                sw.Close();
                return sw.ToString();
            }

        public static string SendData(string data) {

            try
            {
                string url = config_json.MES_URL;

                var request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);    //创建了一个http请求
                request.ContentType = "application/json;charset=UTF-8";
                request.Method = "POST";     //请求方式Post

                byte[] payload = System.Text.Encoding.UTF8.GetBytes(data);

                //设置请求的 ContentLength 
                request.ContentLength = payload.Length;
                using (System.IO.Stream streamWriter = request.GetRequestStream())
                {
                    streamWriter.Write(payload, 0, payload.Length);
                }

                var response = (System.Net.HttpWebResponse)request.GetResponse();
                using (var streamReader = new System.IO.StreamReader(response.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    return result.ToString();
                }
            }
            catch (Exception ex) {
                return "服务器连接失败：" + ex.Message;
            }
        }
    }
}
