using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_Business;
using DVLD_DataLayer;

namespace DVLD_Bussiness
{
    public class clsLocalDrivingLicenseApplications
    {
        public enum enMode { Add, Update }
        public enum enApplicationStatus { New = 1, Cancelled = 2, Completed = 3 }
        private enMode _Mode;

        public int? ApplicationID { get; set; }
        public int? ApplicantPersonID { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int? ApplicationTypeID { get; set; }
        public enApplicationStatus? ApplicationStatus { get; set; }
        public DateTime LastStatusDate { get; set; }
        public decimal PaidFees { get; set; }
        public int? CreatedByUserID { get; set; }
        public clsPeople Person { get; set; }

        public clsLocalDrivingLicenseApplications()
        {
            ApplicationID = null;
            ApplicantPersonID = null;
            ApplicationDate = DateTime.Now;
            ApplicationTypeID = null;
            ApplicationStatus = null;
            LastStatusDate = DateTime.Now;
            PaidFees = 0;
            CreatedByUserID = null;
            Person = null;
            _Mode = enMode.Add;
        }

        private clsLocalDrivingLicenseApplications(int? applicationID, int? applicantPersonID,
            DateTime applicationDate, int? applicationTypeID, enApplicationStatus? applicationStatus,
            DateTime lastStatusDate, decimal paidFees, int? createdByUserID)
        {
            ApplicationID = applicationID;
            ApplicantPersonID = applicantPersonID;
            ApplicationDate = applicationDate;
            ApplicationTypeID = applicationTypeID;
            ApplicationStatus = applicationStatus;
            LastStatusDate = lastStatusDate;
            PaidFees = paidFees;
            CreatedByUserID = createdByUserID;
            Person = clsPeople.Find(ApplicantPersonID);
            _Mode = enMode.Update;
        }

        public static DataTable GetAllApplications()
        {
            return clsDataLocalDrivingLicenseApplications.GetAllApplications();
        }

        public static DataTable GetApplicationsWithIntFilter(string filterBy, string value)
        {
            return clsDataLocalDrivingLicenseApplications.GetAllApplicationsFromFilterIntValues(filterBy, value);
        }

        public static DataTable GetApplicationsWithStringFilter(string filterBy, string value)
        {
            return clsDataLocalDrivingLicenseApplications.GetAllApplicationsFromFilterStringValues(filterBy, value);
        }
    }
}
