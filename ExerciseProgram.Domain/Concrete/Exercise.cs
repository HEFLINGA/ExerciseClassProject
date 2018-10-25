using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseProgram.Domain.Concrete
{
    public class Exercise
    {
        public int ExerciseID { get; set; }
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Display(Name = "5 Rep Max")]
        public int ExerciseMax { get; set; }

        public virtual Category Category { get; set; }

    }
}
