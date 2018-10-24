using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseProgram.Domain.Entities
{
    public class Category
    {
        [Key]
        public int catID { get; set; }
        public int exerciseID { get; set; }
        public string catName { get; set; }
        public string catDesc { get; set; }
    }
}
