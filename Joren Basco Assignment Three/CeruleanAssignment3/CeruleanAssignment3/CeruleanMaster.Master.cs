using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL_Project;
using System.Data;
using System.Web.Script.Serialization;
using System.IO;
using Newtonsoft.Json;

namespace CeruleanAssignment3
{
    public partial class CeruleanMaster : System.Web.UI.MasterPage
    {
        string conn = "Data Source=localhost;Initial Catalog=CeruleanProject3;Integrated Security=SSPI";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserSecurity"] != null)
                {
                    liLogin.Visible = false;
                    liSignup.Visible = false;
                    liProfile.Visible = true;
                    liLogOut.Visible = true;
                    liOrderReview.Visible = true;
                    shop.Visible = true;
                    if((string)Session["UserSecurity"] == "Admin")
                    {
                        liAdminOrders.Visible = true;
                        liAdminUser.Visible = true;
                        liAdminItems.Visible = true;
                    }
                }
                if (Session["userID"] != null)
                {
                    getCart();
                    getTotalAmount();

                    if (cartRepeater.Items.Count <= 0)
                    {
                        modalBody.InnerText = "NO ITEMS IN CART";
                    }
                }
                else
                {
                    modalBody.InnerText = "NO ITEMS IN CART";
                }

            }

        }
        private void getCart()
        {
            ShoppingCartClass.CartItems myCart = new ShoppingCartClass.CartItems();
            cartRepeater.DataSource = myCart.GetCartItems();
            cartRepeater.DataBind();
           


        }

        protected void cartRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            DAL myDal = new DAL(conn);

            if (e.CommandName == "cmd_add")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                int item = e.Item.ItemIndex;
                myDal.AddParam("cartID", id.ToString());
                myDal.AddParam("userID", (string)Session["userID"]);
                myDal.AddParam("action", "u");
                string qty = ((Label)cartRepeater.Items[item].FindControl("lblCartQty")).Text;
                int newQty = Convert.ToInt32(qty) + 1;
                myDal.AddParam("quantity", newQty.ToString());
                myDal.ExecuteProcedure("spCart");
                getCart();
                getTotalAmount();

            }
            else if (e.CommandName == "cmd_minus")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                int item = e.Item.ItemIndex;
                myDal.AddParam("cartID", id.ToString());
                int qty = Convert.ToInt32(((Label)cartRepeater.Items[item].FindControl("lblCartQty")).Text);
                if (qty <= 1)
                {
                    myDal.AddParam("action", "d");
                    myDal.ExecuteProcedure("spCart");
                }
                else
                {
                    myDal.AddParam("userID", (string)Session["userID"]);
                    myDal.AddParam("action", "u");

                    qty = qty - 1;
                    myDal.AddParam("quantity", qty.ToString());
                    myDal.ExecuteProcedure("spCart");
                }
                getCart();
                getTotalAmount();
            }
        }

        protected void submitOrder_Click(object sender, EventArgs e)
        {
            wsEnterOrders myOrder = new wsEnterOrders();

            string orderid = myOrder.getOrderID((string)Session["userID"], lblTotal.Text);

            wsEnterOrderItems myOrderItem = new wsEnterOrderItems();
            
            foreach (RepeaterItem dataItem in cartRepeater.Items)
            {
                HiddenField item = (HiddenField)dataItem.FindControl("hdnItemID");
                Label quantity = (Label)dataItem.FindControl("lblCartQty");
                string id = item.Value;
                string qty = quantity.Text;
                myOrderItem.submitOrder(orderid, id, qty);

            }
            ShoppingCartClass.CartItems myCartCookie = new ShoppingCartClass.CartItems();
            myCartCookie.clearCookie();
            Response.Redirect("OrderReview.aspx");
        }

        protected void btnLogOut_ServerClick(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.AddHeader("REFRESH", ".1;Index.aspx");
            
        }

        private void getTotalAmount()
        {
            DAL myDal = new DAL(conn);
            myDal.AddParam("action", "t");
            myDal.AddParam("userID", (string)Session["userID"]);
            DataSet ds = myDal.ExecuteProcedure("spCart");
            //if ((string)Session["tempo"] != "")
            //{
            //    lblTotal.Text = ds.Tables[0].Rows[0]["totalAmount"].ToString();
            //    if(lblTotal.Text != "")
            //    {

            //    double discounted = Convert.ToDouble(lblTotal.Text) * .9;
            //    lblTotal.Text = discounted.ToString();
            //    divQpon.InnerHtml = "CODE: Tempo 10% OFF";
            //    btnQpon.Visible = false;
            //    }
            //}
            //else
            //{
                lblTotal.Text = ds.Tables[0].Rows[0]["totalAmount"].ToString();
            

        }

        protected void btnSearch_ServerClick(object sender, EventArgs e)
        {
            Session["searchBar"] = txtSearch.Value;
            Response.AddHeader("REFRESH", ".1;Index.aspx");
        }

        //protected void btnEnterQpon_ServerClick(object sender, EventArgs e)
        //{
        //    if (txtQpon.Value == "tempo" || txtQpon.Value == "TEMPO")
        //    {
        //        double discounted = Convert.ToDouble(lblTotal.Text) * .9;
        //        lblTotal.Text = discounted.ToString();
        //        divQpon.InnerHtml = "CODE: Tempo 10% OFF";
        //        btnQpon.Visible = false;
        //        Session["tempo"] = discounted;

        //    }
        //    else
        //    {
        //        txtQpon.Value = "Invalid Code";
        //    }
        //}

        //protected void btnQpon_ServerClick(object sender, EventArgs e)
        //{
        //    if(divQpon.Visible == false)
        //    {
        //        divQpon.Visible = true;
        //    }
        //    else
        //    {
        //        divQpon.Visible = false;
        //    }
        //}
    }
}