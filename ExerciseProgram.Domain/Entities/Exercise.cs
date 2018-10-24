using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseProgram.Domain.Entities
{
    public class Exercise
    {
        [Key]
        public int exerciseID { get; set; }

        [Display(Name = "Exercise Name:")]
        public string exerciseName { get; set; }

        [Display(Name = "Discription:")]
        public string exerciseDesc { get; set; }

        [Display(Name = "5 Rep Max")]
        public int exerciseMax { get; set; }

        public int catID { get; set; }
    }
}
