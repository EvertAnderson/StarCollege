using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StarCollege.DataAccess.Repository.IRepository;
using StarCollege.Models;
using StarCollege.Models.ViewModels;

namespace StarCollege.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CourseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: CourseController
        public IActionResult Index()
        {
            IEnumerable<Course> objCourseList = _unitOfWork.Course.GetAll();
            return View(objCourseList);
        }

        // GET: CourseController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: CourseController/Create
        public IActionResult CreateUpdate(int? id)
        {
            CourseVM obj = new()
            {
                Course = new(),
                SubjectList = _unitOfWork.Subject.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };

            if (id == null || id == 0)
            {
                return View(obj);
            }
            else
            {
                obj.Course = _unitOfWork.Course.GetFirstOrDefault(x => x.Id == id);
                return View(obj);
            }                                                                                                                                                                                                                 
        }

        // POST: CourseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateUpdate(CourseVM obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Course.Id == 0)
                {
                    _unitOfWork.Course.Add(obj.Course);
                }
                else
                {
                    _unitOfWork.Course.Update(obj.Course);
                }
                _unitOfWork.Save();
                TempData["success"] = "Course created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET: CourseController/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var objFromDbFirst = _unitOfWork.Course.GetFirstOrDefault(u => u.Id == id);

            if (objFromDbFirst == null)
            {
                return NotFound();
            }

            return View(objFromDbFirst);
        }

        // POST: CourseController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var obj = _unitOfWork.Course.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Course.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Course deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
