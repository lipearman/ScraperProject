using SimpleBrowser;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TQM.DataEntity;
using System.Xml.Linq;
using System.Xml;
using OpenQA.Selenium;
using SimpleBrowser.WebDriver;
using System.Windows.Forms;
using Gekoproject;


using ScrapySharp.Core;
using ScrapySharp.Html.Parsing;
using ScrapySharp.Network;
using HtmlAgilityPack;
using ScrapySharp.Extensions;
using ScrapySharp.Html.Forms;
using System.Net;
using mshtml;



namespace TQM
{
    class Program
    {

        //public class Datas
        //{
        //    public IList<Data> Data { get; set; }
        //}
        public class Data
        {
            public string ID { get; set; }
            public string MODEL { get; set; }
        }
        static IList<Data> read_Model(string _data)
        {

            JObject _Object = JObject.Parse(_data);
            JToken Datas = _Object["Datas"].Children().First();
            // get JSON result objects into a list

            JObject _Object2 = JObject.Parse("{" + Datas.ToString() + "}");
            IList<JToken> results = _Object2["Data"].Children().ToList();

            // serialize JSON results into .NET objects
            IList<Data> Results = new List<Data>();
            foreach (JToken item in results)
            {
                Data _json = JsonConvert.DeserializeObject<Data>(item.ToString());

                Results.Add(_json);

            }

            return Results;
        }


        static List<String> GetCarYear()
        {
            List<string> _CarYear = new List<string>();
            _CarYear.Add("2017");
            _CarYear.Add("2016");
            _CarYear.Add("2015");
            _CarYear.Add("2014");
            _CarYear.Add("2013");
            _CarYear.Add("2012");
            _CarYear.Add("2011");
            _CarYear.Add("2010");
            _CarYear.Add("2009");
            _CarYear.Add("2008");
            _CarYear.Add("2007");
            _CarYear.Add("2006");
            _CarYear.Add("2005");
            _CarYear.Add("2004");
            _CarYear.Add("2003");
            _CarYear.Add("2002");
            _CarYear.Add("2001");
            _CarYear.Add("2000");
            _CarYear.Add("1999");
            _CarYear.Add("1998");
            _CarYear.Add("1997");
            _CarYear.Add("1996");
            _CarYear.Add("1995");
            _CarYear.Add("1994");
            _CarYear.Add("1993");
            _CarYear.Add("1992");
            _CarYear.Add("1991");
            _CarYear.Add("1990");
            _CarYear.Add("1989");
            _CarYear.Add("1988");
            _CarYear.Add("1987");
            _CarYear.Add("1986");
            _CarYear.Add("1985");
            _CarYear.Add("1984");
            _CarYear.Add("1983");
            _CarYear.Add("1982");
            _CarYear.Add("1981");
            _CarYear.Add("1980");
            _CarYear.Add("1979");
            _CarYear.Add("1978");
            _CarYear.Add("1977");
            _CarYear.Add("1976");
            _CarYear.Add("1975");
            _CarYear.Add("1974");
            _CarYear.Add("1973");
            _CarYear.Add("1972");
            _CarYear.Add("1971");
            _CarYear.Add("1970");
            _CarYear.Add("1969");
            _CarYear.Add("1968");
            _CarYear.Add("1967");
            _CarYear.Add("1966");




            return _CarYear;
        }
        static List<String> GetCarInsure()
        {
            List<string> _CarInsure = new List<string>();
            _CarInsure.Add("1");
            _CarInsure.Add("2");
            _CarInsure.Add("20");
            _CarInsure.Add("3");
            _CarInsure.Add("30");
            return _CarInsure;
        }
        static List<String> GetInsurer()
        {
            List<string> _Insurer = new List<string>();
            _Insurer.Add("BKI");
            _Insurer.Add("STY");
            _Insurer.Add("KKA");
            _Insurer.Add("CHP");
            _Insurer.Add("TUI");
            _Insurer.Add("NIC");
            _Insurer.Add("DVI");
            _Insurer.Add("NHI");
            _Insurer.Add("BUN");
            _Insurer.Add("MMF");
            _Insurer.Add("MIT");
            _Insurer.Add("VIS");
            _Insurer.Add("SCSMG");
            _Insurer.Add("AIC");
            _Insurer.Add("SMK");
            _Insurer.Add("SEI");
            _Insurer.Add("KIT");
            _Insurer.Add("GIT");
            _Insurer.Add("CPY");
            _Insurer.Add("DVS");
            _Insurer.Add("MTI");
            _Insurer.Add("EIC");
            _Insurer.Add("AII");
            _Insurer.Add("MSI");
            _Insurer.Add("AXA");
            _Insurer.Add("LMG");
            _Insurer.Add("SRM");
            _Insurer.Add("THI");
            _Insurer.Add("TVI");
            _Insurer.Add("TSR");
            _Insurer.Add("ABI");

            return _Insurer;
        }

        static void GetModel()
        {

            //var _CarBrand = GetCarBrand();
            var _CarYear = GetCarYear();
            //var _CarInsure = GetCarInsure();
            //var _Insurer = GetInsurer();


            var browser = new Browser();

            int i = 0;
            using (var dc = new TQMDataContext())
            {
                var _CarBrand = (from c in dc.tblCarBrands select c).ToList();

                var _CarModel = new List<tblCarModel>();

                foreach (var item_year in _CarYear)
                {
                    foreach (var item_CarBrand in _CarBrand)
                    {

                        browser.Navigate(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "GetModel.html"));
                        browser.Find("carbrandid").Value = item_CarBrand.CarBrandCode;
                        browser.Find("CARYEAR").Value = item_year;
                        browser.Find(ElementType.Button, "name", "commit").Click();


                        if (browser.Text != "1")
                        {
                            var _Model = read_Model(browser.Text);
                            foreach (var item_CarModel in _Model)
                            {
                                i++;
                                _CarModel.Add(new tblCarModel()
                                {
                                    ID = i
                                    ,
                                    CarYear = item_year
                                    ,
                                    CarBrandCode = item_CarBrand.CarBrandCode
                                    ,
                                    CarModelCode = item_CarModel.ID
                                    ,
                                    CarModelName = item_CarModel.MODEL
                                });

                                Console.WriteLine(String.Format("No.{0} CarBrand: {1} , CarModel: {2} , CarYear: {3} ", i.ToString(), item_CarBrand.CarBrandName, item_CarModel.MODEL, item_year));
                            }
                        }
                    }
                }
                dc.tblCarModels.InsertAllOnSubmit(_CarModel);
                dc.SubmitChanges();

            }


        }
        static void GetSubModel()
        {

            var _CarSubModel = new List<tblCarSubModel>();

            var browser = new Browser();

            int i = 0;
            using (var dc = new TQMDataContext())
            {
                var _CarModel = (from c in dc.tblCarModels select c).ToList();




                foreach (var item_CarModel in _CarModel)
                {

                    browser.Navigate(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "GetSubModel.html"));
                    browser.Find("Makecode").Value = item_CarModel.CarBrandCode;
                    browser.Find("CARMODEL").Value = item_CarModel.CarModelCode;
                    browser.Find("CarYear").Value = item_CarModel.CarYear;
                    browser.Find(ElementType.Button, "name", "commit").Click();


                    foreach (var item in browser.Select("option"))
                    {
                        if (!String.IsNullOrWhiteSpace(item.GetAttribute("value")))
                        {
                            i++;
                            _CarSubModel.Add(new tblCarSubModel()
                            {
                                ID = i
                                ,
                                CarYear = item_CarModel.CarYear
                                ,
                                CarBrandCode = item_CarModel.CarBrandCode
                                ,
                                CarModelCode = item_CarModel.CarModelCode
                                ,
                                CarSubModelName = item.Value
                                ,
                                CarSubModelCode = item.GetAttribute("value")
                            });
                        }

                        Console.WriteLine(String.Format("No.{0} CarBrand: {1} , CarSubModel: {2} , CarYear: {3} ", i.ToString(), item_CarModel.CarBrandCode, item.Value, item_CarModel.CarYear));
                    }



                }

                dc.tblCarSubModels.InsertAllOnSubmit(_CarSubModel);
                dc.SubmitChanges();

            }


        }
        static void GetCC()
        {

            var _CarCC = new List<tblCarCC>();

            var browser = new Browser();

            int i = 0;
            using (var dc = new TQMDataContext())
            {
                var _CarModel = (from c in dc.tblCarModels select c).ToList();




                foreach (var item_CarModel in _CarModel)
                {

                    browser.Navigate(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "GetCC.html"));
                    browser.Find("Makecode").Value = item_CarModel.CarBrandCode;
                    browser.Find("CARMODEL").Value = item_CarModel.CarModelCode;
                    browser.Find("CarYear").Value = item_CarModel.CarYear;
                    browser.Find(ElementType.Button, "name", "commit").Click();


                    foreach (var item in browser.Select("option"))
                    {
                        if (!String.IsNullOrWhiteSpace(item.GetAttribute("value")))
                        {
                            i++;
                            _CarCC.Add(new tblCarCC()
                            {
                                ID = i
                                ,
                                CarYear = item_CarModel.CarYear
                                ,
                                CarBrandCode = item_CarModel.CarBrandCode
                                ,
                                CarModelCode = item_CarModel.CarModelCode
                                ,
                                CarCCName = item.Value
                                ,
                                CarCCCode = item.GetAttribute("value")
                            });
                        }

                        Console.WriteLine(String.Format("No.{0} CarBrand: {1} , CarModel: {2} , CarYear: {3} , CC:{4} ", i.ToString(), item_CarModel.CarBrandCode, item_CarModel.CarModelName, item_CarModel.CarYear, item.Value));
                    }



                }

                dc.tblCarCCs.InsertAllOnSubmit(_CarCC);
                dc.SubmitChanges();

            }


        }
        static void GetSubModelCC()
        {



            var browser = new Browser();

            int i = 0;
            using (var dc = new TQMDataContext())
            {
                var _CarSubModel = (from c in dc.tblCarSubModels orderby c.ID select c).ToList();

                foreach (var item_CarSubModel in _CarSubModel)
                {

                    browser.Navigate(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "GetSubModelCC.html"));
                    browser.Find("Makecode").Value = item_CarSubModel.CarBrandCode;
                    browser.Find("CARMODEL").Value = item_CarSubModel.CarModelCode;
                    browser.Find("CarYear").Value = item_CarSubModel.CarYear;
                    browser.Find("vehiclekey").Value = item_CarSubModel.CarSubModelCode;
                    browser.Find(ElementType.Button, "name", "commit").Click();

                    var _CarSubModelCC = new List<tblCarSubModelCC>();

                    foreach (var item in browser.Select("option"))
                    {
                        if (!String.IsNullOrWhiteSpace(item.GetAttribute("value")))
                        {
                            i++;
                            _CarSubModelCC.Add(new tblCarSubModelCC()
                            {
                                ID = i
                                ,
                                CarSubModelID = item_CarSubModel.ID
                                ,
                                CarYear = item_CarSubModel.CarYear
                                ,
                                CarBrandCode = item_CarSubModel.CarBrandCode
                                ,
                                CarModelCode = item_CarSubModel.CarModelCode
                                ,
                                CarSubModelCode = item_CarSubModel.CarSubModelCode
                                ,
                                CarSubModelCCName = item.Value
                                ,
                                CarSubModelCCCode = item.GetAttribute("value")
                            });
                        }

                        Console.WriteLine(String.Format("No.{0} CarBrand: {1} , CarSubModel: {2} , CarYear: {3} , CC:{4} ", i.ToString(), item_CarSubModel.CarBrandCode, item_CarSubModel.CarSubModelName, item_CarSubModel.CarYear, item.Value));
                    }

                    dc.tblCarSubModelCCs.InsertAllOnSubmit(_CarSubModelCC);
                    dc.SubmitChanges();

                }



            }


        }

        static void GetSubModelSuminsured()
        {



            var browser = new Browser();

            int i = 0;
            using (var dc = new TQMDataContext())
            {
                var _CarSubModel = (from c in dc.tblCarSubModels orderby c.ID select c).ToList();

                foreach (var item_CarSubModel in _CarSubModel)
                {
                    browser.Navigate(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "GetSubModelSuminsured.html"));
                    browser.Find("Makecode").Value = item_CarSubModel.CarBrandCode;
                    browser.Find("carmodel").Value = item_CarSubModel.CarModelCode;
                    browser.Find("caryear").Value = item_CarSubModel.CarYear;
                    browser.Find("VEHICLEKEY").Value = item_CarSubModel.CarSubModelCode;
                    browser.Find(ElementType.Button, "name", "commit").Click();

                    var _CarSubModelSumInsured = new List<tblCarSubModelSumInsured>();

                    foreach (var item in browser.Select("option"))
                    {
                        if (!String.IsNullOrWhiteSpace(item.GetAttribute("value")))
                        {
                            i++;
                            _CarSubModelSumInsured.Add(new tblCarSubModelSumInsured()
                            {
                                ID = i
                                ,
                                CarYear = item_CarSubModel.CarYear
                                ,
                                CarBrandCode = item_CarSubModel.CarBrandCode
                                ,
                                CarModelCode = item_CarSubModel.CarModelCode
                                ,
                                CarSubModelCode = item_CarSubModel.CarSubModelCode
                                ,
                                CarSuminsured = Convert.ToInt32(item.GetAttribute("value"))
                                ,
                                CarSuminsuredText = item.Value.ToString()
                            });
                        }

                        Console.WriteLine(String.Format("No.{0} CarBrand: {1} , CarSubModel: {2} , CarYear: {3} , SuminSured:{4} ", i.ToString(), item_CarSubModel.CarBrandCode, item_CarSubModel.CarSubModelName, item_CarSubModel.CarYear, item.Value));
                    }

                    dc.tblCarSubModelSumInsureds.InsertAllOnSubmit(_CarSubModelSumInsured);
                    dc.SubmitChanges();

                }



            }


        }

        static void GetSearch()
        {

            //WebPage PageResult;

            //ScrapingBrowser Browser = new ScrapingBrowser();
            //Browser.AllowAutoRedirect = true; // Browser has many settings you can access in setup
            //Browser.AllowMetaRedirect = true;
            //Browser.Encoding = Encoding.UTF8;

            //var proxyserver = new WebProxy("118.175.2.186", 3128);
            //proxyserver.Credentials = CredentialCache.DefaultNetworkCredentials;

            //Uri proxyserver = new Uri("118.173.234.132:8080");


            //WebProxy proxyObject = new WebProxy("203.156.126.55", 3129);
            //WebProxy proxyObject = new WebProxy("118.173.234.132", 8080);
            //WebProxy proxyObject = new WebProxy("203.146.189.61", 80);
            //WebProxy proxyObject = new WebProxy("203.185.96.138", 80);





            int i = 0;


            using (var dc = new TQMDataContext())
            {
                var _CarSearch = (from c in dc.V_Searches orderby c.categories_insurance_year descending, c.categories_insurance_brand, c.categories_insurance_age select c).ToList();


                if (dc.tblMotorSearches.Count() > 0) i = dc.tblMotorSearches.Max(x => x.ID);


                WebPage PageResult;

                ScrapingBrowser Browser = new ScrapingBrowser();
                Browser.AllowAutoRedirect = true; // Browser has many settings you can access in setup
                Browser.AllowMetaRedirect = true;
                Browser.Encoding = Encoding.UTF8;


                foreach (var item_Search in _CarSearch)
                {

                    StringBuilder sb = new StringBuilder();
                    sb.AppendFormat("categories_insurance_year={0}", item_Search.categories_insurance_year);
                    sb.AppendFormat("&categories_insurance_brand={0}", item_Search.categories_insurance_brand);
                    sb.AppendFormat("&categories_insurance_age={0}", item_Search.categories_insurance_age);
                    sb.AppendFormat("&categories_insurance_cc={0}", item_Search.categories_insurance_cc);
                    sb.AppendFormat("&VEHICLEKEY={0}", item_Search.VEHICLEKEY);
                    //sb.AppendFormat("&VEHICLEKEY={0}", item_Search.CarSubModelCode);
                    sb.AppendFormat("&CoverMin={0}", item_Search.CoverMin);
                    sb.AppendFormat("&CoverMax={0}", item_Search.CoverMax);
                    sb.Append("&CARUSAGE=110");
                    sb.Append("&categories_insurance=1");
                    sb.Append("&page=index");

                    Browser = new ScrapingBrowser();
                    Browser.Encoding = Encoding.UTF8;
                    //Browser.Proxy = proxyserver;




                    PageResult = Browser.NavigateToPage(new Uri("https://www.tqm.co.th/sql/read_cookie_search.php")
                        , HttpVerb.Post
                        , sb.ToString());

                    //var a = PageResult.Browser.AjaxDownloadString(new Uri("https://www.tqm.co.th/sql/read_cookie_search.php"));


                    //Console.WriteLine(sb.ToString());



                    var html = PageResult.Content.ToString();

                    //var browser = new Browser();
                    ////browser.RefererMode = Browser.RefererModes.UnsafeUrl;
                    //browser.AutoRedirect = true;

                    //browser.Navigate(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "GetSearch.html"));




                    //browser.Find("categories_insurance_year").Value = item_Search.categories_insurance_year;
                    //browser.Find("categories_insurance_brand").Value = item_Search.categories_insurance_brand;
                    //browser.Find("categories_insurance_age").Value = item_Search.categories_insurance_age;
                    //browser.Find("categories_insurance_cc").Value = item_Search.categories_insurance_cc;
                    //browser.Find("VEHICLEKEY").Value = item_Search.VEHICLEKEY + "," + item_Search.categories_insurance_cc;
                    //browser.Find("CoverMin").Value = item_Search.CoverMin.ToString();
                    //browser.Find("CoverMax").Value = item_Search.CoverMax.ToString();
                    //browser.Find(ElementType.Button, "name", "commit").Click();

                    ////browser.AutoRedirect = true;
                  

                    ////var html = browser.CurrentHtml.ToString();
                    //var b = browser.Find("sort_package").FirstOrDefault();
                    //var html = ((System.Xml.Linq.XContainer)(b.XElement)).ToString();
                    // From String

                    var sort_package = new HtmlAgilityPack.HtmlDocument();
                    sort_package.LoadHtml(html);
                    var sort_package_nodes = sort_package.DocumentNode.Descendants()
                   .Where(n => n.GetAttributeValue("id", "").StartsWith("sort_package"))
                   .FirstOrDefault();


                    var mydoc = new  HtmlAgilityPack.HtmlDocument();
                    mydoc.LoadHtml(sort_package_nodes.InnerHtml);
                    // With LINQ	
                    var nodes = mydoc.DocumentNode.Descendants()
                    .Where(n => n.GetAttributeValue("id", "").StartsWith("searh_"))
                    .ToList();

                    var domcount = nodes.Count();

                    foreach (var item in nodes)
                    {
                        var docx = new HtmlAgilityPack.HtmlDocument();
                        docx.OptionOutputOriginalCase = true;
                        docx.LoadHtml(item.OuterHtml);

                        var doc = docx.DocumentNode;


                        var _MotorSearch = new List<tblMotorSearch>();

                        if (!String.IsNullOrEmpty(item.Id))
                        {
                            i++;
                            var _MotorSearch_item = new tblMotorSearch();
                            _MotorSearch_item.ID = i;
                            _MotorSearch_item.CarBrandCode = item_Search.categories_insurance_brand;
                            _MotorSearch_item.CarModelCode = item_Search.categories_insurance_age;
                            _MotorSearch_item.CarSubModelCode = item_Search.VEHICLEKEY;
                            _MotorSearch_item.CarCCName = item_Search.CarCCName;
                            _MotorSearch_item.CarCCCode = item_Search.categories_insurance_cc;
                            _MotorSearch_item.CarYear = item_Search.categories_insurance_year;
                            _MotorSearch_item.CarSubModelName = item_Search.CarSubModelName;



                            _MotorSearch_item.txtSubmitID = doc.SelectNodes("/div[1]/@id[1]")[0].Id.Replace("searh_", "");
                            //[txtInsurer]
                            _MotorSearch_item.txtInsurer = doc.SelectNodes("/div[1]/div[1]/div[1]/a[1]/@title[1]")[0].Attributes["title"].Value;
                            //,[txtPremium]
                            _MotorSearch_item.txtPremium = doc.SelectNodes("/div[1]/div[1]/div[2]/h2[2]")[0].InnerText.Replace("บาท", "").Replace(",", "").Trim();
                            //,[txtLogo]
                            _MotorSearch_item.txtLogo = doc.SelectNodes("/div[1]/div[1]/div[3]/a[1]/img[1]/@src[1]")[0].Attributes["src"].Value;

                            //,[txtCarType]
                            _MotorSearch_item.txtCarType = doc.SelectNodes("/div[1]/div[1]/div[4]/ul[1]/li[1]/span[1]")[0].InnerText.Replace(":", "").Trim();
                            //if (doc.SelectNodes("/div[1]/div[1]/div[4]/ul[1]/li[1]/span[1]") != null)
                            //{
                            //    _MotorSearch_item.txtCarType = doc.SelectNodes("/div[1]/div[1]/div[3]/table[1]/tr[1]/td[3]/span[1]")[0].InnerText;
                            //}
                            //else
                            //{
                            //    if (doc.SelectNodes("/div[1]/div[1]/div[3]/table[1]/tbody[1]/tr[1]/td[3]/span[1]") != null)
                            //    {
                            //        _MotorSearch_item.txtCarType = doc.SelectNodes("/div[1]/div[1]/div[3]/table[1]/tbody[1]/tr[1]/td[3]/span[1]")[0].InnerText;
                            //    }
                            //}


                            //,[txtGarageType]
                            _MotorSearch_item.txtGarageType = doc.SelectNodes("/div[1]/div[1]/div[4]/ul[1]/li[2]/span[1]")[0].InnerText.Replace(":", "").Trim();
                            
                            //if (doc.SelectNodes("/div[1]/div[1]/div[3]/table[1]/tr[2]/td[3]/span[1]") != null)
                            //{
                            //    _MotorSearch_item.txtGarageType = doc.SelectNodes("/div[1]/div[1]/div[3]/table[1]/tr[2]/td[3]/span[1]")[0].InnerText;
                            //}
                            //else
                            //{
                            //    if (doc.SelectNodes("/div[1]/div[1]/div[3]/table[1]/tbody[1]/tr[2]/td[3]/span[1]") != null)
                            //    {
                            //        _MotorSearch_item.txtGarageType = doc.SelectNodes("/div[1]/div[1]/div[3]/table[1]/tbody[1]/tr[2]/td[3]/span[1]")[0].InnerText;
                            //    }
                            //}


                            //,[txtSuminsured]
                            _MotorSearch_item.txtSuminsured = doc.SelectNodes("/div[1]/div[1]/div[4]/ul[1]/li[3]/span[1]")[0].InnerText.Replace(":", "").Trim();

                            //,[txtSuminsured]
                            _MotorSearch_item.txtPolType = doc.SelectNodes("/div[1]/div[1]/div[1]/a[1]/img[1]/@alt[1]")[0].Attributes["alt"].Value;
                            

                            //,[txtSuminsured]
                            //_MotorSearch_item.txtComment = doc.SelectNodes("/div[1]/div[1]/#comment[1]")[0].InnerText;
                            
                            //if (doc.SelectNodes("/div[1]/div[1]/div[3]/table[1]/tr[3]/td[3]/span[1]") != null)
                            //{
                            //    _MotorSearch_item.txtSuminsured = doc.SelectNodes("/div[1]/div[1]/div[3]/table[1]/tr[3]/td[3]/span[1]")[0].InnerText;
                            //}
                            //else
                            //{
                            //    if (doc.SelectNodes("/div[1]/div[1]/div[3]/table[1]/tbody[1]/tr[3]/td[3]/span[1]") != null)
                            //    {
                            //        _MotorSearch_item.txtSuminsured = doc.SelectNodes("/div[1]/div[1]/div[3]/table[1]/tbody[1]/tr[3]/td[3]/span[1]")[0].InnerText;
                            //    }
                            //}


                            //,[txtDeduct]
                            _MotorSearch_item.txtDeduct = doc.SelectNodes("/div[1]/div[1]/div[4]/ul[1]/li[4]/span[1]")[0].InnerText.Replace(":", "").Trim();
                            
                            //if (doc.SelectNodes("/div[1]/div[1]/div[3]/table[1]/tr[4]/td[3]/span[1]") != null)
                            //{
                            //    _MotorSearch_item.txtDeduct = doc.SelectNodes("/div[1]/div[1]/div[3]/table[1]/tr[4]/td[3]/span[1]")[0].InnerText;
                            //}
                            //else
                            //{
                            //    if (doc.SelectNodes("/div[1]/div[1]/div[3]/table[1]/tbody[1]/tr[4]/td[3]/span[1]") != null)
                            //    {
                            //        _MotorSearch_item.txtDeduct = doc.SelectNodes("/div[1]/div[1]/div[3]/table[1]/tbody[1]/tr[4]/td[3]/span[1]")[0].InnerText;
                            //    }
                            //}



                            //,[txtGarageCount]
                            _MotorSearch_item.txtGarageCount = doc.SelectNodes("/div[1]/div[1]/div[4]/ul[2]/li[1]/span[1]/a[1]")[0].InnerText;
                            //,[txtCover1]
                            _MotorSearch_item.txtCover1 = doc.SelectNodes("/div[1]/div[1]/div[4]/ul[2]/li[2]/span[1]/i[1]/@class[1]")[0].Attributes["class"].Value;
                            //,[txtCoverFlood]
                            _MotorSearch_item.txtCoverFlood = doc.SelectNodes("/div[1]/div[1]/div[4]/ul[2]/li[3]/span[1]/i[1]/@class[1]")[0].Attributes["class"].Value;
                            //,[txtCarCheck]
                            _MotorSearch_item.txtCarCheck = doc.SelectNodes("/div[1]/div[1]/div[4]/ul[2]/li[4]/span[1]/i[1]/@class[1]")[0].Attributes["class"].Value;


                            _MotorSearch_item.txtSubmitStatus = doc.SelectNodes("/div[1]/div[1]/div[5]/a[2]")[0].Attributes["onclick"].Value;

                            if (_MotorSearch_item.txtSubmitStatus.IndexOf("'C'") > -1)
                            {
                                //,[txtDataC]
                                if (doc.SelectNodes("/div[1]/div[1]/div[5]/a[2]/@data-c[1]").Count > 0) _MotorSearch_item.txtDataC = doc.SelectNodes("/div[1]/div[1]/div[4]/a[1]")[0].Attributes["data-c"].Value;
                                //,[txtDataP]
                                if (doc.SelectNodes("/div[1]/div[1]/div[5]/a[2]/@data-p[1]").Count > 0) _MotorSearch_item.txtDataP = doc.SelectNodes("/div[1]/div[1]/div[4]/a[1]")[0].Attributes["data-p"].Value;
                                //,[txtDataPV]
                                if (doc.SelectNodes("/div[1]/div[1]/div[5]/a[2]/@data-pv[1]").Count > 0) _MotorSearch_item.txtDataPV = doc.SelectNodes("/div[1]/div[1]/div[4]/a[1]")[0].Attributes["data-pv"].Value;
                                //,[txtDataVAT]
                                if (doc.SelectNodes("/div[1]/div[1]/div[5]/a[2]/@data-vat[1]").Count > 0) _MotorSearch_item.txtDataVAT = doc.SelectNodes("/div[1]/div[1]/div[4]/a[1]")[0].Attributes["data-vat"].Value;
                                //,[txtDataTax]
                                if (doc.SelectNodes("/div[1]/div[1]/div[5]/a[2]/@data-tax[1]").Count > 0) _MotorSearch_item.txtDataTax = doc.SelectNodes("/div[1]/div[1]/div[4]/a[1]")[0].Attributes["data-tax"].Value;
                                //,[txtDataAge]
                                if (doc.SelectNodes("/div[1]/div[1]/div[5]/a[2]/@data-age[1]").Count > 0) _MotorSearch_item.txtDataAge = doc.SelectNodes("/div[1]/div[1]/div[4]/a[1]")[0].Attributes["data-age"].Value;


                            }
                            //else
                            //{

                            //    if (doc.SelectNodes("/div[1]/div[1]/div[4]/a[1]")[0].Attributes["onclick"].Value.IndexOf("'MT'") > -1)
                            //    {
                            //        _MotorSearch_item.txtSubmitStatus = "MT";
                            //    }
                            //}

                            _MotorSearch.Add(_MotorSearch_item);


                            Console.WriteLine(String.Format("No.{0} Brand: {1}, Model: {2}, CarYear: {3}, PolType: {4}, SuminSured:{5}, Premium:{6}, {7} "
                                , i.ToString()
                                , item_Search.categories_insurance_brand
                                , item_Search.VEHICLEKEY
                                , item_Search.categories_insurance_year
                                , _MotorSearch_item.txtPolType
                                , _MotorSearch_item.txtSuminsured
                                , _MotorSearch_item.txtPremium
                                , _MotorSearch_item.txtSubmitStatus

                                ));

                        }


                        dc.tblMotorSearches.InsertAllOnSubmit(_MotorSearch);
                        dc.SubmitChanges();


                        dc.ExecuteCommand("update tblCarSubModelSumInsured set IsPost=1 where CarSubModelCode='" + item_Search .CarSubModelCode + "'");
                    }

                    Console.WriteLine(domcount);

                }

            }


        }


        static void GetCoverage()
        {

            WebPage PageResult;

            ScrapingBrowser Browser = new ScrapingBrowser();
            Browser.AllowAutoRedirect = true; // Browser has many settings you can access in setup
            Browser.AllowMetaRedirect = true;
            //Browser.Encoding = Encoding.UTF8;

            //var proxyserver = new WebProxy("202.29.221.102", 80);
            //proxyserver.Credentials = CredentialCache.DefaultNetworkCredentials;

            //Uri proxyserver = new Uri("118.173.234.132:8080");


            //WebProxy proxyObject = new WebProxy("203.156.126.55", 3129);
            //WebProxy proxyObject = new WebProxy("118.173.234.132", 8080);
            //WebProxy proxyObject = new WebProxy("203.146.189.61", 80);
            //WebProxy proxyObject = new WebProxy("203.185.96.138", 80);





            int i = 0;
            int _Coverage = 0;

            using (var dc = new TQMDataContext())
            {

                var _maxid = dc.tblMotorCoverages.Max(x => x.SearchID).ToString();
                if (_maxid != "")
                {
                    _Coverage = Convert.ToInt32(_maxid);
                    i = dc.tblMotorCoverages.Max(x => x.ID);
                }

                var _CarSearch = (from c in dc.tblMotorSearches where c.ID > _Coverage orderby c.CarYear descending, c.CarBrandCode, c.CarModelCode select c).ToList();







                foreach (var item_Search in _CarSearch)
                {
                    i++;

                    StringBuilder sb = new StringBuilder();

                    sb.Append("PRODUCTTYPE=MT");
                    sb.AppendFormat("&AMOUNT={0}", item_Search.txtDataP);
                    sb.AppendFormat("&AMOUNTNET={0}", item_Search.txtDataPV);
                    sb.AppendFormat("&caryear={0}", item_Search.CarYear);
                    sb.AppendFormat("&carbrand={0}", item_Search.CarBrandCode);
                    sb.AppendFormat("&carmodel={0}", item_Search.CarModelCode);
                    sb.AppendFormat("&CC={0}", item_Search.CarCCCode);
                    sb.AppendFormat("&VEHICLEKEY={0}", item_Search.CarSubModelCode);
                    sb.AppendFormat("&DRIVER_AGE={0}", "");
                    sb.AppendFormat("&CARUSAGE={0}", "110");
                    sb.AppendFormat("&COVER={0}", item_Search.txtDataC);
                    sb.AppendFormat("&PRODUCTID={0}", item_Search.txtSubmitID);
                    sb.AppendFormat("&MX_AGEDISCOUNT={0}", item_Search.txtDataAge);
                    sb.AppendFormat("&VAT={0}", item_Search.txtDataVAT);
                    sb.AppendFormat("&TAX={0} ", item_Search.txtDataTax);

                    Browser = new ScrapingBrowser();
                    Browser.Encoding = Encoding.UTF8;
                    //Browser.Proxy = proxyserver;

                    //class="main_box"
                    //class="col_product_detail"

                    PageResult = Browser.NavigateToPage(new Uri("https://www.tqm.co.th/session.php")
                        , HttpVerb.Post
                        , sb.ToString());



                    var _MotorCoverage = new tblMotorCoverage();
                    _MotorCoverage.ID = i;
                    _MotorCoverage.SearchID = item_Search.ID;



                    var main_box = PageResult.Html.CssSelect(".detial_top").FirstOrDefault();

                    if (main_box == null)
                    {

                        //Console.WriteLine(PageResult.Html.InnerText);

                        Console.WriteLine(String.Format("No.{0} Brand: {1}, Model: {2}, CarYear: {3}, Submodel: {4}, Message :{5} "
                         , i.ToString()
                         , item_Search.CarBrandCode
                         , item_Search.CarModelCode
                         , item_Search.CarYear
                         , item_Search.CarSubModelName
                         , PageResult.Html.InnerText));

                        continue;
                    }

                    var docx = new HtmlAgilityPack.HtmlDocument();
                    docx.OptionOutputOriginalCase = true;
                    docx.LoadHtml(main_box.OuterHtml);
                    var doc = docx.DocumentNode;


                    _MotorCoverage.Premium = doc.SelectNodes("/div[1]/p[1]/span[1]/b[1]")[0].InnerText;
                    _MotorCoverage.txtSuminSured = doc.SelectNodes("/div[1]/h2[2]")[0].InnerText;
                    _MotorCoverage.InsurerImage = doc.SelectNodes("/div[1]/img[1]")[0].Attributes["src"].Value;
                    _MotorCoverage.InsurerName = doc.SelectNodes("/div[1]/img[1]")[0].Attributes["alt"].Value;


                    var col_product_detail = PageResult.Html.CssSelect(".col_product_detail").ToList();

                    //รายละเอียด
                    var docx1 = new HtmlAgilityPack.HtmlDocument();
                    docx1.OptionOutputOriginalCase = true;
                    docx1.LoadHtml(col_product_detail[0].OuterHtml);
                    var doc1 = docx1.DocumentNode;
                    _MotorCoverage.txtInsurerGarage = doc1.SelectNodes("/div[1]/div[1]/div[1]/p[1]")[0].InnerText.Replace("\t", "").Replace("\r", "").Replace("\n", "");
                    _MotorCoverage.txtGarageNo = doc1.SelectNodes("/div[1]/div[1]/div[2]/p[1]")[0].InnerText.Replace("\t", "").Replace("\r", "").Replace("\n", "");
                    _MotorCoverage.txtSuminSured = doc1.SelectNodes("/div[1]/div[1]/div[3]/p[1]")[0].InnerText.Replace("\t", "").Replace("\r", "").Replace("\n", "");
                    _MotorCoverage.txtCheckCar = doc1.SelectNodes("/div[1]/div[1]/div[4]/img[1]")[0].Attributes["src"].Value;



                    //ความคุ้มครองรถยนต์
                    var docx2 = new HtmlAgilityPack.HtmlDocument();
                    docx2.OptionOutputOriginalCase = true;
                    docx2.LoadHtml(col_product_detail[1].OuterHtml);
                    var doc2 = docx2.DocumentNode;
                    _MotorCoverage.txtCoverPirate = doc2.SelectNodes("/div[1]/div[1]/div[1]/img[1]")[0].Attributes["src"].Value;
                    _MotorCoverage.txtCoverFlood = doc2.SelectNodes("/div[1]/div[1]/div[2]/img[1]")[0].Attributes["src"].Value;
                    if (doc2.SelectNodes("/div[1]/div[1]/div[3]/p[1]") != null)
                    {
                        _MotorCoverage.txtDeduct = doc2.SelectNodes("/div[1]/div[1]/div[3]/p[1]")[0].InnerText.Replace("\t", "").Replace("\r", "").Replace("\n", "");
                    }

                    //คุ้มครองบุคคลภายนอก
                    var docx3 = new HtmlAgilityPack.HtmlDocument();
                    docx3.OptionOutputOriginalCase = true;
                    docx3.LoadHtml(col_product_detail[2].OuterHtml);
                    var doc3 = docx3.DocumentNode;
                    _MotorCoverage.txtCoverTP1 = doc3.SelectNodes("/div[1]/div[1]/div[1]/p[1]")[0].InnerText.Replace("\t", "").Replace("\r", "").Replace("\n", "");
                    _MotorCoverage.txtCoverTP2 = doc3.SelectNodes("/div[1]/div[1]/div[2]/p[1]")[0].InnerText.Replace("\t", "").Replace("\r", "").Replace("\n", "");
                    _MotorCoverage.txtCoverTP3 = doc3.SelectNodes("/div[1]/div[1]/div[3]/p[1]")[0].InnerText.Replace("\t", "").Replace("\r", "").Replace("\n", "");

                    //คุ้มครองตัวรถ
                    var docx4 = new HtmlAgilityPack.HtmlDocument();
                    docx4.OptionOutputOriginalCase = true;
                    docx4.LoadHtml(col_product_detail[3].OuterHtml);
                    var doc4 = docx4.DocumentNode;
                    _MotorCoverage.txtCoverBody = doc4.SelectNodes("/div[1]/div[1]/div[1]/p[1]")[0].InnerText.Replace("\t", "").Replace("\r", "").Replace("\n", "");
                    _MotorCoverage.txtCoverFire = doc4.SelectNodes("/div[1]/div[1]/div[2]/p[1]")[0].InnerText.Replace("\t", "").Replace("\r", "").Replace("\n", "");


                    //คุ้มครองคนในรถ
                    var docx5 = new HtmlAgilityPack.HtmlDocument();
                    docx5.OptionOutputOriginalCase = true;
                    docx5.LoadHtml(col_product_detail[4].OuterHtml);
                    var doc5 = docx5.DocumentNode;
                    _MotorCoverage.txtCoverPA = doc5.SelectNodes("/div[1]/div[1]/div[1]/p[1]")[0].InnerText.Replace("\t", "").Replace("\r", "").Replace("\n", "");
                    _MotorCoverage.txtCoverMedical = doc5.SelectNodes("/div[1]/div[1]/div[2]/p[1]")[0].InnerText.Replace("\t", "").Replace("\r", "").Replace("\n", "");
                    _MotorCoverage.txtCoverBB = doc5.SelectNodes("/div[1]/div[1]/div[3]/p[1]")[0].InnerText.Replace("\t", "").Replace("\r", "").Replace("\n", "");



                    Console.WriteLine(String.Format("No.{0} Brand: {1}, Model: {2}, CarYear: {3}, Submodel: {4}, SuminSured:{5}, Premium:{6} "
                           , i.ToString()
                           , item_Search.CarBrandCode
                           , item_Search.CarModelCode
                           , item_Search.CarYear
                           , item_Search.CarSubModelName
                           , _MotorCoverage.txtSuminSured
                           , _MotorCoverage.Premium));

                    dc.tblMotorCoverages.InsertOnSubmit(_MotorCoverage);
                    dc.SubmitChanges();



                }

            }


        }

        static void GetGarage()
        {

            WebPage PageResult;

            ScrapingBrowser Browser = new ScrapingBrowser();
            Browser.AllowAutoRedirect = true; // Browser has many settings you can access in setup
            Browser.AllowMetaRedirect = true;
            //Browser.Encoding = Encoding.UTF8;

            //var proxyserver = new WebProxy("202.29.221.102", 80);
            //proxyserver.Credentials = CredentialCache.DefaultNetworkCredentials;

            //Uri proxyserver = new Uri("118.173.234.132:8080");


            //WebProxy proxyObject = new WebProxy("203.156.126.55", 3129);
            //WebProxy proxyObject = new WebProxy("118.173.234.132", 8080);
            //WebProxy proxyObject = new WebProxy("203.146.189.61", 80);
            //WebProxy proxyObject = new WebProxy("203.185.96.138", 80);




            using (var dc = new TQMDataContext())
            {

                for (int i = 0; i <= (int)(5773 / 5); i++)
                {

                    StringBuilder sb = new StringBuilder();

                    sb.Append("PRODUCTTYPE=MT");
                    sb.AppendFormat("&garage_start_list={0}", (i * 5).ToString());
                    sb.Append("&garage_total=5773");



                    Browser = new ScrapingBrowser();
                    Browser.Encoding = Encoding.UTF8;
                    //Browser.Proxy = proxyserver;

                    //class="main_box"
                    //class="col_product_detail"

                    PageResult = Browser.NavigateToPage(new Uri("http://www.tqm.co.th/garage_search_sub3.php")
                        , HttpVerb.Post
                        , sb.ToString());


                    var docx = new HtmlAgilityPack.HtmlDocument();
                    docx.OptionOutputOriginalCase = true;
                    docx.LoadHtml(PageResult.Html.OuterHtml);
                    var doc = docx.DocumentNode;

                    //var a = doc.SelectNodes("/div[1]/p[1]/span[1]/b[1]")[0].InnerText;

                    //"content-box-rate padding-20 margin-tb-10"

                    var contents = PageResult.Html.CssSelect(".content-box-rate").ToList();

                    foreach (var item in contents)
                    {
                        var docx2 = new HtmlAgilityPack.HtmlDocument();
                        docx2.OptionOutputOriginalCase = true;
                        docx2.LoadHtml(item.InnerHtml);
                        var doc2 = docx2.DocumentNode;

                        tblGarage _garage = new tblGarage();

                        _garage.GarageName = doc2.SelectNodes("/h2[1]")[0].InnerText.Replace("\t", "").Replace("\r", "").Replace("\n", "");
                        _garage.GarageType = doc2.SelectNodes("/h4[1]/span[1]")[0].InnerText.Replace("\t", "").Replace("\r", "").Replace("\n", "");
                        _garage.Address = doc2.SelectNodes("/p[1]/span[2]")[0].InnerText.Replace("\t", "").Replace("\r", "").Replace("\n", "");
                        _garage.Tel = doc2.SelectNodes("/p[1]/span[4]")[0].InnerText.Replace("\t", "").Replace("\r", "").Replace("\n", "");

                        if (doc2.SelectNodes("/div[2]/a[1]") != null) _garage.Url = doc2.SelectNodes("/div[2]/a[1]")[0].Attributes["href"].Value;


                        dc.tblGarages.InsertOnSubmit(_garage);
                        dc.SubmitChanges();



                        Console.WriteLine(String.Format("Url : {0}", _garage.Url));
                    }


                }

            }




        }

        static void GetGarageGPS()
        {

            WebPage PageResult;

            ScrapingBrowser Browser = new ScrapingBrowser();
            Browser.AllowAutoRedirect = true; // Browser has many settings you can access in setup
            Browser.AllowMetaRedirect = true;



            using (var dc = new TQMDataContext())
            {

                var _garages = (from c in dc.tblGarages where c.gps == null select c).ToList();

                foreach (var item in _garages)
                {
                    PageResult = Browser.NavigateToPage(new Uri("http://www.tqm.co.th" + item.Url), HttpVerb.Post);

                    var _fax = PageResult.Html.CssSelect(".col-sm-8").ToList();
                    if (_fax.Count > 0)
                    {
                        item.Fax = _fax[3].InnerHtml.ToString().Replace("\t", "").Replace("\r", "").Replace("\n", "");
                    }

                    var _gps = PageResult.Html.OwnerDocument.GetElementbyId("coordinates");
                    if (_gps != null)
                    {
                        item.gps = _gps.Attributes["value"].Value;
                    }


                    var _insurer = PageResult.Html.CssSelect(".box-list-thumbnail").ToList();
                    if (_insurer.Count > 0)
                    {
                        var docx = new HtmlAgilityPack.HtmlDocument();
                        docx.OptionOutputOriginalCase = true;
                        docx.LoadHtml(_insurer[0].InnerHtml);
                        var doc = docx.DocumentNode;
                        var insurer = doc.SelectNodes("/ul[1]/li").ToList();

                        StringBuilder sb = new StringBuilder();
                        foreach (var item_insurer in insurer)
                        {
                            if (String.IsNullOrEmpty(sb.ToString()))
                            {
                                sb.Append(item_insurer.InnerText.Trim());
                            }
                            else
                            {
                                sb.Append(";" + item_insurer.InnerText.Trim());
                            }
                        }

                        item.insurer = sb.ToString();
                    }


                    dc.SubmitChanges();


                    Console.WriteLine(String.Format("Url : {0}", item.Url));
                    
                }



            }




        }



        //static WebBrowser webBrowser = new WebBrowser();
        static void Main(string[] args)
        {


            //GetModel();

            //GetSubModel();

            //GetCC();

            //GetSubModelCC();

            //GetSubModelSuminsured();

            GetSearch();

            //GetCoverage();

            //GetGarage();


            //GetGarageGPS();


            //WebPage PageResult;


            //IWebDriver browser = new SimpleBrowserDriver();

            //browser.Navigate().GoToUrl("http://www.funda.nl/koop");

            //ScrapingBrowser Browser = new ScrapingBrowser();
            //var browser = new Browser();
            //browser.Navigate("http://localhost:60840/rfid.aspx");
            //PageResult = Browser.NavigateToPage(new Uri("http://localhost:60840/rfid.aspx"), HttpVerb.Post);
 
            //try
            //{
            //    // log the browser request/response data to files so we can interrogate them in case of an issue with our scraping
            //    browser.RequestLogged += OnBrowserRequestLogged;
            //    browser.MessageLogged += new Action<Browser, string>(OnBrowserMessageLogged);

            //    // we'll fake the user agent for websites that alter their content for unrecognised browsers
            //    browser.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.1; en-US) AppleWebKit/534.10 (KHTML, like Gecko) Chrome/8.0.552.224 Safari/534.10";

            //    // browse to GitHub
            //    browser.Navigate("http://github.com/");
            //    if (LastRequestFailed(browser)) return; // always check the last request in case the page failed to load

            //    // click the login link and click it
            //    browser.Log("First we need to log in, so browse to the login page, fill in the login details and submit the form.");
            //    var loginLink = browser.Find("a", FindBy.Text, "Login");
            //    if (!loginLink.Exists)
            //        browser.Log("Can't find the login link! Perhaps the site is down for maintenance?");
            //    else
            //    {
            //        loginLink.Click();
            //        if (LastRequestFailed(browser)) return;

            //        // fill in the form and click the login button - the fields are easy to locate because they have ID attributes
            //        browser.Find("login_field").Value = "youremail@domain.com";
            //        browser.Find("password").Value = "yourpassword";
            //        browser.Find(ElementType.Button, "name", "commit").Click();
            //        if (LastRequestFailed(browser)) return;

            //        // see if the login succeeded - ContainsText() is very forgiving, so don't worry about whitespace, casing, html tags separating the text, etc.
            //        if (browser.ContainsText("Incorrect login or password"))
            //        {
            //            browser.Log("Login failed!", LogMessageType.Error);
            //        }
            //        else
            //        {
            //            // After logging in, we should check that the page contains elements that we recognise
            //            if (!browser.ContainsText("Your Repositories"))
            //                browser.Log("There wasn't the usual login failure message, but the text we normally expect isn't present on the page");
            //            else
            //            {
            //                browser.Log("Your News Feed:");
            //                // we can use simple jquery selectors, though advanced selectors are yet to be implemented
            //                foreach (var item in browser.Select("div.news .title"))
            //                    browser.Log("* " + item.Value);
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    browser.Log(ex.Message, LogMessageType.Error);
            //    browser.Log(ex.StackTrace, LogMessageType.StackTrace);
            //}
            //finally
            //{
            //    var path = WriteFile("log-" + DateTime.UtcNow.Ticks + ".html", browser.RenderHtmlLogFile("SimpleBrowser Sample - Request Log"));
            //    Process.Start(path);
            //}
        }

        static bool LastRequestFailed(Browser browser)
        {
            if (browser.LastWebException != null)
            {
                browser.Log("There was an error loading the page: " + browser.LastWebException.Message);
                return true;
            }
            return false;
        }

        //static void OnBrowserMessageLogged(Browser browser, string log)
        //{
        //    Console.WriteLine(log);
        //}

        //static void OnBrowserRequestLogged(Browser req, HttpRequestLog log)
        //{
        //    Console.WriteLine(" -> " + log.Method + " request to " + log.Url);
        //    Console.WriteLine(" <- Response status code: " + log.ResponseCode);
        //}

        //static string WriteFile(string filename, string text)
        //{
        //    var dir = new DirectoryInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs"));
        //    if (!dir.Exists) dir.Create();
        //    var path = Path.Combine(dir.FullName, filename);
        //    File.WriteAllText(path, text);
        //    return path;
        //}


    }
}
