using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL_Project;

namespace CeruleanAssignment3
{
    /// <summary>
    /// Summary description for EnterOrderItems
    /// </summary>
    public class EnterOrderItems : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            var itemID = context.Request.Form["itemID"];
            var qty = context.Request.Form["qty"];
            var orderID = context.Request["orderID"];

            submitOrder(orderID, itemID, qty);
        }

        private void submitOrder(string orderID, string itemID, string qty)
        {
            DAL myDal = new DAL("Data Source=localhost;Initial Catalog=CeruleanProject3;Integrated Security=SSPI");
            myDal.AddParam("action", "c");
            myDal.AddParam("orderID", orderID);
            myDal.AddParam("itemID", itemID);
            myDal.AddParam("quantity", qty);
            myDal.ExecuteProcedure("spOrderItems");


        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}