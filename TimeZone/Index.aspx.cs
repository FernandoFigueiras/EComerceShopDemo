using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TimeZone.Data;
using TimeZone.Resources;

namespace TimeZone
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            var list = (List<Product>)Session["tempList"];

            if (!this.IsPostBack)
            {
                var conn = DataBaseAccess.OpenTempData();

                if (list ==null)
                {
                    DataBaseAccess.CreateTempTable(conn);

                    Session["conn"] = conn;
                }

               
            }
          
        }
    }
}