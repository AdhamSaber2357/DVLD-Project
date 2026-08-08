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

        public static int CheckUser(string username,string password)
        {
            string connection = DataBaseSettings.connectionString;
            string query = "Select * From Users where UserName = @UserName and Password =@Password;";

            SqlConnection c = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand( query, c);
            cmd.Parameters.AddWithValue("@UserName", username);
            cmd.Parameters.AddWithValue("@Password", password);

            try
            {
                c.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if(reader.Read())
                {
                    bool isActive = Convert.ToBoolean(reader["IsActive"]);
                    if (isActive)
                        return 1;
                    else
                        return 2;
                }
                
            }
            catch(Exception e) { Console.WriteLine(e.Message); }
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


        public static bool PresonIsUserOrNot(int personid)
        {

            try
            {

                string connection = DataBaseSettings.connectionString;
                string query = "Select * From Users Where PersonID = @PersonID;";
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    conn.Open();
                    using(SqlCommand cmd = new SqlCommand(query, conn))
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
    }


    
}
