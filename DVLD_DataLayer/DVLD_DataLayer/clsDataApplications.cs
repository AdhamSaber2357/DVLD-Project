using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataLayer
{
    public static class clsDataLocalDrivingLicenseApplications
    {
        public static DataTable GetAllApplications()
        {
            DataTable dataTable = new DataTable();
            const string query = @"Select * From LocalDrivingLicenseApplications_View;";

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

        public static DataTable GetAllApplicationsFromFilterIntValues(string filterBy, string value)
        {
            return _GetAllApplicationsWithFilter(filterBy, value, false);
        }

        public static DataTable GetAllApplicationsFromFilterStringValues(string filterBy, string value)
        {
            return _GetAllApplicationsWithFilter(filterBy, value, true);
        }

        private static DataTable _GetAllApplicationsWithFilter(string filterBy, string value, bool useLike)
        {
            DataTable dataTable = new DataTable();
            string query = $@"SELECT *
                              FROM LocalDrivingLicenseApplications_View
                              WHERE [{filterBy}] {(useLike ? "LIKE" : "=")} @Value;";

            using (SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Value", useLike ? value + "%" : value);

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
    }
}
