using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExerciseProgram.Domain.Concrete
{
    public class Category
    {
        [Display(Name = "Category")]
        public int CategoryID { get; set; }

        [Display(Name = "Category")]
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
