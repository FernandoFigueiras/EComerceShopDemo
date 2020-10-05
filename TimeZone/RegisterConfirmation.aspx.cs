using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TimeZone.Resources;

namespace TimeZone
{
    public partial class RegisterConfirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var registerNumber = Request.QueryString["id"].ToString();
            var email = Request.QueryString["email"].ToString();

            var regNumb = Encryption.DecryptString(registerNumber);

            var success = DataBaseAccess.ConfirmRegistration(email, regNumb);

            if (!success)
            {
                divModalNoSuccess.Visible = true;
            }

        }

        protected void CloseModal(object sender, EventArgs e)
        {
            divModalNoSuccess.Visible = false;
            Response.Redirect("Login.aspx");
        }
    }
}