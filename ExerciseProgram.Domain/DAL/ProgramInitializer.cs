using ExerciseProgram.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseProgram.Domain.DAL
{
    public class ProgramInitializer : System.Data.Entity.DropCreateDatabaseAlways<ExerciseContext>
    {
        protected override void Seed(ExerciseContext context)
        {
            var categories = new List<Category>
            {
                new Category{Name="Chest",
                    Description ="Exercises prodominantly involving the pectoralis major and pectoralis minor."},
                new Category{Name="Back",
                    Description ="Exercises prodominantly involving the trapezius, latissimus dorsi, serratus posterior inferior and superior, or any combination of said muscles."},
                new Category{Name="Legs",
                    Description ="Good luck out there.. Also.. These are any exercises involving the quadriceps, hamstrings, gastrocnemius(calf muscle) or gluteus maximus."},
                new Category{Name="Shoulders",
                    Description ="Exercises prodominantly involving the deltoid, pecktoralis minor or any of the surrounding muscles."},
                new Category{Name="Arms",
                    Description="Exercises primarely involving the Biceps, Triceps, and Forearm muscles"}
            };
            categories.ForEach(s => context.Categories.Add(s));
            context.SaveChanges();

            var exercises = new List<Exercise>
            {
                new Exercise{CategoryID = 1,
                    Name = "Bench press",
                    Description = "The bench press is an upper body strength training exercise that consists of pressing a weight upwards from a supine position.",
                    ExerciseMax = 225,
                    BarWeight = 45},
                new Exercise{CategoryID = 2,
                    Name = "Deadlift",
                    Description = "The deadlift is a weight training exercise in which a loaded barbell or bar is lifted off the ground to the level of the hips, then lowered to the ground.",
                    ExerciseMax = 275,
                    BarWeight = 45},
                new Exercise{CategoryID = 3,
                    Name = "Squat",
                    Description = "Movement begins from a standing position, lower your body towards the ground keeping good form, then back to the starting position. Bar is to be placed on your upper back and rear deltoids.",
                    ExerciseMax = 225,
                    BarWeight = 45},
                new Exercise{CategoryID = 4,
                    Name = "Military Press",
                    Description = "With bar starting at shoulder level, lift weight overhead until the elbows are fully locked out. As the weight clears the head, the lifter leans forward slightly, or comes directly under, in order to keep balance. As the weight is lowered back to racking position and clears the head again, the lifter leans slightly back.",
                    ExerciseMax = 155,
                    BarWeight = 45},
                new Exercise{CategoryID = 5,
                    Name = "Dumbbell Curl",
                    Description = "With a dumbbell in each hand, raise your hands up keeping your elbows to your side, and arms raising towards shoulders. Once the top of the motion is reached, lower the weight back down again in a slow and controlled motion.",
                    ExerciseMax = 100,
                    BarWeight = 0 }
            };
            exercises.ForEach(s => context.Exercises.Add(s));
            context.SaveChanges();
        }
    }
}
