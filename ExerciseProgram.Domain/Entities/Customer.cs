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
        [Key]
        public int CustID { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal Weight { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
