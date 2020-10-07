using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TimeZone.Resources;

namespace TimeZone
{
    public partial class DeleteUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = (User)Session["user"];

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

            if (!this.IsPostBack)
            {
                var fN = user.FirstName;
                var lN = user.LastName;
                var mail = user.Email;

                FN.Text = fN;
                LN.Text = lN;
                EM.Text = mail;
            }

        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            User user = (User)Session["user"];

            var email = user.Email;

            var response= DataBaseAccess.DeleteUser(email);

            if (response)
            {
                Response.Redirect("Index.aspx");
            }

        }



        protected void btnClose_Click(object sender, EventArgs e)
        {
            divModal.Visible = false;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            divModal.Visible = true;
        }
    }
}