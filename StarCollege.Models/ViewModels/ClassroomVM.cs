using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarCollege.Models.ViewModels
{
    public class ClassroomVM
    {
        public Classroom Classroom { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> CourseList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> TeacherList { get; set; }
    }
}
