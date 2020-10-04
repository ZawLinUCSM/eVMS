using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace eStore.Repositories.Interfaces
{
    public interface IRepositoryBase<T>
    {
        IEnumerable<T> FindAll();
        IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression);
        void Create(T entity, bool flush = true);
        void Update(T entity, bool flush = true);
        void Delete(T entity, bool flush = true);
        void Save();

        Task CreateAsync(T entity, bool flush = true);      
        Task UpdateAsync(T entity, bool flush = true);
        Task DeleteAsync(T entity, bool flush = true);
        Task SaveAsync();
    }
}
