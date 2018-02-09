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

    public partial class OrderReview : System.Web.UI.Page
    {
        string conn = "Data Source=localhost;Initial Catalog=CeruleanProject3;Integrated Security=SSPI";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Session["UserSecurity"] == null)
                {
                    Response.Redirect("Index.aspx");
                }
                if (Session["userID"] != null)
                {
                    getOrders();
                }

            }
        }

        private void getOrders()
        {
            DAL myDal = new DAL(conn);
            myDal.AddParam("action", "b");
            if ((string)Session["UserSecurity"] != "Admin")
            {
                myDal.AddParam("userID", (string)Session["userID"]);
            }

            DataSet ds = myDal.ExecuteProcedure("spOrder");
            if (ds.Tables[0].Rows.Count > 0)
            {

                xmlReviewOrder.DocumentContent = ds.GetXml();
            }
            else
            {
                divOrderReview.InnerHtml = "No Current Orders";
            }

        }

    }
}