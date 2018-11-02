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

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage ="Bar Weight is Required. If not using a barbell (i.e. kettle bells, dumbbells etc..) put '0'")]
        [Display(Name = "Bar Weight")]
        public int BarWeight { get; set; }

        [Required]
        [Display(Name = "5x5 Max")]
        public int ExerciseMax { get; set; }

        public virtual Category Category { get; set; }
    }
}
