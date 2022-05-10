using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarCollege.DataAccess.Repository.IRepository;
using StarCollege.Models;

namespace StarCollege.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubjectController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SubjectController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: SubjectController
        public IActionResult Index()
        {
            IEnumerable<Subject> objSubjectList = _unitOfWork.Subject.GetAll();
            return View(objSubjectList);
        }

        // GET: SubjectController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: SubjectController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SubjectController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Subject obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Subject.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Subject created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET: SubjectController/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var objFromDbFirst = _unitOfWork.Subject.GetFirstOrDefault(u => u.Id == id);

            if (objFromDbFirst == null) return NotFound();

            return View(objFromDbFirst);
        }

        // POST: SubjectController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Subject obj)
        {
            var errors = ModelState
            .Where(x => x.Value.Errors.Count > 0)
            .Select(x => new { x.Key, x.Value.Errors })
            .ToArray();
            if (ModelState.IsValid)
            {
                _unitOfWork.Subject.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Subject updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET: SubjectController/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var objFromDbFirst = _unitOfWork.Subject.GetFirstOrDefault(u => u.Id == id);

            if (objFromDbFirst == null)
            {
                return NotFound();
            }

            return View(objFromDbFirst);
        }

        // POST: SubjectController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var obj = _unitOfWork.Subject.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Subject.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Subject deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
