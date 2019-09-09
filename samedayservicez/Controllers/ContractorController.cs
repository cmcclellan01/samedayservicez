using samedayservicez.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace samedayservicez.Controllers
{
    public class ContractorController : Controller
    {

        private samedayservicezContext db = new samedayservicezContext();
        // GET: ContractorRegistrationForms/Create
        public ActionResult CreateContractorProfile()
        {
            return View();
        }

        // POST: ContractorRegistrationForms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateContractorProfile([Bind(Include = "ID,FirstName,MiddleName,LastName,Address,City,State,ZipCode,PhoneNumber,Email,Password,ConfirmPassword,BirthDate,Bio")] ContractorRegistrationForm contractorRegistrationForm)
        {
            if (ModelState.IsValid)
            {
                db.Contractors.Add(contractorRegistrationForm);
                db.SaveChanges();

                var login = new Login
                {
                    ProfileId = contractorRegistrationForm.ID,
                    Email = contractorRegistrationForm.Email,
                    Password = contractorRegistrationForm.Password
                };

                db.Login.Add(login);
                db.SaveChanges();


                return RedirectToAction("Index");
            }

            return View(contractorRegistrationForm);
        }

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
        public ActionResult Contractorlogin(Models.Login model)
        {
            ViewBag.Message = "Your Contractorlogin page.";
            var password = Encrypt(model.Password).ToString();

            var user = db.Login
                    .Where(b => b.Email == model.Email.ToString() && b.Password == password)
                    .FirstOrDefault();


            if (user != null)
            {
                var profile = db.Contractors.Where(b => b.ID == user.ProfileId)
                   .FirstOrDefault();
                var states = samedayservicez.Utils.Extensions.GetStatesList();

                profile.States = GetSelectListItems(states);

                return View("ContractorProfileConfirm", profile);
            }
            else
            {
                return View("Contractorlogin", model);
            }
           
        }

        public string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }


        [HttpPost]
        public ActionResult ContractorProfile(Models.ContractorRegistrationForm model)
        {

            var states = samedayservicez.Utils.Extensions.GetStatesList();

            model.States = GetSelectListItems(states);
          
            if (ModelState.IsValid)
            {
                Session["ContractorSignupModel"] = model;
                model.Password = Encrypt(model.Password);
                model.ConfirmPassword = Encrypt(model.ConfirmPassword);

                CreateContractorProfile(model);

                return RedirectToAction("ContractorProfileConfirm");
            }
            
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

            if(model == null)
            {
                var states = samedayservicez.Utils.Extensions.GetStatesList();

                model = new Models.ContractorRegistrationForm();

                model.States = GetSelectListItems(states);

            }

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