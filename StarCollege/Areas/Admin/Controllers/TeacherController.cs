using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarCollege.DataAccess.Repository.IRepository;
using StarCollege.Models;

namespace StarCollege.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeacherController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TeacherController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: TeacherController
        public IActionResult Index()
        {
            IEnumerable<Teacher> objTeacherList = _unitOfWork.Teacher.GetAll();
            return View(objTeacherList);
        }

        // GET: TeacherController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: TeacherController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TeacherController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Teacher obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Teacher.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Teacher created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET: TeacherController/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var objFromDbFirst = _unitOfWork.Teacher.GetFirstOrDefault(u => u.Id == id);

            if (objFromDbFirst == null) return NotFound();

            return View(objFromDbFirst);
        }

        // POST: TeacherController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Teacher obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Teacher.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Teacher updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET: TeacherController/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var objFromDbFirst = _unitOfWork.Teacher.GetFirstOrDefault(u => u.Id == id);

            if (objFromDbFirst == null)
            {
                return NotFound();
            }

            return View(objFromDbFirst);
        }

        // POST: TeacherController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var obj = _unitOfWork.Teacher.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Teacher.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Teacher deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
