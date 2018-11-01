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
        private int currentSetWeight = 0;

        public int WeightOnFiveByFiveSet(int exerciseMax, int currentSet)
        {
            currentSetWeight = 0;
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
            currentSetWeight = 0;
            currentSetWeight = exerciseMax;
            currentSetWeight += exerciseMax * 5 / 100;
            currentSetWeight = nearestFive.RoundTo(currentSetWeight, 5);
            return currentSetWeight;
        }
        public int WeightOnOneByEightSet(int exerciseMax)
        {
            currentSetWeight = 0;
            currentSetWeight = exerciseMax;
            currentSetWeight -= currentSetWeight * 20 / 100;
            currentSetWeight = nearestFive.RoundTo(currentSetWeight, 5);
            return currentSetWeight;
        }

        // Start of new code
        public List<CalcLine> lineCollection = new List<CalcLine>();

        public void AddExercise(Exercise exercise, Calculation calculation)
        {
            CalcLine line = lineCollection
                .Where(c => c.Exercise.ExerciseID == exercise.ExerciseID)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.RemoveAll(e => e.Exercise.ExerciseID != exercise.ExerciseID);
                lineCollection.Add(new CalcLine
                {
                    Exercise = exercise,
                    Calculation = calculation
                });
            }
        }

        public void RemoveLine(Exercise exercise)
        {
            lineCollection.RemoveAll(l => l.Exercise.ExerciseID == exercise.ExerciseID);
        }

        public decimal ComputeTotal(int index)
        {
            return lineCollection.Sum(e => e.Calculation.WeightOnFiveByFiveSet(e.Exercise.ExerciseMax, index));
        }
        public decimal ComputeTotal()
        {
            return lineCollection.Sum(e => e.Calculation.WeightOnOneByEightSet(e.Exercise.ExerciseMax));
        }
        public decimal ComputeTotalOfThree()
        {
            return lineCollection.Sum(e => e.Calculation.WeightOnOneByThreeSet(e.Exercise.ExerciseMax));
        }

        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CalcLine> Lines
        {
            get { return lineCollection; }
        }

        public class CalcLine
        {
            public Exercise Exercise { get; set; }
            public Calculation Calculation { get; set; }
        }
    }
}
