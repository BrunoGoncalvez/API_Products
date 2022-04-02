using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ploomes.Business.Interfaces;
using Ploomes.Business.Models;
using Ploomes.Data.Context;

namespace Ploomes.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {

        protected readonly DataDbContext _context;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(DataDbContext context)
        {
            _context = context;
            DbSet = context.Set<TEntity>();
        }

        public virtual async Task Add(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Remove(Guid id)
        {
            DbSet.Remove(new TEntity() { Id = id});
            await SaveChanges();
        }

        public virtual async Task Update(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

        public virtual async Task<List<TEntity>> FindAll()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task<TEntity> FindById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }      

        public virtual async Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

    }
}
