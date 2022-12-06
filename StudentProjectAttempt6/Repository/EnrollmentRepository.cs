using StudentProjectAttempt6.Data;
using StudentProjectAttempt6.Models;
using StudentProjectAttempt6.Repository.IRepository;


namespace StudentProjectAttempt6.Repository
{
    public class EnrollmentRepository: Repository<Enrollment>, IEnrollmentRepository
    {
        private ApplicationDbContext _db;

        public EnrollmentRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        void IEnrollmentRepository.Update(Enrollment enrollment)
        {
            _db.Enrollments.Update(enrollment);
        }
    }
}
