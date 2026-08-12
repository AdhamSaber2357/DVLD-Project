using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataLayer;

namespace DVLD_Business
{
    public class clsApplicationType
    {
        public enum enMode { Add, Update }
        private enMode _Mode;

        public int? ApplicationTypeID { get; set; }
        public string ApplicationTypeTitle { get; set; }
        public decimal ApplicationFees { get; set; }

        public clsApplicationType()
        {
            ApplicationTypeID = null;
            ApplicationTypeTitle = null;
            ApplicationFees = 0;
            _Mode = enMode.Add;
        }

        private clsApplicationType(int? applicationTypeID, string applicationTypeTitle, decimal applicationFees)
        {
            ApplicationTypeID = applicationTypeID;
            ApplicationTypeTitle = applicationTypeTitle;
            ApplicationFees = applicationFees;
            _Mode = enMode.Update;
        }

        public static DataTable GetAllApplicationTypes()
        {
            return clsDataApplicationType.GetAllApplicationTypes();
        }

        public static clsApplicationType Find(int? applicationTypeID)
        {
            string applicationTypeTitle = string.Empty;
            decimal applicationFees = 0;

            if (clsDataApplicationType.Find(applicationTypeID, ref applicationTypeTitle, ref applicationFees))
                return new clsApplicationType(applicationTypeID, applicationTypeTitle, applicationFees);

            return null;
        }

        private bool _UpdateApplicationType()
        {
            return clsDataApplicationType.UpdateApplicationType(
                ApplicationTypeID,
                ApplicationTypeTitle,
                ApplicationFees);
        }

        public bool Save()
        {
            if (_Mode == enMode.Update)
                return _UpdateApplicationType();

            return false;
        }
    }
}
