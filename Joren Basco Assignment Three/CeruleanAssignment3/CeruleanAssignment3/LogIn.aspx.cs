using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL_Project;
using System.Data;
using System.IO;
using System.Net.Mail;

namespace CeruleanAssignment3
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void Login()
        {
            DAL myDal = new DAL("Data Source=localhost;Initial Catalog=CeruleanProject3;Integrated Security=SSPI");
            myDal.AddParam("action", "S"); //action S is security
            myDal.AddParam("userEmail", txtLogInEmail.Value);
            myDal.AddParam("userPass", txtLogInPassword.Value);

            DataSet ds = myDal.ExecuteProcedure("spUser");
            string userSecurity = ds.Tables[0].Rows[0]["securityLevel"].ToString();
            HttpCookie cookie = Request.Cookies["errorLogin"];
            if (Request.Cookies["errorLogin"] == null)
            {
                cookie = new HttpCookie("errorLogin");
            }
            if (userSecurity == "invalid")
            {

                if (cookie.Value == null)
                {
                    cookie.Value = "1";
                    cookie.Expires = DateTime.Now.AddMinutes(2);
                    Response.Cookies.Add(cookie);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Wrong Username or Password')", true);
                }
                else if (cookie.Value == "5")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Too many Attempts, try again in 10minutes')", true);
                    txtLogInEmail.Attributes.Add("readonly", "true");
                    txtLogInPassword.Attributes.Add("readonly", "true");
                    btnLogIn.Visible = false;
                }
                else
                {
                    int attemps = Convert.ToInt32(cookie.Value);
                    attemps = attemps + 1;
                    cookie.Value = attemps.ToString();
                    cookie.Expires = DateTime.Now.AddMinutes(10);
                    Response.Cookies.Add(cookie);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Wrong Username or Password')", true);

                }

            }
            else
            {
                string name = ds.Tables[0].Rows[0]["firstName"].ToString() + " " + ds.Tables[0].Rows[0]["lastName"].ToString();
                Session["UserSecurity"] = userSecurity;
                Session["userID"] = ds.Tables[0].Rows[0]["userID"].ToString();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Hello'" + name + ")", true);

                cookie.Expires = DateTime.Now.AddMinutes(-10);
                Response.Cookies.Add(cookie);
                Response.AddHeader("REFRESH", "1;URL=Index.aspx");
            }
        }

        protected void btnLogIn_ServerClick(object sender, EventArgs e)
        {
            Login();

        }

        protected void btnForgot_ServerClick(object sender, EventArgs e)
        {
            passwordColumn.Visible = false;
            txtLogInEmail.Attributes.Remove("readonly");
            txtLogInPassword.Attributes.Remove("readonly");
            btnLogIn.Visible = false;
            btnForgot.Visible = false;
            btnGetPass.Visible = true;

        }


        private void emailNewPassword()
        {
            DAL myDal = new DAL("Data Source=localhost;Initial Catalog=CeruleanProject3;Integrated Security=SSPI");
            myDal.AddParam("action", "p"); // (p)assword
            myDal.AddParam("userEmail", txtLogInEmail.Value);
            DataSet ds = myDal.ExecuteProcedure("spUser");
            string userEmail = ds.Tables[0].Rows[0]["userEmail"].ToString();


            if (userEmail == "invalid")
            {
                lbltest.Text = " The Email you have entered is wrong or doesn't exist";
            }
            else
            {
                string id = ds.Tables[0].Rows[0]["userID"].ToString();

                myDal.ClearParams();
                string newPassword = Path.GetRandomFileName();
                newPassword = newPassword.Replace(".", "");
                newPassword.Substring(0, 8);

                myDal.AddParam("action", "u");
                myDal.AddParam("userID", id);
                myDal.AddParam("userPass", newPassword);
                myDal.ExecuteProcedure("spUser");

                MailMessage message = new MailMessage();
                message.From = new MailAddress("jose_ramiro.basco@robertsoncollege.net");
                message.To.Add(new MailAddress(userEmail));
                message.Subject = "Your new Password! yey";
                message.IsBodyHtml = true;
                message.Body = "Your new password is " + newPassword + "<br/> <a href='http://localhost:1080/LogIn.aspx'> Log in here </a>";
                SmtpClient client = new SmtpClient();
                client.Host = "localhost";
                client.PickupDirectoryLocation = "C:\\Users\\Jose Ramiro\\Desktop"; // Change this to your prefered Location
                client.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                client.Send(message);
                lbltest.Text = " Your new Password has been Emailed to you!";

            }
            Session["userID"] = ds.Tables[0].Rows[0]["userID"].ToString();

        }

        protected void btnGetPass_ServerClick(object sender, EventArgs e)
        {
            emailNewPassword();
            lbltest.Visible = true;

        }
    }
}