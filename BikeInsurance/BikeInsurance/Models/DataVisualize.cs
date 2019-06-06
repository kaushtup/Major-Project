using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BikeInsurance.Models
{
    public class DataVisualize
    {
        // This property holds user-selected state
        [Required]
        [Display(Name = "Select Attribute")]
        public string State { get; set; }

        // This property holds all available states for selection
        public Dictionary<string, string> States { get; set; }

        // Property to store human-readable state name
        public string StateName { get; set; }
    }
}