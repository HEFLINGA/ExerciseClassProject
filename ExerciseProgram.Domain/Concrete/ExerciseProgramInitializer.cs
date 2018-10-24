using ExerciseProgram.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseProgram.Domain.Concrete
{
    public class ExerciseProgramInitializer : System.Data.Entity. DropCreateDatabaseIfModelChanges<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            var customers = new List<Customer>
            {
                new Customer{FirstName="Auston",LastName="Hefling",DateOfBirth=DateTime.Parse("1995-06-15"),Weight=178.5M},
                new Customer{FirstName="Erin",LastName="Hefling",DateOfBirth=DateTime.Parse("1995-07-27"),Weight=124M}
            };

            customers.ForEach(c => context.Customers.Add(c));
            context.SaveChanges();

            var categories = new List<Category>
            {
                new Category{Name="Chest",Description="Exercises involving the Chest."},
                new Category{Name="Back",Description="Exercises involving the Back."},
                new Category{Name="Legs",Description="Good luck out there.."},
                new Category{Name="Shoulders",Description="Exercises involving the Shoulders."}
            };

            categories.ForEach(c => context.Categories.Add(c));
            context.SaveChanges();

            var exercises = new List<Exercise>
            {
                new Exercise{CustID=1,CatID=1,ExerciseName="Benchpress"
                ,ExerciseDesc="Using a 45lb bar laying on a bench, let the bar lower to your chest, then push back to the start point."},
                new Exercise{CustID=1,CatID=1,ExerciseName="Dumbbell Flys"
                ,ExerciseDesc="Using dumbbells laying flat on a bench, use dumbells going straight to the side and back."},
                new Exercise{CustID=1,CatID=2,ExerciseName="Deadlift"
                ,ExerciseDesc="Using a 45lb bar, lift straight up from the ground, and back."},
                new Exercise{CustID=1,CatID=3,ExerciseName="Squat"
                ,ExerciseDesc="Using a 45lb bar resting on your shoulders, squat straight down keeping your back straight, and return to starting position."},
                new Exercise{CustID=1,CatID=4,ExerciseName="Military Press",ExerciseDesc="Using a 45lb bar, hands holding the bar at shoulder level about shoulder width apart, push over your head and back."},
            };

            exercises.ForEach(e => context.Exercises.Add(e));
            context.SaveChanges();
        }
    }
}
