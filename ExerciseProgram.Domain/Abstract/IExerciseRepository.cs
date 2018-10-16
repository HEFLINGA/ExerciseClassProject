using ExerciseProgram.Domain.Entities;
using System.Collections.Generic;

namespace ExerciseProgram.Domain.Abstract
{
    public interface IExerciseRepository
    {
        IEnumerable<Exercise> Exercises { get; }
    }
}
