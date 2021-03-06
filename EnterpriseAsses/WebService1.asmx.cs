﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.IO;
using System.Xml.Linq;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Xml;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace EnterpriseAsses
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {//public static Request a = new Request();


       

        [WebMethod]
        public string getAllCountriesAPI()
        {
            string result = null;
            try
            {
                //GetCountry country = new GetCountry();
                XmlDocument xdoc = new XmlDocument();
                //string str = string.Format("https://dev-sandbox-api.airhob.com/sandboxapi/stays/v1/search");
                string str = string.Format("https://restcountries-v1.p.rapidapi.com/all");
                HttpWebRequest reqobj = (HttpWebRequest)WebRequest.Create(str);
                reqobj.Headers.Add("X-RapidAPI-Key", "e09fb1335dmsheb8f4e795507706p179b69jsn0fb20cfa8d25");
                reqobj.Method = "GET";
                reqobj.ContentType = "application/json;charset=utf-8";
                HttpWebResponse res = null;

                //string reqparam = "{ \"City\": \"Manchester\", \"Country\": \"United Kingdom\", \"Latitude\": \"\", \"Longitude\": \"\", \"FromDate\": \"2018-04-23\", \"ToDate\": \"2018-04-24\", \"ClientNationality\": \"IN\", \"Currency\": \"USD\", \"IsAddress\":\"false\", \"IsDescription\":\"false\", \"IsFacility\":\"false\", \"Occupancies\": [ { \"NoOfAdults\": 1, \"ChildrenAges\": [ 5, 7 ]}, { \"NoOfAdults\": 2 } ] }";
                //reqobj.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/35.0.1916.153 Safari/537.36";
                //reqobj.Headers.Add("HOTEL", "42f1d6eb-1998-4");


                var response = (HttpWebResponse)reqobj.GetResponse();
               
                using (Stream stream = (response.GetResponseStream()))
                {
                    StreamReader rd = new StreamReader(stream);
                    result = rd.ReadToEnd();
                    rd.Close();
                    //xdoc.LoadXml(result);

                    return result;

                }

            }

            catch (Exception ex)
            {
                return result;
            }
          





        }

        //[WebMethod]
        //public void getByCountryCode()
        //{
        //    //string str = string.Format("https://dev-sandbox-api.airhob.com/sandboxapi/stays/v1/search");
        //    //string str = string.Format("https://restcountries-v1.p.rapidapi.com/alpha");
        //    //HttpWebRequest reqobj = (HttpWebRequest)WebRequest.Create(str);
        //    //reqobj.Headers.Add("X-RapidAPI-Key", "e09fb1335dmsheb8f4e795507706p179b69jsn0fb20cfa8d25");
        //    //reqobj.Method = "POST";
        //    //reqobj.ContentType = "application/json;charset=utf-8";
        //    //HttpWebResponse res = null;

        //    //string reqparam = "{ \"codes\": \"co;nor\"}";
        //    ////string reqparam = "{ \"City\": \"Manchester\", \"Country\": \"United Kingdom\", \"Latitude\": \"\", \"Longitude\": \"\", \"FromDate\": \"2018-04-23\", \"ToDate\": \"2018-04-24\", \"ClientNationality\": \"IN\", \"Currency\": \"USD\", \"IsAddress\":\"false\", \"IsDescription\":\"false\", \"IsFacility\":\"false\", \"Occupancies\": [ { \"NoOfAdults\": 1, \"ChildrenAges\": [ 5, 7 ]}, { \"NoOfAdults\": 2 } ] }";
        //    ////reqobj.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/35.0.1916.153 Safari/537.36";
        //    ////reqobj.Headers.Add("HOTEL", "42f1d6eb-1998-4");

        //    //using (var streamwriter = new StreamWriter(reqobj.GetRequestStream()))

        //    //{
        //    //    streamwriter.Write(reqparam);
        //    //    streamwriter.Flush();
        //    //    streamwriter.Close();

        //    //    var response = (HttpWebResponse)reqobj.GetResponse();
        //    //   // string result = null;
        //    //    using (var streamreader = new StreamReader(response.GetResponseStream()))
        //    //    {
        //    //        //StreamReader rd = new StreamReader(stream);
        //    //        var result = streamreader.ReadToEnd();
        //    //        //rd.Close();
        //    //    }



        //    string str = string.Format("https://restcountries-v1.p.rapidapi.com/alpha/?codes=co%3Bnor");
        //    HttpWebRequest reqobj = (HttpWebRequest)WebRequest.Create(str);
        //    reqobj.Headers.Add("X-RapidAPI-Key", "e09fb1335dmsheb8f4e795507706p179b69jsn0fb20cfa8d25");
        //    reqobj.Method = "GET";
        //    reqobj.ContentType = "application/json;charset=utf-8";
        //    HttpWebResponse res = null;

        //    //string reqparam = "{ \"City\": \"Manchester\", \"Country\": \"United Kingdom\", \"Latitude\": \"\", \"Longitude\": \"\", \"FromDate\": \"2018-04-23\", \"ToDate\": \"2018-04-24\", \"ClientNationality\": \"IN\", \"Currency\": \"USD\", \"IsAddress\":\"false\", \"IsDescription\":\"false\", \"IsFacility\":\"false\", \"Occupancies\": [ { \"NoOfAdults\": 1, \"ChildrenAges\": [ 5, 7 ]}, { \"NoOfAdults\": 2 } ] }";
        //    //reqobj.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/35.0.1916.153 Safari/537.36";
        //    //reqobj.Headers.Add("HOTEL", "42f1d6eb-1998-4");


        //    var response = (HttpWebResponse)reqobj.GetResponse();
        //    string result = null;
        //    using (Stream stream = (response.GetResponseStream()))
        //    {
        //        StreamReader rd = new StreamReader(stream);
        //        result = rd.ReadToEnd();
        //        rd.Close();
        //    }

        //}
        //[WebMethod]
        //public void getCountryByCountryName()
        //{
        //    string city = "India";
        //    //string str = string.Format("https://dev-sandbox-api.airhob.com/sandboxapi/stays/v1/search");
        //    string str = string.Format("https://restcountries-v1.p.rapidapi.com/name/" + city);
        //    HttpWebRequest reqobj = (HttpWebRequest)WebRequest.Create(str);
        //    reqobj.Headers.Add("X-RapidAPI-Key", "e09fb1335dmsheb8f4e795507706p179b69jsn0fb20cfa8d25");
        //    reqobj.Method = "GET";
        //    reqobj.ContentType = "application/json;charset=utf-8";
        //    HttpWebResponse res = null;

        //    //string reqparam = "{ \"City\": \"Manchester\", \"Country\": \"United Kingdom\", \"Latitude\": \"\", \"Longitude\": \"\", \"FromDate\": \"2018-04-23\", \"ToDate\": \"2018-04-24\", \"ClientNationality\": \"IN\", \"Currency\": \"USD\", \"IsAddress\":\"false\", \"IsDescription\":\"false\", \"IsFacility\":\"false\", \"Occupancies\": [ { \"NoOfAdults\": 1, \"ChildrenAges\": [ 5, 7 ]}, { \"NoOfAdults\": 2 } ] }";
        //    //reqobj.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/35.0.1916.153 Safari/537.36";
        //    //reqobj.Headers.Add("HOTEL", "42f1d6eb-1998-4");


        //    var response = (HttpWebResponse)reqobj.GetResponse();
        //    string result = null;
        //    using (Stream stream = (response.GetResponseStream()))
        //    {
        //        StreamReader rd = new StreamReader(stream);

        //        result = rd.ReadToEnd();
        //        //var jobject = JsonConvert.DeserializeObject<XObject>(result);
        //        //var list = JsonConvert.DeserializeObject(result);
        //        var list = new JavaScriptSerializer().Deserialize<object>(result);
        //        rd.Close();
        //    }

        //}

        [WebMethod]
        public string getCountryByRegion( string region)
        {
            string result = null;
            try
            {
                // string region = "Africa";

                string str = string.Format("https://restcountries-v1.p.rapidapi.com/region/" + region);

                HttpWebRequest reqobj = (HttpWebRequest)WebRequest.Create(str);
                reqobj.Headers.Add("X-RapidAPI-Key", "e09fb1335dmsheb8f4e795507706p179b69jsn0fb20cfa8d25");
                reqobj.Method = "GET";
                reqobj.ContentType = "application/json;charset=utf-8";
                HttpWebResponse res = null;
                var response = (HttpWebResponse)reqobj.GetResponse();
               
                using (Stream stream = (response.GetResponseStream()))
                {
                    StreamReader rd = new StreamReader(stream);

                    result = rd.ReadToEnd();

                    var list = new JavaScriptSerializer().Deserialize<object>(result);
                    rd.Close();

                    return result;
                }
            }
            catch(Exception ex)
            {
                return result;
            }

        

        }

    
        [WebMethod]
        public string Currency(string from, string to)
        {
            string result = null;
            //string region = "Africa";
            try
            {
                string str = string.Format("https://api.exchangeratesapi.io/latest?base=" + from + "&symbols=" + to);
                // string str = string.Format("https://restcountries.eu/rest/v2/all");
                //string str = string.Format("http://data.fixer.io/api/latest?access_key=d45c2ead2e66ec108083fe9a90eaf39f&base&symbols=USD,AUD,CAD,PLN,MXN");

                HttpWebRequest reqobj = (HttpWebRequest)WebRequest.Create(str);
                // reqobj.Headers.Add("X-RapidAPI-Key", "e09fb1335dmsheb8f4e795507706p179b69jsn0fb20cfa8d25");
                reqobj.Method = "GET";
                reqobj.ContentType = "application/json;charset=utf-8";
                HttpWebResponse res = null;
                var response = (HttpWebResponse)reqobj.GetResponse();
              
                using (Stream stream = (response.GetResponseStream()))
                {
                    StreamReader rd = new StreamReader(stream);

                    result = rd.ReadToEnd();

                    var list = new JavaScriptSerializer().Deserialize<object>(result);


                    rd.Close();

                    return result;

                }
            }
            catch (Exception ex)
            {
                return result;
            }
            

        }


    }
}
