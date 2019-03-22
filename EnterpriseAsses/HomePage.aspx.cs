using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EnterpriseAsses
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
            
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            Request rq = new Request();
            rq.cityID = ddlcity.SelectedValue;
            rq.cityName = ddlcity.SelectedItem.Text;
            rq.Adults = ddlAdult.SelectedItem.Text;
            rq.Child = ddlchild.SelectedItem.Text;

            //WebService1 webService = new WebService1();
            //webService.RequestXML(rq);
            Response.Redirect("Results.aspx?cityid=" + rq.cityID);
            //Response.Redirect("WebService1.asmx");
        }
    }
}