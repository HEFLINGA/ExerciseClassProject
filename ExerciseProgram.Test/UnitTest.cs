using System.Collections.Generic;
using ExerciseProgram.Domain.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;
using ExerciseProgram.Domain.DAL;
using System.Data.Entity;
using ExerciseProgram.WebUI.Controllers;

namespace ExerciseProgram.Test
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void Can_Do_Math_On_FiveByFive_Sets()
        {
            Calculation cal = new Calculation();
            Exercise exercise1 = new Exercise
            {
                Name = "Super Fly",
                ExerciseMax = 225,
                CategoryID = 1
            };

            Assert.AreEqual(135, cal.WeightOnFiveByFiveSet(exercise1.ExerciseMax, 1));
            Assert.AreEqual(170, cal.WeightOnFiveByFiveSet(245, 2));
            Assert.AreEqual(210, cal.WeightOnFiveByFiveSet(265, 3));
            Assert.AreEqual(205, cal.WeightOnFiveByFiveSet(exercise1.ExerciseMax, 4));
            Assert.AreEqual(225, cal.WeightOnFiveByFiveSet(exercise1.ExerciseMax, 5));
        }

        [TestMethod]
        public void Can_Do_Math_On_OneByThree_Set()
        {
            Calculation cal = new Calculation();

            Assert.AreEqual(235, cal.WeightOnOneByThreeSet(225));
        }

        [TestMethod]
        public void Can_Do_Math_On_OneByEight_Set()
        {
            Calculation cal = new Calculation();

            Assert.AreEqual(180, cal.WeightOnOneByEightSet(225));
        }

        [TestMethod]
        public void Can_Display_Plate_Weight_In_String()
        {
            Plate plate = new Plate();
            Calculation cal = new Calculation();
            Exercise exercise1 = new Exercise
            {
                Name = "Overhead Press",
                Description = "SuperHard",
                CategoryID = 4,
                ExerciseMax = 205
            };
            Exercise exercise2 = new Exercise
            {
                ExerciseMax = 305
            };
            
            Assert.AreEqual("2x45, 2x25, 2x10, 0x5, 0x2.5"
                , plate.PlateWeight(cal.WeightOnFiveByFiveSet(exercise1.ExerciseMax, 5)));
            Assert.AreEqual("6x45, 0x25, 0x10, 0x5, 2x2.5"
                , plate.PlateWeight(cal.WeightOnOneByThreeSet(exercise2.ExerciseMax)));
        }
    }
}
