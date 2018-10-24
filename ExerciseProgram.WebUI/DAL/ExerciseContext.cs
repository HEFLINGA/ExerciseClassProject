using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using ExerciseProgram.WebUI.Models;

namespace ExerciseProgram.WebUI.DAL
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