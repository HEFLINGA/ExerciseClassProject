using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseProgram.Domain.Entities
{
    public class Exercise
    {
        [Key]
        public int ExerciseID { get; set; }
        public int CatID { get; set; }
        public int CustID { get; set; }
        public int ExerciseMax { get; set; }
        public string ExerciseName { get; set; }
        public string ExerciseDesc { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Category Category { get; set; }
    }
}
