using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TimeZone.Resources;

namespace TimeZone
{
    public partial class ConfirmRecoverPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var email = Request.QueryString["email"].ToString();

            User user = DataBaseAccess.GtUserByEmail(email);

            lbl_email.Text = user.Email;
        }

        protected void btnChangePass_Click(object sender, EventArgs e)
        {
            var newP = newPass.Text;
            var email = lbl_email.Text;


            var newPEnc = Encryption.EncryptString(newP);


            var response = DataBaseAccess.EndRecoverPassword(email, newPEnc);

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
            Response.Redirect("Index.aspx");
        }

        protected void btnClose2_Click(object sender, EventArgs e)
        {
            divModal2.Visible = false;
            Response.Redirect("IndexLogedin.aspx");
        }
    }
}