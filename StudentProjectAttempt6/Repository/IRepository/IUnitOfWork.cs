namespace StudentProjectAttempt6.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IStudentRepository Student { get; }
        IEnrollmentRepository Enrollment { get; }
        void Save();
    }
}
