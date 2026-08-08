using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataLayer;
namespace DVLD_Bussiness
{
    public static class clsUser
    {











        public static int CheckUser(string username,string password)
        { return clsDataUser.CheckUser(username, password); }
        public static DataTable GetUsers() { return clsDataUser.GetAllUsers(); }
        public static bool CheckPersonIsUser(int pid) { return clsDataUser.PresonIsUserOrNot(pid); }
    }
}
