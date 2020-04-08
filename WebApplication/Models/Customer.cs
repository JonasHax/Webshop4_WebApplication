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

        public int Id { get; set; }
        [Required]
        [DisplayName("Fornavn")]
        public string firstName { get; set; }
        [Required]
        [DisplayName("Efternavn")]
        public string lastName { get; set; }
        [Required]
        [DisplayName("Vej/gade")]
        public string custStreet { get; set; }
        [Required]
        [DisplayName("Nummer")]
        public int custNo { get; set; }
        [Required]
        [DisplayName("Postnummer")]
        public string zipCode { get; set; }
        [Required]
        [DisplayName("Telefon")]
        public string phoneNumber { get; set; }
        [Required]
        [DisplayName("Email")]
        public string email { get; set; }
        [Required]
        [DisplayName("Password")]
        public string password { get; set; }
    }
}