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
    public class Enrollment
    {
        [Key]
        public int Id { get; set; }
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        [ValidateNever]
        public Student Student { get; set; }
        public int ClassroomId { get; set; }
        [ForeignKey("ClassroomId")]
        [ValidateNever]
        public Classroom Classroom { get; set; }
        public double Score { get; set; }
    }
}
