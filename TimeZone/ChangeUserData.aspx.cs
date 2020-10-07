using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TimeZone.Resources;

namespace TimeZone
{
    public partial class ChangeUserData : System.Web.UI.Page
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


                fName.Text = fN;
                lName.Text = lN;
            }
            
        }


        protected void btnChange_Click(object sender, EventArgs e)
        {
            

            var fN = fName.Text;
            var lN = lName.Text;

            User user = (User)Session["user"];

            user.FirstName = fN;
            user.LastName = lN;

            var response = DataBaseAccess.ChangeUserData(fN, lN, user.Email);

            if (response)
            {
                divModal.Visible = true;
            }
            else
            {
                divModal2.Visible = true;
            }

        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            divModal.Visible = false;
            Response.Redirect("IndexLogedin.aspx");
        }

        protected void btnClose2_Click(object sender, EventArgs e)
        {
            divModal.Visible = false;
            Response.Redirect("IndexLogedin.aspx");
        }
    }
}