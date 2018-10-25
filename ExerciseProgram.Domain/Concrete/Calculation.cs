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
        private int[] currentSetWeight = new int[5];
        public int CurrentSet { get; set; }
        public int CurrentPhase { get; set; }

        public int WeightOnSet(int currentPhase, int exerciseMax, int currentSet)
        {
            currentSetWeight[0] = exerciseMax;

            if (currentPhase == 1)
            {
                if (currentSet == 1)
                {
                    return currentSetWeight[0] / 2;
                }
                else if (currentSet == 2)
                {
                    return currentSetWeight[1] += currentSetWeight[0] * 10 / 100;
                }
                else if (currentSet == 3)
                {
                    return currentSetWeight[2] += currentSetWeight[1] * 10 / 100;
                }
                else if (currentSet == 4)
                {
                    return currentSetWeight[3] += currentSetWeight[2] * 10 / 100;
                }
                else if (currentSet == 5)
                {
                    return currentSetWeight[4] += currentSetWeight[3] * 10 / 100;
                }
                else
                {
                    throw new Exception("Current set weight or max is not correct");
                }
                
            }
            /*
            else if (currentPhase == 2)
            {

            }
            else if (currentPhase == 2)
            {

            }
            */
            else
            {
                throw new Exception("Phase Information Incorrect");
            }
        }
    }
}
