using StudentProjectAttempt6.Data;
using StudentProjectAttempt6.Repository.IRepository;

namespace StudentProjectAttempt6.Repository
{
    public class UnitOfWork: IUnitOfWork
    {
        private ApplicationDbContext _db;
        public IStudentRepository Student { get; private set; }
        public IEnrollmentRepository Enrollment { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Student = new StudentRepository(_db);
            Enrollment = new EnrollmentRepository(_db);
        }

        void IUnitOfWork.Save()
        {
            _db.SaveChanges();
        }
    }
}
