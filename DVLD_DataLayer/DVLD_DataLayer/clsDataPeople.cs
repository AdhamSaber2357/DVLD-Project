using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataLayer
{
    public static class clsDataPeople
    {
        public static DataTable GetAllPeople()
        {
            DataTable dt = new DataTable();
            string connection = DataBaseSettings.connectionString;
            string query = @"Select p.PersonID,p.NationalNo,p.FirstName,p.SecondName,p.ThirdName , p.LastName , Gender = Case 
                            When p.Gendor = 0 Then 'Male'
                            When p.Gendor = 1 Then 'Female'
                         End
                         ,p.DateOfBirth,p.Phone,p.Email, c.CountryName as Nationality
                         From People as p
                         Inner Join Countries as c on
                         p.NationalityCountryID = c.CountryID
                         ";

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




        public static DataTable GetAllPeopleWithIntFilter(string filterBy, string value)
        {
            return _GetAllPeopleWithFilter(filterBy, value, "=");
        }

        public static DataTable GetAllPeopleWithStringFilter(string filterBy, string value)
        {
            return _GetAllPeopleWithFilter(filterBy, value + "%", "LIKE");
        }

        public static DataTable GetAllPeopleWithDateFilter(string filterBy, string value)
        {
            return _GetAllPeopleWithFilter(filterBy, value + "%", "LIKE", true);
        }

        private static DataTable _GetAllPeopleWithFilter(string filterBy, string value,
            string comparison, bool isDate = false)
        {
            string[] allowedColumns = { "PersonID", "NationalNo", "FirstName", "SecondName", "ThirdName",
                "LastName", "Gender", "DateOfBirth", "Phone", "Email", "Nationality" };

            if (!allowedColumns.Contains(filterBy))
                return GetAllPeople();

            DataTable dt = new DataTable();
            string query = $@"SELECT * FROM
                              (
                                  Select p.PersonID,p.NationalNo,p.FirstName,p.SecondName,p.ThirdName, p.LastName,
                                  Gender = Case When p.Gendor = 0 Then 'Male' When p.Gendor = 1 Then 'Female' End,
                                  p.DateOfBirth,p.Phone,p.Email, c.CountryName as Nationality
                                  From People as p
                                  Inner Join Countries as c on p.NationalityCountryID = c.CountryID
                              ) AS PeopleList
                              WHERE {(isDate ? "CONVERT(varchar(30), [DateOfBirth], 120)" : "[" + filterBy + "]")} {comparison} @Value;";

            using (SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Value", value);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return dt;
        }


        public static int AddPerson( string nationalnumber
            , string firstname, string secondname, string thirdname, string lastname
            , int gender, string address,string phone, string email, int nationality, DateTime birthofdate, string ImagePath)
        {
            int PersonId = -1;
            string connection = DataBaseSettings.connectionString;
            SqlConnection c = new SqlConnection(connection);
            string query = @"
                    Insert Into People 
                    Values (@NationalNo
                   ,@FirstName,@SecondName,@ThirdName,@LastName,
                   @DateOfBirth,@Gendor,@Address,@Phone,@Email,@NationalityCountryID,@ImagePath);
                   Select SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(query, c);
            cmd.Parameters.AddWithValue("@NationalNo", nationalnumber);
            cmd.Parameters.AddWithValue("@FirstName", firstname);
            cmd.Parameters.AddWithValue("@SecondName", secondname);
            cmd.Parameters.AddWithValue("@ThirdName", thirdname);
            cmd.Parameters.AddWithValue("@LastName", lastname);
            cmd.Parameters.AddWithValue("@DateOfBirth", birthofdate);
            cmd.Parameters.AddWithValue("@Gendor", gender);
            cmd.Parameters.AddWithValue("@Address", address);
            cmd.Parameters.AddWithValue("@Phone", phone);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@NationalityCountryID", nationality);
            if (!string.IsNullOrEmpty(ImagePath))
                cmd.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                cmd.Parameters.AddWithValue("@ImagePath", DBNull.Value);

            try
            {
                c.Open();
                object reader = cmd.ExecuteScalar();
                PersonId = int.Parse(reader.ToString());

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { c.Close(); }

            return PersonId;

        }

        public static bool UpdatePerson(int? personid,string nationalnumber
            , string firstname, string secondname, string thirdname, string lastname
            , int gender, string address, string phone, string email, int nationality, DateTime birthofdate, string ImagePath)
        {
            int rows = 0;
            string connection = DataBaseSettings.connectionString;
            SqlConnection c = new SqlConnection(connection);
            string query = @"
                    Update People 
                    Set NationalNo=@NationalNo,FirstName=@FirstName,SecondName=@SecondName,ThirdName=@ThirdName,LastName=@LastName
                    ,Gendor=@Gendor,Address=@Address,Phone=@Phone,Email=@Email,
                    NationalityCountryID=@NationalityCountryID,DateOfBirth=@DateOfBirth,ImagePath=@ImagePath
                    where PersonID=@PersonID;";

            SqlCommand cmd = new SqlCommand(query, c);
            cmd.Parameters.AddWithValue("@PersonID", personid);
            cmd.Parameters.AddWithValue("@NationalNo", nationalnumber);
            cmd.Parameters.AddWithValue("@FirstName", firstname);
            cmd.Parameters.AddWithValue("@SecondName", secondname);
            cmd.Parameters.AddWithValue("@ThirdName", thirdname);
            cmd.Parameters.AddWithValue("@LastName", lastname);
            cmd.Parameters.AddWithValue("@DateOfBirth", birthofdate);
            cmd.Parameters.AddWithValue("@Gendor", gender);
            cmd.Parameters.AddWithValue("@Address", address);
            cmd.Parameters.AddWithValue("@Phone", phone);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@NationalityCountryID", nationality);
            if (!string.IsNullOrEmpty(ImagePath))
                cmd.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                cmd.Parameters.AddWithValue("@ImagePath", DBNull.Value);

            try
            {
                c.Open();
                 rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { c.Close(); }

            return rows > 0;

        }

        public static  bool Find( int?  personid,ref string nationalnumber
            ,ref string firstname,ref string secondname,ref string thirdname,ref string lastname
            , ref int  gender,ref string address,ref string phone,ref string email,ref int nationality,ref DateTime birthofdate,ref string ImagePath)
        {
            string query = @"Select * From People where PersonID = @PersonID";
            string connection = DataBaseSettings.connectionString;

            SqlConnection c = new SqlConnection(connection);

            SqlCommand cmd = new SqlCommand(query, c);
            cmd.Parameters.AddWithValue("@PersonID",personid);

            try
            {
                c.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nationalnumber = (string)reader["NationalNo"];
                    firstname = (string)reader["FirstName"];
                    secondname = (string)reader["SecondName"];
                    thirdname = (string)reader["ThirdName"];
                    lastname = (string)reader["LastName"];
                    phone = (string)reader["Phone"];
                    email = (string)reader["Email"];
                    address = (string)reader["Address"];
                    if (reader["ImagePath"] == DBNull.Value)
                        ImagePath = null;
                    else
                        ImagePath = (string)reader["ImagePath"];

                    gender = (byte)reader["Gendor"];
                    nationality = (int)reader["NationalityCountryID"];
                    birthofdate = (DateTime)reader["DateOfBirth"];

                }
                else
                    return false;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                c.Close();
            }
            return true;

        }

        public static bool DeletePerson(int PersonId)
        {
            int rowsAffected = 0;
            string query = @"Delete From People where PersonID = @PersonID";
            string connection = DataBaseSettings.connectionString;

            SqlConnection c = new SqlConnection(connection);

            SqlCommand cmd = new SqlCommand(query, c);
            cmd.Parameters.AddWithValue("@PersonID", PersonId);
            try
            {
                c.Open();
                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { c.Close(); }

            return rowsAffected> 0;
        }
        
    }
}
