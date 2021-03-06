﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExerciseProgram.Domain.Abstract;
using ExerciseProgram.Domain.Concrete;
using ExerciseProgram.Domain.DAL;
using ExerciseProgram.WebUI.Models;

namespace ExerciseProgram.WebUI.Controllers
{
    public class ExerciseController : Controller
    {
        private ExerciseContext db = new ExerciseContext();
        private IExerciseRepository exerciseRepository;
        public int PageSize = 4;

        public ExerciseController(IExerciseRepository exRepository)
        {
            this.exerciseRepository = exRepository;
        }

        public ViewResult List(string category, int page = 1)
        {
            ExercisesListViewModel model = new ExercisesListViewModel
            {
                Exercises = exerciseRepository.Exercises
                .Where(e => category == null || e.Category.Name == category)
                .OrderBy(e => e.ExerciseID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                        exerciseRepository.Exercises.Count() :
                        exerciseRepository.Exercises.Where(e => e.Category.Name == category).Count()
                },
                CurrentCategory = category
            };

            return View(model);
        }

        // GET: Exercise
        public ActionResult Index()
        {
            var exercises = db.Exercises.Include(e => e.Category);
            return View(exercises.ToList());
        }

        // GET: Exercise/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exercise exercise = db.Exercises.Find(id);
            if (exercise == null)
            {
                return HttpNotFound();
            }
            return View(exercise);
        }

        // GET: Exercise/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name");
            return View();
        }

        // POST: Exercise/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExerciseID,CategoryID,Name,Description,BarWeight,ExerciseMax")] Exercise exercise)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Exercises.Add(exercise);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Please Try again");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name", exercise.CategoryID);
            return View(exercise);
        }

        // GET: Exercise/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exercise exercise = db.Exercises.Find(id);
            if (exercise == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name", exercise.CategoryID);
            return View(exercise);
        }

        // POST: Exercise/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExerciseID,CategoryID,Name,Description,BarWeight,ExerciseMax")] Exercise exercise)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exercise).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name", exercise.CategoryID);
            return View(exercise);
        }

        // GET: Exercise/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exercise exercise = db.Exercises.Find(id);
            if (exercise == null)
            {
                return HttpNotFound();
            }
            return View(exercise);
        }

        // POST: Exercise/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Exercise exercise = db.Exercises.Find(id);
            db.Exercises.Remove(exercise);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
