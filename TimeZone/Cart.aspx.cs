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
            if (!this.IsPostBack)
            {
                if (user == null)
                {
                    if (!this.IsPostBack)
                    {
                        LoadCartTemp();
                    }
                }
                else
                {

                    if (tempList != null)
                    {
                        if (!this.IsPostBack)
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

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            var tempList = (List<Product>)Session["tempList"];

            var user = (User)Session["user"];

            if (user == null)
            {
                var conn = (SqlConnection)Session["conn"];

                if (e.CommandName.Equals("btnDel"))
                {


                    var product = Convert.ToInt32(((ImageButton)e.Item.FindControl("btnDel")).CommandArgument);


                    var response = DataBaseAccess.DeleteTempCartProduct(product, conn);


                    if (response)
                    {

                        var itemToRemove = tempList.SingleOrDefault(r => r.Id == product);
                        if (itemToRemove != null)
                            tempList.Remove(itemToRemove);
                        Session["tempList"] = tempList;

                        LoadCartTemp();
                    }

                    
                }
                
            }
            else
            {

                var conn = new SqlConnection();

                if (e.CommandName.Equals("btnDel"))
                {
                    var product = Convert.ToInt32(((ImageButton)e.Item.FindControl("btnDel")).CommandArgument);


                    var response = DataBaseAccess.DeleteUserCartProd(product);

                    GetLogedInCart(user.Id);
                }


            }



            
        }
    }
}