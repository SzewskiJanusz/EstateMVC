using System.Linq;
using System.Web.Mvc;

namespace EstateMVC.Controllers
{
    public class InformationController : Controller
    {
        Models.EstateAgencyEntities db = new Models.EstateAgencyEntities();
        // GET: Information
        public ActionResult Index()
        {
            return View();
        }

        // GET: Row clicked
        public ActionResult ShowProfile(string hlcn)
        {
            Models.Listing estate = 
                db.Listing.Where(x => x.HLCN == hlcn).First();
            long id = estate.ListingID;
            string imagePath =
                db.ListingPicture.Where(x =>
                x.ListingID == id).Select(x => x.ImagePath).First();

            Models.DetailedListing dl = new Models.DetailedListing
            {
                listing = estate,
                imagePath = imagePath
            };


            return View(dl);
        }
    }
}