using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TripAgencyProject.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AdminPosts()
        {
            return View();
        }
        public ActionResult AdminAgencies()
        {
            return View();
        }
        public ActionResult AdminTravelers()
        {
            return View();
        }
    }
}