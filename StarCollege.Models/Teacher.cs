using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarCollege.Models
{
    public class Teacher : Person
    {
        public string Title { get; set; }
        public IEnumerable<Classroom>? Classrooms { get; set; }
    }
}
