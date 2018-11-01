using ExerciseProgram.Domain.Concrete;

namespace ExerciseProgram.Domain.Abstract
{
    public interface ICalculation
    {
        int WeightOnFiveByFiveSet(int exerciseMax, int index);
        int WeightOnOneByThreeSet(int exerciseMax);
        int WeightOnOneByEightSet(int exerciseMax);
    }
}
