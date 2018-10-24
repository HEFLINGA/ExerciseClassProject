using ExerciseProgram.Domain.Entities;
using System.Data.Entity;

namespace ExerciseProgram.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}