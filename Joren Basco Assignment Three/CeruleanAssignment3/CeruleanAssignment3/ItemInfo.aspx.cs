using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL_Project;
using System.Data;
using System.IO;

namespace CeruleanAssignment3
{
    public partial class ItemInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getItem();
            }
        }

        private void getItem()
        {
            DAL myDal = new DAL("Data Source=localhost; Initial Catalog=CeruleanProject3; Integrated Security=SSPI");
            myDal.AddParam("action", "r");
            myDal.AddParam("itemID", Request.QueryString["itemID"]);
            DataSet ds = myDal.ExecuteProcedure("spItem");
            divTitle.InnerHtml = "<h1>" + ds.Tables[0].Rows[0]["itemName"].ToString() + "</h1>";

            // --- SPLITS THE GENRE -- \\
            string fullGenre = ds.Tables[0].Rows[0]["itemGenre"].ToString();
            string[] sep = { "/" };
            string[] genres = fullGenre.Split(sep, StringSplitOptions.RemoveEmptyEntries);

            string allGenres = "";
            // --- prints my split genre --- \\
            for (int i = 0; i < genres.Length; i++)
            {
                string x = genres[i].ToString();
                allGenres += "<li><a href='Index.aspx?genre=" + x + "'>" + x + "</a></li>";
            }
            genreUl.InnerHtml = allGenres;
            //-------------------------------------------\\

            itemImg.Src = "\\Merch\\" + ds.Tables[0].Rows[0]["itemImg"];
            // divDescript.InnerHtml = "<b>"+ds.Tables[0].Rows[0]["itemDescription"].ToString()+"</b>";
            description.InnerText = ds.Tables[0].Rows[0]["itemDescription"].ToString();
            itemInfoPrice.InnerText = "$ " + ds.Tables[0].Rows[0]["itemPrice"].ToString();

        }

        protected void btnAddCart_ServerClick(object sender, EventArgs e)
        {

            addToCart();
            //Response.AddHeader("REFRESH", ".1;ItemInfo.aspx?itemID=" + Request.QueryString["itemID"]);
            Response.Redirect("Index.aspx?cart=go");
        }

        private void addToCart()
        {
            //DAL myDal = new DAL("Data Source=localhost; Initial Catalog=CeruleanProject3; Integrated Security=SSPI");
            //myDal.AddParam("action", "c");
            //myDal.AddParam("userID", (string)Session["userID"]);
            //myDal.AddParam("itemID", Request.QueryString["itemID"]);
            //myDal.AddParam("quantity", txtQty.Value);
            //myDal.ExecuteProcedure("spCart");

            ShoppingCartClass.CartItems myItem = new ShoppingCartClass.CartItems();
            myItem.AddtoCart(Request.QueryString["itemID"], (string)Session["userID"],txtQty.Value);



        }
    }
}