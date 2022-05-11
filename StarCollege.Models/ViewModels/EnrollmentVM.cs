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
    public class EnrollmentVM
    {
        public Enrollment Enrollment { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> StudentList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> ClassroomList { get; set; }
    }
}
