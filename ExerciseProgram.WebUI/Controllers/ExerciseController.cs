using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExerciseProgram.Domain.Abstract;
using ExerciseProgram.Domain.Entities;

namespace ExerciseProgram.WebUI.Controllers
{
    public class ExerciseController : Controller
    {
        private IExerciseRepository repository;

        public ExerciseController(IExerciseRepository exerciseRepository)
        {
            this.repository = exerciseRepository;
        }

        public ViewResult List()
        {
            return View(repository.Exercises);
        }
    }
}