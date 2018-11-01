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

        // Start of new code
        public List<CalcLine> lineCollection = new List<CalcLine>();

        public void AddExercise(Exercise exercise, int quantity, Calculation calculation)
        {
            CalcLine line = lineCollection
                .Where(c => c.Exercise.ExerciseID == exercise.ExerciseID)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CalcLine
                {
                    Exercise = exercise,
                    Quantity = quantity,
                    Calculation = calculation
                });
            }
            else
            {
                line.Quantity += quantity;
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
            public int Quantity { get; set; }
        }
    }
}
