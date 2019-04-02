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
        protected void Page_Load(object sender, EventArgs e)
        {
            WebService1 webService = new WebService1();
          
            GetCountry country = new GetCountry();
            string str= webService.getAllCountriesAPI();
           
            dynamic list =  JsonConvert.DeserializeObject(str);
          
            int count = ((Newtonsoft.Json.Linq.JContainer)list).Count;

            foreach (var item in list)
            {
                string name = item["name"].Value;
                ddlcountry.Items.Add(new ListItem(name, name));
            }



        }
            
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            Request rq = new Request(); 
            //rq.cityID = ddlcity.SelectedValue;
           // rq.cityName = ddlcity.SelectedItem.Text;
            rq.Adults = ddlAdult.SelectedItem.Text;
            rq.Child = ddlchild.SelectedItem.Text;

            //WebService1 webService = new WebService1();
            //webService.RequestXML(rq);
            Response.Redirect("Results.aspx?cityid=" + rq.cityID);
            //Response.Redirect("WebService1.asmx");
        }

        protected void ddlcountry_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}