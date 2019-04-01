using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EnterpriseAsses
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WebService1 webService = new WebService1();
          
            GetCountry country = new GetCountry();
            string str= webService.getAllCountriesAPI();
            //var list = new JavaScriptSerializer().Deserialize<object>(str);
            var list =  JsonConvert.DeserializeObject(str);
            JObject jObject = JObject.Parse(str);
            int count = ((Newtonsoft.Json.Linq.JContainer)list).Count;

            for ( int i = 0; i <= count; i++  )
            {
                //((Newtonsoft.Json.Linq.JContainer)(new System.Collections.Generic.Mscorlib_CollectionDebugView<Newtonsoft.Json.Linq.JToken>(((Newtonsoft.Json.Linq.JObject)(new System.Collections.Generic.Mscorlib_CollectionDebugView<Newtonsoft.Json.Linq.JToken>(((Newtonsoft.Json.Linq.JArray)list).ChildrenTokens).Items[0])).ChildrenTokens).Items[0])).First();
                string name = Convert.ToString(((Newtonsoft.Json.Linq.JContainer)((Newtonsoft.Json.Linq.JContainer)((Newtonsoft.Json.Linq.JContainer)list).First).First).First());
                ddlcountry.Items.Add(new ListItem("name", "name"));
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
    }
}