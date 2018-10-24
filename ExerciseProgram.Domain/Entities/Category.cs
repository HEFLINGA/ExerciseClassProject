using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseProgram.Domain.Entities
{
    public class Category
    {
        [Key]
        public int CatID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
