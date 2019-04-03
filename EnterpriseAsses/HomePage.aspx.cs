using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace EnterpriseAsses
{
    public partial class HomePage : System.Web.UI.Page
    {
        dynamic list;
        protected void Page_Load(object sender, EventArgs e)
        {
            WebService1 webService = new WebService1();
          
            GetCountry country = new GetCountry();
            string str= webService.getAllCountriesAPI();
           
             list =  JsonConvert.DeserializeObject(str);
      

            foreach (var item in list)
            {
                string name = item["name"].Value;
                ddlcountry.Items.Add(new ListItem(name, name));
            }



        }
            
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            string CountryName = ddlcountry.SelectedValue;

            //var data = from a in list
            //           where list["name"] = CountryName
            //           select a["currencies"].Value;

            int count = ((Newtonsoft.Json.Linq.JContainer)list).Count;

            foreach (var item in list)
            {
                string name = item["name"].Value;

                if (CountryName == name)
                {

                }


            }


        }

        
    }
}