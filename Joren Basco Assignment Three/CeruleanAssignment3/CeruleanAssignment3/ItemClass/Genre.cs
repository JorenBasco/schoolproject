using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CeruleanAssignment3.ItemClass
{
    public class Genre : Item
    {
        private string genre { get; set; }
        private string stock { get; set; }
        private string img { get; set; }
        public Genre()
        {

        }
        public Genre(string itemName, string itemPrice, string itemDescription,string genre,string img,string stock) : base(itemName,itemPrice,itemDescription)
        {
            this.genre = genre;
            this.stock = stock;
            this.img = img;
        }

        public override void enterToDB()
        {
            DAL_Project.DAL myDal = new DAL_Project.DAL("Data Source=localhost; Initial Catalog=CeruleanProject3; Integrated Security=SSPI;");
            myDal.AddParam("itemGenre", genre);
            myDal.AddParam("itemImg", img);
            myDal.AddParam("itemStock", stock);
            myDal.AddParam("action", "c");
            myDal.AddParam("itemName", itemName);
            myDal.AddParam("itemDescription", itemDescription);
            myDal.AddParam("itemPrice", itemPrice);
            myDal.ExecuteProcedure("spItem");
        }
        public override void updateItem(string itemID)
        {
            DAL_Project.DAL myDal = new DAL_Project.DAL("Data Source=localhost; Initial Catalog=CeruleanProject3; Integrated Security=SSPI;");
            myDal.AddParam("itemID", itemID);
            myDal.AddParam("itemGenre", genre);
            myDal.AddParam("itemImg", img);
            myDal.AddParam("itemStock", stock);
            myDal.AddParam("action", "u");
            myDal.AddParam("itemName", itemName);
            myDal.AddParam("itemDescription", itemDescription);
            myDal.AddParam("itemPrice", itemPrice);
            myDal.ExecuteProcedure("spItem");
        }
    }
}