using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace samedayservicez.Controllers
{
    public class ContractorController : Controller
    {
        // GET: Contractor
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contractorlogin()
        {
            ViewBag.Message = "Your Contractorlogin page.";

            return View();
        }

        public ActionResult ContractorProfile()
        {
            ViewBag.Message = "Your ContractorProfile page.";

            return View();
        }

        public ActionResult ContractorProfileConfirm()
        {
            ViewBag.Message = "Your ContractorProfileConfirm page.";

            return View();
        }
        

    }
}