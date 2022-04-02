using System;
using Ploomes.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Ploomes.Business.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {

        Task Add(TEntity entity);

        Task<TEntity> FindById(Guid id);

        Task<List<TEntity>> FindAll();

        Task Update(TEntity entity);

        Task Remove(Guid id);

        Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate);

        Task<int> SaveChanges();

    }
}
