using System;
using System.Collections.Generic;
using System.Text;

namespace SendMailWPF.Logic
{
    public class CodingPassword
    {
        public static string ToCodingPassword(string passIn)
        {
            return passIn.GetHashCode().ToString();
        }
    }
}
