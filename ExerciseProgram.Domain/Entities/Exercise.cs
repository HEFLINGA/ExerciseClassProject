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

        public string exerciseName { get; set; }
        public string exerciseDesc { get; set; }
        public int exerciseMax { get; set; }
        public int catID { get; set; }
    }
}
