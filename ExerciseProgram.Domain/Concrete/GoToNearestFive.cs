using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseProgram.Domain.Concrete
{
    public class GoToNearestFive
    {
        // Code for the idea behind this Number Rounder was found here:
        // https://codereview.stackexchange.com/questions/109319/round-to-specified-int

        public int RoundTo(int value, int roundTo)
        {
            var remainder = value % roundTo;
            var result = remainder < roundTo - remainder
                ? (value - remainder)
                : (value + (roundTo - remainder));
            return result;
        }
    }
}
