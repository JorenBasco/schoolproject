using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL_Project;

namespace CeruleanAssignment3
{
    /// <summary>
    /// Summary description for EnterOrder
    /// </summary>
    public class EnterOrder : IHttpHandler
    {
        string conn = "Data Source=localhost;Initial Catalog=CeruleanProject3;Integrated Security=SSPI";
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            var userID = context.Request.Form["userID"];
            var total = context.Request.Form["total"];
            var orderID = getOrderID(userID,total);

            context.Response.Write(orderID);
        //    HttpContext.Current.Session["tempo"] = "";

        }
        private string getOrderID(string userID, string total)
        {
            string today = DateTime.Now.Date.ToString();
            DAL myDal = new DAL(conn);
            myDal.AddParam("action", "c");
            myDal.AddParam("userID", userID);
            myDal.AddParam("orderDate",today);
            myDal.AddParam("total", total);
            string orderID = myDal.ExecuteProcedure("spOrder").Tables[0].Rows[0]["orderID"].ToString();
            return orderID;
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