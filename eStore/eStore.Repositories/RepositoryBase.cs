using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using eStore.Repositories.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace eStore.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected eVoucherContext RepositoryContext { get; set; }

        public RepositoryBase(eVoucherContext repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
        }

        public IEnumerable<T> FindAll()
        {
            return this.RepositoryContext.Set<T>();
        }

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.RepositoryContext.Set<T>().Where(expression);
        }

        public void Create(T entity, bool flush = true)
        {
            this.RepositoryContext.Set<T>().Add(entity);
            if (flush) this.Save();
        }

        public void Update(T entity, bool flush = true)
        {
            this.RepositoryContext.Set<T>().Update(entity);
            if (flush) this.Save();
        }

        public void Delete(T entity, bool flush = true)
        {
            this.RepositoryContext.Set<T>().Remove(entity);
            if (flush) this.Save();
        }

        public void Save()
        {
            this.RepositoryContext.SaveChanges();
        }

        public async Task CreateAsync(T entity, bool flush = true)
        {
             this.RepositoryContext.Set<T>().Add(entity);
            if (flush) await this.SaveAsync();
        }      

        public async Task UpdateAsync(T entity, bool flush = true)
        {
            this.RepositoryContext.Set<T>().Update(entity);
            if (flush) await this.SaveAsync();
        }

        public async Task DeleteAsync(T entity, bool flush = true)
        {
            this.RepositoryContext.Set<T>().Remove(entity);
            if (flush) await this.SaveAsync();
        }

        public async Task SaveAsync()
        {
            await this.RepositoryContext.SaveChangesAsync();
        }


    }
}
