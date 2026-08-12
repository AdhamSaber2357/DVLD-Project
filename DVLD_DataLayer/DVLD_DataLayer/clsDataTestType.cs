using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataLayer
{
    public static class clsDataTestType
    {
        public static DataTable GetAllTestTypes()
        {
            DataTable dataTable = new DataTable();
            const string query = @"SELECT TestTypeID AS ID,
                                          TestTypeTitle AS Title,
                                          TestTypeDescription AS Description,
                                          TestTypeFees AS Fees
                                   FROM TestTypes;";

            using (SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        dataTable.Load(reader);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return dataTable;
        }

        public static bool Find(int? testTypeID, ref string testTypeTitle,
            ref string testTypeDescription, ref decimal testTypeFees)
        {
            const string query = @"SELECT TestTypeTitle, TestTypeDescription, TestTypeFees
                                   FROM TestTypes
                                   WHERE TestTypeID = @TestTypeID;";

            using (SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TestTypeID", testTypeID);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                            return false;

                        testTypeTitle = (string)reader["TestTypeTitle"];
                        testTypeDescription = (string)reader["TestTypeDescription"];
                        testTypeFees = (decimal)reader["TestTypeFees"];
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }

        public static bool UpdateTestType(int? testTypeID, string testTypeTitle,
            string testTypeDescription, decimal testTypeFees)
        {
            const string query = @"UPDATE TestTypes
                                   SET TestTypeTitle = @TestTypeTitle,
                                       TestTypeDescription = @TestTypeDescription,
                                       TestTypeFees = @TestTypeFees
                                   WHERE TestTypeID = @TestTypeID;";

            using (SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TestTypeID", testTypeID);
                command.Parameters.AddWithValue("@TestTypeTitle", testTypeTitle);
                command.Parameters.AddWithValue("@TestTypeDescription", testTypeDescription);
                command.Parameters.AddWithValue("@TestTypeFees", testTypeFees);

                try
                {
                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }
    }
}
