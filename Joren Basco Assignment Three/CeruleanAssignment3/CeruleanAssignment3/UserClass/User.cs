using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL_Project;

namespace CeruleanAssignment3.UserClass
{
    public class User
    {
        private string Email { get; set; }
        private string Password { get; set; }
        public string ID { get; set; }

        public User(string email, string password)
        {
            string id = checkDuplicate(email);
            //    string id = signUp();
            if (id == "invalid")
            {
                HttpContext.Current.Session["SignUp"] = id;
            }
            else
            {
                this.Email = email;
                this.Password = password;
                this.ID = id; 
            }

        }
        public User()
        {

        }
        public string signUp()
        {
            DAL myDal = new DAL("Data Source=localhost; Initial Catalog=CeruleanProject3; Integrated Security=SSPI");
            myDal.AddParam("action", "C");
            myDal.AddParam("userEmail", Email);
            myDal.AddParam("userPass", Password);
            return myDal.ExecuteProcedure("spUser").Tables[0].Rows[0]["userID"].ToString();
        }
        private string checkDuplicate(string email)
        {
            DAL myDal = new DAL("Data Source=localhost; Initial Catalog=CeruleanProject3; Integrated Security=SSPI");
            myDal.AddParam("action", "F"); // (F)ind dupes
            myDal.AddParam("userEmail", email);

            return myDal.ExecuteProcedure("spUser").Tables[0].Rows[0]["error"].ToString();
        }
    }
}