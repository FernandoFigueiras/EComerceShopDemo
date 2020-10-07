using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TimeZone.Resources;

namespace TimeZone
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void logInButton_Click(object sender, EventArgs e)
        {
            var email = userName.Text;
            var pass = passWd.Text;
            var encryPass = Encryption.EncryptString(pass);

            var user = DataBaseAccess.LoginUser(email, encryPass);



            if (user.Email== null)
            {
                divModal.Visible = true;
                return;
            }
            else if (user.IsActive == 0)
            {
                divModal2.Visible = true;
                return;
            }

            user.IsLogedIn = true;


            Session["user"] = user;

            if (user.Role == "Customer")
            {
                Response.Redirect("IndexLogedin.aspx");
            }
            else if (user.Role == "Admin")
            {
                Response.Redirect("IndexLogedInAdmin.aspx");
            }

            

        }


        protected void btnClose1_Click1(object sender, EventArgs e)
        {
            divModal.Visible = false;
        }

        protected void btnClose2_Click(object sender, EventArgs e)
        {
            divModal2.Visible = false;
        }
    }
}