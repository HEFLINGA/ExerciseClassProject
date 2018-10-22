using ExerciseProgram.Domain.Entities;
using System.Collections.Generic;

namespace ExerciseProgram.Domain.Abstract
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> Customers { get; }
    }
}
