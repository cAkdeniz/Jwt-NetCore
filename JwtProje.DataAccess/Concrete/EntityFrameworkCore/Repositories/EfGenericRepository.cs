using JwtProje.DataAccess.Concrete.EntityFrameworkCore.Context;
using JwtProje.DataAccess.Interfaces;
using JwtProje.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JwtProje.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfGenericRepository<TEntity> : IGenericDal<TEntity>
        where TEntity : class, ITable, new()
    {
        public async Task Add(TEntity entity)
        {
            using (var context = new JwtProjeDB())
            {
                context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                await context.SaveChangesAsync();
            }
        }

        public async Task Delete(TEntity entity)
        {
            using (var context = new JwtProjeDB())
            {
                context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<TEntity>> GetAll()
        {
            using (var context = new JwtProjeDB())
            {
                return await context.Set<TEntity>().ToListAsync();
            }
        }

        public async Task<List<TEntity>> GetAllByFilter(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new JwtProjeDB())
            {
                return await context.Set<TEntity>().Where(filter).ToListAsync();
            }
        }

        public async Task<TEntity> GetByFilter(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new JwtProjeDB())
            {
                return await context.Set<TEntity>().FirstOrDefaultAsync(filter);
            }
        }

        public async Task<TEntity> GetById(int id)
        {
            using (var context = new JwtProjeDB())
            {
                return await context.Set<TEntity>().FindAsync(id);
            }
        }

        public async Task Update(TEntity entity)
        {
            using (var context = new JwtProjeDB())
            {
                context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }
    }
}
