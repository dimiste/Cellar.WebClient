using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cellar.Data.Repositories
{
    public class EfRepository<T> where T : class
    {
        private readonly IBillsSystemContext context;

        public IDbSet<T> DbSet { get; set; }

        public EfRepository(IBillsSystemContext context)
        {
            this.context = context;
            this.DbSet = this.context.Set<T>();
        }

        public IQueryable<T> All {
            get {
                return this.context.Set<T>();
            }
        }

        public void Add(T entity)
        {
            DbEntityEntry entry = this.context.Entry(entity);

            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                this.context.Set<T>().Add(entity);
            }
        }

        public void Delete(T entity)
        {
            this.context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            DbEntityEntry entry = this.context.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                this.context.Set<T>().Attach(entity);
            }

            entry.State = EntityState.Modified;
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}
