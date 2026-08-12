using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataLayer
{
    public static class clsDataApplicationType
    {
        public static DataTable GetAllApplicationTypes()
        {
            DataTable dataTable = new DataTable();
            const string query = @"SELECT ApplicationTypeID as ID, ApplicationTypeTitle as Title, ApplicationFees as Fees
                                   FROM ApplicationTypes;";

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

        public static bool Find(int? applicationTypeID, ref string applicationTypeTitle, ref decimal applicationFees)
        {
            const string query = @"SELECT ApplicationTypeTitle, ApplicationFees
                                   FROM ApplicationTypes
                                   WHERE ApplicationTypeID = @ApplicationTypeID;";

            using (SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ApplicationTypeID", applicationTypeID);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                            return false;

                        applicationTypeTitle = (string)reader["ApplicationTypeTitle"];
                        applicationFees = (decimal)reader["ApplicationFees"];
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

        public static bool UpdateApplicationType(int? applicationTypeID, string applicationTypeTitle, decimal applicationFees)
        {
            const string query = @"UPDATE ApplicationTypes
                                   SET ApplicationTypeTitle = @ApplicationTypeTitle,
                                       ApplicationFees = @ApplicationFees
                                   WHERE ApplicationTypeID = @ApplicationTypeID;";

            using (SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ApplicationTypeID", applicationTypeID);
                command.Parameters.AddWithValue("@ApplicationTypeTitle", applicationTypeTitle);
                command.Parameters.AddWithValue("@ApplicationFees", applicationFees);

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
