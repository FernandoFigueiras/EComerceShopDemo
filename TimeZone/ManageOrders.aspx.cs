using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TimeZone.Resources;

namespace TimeZone
{
    public partial class ManageOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {
                LoadManageOrders();
            }

            User user = (User)Session["user"];

            var response = Request.QueryString["logout"];

            if (response != null && response == "true")
            {
                user.IsLogedIn = false;
                Response.Redirect("Index.aspx");
            }




            if (user == null)
            {
                Response.Redirect("Index.aspx");
            }

            if (user.Role == "Customer")
            {
                Response.Redirect("IndexLogedin.aspx");
            }

            if (!user.IsLogedIn)
            {
                Response.Redirect("Login.aspx");
            }



            userName.Text = user.Email;
        }

        private void LoadManageOrders()
        {
            var list = DataBaseAccess.GetManageOrders();


            Repeater1.DataSource = list;
            Repeater1.DataBind();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string email = string.Empty;

            string newQuery = $"Select * from sells where id = {Convert.ToInt32(((ImageButton)e.Item.FindControl("btnGo")).CommandArgument)}";
            var newConn = DataBaseAccess.OpenConnection();

            SqlCommand newCommand = new SqlCommand(newQuery, newConn);

            SqlDataReader reader = newCommand.ExecuteReader();

            
            while (reader.Read())
            {
                email = reader["user_email"].ToString();
            }
            string query = "DELETE FROM sells ";

            var conn = DataBaseAccess.OpenConnection();

            if (e.CommandName.Equals("btnGo"))
            {
                query += "WHERE id =" + ((ImageButton)e.Item.FindControl("btnGo")).CommandArgument;


                SqlCommand command = new SqlCommand(query, conn);

                command.ExecuteNonQuery();

                conn.Close();


            }


            
            conn.Close();
            var response = EmailService.SendConfirmationPackage(email);

            if (response)
            {
                LoadManageOrders();
            }

            

            

        }
    }
}