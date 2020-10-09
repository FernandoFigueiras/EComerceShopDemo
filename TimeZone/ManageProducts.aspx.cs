using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TimeZone.Resources;

namespace TimeZone
{
    public partial class ManageProducts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                LoadData();
            }

            User user = (User)Session["user"];

            var response = Request.QueryString["logout"];

            if (response != null && response == "true")
            {
                user.IsLogedIn = false;
                Response.Redirect("Index.aspx");
            }




            if (user == null)
            {
                Response.Redirect("Index.aspx");
            }

            if (user.Role == "Customer")
            {
                Response.Redirect("IndexLogedin.aspx");
            }

            if (!user.IsLogedIn)
            {
                Response.Redirect("Login.aspx");
            }



            userName.Text = user.Email;
        }

        private void LoadData()
        {
            Repeater1.DataSource = DataBaseAccess.GetProducts();
            Repeater1.DataBind();
        }

        protected void btnInsertProd_Click(object sender, EventArgs e)
        {
            var pDesc = prodDescript.Text;
            var pPrice = prodPrice.Text;
            var pStock = prodStock.Text;

            int numb;

            decimal dec;

            if (!decimal.TryParse(pPrice,out dec))
            {
                Response.Redirect("ManageProducts.aspx");
            }

            if (!int.TryParse(pStock, out numb))
            {
                Response.Redirect("ManageProducts.aspx");
            }

            var price = Convert.ToDecimal(pPrice);
            var stock = Convert.ToInt32(pStock);




            var result = DataBaseAccess.AddProduct(pDesc, price, stock);


            if (result)
            {
                Response.Redirect("ManageProducts.aspx");
            }
            else
            {
                divModal.Visible = true;
            }

            LoadData();

        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            divModal.Visible = false;
        }






        protected void btn_edit_Click(object sender, EventArgs e)
        {
            ProdShow.Visible = false;
            EditProd.Visible = true;
        }





        protected void Repeater2_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView dr = (DataRowView)e.Item.DataItem;


                ((Label)e.Item.FindControl("lblId")).Text = dr["id"].ToString();
                ((TextBox)e.Item.FindControl("tb_description")).Text = dr["product_description"].ToString();
                ((TextBox)e.Item.FindControl("tb_price")).Text = dr["product_price"].ToString();
                ((TextBox)e.Item.FindControl("tb_stock")).Text = dr["stock"].ToString();
            }
        }



        protected void Repeater2_ItemCommand1(object source, RepeaterCommandEventArgs e)
        {
            

            var conn = DataBaseAccess.OpenConnection();



            if (e.CommandName.Equals("btnSave"))
            {
                string query = "UPDATE products set ";


                query += "product_description='" + ((TextBox)e.Item.FindControl("tb_description")).Text + "',";
                query += "product_price='" + ((TextBox)e.Item.FindControl("tb_price")).Text + "',";
                query += "stock='" + ((TextBox)e.Item.FindControl("tb_stock")).Text + "'";
                query += "WHERE id =" + ((Label)e.Item.FindControl("lblId")).Text;


                SqlCommand command = new SqlCommand(query, conn);

                command.ExecuteNonQuery();

                conn.Close();
                LoadData();
            }

            if (e.CommandName.Equals("btnDelete"))
            {
                string query = "DELETE FROM products ";

                query += "WHERE id =" + ((Label)e.Item.FindControl("lblId")).Text;


                SqlCommand command = new SqlCommand(query, conn);

                command.ExecuteNonQuery();

                conn.Close();

                Response.Redirect("ManageProducts.aspx");
            }

        }
    }
}