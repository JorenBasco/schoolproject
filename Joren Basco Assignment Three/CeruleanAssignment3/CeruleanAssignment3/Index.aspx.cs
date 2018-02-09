using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL_Project;
using System.Web.UI.HtmlControls;
using System.Data;

namespace CeruleanAssignment3
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["genre"] != null)
                {
                    string genre = Request.QueryString["genre"];
                    getItemByGenre(genre);
                }
                else if (Session["searchBar"] != null)
                {
                    string search = (string)Session["searchBar"];
                    getSearchedItem(search);

                }
                else
                {

                    getItems();
                }

                if(Session["userID"] != null)
                {
                    if((string)Session["UserSecurity"] == "Admin")
                    {

                    }else if((string)Session["UserSecurity"] != "Customer")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Verify your Email')", true);
                        
                    }
                }
            }

        }

        private void getItems()
        {
            DAL myDal = new DAL("Data Source=localhost; Initial Catalog=CeruleanProject3; Integrated Security=SSPI");
            myDal.AddParam("action", "R");
            homeItemRepeater.DataSource = myDal.ExecuteProcedure("spItem");
            homeItemRepeater.DataBind();


        }


        protected void homeItemRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
            Response.Redirect("ItemInfo.aspx?itemID=" + id);
        }
        private void getItemByGenre(string genre)
        {
            DAL myDal = new DAL("Data Source=localhost; Initial Catalog=CeruleanProject3; Integrated Security=SSPI");
            myDal.AddParam("action", "G"); // (G)enre
            myDal.AddParam("itemGenre", genre);
            homeItemRepeater.DataSource = myDal.ExecuteProcedure("spItem");
            homeItemRepeater.DataBind();
        }
        private void getSearchedItem(string search)
        {
            DAL myDal = new DAL("Data Source=localhost; Initial Catalog=CeruleanProject3; Integrated Security=SSPI");
            myDal.AddParam("search", search);
            DataSet ds = myDal.ExecuteProcedure("spSearchBar");
            if (ds.Tables[0].Rows.Count <= 0)
            {
                divSearchError.InnerHtml =
                    "<b> No Item Found.. Please try again.. </b> <br/> <img src='Merch/Purge.gif' />";

            }
            else
            {
                homeItemRepeater.DataSource = ds;
                homeItemRepeater.DataBind();
            }
            Session["searchBar"] = "";
        }


    }
}