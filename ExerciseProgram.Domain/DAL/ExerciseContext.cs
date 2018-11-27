using ExerciseProgram.Domain.Concrete;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ExerciseProgram.Domain.DAL
{
    public class ExerciseContext : DbContext
    {
        public ExerciseContext() : base("ExerciseContext")
        {
        }

        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
