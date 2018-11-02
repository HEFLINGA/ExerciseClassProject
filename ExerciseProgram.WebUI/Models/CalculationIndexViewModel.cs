using ExerciseProgram.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExerciseProgram.WebUI.Models
{
    public class CalculationIndexViewModel
    {
        public Calculation Calculation { get; set; }
        // TODO: Testing placing plate in calculation view model
        public Plate Plate { get; set; }
        public string ReturnUrl { get; set; }
    }
}