﻿using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;

class Class_SoftRegister
{
    public static int InitRegedit()
    {
        /*检查注册表*/
        string SericalNumber = ReadSetting("", "SerialNumber", "-1");    // 读取注册表， 检查是否注册 -1为未注册

        if (SericalNumber == "-1")
        {
            return 1;
        }

        /* 比较CPUid */
        string CpuId = GetSoftEndDateAllCpuId(1, SericalNumber);   //从注册表读取CPUid
        string CpuIdThis = GetCpuId();           //获取本机CPUId         
        if (CpuId != CpuIdThis)
        {
            return 2;
        }

        /* 比较时间 */
        string d = GetSoftEndDateAllCpuId(0, SericalNumber);
        TimeSpan ts = Convert.ToDateTime(GetSoftEndDateAllCpuId(0, SericalNumber)) - DateTime.Now;
        int leftdays = (int)ts.TotalDays;
        if (leftdays < 0)
        {
            return 3;
        }
        else
        {
            return leftdays + 100;
        }
    }


    /*CPUid*/
    public static string GetCpuId()
    {
        System.Management.ManagementClass mc = new System.Management.ManagementClass("Win32_Processor");
        System.Management.ManagementObjectCollection moc = mc.GetInstances();

        string strCpuID = null;
        foreach (System.Management.ManagementObject mo in moc)
        {
            strCpuID = mo.Properties["ProcessorId"].Value.ToString();
            break;
        }
        return strCpuID;
    }

    /* 生成序列号 */
    public static string CreatSerialNumber()
    {
        string SerialNumber = GetCpuId() + "+" + DateTime.Now.AddMonths(1).ToString("yyyy-MM-dd");
        return SerialNumber;
    }

    /* 
     * i=1 得到 CUP 的id 
     * i=0 得到上次或者 开始时间 
     */
    public static string GetSoftEndDateAllCpuId(int i, string SerialNumber)
    {
        if (i == 1)
        {
            try
            {
                string cupId = SerialNumber.Substring(0, SerialNumber.LastIndexOf("+")); // .LastIndexOf("-"));

                return cupId;
            }
            catch
            {
                return string.Empty;
            }
        }

        if (i == 0)
        {
            string dateTime = SerialNumber.Substring(SerialNumber.LastIndexOf("+") + 1);
            //  dateTime = dateTime.Insert(4, "/").Insert(7, "/");
            //  DateTime date = Convert.ToDateTime(dateTime);

            return dateTime;
        }
        else
        {
            return string.Empty;
        }
    }

    /*写入注册表*/
    public static void WriteSetting(string Section, string Key, string Setting)  // name = key  value=setting  Section= path
    {
        Attribute guid_attr = Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(GuidAttribute));
        string guid = ((GuidAttribute)guid_attr).Value;

        string text1 = Section;

        Microsoft.Win32.RegistryKey key1 = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\" + guid + "\\key1");
        if (key1 == null)
        {
            return;
        }
        try
        {
            key1.SetValue(Key, Setting);
        }
        catch
        {
            return;
        }
        finally
        {
            key1.Close();
        }

    }

    /*读取注册表*/
    public static string ReadSetting(string Section, string Key, string Default)
    {
        if (Default == null)
        {
            Default = "-1";
        }
        Attribute guid_attr = Attribute.GetCustomAttribute(System.Reflection.Assembly.GetExecutingAssembly(), typeof(System.Runtime.InteropServices.GuidAttribute));
        string guid = ((System.Runtime.InteropServices.GuidAttribute)guid_attr).Value;

        string text2 = Section;
        Microsoft.Win32.RegistryKey key1 = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\" + guid + "\\key1");
        if (key1 != null)
        {
            object obj1 = key1.GetValue(Key, Default);
            key1.Close();
            if (obj1 != null)
            {
                if (!(obj1 is string))
                {
                    return "-1";
                }
                string obj2 = obj1.ToString();
                obj2 = Encrypt.DES.DesDecrypt(obj2);
                return obj2;
            }
            return "-1";
        }
        else
        {
            Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\"+guid+"\\key1");
            WriteSetting("", "SerialNumber", Encrypt.DES.DesEncrypt(CreatSerialNumber()));
        }
        return Default;
       
    }
}

