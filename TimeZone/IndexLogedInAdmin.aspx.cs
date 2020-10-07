using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TimeZone
{
    public partial class IndexLogedInAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = (User)Session["user"];

            var response = Request.QueryString["logout"];

            if (response !=null && response == "true" )
            {
                user.IsLogedIn = false;
                Response.Redirect("Login.aspx");
            }


           

            if (user == null)
            {
                Response.Redirect("Login.aspx");
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


    }
}