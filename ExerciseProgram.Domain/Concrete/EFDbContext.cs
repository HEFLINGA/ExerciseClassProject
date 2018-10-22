using ExerciseProgram.Domain.Entities;
using System.Data.Entity;

namespace ExerciseProgram.Domain.Concrete
{
    public class EFDbContext : System.Data.Entity.DbContext
    {
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}