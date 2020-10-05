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
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void registerButton_Click(object sender, EventArgs e)
        {
            var fname = fName.Text;
            var lname = lName.Text;
            var email = eMail.Text;
            var password = passWd.Text;
            var randNumber = new Random();
            var numb = randNumber.Next(1000);

            if (fname != null && lname!=null && email != null && password!=null)
            {
                var encPassword = Encryption.EncryptString(password);


                var result = DataBaseAccess.RegisterUser(fname, lname, email, encPassword, "Customer", numb.ToString());

                if (!result)
                {
                    divModal.Visible = true;
                }
                else
                {

                    var registerNumb = Encryption.EncryptString(numb.ToString());

                   var emailResult = EmailService.SendRegisterEmail(email, registerNumb);

                    if (emailResult)
                    {
                        divModal2.Visible = true;
                    }
                }
            }
        }



        protected void btnClose_Click(object sender, EventArgs e)
        {
            divModal.Visible = false;
        }

        protected void btnClose2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}