using StudentProjectAttempt6.Data;
using Microsoft.AspNetCore.Mvc;
using StudentProjectAttempt6.Models;
using StudentProjectAttempt6.Repository.IRepository;


namespace EnrollmentProjectAttempt6.Controllers
{
    public class EnrollmentController: Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public EnrollmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Enrollment> objEnrollmentList = _unitOfWork.Enrollment.GetAll();
            return View(objEnrollmentList);
        }
        public IActionResult Create()
        {
            ViewData["Students"] = _unitOfWork.Student.GetAll();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Enrollment obj)
        {
            if (obj.Grade > 4 || obj.Grade < 0) // Custom Validation
            {
                ModelState.AddModelError("CustomError", "Enrollments GPA must be within 0 and 4.");
                // ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }

            if (ModelState.IsValid)
            {
                //_db.Enrollments.Add(obj);
                //_db.SaveChanges();
                //_db.Add(obj);
                //_db.Save();
                _unitOfWork.Enrollment.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Enrollment added successfully";
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //Enrollment EnrollmentFromDb = _db.GetFirstOrDefault(x => x.Id == id);
            Enrollment enrollmentFromDb = _unitOfWork.Enrollment.GetFirstOrDefault(x => x.Id == id);

            if (enrollmentFromDb == null)
            {
                return NotFound();
            }
            ViewData["Students"] = _unitOfWork.Student.GetAll();
            return View(enrollmentFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Enrollment enrollment)
        {
            if (enrollment.Grade > 4 || enrollment.Grade < 0)
            {
                ModelState.AddModelError("CustomError", "Enrollments GPA must be within 0 and 4.");
            }
            if (ModelState.IsValid)
            {
                //_db.Enrollments.Update(Enrollment); 
                //_db.SaveChanges();
                //_db.Update(Enrollment); //for repo
                //_db.Save();
                _unitOfWork.Enrollment.Update(enrollment);
                _unitOfWork.Save();

                TempData["success"] = "Enrollment Modified successfully";
                return RedirectToAction("Index");
            }
            return View(enrollment);
        }
        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            //Enrollment EnrollmentFromDb = _db.GetFirstOrDefault(x => x.Id == id);
            Enrollment enrollmentFromDb = _unitOfWork.Enrollment.GetFirstOrDefault(x => x.Id == id);
            if (enrollmentFromDb == null)
            {
                return NotFound();
            }
            return View(enrollmentFromDb);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //Enrollment Enrollment = _db.GetFirstOrDefault(x => x.Id == id);
            Enrollment enrollment = _unitOfWork.Enrollment.GetFirstOrDefault(x => x.Id == id);
            if (enrollment == null)
            {
                return NotFound();
            }
            //_db.Remove(Enrollment);
            //_db.Save();
            _unitOfWork.Enrollment.Remove(enrollment);
            _unitOfWork.Save();

            TempData["success"] = "Enrollment Deleted successfully";
            return RedirectToAction("Index");
        }
    }
}