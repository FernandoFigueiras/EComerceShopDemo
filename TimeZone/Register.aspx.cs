using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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


            if (fname != null && lname!=null && email != null && password!=null)
            {
                SqlConnection con = new SqlConnection()
            }
        }
    }
}