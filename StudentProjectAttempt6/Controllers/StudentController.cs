using StudentProjectAttempt6.Data;
using Microsoft.AspNetCore.Mvc;
using StudentProjectAttempt6.Models;
using StudentProjectAttempt6.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;

namespace StudentProjectAttempt6.Controllers
{
    [Authorize]
    public class StudentController: Controller
    {
        //private readonly ApplicationDbContext _db;
        //private readonly IStudentRepository _db;
        private readonly IUnitOfWork _unitOfWork;

        public StudentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        
        public IActionResult Index()
        {
            IEnumerable<Student> objStudentList = _unitOfWork.Student.GetAll();
            return View(objStudentList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student obj)
        {
            if (obj.Grade >4 || obj.Grade <0) // Custom Validation
            {
                ModelState.AddModelError("CustomError", "Students GPA must be within 0 and 4.");
                // ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }

            if (ModelState.IsValid)
            {
                //_db.Students.Add(obj);
                //_db.SaveChanges();
                //_db.Add(obj);
                //_db.Save();
                _unitOfWork.Student.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Student added successfully";
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

            //Student StudentFromDb = _db.GetFirstOrDefault(x => x.Id == id);
            Student StudentFromDb = _unitOfWork.Student.GetFirstOrDefault(x => x.Id == id);

            if (StudentFromDb == null)
            {
                return NotFound();
            }
            return View(StudentFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student student)
        {
            if (student.Grade >4 || student.Grade < 0)
            {
                ModelState.AddModelError("CustomError", "Students GPA must be within 0 and 4.");
            }
            if (ModelState.IsValid)
            {
                //_db.Students.Update(student); 
                //_db.SaveChanges();
                //_db.Update(student); //for repo
                //_db.Save();
                _unitOfWork.Student.Update(student);
                _unitOfWork.Save();

                TempData["success"] = "Student Modified successfully";
                return RedirectToAction("Index");
            }
            return View(student);
        }
        public IActionResult Delete(int? id)
        {
            if (id == 0|| id == null)
            {
                return NotFound();
            }
            //Student studentFromDb = _db.GetFirstOrDefault(x => x.Id == id);
            Student studentFromDb = _unitOfWork.Student.GetFirstOrDefault(x => x.Id == id);
            if (studentFromDb == null)
            {
                return NotFound();
            }
            return View(studentFromDb);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            if(id ==null || id == 0)
            {
                return NotFound();
            }
            //Student student = _db.GetFirstOrDefault(x => x.Id == id);
            Student student = _unitOfWork.Student.GetFirstOrDefault(x => x.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            //_db.Remove(student);
            //_db.Save();
            _unitOfWork.Student.Remove(student);
            _unitOfWork.Save();

            TempData["success"] = "Student Deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
