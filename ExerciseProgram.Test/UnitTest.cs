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
        public void Can_Do_Math()
        {
            var exerciseMax = 225;
            var currentPhase = 1;
            var currentSet = 1;

            Calculation cal = new Calculation();

            var tmp = cal.WeightOnSet(currentPhase, exerciseMax, currentSet);

            Assert.AreEqual(112, tmp);
        }
    }
}
