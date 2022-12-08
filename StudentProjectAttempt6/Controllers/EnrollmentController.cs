using StudentProjectAttempt6.Data;
using StudentProjectAttempt6.Models;
using StudentProjectAttempt6.Models.ViewModels;
using StudentProjectAttempt6.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            foreach(Enrollment objEnrollment in objEnrollmentList)
            {
                objEnrollment.Student = _unitOfWork.Student.GetFirstOrDefault(i => i.Id == objEnrollment.StudentId);
            }
            return View(objEnrollmentList);
        }
        public IActionResult Create()
        {
            EnrollmentViewModel modelVM = new()
            {
                Enrollment = new(),

                StudentsList = _unitOfWork.Student.GetAll().Select(i =>
                    new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    }
                ),

            };
            //ViewBag.StudentsList = StudentsList;
            
            return View(modelVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EnrollmentViewModel obj)
        {
            Enrollment enroll = obj.Enrollment;
            if (enroll.Grade > 4 || enroll.Grade < 0) // Custom Validation
            {
                ModelState.AddModelError("CustomError", "Enrollments GPA must be within 0 and 4.");
                // ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }
            //_db.Enrollments.Add(obj);
            //_db.SaveChanges();
            //_db.Add(obj);
            //_db.Save();
            _unitOfWork.Enrollment.Add(enroll);
            _unitOfWork.Save();
            TempData["success"] = "Enrollment added successfully";
            return RedirectToAction("Index");
            
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
            enrollmentFromDb.Id = (int)id;
            EnrollmentViewModel modelVM = new()
            {
                Enrollment = enrollmentFromDb,

                StudentsList = _unitOfWork.Student.GetAll().Select(i =>
                    new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    }
                ),

            };
            return View(modelVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, EnrollmentViewModel enrollmentVM)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Enrollment enrollment = enrollmentVM.Enrollment;
            enrollment.Id = (int)id;
            if (enrollment.Grade > 4 || enrollment.Grade < 0)
            {
                ModelState.AddModelError("CustomError", "Enrollments GPA must be within 0 and 4.");
            }
            //_db.Enrollments.Update(Enrollment); 
            //_db.SaveChanges();
            //_db.Update(Enrollment); //for repo
            //_db.Save();
            _unitOfWork.Enrollment.Update(enrollment);
            _unitOfWork.Save();

            TempData["success"] = "Enrollment Modified successfully";
            return RedirectToAction("Index");
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
            enrollmentFromDb.Student = _unitOfWork.Student.GetFirstOrDefault(s=> s.Id == enrollmentFromDb.StudentId);
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