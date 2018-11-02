using ExerciseProgram.Domain.Abstract;
using ExerciseProgram.Domain.Concrete;
using ExerciseProgram.Domain.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseProgram.Domain.Concrete
{
    public class Plate : IPlate
    {
        GoToNearestFive GoToNearestFive = new GoToNearestFive();
        public string PlateWeight(int totalWeight, int barWeight)
        {
            totalWeight -= barWeight;
            int totalOf45 = 0;
            int totalOf25 = 0;
            int totalOf10 = 0;
            int totalOf5 = 0;
            int totalOf2Point5 = 0;
            string answer = "";

            if (barWeight > 0)
            {
                while (totalWeight != 0)
                {
                    if (totalWeight >= 5)
                    {
                        totalOf2Point5 += 2;
                        totalWeight -= 5;
                    }
                    if (totalOf2Point5 >= 4)
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

                if (totalOf45 > 0)
                {
                    answer += $"{totalOf45}x45 ";
                }
                if (totalOf25 > 0)
                {
                    answer += $"{totalOf25}x25 ";
                }
                if (totalOf10 > 0)
                {
                    answer += $"{totalOf10}x10 ";
                }
                if (totalOf5 > 0)
                {
                    answer += $"{totalOf5}x5 ";
                }
                if (totalOf2Point5 > 0)
                {
                    answer += $"{totalOf2Point5}x2.5";
                }
            }
            else
            {
                totalWeight /= 2;
                answer = $"2x{totalWeight}";
            }

            return $"{answer}";
        }
    }
}
