using ExerciseProgram.Domain.Concrete;

namespace ExerciseProgram.Domain.Abstract
{
    public interface ICalculation
    {
        int WeightOnFiveByFiveSet(int exerciseMax, int index, int barWeight);
        int WeightOnOneByThreeSet(int exerciseMax, int barWeight);
        int WeightOnOneByEightSet(int exerciseMax, int barWeight);
    }
}
