using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace EnterpriseAsses
{
    public class GetCountry
    {
        public XmlDocument xDoc { get; set; }

        public string CountryName { get; set; }
        public string callingCodes { get; set; }
        public string capital { get; set; }
        public string altSpellings { get; set; }
        public string region { get; set; }
        public string subregion { get; set; }
        public long population { get; set; }
        public double lat { get; set; }
        public double area { get; set; }
        public string currencies { get; set; }
        public double longt { get; set; }
        public string countryByregion { get; set; }
    }
}