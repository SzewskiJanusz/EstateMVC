using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EstateMVC.Controllers
{
    public class SearchController : Controller
    {
        // GET: search choice
        public ActionResult Index()
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("/Login/Index");
            }

            return View();
        }

        // GET: manually search estate  
        public ActionResult SearchEstate()
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("/Login/Index");
            }

            return View();
        }

        [HttpPost]
        public ActionResult SearchEstate(Models.EstateSearching es)
        {
            if (es.MinPrice > es.MaxPrice)
            {
                ModelState.AddModelError("", "Cena minimalna nie może być większa niż cena maksymalna!");
            }

            return View(es);
        }

        // GET: search by id 
        public ActionResult SearchByID()
        {
            return View();
        }
    }
}