using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web.Mvc;
using ExerciseProgram.Domain.Abstract;
using ExerciseProgram.Domain.Entities;
using ExerciseProgram.WebUI.Controllers;
using System.Collections.Generic;
using ExerciseProgram.WebUI.Models;
using ExerciseProgram.WebUI.HtmlHelpers;

namespace ExerciseProgram.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Paginate()            
        {
            // Arrange
            Mock<IExerciseRepository> mock = new Mock<IExerciseRepository>();
            mock.Setup(m => m.Exercises).Returns(new Exercise[]{
                new Exercise {exerciseID = 1, exerciseName = "E1"},
                new Exercise {exerciseID = 2, exerciseName = "E2"},
                new Exercise {exerciseID = 3, exerciseName = "E3"},
                new Exercise {exerciseID = 4, exerciseName = "E4"},
                new Exercise {exerciseID = 5, exerciseName = "E5"}
            });

            ExerciseController controller = new ExerciseController(mock.Object);
            controller.PageSize = 3;

            // Act
            ExerciseListViewModel result = (ExerciseListViewModel)controller.List(2).Model;

            // Assert
            Exercise[] exArray = result.Exercises.ToArray();
            Assert.IsTrue(exArray.Length == 2);
            Assert.AreEqual(exArray[0].exerciseName, "E4");
            Assert.AreEqual(exArray[1].exerciseName, "E5");
        }

        [TestMethod]
        public void Can_Generate_Page_Links()
        {
            // Arrange - Used to apply the extension method
            HtmlHelper myHelper = null;

            // Arrange - Create paginginfo data
            PagingInfo pagingInfo = new PagingInfo
            {
                CurrentPage = 2,
                TotalItems = 28,
                ItemsPerPage = 10
            };

            // Arrange - Set up the delage
            Func<int, string> pageUrlDelegate = i => "Page" + i;

            // Act
            MvcHtmlString result = myHelper.PageLinks(pagingInfo, pageUrlDelegate);

            // Assert
            Assert.AreEqual(@"<a class=""btn btn-default"" href=""Page1"">1</a>"
                            + @"<a class=""btn btn-deafult btn-primary selected"" href=""Page2"">2</a>"
                            + @"<a class=""btn btn-default"" href=""Page3"">3</a>",
                            result.ToString());
        }

        [TestMethod]
        public void Can_Sned_Pagination_View_Model()
        {
            // Arrange
            Mock<IExerciseRepository> mock = new Mock<IExerciseRepository>();
            mock.Setup(m => m.Exercises).Returns(new Exercise[]
            {
                new Exercise {exerciseID = 1, exerciseName = "E1"},
                new Exercise {exerciseID = 2, exerciseName = "E2"},
                new Exercise {exerciseID = 3, exerciseName = "E3"},
                new Exercise {exerciseID = 4, exerciseName = "E4"},
                new Exercise {exerciseID = 5, exerciseName = "E5"}
            });

            // Arrange
            ExerciseController controller = new ExerciseController(mock.Object);
            controller.PageSize = 3;

            // Act
            ExerciseListViewModel result = (ExerciseListViewModel)controller.List(2).Model;

            // Assert
            PagingInfo pageInfo = result.PagingInfo;
            Assert.AreEqual(pageInfo.CurrentPage, 2);
            Assert.AreEqual(pageInfo.ItemsPerPage, 3);
            Assert.AreEqual(pageInfo.TotalItems, 5);
            Assert.AreEqual(pageInfo.TotalPages, 2);
        }
    }
}
