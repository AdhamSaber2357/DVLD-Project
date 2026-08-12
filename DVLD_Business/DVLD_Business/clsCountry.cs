using DVLD_DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsCountry
    {
        public static DataTable GetCountries() { return clsDataCountry.GetAllCountries();}
        public static int Find(string CountryName) { return clsDataCountry.FindCountryIDByName(CountryName);}

        public static string Find(int id) { return clsDataCountry.FindCountryNameByID(id); }

    }
}
