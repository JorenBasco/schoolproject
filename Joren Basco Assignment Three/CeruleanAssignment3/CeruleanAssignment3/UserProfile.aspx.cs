using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL_Project;



namespace CeruleanAssignment3
{
    public partial class UserProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserSecurity"] == null)
                {
                    Response.Redirect("Index.aspx");
                }

                getUserInfo();
                if((string)Session["UserSecurity"] == "Admin")
                {

                }
                else if ((string)Session["UserSecurity"] != "Customer")
                {
                    divReVerifyEmail.Visible = true;
                }
            }
        }

        private void getUserInfo()
        {
            DAL myDal = new DAL("Data Source=localhost;Initial Catalog=CeruleanProject3;Integrated Security=SSPI;");
            myDal.AddParam("action", "r");
            myDal.AddParam("userID", (string)Session["userID"]);
            var i = myDal.ExecuteProcedure("spCustomer");
            txtEmail.Value = i.Tables[0].Rows[0]["userEmail"].ToString();
            txtPassword.Value = i.Tables[0].Rows[0]["userPass"].ToString();

            txtFirst.Value = i.Tables[0].Rows[0]["firstName"].ToString();
            txtLast.Value = i.Tables[0].Rows[0]["lastName"].ToString();
            txtPhone.Value = i.Tables[0].Rows[0]["phone"].ToString();
            txtAddress.Value = i.Tables[0].Rows[0]["address"].ToString();

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DAL myDal = new DAL("Data Source=localhost;Initial Catalog=CeruleanProject3;Integrated Security=SSPI;");
            myDal.AddParam("action", "u");
            myDal.AddParam("userID", (string)Session["userID"]);
            myDal.AddParam("firstName", txtFirst.Value);
            myDal.AddParam("lastName", txtLast.Value);
            myDal.AddParam("phone", txtPhone.Value);
            myDal.AddParam("address", txtAddress.Value);
            myDal.ExecuteProcedure("spCustomer");
            Response.AddHeader("REFRESH", ".1;UserProfile.aspx");

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.AddHeader("REFRESH", ".1;UserProfile.aspx");
        }

        protected void editCustomerInfo_ServerClick(object sender, EventArgs e)
        {
            txtFirst.Attributes.Remove("readonly");
            txtLast.Attributes.Remove("readonly");
            txtPhone.Attributes.Remove("readonly");
            txtAddress.Attributes.Remove("readonly");
            btnSave.Visible = true;
            btnCancel.Visible = true;
            editCustomerInfo.Visible = false;
            divUserInfo.Visible = false;
        }

        protected void btnChangePassword_ServerClick(object sender, EventArgs e)
        {
            passwordColumn.Visible = false;
            passChange.Visible = true;
            btnChangePassword.Visible = false;
            divCustomerInfo.Visible = false;


        }

        protected void btnSavePass_ServerClick(object sender, EventArgs e)
        {

            DAL myDal = new DAL("Data Source=localhost;Initial Catalog=CeruleanProject3;Integrated Security=SSPI;");
            myDal.AddParam("action", "L");
            myDal.AddParam("userPass", txtOldpass.Value);
            myDal.AddParam("userEmail", txtEmail.Value);
            myDal.AddParam("newPass", txtNewPass.Value);
            myDal.ExecuteProcedure("spUser");
            Response.AddHeader("REFRESH", ".1;UserProfile.aspx");
        }

        protected void btnCancelPass_ServerClick(object sender, EventArgs e)
        {
            Response.AddHeader("REFRESH", ".1;UserProfile.aspx");
        }

        protected void btnReVerify_ServerClick(object sender, EventArgs e)
        {
            UserClass.Customer myCust = new UserClass.Customer();
            myCust.confirmation(txtEmail.Value, (string)Session["userID"]);


        }
    }
}