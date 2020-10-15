using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TimeZone.Data;
using TimeZone.Resources;

namespace TimeZone
{
    public partial class Shop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           

            if (!this.IsPostBack)
            {

                LoadShop();

                var orderType = Request.QueryString["order"];

                if (orderType == "orderPrice")
                {
                    LoadShopByPrice();
                }
                if (orderType == "orderName")
                {
                    LoadShopByName();
                }
            }

            

            var user = (User)Session["user"];

            var conn = (SqlConnection)Session["conn"];

            if (user!= null && user.IsLogedIn == true)
            {
                NotLog.Visible = false;
                Log.Visible = true;

                var response = Request.QueryString["logout"];

                if (response != null && response == "true")
                {
                    user.IsLogedIn = false;
                    Response.Redirect("Login.aspx");
                }


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



        }

        private void LoadShopByName()
        {
            var list = DataBaseAccess.GetProducts();
            list = list.OrderBy(l => l.Description).ToList();

            Repeater1.DataSource = list;
            Repeater1.DataBind();
        }

        private void LoadShopByPrice()
        {
            var list = DataBaseAccess.GetProducts();
            list = list.OrderBy(l => l.Price).ToList();

            Repeater1.DataSource = list;
            Repeater1.DataBind();
        }

        private void LoadShop()
        {
            var list = DataBaseAccess.GetProducts();


            Repeater1.DataSource = list;
            Repeater1.DataBind();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

            var user = (User)Session["user"];


            var conn = (SqlConnection)Session["conn"];
            if (e.CommandName.Equals("btnAdd"))
            {

                var id = Convert.ToInt32(((ImageButton)e.Item.FindControl("btnAdd")).CommandArgument);

                var product = DataBaseAccess.GtProductByID(id);


                if (product != null)
                {
                    if (user==null)
                    {
                        var result = DataBaseAccess.UpdateCartTableTemp(id, product.Description, product.Price, conn);

                        if (!result)
                        {
                            divModal.Visible = true;
                        }
                    }
                    else
                    {
                        DataBaseAccess.UpdateCartUser(user, id, product.Description, product.Price);
                    }
                    
                }

                
            }

            var list = DataBaseAccess.GetTempCart(conn);

            Session["tempList"] = list;
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            divModal.Visible = false;
        }
    }
}