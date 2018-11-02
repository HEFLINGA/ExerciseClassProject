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
        // Custom code to make the math work for getting weight per set
        GoToNearestFive nearestFive = new GoToNearestFive();
        private int currentSetWeight = 0;
        public int WeightOnFiveByFiveSet(int exerciseMax, int currentSet, int barWeight)
        {
            currentSetWeight = 0;
            currentSetWeight = exerciseMax;

            if (barWeight > 0)
            {
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
            else
            {
                if (currentSet == 1)
                {
                    currentSetWeight -= currentSetWeight * 40 / 100;
                    currentSetWeight = nearestFive.RoundTo(currentSetWeight, 10);
                    return currentSetWeight;
                }
                else if (currentSet == 2)
                {
                    currentSetWeight -= currentSetWeight * 30 / 100;
                    currentSetWeight = nearestFive.RoundTo(currentSetWeight, 10);
                    return currentSetWeight;
                }
                else if (currentSet == 3)
                {
                    currentSetWeight -= currentSetWeight * 20 / 100;
                    currentSetWeight = nearestFive.RoundTo(currentSetWeight, 10);
                    return currentSetWeight;
                }
                else if (currentSet == 4)
                {
                    currentSetWeight -= currentSetWeight * 10 / 100;
                    currentSetWeight = nearestFive.RoundTo(currentSetWeight, 10);
                    return currentSetWeight;
                }
                else if (currentSet == 5)
                {
                    currentSetWeight = nearestFive.RoundTo(currentSetWeight, 10);
                    return currentSetWeight;
                }
                else
                {
                    throw new Exception("Current set weight or max is not correct");
                }
            }
        }
        public int WeightOnOneByThreeSet(int exerciseMax, int barWeight)
        {
            if (barWeight > 0)
            {
                currentSetWeight = 0;
                currentSetWeight = exerciseMax;
                currentSetWeight += exerciseMax * 2 / 100;
                currentSetWeight = nearestFive.RoundTo(currentSetWeight, 5);
                return currentSetWeight;
            }
            else
            {
                currentSetWeight = 0;
                currentSetWeight = exerciseMax;
                currentSetWeight += exerciseMax * 5 / 100;
                currentSetWeight = nearestFive.RoundTo(currentSetWeight, 10);
                return currentSetWeight;
            }
            
        }
        public int WeightOnOneByEightSet(int exerciseMax, int barWeight)
        {
            if (barWeight > 0)
            {
                currentSetWeight = 0;
                currentSetWeight = exerciseMax;
                currentSetWeight -= currentSetWeight * 20 / 100;
                currentSetWeight = nearestFive.RoundTo(currentSetWeight, 5);
                return currentSetWeight;
            }
            else
            {
                currentSetWeight = 0;
                currentSetWeight = exerciseMax;
                currentSetWeight -= currentSetWeight * 20 / 100;
                currentSetWeight = nearestFive.RoundTo(currentSetWeight, 10);
                return currentSetWeight;
            }
            
        }

        // Code for getting calculations to the View
        public List<CalcLine> lineCollection = new List<CalcLine>();
        public void AddExercise(Exercise exercise, Calculation calculation, Plate plate)
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
                    Calculation = calculation,
                    Plate = plate
                });
            }
        }
        public void RemoveLine(Exercise exercise)
        {
            lineCollection.RemoveAll(l => l.Exercise.ExerciseID == exercise.ExerciseID);
        }
        public decimal ComputeTotal(int index)
        {
            return lineCollection.Sum(e => e.Calculation.WeightOnFiveByFiveSet(e.Exercise.ExerciseMax, index, e.Exercise.BarWeight));
        }
        public decimal ComputeTotal()
        {
            return lineCollection.Sum(e => e.Calculation.WeightOnOneByEightSet(e.Exercise.ExerciseMax, e.Exercise.BarWeight));
        }
        public decimal ComputeTotalOfThree()
        {
            return lineCollection.Sum(e => e.Calculation.WeightOnOneByThreeSet(e.Exercise.ExerciseMax, e.Exercise.BarWeight));
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
            public Plate Plate { get; set; }
        }
    }
}
