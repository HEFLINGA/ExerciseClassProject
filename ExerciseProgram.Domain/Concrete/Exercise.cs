using System;
using System.Collections.Generic;
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
        public int ExerciseMax { get; set; }

        public virtual Category Category { get; set; }

    }
}
