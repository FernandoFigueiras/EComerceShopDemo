using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TimeZone.Resources;

namespace TimeZone
{
    public partial class RecoverPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            var email = eMail.Text;



            var response = DataBaseAccess.RecoverPassword(email);


            if (response)
            {
                var result = EmailService.SendRecoverPasswordEmail(email);

                if (result)
                {
                    divModal.Visible = true;
                }
                
            }
            else
            {
                divModal2.Visible = true;
            }
        }

        protected void btnClose2_Click(object sender, EventArgs e)
        {
            divModal.Visible = false;
            Response.Redirect("Index.aspx");

        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            divModal2.Visible = false;
            Response.Redirect("Index.aspx");
        }
    }
}