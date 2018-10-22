using ExerciseProgram.Domain.Abstract;
using ExerciseProgram.Domain.Entities;
using System.Collections.Generic;

namespace ExerciseProgram.Domain.Concrete
{
    public class EFCustomerRepository : ICustomerRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Customer> Customers
        {
            get { return context.Customers; }
        }
    }
}
