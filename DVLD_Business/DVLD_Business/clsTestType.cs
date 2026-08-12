using System.Data;
using DVLD_DataLayer;

namespace DVLD_Business
{
    public class clsTestType
    {
        public enum enMode { Add, Update }
        private enMode _Mode;

        public int? TestTypeID { get; set; }
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }
        public decimal TestTypeFees { get; set; }

        public clsTestType()
        {
            TestTypeID = null;
            TestTypeTitle = null;
            TestTypeDescription = null;
            TestTypeFees = 0;
            _Mode = enMode.Add;
        }

        private clsTestType(int? testTypeID, string testTypeTitle,
            string testTypeDescription, decimal testTypeFees)
        {
            TestTypeID = testTypeID;
            TestTypeTitle = testTypeTitle;
            TestTypeDescription = testTypeDescription;
            TestTypeFees = testTypeFees;
            _Mode = enMode.Update;
        }

        public static DataTable GetAllTestTypes()
        {
            return clsDataTestType.GetAllTestTypes();
        }

        public static clsTestType Find(int? testTypeID)
        {
            string testTypeTitle = string.Empty;
            string testTypeDescription = string.Empty;
            decimal testTypeFees = 0;

            if (clsDataTestType.Find(testTypeID, ref testTypeTitle,
                ref testTypeDescription, ref testTypeFees))
            {
                return new clsTestType(testTypeID, testTypeTitle,
                    testTypeDescription, testTypeFees);
            }

            return null;
        }

        private bool _UpdateTestType()
        {
            return clsDataTestType.UpdateTestType(TestTypeID, TestTypeTitle,
                TestTypeDescription, TestTypeFees);
        }

        public bool Save()
        {
            if (_Mode == enMode.Update)
                return _UpdateTestType();

            return false;
        }
    }
}
