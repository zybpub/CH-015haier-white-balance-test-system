using System;

namespace helper
{
    class stringhandle
    {
        public static byte[] HexStringToByteArray(String hex)
        {
            hex = hex.Replace(" ","");
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
            bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }


        /// <summary>
        /// 将byte型转换为字符串
        /// </summary>
        /// <param name="arrInput">byte型数组</param>
        /// <returns>目标字符串</returns>
        public static string ByteArrayToHexString(byte[] arrInput)
        {
            int i;
            System.Text.StringBuilder sOutput = new System.Text.StringBuilder(arrInput.Length);
            for (i = 0; i < arrInput.Length; i++)
            {
                sOutput.Append(arrInput[i].ToString("X2")+" ");
            }
            //将此实例的值转换为System.String
            return sOutput.ToString();
        }
    }
}
