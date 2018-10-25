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

            Assert.AreEqual(135, cal.WeightOnFiveByFiveSet(225, 1));
            Assert.AreEqual(170, cal.WeightOnFiveByFiveSet(245, 2));
            Assert.AreEqual(210, cal.WeightOnFiveByFiveSet(265, 3));
            Assert.AreEqual(205, cal.WeightOnFiveByFiveSet(225, 4));
            Assert.AreEqual(225, cal.WeightOnFiveByFiveSet(225, 5));
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
    }
}
