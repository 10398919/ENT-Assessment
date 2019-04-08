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
           // ddlcountry.Items.Clear();
            ddlcountry.Items.Insert(0, new ListItem("---Please Select---", "Please Select"));
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlcountry.SelectedValue == "Please Select")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select country from dropdown')", true);
                    ddlcountry.Items.Clear();
                    ddlcountry.Items.Insert(0, new ListItem("---Please Select---", "Please Select"));
                }
                else
                {
                    if (rdbregion.Checked == true)
                    {
                        dynamic cnt = Session["Country"];
                        country(cnt);
                    }

                    else if (rdballcountry.Checked == true)
                   {
                        dynamic cnt = Session["Country"];
                        country(cnt);

                    }
                }
             
            }

            catch             
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong...Please select another country ')", true);
                
            }
         


           
            


        }

        protected void rdballcountry_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                table.Style.Add("display", "none");
                ddlcountry.Items.Clear();
                txtregion.Style.Add("display", "none");

                btnregion.Style.Add("display", "none");
                WebService1 webService = new WebService1();

                GetCountry country = new GetCountry();
                string str = webService.getAllCountriesAPI();

                if (string.IsNullOrEmpty(str))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong....')", true);
                    ddlcountry.Items.Insert(0, new ListItem("---Please Select---", "Please Select"));
                }
                else
                {
                    list = JsonConvert.DeserializeObject(str);

                    Session["Country"] = list;

                    foreach (var item in list)
                    {
                        string name = item["name"].Value;
                        ddlcountry.Items.Add(new ListItem(name, name));
                    }
                    ddlcountry.Items.Insert(0, new ListItem("---Please Select---", "Please Select"));

                }
          

            }
            catch(Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong...Please select another country ')", true);
           
            }
          
        }

        protected void rdbregion_CheckedChanged(object sender, EventArgs e)
        {

            ddlcountry.Items.Clear();
            table.Style.Add("display", "none");
            txtregion.Style.Add("display", "block");

            btnregion.Style.Add("display", "block");

            ddlcountry.Items.Insert(0, new ListItem("---Please Select---", "Please Select"));
        }

        protected void btnregion_Click(object sender, EventArgs e)        
        {
            try
            {
                if (string.IsNullOrEmpty(txtregion.Text))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter region')", true);
                    ddlcountry.Items.Clear();
                    ddlcountry.Items.Insert(0, new ListItem("---Please Select---", "Please Select"));
                }
                else
                {

                    WebService1 webService = new WebService1();

                    GetCountry country = new GetCountry();
                    country.countryByregion = txtregion.Text;
                    string str = webService.getCountryByRegion(country.countryByregion);

                    if (string.IsNullOrEmpty(str))
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong....')", true);
                      //  ddlcountry.Items.Insert(0, new ListItem("---Please Select---", "Please Select"));
                    }
                    else
                    {
                        list = JsonConvert.DeserializeObject(str);

                        Session["Country"] = list;

                        foreach (var item in list)
                        {
                            string name = item["name"].Value;
                            ddlcountry.Items.Add(new ListItem(name, name));
                        }
                    }
                   
                }
              
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong...Please select another country ')", true);
                ddlcountry.Items.Clear();
                ddlcountry.Items.Insert(0, new ListItem("---Please Select---", "Please Select"));
            }
         

        }

        public void country(dynamic list)
        {
            try
            {

                string CountryName = ddlcountry.SelectedValue;
                GetCountry gt = new GetCountry();

                int count = ((Newtonsoft.Json.Linq.JContainer)list).Count;

                foreach (var item in list)
                {
                    string name = item["name"].Value;

                    if (CountryName == name)
                    {
                        gt.CountryName = name;
                        gt.callingCodes = item["callingCodes"][0].Value;
                        gt.capital = item["capital"].Value;
                        gt.region = item["region"].Value;
                        gt.subregion = item["subregion"].Value;
                        gt.population = item["population"].Value;
                        gt.currencies = item["currencies"][0].Value;
                        gt.area = item["area"].Value;
                        gt.lat = item["latlng"][0].Value;
                        gt.longt = item["latlng"][1].Value;

                        countname.Text = gt.CountryName;
                        tdcapital.Text = gt.capital;
                        tdregion.Text = gt.region;
                        tdsubregion.Text = gt.subregion;
                        tdArea.Text = Convert.ToString(gt.area);
                        tdpop.Text = Convert.ToString(gt.population);
                        tdlat.Text = Convert.ToString(gt.lat);
                        logt.Text = Convert.ToString(gt.longt);
                        curr.Text = Convert.ToString(gt.currencies);
                        tdcallin.Text = gt.callingCodes;

                        table.Style.Add("display", "block");
                        break;

                    }


                }
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong...Please select another country ')", true);
            }


        }


        protected void btncurrencyconvert_Click(object sender, EventArgs e)
        {
            Response.Redirect("Results.aspx");


        }
    }
}