using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarCollege.Models.ViewModels
{
    public class CourseListVM
    {
        public IEnumerable<Course> Courses { get; set; }
        [ValidateNever]
        public int numberStudents { get; set; }
    }
}
