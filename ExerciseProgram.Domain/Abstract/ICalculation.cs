using ExerciseProgram.Domain.Concrete;

namespace ExerciseProgram.Domain.Abstract
{
    public interface ICalculation
    {
        int FirstSet(int currentPhase);
        int SecondSet(int currentPhase);
        int ThirdSet(int currentPhase);
        int FourthSet(int currentPhase);
        int FifthSet(int currentPhase);
    }
}
