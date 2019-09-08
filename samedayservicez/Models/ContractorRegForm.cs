using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace samedayservicez.Models
{
    public class ContractorRegistrationForm
    {

       
        [Required(ErrorMessage = "Please Enter Your First Name",
            AllowEmptyStrings = false)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Please Enter Your  Middle Name",
          AllowEmptyStrings = false)]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }



        [Required(ErrorMessage = "Please Enter Your Last Name",
        AllowEmptyStrings = false)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Please Enter Your Street Address",
       AllowEmptyStrings = false)]
        [Display(Name = "Address")]
        public string Address { get; set; }


        [Required(ErrorMessage = "Please Enter Your City",
       AllowEmptyStrings = false)]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please Enter Your State",
         AllowEmptyStrings = false)]
        [Display(Name = "State")]
        public string State { get; set; }
        public IEnumerable<SelectListItem> States { get; set; }


        [Required(ErrorMessage = "Please Enter Your Zip Code",
       AllowEmptyStrings = false)]
        [StringLength(5, MinimumLength = 5)]
        [RegularExpression("(^\\d{5}(-\\d{4})?$)|(^[ABCEGHJKLMNPRSTVXY]{1}\\d{1}[A-Z]{1} *\\d{1}[A-Z]{1}\\d{1}$)", ErrorMessage = "Zip code is invalid.")] // US or Canada

        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Please Enter Your Phone Number",
      AllowEmptyStrings = false)]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Invalid Phone number")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }


        [Required(ErrorMessage ="Please Enter Email Address")]
        [Display(Name = "Email")]
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$",
        ErrorMessage = "Please Enter Correct Email Address")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Please Enter a Password",
      AllowEmptyStrings = false)]
        public string Password { get; set; }

        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Confirm password doesn't match, Try Again!")]
        public string ConfirmPassword { get; set; }


        [Required(ErrorMessage = "Choose date of birth")]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }


        [Required(ErrorMessage = "Please Enter Your Bio",
     AllowEmptyStrings = false)]
        [Display(Name = "Bio")]
        public string Bio { get; set; }

    }
}