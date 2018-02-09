using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL_Project;
using System.Data;

namespace CeruleanAssignment3
{
    public partial class AdminOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((string)Session["UserSecurity"] != "Admin")
                {
                    Response.Redirect("Index.aspx");
                }
                getallOrderID();
            }
        }
        private void getOrders(string id)
        {
            DAL myDal = new DAL("Data Source=localhost;Initial Catalog=CeruleanProject3;Integrated Security=SSPI");
            myDal.AddParam("action", "a");
            myDal.AddParam("OrderID", id);
            gvOrders.DataSource = myDal.ExecuteProcedure("spOrder");
            gvOrders.DataBind();
        }
        private void getallOrderID()
        {
            DAL myDal = new DAL("Data Source=localhost;Initial Catalog=CeruleanProject3;Integrated Security=SSPI");
            myDal.AddParam("action", "r");
            DataSet ds = myDal.ExecuteProcedure("spOrder");
            ddlOrderID.DataSource = ds;
            ddlOrderID.DataValueField = "orderID";
            ddlOrderID.DataTextField = "orderID";
            ddlOrderID.DataBind();
        }

        protected void btnSelectDDL_Click(object sender, EventArgs e)
        {
            string id = ddlOrderID.SelectedValue;

            getOrders(id);


        }

        protected void gvOrders_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            DAL myDal = new DAL("Data Source=localhost;Initial Catalog=CeruleanProject3;Integrated Security=SSPI");
            int index = Convert.ToInt32(e.CommandArgument);
            gvOrders.SelectedIndex = index;

           if(e.CommandName == "del")
            {
                myDal.AddParam("action", "d");
                myDal.AddParam("orderItemID", gvOrders.SelectedDataKey.Value.ToString());
                myDal.ExecuteProcedure("spOrderItems");
                myDal.ClearParams();
                Response.AddHeader("REFRESH", ".1;AdminOrders.aspx");
            }
           else if(e.CommandName == "upd")
            {
                myDal.AddParam("action", "y");
                myDal.AddParam("orderItemID", gvOrders.SelectedDataKey.Value.ToString());
                DataSet ds = myDal.ExecuteProcedure("spOrderItems");
                txtAdminOrderID.Text = ds.Tables[0].Rows[0]["orderID"].ToString();
                txtAdminOrderItemID.Text= ds.Tables[0].Rows[0]["orderItemID"].ToString();
                txtAdminUserID.Text = ds.Tables[0].Rows[0]["userID"].ToString();
                txtAdminItemID.Text = ds.Tables[0].Rows[0]["itemID"].ToString();
                txtAdminItem.Text = ds.Tables[0].Rows[0]["itemName"].ToString();
                txtAdminItemPrice.Text = ds.Tables[0].Rows[0]["itemPrice"].ToString();
                txtAdminItemQty.Text = ds.Tables[0].Rows[0]["quantity"].ToString();
                txtAdminUserEmail.Text = ds.Tables[0].Rows[0]["userEmail"].ToString();
                txtAdminFirstName.Text = ds.Tables[0].Rows[0]["firstName"].ToString();
                txtAdminLastName.Text = ds.Tables[0].Rows[0]["lastName"].ToString();
                txtAdminPhone.Text = ds.Tables[0].Rows[0]["phone"].ToString();
                txtAdminAddress.Text = ds.Tables[0].Rows[0]["address"].ToString();
                pnlUpdateOrders.Visible = true;
            }
        }

        protected void btnSaveUpdate_Click(object sender, EventArgs e)
        {
            DAL myDal = new DAL("Data Source=localhost;Initial Catalog=CeruleanProject3;Integrated Security=SSPI");
            myDal.AddParam("orderID", txtAdminOrderID.Text);
            myDal.AddParam("orderItemID", txtAdminOrderItemID.Text);
            myDal.AddParam("quantity", txtAdminItemQty.Text);
            myDal.AddParam("itemID", txtAdminItemID.Text);           
            myDal.AddParam("userID", txtAdminUserID.Text);
            myDal.ExecuteProcedure("spUpdateOrder");

            Response.AddHeader("REFRESH", ".1;AdminOrders.aspx");
        }
    }
}