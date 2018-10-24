using ExerciseProgram.Domain.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ExerciseProgram.Domain.Concrete
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("ApplicationContext")
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
