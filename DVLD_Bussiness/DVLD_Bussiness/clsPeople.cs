using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataLayer;

namespace DVLD_Bussiness
{
    public class clsPeople
    {
        public enum _enMode { Add, Update };
        public _enMode Mode;
        public int PersonID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public int Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NationalityID { get; set; }
        public string ImagePath { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }

        public clsPeople()
        {
            PersonID = -1;
            NationalNo = null;
            FirstName = null;
            SecondName = null;
            ThirdName = null;
            LastName = null;
            Gender = -1;
            Phone = null;
            Address = null;
            ImagePath = null;
            Email = null;
            NationalityID = -1;
            DateOfBirth = DateTime.Today;
            ImagePath = "";
            Mode = _enMode.Add;
        }

        private clsPeople(int PersonID, string NationalNo
            , string FirstName, string SecondName, string ThirdName, string LastName, int Gender
            , string Phone, string Email, string Address, int NationalityID, string ImagePath, DateTime DateOfBirth)
        {
            this.PersonID = PersonID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.Gender = Gender;
            this.Phone = Phone;
            this.Email = Email;
            this.Address = Address;
            this.NationalityID = NationalityID;
            this.ImagePath = ImagePath;
            this.DateOfBirth = DateOfBirth;
            Mode = _enMode.Update;
        }

        public static DataTable GetPeople()
        { return clsDataPeople.GetAllPeople(); }
        public static DataTable GetPeopleWithFilter(string Attribute, string value)
        { return clsDataPeople.GetAllPeopleWithFilter(Attribute, value); }


        public bool _AddNewPerson()


        {
            int PersonID = clsDataPeople.AddPerson(this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName
                , this.Gender, this.Address, this.Phone, this.Email, this.NationalityID, this.DateOfBirth, this.ImagePath);

            return PersonID != -1;
        }
        public bool _UpdatePerson()
        {
            return clsDataPeople.UpdatePerson(this.PersonID, this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName
                , this.Gender, this.Address, this.Phone, this.Email, this.NationalityID, this.DateOfBirth, this.ImagePath);
        }
        public static clsPeople Find(int id)
        {
            string nationalno = "", firstname = "", lastname = "", secondnane = "", thirdname = "",
                phone = "", email = "", address = "", imagepath = "";
            int gender = -1, nationality = -1;
            DateTime date = DateTime.Now;

            if (clsDataPeople.Find(id, ref nationalno, ref firstname, ref secondnane, ref thirdname, ref lastname
                , ref gender, ref address, ref phone, ref email, ref nationality, ref date, ref imagepath))
                return new clsPeople(id, nationalno
            , firstname, secondnane, thirdname, lastname, gender
            , phone, email, address, nationality, imagepath, date);

            else
                return null;
        }

        public static bool DeletePerson(int pi) { return clsDataPeople.DeletePerson(pi); }

        public bool Save()
        {
            if (Mode == _enMode.Add)
            {
               return _AddNewPerson();
            }
            else
            {
                return _UpdatePerson();
            }
        }
    }
}


