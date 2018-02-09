using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL_Project;
using System.Net.Mail;
using System.IO;

namespace CeruleanAssignment3.UserClass
{
    public class Customer:User
    {
        private string first { get; set; }
        private string last { get; set; }
        private string phone { get; set; }
        private string address { get; set; }

        public Customer()
        {

        }
        public Customer(string email, string password, string first, string last, string phone, string address) : base(email, password)
        {
            this.first = first;
            this.last = last;
            this.phone = phone;
            this.address = address;
            var id = signUp();
            
            enterInfo(id);
            confirmation(email, id);
        }
        private void enterInfo(string ID)
        {
            DAL myDal = new DAL("Data Source=localhost; Initial Catalog=CeruleanProject3; Integrated Security=SSPI");
            myDal.AddParam("action", "C");
            myDal.AddParam("userID", ID);
            myDal.AddParam("firstName", first);
            myDal.AddParam("lastName", last);
            myDal.AddParam("phone", phone);
            myDal.AddParam("address", address);
            myDal.ExecuteProcedure("spCustomer");
            
        }

        public void confirmation(string email,string id)
        {
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("jose_ramiro.basco@robertsoncollege.net");
            msg.To.Add(new MailAddress(email));
            string queryUrl = Path.GetRandomFileName();
            queryUrl = queryUrl.Replace(",", "");
            queryUrl = queryUrl.Replace(".","");
            queryUrl.Substring(0, 9);
            DAL myDal = new DAL("Data Source=localhost; Initial Catalog=CeruleanProject3; Integrated Security=SSPI");
            myDal.AddParam("action", "u");
            myDal.AddParam("securityLevel",queryUrl);
            myDal.AddParam("userID", id);
            myDal.ExecuteProcedure("spUser");
            msg.Subject = "Email Confirmation";
            msg.IsBodyHtml = true;

            msg.Body = "This is your confimation URL <br/>" + "<a href='http://localhost:1080/EmailConfirm.aspx?zestiria=" + queryUrl +"'> LINK </a>";
            SmtpClient client = new SmtpClient();
            client.Host = "localhost";
            client.PickupDirectoryLocation = "C:\\Users\\Jose Ramiro\\Desktop";  // Change this to your prefered Location
            client.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
            client.Send(msg);


        }
    }
}