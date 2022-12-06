using StudentProjectAttempt6.Models;

namespace StudentProjectAttempt6.Repository.IRepository
{
    public interface IStudentRepository: IRepository<Student>
    {
        new void Update(Student student);
    }
}
