using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DO.Validation.Codes;

namespace WebApplication.Models
{
    public class Customer
    {


        [Required(ErrorMessage = "Indtast fornavn.")]
        [DisplayName("Fornavn")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Indtast efternavn.")]
        [DisplayName("Efternavn")]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Indtast vej/gade.")]
        [DisplayName("Vej/gade")]
        public string Street { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Indtast nummer.")]
        [DisplayName("Nummer")]
        //public int CustNo { get; set; }
        public int HouseNo { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Indtast postnummer.")]
        [DisplayName("Postnummer")]
        public string ZipCode { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Indtast telefonnummer.")]
        [DisplayName("Telefon")]
        public string PhoneNumber { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Indtast email.")]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Indtast password.")]
        [DisplayName("Password")]
        public string Password { get; set; }
    }
}