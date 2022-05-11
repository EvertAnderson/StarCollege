using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StarCollege.DataAccess.Repository.IRepository;
using StarCollege.Models;
using StarCollege.Models.ViewModels;

namespace StarCollege.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ClassroomController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClassroomController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: ClassroomController
        public IActionResult Index()
        {
            var objClassroomList = _unitOfWork.Classroom.GetAll(includeProperties: "Course,Teacher");

            return View(objClassroomList);
        }

        // GET: ClassroomController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: ClassroomController/Create
        public IActionResult CreateUpdate(int? id)
        {
            ClassroomVM obj = new()
            {
                Classroom = new(),
                CourseList = _unitOfWork.Course.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                TeacherList = _unitOfWork.Teacher.GetAll().Select(i => new SelectListItem
                {
                    Text = i.FullName,
                    Value = i.Id.ToString()
                })
            };
            
            if (id == null || id == 0)
            {
                return View(obj);
            }
            else
            {
                obj.Classroom = _unitOfWork.Classroom.GetFirstOrDefault(x => x.Id == id);
                return View(obj);
            }                                                                                                                                                                                                                 
        }

        // POST: ClassroomController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateUpdate(ClassroomVM obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Classroom.Id == 0)
                {
                    _unitOfWork.Classroom.Add(obj.Classroom);
                }
                else
                {
                    _unitOfWork.Classroom.Update(obj.Classroom);
                }
                _unitOfWork.Save();
                TempData["success"] = "Classroom created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET: ClassroomController/Delete/5
        public IActionResult Delete(int? id)
        {
            ClassroomVM objFromDbFirst = new()
            {
                Classroom = new(),
                CourseList = _unitOfWork.Course.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                TeacherList = _unitOfWork.Teacher.GetAll().Select(i => new SelectListItem
                {
                    Text = i.FullName,
                    Value = i.Id.ToString()
                })
            };

            if (id == null || id == 0)
            {
                return NotFound();
            }

            //var objFromDbFirst = _unitOfWork.Classroom.GetFirstOrDefault(u => u.Id == id);
            objFromDbFirst.Classroom = _unitOfWork.Classroom.GetFirstOrDefault(u => u.Id == id);

            if (objFromDbFirst == null)
            {
                return NotFound();
            }

            return View(objFromDbFirst);
        }

        // POST: ClassroomController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var obj = _unitOfWork.Classroom.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Classroom.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Classroom deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
