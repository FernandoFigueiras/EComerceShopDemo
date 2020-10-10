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
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = (User)Session["user"];


            var tempList = (List<Product>)Session["tempList"];

            if (user == null)
            {
                if (!this.IsCallback)
                {
                    LoadCartTemp();
                }
            }
            else
            {

                if (tempList!=null)
                {
                    if (!this.IsCallback)
                    {
                        LoadUserCart();
                    }
                    
                }
                else
                {
                    GetLogedInCart(user.Id);
                }
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

        private void LoadCartTemp()
        {

            var user = (User)Session["user"];

            var conn = (SqlConnection)Session["conn"];


            var list = DataBaseAccess.GetTempCart(conn);

            

            Repeater1.DataSource = list;
            Repeater1.DataBind();

            decimal count = 0;
            foreach (var item in list)
            {
                count += item.Price;
            }


            if (user != null)
            {
                if (user.Role == "Customer")
                {
                    LblTotal.Text = count.ToString() + "Euros";
                }
                else if (user.Role == "Resseler")
                {
                    count = count - (count * 20 / 100);
                    LblTotal.Text = count.ToString() + "Euros";
                }
            }

            LblTotal.Text = count.ToString() + "Euros";


        }


        private void LoadUserCart()
        {
            var user = (User)Session["user"];

            var conn = (SqlConnection)Session["conn"];


            var list = DataBaseAccess.GetUserCart(conn, user.Id);



            

            Repeater1.DataSource = list;
            Repeater1.DataBind();

            decimal count = 0;
            foreach (var item in list)
            {
                count += item.Price;
            }


            if (user != null)
            {
                if (user.Role == "Customer")
                {
                    LblTotal.Text = count.ToString() + "Euros";
                }
                else if (user.Role == "Resseler")
                {
                    count = count - (count * 20 / 100);
                    LblTotal.Text = count.ToString() + "Euros";
                }
            }

            LblTotal.Text = count.ToString() + "Euros";
        }

        private void GetLogedInCart(int id)
        {

            var user = (User)Session["user"];

            var list = DataBaseAccess.GetUserCartLogin(id);

                 Repeater1.DataSource = list;
            Repeater1.DataBind();

            decimal count = 0;
            foreach (var item in list)
            {
                count += item.Price;
            }


            if (user != null)
            {
                if (user.Role == "Customer")
                {
                    LblTotal.Text = count.ToString() + "Euros";
                }
                else if (user.Role == "Resseler")
                {
                    count = count - (count * 20 / 100);
                    LblTotal.Text = count.ToString() + "Euros";
                }
            }

            LblTotal.Text = count.ToString() + "Euros";
        }

    }
}