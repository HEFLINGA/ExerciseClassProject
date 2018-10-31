using ExerciseProgram.Domain.Abstract;
using ExerciseProgram.Domain.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseProgram.Domain.Concrete
{
    public class EFCategoryRepository : ICategoryRepository
    {
        private ExerciseContext context = new ExerciseContext();

        public IEnumerable<Category> Categories
        {
            get { return context.Categories; }
        }
    }
}
