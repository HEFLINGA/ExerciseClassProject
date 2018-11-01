using ExerciseProgram.Domain.Abstract;
using ExerciseProgram.Domain.Concrete;
using ExerciseProgram.WebUI.Controllers;
using ExerciseProgram.WebUI.HtmlHelpers;
using ExerciseProgram.WebUI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

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

            Assert.AreEqual(135
                , cal.WeightOnFiveByFiveSet(exercise1.ExerciseMax, 1));
            Assert.AreEqual(170
                , cal.WeightOnFiveByFiveSet(245, 2));
            Assert.AreEqual(210
                , cal.WeightOnFiveByFiveSet(265, 3));
            Assert.AreEqual(205
                , cal.WeightOnFiveByFiveSet(exercise1.ExerciseMax, 4));
            Assert.AreEqual(225
                , cal.WeightOnFiveByFiveSet(exercise1.ExerciseMax, 5));
        }

        [TestMethod]
        public void Can_Do_Math_On_OneByThree_Set()
        {
            Calculation cal = new Calculation();

            Assert.AreEqual(235
                , cal.WeightOnOneByThreeSet(225));
        }

        [TestMethod]
        public void Can_Do_Math_On_OneByEight_Set()
        {
            Calculation cal = new Calculation();

            Assert.AreEqual(180
                , cal.WeightOnOneByEightSet(225));
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
            
            Assert.AreEqual("Plates: 2x45 2x25 2x10 "
                , plate.PlateWeight(cal.WeightOnFiveByFiveSet(exercise1.ExerciseMax, 5)));
            Assert.AreEqual("Plates: 6x45 2x2.5"
                , plate.PlateWeight(cal.WeightOnOneByThreeSet(exercise2.ExerciseMax)));
        }
    }

    [TestClass]
    public class GeneralTests
    {
        [TestMethod]
        public void Can_Paginate()
        {
            Mock<IExerciseRepository> mock = new Mock<IExerciseRepository>();
            mock.Setup(m => m.Exercises).Returns(new Exercise[]
            {
                new Exercise{ExerciseID=1,Name="E1"},
                new Exercise{ExerciseID=2,Name="E2"},
                new Exercise{ExerciseID=3,Name="E3"},
                new Exercise{ExerciseID=4,Name="E4"},
                new Exercise{ExerciseID=5,Name="E5"}
            });

            ExerciseController controller = new ExerciseController(mock.Object);
            controller.PageSize = 3;

            ExercisesListViewModel result = (ExercisesListViewModel)controller.List(null, 2).Model;

            Exercise[] exArray = result.Exercises.ToArray();
            Assert.IsTrue(exArray.Length == 2);
            Assert.AreEqual(exArray[0].Name, "E4");
            Assert.AreEqual(exArray[1].Name, "E5");
        }

        [TestMethod]
        public void Can_Send_Pagination_View_Model()
        {
            Mock<IExerciseRepository> mock = new Mock<IExerciseRepository>();
            mock.Setup(m => m.Exercises).Returns(new Exercise[]
            {
                new Exercise{ExerciseID=1,Name="E1"},
                new Exercise{ExerciseID=2,Name="E2"},
                new Exercise{ExerciseID=3,Name="E3"},
                new Exercise{ExerciseID=4,Name="E4"},
                new Exercise{ExerciseID=5,Name="E5"}
            });

            ExerciseController controller = new ExerciseController(mock.Object);
            controller.PageSize = 3;

            ExercisesListViewModel result = (ExercisesListViewModel)controller.List(null, 2).Model;

            PagingInfo pageInfo = result.PagingInfo;
            Assert.AreEqual(pageInfo.CurrentPage, 2);
            Assert.AreEqual(pageInfo.ItemsPerPage, 3);
            Assert.AreEqual(pageInfo.TotalItems, 5);
            Assert.AreEqual(pageInfo.TotalPages, 2);
        }
    }
}
