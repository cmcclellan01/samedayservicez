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


        [HttpPost]
        public ActionResult ContractorProfile(Models.ContractorRegistrationForm model)
        {

            // Get all states again
            var states = samedayservicez.Utils.Extensions.GetStatesList();


            model.States = GetSelectListItems(states);

            // In case everything is fine - i.e. both "Name" and "State" are entered/selected,
            // redirect user to the "Done" page, and pass the user object along via Session
            if (ModelState.IsValid)
            {
                Session["ContractorSignupModel"] = model;
                return RedirectToAction("ContractorProfileConfirm");
            }

            // Something is not right - so render the registration page again,
            // keeping the data user has entered by supplying the model.
            return View("ContractorProfile", model);
        }

        public ActionResult ContractorProfile()
        {
            var states = samedayservicez.Utils.Extensions.GetStatesList();

            var model = new Models.ContractorRegistrationForm();

            model.States = GetSelectListItems(states);


            ViewBag.Message = "Your ContractorProfile page.";
          

            return View(model);
        }

        public ActionResult ContractorProfileConfirm()
        {
            ViewBag.Message = "Your ContractorProfileConfirm page.";

            var model = Session["ContractorSignupModel"] as Models.ContractorRegistrationForm;

            // Display Done.html page that shows Name and selected state.
            return View(model);
        }

        private IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<SelectListItem> elements)
        {
            // Create an empty list to hold result of the operation
            var selectList = new List<SelectListItem>();

            // For each string in the 'elements' variable, create a new SelectListItem object
            // that has both its Value and Text properties set to a particular value.
            // This will result in MVC rendering each item as:
            //     <option value="State Name">State Name</option>
            foreach (var element in elements)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element.Value,
                    Text = element.Text
                });
            }

            return selectList;
        }


    }
}