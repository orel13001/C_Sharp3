using System;
using System.Collections.Generic;
using System.Text;

namespace SendMailWPF.Logic
{
    public static class AccessProgramm
    {
        private static string pass = "admin";
        public static bool IsAccessProgramm(string login, string password)
        {
            return (login == "admin" && password == pass.GetHashCode().ToString());
        }

    }
}
