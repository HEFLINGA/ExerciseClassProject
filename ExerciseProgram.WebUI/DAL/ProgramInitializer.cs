using ExerciseProgram.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExerciseProgram.WebUI.DAL
{
    public class ProgramInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ExerciseContext>
    {
        protected override void Seed(ExerciseContext context)
        {
            var categories = new List<Category>
            {
                new Category{Name="Chest",Description="Exercises involving the chest."},
                new Category{Name="Back",Description="Exercises involving the back."},
                new Category{Name="Legs",Description="Good luck out there.."},
                new Category{Name="Shoulders",Description="Exercises involving the shoulders."}
            };
            categories.ForEach(s => context.Categories.Add(s));
            context.SaveChanges();

            var exercises = new List<Exercise>
            {
                new Exercise{CategoryID=1,Name="Benchpress",Description="Pushing bar out and back",ExerciseMax=225},
                new Exercise{CategoryID=2,Name="Deadlift",Description="Pull bar from ground",ExerciseMax=275},
                new Exercise{CategoryID=3,Name="Squat",Description="Lower your body to parrellel and back", ExerciseMax=225},
                new Exercise{CategoryID=4,Name="Military Press",Description="Lift bar above head",ExerciseMax=155}
            };
            exercises.ForEach(s => context.Exercises.Add(s));
            context.SaveChanges();
        }
    }
}