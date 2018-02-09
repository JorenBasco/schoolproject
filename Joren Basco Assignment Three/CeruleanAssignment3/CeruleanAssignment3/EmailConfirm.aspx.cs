using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL_Project;

namespace CeruleanAssignment3
{
    public partial class EmailConfirm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["zestiria"] == null)
            {
                Response.Redirect("Index.aspx");
            }
            else
            {
                DAL queryDal = new DAL("Data Source=localhost; Initial Catalog=CeruleanProject3; Integrated Security=SSPI");
                queryDal.AddParam("action", "z");
                queryDal.AddParam("securityLevel", Request.QueryString["zestiria"]);
                Session["userID"] = queryDal.ExecuteProcedure("spUser").Tables[0].Rows[0]["userID"].ToString();
                string id = Session["userID"].ToString();
            }

        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            DAL myDal = new DAL("Data Source=localhost; Initial Catalog=CeruleanProject3; Integrated Security=SSPI");
            myDal.AddParam("action", "u");
            myDal.AddParam("userID", (string)Session["userID"]);
            myDal.AddParam("securityLevel", "Customer");
            myDal.ExecuteProcedure("spUser");
            Session["UserSecurity"] = "Customer";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Your Account has been confirmed')", true);

            Response.AddHeader("REFRESH", "3;Login.aspx");
            
        }
    }
}