using ExerciseProgram.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExerciseProgram.WebUI.Models
{
    public class ExerciseListViewModel
    {
        public IEnumerable<Exercise> Exercises { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}