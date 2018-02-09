using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
namespace CeruleanAssignment3.ShoppingCartClass
{
    public class ShoppingCart
    {
        public string itemID { get; set; }

        public string userID { get; set; }

        public string itemImg { get; set; }

        public string itemName { get; set; }
        public string itemPrice { get; set; }
        public string quantity { get; set; }
        public string cartID { get; set; }

        public ShoppingCart() { }

        public ShoppingCart(string ItemID, string UserID)
        {
            this.itemID = ItemID;
            this.userID = UserID;
            DAL_Project.DAL myDal = new DAL_Project.DAL("Data Source=localhost; Initial Catalog=CeruleanProject3; Integrated Security=SSPI");
            myDal.AddParam("action", "r");
            myDal.AddParam("userID",UserID);
            DataSet ds = myDal.ExecuteProcedure("spCart");
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    this.cartID = ds.Tables[0].Rows[i]["cartID"].ToString();
                    this.itemImg = ds.Tables[0].Rows[i]["itemImg"].ToString();
                    this.itemName = ds.Tables[0].Rows[i]["itemName"].ToString();
                    this.itemPrice = ds.Tables[0].Rows[i]["itemPrice"].ToString();
                    this.quantity = ds.Tables[0].Rows[i]["quantity"].ToString();
                }
            }

        }
    }
}