using Newtonsoft.Json;
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
        dynamic list;
        protected void Page_Load(object sender, EventArgs e)
        {
            WebService1 webService = new WebService1();
            GetCountry country = new GetCountry();
            string str = webService.getAllCountriesAPI();

            list = JsonConvert.DeserializeObject(str);



            foreach (var item in list)
            {
                string name = item["name"].Value;
                ddlFromcountry.Items.Add(new ListItem(name, name));
                ddlToCountry.Items.Add(new ListItem(name, name));
            }
            ddlFromcountry.Items.Insert(0, new ListItem("---Please Select---", "Please Select"));
            ddlToCountry.Items.Insert(0, new ListItem("---Please Select---", "Please Select"));

        }

        protected void btnconvert_Click(object sender, EventArgs e)
        {
            string FromCountry = ddlFromcountry.SelectedValue;
            string ToCountry = ddlToCountry.SelectedValue;
            string From = string.Empty;
            string To = string.Empty;

            if (FromCountry != "Please Select")
            {

                if (ToCountry != "Please Select")
                {
                    foreach (var item in list)
                    {
                        string name = item["name"].Value;

                        if (FromCountry == name)
                        {
                            From = item["currencies"][0].Value;
                        }

                        if (ToCountry == name)
                        {
                            To = item["currencies"][0].Value;
                        }



                    }

                    WebService1 webService = new WebService1();
                    string str = webService.Currency(From, To);
                    if (!String.IsNullOrEmpty(str))
                    {

                        dynamic amt = JsonConvert.DeserializeObject(str);

                        double convertedamt = amt["rates"][To].Value;
                        txtconvertamount.Text = Convert.ToString(convertedamt);
                        if (!String.IsNullOrEmpty(txtamount.Text))
                        {
                            if (txtamount.Text != "0")
                            {
                                double originalamt = Convert.ToDouble((Convert.ToInt32(txtamount.Text)) * (convertedamt));

                                txtconvertamount.Text = Convert.ToString(originalamt);
                                txtconvertamount.Text = String.Format("{0:0.00}", originalamt);
                            }


                        }
                        else
                        {
                            txtconvertamount.Text = String.Format("{0:0.00}", convertedamt);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong...Please select another country ')", true);
                    }


                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select country ')", true);
                }

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select country ')", true);
            }

        }


    }
}