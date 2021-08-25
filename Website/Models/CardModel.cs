using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Models
{
public class CardModel
    {
        public string ID { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public string PostedDate { get; set; }
        public string SmallDescription { get; set; }
        public string imageSrc { get; set; }
        public string LongDescription { get; set; }
        public string imageAlt { get; set; }
        public string ButtonText { get; set; }
        public CardModel(string ID, string Category, string Title, string CreatedDate, string SmallDescription, string imageSrc, string imageAlt, string ButtonText)
        {
            this.ID = ID;
            this.Category = Category;
            this.Title = Title;
            this.PostedDate = PostedDate;
            this.LongDescription = LongDescription;
            this.imageSrc = imageSrc;
            this.imageAlt = imageAlt;
            this.ButtonText = ButtonText;
        }
    }

}