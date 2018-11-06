using ExerciseProgram.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExerciseProgram.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IExerciseRepository repository;

        public NavController(IExerciseRepository repo)
        {
            repository = repo;
        }

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;

            IEnumerable<string> categories = repository.Exercises
                .Select(x => x.Category.Name)
                .Distinct()
                .OrderBy(x => x);
            return PartialView(categories);
        }

        public PartialViewResult AddExercisesMenu(string addExercisesCategory = null)
        {
            ViewBag.SelectedCategory = addExercisesCategory;

            IEnumerable<string> addExercisesCategories = repository.Exercises
                .Select(x => x.Category.Name)
                .Distinct()
                .OrderBy(x => x);
            return PartialView(addExercisesCategories);
        }
    }
}