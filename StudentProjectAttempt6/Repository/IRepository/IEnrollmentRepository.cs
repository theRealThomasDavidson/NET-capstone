using StudentProjectAttempt6.Models;

namespace StudentProjectAttempt6.Repository.IRepository
{
    public interface IEnrollmentRepository: IRepository<Enrollment>
    {
        new void Update(Enrollment enrollment);
    }
}
