using ExerciseProgram.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseProgram.Domain.Abstract
{
    public interface IExerciseRepository
    {
        IEnumerable<Exercise> Exercises { get; }
    }
}
