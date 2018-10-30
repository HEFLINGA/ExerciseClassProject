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
        [Display(Name = "Exercise")]
        public int ExerciseID { get; set; }

        [Display(Name ="Category")]
        public int CategoryID { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        [Display(Name = "Max")]
        public int ExerciseMax { get; set; }

        public virtual Category Category { get; set; }
    }
}
