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
        public int CurrentSet { get; set; }
        public int CurrentPhase { get; set; }


        public int FirstSet(int currentPhase)
        {
            throw new NotImplementedException();
        }

        public int SecondSet(int currentPhase)
        {
            throw new NotImplementedException();
        }

        public int ThirdSet(int currentPhase)
        {
            throw new NotImplementedException();
        }

        public int FourthSet(int currentPhase)
        {
            throw new NotImplementedException();
        }

        public int FifthSet(int currentPhase)
        {
            throw new NotImplementedException();
        }
    }
}
