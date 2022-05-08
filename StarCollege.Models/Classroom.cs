using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarCollege.Models
{
    public class Classroom
    {
        [Key]
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int TeacherId { get; set; }
        public string ClassCode { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
