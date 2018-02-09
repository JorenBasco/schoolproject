using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using DAL_Project;

namespace CeruleanAssignment3
{
    /// <summary>
    /// Summary description for EnterOrder1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class wsEnterOrders : System.Web.Services.WebService
    {
        string conn = "Data Source=localhost;Initial Catalog=CeruleanProject3;Integrated Security=SSPI";
        [WebMethod]
        public string getOrderID(string userID,string total)
        {
            string today = DateTime.Now.Date.ToShortDateString();
            DAL myDal = new DAL(conn);
            myDal.AddParam("action", "c");
            myDal.AddParam("userID", userID);
            myDal.AddParam("orderDate", today);
            myDal.AddParam("total", total);
            string orderID = myDal.ExecuteProcedure("spOrder").Tables[0].Rows[0]["orderID"].ToString();
      //      HttpContext.Current.Session["tempo"] = "";
            return orderID;
        }
    }
}
