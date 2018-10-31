using ExerciseProgram.Domain.Abstract;
using ExerciseProgram.Domain.Concrete;
using ExerciseProgram.Domain.DAL;
using ExerciseProgram.WebUI.Models;
using System.Linq;
using System.Web.Mvc;

namespace ExerciseProgram.WebUI.Controllers
{
    public class PlateController : Controller
    {
        private IExerciseRepository repository;

        public PlateController(IExerciseRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new PlateIndexViewModel
            {
                Plate = GetPlate(),
                ReturnUrl = returnUrl
            });
        }

        public RedirectToRouteResult AddToPlate(int exerciseId, string returnUrl)
        {
            Exercise exercise = repository.Exercises
                .FirstOrDefault(e => e.ExerciseID == exerciseId);

            if (exercise != null)
            {
                GetPlate().PlateWeight(exercise.ExerciseMax);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        private Plate GetPlate()
        {
            Plate plate = (Plate)Session["Plate"];
            if (plate == null)
            {
                plate = new Plate();
                Session["Plate"] = plate;
            }
            return plate;
        }
    }
}