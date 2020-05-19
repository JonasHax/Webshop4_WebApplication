using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
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

        public List<string> GetAvailableColors() {
            List<string> colors = new List<string>();

            foreach (CompanyProductVersion item in ProductVersions) {
                string color = item.ColorCode;
                if (!colors.Contains(color)) {
                    colors.Add(color);
                }
            }

            return colors;
        }

        public List<string> GetSizesAvailableInSpecificColor(string color) {
            List<string> sizes = new List<string>();
            //string[] ordering = { "xs", "s", "m", "l", "xl", "xxl" };

            foreach (CompanyProductVersion item in ProductVersions) {
                if (item.ColorCode.Equals(color)) {
                    string size = item.SizeCode;
                    if (!sizes.Contains(size)) {
                        sizes.Add(size.ToUpper());
                    }
                }
            }
            //sizes.OrderBy();

            return sizes;
        }

        public CompanyProductVersion GetProductVersion(string sizeCode, string colorCode) {
            CompanyProductVersion prodVer = null;

            foreach (CompanyProductVersion item in ProductVersions) {
                if (item.SizeCode.Equals(sizeCode) && item.ColorCode.Equals(colorCode)) {
                    prodVer = item;
                }
            }

            return prodVer;
        }
    }
}