using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExerciseProgram.Domain.Entities
{
    public class Customer
    {
        public int custID { get; set; }

        [Range(1, 200)]
        [Display(Name = "Age")]
        public int custAge { get; set; }

        [Range(50, 1000)]
        [Display(Name = "Weight")]
        public int custWeight { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [Required]
        [StringLength(100)]
        [Display(Name = "Name")]
        public string custName { get; set; }
    }
}
