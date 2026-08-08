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
    public class clsUser
    {
        public enum Mode { Add,Update};
        private Mode _enMode;
        public int? UserID { get; set; }
        public int? PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public  bool? IsActive { get; set; }

        public clsPeople Person { get; set; }

       public clsUser()
        {
            UserID = null;
            PersonID = null;
            UserName = null;
            Password = null;
            IsActive = null;
            Person = null;
            _enMode = Mode.Add;
        }


        private clsUser(int? UserID,int? PersonID,string UserName, string Password,bool? IsActive)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.UserName = UserName;
            this.Password = Password;
            this.IsActive = IsActive;
            this.Person = clsPeople.Find(this.PersonID);
            _enMode =Mode.Update;
        }


        public static int CheckUser(string username,string password)
        { return clsDataUser.CheckUser(username, password); }
        public static DataTable GetUsers() { return clsDataUser.GetAllUsers(); }
        public static bool CheckPersonIsUser(int? pid) { return clsDataUser.PresonIsUserOrNot(pid); }

        public static clsUser Find(int? UserId)
        {
            string username = "", password = "";
            int? personid = null;
            bool? isactive = null;
            if(clsDataUser.Find(UserId,ref personid,ref username,ref password,ref isactive))
                return new clsUser(UserId,personid,username,password,isactive);

            else
                return null;
        }


        public bool AddUser()
        {
            int x = clsDataUser.AddUser(this.PersonID, this.UserName, this.Password, this.IsActive);
            this.UserID = x;
            this.Person = clsPeople.Find(this.PersonID);
            return x != 0;
        }

        public bool UpdateUser()
        {
            return clsDataUser.UpdateUser(this.UserID, this.UserName, this.Password, this.IsActive);
        }

        public bool Save()
        {
            if(_enMode == Mode.Add)
            {
                _enMode = Mode.Update;
                return AddUser();

            }
            return UpdateUser();

        }
    }
}
