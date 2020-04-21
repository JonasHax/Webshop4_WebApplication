using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApplication.Models {
    [DataContract]
    public class CompanyProductVersion {
        [DataMember]
        public CompanyProduct Product { get; set; }

        [DataMember]
        public int Stock { get; set; }

        [DataMember]
        public string SizeCode { get; set; }

        [DataMember]
        public string ColorCode { get; set; }

        public CompanyProductVersion() {
        }

        public override string ToString() {
            return $"Size: {SizeCode}, Color: {ColorCode}, stock: {Stock}";
        }
    }
}