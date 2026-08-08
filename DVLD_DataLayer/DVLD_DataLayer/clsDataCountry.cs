using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataLayer
{
    public static class clsDataCountry
    {
        public static DataTable GetAllCountries()
        {
            DataTable dt = new DataTable();
            string connection = DataBaseSettings.connectionString;
            string query = "Select CountryName From Countries; ";

            SqlConnection c = new SqlConnection(connection);

            SqlCommand cmd = new SqlCommand(query, c);

            try
            {
                c.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                    dt.Load(reader);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                c.Close();
            }
            return dt;

        }

        public static int FindCountryIDByName(string Name)
        {
            int CountryID = -1;
             string connection = DataBaseSettings.connectionString;
            string query = "Select CountryID From Countries Where CountryName = @CountryName;";

            SqlConnection c = new SqlConnection(connection);

            SqlCommand cmd = new SqlCommand(query, c);
            cmd.Parameters.AddWithValue("@CountryName", Name);
            try
            {
                c.Open();
                object reader = cmd.ExecuteScalar();
                CountryID = int.Parse(reader.ToString());
            }
            catch(Exception ex) {  Console.WriteLine(ex.Message); }
            finally { c.Close(); }

            return CountryID;

        }
        public static string FindCountryNameByID(int ID)
        {
           string name="";
            string connection = DataBaseSettings.connectionString;
            string query = "Select CountryName From Countries Where CountryID = @CountryID;";

            SqlConnection c = new SqlConnection(connection);

            SqlCommand cmd = new SqlCommand(query, c);
            cmd.Parameters.AddWithValue("@CountryID", ID);
            try
            {
                c.Open();
                object reader = cmd.ExecuteScalar();
                name  = (string)reader.ToString();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { c.Close(); }

            return name;

        }
    }
}
