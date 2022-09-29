using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

namespace Test_Automation.Nathan_Classes
{
    public class UserHelper
    {
        public void CheckSupperUser(string path,List<Class_User> listUser)
        {
            if (!System.IO.File.Exists(path)){
                Class_User user = new Class_User() { index = 0, UserName = "Admin", Password = "admin", Level = Class_User.Authority.Admin };
                listUser.Add(user);
                serialized_user(path, listUser);
            }
        }
        /// <summary>
        /// serialized to file
        /// </summary>
        /// <param name="path"></param>
        /// <param name="listuser"></param>
        /// <returns></returns>
        public bool serialized_user(string path, List<Class_User> listuser)
        {
            if (listuser == null) return false;
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter format = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            using (System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.Create, System.IO.FileAccess.Write))
            {
                format.Serialize(fs, listuser);
                return true;
            }
        }
        public List<Class_User> deserializedUser(string path) {
            BinaryFormatter format = new BinaryFormatter();
            try {
                using (System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.Create, System.IO.FileAccess.Read))
                {
                  object obj=  format.Deserialize(fs);
                    return obj as List<Class_User>;
                }
            }catch(System.Exception) { return null; }
        }


    }
}
