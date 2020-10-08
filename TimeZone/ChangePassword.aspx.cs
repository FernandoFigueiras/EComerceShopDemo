using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TimeZone.Resources;

namespace TimeZone
{
    public partial class ChangePassword : System.Web.UI.Page
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

           

        }

        protected void btnChangePass_Click(object sender, EventArgs e)
        {

            User user = (User)Session["user"];

            if (user == null)
            {
                Response.Redirect("Index.aspx");
            }

            var oldP = oldPass.Text;
            var newP = newPass.Text;

            var oldPEnc = Encryption.EncryptString(oldP);
            var newPEnc = Encryption.EncryptString(newP);


            var response = DataBaseAccess.ChangePassword(user.Email, oldPEnc, newPEnc);

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