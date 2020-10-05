using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TimeZone.Resources
{
    public static class DataBaseAccess
    {

        private static SqlConnection OpenConnection()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["clockShopConnectionString"].ConnectionString);
            conn.Open();
            return conn;
        }


        public static bool RegisterUser(string fName, string lName, string email, string password, string role, string registerNumb)
        {
           
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "register_new_user";
            var conn = OpenConnection();

            command.Connection = conn;


            command.Parameters.AddWithValue("@register_number", registerNumb);
            command.Parameters.AddWithValue("@fName", fName);
            command.Parameters.AddWithValue("@lName", lName);
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@password", password);
            command.Parameters.AddWithValue("@role", role);



            SqlParameter sucess = new SqlParameter();
            sucess.ParameterName = "@sucess";
            sucess.Direction = ParameterDirection.Output;
            sucess.SqlDbType = SqlDbType.Int;
            sucess.Size = 1;

            command.Parameters.Add(sucess);

            command.ExecuteNonQuery();
            int response = Convert.ToInt32(command.Parameters["@sucess"].Value);
            conn.Close();

            if (response == 0)
            {
                return false;
            }
            return true;

        }


        public static User LoginUser(string userName, string password)
        {

            string query = $"SELECT * FROM shop_user WHERE email = '{userName}' AND user_password = '{password}'";

            var conn = OpenConnection();
            SqlCommand command = new SqlCommand(query, conn);


            SqlDataReader reader = command.ExecuteReader();

            var user = new User();

            try
            {
                while (reader.Read())
                {
                    user.FirstName = reader["first_name"].ToString();
                    user.LastName = reader["last_name"].ToString();
                    user.Email = reader["email"].ToString();
                    user.Role = reader["user_role"].ToString();
                    user.IsActive = Convert.ToInt32(reader["is_active"]);
                }

                return user;
            }
            finally
            {
                reader.Close();
                
            }

        }


        public static bool ConfirmRegistration(string email, string regNumber)
        {
            var conn = OpenConnection();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "activate_user";


            command.Connection = conn;

            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@register_number", regNumber);
            SqlParameter sucess = new SqlParameter();
            sucess.ParameterName = "@success";
            sucess.Direction = ParameterDirection.Output;
            sucess.SqlDbType = SqlDbType.Int;
            sucess.Size = 1;

            command.Parameters.Add(sucess);

            try
            {
                command.ExecuteNonQuery();
                int response = Convert.ToInt32(command.Parameters["@success"].Value);
                conn.Close();
                if (response == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                conn.Close();
                return false;
                
            }

        }
    }
}