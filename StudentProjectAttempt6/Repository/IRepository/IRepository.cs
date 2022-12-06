using System.Linq.Expressions;

namespace StudentProjectAttempt6.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        T GetFirstOrDefault(Expression<Func<T, bool>> filter);

        IEnumerable<T> GetAll();

        void Add(T item);
        void Update(T item);
        void Remove(T item);
        void RemoveRange(IEnumerable<T> items);
    }
}
