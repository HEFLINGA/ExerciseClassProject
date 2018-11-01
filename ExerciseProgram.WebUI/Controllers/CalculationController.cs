using ExerciseProgram.Domain.Abstract;
using ExerciseProgram.Domain.Concrete;
using ExerciseProgram.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExerciseProgram.WebUI.Controllers
{
    public class CalculationController : Controller
    {
        private IExerciseRepository repository;

        public CalculationController(IExerciseRepository repo)
        {
            repository = repo;
        }
        public ViewResult Index(string returnUrl)
        {
            return View(new CalculationIndexViewModel
            {
                Calculation = GetCalculation(),
                ReturnUrl = returnUrl
            });
        }
        public RedirectToRouteResult AddToCalculation(int exerciseId, string returnUrl)
        {
            Exercise exercise = repository.Exercises
                .FirstOrDefault(e => e.ExerciseID == exerciseId);
            Calculation calculation = new Calculation();

            if (exercise != null)
            {
                GetCalculation().AddExercise(exercise, calculation);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public RedirectToRouteResult RemoveFromCalculation(int exerciseId, string returnUrl)
        {
            Exercise exercise = repository.Exercises
                .FirstOrDefault(e => e.ExerciseID == exerciseId);

            if (exercise != null)
            {
                GetCalculation().RemoveLine(exercise);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        private Calculation GetCalculation()
        {
            Calculation calc = (Calculation)Session["Calculation"];
            if (calc == null)
            {
                calc = new Calculation();
                Session["Calculation"] = calc;
            }
            return calc;
        }
    }
}