using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarCollege.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }
        public ICollection<Classroom> Classrooms { get; set; }
    }
}