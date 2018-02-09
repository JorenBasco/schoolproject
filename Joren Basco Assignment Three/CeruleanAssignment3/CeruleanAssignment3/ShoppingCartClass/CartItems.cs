using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Data;

namespace CeruleanAssignment3.ShoppingCartClass
{
    public class CartItems
    {
        public List<ShoppingCart> _CartItems;


        public CartItems()
        {
            if (HttpContext.Current.Request.Cookies["ShopCart"] == null)
            {
                DAL_Project.DAL myDal = new DAL_Project.DAL("Data Source=localhost;Initial Catalog=CeruleanProject3;Integrated Security=SSPI");
                myDal.AddParam("action", "r");
                if (HttpContext.Current.Session["userID"] != null)
                {
                    myDal.AddParam("userID", HttpContext.Current.Session["userID"].ToString());
                }
                DataSet ds = myDal.ExecuteProcedure("spCart");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
                    Dictionary<string, object> childRow;
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        childRow = new Dictionary<string, object>();
                        foreach (DataColumn td in ds.Tables[0].Columns)
                        {
                            childRow.Add(td.ColumnName, row[td]);
                        }
                        parentRow.Add(childRow);
                    }
                    //references instruction: ---> http://codepedia.info/convert-datatable-to-json-in-asp-net-c-sharp/ // 

                    string dsJson = new JavaScriptSerializer().Serialize(parentRow);
                    _CartItems = new JavaScriptSerializer().Deserialize<List<ShoppingCart>>(dsJson);
                }
                else
                {
                    _CartItems = new List<ShoppingCart>();

                }
            }
            else
            {
                string Items = HttpContext.Current.Request.Cookies["ShopCart"].Value;

                _CartItems = new JavaScriptSerializer().Deserialize<List<ShoppingCart>>(Items);
            }
        }

        public void AddtoCart(string ItemID, string UserID, string Quantity)
        {

            DAL_Project.DAL myDal = new DAL_Project.DAL("Data Source=localhost;Initial Catalog=CeruleanProject3;Integrated Security=SSPI");
            myDal.AddParam("action", "c");
            myDal.AddParam("userID", UserID);
            myDal.AddParam("itemID", ItemID);
            myDal.AddParam("quantity", Quantity);
            myDal.ExecuteProcedure("spCart");
            ShoppingCart myCart = new ShoppingCart(ItemID, UserID);
            _CartItems.Add(myCart);
            SaveToCookie();
        }

        private void SaveToCookie()
        {
            string cartJson = new JavaScriptSerializer().Serialize(_CartItems);
            var cookie = new HttpCookie("ShopCart", cartJson)
            {
                Expires = DateTime.Now.AddMinutes(25)
            };
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
        public List<ShoppingCart> GetCartItems()
        {
            clearCookie();
            return _CartItems;

        }
        public void clearCookie()
        {
            var cookie = new HttpCookie("ShopCart")
            {
                Expires = DateTime.Now.AddMinutes(-25) // just put negative whatever to delete cookie.
            };
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

    }
}