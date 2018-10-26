using ExerciseProgram.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseProgram.Domain.Concrete
{
    public class Plate : IPlate
    {
        private readonly string FourtyFive = "45";
        private readonly string TwentyFive = "25";
        private readonly string Ten = "10";
        private readonly string Five = "5";
        private readonly string TwoPointFive = "2.5";

        public string PlateWeight(int totalWeight)
        {
            totalWeight -= 45;
            int totalOf45 = 0;
            int totalOf25 = 0;
            int totalOf10 = 0;
            int totalOf5 = 0;
            int totalOf2Point5 = 0;        

            while (totalWeight != 0)
            {
                if (totalWeight >= 5)
                {
                    totalOf2Point5 += 2;
                    totalWeight -= 5;
                }
                if(totalOf2Point5 >= 4)
                {
                    totalOf5 += 2;
                    totalOf2Point5 = 0;
                }
                if (totalOf5 >= 4)
                {
                    totalOf10 += 2;
                    totalOf5 = 0;
                }
                if (totalOf10 >= 4 && totalOf5 >= 2)
                {
                    totalOf25 += 2;
                    totalOf10 = 0;
                    totalOf5 = 0;
                }
                if (totalOf25 >= 2 && totalOf10 >= 4)
                {
                    totalOf45 += 2;
                    totalOf25 -= 2;
                    totalOf10 -= 4;
                }
            }
                

            string answer = $"{totalOf45}x{FourtyFive}, {totalOf25}x{TwentyFive}, {totalOf10}x{Ten}, {totalOf5}x{Five}, {totalOf2Point5}x{TwoPointFive}";

            return $"{answer}";
        }
    }
}
