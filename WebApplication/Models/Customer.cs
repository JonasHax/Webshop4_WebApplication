using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class Customer
    {

        //public int Id { get; set; }
        [Required(ErrorMessage = "Please enter first name.")]
        [DisplayName("Fornavn")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Efternavn")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Vej/gade")]
        public string Street { get; set; }

        [Required]
        [DisplayName("Nummer")]
        //public int CustNo { get; set; }
        public int HouseNo { get; set; }

        [Required]
        [DisplayName("Postnummer")]
        public string ZipCode { get; set; }

        [Required]
        [DisplayName("Telefon")]
        public string PhoneNumber { get; set; }

        [Required]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required]
        [DisplayName("Password")]
        public string Password { get; set; }
    }
}