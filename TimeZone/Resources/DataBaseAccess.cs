using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TimeZone.Data;

namespace TimeZone.Resources
{
    public static class DataBaseAccess
    {

        public static SqlConnection OpenConnection()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["clockShopConnectionString"].ConnectionString);
            conn.Open();
            return conn;
        }


        public static SqlConnection OpenTempData()
        {
            SqlConnection connTemp = new SqlConnection(ConfigurationManager.ConnectionStrings["clockShopConnectionString"].ConnectionString);
            connTemp.Open();
            return connTemp;
        }


        public static bool RegisterUser(string fName, string lName, string email, string password, string role, string registerNumb)
        {
            var conn = OpenConnection();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "register_new_user";
            
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
                    user.Id = Convert.ToInt32(reader["id"]);
                    user.FirstName = reader["first_name"].ToString();
                    user.LastName = reader["last_name"].ToString();
                    user.Email = reader["email"].ToString();
                    user.Role = reader["user_role"].ToString();
                    user.IsActive = Convert.ToInt32(reader["is_active"]);
                    if (Convert.ToInt32(reader["is_resseler"]) == 1)
                    {
                        user.IsResseler = true;
                    }
                    else if (Convert.ToInt32(reader["is_resseler"]) == 0)
                    {
                        user.IsResseler = false;
                    }
                        
                        
                         
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


        public static bool ChangeUserData(string firstName, string lastName, string email)
        {
            var conn = OpenConnection();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "change_user";

            command.Connection = conn;

            command.Parameters.AddWithValue("@first_name", firstName);
            command.Parameters.AddWithValue("@last_name", lastName);
            command.Parameters.AddWithValue("@email", email);
            SqlParameter success = new SqlParameter();
            success.ParameterName = "@success";
            success.Direction = ParameterDirection.Output;
            success.SqlDbType = SqlDbType.Int;
            success.Size = 1;
            command.Parameters.Add(success);

            try
            {
                command.ExecuteNonQuery();
                int response = Convert.ToInt32(command.Parameters["@success"].Value);
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


        public static bool DeleteUser(string email)
        {
            var conn = OpenConnection();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "delete_user";

            command.Connection = conn;
            command.Parameters.AddWithValue("@email", email);
            SqlParameter success = new SqlParameter();
            success.ParameterName = "@success";
            success.Direction = ParameterDirection.Output;
            success.SqlDbType = SqlDbType.Int;
            success.Size = 1;
            command.Parameters.Add(success);

            try
            {
                command.ExecuteNonQuery();
                int response = Convert.ToInt32(command.Parameters["@success"].Value);
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


        public static void CreateTempTable(SqlConnection sqlConnection)
        {
           
            var conntemp = sqlConnection;
            
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "create_temp_table";
            command.Connection = conntemp;

            command.ExecuteNonQuery();
        } 




        public static bool UpdateCartTableTemp(int productId, string description, decimal price, SqlConnection conn)
        {

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "update_cart_table";

            command.Connection = conn;


            command.Parameters.AddWithValue("@product_id", productId);
            command.Parameters.AddWithValue("@product_description", description);
            command.Parameters.AddWithValue("@product_price", price);


            SqlParameter success = new SqlParameter();
            success.ParameterName = "@success";
            success.Direction = ParameterDirection.Output;
            success.SqlDbType = SqlDbType.Int;
            success.Size = 1;

            command.Parameters.Add(success);

            command.ExecuteNonQuery();
            int response = Convert.ToInt32(command.Parameters["@success"].Value);

            if (response == 0)
            {
                return false;
            }
            return true;

        }



        public static void UpdateCartUser(User user, int productId, string description, decimal price)
        {
            var conn = OpenConnection();


            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "update_cart";

            command.Connection = conn;

            command.Parameters.Clear();
            command.Parameters.AddWithValue("@product_id", productId);
            command.Parameters.AddWithValue("@product_description", description);
            command.Parameters.AddWithValue("@product_price", price);
            command.Parameters.AddWithValue("@user_shop_id", user.Id);


            command.ExecuteNonQuery();

        }



        public static void UpdateCart(List<Product> products, User user)
        {
            var conn = OpenConnection();


            var tempConn = OpenTempData();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "update_cart";

            command.Connection = conn;

            foreach (var item in products)
            {
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@product_id", item.Id);
                command.Parameters.AddWithValue("@product_description", item.Description);
                command.Parameters.AddWithValue("@product_price", item.Price);
                command.Parameters.AddWithValue("@user_shop_id", user.Id);
                command.ExecuteNonQuery();
            }

            conn.Close();
            tempConn.Close();

        }


        public static List<User>  GetActiveResselers()
        {
            string query = $"SELECT * FROM shop_user WHERE user_role = 'Resseler' AND is_resseler = 1";

            var conn = OpenConnection();
            SqlCommand command = new SqlCommand(query, conn);

            var list = new List<User>();

            SqlDataReader reader = command.ExecuteReader();

            

            try
            {
                while (reader.Read())
                {
                    var user = new User();

                    user.Id = Convert.ToInt32(reader["id"]);
                    user.FirstName = reader["first_name"].ToString();
                    user.LastName = reader["last_name"].ToString();
                    user.Email = reader["email"].ToString();
                    user.Role = reader["user_role"].ToString();
                    user.IsActive = Convert.ToInt32(reader["is_active"]);


                    list.Add(user);
                }

                return list;
            }
            finally
            {
                reader.Close();

            }
        }


        public static List<User> GetInactiveResselers()
        {
            string query = $"SELECT * FROM shop_user WHERE user_role = 'Resseler' AND is_resseler = 0";

            var conn = OpenConnection();
            SqlCommand command = new SqlCommand(query, conn);

            var list = new List<User>();

            SqlDataReader reader = command.ExecuteReader();



            try
            {
                while (reader.Read())
                {
                    var user = new User();

                    user.Id = Convert.ToInt32(reader["id"]);
                    user.FirstName = reader["first_name"].ToString();
                    user.LastName = reader["last_name"].ToString();
                    user.Email = reader["email"].ToString();
                    user.Role = reader["user_role"].ToString();
                    user.IsActive = Convert.ToInt32(reader["is_active"]);


                    list.Add(user);
                }

                return list;
            }
            finally
            {
                reader.Close();

            }
        }



        public static bool ChangePassword(string email, string oldPassword, string newPassword)
        {
            var conn = OpenConnection();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "change_password";

            command.Connection = conn;
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@oldpass", oldPassword);
            command.Parameters.AddWithValue("@newpass", newPassword);
            SqlParameter success = new SqlParameter();
            success.ParameterName = "@success";
            success.Direction = ParameterDirection.Output;
            success.SqlDbType = SqlDbType.Int;
            success.Size = 1;
            command.Parameters.Add(success);

            try
            {
                command.ExecuteNonQuery();
                int response = Convert.ToInt32(command.Parameters["@success"].Value);
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




        public static bool RecoverPassword(string email)
        {
            var conn = OpenConnection();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "recover_password";

            command.Connection = conn;
            command.Parameters.AddWithValue("@email", email);
            SqlParameter success = new SqlParameter();
            success.ParameterName = "@success";
            success.Direction = ParameterDirection.Output;
            success.SqlDbType = SqlDbType.Int;
            success.Size = 1;
            command.Parameters.Add(success);

            try
            {
                command.ExecuteNonQuery();
                int response = Convert.ToInt32(command.Parameters["@success"].Value);
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



        public static bool EndRecoverPassword(string email, string password)
        {
            var conn = OpenConnection();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "end_recover_password";

            command.Connection = conn;
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@password", password);
            SqlParameter success = new SqlParameter();
            success.ParameterName = "@success";
            success.Direction = ParameterDirection.Output;
            success.SqlDbType = SqlDbType.Int;
            success.Size = 1;
            command.Parameters.Add(success);

            try
            {
                command.ExecuteNonQuery();
                int response = Convert.ToInt32(command.Parameters["@success"].Value);
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


        public static User GtUserByEmail(string email)
        {
            string query = $"SELECT * FROM shop_user WHERE email = '{email}' AND is_active = 1;";

            var conn = OpenConnection();
            SqlCommand command = new SqlCommand(query, conn);


            SqlDataReader reader = command.ExecuteReader();

            var user = new User();

            try
            {
                while (reader.Read())
                {
                    user.Id = Convert.ToInt32(reader["id"]);
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



        public static bool AddProduct(string description, decimal price, int stock)
        {
            var conn = OpenConnection();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "add_product";

            command.Connection = conn;


            command.Parameters.AddWithValue("@prod_desc", description);
            command.Parameters.AddWithValue("@prod_price", price);
            command.Parameters.AddWithValue("@prod_stock", stock);




            SqlParameter success = new SqlParameter();
            success.ParameterName = "@success";
            success.Direction = ParameterDirection.Output;
            success.SqlDbType = SqlDbType.Int;
            success.Size = 1;

            command.Parameters.Add(success);

            command.ExecuteNonQuery();
            int response = Convert.ToInt32(command.Parameters["@success"].Value);
            conn.Close();

            if (response == 0)
            {
                return false;
            }
            return true;
        }



        public static List<Product> GetProducts()
        {
            string query = $"SELECT * FROM products WHERE stock >0";

            var conn = OpenConnection();
            SqlCommand command = new SqlCommand(query, conn);

            var list = new List<Product>();

            SqlDataReader reader = command.ExecuteReader();



            try
            {
                while (reader.Read())
                {
                    var product = new Product();

                    product.Id = Convert.ToInt32(reader["id"]);
                    product.Description = reader["product_description"].ToString();
                    product.Price = Convert.ToDecimal(reader["product_price"]);
                    product.Stock = Convert.ToInt32(reader["stock"]);

                    list.Add(product);
                }

                return list;
            }
            finally
            {
                reader.Close();

            }
        }



        public static Product GtProductByID(int id)
        {
            
            var conn = OpenConnection();

            string query = $"SELECT * FROM products WHERE id = {id}";

            SqlCommand command = new SqlCommand(query, conn);

            SqlDataReader reader = command.ExecuteReader();

            Product product = new Product();

            
            while (reader.Read())
            {
                

                product.Id = reader.GetInt32(0);
                product.Description = reader.GetString(1);
                product.Price = reader.GetDecimal(2);

            }

            reader.Close();
            conn.Close();
            return product;

            
        }



        public static List<Product> GetTempCart(SqlConnection conn)
        {

            string query = $"SELECT * FROM ##cart_product";

            SqlCommand command = new SqlCommand(query, conn);
            List<Product> products = new List<Product>();
            try
            {
                SqlDataReader reader = command.ExecuteReader();



                while (reader.Read())
                {
                    Product product = new Product();

                    product.Id = Convert.ToInt32(reader["id"]);
                    product.Description = reader["product_description"].ToString(); 
                    product.Price = Convert.ToDecimal(reader["product_price"]);


                    products.Add(product);


                    
                }
                reader.Close();
                return products;

               
            }
            catch (Exception ex)
            {
                return products;
            }

            
        }


        public static bool DeleteTempCartProduct(int productId, SqlConnection conn)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "delete_temp_cart";

            command.Connection = conn;


            command.Parameters.AddWithValue("@product_id", productId);


            SqlParameter success = new SqlParameter();
            success.ParameterName = "@success";
            success.Direction = ParameterDirection.Output;
            success.SqlDbType = SqlDbType.Int;
            success.Size = 1;

            command.Parameters.Add(success);

            command.ExecuteNonQuery();
            int response = Convert.ToInt32(command.Parameters["@success"].Value);

            if (response == 0)
            {
                return false;
            }
            return true;

        }


        public static List<Product> GetUserCart(SqlConnection connTemp, int id)
        {
            var conn = OpenConnection();

            var tempCon = connTemp;

            

            string query = $"SELECT * FROM user_cart WHERE user_shop_id = {id}";

            SqlCommand command = new SqlCommand(query, conn);
            List<Product> products = new List<Product>();
            try
            {
                SqlDataReader reader = command.ExecuteReader();



                while (reader.Read())
                {
                    Product product = new Product();

                    product.Id = Convert.ToInt32(reader["id"]);
                    product.Description = reader["product_description"].ToString();
                    product.Price = Convert.ToDecimal(reader["product_price"]);


                    products.Add(product);



                }
                reader.Close();

                if (tempCon!=null)
                {
                    tempCon.Close();
                }
               
                return products;
                

            }
            catch (Exception ex)
            {
                return products;
            }
        }


        public static bool DeleteUserCartProd(int productId)
        {
            var conn = OpenConnection();


            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "delete_user_cart_product";

            command.Connection = conn;

            command.Parameters.Clear();
            command.Parameters.AddWithValue("@product_id", productId);


            SqlParameter success = new SqlParameter();
            success.ParameterName = "@success";
            success.Direction = ParameterDirection.Output;
            success.SqlDbType = SqlDbType.Int;
            success.Size = 1;

            command.Parameters.Add(success);


            command.ExecuteNonQuery();
            int response = Convert.ToInt32(command.Parameters["@success"].Value);
            conn.Close();
            if (response == 0)
            {
                return false;
            }
            return true;

           
        }

       public static List<Product> GetUserCartLogin(int id)
        {
            var conn = OpenConnection();




            string query = $"SELECT * FROM user_cart WHERE user_shop_id = {id}";

            SqlCommand command = new SqlCommand(query, conn);
            List<Product> products = new List<Product>();
            try
            {
                SqlDataReader reader = command.ExecuteReader();



                while (reader.Read())
                {
                    Product product = new Product();

                    product.Id = Convert.ToInt32(reader["id"]);
                    product.Description = reader["product_description"].ToString();
                    product.Price = Convert.ToDecimal(reader["product_price"]);


                    products.Add(product);



                }
                reader.Close();
                return products;


            }
            catch (Exception ex)
            {
                return products;
            }

        }



        public static bool FinishSell(int userId)
        {
            var conn = OpenConnection();


            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "finish_sell";

            command.Connection = conn;

            command.Parameters.Clear();
            command.Parameters.AddWithValue("@id_user", userId);

            SqlParameter success = new SqlParameter();
            success.ParameterName = "@success";
            success.Direction = ParameterDirection.Output;
            success.SqlDbType = SqlDbType.Int;
            success.Size = 1;

            command.Parameters.Add(success);

            try
            {
                command.ExecuteNonQuery();
                int response = Convert.ToInt32(command.Parameters["@success"].Value);
                conn.Close();

                if (response == 0)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {

                throw;
            }


          
        }



        public static void AddSells(string prod, string user)
        {
            var conn = OpenConnection();


            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "finish_sell_admin";

            command.Connection = conn;

            command.Parameters.Clear();
            command.Parameters.AddWithValue("@product_description", prod);
            command.Parameters.AddWithValue("@user_email", user);
            



            try
            {
                command.ExecuteNonQuery();
                conn.Close();

            }
            catch (Exception ex)
            {

                throw;
            }


        }




        public static List<Sells> GetManageOrders()
        {

            string query = $"SELECT * FROM sells";

            var conn = OpenConnection();
            SqlCommand command = new SqlCommand(query, conn);

            var list = new List<Sells>();

            SqlDataReader reader = command.ExecuteReader();



            try
            {
                while (reader.Read())
                {
                    var sells = new Sells();

                    sells.Id = Convert.ToInt32(reader["id"]);
                    sells.ProductDiscription = reader["product_discription"].ToString();
                    sells.UserEmail = reader["user_email"].ToString();


                    list.Add(sells);
                }

                return list;
            }
            finally
            {
                reader.Close();

            }
        }
    }
}