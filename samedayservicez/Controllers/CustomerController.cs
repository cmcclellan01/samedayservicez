using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace samedayservicez.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CustomerLogin()
        {
            ViewBag.Message = "Your CustomerLogin page.";

            return View();
        }
    }
}