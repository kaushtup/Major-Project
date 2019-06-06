
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BikeInsurance.Models;
using Newtonsoft.Json;

namespace BikeInsurance.Controllers
{
    public class DataVisualController : Controller
    {
        //00
        // 1. Action method for displaying the 'User Profile' page
        //
        public ActionResult Visualize()
        {
            // Get existing user profile object from the session or create a new one
            var model = Session["DataVisualize"] as DataVisualize ?? new DataVisualize();

            // Simulate getting states from a database
            model.States = GetStatesFromDB();

            return View(model);
        }

        //
        // 2. Action method for handling user-entered data when 'Update' button is pressed.
        //
        [HttpPost]
        public ActionResult Visualize(DataVisualize model)
        {
            // Set States on the model. We need to do this because only the value selected 
            // in the DropDownList is posted back, not the whole list of states
            model.States = GetStatesFromDB();

            // In case everything is fine - i.e. "FirstName", "LastName" and "State" are entered/selected,
            // redirect a user to the "ViewProfile" page, and pass the user object along via Session
            if (ModelState.IsValid)
            {
                Session["DataVisualize"] = model;
                return RedirectToAction("DataVisual");
            }

            // Something is not right - re-render the registration page, keeping user-entered data
            // and display validation errors
            return View(model);
        }

        //
        // 3. Action method for displaying 'ViewProfile' page
        //
        public ActionResult DataVisual()
        {
                       
            // Get user profile information from the session
            var model = Session["DataVisualize"] as DataVisualize;

            if (model.State == "Z")
            {
                DataChartZone();
            }
            else if(model.State == "LN")
            {
                DataChartLoteNo();
            }
            else if (model.State == "YM")
            {
                DataChartYM();
            }
            else if (model.State == "TC")
            {
                DataChartTC();
            }
            else if (model.State == "CN")
            {
                DataChartCN();
            }
            else if (model.State == "CCHP")
            {
                DataChartCCHP();
            }
            else
            {
                return RedirectToAction("Visualize");
            }
            //if (model == null)
            //    return RedirectToAction("Visualize");

            // Get a human-readable description of a currently selected State
            var allStates = GetStatesFromDB();
            model.StateName = allStates[model.State];

            // Display View Profile page that shows FirstName, Last Name and a selected State.
            return View(model);
        }

        /// <summary>
        /// Simulates retrieval of country's states from a DB.
        /// </summary>
        /// <returns>Dictionary of US states</returns>
        private Dictionary<string, string> GetStatesFromDB()
        {
            return new Dictionary<string, string>
            {
                {"Z", "Zone"},
                {"LN", "LoteNo"},
                {"YM", "YearManufacture"},
                {"TC", "TypeCover"},
                {"CN", "CompanyName"},
                {"CCHP", "CCHP"},

            };
        }
    
            // GET: DataVisual
            Test blu = new Test();
       
       

        public void DataChartZone()
        {
            DataTable dt = blu.GetZoneData();
            List<DataPoint> dataPoints1 = new List<DataPoint>();
            List<DataPoint> dataPoints2 = new List<DataPoint>();

            dataPoints1.Add(new DataPoint("ME", Convert.ToInt32(dt.Rows[0][1].ToString())));
            dataPoints1.Add(new DataPoint("KO", Convert.ToInt32(dt.Rows[0][3].ToString())));
            dataPoints1.Add(new DataPoint("SA", Convert.ToInt32(dt.Rows[0][5].ToString())));
            dataPoints1.Add(new DataPoint("JA", Convert.ToInt32(dt.Rows[0][7].ToString())));
            dataPoints1.Add(new DataPoint("BA", Convert.ToInt32(dt.Rows[0][9].ToString())));
            dataPoints1.Add(new DataPoint("NA", Convert.ToInt32(dt.Rows[0][11].ToString())));
            dataPoints1.Add(new DataPoint("GA", Convert.ToInt32(dt.Rows[0][13].ToString())));
            dataPoints1.Add(new DataPoint("LU", Convert.ToInt32(dt.Rows[0][15].ToString())));
            dataPoints1.Add(new DataPoint("DH", Convert.ToInt32(dt.Rows[0][17].ToString())));
            dataPoints1.Add(new DataPoint("RA", Convert.ToInt32(dt.Rows[0][19].ToString())));
            dataPoints1.Add(new DataPoint("BHE", Convert.ToInt32(dt.Rows[0][21].ToString())));
            dataPoints1.Add(new DataPoint("KA", Convert.ToInt32(dt.Rows[0][23].ToString())));
            dataPoints1.Add(new DataPoint("SE", Convert.ToInt32(dt.Rows[0][25].ToString())));
            dataPoints1.Add(new DataPoint("MA", Convert.ToInt32(dt.Rows[0][27].ToString())));


            dataPoints2.Add(new DataPoint("ME", Convert.ToInt32(dt.Rows[0][2].ToString())));
            dataPoints2.Add(new DataPoint("KO", Convert.ToInt32(dt.Rows[0][4].ToString())));
            dataPoints2.Add(new DataPoint("SA", Convert.ToInt32(dt.Rows[0][6].ToString())));
            dataPoints2.Add(new DataPoint("JA", Convert.ToInt32(dt.Rows[0][8].ToString())));
            dataPoints2.Add(new DataPoint("BA", Convert.ToInt32(dt.Rows[0][10].ToString())));
            dataPoints2.Add(new DataPoint("NA", Convert.ToInt32(dt.Rows[0][12].ToString())));
            dataPoints2.Add(new DataPoint("GA", Convert.ToInt32(dt.Rows[0][14].ToString())));
            dataPoints2.Add(new DataPoint("LU", Convert.ToInt32(dt.Rows[0][16].ToString())));
            dataPoints2.Add(new DataPoint("DH", Convert.ToInt32(dt.Rows[0][18].ToString())));
            dataPoints2.Add(new DataPoint("RA", Convert.ToInt32(dt.Rows[0][20].ToString())));
            dataPoints2.Add(new DataPoint("BHE", Convert.ToInt32(dt.Rows[0][22].ToString())));
            dataPoints2.Add(new DataPoint("KA", Convert.ToInt32(dt.Rows[0][24].ToString())));
            dataPoints2.Add(new DataPoint("SE", Convert.ToInt32(dt.Rows[0][26].ToString())));
            dataPoints2.Add(new DataPoint("MA", Convert.ToInt32(dt.Rows[0][28].ToString())));
            ViewBag.DataPoints1 = JsonConvert.SerializeObject(dataPoints1);
            ViewBag.DataPoints2 = JsonConvert.SerializeObject(dataPoints2);

        }


        public void DataChartLoteNo()
        {
            DataTable dt = blu.GetLoteNoData();
            List<DataPoint> dataPoints1 = new List<DataPoint>();
            List<DataPoint> dataPoints2 = new List<DataPoint>();

            dataPoints1.Add(new DataPoint("0-10", Convert.ToInt32(dt.Rows[0][1].ToString())));
            dataPoints1.Add(new DataPoint("10-20", Convert.ToInt32(dt.Rows[0][3].ToString())));
            dataPoints1.Add(new DataPoint("20-30", Convert.ToInt32(dt.Rows[0][5].ToString())));
            dataPoints1.Add(new DataPoint("30-40", Convert.ToInt32(dt.Rows[0][7].ToString())));
            dataPoints1.Add(new DataPoint("40-50", Convert.ToInt32(dt.Rows[0][9].ToString())));
            dataPoints1.Add(new DataPoint("50-60", Convert.ToInt32(dt.Rows[0][11].ToString())));
            dataPoints1.Add(new DataPoint("60-70", Convert.ToInt32(dt.Rows[0][13].ToString())));
            dataPoints1.Add(new DataPoint("70-80", Convert.ToInt32(dt.Rows[0][15].ToString())));
            dataPoints1.Add(new DataPoint("80 ABOVE", Convert.ToInt32(dt.Rows[0][17].ToString())));
            


            dataPoints2.Add(new DataPoint("0-10", Convert.ToInt32(dt.Rows[0][2].ToString())));
            dataPoints2.Add(new DataPoint("10-20", Convert.ToInt32(dt.Rows[0][4].ToString())));
            dataPoints2.Add(new DataPoint("20-30", Convert.ToInt32(dt.Rows[0][6].ToString())));
            dataPoints2.Add(new DataPoint("30-40", Convert.ToInt32(dt.Rows[0][8].ToString())));
            dataPoints2.Add(new DataPoint("40-50", Convert.ToInt32(dt.Rows[0][10].ToString())));
            dataPoints2.Add(new DataPoint("50-60", Convert.ToInt32(dt.Rows[0][12].ToString())));
            dataPoints2.Add(new DataPoint("60-70", Convert.ToInt32(dt.Rows[0][14].ToString())));
            dataPoints2.Add(new DataPoint("70-80", Convert.ToInt32(dt.Rows[0][16].ToString())));
            dataPoints2.Add(new DataPoint("80 ABOVE", Convert.ToInt32(dt.Rows[0][18].ToString())));
 
            ViewBag.DataPoints1 = JsonConvert.SerializeObject(dataPoints1);
            ViewBag.DataPoints2 = JsonConvert.SerializeObject(dataPoints2);

        }


        public void DataChartYM()
        {
            DataTable dt = blu.GetYearManufactureData();
            List<DataPoint> dataPoints1 = new List<DataPoint>();
            List<DataPoint> dataPoints2 = new List<DataPoint>();

            dataPoints1.Add(new DataPoint("0-2010", Convert.ToInt32(dt.Rows[0][1].ToString())));
            dataPoints1.Add(new DataPoint("2010-2015", Convert.ToInt32(dt.Rows[0][3].ToString())));
            dataPoints1.Add(new DataPoint("2015 ABOVE", Convert.ToInt32(dt.Rows[0][5].ToString())));
            


            dataPoints2.Add(new DataPoint("0-2010", Convert.ToInt32(dt.Rows[0][2].ToString())));
            dataPoints2.Add(new DataPoint("2010-2015", Convert.ToInt32(dt.Rows[0][4].ToString())));
            dataPoints2.Add(new DataPoint("2015 ABOVE", Convert.ToInt32(dt.Rows[0][6].ToString())));
         
            ViewBag.DataPoints1 = JsonConvert.SerializeObject(dataPoints1);
            ViewBag.DataPoints2 = JsonConvert.SerializeObject(dataPoints2);

        }


        public void DataChartTC()
        {
            DataTable dt = blu.GetTypeCoverData();
            List<DataPoint> dataPoints1 = new List<DataPoint>();
            List<DataPoint> dataPoints2 = new List<DataPoint>();

            dataPoints1.Add(new DataPoint("CM", Convert.ToInt32(dt.Rows[0][1].ToString())));
            dataPoints1.Add(new DataPoint("TP", Convert.ToInt32(dt.Rows[0][3].ToString())));
            

            dataPoints2.Add(new DataPoint("CM", Convert.ToInt32(dt.Rows[0][2].ToString())));
            dataPoints2.Add(new DataPoint("TP", Convert.ToInt32(dt.Rows[0][4].ToString())));
            ViewBag.DataPoints1 = JsonConvert.SerializeObject(dataPoints1);
            ViewBag.DataPoints2 = JsonConvert.SerializeObject(dataPoints2);

        }


        public void DataChartCN()
        {
            DataTable dt = blu.GetCompanyNameData();
            List<DataPoint> dataPoints1 = new List<DataPoint>();
            List<DataPoint> dataPoints2 = new List<DataPoint>();

            dataPoints1.Add(new DataPoint("YAMAHA", Convert.ToInt32(dt.Rows[0][1].ToString())));
            dataPoints1.Add(new DataPoint("ROYALENFIELD", Convert.ToInt32(dt.Rows[0][3].ToString())));
            dataPoints1.Add(new DataPoint("HONDA", Convert.ToInt32(dt.Rows[0][5].ToString())));
            dataPoints1.Add(new DataPoint("HERO", Convert.ToInt32(dt.Rows[0][7].ToString())));
            dataPoints1.Add(new DataPoint("HEROHONDA", Convert.ToInt32(dt.Rows[0][9].ToString())));
            dataPoints1.Add(new DataPoint("BAJAJ", Convert.ToInt32(dt.Rows[0][11].ToString())));
            dataPoints1.Add(new DataPoint("TVS", Convert.ToInt32(dt.Rows[0][13].ToString())));
            dataPoints1.Add(new DataPoint("SUZUKI", Convert.ToInt32(dt.Rows[0][15].ToString())));
            dataPoints1.Add(new DataPoint("MAHINDRA", Convert.ToInt32(dt.Rows[0][17].ToString())));
            dataPoints1.Add(new DataPoint("KTM", Convert.ToInt32(dt.Rows[0][19].ToString())));
            

            dataPoints2.Add(new DataPoint("YAMAHA", Convert.ToInt32(dt.Rows[0][2].ToString())));
            dataPoints2.Add(new DataPoint("ROYALENFIELD", Convert.ToInt32(dt.Rows[0][4].ToString())));
            dataPoints2.Add(new DataPoint("HONDA", Convert.ToInt32(dt.Rows[0][6].ToString())));
            dataPoints2.Add(new DataPoint("HERO", Convert.ToInt32(dt.Rows[0][8].ToString())));
            dataPoints2.Add(new DataPoint("HEROHONDA", Convert.ToInt32(dt.Rows[0][10].ToString())));
            dataPoints2.Add(new DataPoint("BAJAJ", Convert.ToInt32(dt.Rows[0][12].ToString())));
            dataPoints2.Add(new DataPoint("TVS", Convert.ToInt32(dt.Rows[0][14].ToString())));
            dataPoints2.Add(new DataPoint("SUZUKI", Convert.ToInt32(dt.Rows[0][16].ToString())));
            dataPoints2.Add(new DataPoint("MAHINDRA", Convert.ToInt32(dt.Rows[0][18].ToString())));
            dataPoints2.Add(new DataPoint("KTM", Convert.ToInt32(dt.Rows[0][20].ToString())));
          
            ViewBag.DataPoints1 = JsonConvert.SerializeObject(dataPoints1);
            ViewBag.DataPoints2 = JsonConvert.SerializeObject(dataPoints2);

        }



        public void DataChartCCHP()
        {
            DataTable dt = blu.GetCCHPData();
            List<DataPoint> dataPoints1 = new List<DataPoint>();
            List<DataPoint> dataPoints2 = new List<DataPoint>();

            dataPoints1.Add(new DataPoint("0-100", Convert.ToInt32(dt.Rows[0][1].ToString())));
            dataPoints1.Add(new DataPoint("100-125", Convert.ToInt32(dt.Rows[0][3].ToString())));
            dataPoints1.Add(new DataPoint("125-150", Convert.ToInt32(dt.Rows[0][5].ToString())));
            dataPoints1.Add(new DataPoint("150 ABOVE", Convert.ToInt32(dt.Rows[0][7].ToString())));
            

            dataPoints2.Add(new DataPoint("0-100", Convert.ToInt32(dt.Rows[0][2].ToString())));
            dataPoints2.Add(new DataPoint("100-125", Convert.ToInt32(dt.Rows[0][4].ToString())));
            dataPoints2.Add(new DataPoint("125-150", Convert.ToInt32(dt.Rows[0][6].ToString())));
            dataPoints2.Add(new DataPoint("150 ABOVE", Convert.ToInt32(dt.Rows[0][8].ToString())));
           
            ViewBag.DataPoints1 = JsonConvert.SerializeObject(dataPoints1);
            ViewBag.DataPoints2 = JsonConvert.SerializeObject(dataPoints2);

        }




    }
}