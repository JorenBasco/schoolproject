using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace CeruleanAssignment3
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSign_ServerClick(object sender, EventArgs e)
        {

            btnSign.Visible = false;
            ViewState["Email"] = Request.Form["UserEmail"];
            ViewState["Password"] = Request.Form["UserPass"];
            string email = ViewState["Email"].ToString();
            string pass = ViewState["Password"].ToString();
            UserClass.User user = new UserClass.User(email, pass);
            
            if ((string)Session["SignUp"] == "invalid")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Username is already taken')", true);
                Response.AddHeader("REFRESH", ".01;URL=SignUp.aspx");
               // Response.Redirect("SignUp.aspx");
                Session.Abandon();
            }
            else
            {
             divCustInfo.Visible = true;
                divSignUp.Visible = false;
            }


        }

        protected void btnSubmitInfo_ServerClick(object sender, EventArgs e)
        {

            string first = Request.Form["firstName"];
            string last = Request.Form["lastName"];
            string phone = Request.Form["phone"];
            string address = Request.Form["address"];

            string email = ViewState["Email"].ToString();
            string pass = ViewState["Password"].ToString();

            UserClass.Customer cust = new UserClass.Customer(email, pass, first, last, phone, address);

            Response.Redirect("LogIn.aspx");
        }
    }
}