using System.Data.Entity;
using System.Linq;

namespace Cellar.Data.Repositories
{
    public interface IEfRepository<T> where T : class
    {
        IQueryable<T> All { get; }
        IDbSet<T> DbSet { get; set; }

        void Add(T entity);
        void Delete(T entity);
        void SaveChanges();
        void Update(T entity);
    }
}