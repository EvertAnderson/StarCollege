using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarCollege.Models
{
    public class Student : Person
    {
        public IEnumerable<Enrollment>? Enrollments { get; set; }
    }
}