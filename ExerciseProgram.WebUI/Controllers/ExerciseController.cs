using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExerciseProgram.Domain.Abstract;
using ExerciseProgram.Domain.Entities;
using ExerciseProgram.WebUI.Models;

namespace ExerciseProgram.WebUI.Controllers
{
    public class ExerciseController : Controller
    {
        private IExerciseRepository repository;
        public int PageSize = 10;

        public ExerciseController(IExerciseRepository exerciseRepository)
        {
            this.repository = exerciseRepository;
        }

        public ViewResult List(int page = 1)
        {
            ExerciseListViewModel model = new ExerciseListViewModel
            {
                Exercises = repository.Exercises
                .OrderBy(e => e.exerciseID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Exercises.Count()
                }
            };
            return View(model);
        }
    }
}