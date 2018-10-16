using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseProgram.Domain.Entities
{
    public class Exercise
    {
        public int ExerciseID { get; set; }
        public string ExerciseName { get; set; }
        public string ExerciseDescription { get; set; }
        public int ExerciseMax { get; set; }
        public int CategoryID { get; set; }
    }
}
