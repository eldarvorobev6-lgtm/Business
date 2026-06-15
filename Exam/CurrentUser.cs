using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    public static class CurrentUser
    {
        public static string Login { get; set; }
        public static string FIO { get; set; }
        public static int RoleID { get; set; }
        public static string RoleName { get; set; }

        public static void Logout()
        {
            Login = null;
            FIO = null;
            RoleID = 0;
            RoleName = null;
        }

        public static bool IsAuthenticated => !string.IsNullOrEmpty(Login);
    }
}