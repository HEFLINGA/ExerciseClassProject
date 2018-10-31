using ExerciseProgram.Domain.Abstract;
using ExerciseProgram.Domain.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseProgram.Domain.Concrete
{
    public class EFExerciseRepository : IExerciseRepository
    {
        private ExerciseContext context = new ExerciseContext();

        public IEnumerable<Exercise> Exercises
        {
            get { return context.Exercises; }
        }
    }
}
