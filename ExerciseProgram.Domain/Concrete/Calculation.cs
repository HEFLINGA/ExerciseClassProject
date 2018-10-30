using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExerciseProgram.Domain.Abstract;

namespace ExerciseProgram.Domain.Concrete
{
    public class Calculation : ICalculation
    {
        GoToNearestFive nearestFive = new GoToNearestFive();
        private int currentSetWeight;
        public int CurrentSet { get; set; }

        public int WeightOnFiveByFiveSet(int exerciseMax, int currentSet)
        {
            currentSetWeight = exerciseMax;

            if (currentSet == 1)
            {
                currentSetWeight -= currentSetWeight * 40 / 100;
                currentSetWeight = nearestFive.RoundTo(currentSetWeight, 5);
                return currentSetWeight;
            }
            else if (currentSet == 2)
            {
                currentSetWeight -= currentSetWeight * 30 / 100;
                currentSetWeight = nearestFive.RoundTo(currentSetWeight, 5);
                return currentSetWeight;
            }
            else if (currentSet == 3)
            {
                currentSetWeight -= currentSetWeight * 20 / 100;
                currentSetWeight = nearestFive.RoundTo(currentSetWeight, 5);
                return currentSetWeight;
            }
            else if (currentSet == 4)
            {
                currentSetWeight -= currentSetWeight * 10 / 100;
                currentSetWeight = nearestFive.RoundTo(currentSetWeight, 5);
                return currentSetWeight;
            }
            else if (currentSet == 5)
            {
                currentSetWeight = nearestFive.RoundTo(currentSetWeight, 5);
                return currentSetWeight;
            }
            else
            {
                throw new Exception("Current set weight or max is not correct");
            }
        }
        public int WeightOnOneByThreeSet(int exerciseMax)
        {
            currentSetWeight = exerciseMax;
            currentSetWeight += exerciseMax * 5 / 100;
            currentSetWeight = nearestFive.RoundTo(currentSetWeight, 5);
            return currentSetWeight;
        }
        public int WeightOnOneByEightSet(int exerciseMax)
        {
            currentSetWeight = exerciseMax;
            currentSetWeight -= currentSetWeight * 20 / 100;
            currentSetWeight = nearestFive.RoundTo(currentSetWeight, 5);
            return currentSetWeight;
        }
    }
}
