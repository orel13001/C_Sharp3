using System;
using System.Collections.Generic;
using System.Text;

namespace SendMailWPF.Logic
{
    internal static class AccessProgramm
    {
        public static bool IsAccessProgramm(string login, string password)
        {
            return (login == "admin" && password == "admin");
        }
    }
}
