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
    public partial class ManageResselers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                GetActiveResselers();

                GetInactiveResselers();
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



        private void GetInactiveResselers()
        {
            Repeater1.DataSource = DataBaseAccess.GetInactiveResselers();
            Repeater1.DataBind();

            if (Repeater1.Items.Count == 0)
            {
                InactiveRlabel.Visible = true;
                activeRlabel.Visible = false;
            }
            else
            {
                InactiveR.Visible = true;
                activeR.Visible = false;
            }
        }



        private void GetActiveResselers()
        {
            Repeater2.DataSource = DataBaseAccess.GetActiveResselers();
            Repeater2.DataBind();


            if (Repeater2.Items.Count == 0)
            {
                activeRlabel.Visible = true;
                InactiveRlabel.Visible = false;
            }
            else
            {
                activeR.Visible = true;
                InactiveR.Visible = false;
            }
        }


        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

            string query = "UPDATE shop_user SET ";

            var conn = DataBaseAccess.OpenConnection();




            if (e.CommandName.Equals("btnNo"))
            {
                query += "role = 'Customer' ";
                query += "WHERE id =" + ((ImageButton)e.Item.FindControl("btnNo")).CommandArgument;


                SqlCommand command = new SqlCommand(query, conn);

                command.ExecuteNonQuery();

                conn.Close();
            }

            if (e.CommandName.Equals("btnYes"))
            {
                query += "is_resseler = 1 ";
                query += "WHERE id = " + ((ImageButton)e.Item.FindControl("btnYes")).CommandArgument;


                SqlCommand command = new SqlCommand(query, conn);

                command.ExecuteNonQuery();

                conn.Close();
            }

            GetActiveResselers();

            GetInactiveResselers();
        }


    }
}