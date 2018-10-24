using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExerciseProgram.Domain.Entities;

namespace ExerciseProgram.Domain.Concrete
{
    public class Calculation
    {
        Exercise Exercise = new Exercise();
        public int CurrentSet { get; set; }
        public int RepsWeight { get; set; }

        public int SetWeight()
        {
            RepsWeight = Exercise.ExerciseMax;
            if (CurrentSet == 1)
            {
                return RepsWeight = RepsWeight * 15 / 100;
            }
            else if (CurrentSet == 2)
            {
                return RepsWeight = RepsWeight * 15 / 100;
            }
            else if (CurrentSet == 3)
            {
                return RepsWeight = RepsWeight * 15 / 100;
            }
            else if (CurrentSet == 4)
            {
                return RepsWeight = RepsWeight * 15 / 100;
            }
            else if (CurrentSet == 5)
            {
                return RepsWeight = RepsWeight * 15 / 100;
            }

            return RepsWeight;
        }
    }
}
