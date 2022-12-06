using StudentProjectAttempt6.Data;
using StudentProjectAttempt6.Models;
using StudentProjectAttempt6.Repository.IRepository;


namespace StudentProjectAttempt6.Repository
{
    public class StudentRepository: Repository<Student>, IStudentRepository
    {
        private ApplicationDbContext _db;

        public StudentRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }
        void IStudentRepository.Update(Student student)
        {
            _db.Students.Update(student);
        }
    }
}
