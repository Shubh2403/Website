using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Models;

namespace Website.Controllers
{
    public class AssignmentController : Controller
    {
        private object src;
        private object imageField;

        public string Buttontext { get; private set; }

        // GET: Assignment
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CardComponent(FormCollection form)
        {
            string query = form["searchInput"];
            List<CardModel> PM = new List<CardModel>();
            var item = Sitecore.Context.Database.GetItem("{1832109B-71C7-4144-91C6-6EBEDE5A4F65}");
            Sitecore.Data.Fields.MultilistField Article = item.Fields["Article"];
            if (Article != null)
            {
                foreach (Sitecore.Data.Items.Item I in Article.GetItems())
                {
                    var ID = I.ID.ToString();
                    var CreatedDate = DateTime.ParseExact(I.Fields["PostedDate"].Value, "yyyyMMdd'T'HHmmss'Z'", CultureInfo.InvariantCulture).ToString("dd/MM/yyyy");
                    var Title = I.Fields["Title"].Value;
                    var SmallDescription = I.Fields["SmallDescription"].Value;
                    var Image = I.Fields["SmallImages"].Value;
                    Sitecore.Data.Fields.ImageField imageField = I.Fields["SmallImages"];
                    Sitecore.Data.Items.MediaItem image = new Sitecore.Data.Items.MediaItem(imageField.MediaItem);
                    string imageSrc = Sitecore.StringUtil.EnsurePrefix('/',
                    Sitecore.Resources.Media.MediaManager.GetMediaUrl(image));
                    //var Buttontext = item.Fields["CardButtonText"].Value;

                    string imgTag = String.Format(@"<img src=""{0}"" alt=""{1}"" />", src, image.Alt);

                    PM.Add(new CardModel(ID, "Design", Title, CreatedDate, SmallDescription, imageSrc, image.Alt, Buttontext));
                }
            }

            if (query != null)
            {
                List<CardModel> results = null;

                results = PM.FindAll(Findtitle);

                bool Findtitle(CardModel dmp)
                {
                    if (dmp.Title.ToLower().Contains(query.ToLower()) || dmp.SmallDescription.ToLower().Contains(query.ToLower()))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return View("~/Views/Assignment/Card.cshtml", results);
            }

            return View("~/Views/Assignment/Card.cshtml", PM);

        }

    }
}