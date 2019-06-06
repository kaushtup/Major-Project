using BikeInsurance.Models;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BikeInsurance.Controllers
{
    public class ReportingController : Controller
    {

        BikeInsuranceEntities17 _db = new BikeInsuranceEntities17();
        public string name = "";
        


        // GET: Reporting
        //
        // 1. Action method for displaying the 'User Profile' page
        //

        ///DataVisualReport/VisualizeReport
        //DAta visual/data visual
        //data visual/visualize
        //reporting/visualize report.

        public ActionResult VisualizeReport()
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
        public ActionResult VisualizeReport(DataVisualize model)
        {
            // Set States on the model. We need to do this because only the value selected 
            // in the DropDownList is posted back, not the whole list of states
            model.States = GetStatesFromDB();

            // In case everything is fine - i.e. "FirstName", "LastName" and "State" are entered/selected,
            // redirect a user to the "ViewProfile" page, and pass the user object along via Session
            if (ModelState.IsValid)
            {
                Session["DataVisualize"] = model;
                return RedirectToAction("DataVisualReport");
            }

            // Something is not right - re-render the registration page, keeping user-entered data
            // and display validation errors
            return View(model);
        }

        //
        // 3. Action method for displaying 'ViewProfile' page
        //
        public ActionResult DataVisualReport()
        {

            // Get user profile information from the session
            var model = Session["DataVisualize"] as DataVisualize;

            if (model.State == "Z")
            {
                         
                name = "ZOne.pdf";
            }
            else if (model.State == "LN")
            {
               
                name = "Lot.pdf";
            }
            else if (model.State == "YM")
            {
             
                name = "year.pdf";
            }
            else if (model.State == "TC")
            {
             
                name = "type cover.pdf";
            }
            else if (model.State == "CN")
            {
                
                name = "company name.pdf";
            }
            else if (model.State == "CCHP")
            {
               
                name = "CCHP.pdf";
            }
            else
            {
                return RedirectToAction("VisualizeReport");
            }
            //if (model == null)
            //    return RedirectToAction("Visualize");

            //Get a human - readable description of a currently selected State
            var allStates = GetStatesFromDB();
            model.StateName = allStates[model.State];

            //Display View Profile page that shows FirstName, Last Name and a selected State.
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

        public ActionResult exportReport()
        {
            ReportDocument rd = new ReportDocument();

            var model = Session["DataVisualize"] as DataVisualize;

            if (model.State == "Z")
            {

                
                rd.Load(Path.Combine(Server.MapPath("~/ReportingFolder"), "CrystalReportZone.rpt"));
                rd.SetDataSource(_db.tblZones.ToList());
            }
            else if (model.State == "LN")
            {
                rd.Load(Path.Combine(Server.MapPath("~/ReportingFolder"), "CrystalReportLoteNo.rpt"));
                rd.SetDataSource(_db.tblLoteNoes.ToList());
            }
            else if (model.State == "YM")
            {
                rd.Load(Path.Combine(Server.MapPath("~/ReportingFolder"), "CrystalReportYM.rpt"));
                rd.SetDataSource(_db.tblYMs.ToList());
                
            }
            else if (model.State == "TC")
            {
                rd.Load(Path.Combine(Server.MapPath("~/ReportingFolder"), "CrystalReportTypeCover.rpt"));
                rd.SetDataSource(_db.tblTypeCovers.ToList());
            }
            else if (model.State == "CN")
            {
                rd.Load(Path.Combine(Server.MapPath("~/ReportingFolder"), "CrystalReportCompanyName.rpt"));
                rd.SetDataSource(_db.tblCompanyNames.ToList());
            }
            else if (model.State == "CCHP")
            {
                rd.Load(Path.Combine(Server.MapPath("~/ReportingFolder"), "CrystalReportCCHP.rpt"));
                rd.SetDataSource(_db.tblCCHPs.ToList());
            }
          
            //rd.Load(Path.Combine(Server.MapPath("~/ReportingFolder"), name));
            //rd.SetDataSource(datasource);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            try
            {
                Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0, SeekOrigin.Begin);
                return File(stream, "application/pdf", name);
            }
            catch
            {
                throw;
            }


        }
    }
}