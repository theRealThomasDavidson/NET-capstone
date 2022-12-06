using StudentProjectAttempt6.Data;
using StudentProjectAttempt6.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace StudentProjectAttempt6.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> DbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.DbSet = _db.Set<T>();
        }
        void IRepository<T>.Add(T item)
        {
            DbSet.Add(item);
        }
        IEnumerable<T> IRepository<T>.GetAll()
        {
            IQueryable<T> query = this.DbSet;
            return query.ToList();
        }
        T IRepository<T>.GetFirstOrDefault(Expression<Func<T,bool>> filter)
        {
            IQueryable<T> query = this.DbSet;

            query = query.Where(filter);

            return query.FirstOrDefault();
        }
        void IRepository<T>.Update(T item)
        {
            DbSet.Update(item);
        }
        void IRepository<T>.Remove(T item)
        {
            DbSet.Remove(item);
        }

        public void RemoveRange(IEnumerable<T> items)
        {
            DbSet.RemoveRange(items);
        }
    }
}
