using ExerciseProgram.Domain.Concrete;

namespace ExerciseProgram.Domain.Abstract
{
    public interface ICalculation
    {
        int CurrentPhase { get; set; }
        int CurrentSet { get; set; }
        int WeightOnSet(int currentPhase, int exerciseMax, int currentSet);
    }
}
