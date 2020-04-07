using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models {

    public class CompanyProduct {
        public int StyleNumber { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Boolean State { get; set; }

        public decimal Price { get; set; }

        public List<CompanyProductVersion> ProductVersions { get; set; }

        public CompanyProduct() {
            ProductVersions = new List<CompanyProductVersion>();
        }

        public override string ToString() {
            return $"Varenummer: {StyleNumber} \nNavn: {Name}\nPris: {Price},-\nBeskrivelse: {Description}\nTilgængelig: {State}"; /*\nLager: {Stock} \nStr.: {SizeCode} \nFarve: {ColorCode}*/
        }
    }
}