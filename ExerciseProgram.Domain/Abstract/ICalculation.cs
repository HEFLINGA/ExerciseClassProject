﻿using ExerciseProgram.Domain.Concrete;

namespace ExerciseProgram.Domain.Abstract
{
    public interface ICalculation
    {
        int CurrentSet { get; set; }
        int WeightOnFiveByFiveSet(int exerciseMax, int currentSet);
        int WeightOnOneByThreeSet(int exerciseMax);
        int WeightOnOneByEightSet(int exerciseMax);
    }
}