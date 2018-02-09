using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL_Project;

namespace CeruleanAssignment3.ItemClass
{
    public class Item
    {
        public string itemName { get; set; }

        public string itemPrice { get; set; }
        public string itemDescription { get; set; }

        public Item()
        {

        }
        public Item(string itemName, string itemPrice, string itemDescription)
        {
            this.itemName = itemName;
            this.itemPrice = itemPrice;
            this.itemDescription = itemDescription;
        }

        public virtual void enterToDB()
        {
            DAL myDal = new DAL("Data Source=localhost; Initial Catalog=CeruleanProject3; Integrated Security=SSPI;");
            myDal.AddParam("action", "c");
            myDal.AddParam("itemName", itemName);
            myDal.AddParam("itemDescription", itemDescription);
            myDal.AddParam("itemPrice", itemPrice);
            myDal.ExecuteProcedure("spItem");
        }

        public void deleteItem(string itemID)
        {
            DAL myDal = new DAL("Data Source=localhost; Initial Catalog=CeruleanProject3; Integrated Security=SSPI;");
            myDal.AddParam("action", "d");
            myDal.AddParam("itemID", itemID);
            myDal.ExecuteProcedure("spItem");
        }

        public virtual void updateItem(string itemID)
        {
            DAL_Project.DAL myDal = new DAL_Project.DAL("Data Source=localhost; Initial Catalog=CeruleanProject3; Integrated Security=SSPI;");
            myDal.AddParam("itemID", itemID);
            myDal.AddParam("action", "u");
            myDal.AddParam("itemName", itemName);
            myDal.AddParam("itemDescription", itemDescription);
            myDal.AddParam("itemPrice", itemPrice);
            myDal.ExecuteProcedure("spItem");

        }
    }
}