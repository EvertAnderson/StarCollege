using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [ForeignKey("CourseId")]
        [ValidateNever]
        public Course Course { get; set; }
        public int TeacherId { get; set; }
        [ForeignKey("TeacherId")]
        [ValidateNever]
        public Teacher Teacher { get; set; }
        public string ClassCode { get; set; }
        public ICollection<Enrollment>? Enrollments { get; set; }
    }
}
