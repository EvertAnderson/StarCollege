using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarCollege.DataAccess.Repository.IRepository;
using StarCollege.Models;

namespace StarCollege.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StudentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: StudentController
        public IActionResult Index()
        {
            IEnumerable<Student> objStudentList = _unitOfWork.Student.GetAll();
            return View(objStudentList);
        }

        // GET: StudentController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: StudentController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Student.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Student created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET: StudentController/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var objFromDbFirst = _unitOfWork.Student.GetFirstOrDefault(u => u.Id == id);

            if (objFromDbFirst == null) return NotFound();

            return View(objFromDbFirst);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Student.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Student updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET: StudentController/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var objFromDbFirst = _unitOfWork.Student.GetFirstOrDefault(u => u.Id == id);

            if (objFromDbFirst == null)
            {
                return NotFound();
            }

            return View(objFromDbFirst);
        }

        // POST: StudentController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var obj = _unitOfWork.Student.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Student.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Student deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
