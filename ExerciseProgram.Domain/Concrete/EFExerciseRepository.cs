using ExerciseProgram.Domain.Abstract;
using ExerciseProgram.Domain.Entities;
using System.Collections.Generic;

namespace ExerciseProgram.Domain.Concrete
{
    public class EFExerciseRepository : IExerciseRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Exercise> Exercises
        {
            get { return context.Exercises; }
        }
    }
}
