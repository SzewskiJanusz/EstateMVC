using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EstateMVC.Models;

namespace EstateMVC.Controllers
{
    public class ResultController : Controller
    {
        Models.EstateAgencyEntities db = new Models.EstateAgencyEntities();
        // GET: Result
        public ActionResult Index()
        {
            return View();
        }

        // GET: Result with searching with ID
        public ActionResult GetByID(string hlcn)
        {
            string imagePath;
            try
            {
                imagePath = db.ListingPicture.Where(x =>
                    x.Listing.HLCN == hlcn).Select(x => x.ImagePath).First();

                BriefResult br = new BriefResult(
                imagePath,
                hlcn,
                db.Listing.Where(x => x.HLCN == hlcn).Select(x => x.HousePrice).First(),
                db.Listing.Where(x => x.HLCN == hlcn).Select(x => x.HomeLocation).First(),
                db.Listing.Where(x => x.HLCN == hlcn).Select(x => x.Address).First(),
                db.Listing.Where(x => x.HLCN == hlcn).Select(x => x.RoomAmount).First(),
                db.Listing.Where(x => x.HLCN == hlcn).Select(x => x.BathroomAmount).First(),
                db.Listing.Where(x => x.HLCN == hlcn).Select(x => x.BedroomAmount).First()
            );
                // Create list in purpose of using the same view of GetProperties action
                // which uses IEnumerable model
                List<BriefResult> blist = new List<BriefResult>();
                blist.Add(br);
                return View("~/Views/Result/GetProperties.cshtml", blist);
            }
            catch (InvalidOperationException)
            {
                imagePath = "";
                List<BriefResult> blist = new List<BriefResult>();
                return View("~/Views/Result/GetProperties.cshtml", blist);
            }
        }


        // GET: Result with searching arguments
        public ActionResult GetProperties(int minPrice, int maxPrice,
            int roomAmount,int bedroomAmount,int bathroomAmount)
        {    
            List<EstateMVC.Models.Listing> listing =
                db.Listing.Where(x =>
                x.HousePrice >= minPrice && x.HousePrice <= maxPrice).ToList();

            if (roomAmount > 0)
            {
                listing = FilterRooms(roomAmount,listing);
            }

            if (bathroomAmount > 0)
            {
                listing = FilterBathrooms(bathroomAmount,listing);
            }

            if (bedroomAmount > 0)
            {
                listing = FilterBedrooms(bedroomAmount,listing);
            }


            List<Models.BriefResult> brieflist = new List<Models.BriefResult>();
            foreach (var objList in listing)
            {
                long id = objList.ListingID;
                string imagePath = 
                db.ListingPicture.Where(x =>
                x.ListingID == id).Select(x => x.ImagePath).First();
                ViewBag.ImagePath = imagePath;
                brieflist.Add(new Models.BriefResult(
                    imagePath, 
                    objList.HLCN, 
                    objList.HousePrice,
                    objList.HomeLocation,
                    objList.Address,
                    objList.RoomAmount,
                    objList.BathroomAmount,
                    objList.BedroomAmount
                    ));
            }
            return View(brieflist);
        }

        // room == 5 because in DDL in SearchEstate view there is value 5 on 4+ rooms option 
        private List<Listing> FilterBedrooms(int bedroomAmount, List<EstateMVC.Models.Listing> list)
        {
            if (bedroomAmount == 5)
            {
                return list.Where(x => x.BedroomAmount >= bedroomAmount).ToList();
            }

            return list.Where(x => x.BedroomAmount == bedroomAmount).ToList();
        }

        private List<Listing> FilterBathrooms(int bathroomAmount, List<EstateMVC.Models.Listing> list)
        {
            if (bathroomAmount == 5)
            {
                return list.Where(x => x.BathroomAmount >= bathroomAmount).ToList();
            }

            return list.Where(x => x.BathroomAmount == bathroomAmount).ToList();
        }
        private List<Models.Listing> FilterRooms(int rooms, List<EstateMVC.Models.Listing> list)
        {
            if (rooms == 5)
            {
                return list.Where(x => x.RoomAmount >= rooms).ToList();
            }

            return list.Where(x => x.RoomAmount == rooms).ToList();
        }
    }
}