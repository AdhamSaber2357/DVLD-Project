using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataLayer
{
    public static class clsDataUser
    {


        public static bool IsUserExist(string UserName)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(DataBaseSettings.connectionString))
            {
                string query = "SELECT Found=1 FROM Users WHERE UserName = @UserName";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserName", UserName);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            isFound = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        isFound = false;
                    }
                }
            }

            return isFound;
        }

        public static int CheckUser(string username, string password)
        {
            string connection = DataBaseSettings.connectionString;
            string query = "Select * From Users where UserName = @UserName and Password =@Password;";

            SqlConnection c = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand(query, c);
            cmd.Parameters.AddWithValue("@UserName", username);
            cmd.Parameters.AddWithValue("@Password", password);

            try
            {
                c.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    bool isActive = Convert.ToBoolean(reader["IsActive"]);
                    if (isActive)
                        return 1;
                    else
                        return 2;
                }

            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            finally { c.Close(); }

            return 3;
        }




        public static DataTable GetAllUsers()
        {
            DataTable dt = new DataTable();
            string connection = DataBaseSettings.connectionString;
            string query = @"Select u.UserID,p.PersonID , [Full Name] = p.FirstName +' ' + p.SecondName+' '+
                           p.ThirdName +' '+p.LastName ,u.UserName, u.IsActive
                           From Users u
                           inner join People p
                           on u.PersonID = p.PersonID
                           ;";

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


        public static bool PresonIsUserOrNot(int? personid)
        {

            try
            {

                string connection = DataBaseSettings.connectionString;
                string query = "Select * From Users Where PersonID = @PersonID;";
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@PersonID", personid);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                            return true;


                    }



                }


            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return false;
        }
    

    public static int AddUser(int? PersonID,string username,string password,bool? isactive)
    {
        int UserID = 0;
            try
            {
                string connection = DataBaseSettings.connectionString;
                string query = @"Insert into Users (PersonID,UserName,Password,IsActive)
                               Values(@PersonID,@UserName,@Password,@IsActive);
                               Select SCOPE_IDENTITY();";
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@PersonID", PersonID);
                        cmd.Parameters.AddWithValue("@UserName", username);
                        cmd.Parameters.AddWithValue("@Password", password);
                        cmd.Parameters.AddWithValue("@IsActive", isactive);

                        object reader = cmd.ExecuteScalar();
                        
                        UserID = int.Parse(reader.ToString());


                    }


                }


            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return UserID;
        }


        public static bool Find(int? Userid, ref int?  Personid,ref string username,ref string password,ref bool? isactive)
        {
            string cconnection = DataBaseSettings.connectionString;
            string query = "Select * From Users Where UserID = @UserID";
            using(SqlConnection conn = new SqlConnection(cconnection))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", Userid);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if(reader.Read())
                    {
                        Personid = (int)reader["PersonID"];
                        username = (string)reader["UserName"];
                        password = (string)reader["Password"];
                        isactive = (bool)reader["IsActive"];
                        return true;
                    }


                }

            }
            return false;
        }
        public static bool FindByUserName(string UserName, ref int? Personid, ref int? UserID, ref string password, ref bool? isactive)
        {
            string cconnection = DataBaseSettings.connectionString;
            string query = "Select * From Users Where UserName = @UserName";
            using (SqlConnection conn = new SqlConnection(cconnection))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserName", UserName);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        Personid = (int)reader["PersonID"];
                        UserID = (int)reader["UserID"];
                        password = (string)reader["Password"];
                        isactive = (bool)reader["IsActive"];
                        return true;
                    }


                }

            }
            return false;
        }

        public static bool UpdateUser(int? UserID,string UserName,string Password,bool? IsActive)
        {
            int rows = 0;
            try
            {
                string connection = DataBaseSettings.connectionString;
                string query = @"
                              Update Users
                              Set UserName = @UserName,Password =@Password,IsActive = @IsActive
                              where UserID = @UserID;";
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", UserID);
                        cmd.Parameters.AddWithValue("@UserName", UserName);
                        cmd.Parameters.AddWithValue("@Password", Password);
                        cmd.Parameters.AddWithValue("@IsActive", IsActive);

                         rows = cmd.ExecuteNonQuery();



                    }


                }


            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return rows > 0;
        }



        public static bool DeleteUser(int UserID)
        {
            int rows = 0;
            try
            {
                string connection = DataBaseSettings.connectionString;
                string query = " Delete From Users where UserID = @UserID;";
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", UserID);
                        rows = cmd.ExecuteNonQuery();
                    }


                }


            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return rows > 0;
        }


        public static DataTable GetAllUsersFromFilterIntValues(string FilterBy ,string value)
        {
            DataTable dt = new DataTable();
            string connection = DataBaseSettings.connectionString;
            string query = $@"
                         Select * From 
                         
                         (
                         
                         Select u.UserID,p.PersonID , [Full Name] = p.FirstName +' ' + p.SecondName+' '+
                                                    p.ThirdName +' '+p.LastName ,u.UserName, u.IsActive
                          From Users u
                          inner join People p
                          on u.PersonID = p.PersonID
                         ) t
                         Where {FilterBy} = @Value";

            SqlConnection c = new SqlConnection(connection);

            SqlCommand cmd = new SqlCommand(query, c);
            cmd.Parameters.AddWithValue("@Value",value);

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

        public static DataTable GetAllUsersFromFilterStringValues(string FilterBy, string value)
        {
            DataTable dt = new DataTable();
            string connection = DataBaseSettings.connectionString;
            string query = $@"
                         Select * From 
                         
                         (
                         
                         Select u.UserID,p.PersonID , [Full Name] = p.FirstName +' ' + p.SecondName+' '+
                                                    p.ThirdName +' '+p.LastName ,u.UserName, u.IsActive
                          From Users u
                          inner join People p
                          on u.PersonID = p.PersonID
                         ) t
                         Where [{FilterBy}] like @Value;";

            SqlConnection c = new SqlConnection(connection);

            SqlCommand cmd = new SqlCommand(query, c);
            cmd.Parameters.AddWithValue("@Value", value + "%");

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
    }


    
}
    