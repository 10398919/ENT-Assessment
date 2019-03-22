using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EnterpriseAsses
{
    public partial class Results : System.Web.UI.Page
    {
        string cityid = string.Empty;
        string str = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            cityid = Request["cityid"];
            getresult();
           
        }
        public void getresult()
        {
            string _getUri = HttpContext.Current.Request.Url.AbsoluteUri;
            WebService1 webService = new WebService1();
            List<Response> data = new List<Response>();
           data= webService.GetHotels(cityid);
            if (data.Count > 0)
            {
                str += "<div>";
                str += "Total hotels: " + data.Count;
                str += "</br>";
                str += "CityName: " + data[0].cityName;
                str += "</div>";
                for (int i=0;i<=(data.Count-1);i++)
                {
                    
                  
                    str += "</br>";
                    str += "<div>";
                    str += "Hotel Name: "+ data[i].hotelname;
                    str += "</div>";


                    str += "</div>";
                   
                }
                dvresult.InnerHtml = str;
            }
        }
    }
}