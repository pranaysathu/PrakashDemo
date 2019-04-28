using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDE.UITest.Utilities
{
    public class Helper
    {
        public void EncryptPassword()
        {
            byte[] passBytes = System.Text.Encoding.Unicode.GetBytes("");
            string encryptPass = Convert.ToBase64String(passBytes);
        }

        public string DecryptPassword(string encryptedPassword)
        {
            byte[] passByteData = Convert.FromBase64String(encryptedPassword);
            string originalPassword = System.Text.Encoding.Unicode.GetString(passByteData);
            return originalPassword;
        }
    }
}
