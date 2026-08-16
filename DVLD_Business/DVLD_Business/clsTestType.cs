using System.Data;
using DVLD_DataLayer;

namespace DVLD_Business
{
    public class clsTestType
    {
        public enum enMode { Add, Update }
        private enMode _Mode;

        public enum enTestType { VisionTest = 1, WrittenTest = 2, StreetTest = 3 };
        public clsTestType.enTestType ID { get; set; }
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }
        public decimal TestTypeFees { get; set; }

        public clsTestType()
        {
            ID = clsTestType.enTestType.VisionTest;
            TestTypeTitle = null;
            TestTypeDescription = null;
            TestTypeFees = 0;
            _Mode = enMode.Add;
        }

        private clsTestType(clsTestType.enTestType testTypeID, string testTypeTitle,
            string testTypeDescription, decimal testTypeFees)
        {
            ID = testTypeID;
            TestTypeTitle = testTypeTitle;
            TestTypeDescription = testTypeDescription;
            TestTypeFees = testTypeFees;
            _Mode = enMode.Update;
        }

        public static DataTable GetAllTestTypes()
        {
            return clsDataTestType.GetAllTestTypes();
        }

        public static clsTestType Find(clsTestType.enTestType TestTypeID )
        {
            string testTypeTitle = string.Empty;
            string testTypeDescription = string.Empty;
            decimal testTypeFees = 0;

            if (clsDataTestType.Find((int)TestTypeID, ref testTypeTitle,
                ref testTypeDescription, ref testTypeFees))
            {
                return new clsTestType(TestTypeID, testTypeTitle,
                    testTypeDescription, testTypeFees);
            }

            return null;
        }

        private bool _UpdateTestType()
        {
            return clsDataTestType.UpdateTestType((int)ID, TestTypeTitle,
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
