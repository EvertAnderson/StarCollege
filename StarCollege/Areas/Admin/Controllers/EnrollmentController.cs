using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StarCollege.DataAccess.Repository.IRepository;
using StarCollege.Models;
using StarCollege.Models.ViewModels;

namespace StarCollege.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EnrollmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public EnrollmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: EnrollmentController
        public IActionResult Index()
        {
            var objEnrollmentList = _unitOfWork.Enrollment.GetAll(includeProperties: "Student,Classroom");

            return View(objEnrollmentList);
        }

        // GET: EnrollmentController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: EnrollmentController/Create
        public IActionResult CreateUpdate(int? id)
        {
            EnrollmentVM obj = new()
            {
                Enrollment = new(),
                StudentList = _unitOfWork.Student.GetAll().Select(i => new SelectListItem
                {
                    Text = i.FullName,
                    Value = i.Id.ToString()
                }),
                ClassroomList = _unitOfWork.Classroom.GetAll().Select(i => new SelectListItem
                {
                    Text = i.ClassCode,
                    Value = i.Id.ToString()
                })
            };

            if (id == null || id == 0)
            {
                return View(obj);
            }
            else
            {
                obj.Enrollment = _unitOfWork.Enrollment.GetFirstOrDefault(x => x.Id == id);
                return View(obj);
            }                                                                                                                                                                                                                 
        }

        // POST: EnrollmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateUpdate(EnrollmentVM obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Enrollment.Id == 0)
                {
                    _unitOfWork.Enrollment.Add(obj.Enrollment);
                }
                else
                {
                    _unitOfWork.Enrollment.Update(obj.Enrollment);
                }
                _unitOfWork.Save();
                TempData["success"] = "Enrollment created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET: EnrollmentController/Delete/5
        public IActionResult Delete(int? id)
        {
            EnrollmentVM objFromDbFirst = new()
            {
                Enrollment = new(),
                StudentList = _unitOfWork.Student.GetAll().Select(i => new SelectListItem
                {
                    Text = i.FullName,
                    Value = i.Id.ToString()
                }),
                ClassroomList = _unitOfWork.Classroom.GetAll().Select(i => new SelectListItem
                {
                    Text = i.ClassCode,
                    Value = i.Id.ToString()
                })
            };

            if (id == null || id == 0)
            {
                return NotFound();
            }

            objFromDbFirst.Enrollment = _unitOfWork.Enrollment.GetFirstOrDefault(u => u.Id == id);

            if (objFromDbFirst == null)
            {
                return NotFound();
            }

            return View(objFromDbFirst);
        }

        // POST: EnrollmentController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var obj = _unitOfWork.Enrollment.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Enrollment.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Enrollment deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
