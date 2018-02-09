using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using DAL_Project;

namespace CeruleanAssignment3
{
    /// <summary>
    /// Summary description for wsEnterOrderItems
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class wsEnterOrderItems : System.Web.Services.WebService
    {

        [WebMethod]
        public void submitOrder(string orderID, string itemID, string qty)
        {
            DAL myDal = new DAL("Data Source=localhost;Initial Catalog=CeruleanProject3;Integrated Security=SSPI");
            myDal.AddParam("action", "c");
            myDal.AddParam("orderID", orderID);
            myDal.AddParam("itemID", itemID);
            myDal.AddParam("quantity", qty);
            myDal.ExecuteProcedure("spOrderItems");
            //HttpContext.Current.Session["tempo"] = null;   // <<-- discount session, reset FIX IT

        }
    }
}
