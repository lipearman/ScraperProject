using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Lib;
using ConsoleGoBear.DataEntity;


namespace Lib
{
    /// <summary>
    /// Handy string methods
    /// </summary>
    public static class Strings
    {
        /// <summary>
        /// Extension method to write the string Str to a file
        /// </summary>
        /// <param name="Str"></param>
        /// <param name="Filename"></param>
        public static void WriteToFile(this string Str, string Filename)
        {
            File.WriteAllText(Filename, Str, System.Text.Encoding.UTF8);
            return;
        }

        // of course you could add other useful string methods...
    }//end class
}//end ns

namespace ConsoleGoBear
{

    public class InsurerType
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string UrlTitle { get; set; }
        public string Logo { get; set; }
        public string SmallLogo { get; set; }
        public string InsureType { get; set; }
        public string HasQuote { get; set; }
        public string ReviewRating { get; set; }
        public string ReviewCount { get; set; }
    }
    public class Makes
    {
        public string ID { get; set; }
        public string Name { get; set; }
    }
    public class Models
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Capacity { get; set; }
    }
    public class Insurances
    {
        public string InsurerID { get; set; }
        public string InsurerName { get; set; }
        public string InsurerLogo { get; set; }
        public string InsurerSmallLogo { get; set; }
        public string PlanID { get; set; }
        public string PlanName { get; set; }
        public string SupplierID { get; set; }
        public string Premium { get; set; }
        public string OriginalPremium { get; set; }
        public string DiscountValue { get; set; }
        public string DiscountUnit { get; set; }
        public string DiscountUntill { get; set; }
        public string TotalScore { get; set; }
        public string Score { get; set; }
        public string PlanCategory { get; set; }
        public string HasQuotes { get; set; }
        public string PromotionID { get; set; }
        public string PromotionTitle { get; set; }
        public string UrlTitle { get; set; }
        public string Class { get; set; }
        public IList<Coverages> Coverages { get; set; }
        public IList<CheckoutOptions> CheckoutOptions { get; set; }
    }
    public class Coverages
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Value { get; set; }
    }
    public class CheckoutOptions
    {
        public string SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string IsBroker { get; set; }
        public string Link { get; set; }
        public string Premium { get; set; }
        public string SKUCode { get; set; }
        public IList<string> CheckoutNotes { get; set; }
    }


    //===============Premium =========== 
    public class InsuranceDetail
    {

        public Insurer Insurer { get; set; }
        public Insurance Insurance { get; set; }
        public Plan Plan { get; set; }
        public Promotion Promotion { get; set; }
        public List<CoverageGroups> CoverageGroups { get; set; }
        public List<Top5CoverageItems> Top5CoverageItems { get; set; }
        public List<CheckoutOptions> CheckoutOptions { get; set; }
    }

    public class Insurer
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string SmallLogo { get; set; }
        public string IntroDescription { get; set; }
        public string Review { get; set; }
        public string Rating { get; set; }
        public string HasQuote { get; set; }
    }
    public class Insurance
    {
        public string Premium { get; set; }
        public string OriginalPremium { get; set; }
        public string DiscountValue { get; set; }
        public string DiscountUnit { get; set; }
        public string DiscountUntil { get; set; }
        public string Class { get; set; }
    }
    public class Plan
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string PlanCategory { get; set; }
        public string Description { get; set; }
        public string Score { get; set; }
        public string TotalScore { get; set; }
        public string Class { get; set; }
    }
    public class Promotion
    {
        public string Title { get; set; }
        public string From { get; set; }
        public string Until { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
    }
    public class CoverageGroups
    {
        public string Name { get; set; }
        public List<CoverageItems> CoverageItems { get; set; }
    }
    public class CoverageItems
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public string Score { get; set; }
        public string TotalScore { get; set; }
        public string Value { get; set; }
    }
    public class Top5CoverageItems
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public string Score { get; set; }
        public string TotalScore { get; set; }
        public string Value { get; set; }
    }

    //===================================
    public class Models2
    {
        public string ModelName { get; set; }
        public string Capacity { get; set; }
        public string ModelGuid { get; set; }
        public string RegisterYear { get; set; }
    }
    public class Insurance2
    {
        public string PlanGuid { get; set; }
        public string ModelName { get; set; }
        public string Capacity { get; set; }
        public string ModelGuid { get; set; }
        public string RegisterYear { get; set; }
    }

    public class Program
    {

        static int delay = 0;
        //=========================== GoBear ==========================
        static void get_insurerType()
        {
            //======================== insurerType ============================
            string _Path = @"C:\WorkSpace\libs\JSON\json-71556\trunk\Src\ConsoleGoBear\JSONdata\Insurers.txt";

            var _data = GetResponseText(@"https://th-api.gobear.com/api/Insurers?insurerType=car");
            _data.WriteToFile(_Path);

        }
        static void get_makes()
        {
            //======================== Makes ============================
            string _Path = @"C:\WorkSpace\libs\JSON\json-71556\trunk\Src\ConsoleGoBear\JSONdata\Makes.txt";

            var _data = GetResponseText(@"https://th-api.gobear.com/api/cars/makes");
            _data.WriteToFile(_Path);

        }
        static void get_models()
        {
            IList<Makes> Makes = read_makes();





            // serialize JSON results into .NET objects
            //IList<Models> Results = new List<Models>();

            foreach (var Make in Makes)
            {


                //======================== Model ============================
                string _Path = String.Format(@"C:\WorkSpace\libs\JSON\json-71556\trunk\Src\ConsoleGoBear\JSONdata\Model\{0}.txt", Make.Name);

                var _data = GetResponseText(String.Format(@"https://th-api.gobear.com/api/cars/makes/{0}/models", Make.ID));
                _data.WriteToFile(_Path);


                Console.WriteLine(String.Format("Make: {0}", Make.Name));
                System.Threading.Thread.Sleep(delay);


            }



            //return Results;

        }
        static void get_insurances(string ModelName, string Capacity, string ModelGuid, string RegisterYear)
        {

            // serialize JSON results into .NET objects
            IList<Insurances> Results = new List<Insurances>();

            //======================== Model ============================
            string _Path = String.Format(@"C:\WorkSpace\libs\JSON\json-71556\trunk\Src\ConsoleGoBear\JSONdata\Premium\{0}-{1}.txt", ModelGuid, RegisterYear);
            if (!File.Exists(_Path))
            {
                var _uri = String.Format(@"https://th-api.gobear.com/api/insurance/car?CoverageFiltrations=&ModelGuid={0}&PolicyTypes=OneYear&PolicyTypes=TwoPlusYears&PolicyTypes=ThreePlusYears&PolicyTypes=ThreeYears&RegisterYear={1}", ModelGuid, RegisterYear);

                //DownloadFile(_uri, _Path);

                //var _data = GetResponseText(_uri);
                //_data.WriteToFile(_Path);

                int read = DownloadFile2(_uri, _Path);

                Console.WriteLine(String.Format("Model: {0}, Capacity: {1} , Year: {2}, {3} bytes written", ModelName, Capacity, RegisterYear, read));
                System.Threading.Thread.Sleep(delay);



            }


        }
        static void get_insurances_details(string PlanGuid, string ModelName, string Capacity, string ModelGuid, string RegisterYear)
        {

            // serialize JSON results into .NET objects
            IList<Insurances> Results = new List<Insurances>();

            //======================== Model ============================
            string _Path = String.Format(@"C:\WorkSpace\libs\JSON\json-71556\trunk\Src\ConsoleGoBear\JSONdata\PremiumDetails\{0}-{1}-{2}.txt", PlanGuid, ModelGuid, RegisterYear);
            if (!File.Exists(_Path))
            {
                var _uri = String.Format(@"https://th-api.gobear.com/api/policies/car/{0}?fromLanding=true&model={1}&modelGuid={2}&registerYear={3}", PlanGuid, ModelGuid, ModelGuid, RegisterYear);

                int read = DownloadFile2(_uri, _Path);

                Console.WriteLine(String.Format("Model: {0}, Capacity: {1} , Year: {2}, {3} bytes written", ModelName, Capacity, RegisterYear, read));
                System.Threading.Thread.Sleep(delay);

            }

        }

        //=============================================================
        static IList<InsurerType> read_insurerType()
        {
            //======================== insurerType ============================
            string _Path = @"C:\WorkSpace\libs\JSON\json-71556\trunk\Src\ConsoleGoBear\JSONdata\Insurers.txt";

            var _data = File.ReadAllText(_Path);

            JObject _Object = JObject.Parse(_data);
            // get JSON result objects into a list
            IList<JToken> results = _Object["Insurers"].Children().ToList();

            // serialize JSON results into .NET objects
            IList<InsurerType> Results = new List<InsurerType>();
            foreach (JToken item in results)
            {
                InsurerType _json = JsonConvert.DeserializeObject<InsurerType>(item.ToString());
                if (_json.ID != "00000000-0000-0000-0000-000000000000")
                {
                    Results.Add(_json);
                    Console.WriteLine(String.Format("ID: {0} , Name: {1} ", _json.ID, _json.Name));

                    System.Threading.Thread.Sleep(delay);
                }
            }

            return Results;
        }
        static IList<Makes> read_makes()
        {
            //======================== Makes ============================
            string _Path = @"C:\WorkSpace\libs\JSON\json-71556\trunk\Src\ConsoleGoBear\JSONdata\Makes.txt";
            var _data = File.ReadAllText(_Path, System.Text.Encoding.UTF8);

            JObject _Object = JObject.Parse(_data);
            // get JSON result objects into a list
            IList<JToken> results = _Object["Makes"].Children().ToList();

            // serialize JSON results into .NET objects
            IList<Makes> Results = new List<Makes>();
            foreach (JToken item in results)
            {
                Makes _json = JsonConvert.DeserializeObject<Makes>(item.ToString());
                if (_json.ID != "00000000-0000-0000-0000-000000000000")
                {
                    Results.Add(_json);
                    Console.WriteLine(String.Format("ID: {0} , Name: {1} ", _json.ID, _json.Name));
                    System.Threading.Thread.Sleep(delay);
                }
            }


            return Results;
        }
        static IList<Models> read_models()
        {

            // serialize JSON results into .NET objects
            IList<Models> Results = new List<Models>();

            var Makes = read_makes();
            foreach (var Make in Makes)
            {
                //======================== Model ============================
                string _Path = String.Format(@"C:\WorkSpace\libs\JSON\json-71556\trunk\Src\ConsoleGoBear\JSONdata\Model\{0}.txt", Make.Name);

                if (File.Exists(_Path))
                {
                    var _data = File.ReadAllText(_Path, System.Text.Encoding.UTF8);

                    JObject _Object = JObject.Parse(_data);
                    // get JSON result objects into a list
                    IList<JToken> results = _Object["Models"].Children().ToList();

                    foreach (JToken item in results)
                    {
                        Models _json = JsonConvert.DeserializeObject<Models>(item.ToString());

                        if (_json.ID != "00000000-0000-0000-0000-000000000000")
                        {
                            Results.Add(_json);
                        }
                    }
                }
            }

            return Results;

        }

        static IList<Models> read_models(Makes Make)
        {

            // serialize JSON results into .NET objects
            IList<Models> Results = new List<Models>();

            //======================== Model ============================
            string _Path = String.Format(@"C:\WorkSpace\libs\JSON\json-71556\trunk\Src\ConsoleGoBear\JSONdata\Model\{0}.txt", Make.Name);

            if (File.Exists(_Path))
            {
                var _data = File.ReadAllText(_Path, System.Text.Encoding.UTF8);

                JObject _Object = JObject.Parse(_data);
                // get JSON result objects into a list
                IList<JToken> results = _Object["Models"].Children().ToList();

                foreach (JToken item in results)
                {
                    Models _json = JsonConvert.DeserializeObject<Models>(item.ToString());

                    if (_json.ID != "00000000-0000-0000-0000-000000000000")
                    {
                        Results.Add(_json);
                        Console.WriteLine(String.Format("ID: {0} , Name: {1}, Capacity: {2} ", _json.ID, _json.Name, _json.Capacity));
                        System.Threading.Thread.Sleep(delay);
                    }
                }
            }

            return Results;

        }
        static IList<Models> read_models(string MakeName)
        {

            // serialize JSON results into .NET objects
            IList<Models> Results = new List<Models>();

            //======================== Model ============================
            string _Path = String.Format(@"C:\WorkSpace\libs\JSON\json-71556\trunk\Src\ConsoleGoBear\JSONdata\Model\{0}.txt", MakeName);

            if (File.Exists(_Path))
            {
                var _data = File.ReadAllText(_Path, System.Text.Encoding.UTF8);

                JObject _Object = JObject.Parse(_data);
                // get JSON result objects into a list
                IList<JToken> results = _Object["Models"].Children().ToList();

                foreach (JToken item in results)
                {
                    Models _json = JsonConvert.DeserializeObject<Models>(item.ToString());

                    if (_json.ID != "00000000-0000-0000-0000-000000000000")
                    {
                        Results.Add(_json);
                        Console.WriteLine(String.Format("ID: {0} , Name: {1}, Capacity: {2} ", _json.ID, _json.Name, _json.Capacity));
                        //System.Threading.Thread.Sleep(delay);
                    }
                }
            }

            return Results;

        }
        static IList<Insurances> read_insurances(string ModelGuid, string RegisterYear)
        {

            // serialize JSON results into .NET objects
            IList<Insurances> Results = new List<Insurances>();

            //======================== Model ============================
            string _Path = String.Format(@"C:\WorkSpace\libs\JSON\json-71556\trunk\Src\ConsoleGoBear\JSONdata\Premium\{0}-{1}.txt", ModelGuid, RegisterYear);

            if (File.Exists(_Path))
            {
                var _data = File.ReadAllText(_Path, System.Text.Encoding.UTF8);

                JObject _Object = JObject.Parse(_data);
                // get JSON result objects into a list
                IList<JToken> results = _Object["Insurances"].Children().ToList();

                foreach (JToken item in results)
                {
                    Insurances _json = JsonConvert.DeserializeObject<Insurances>(item.ToString());
                    Results.Add(_json);
                    //Console.WriteLine(String.Format("Class: {0} , UrlTitle: {1}, Premium: {2}, OD: {3}, Disc: {4}, Ori: {5} ", _json.Class, _json.UrlTitle, _json.Premium, _json.Coverages[0].Value, _json.DiscountValue, _json.OriginalPremium));
                    //System.Threading.Thread.Sleep(delay);

                }
            }

            return Results;

        }

        static InsuranceDetail read_insurances(string PlanGuid, string ModelGuid, string RegisterYear)
        {

            // serialize JSON results into .NET objects
            InsuranceDetail Results = new InsuranceDetail();

            //======================== Model ============================
            string _Path = String.Format(@"C:\WorkSpace\libs\JSON\json-71556\trunk\Src\ConsoleGoBear\JSONdata\PremiumDetails\{0}-{1}-{2}.txt", PlanGuid, ModelGuid, RegisterYear);

            if (File.Exists(_Path))
            {
                var _data = File.ReadAllText(_Path, System.Text.Encoding.Default);
                JObject _Object = JObject.Parse(_data);



                // get JSON result objects into a list
                Insurer Insurer_json = JsonConvert.DeserializeObject<Insurer>(_Object["Insurer"].ToString());
                Results.Insurer = Insurer_json;

                Insurance Insurance_json = JsonConvert.DeserializeObject<Insurance>(_Object["Insurance"].ToString());
                Results.Insurance = Insurance_json;

                Plan Plan_json = JsonConvert.DeserializeObject<Plan>(_Object["Plan"].ToString());
                Results.Plan = Plan_json;

                Promotion Promotion_json = JsonConvert.DeserializeObject<Promotion>(_Object["Promotion"].ToString());
                Results.Promotion = Promotion_json;


                IList<JToken> CoverageGroups_results = _Object["CoverageGroups"].Children().ToList();
                List<CoverageGroups> CoverageGroups_Result = new List<CoverageGroups>();
                foreach (JToken item in CoverageGroups_results)
                {
                    CoverageGroups _json = JsonConvert.DeserializeObject<CoverageGroups>(item.ToString());
                    CoverageGroups_Result.Add(_json);
                }
                Results.CoverageGroups = CoverageGroups_Result;

                IList<JToken> Top5CoverageItems_results = _Object["Top5CoverageItems"].Children().ToList();
                List<Top5CoverageItems> Top5CoverageItems_Results = new List<Top5CoverageItems>();
                foreach (JToken item in Top5CoverageItems_results)
                {
                    Top5CoverageItems _json = JsonConvert.DeserializeObject<Top5CoverageItems>(item.ToString());
                    Top5CoverageItems_Results.Add(_json);
                }
                Results.Top5CoverageItems = Top5CoverageItems_Results;

                IList<JToken> CheckoutOptions_results = _Object["CheckoutOptions"].Children().ToList();
                List<CheckoutOptions> CheckoutOptions_Results = new List<CheckoutOptions>();
                foreach (JToken item in CheckoutOptions_results)
                {
                    CheckoutOptions _json = JsonConvert.DeserializeObject<CheckoutOptions>(item.ToString());
                    CheckoutOptions_Results.Add(_json);
                }
                Results.CheckoutOptions = CheckoutOptions_Results;


            }

            return Results;

        }


        //====================================================================
        static void write_insurances(string MakeName)
        {
            StringBuilder sb = new StringBuilder();

            var Models = read_models(MakeName);

            foreach (var model in Models)
            {
                for (int year = 1990; year <= 2016; year++)
                {

                    string _Path = String.Format(@"C:\WorkSpace\libs\JSON\json-71556\trunk\Src\ConsoleGoBear\JSONdata\Premium\{0}-{1}.txt", model.ID, year);
                    if (!File.Exists(_Path))
                    {
                        sb.AppendLine(String.Format(@"https://th-api.gobear.com/api/insurance/car?CoverageFiltrations=&ModelGuid={0}&PolicyTypes=OneYear&PolicyTypes=TwoPlusYears&PolicyTypes=ThreePlusYears&PolicyTypes=ThreeYears&RegisterYear={1}", model.ID, year));
                    }

                }

            }


            sb.ToString().WriteToFile(String.Format(@"C:\WorkSpace\libs\JSON\json-71556\trunk\Src\ConsoleGoBear\JSONdata\Download\{0}.txt", MakeName));

        }

        static void Main(string[] args)
        {

            using (var dc = new GobearDataContextDataContext())
            {

            //    //var Makes = read_makes();

            //    var Makes = dc.Makes.Select(x => x).ToList();
            //    foreach (var make in Makes)
            //    {

            //        //var mk = new Make();
            //        //mk.ID = make.ID;
            //        //mk.Name = make.Name;

            //        //List<Model> md = new List<Model>();

            //        var Models = read_models(make.Name);

            //        //var _dmd = Models.Distinct().ToList();


            //        foreach (var model in Models)
            //        {
            //            make.Models.Add(new Model { ID = model.ID, Name = model.Name, Capacity = model.Capacity, MakeID = make.ID });


            //            //md.Add(new Model { ID = model.ID, Name = model.Name, Capacity = model.Capacity, MakeID = make.ID });
            //        }

            //        ////mk.Models = md;


            //        ////dc.Models.InsertAllOnSubmit(md);


            //        //dc.Makes.InsertOnSubmit(mk);

            //        //dc.SubmitChanges();
            //    }
            //    dc.SubmitChanges();
            //}

                    var Makes = dc.Makes.Select(x => x).ToList();
                    foreach (var make in Makes)
                    {

                        var Premiums = new List<tblMotorSearch>();

                        var Models = read_models(make.Name);


                        foreach (var model in Models)
                        {
                            for (int year = 1990; year <= 2017; year++)
                            {
                                try
                                {
                                    var Insurances = read_insurances(model.ID, year.ToString());




                                    foreach (var plan in Insurances)
                                    {
                                        var Premium = new tblMotorSearch();

                                        //Insurance2.Add(new Insurance2() { PlanGuid = plan.PlanID, Capacity = model.Capacity, ModelGuid = model.ID, ModelName = model.Name, RegisterYear = year.ToString() });


                                        Premium.BrandName = make.Name;
                                        Premium.ModelID = model.ID;
                                        Premium.ModelName = model.Name;
                                        Premium.Capacity = model.Capacity;
                                        Premium.ModelYear = year.ToString();



                                        Premium.InsurerID = plan.InsurerID;
                                        Premium.InsurerName = plan.InsurerName;
                                        Premium.InsurerLogo = plan.InsurerLogo;
                                        Premium.InsurerSmallLogo = plan.InsurerSmallLogo;
                                        Premium.PlanID = plan.PlanID;
                                        Premium.PlanName = plan.PlanName;
                                        Premium.SupplierID = plan.SupplierID;
                                        Premium.Premium = plan.Premium;
                                        Premium.OriginalPremium = plan.OriginalPremium;
                                        Premium.DiscountValue = plan.DiscountValue;
                                        Premium.DiscountUnit = plan.DiscountUnit;
                                        Premium.DiscountUntill = plan.DiscountUntill;
                                        Premium.TotalScore = plan.TotalScore;
                                        Premium.Score = plan.Score;
                                        Premium.PlanCategory = plan.PlanCategory;
                                        Premium.HasQuotes = plan.HasQuotes;
                                        Premium.PromotionID = plan.PromotionID;
                                        Premium.PromotionTitle = plan.PromotionTitle;
                                        Premium.UrlTitle = plan.UrlTitle;
                                        Premium.Class = plan.Class;

                                        if (plan.Coverages.Count > 0)
                                        {
                                            Premium.OD = plan.Coverages[0].Value;
                                            Premium.Flood = plan.Coverages[1].Value;
                                            Premium.ODDD = plan.Coverages[2].Value;
                                            Premium.FIX = plan.Coverages[3].Content;
                                            Premium.TP = plan.Coverages[4].Value;
                                        }

                                        if (plan.CheckoutOptions.Count > 0)
                                        {

                                            Premium.SupplierID = plan.CheckoutOptions[0].SupplierID;
                                            Premium.SupplierName = plan.CheckoutOptions[0].SupplierName;
                                            Premium.IsBroker = plan.CheckoutOptions[0].IsBroker;
                                            Premium.Link = plan.CheckoutOptions[0].Link;
                                            //Premium.Premium = plan.CheckoutOptions[0].Premium;
                                            Premium.SKUCode = plan.CheckoutOptions[0].SKUCode;

                                            if (plan.CheckoutOptions[0].CheckoutNotes.Count > 0)
                                            {
                                                Premium.CheckoutNotes = plan.CheckoutOptions[0].CheckoutNotes[0];
                                            }


                                        }


                                        Premiums.Add(Premium);

                                        Console.WriteLine(String.Format("Model: {0}, Capacity: {1} , Year: {2}, Sumimsured:{3}, Premium:{4}, ", model.Name, model.Capacity, year.ToString(), Premium.OD, Premium.Premium));

                                    }
                                }
                                catch (Exception ex)
                                {

                                    Console.WriteLine(String.Format("Error Model: {0}, Capacity: {1} , Year: {2} {3}", model.Name, model.Capacity, year.ToString(), ex.Message));

                                }
                            }
                        }
                        dc.tblMotorSearches.InsertAllOnSubmit(Premiums);
                        dc.SubmitChanges();



                    }
            }

            //MultiThreadedWebDownloader downloader = null;
            //downloader.DownloadCompleted += DownloadCompleted;




            //write_insurances("HONDA");

            //var Models = read_models();
            ////var Models = read_models("TOYOTA");
            ////var Models = read_models("HONDA");
            ////var Models = read_models("NISSAN");
            ////var Models = read_models("TATA");
            ////var Models = read_models("MAZDA");
            ////var Models = read_models("FORD");
            ////var Models = read_models("ISUZU");
            ////foreach (var model in Models)
            ////{
            ////    for (int year = 1990; year <= 2016; year++)
            ////    {
            ////        get_insurances(model.Name, model.Capacity, model.ID, year.ToString());
            ////    }

            ////}

            //var Models2 = new List<Models2>();
            //foreach (var model in Models)
            //{
            //    for (int year = 1990; year <= 2016; year++)
            //    {
            //        Models2.Add(new Models2() { Capacity = model.Capacity, ModelGuid = model.ID, ModelName = model.Name, RegisterYear = year.ToString() });
            //    }
            //}
            //Parallel.ForEach(
            //   Models2,
            //   new ParallelOptions { MaxDegreeOfParallelism = 5 },
            //   DownloadFile);



            //read_insurances("b22cd85c-4935-499d-bc37-6534053e24c8", "58e19e20-d889-4c71-af90-4ce3278d0eb9", "2012");






            ////string PlanGuid, string ModelGuid, string RegisterYear


            //List<string> _m = new List<string>();           
            //_m.Add("TOYOTA");
            //_m.Add("HONDA");
            //_m.Add("NISSAN");
            //_m.Add("TATA");
            //_m.Add("MAZDA");
            //_m.Add("FORD");
            //_m.Add("ISUZU");
            //_m.Add("MITSUBISHI");
            //_m.Add("KIA");
            //_m.Add("MG");

            //var _data = read_models().ToList();



            //var Models = (from c in _data where !_m.Contains(c.Name) select c).ToList();

            ////var Models = read_models();
            ////var Models = read_models("TOYOTA");
            ////var Models = read_models("HONDA");
            ////var Models = read_models("NISSAN");
            ////var Models = read_models("TATA");
            ////var Models = read_models("MAZDA");
            ////var Models = read_models("FORD");
            ////var Models = read_models("ISUZU");
            ////var Models = read_models("MITSUBISHI");
            ////var Models = read_models("KIA");
            ////var Models = read_models("MG");



            //var Insurance2 = new List<Insurance2>();
            //foreach (var model in Models)
            //{
            //    for (int year = 1990; year <= 2016; year++)
            //    {
            //        try
            //        {
            //            var Insurances = read_insurances(model.ID, year.ToString());

            //            foreach (var plan in Insurances)
            //            {
            //                Insurance2.Add(new Insurance2() { PlanGuid = plan.PlanID, Capacity = model.Capacity, ModelGuid = model.ID, ModelName = model.Name, RegisterYear = year.ToString() });
            //            }
            //        }
            //        catch (Exception ex)
            //        {

            //            Console.WriteLine(String.Format("Error Model: {0}, Capacity: {1} , Year: {2} {3}", model.Name, model.Capacity, year.ToString(), ex.Message));

            //        }


            //    }
            //}
            //Parallel.ForEach(
            //   Insurance2,
            //   new ParallelOptions { MaxDegreeOfParallelism = 5 },
            //   DownloadInsurance);



            //var a = read_insurances("1c09d560-d4a0-4326-bd31-843a109e5e66", "1990");


            //var b = "";


            //get_models();

            //Filter
            //https://th-api.gobear.com/api/policies/filtrationoptions/car

            //insurerType
            //get_insurerType();

            //makes
            //var _makes = get_makes();

            //models
            //Makes _Makes = new Makes();
            //_Makes.ID = "3fdf0e0f-dea8-4434-8536-7d86b340b3f9";
            //_Makes.Name = "TOYOTA";
            //var a = get_models(_makes);

            //var makes = read_makes();
            //foreach (var make in makes)
            //{
            //    read_models(make);
            //}


            //var r = read_insurances("58e19e20-d889-4c71-af90-4ce3278d0eb9", "2015");
            //Console.WriteLine("Total :  " + r.Count.ToString());


            //List<int> _suminsured = new List<int>();
            //_suminsured.Add(100000);
            //_suminsured.Add(200000);
            //_suminsured.Add(300000);
            //_suminsured.Add(500000);
            //_suminsured.Add(700000);
            //_suminsured.Add(900000);
            //_suminsured.Add(1000000);
            //_suminsured.Add(2000000);

            //string _ModelGuid = "";
            //string _RegisterYear = "";

            //Premium
            //https://th-api.gobear.com/api/insurance/car?CoverageFiltrations=&ModelGuid={ModelGuid}&PolicyTypes=OneYear&PolicyTypes=TwoPlusYears&PolicyTypes=ThreePlusYears&PolicyTypes=ThreeYears&RegisterYear={RegisterYear}

            //Premium Details
            //https://th-api.gobear.com/api/policies/car/{planid}?fromLanding=true&model={model}&modelGuid={model}&registerYear={RegisterYear}
            //https://th-api.gobear.com/api/policies/car/b22cd85c-4935-499d-bc37-6534053e24c8?fromLanding=true&model=58e19e20-d889-4c71-af90-4ce3278d0eb9&modelGuid=58e19e20-d889-4c71-af90-4ce3278d0eb9&registerYear=2012

            //https://www.gobear.co.th/insurance/car/-/-/{PremiumCode}?registerYear={registerYear}&make={make}&model={model}&policyTypes={policyTypes}&premium={premium}&supplierID={supplierID}
            //or
            //https://www.gobear.co.th/insurance/car/-/-/b22cd85c-4935-499d-bc37-6534053e24c8?fromLanding=true&registerYear=2012&model=58e19e20-d889-4c71-af90-4ce3278d0eb9


            Console.WriteLine("End");
            Console.ReadLine();
        }


        static string GetResponseText(string address)
        {
            var request = (HttpWebRequest)WebRequest.Create(address);

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                var encoding = Encoding.GetEncoding(response.CharacterSet);

                using (var responseStream = response.GetResponseStream())
                using (var reader = new StreamReader(responseStream, encoding))
                    return reader.ReadToEnd();
            }
        }

        static void DownloadFile(string sSourceURL, string sDestinationPath)
        {
            long iFileSize = 0;
            int iBufferSize = 1024;
            iBufferSize *= 1000;
            long iExistLen = 0;
            System.IO.FileStream saveFileStream;
            if (System.IO.File.Exists(sDestinationPath))
            {
                System.IO.FileInfo fINfo =
                   new System.IO.FileInfo(sDestinationPath);
                iExistLen = fINfo.Length;
            }
            if (iExistLen > 0)
                saveFileStream = new System.IO.FileStream(sDestinationPath,
                  System.IO.FileMode.Append, System.IO.FileAccess.Write,
                  System.IO.FileShare.ReadWrite);
            else
                saveFileStream = new System.IO.FileStream(sDestinationPath,
                  System.IO.FileMode.Create, System.IO.FileAccess.Write,
                  System.IO.FileShare.ReadWrite);

            System.Net.HttpWebRequest hwRq;
            System.Net.HttpWebResponse hwRes;
            hwRq = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(sSourceURL);
            hwRq.AddRange((int)iExistLen);
            System.IO.Stream smRespStream;
            hwRes = (System.Net.HttpWebResponse)hwRq.GetResponse();
            smRespStream = hwRes.GetResponseStream();

            iFileSize = hwRes.ContentLength;

            int iByteSize;
            byte[] downBuffer = new byte[iBufferSize];

            while ((iByteSize = smRespStream.Read(downBuffer, 0, downBuffer.Length)) > 0)
            {
                saveFileStream.Write(downBuffer, 0, iByteSize);
            }
        }

        static int DownloadFile2(String remoteFilename, String localFilename)
        {
            // Function will return the number of bytes processed
            // to the caller. Initialize to 0 here.
            int bytesProcessed = 0;

            // Assign values to these objects here so that they can
            // be referenced in the finally block
            Stream remoteStream = null;
            Stream localStream = null;
            WebResponse response = null;

            // Use a try/catch/finally block as both the WebRequest and Stream
            // classes throw exceptions upon error
            try
            {
                //WebProxy proxyObject = new WebProxy("203.156.126.55", 3129);
                //WebProxy proxyObject = new WebProxy("118.173.234.132", 8080);
                WebProxy proxyObject = new WebProxy("203.146.189.61", 80);
                //WebProxy proxyObject = new WebProxy("203.185.96.138", 80);


                // Disable proxy use when the host is local.
                proxyObject.BypassProxyOnLocal = true;

                // HTTP requests use this proxy information.
                GlobalProxySelection.Select = proxyObject;



                // Create a request for the specified remote file name
                WebRequest request = WebRequest.Create(remoteFilename);
                request.Proxy = proxyObject;

                if (request != null)
                {
                    // Send the request to the server and retrieve the
                    // WebResponse object 
                    response = request.GetResponse();
                    if (response != null)
                    {
                        // Once the WebResponse object has been retrieved,
                        // get the stream object associated with the response's data
                        remoteStream = response.GetResponseStream();

                        // Create the local file
                        localStream = File.Create(localFilename);

                        // Allocate a 1k buffer
                        byte[] buffer = new byte[1024];
                        int bytesRead;

                        // Simple do/while loop to read from stream until
                        // no bytes are returned
                        do
                        {
                            // Read data (up to 1k) from the stream
                            bytesRead = remoteStream.Read(buffer, 0, buffer.Length);

                            // Write the data to the local file
                            localStream.Write(buffer, 0, bytesRead);

                            // Increment total bytes processed
                            bytesProcessed += bytesRead;
                        } while (bytesRead > 0);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                // Close the response and streams objects here 
                // to make sure they're closed even if an exception
                // is thrown at some point
                if (response != null) response.Close();
                if (remoteStream != null) remoteStream.Close();
                if (localStream != null) localStream.Close();
            }

            // Return total bytes processed to caller.
            return bytesProcessed;
        }


        public static void DownloadModels(Models2 model)
        {
            get_insurances(model.ModelName, model.Capacity, model.ModelGuid, model.RegisterYear);
        }
        public static void DownloadInsurance(Insurance2 Insurance)
        {
            //var insurances = read_insurances(Insurance.ModelGuid, Insurance.RegisterYear);
            //if (insurances.Count > 0)
            //{
            get_insurances_details(Insurance.PlanGuid, Insurance.ModelName, Insurance.Capacity, Insurance.ModelGuid, Insurance.RegisterYear);
            //}
        }
    }

}
