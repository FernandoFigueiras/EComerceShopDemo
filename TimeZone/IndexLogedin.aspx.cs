using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TimeZone
{
    public partial class IndexLogedin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = (User)Session["user"];

            var response = Request.QueryString["logout"];

            if (response != null && response == "true")
            {
                user.IsLogedIn = false;
                Response.Redirect("Login.aspx");
            }


            if (user == null)
            {
                Response.Redirect("Index.aspx");
            }

            if (user.IsActive == 0)
            {
                Response.Redirect("Index.aspx");
            }

            if (user.Role == "Admin")
            {
                Response.Redirect("IndexLogedInAdmin.aspx");
            }


            if (!user.IsLogedIn)
            {
                Response.Redirect("Index.aspx");
            }


            userName.Text = user.Email;
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            
        }
    }
}