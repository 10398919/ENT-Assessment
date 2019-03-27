using System;
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
        public Request RequestXML(Request a)
        {
            Request req = new Request();
            req.cityID = a.cityID;
            req.cityName = a.cityName;
            req.Adults = a.Adults;
            req.Child = a.Child;



            return req;
        }
        [WebMethod]
        public List<Response> GetHotels(string cityid)

        {
            string cs = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("usp_Gethotel", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter parameter = new SqlParameter("@cityid", cityid);
                cmd.Parameters.AddWithValue("@cityid", cityid);
                List<Response> data = new List<Response>();

                con.Open();
                //  con.Execute("usp_Gethotel",parameter,commandtype:CommandType.StoredProcedure);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Response res = new Response();
                    res.cityID = reader["HotelCityId"].ToString();
                    res.cityName = reader["CityName"].ToString();
                    res.hotelId = reader["HotelID"].ToString();
                    res.hotelname = reader["HotelName"].ToString();
                    res.countryID = reader["HotelCountryId"].ToString();

                    data.Add(res);
                }
                return data;
            }
        }

        [WebMethod]
        public void getAllCountriesAPI()
        {
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
            string result = null;
            using (Stream stream = (response.GetResponseStream()))
            {
                StreamReader rd = new StreamReader(stream);
                result = rd.ReadToEnd();
                rd.Close();
            }






        }

        [WebMethod]
        public void getByCountryCode()
        {
            //string str = string.Format("https://dev-sandbox-api.airhob.com/sandboxapi/stays/v1/search");
            //string str = string.Format("https://restcountries-v1.p.rapidapi.com/alpha");
            //HttpWebRequest reqobj = (HttpWebRequest)WebRequest.Create(str);
            //reqobj.Headers.Add("X-RapidAPI-Key", "e09fb1335dmsheb8f4e795507706p179b69jsn0fb20cfa8d25");
            //reqobj.Method = "POST";
            //reqobj.ContentType = "application/json;charset=utf-8";
            //HttpWebResponse res = null;

            //string reqparam = "{ \"codes\": \"co;nor\"}";
            ////string reqparam = "{ \"City\": \"Manchester\", \"Country\": \"United Kingdom\", \"Latitude\": \"\", \"Longitude\": \"\", \"FromDate\": \"2018-04-23\", \"ToDate\": \"2018-04-24\", \"ClientNationality\": \"IN\", \"Currency\": \"USD\", \"IsAddress\":\"false\", \"IsDescription\":\"false\", \"IsFacility\":\"false\", \"Occupancies\": [ { \"NoOfAdults\": 1, \"ChildrenAges\": [ 5, 7 ]}, { \"NoOfAdults\": 2 } ] }";
            ////reqobj.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/35.0.1916.153 Safari/537.36";
            ////reqobj.Headers.Add("HOTEL", "42f1d6eb-1998-4");

            //using (var streamwriter = new StreamWriter(reqobj.GetRequestStream()))

            //{
            //    streamwriter.Write(reqparam);
            //    streamwriter.Flush();
            //    streamwriter.Close();

            //    var response = (HttpWebResponse)reqobj.GetResponse();
            //   // string result = null;
            //    using (var streamreader = new StreamReader(response.GetResponseStream()))
            //    {
            //        //StreamReader rd = new StreamReader(stream);
            //        var result = streamreader.ReadToEnd();
            //        //rd.Close();
            //    }



            string str = string.Format("https://restcountries-v1.p.rapidapi.com/alpha/?codes=co%3Bnor");
            HttpWebRequest reqobj = (HttpWebRequest)WebRequest.Create(str);
            reqobj.Headers.Add("X-RapidAPI-Key", "e09fb1335dmsheb8f4e795507706p179b69jsn0fb20cfa8d25");
            reqobj.Method = "GET";
            reqobj.ContentType = "application/json;charset=utf-8";
            HttpWebResponse res = null;

            //string reqparam = "{ \"City\": \"Manchester\", \"Country\": \"United Kingdom\", \"Latitude\": \"\", \"Longitude\": \"\", \"FromDate\": \"2018-04-23\", \"ToDate\": \"2018-04-24\", \"ClientNationality\": \"IN\", \"Currency\": \"USD\", \"IsAddress\":\"false\", \"IsDescription\":\"false\", \"IsFacility\":\"false\", \"Occupancies\": [ { \"NoOfAdults\": 1, \"ChildrenAges\": [ 5, 7 ]}, { \"NoOfAdults\": 2 } ] }";
            //reqobj.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/35.0.1916.153 Safari/537.36";
            //reqobj.Headers.Add("HOTEL", "42f1d6eb-1998-4");


            var response = (HttpWebResponse)reqobj.GetResponse();
            string result = null;
            using (Stream stream = (response.GetResponseStream()))
            {
                StreamReader rd = new StreamReader(stream);
                result = rd.ReadToEnd();
                rd.Close();
            }

        }
        [WebMethod]
        public void getCountryByCountryName()
        {
            string city = "India";
            //string str = string.Format("https://dev-sandbox-api.airhob.com/sandboxapi/stays/v1/search");
            string str = string.Format("https://restcountries-v1.p.rapidapi.com/name/" + city);
            HttpWebRequest reqobj = (HttpWebRequest)WebRequest.Create(str);
            reqobj.Headers.Add("X-RapidAPI-Key", "e09fb1335dmsheb8f4e795507706p179b69jsn0fb20cfa8d25");
            reqobj.Method = "GET";
            reqobj.ContentType = "application/json;charset=utf-8";
            HttpWebResponse res = null;

            //string reqparam = "{ \"City\": \"Manchester\", \"Country\": \"United Kingdom\", \"Latitude\": \"\", \"Longitude\": \"\", \"FromDate\": \"2018-04-23\", \"ToDate\": \"2018-04-24\", \"ClientNationality\": \"IN\", \"Currency\": \"USD\", \"IsAddress\":\"false\", \"IsDescription\":\"false\", \"IsFacility\":\"false\", \"Occupancies\": [ { \"NoOfAdults\": 1, \"ChildrenAges\": [ 5, 7 ]}, { \"NoOfAdults\": 2 } ] }";
            //reqobj.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/35.0.1916.153 Safari/537.36";
            //reqobj.Headers.Add("HOTEL", "42f1d6eb-1998-4");


            var response = (HttpWebResponse)reqobj.GetResponse();
            string result = null;
            using (Stream stream = (response.GetResponseStream()))
            {
                StreamReader rd = new StreamReader(stream);

                result = rd.ReadToEnd();
                //var jobject = JsonConvert.DeserializeObject<XObject>(result);
                //var list = JsonConvert.DeserializeObject(result);
                var list = new JavaScriptSerializer().Deserialize<object>(result);
                rd.Close();
            }

        }

        [WebMethod]
        public void getCountryByRegion()
        {
            string region = "Africa";
            
            string str = string.Format("https://restcountries-v1.p.rapidapi.com/region/"+region);

            HttpWebRequest reqobj = (HttpWebRequest)WebRequest.Create(str);
            reqobj.Headers.Add("X-RapidAPI-Key", "e09fb1335dmsheb8f4e795507706p179b69jsn0fb20cfa8d25");
            reqobj.Method = "GET";
            reqobj.ContentType = "application/json;charset=utf-8";
            HttpWebResponse res = null;
            var response = (HttpWebResponse)reqobj.GetResponse();
            string result = null;
            using (Stream stream = (response.GetResponseStream()))
            {
                StreamReader rd = new StreamReader(stream);

                result = rd.ReadToEnd();
               
                var list = new JavaScriptSerializer().Deserialize<object>(result);
                rd.Close();
            }

        }

        [WebMethod]
        public void trivago()
        {
            string str = string.Format("https://advertiser-site.com/api_implementation/hotel_data");
            // string str = string.Format("https://restcountries-v1.p.rapidapi.com/alpha");
            HttpWebRequest reqobj = (HttpWebRequest)WebRequest.Create(str);
            // reqobj.Headers.Add("X-RapidAPI-Key", "e09fb1335dmsheb8f4e795507706p179b69jsn0fb20cfa8d25");
            reqobj.Method = "POST";
            reqobj.ContentType = "application/x-www-form-urlencoded";
            HttpWebResponse res = null;

            //  string reqparam = "{ \"codes\": \"co;nor\"}";
            string reqparam = "{ \"City\": \"Manchester\", \"Country\": \"United Kingdom\", \"Latitude\": \"\", \"Longitude\": \"\", \"FromDate\": \"2018-04-23\", \"ToDate\": \"2018-04-24\", \"ClientNationality\": \"IN\", \"Currency\": \"USD\", \"IsAddress\":\"false\", \"IsDescription\":\"false\", \"IsFacility\":\"false\", \"Occupancies\": [ { \"NoOfAdults\": 1, \"ChildrenAges\": [ 5, 7 ]}, { \"NoOfAdults\": 2 } ] }";
            //reqobj.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/35.0.1916.153 Safari/537.36";
            //reqobj.Headers.Add("HOTEL", "42f1d6eb-1998-4");

            using (var streamwriter = new StreamWriter(reqobj.GetRequestStream()))

            {
                streamwriter.Write(reqparam);
                streamwriter.Flush();
                streamwriter.Close();

                var response = (HttpWebResponse)reqobj.GetResponse();
                // string result = null;
                using (var streamreader = new StreamReader(response.GetResponseStream()))
                {
                    //StreamReader rd = new StreamReader(stream);
                    var result = streamreader.ReadToEnd();
                    //rd.Close();
                }

            }

        }



        [WebMethod]
        public void Currency()
        {
            //string region = "Africa";

            //string str = string.Format("https://api.exchangeratesapi.io/latest?base=INR&symbols=USD");
            string str = string.Format("https://restcountries.eu/rest/v2/all");
            //string str = string.Format("http://data.fixer.io/api/latest?access_key=d45c2ead2e66ec108083fe9a90eaf39f&base&symbols=USD,AUD,CAD,PLN,MXN");

            HttpWebRequest reqobj = (HttpWebRequest)WebRequest.Create(str);
            // reqobj.Headers.Add("X-RapidAPI-Key", "e09fb1335dmsheb8f4e795507706p179b69jsn0fb20cfa8d25");
            reqobj.Method = "GET";
            reqobj.ContentType = "application/json;charset=utf-8";
            HttpWebResponse res = null;
            var response = (HttpWebResponse)reqobj.GetResponse();
            string result = null;
            using (Stream stream = (response.GetResponseStream()))
            {
                StreamReader rd = new StreamReader(stream);

                result = rd.ReadToEnd();

                var list = new JavaScriptSerializer().Deserialize<object>(result);
                
                rd.Close();

            }

        }


    }
}
