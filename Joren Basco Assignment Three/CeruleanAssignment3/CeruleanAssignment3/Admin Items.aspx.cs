using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CeruleanAssignment3
{
    public partial class Admin_Items : System.Web.UI.Page
    {
        string conn = "Data Source=localhost; Initial Catalog=CeruleanProject3; Integrated Security=SSPI;";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((string)Session["UserSecurity"] != "Admin")
                {
                    Response.Redirect("Index.aspx");
                }
                getItems();
                Session["SortDirectionAdminItem"] = "Ascending";
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            DAL_Project.DAL myDal = new DAL_Project.DAL(conn);
            int index;
            if (int.TryParse(e.CommandArgument.ToString(), out index))
            {
                index = Convert.ToInt32(e.CommandArgument);

                gvItems.SelectedIndex = index;
            }


            if (e.CommandName == "del")
            {
                ItemClass.Item myItem = new ItemClass.Item();
                myItem.deleteItem(gvItems.SelectedDataKey.Value.ToString());
                Response.AddHeader("REFRESH", ".1;Admin%20Items.aspx");
            }
            else if (e.CommandName == "upd")
            {
                myDal.AddParam("action", "r");
                myDal.AddParam("itemID", gvItems.SelectedDataKey.Value.ToString());
                DataSet ds = myDal.ExecuteProcedure("spItem");
                txtItemID.Text = ds.Tables[0].Rows[0]["itemID"].ToString();
                txtItemName.Text = ds.Tables[0].Rows[0]["itemName"].ToString();
                txtItemDescript.Text = ds.Tables[0].Rows[0]["itemDescription"].ToString();
                txtItemPrice.Text = ds.Tables[0].Rows[0]["itemPrice"].ToString();
                txtItemGenre.Text = ds.Tables[0].Rows[0]["itemGenre"].ToString();
                imgItem.ImageUrl = "\\Merch\\" + ds.Tables[0].Rows[0]["itemImg"].ToString();
                txtStock.Text = ds.Tables[0].Rows[0]["itemStock"].ToString();
                pnlItemUpdate.Visible = true;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtItemID.Text != "")
            {
                ItemClass.Item myItem = new ItemClass.Genre(txtItemName.Text, txtItemPrice.Text, txtItemDescript.Text, txtItemGenre.Text, flItemImage.FileName, txtStock.Text);
                myItem.updateItem(txtItemID.Text);
            }
            else
            {
                // Create new Item //
                ItemClass.Item myItem = new ItemClass.Genre(txtItemName.Text, txtItemPrice.Text, txtItemDescript.Text, txtItemGenre.Text, flItemImage.FileName, txtStock.Text);
                myItem.enterToDB();

            }


            if (flItemImage.FileName != "")
            {
                SavePic();
            }
            Response.AddHeader("REFRESH", ".1;Admin%20Items.aspx");
        }
        private void getItems()
        {
            DAL_Project.DAL myDal = new DAL_Project.DAL("Data Source=localhost; Initial Catalog=CeruleanProject3; Integrated Security=SSPI;");
            myDal.AddParam("action", "r");
            DataSet ds = myDal.ExecuteProcedure("spItem");
            gvItems.DataSource = ds;
            gvItems.DataBind();

        }


        protected void gvItems_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvItems.PageIndex = e.NewPageIndex;
            if ((string)Session["SortbyAdminItem"] != null)
            {
                getsortedItem();
            }
            else
            {
                getItems();
            }


        }

        protected void gvItems_Sorting(object sender, GridViewSortEventArgs e)
        {
            string sortby = e.SortExpression.ToString();
            Session["SortbyAdminItem"] = sortby;
            if ((string)Session["SortDirectionAdminItem"] == "Ascending")
            {
                Session["SortDirectionAdminItem"] = "Descending";
            }
            else if ((string)Session["SortDirectionAdminItem"] == "Descending")
            {
                Session["SortDirectionAdminItem"] = "Ascending";
            }
            //string  direction = Session["SortDirectionAdminItem"].ToString();
            //DAL_Project.DAL mydal = new DAL_Project.DAL("Data Source=localhost; Initial Catalog=CeruleanProject3; Integrated Security=SSPI;");
            //mydal.AddParam("item", sortby);
            //mydal.AddParam("direction", direction);
            //gvItems.DataSource = mydal.ExecuteProcedure("spSortItemAdmin");
            //gvItems.DataBind();
            getsortedItem();

        }
        private void getsortedItem()
        {
            string sortby = Session["SortbyAdminItem"].ToString();
            string direction = Session["SortDirectionAdminItem"].ToString();
            DAL_Project.DAL mydal = new DAL_Project.DAL("Data Source=localhost; Initial Catalog=CeruleanProject3; Integrated Security=SSPI;");
            mydal.AddParam("item", sortby);
            mydal.AddParam("direction", direction);
            gvItems.DataSource = mydal.ExecuteProcedure("spSortItemAdmin");
            gvItems.DataBind();
        }

        protected void btnAddnew_ServerClick(object sender, EventArgs e)
        {
            pnlItemUpdate.Visible = true;
            txtItemID.Text = "";
            txtItemName.Text = "";
            txtItemDescript.Text = "";
            txtItemPrice.Text = "";
            txtItemGenre.Text = "";

            txtStock.Text = "";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            pnlItemUpdate.Visible = false;
            txtItemID.Text = "";
            txtItemName.Text = "";
            txtItemDescript.Text = "";
            txtItemPrice.Text = "";
            txtItemGenre.Text = "";

            txtStock.Text = "";
        }
        private void SavePic()
        {
            string serverPath = Server.MapPath(".") + "\\Merch\\";
            string fileName = flItemImage.FileName;
            string pathAndfile = serverPath + fileName;
            flItemImage.PostedFile.SaveAs(pathAndfile);
        }
    }
}