using Blog.Context;
using Blog.Models;
using Blog.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blog.Repository.Base
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : BaseModel
    {
        public readonly DbSet<TEntity> DbSet;
        public readonly BlogDbContext Context;

        public RepositoryBase(BlogDbContext context)
        {
            DbSet = context.Set<TEntity>();
            Context = context;
        }

        public async Task AddAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public async Task<IList<TEntity>> Get() =>
            await DbSet.ToListAsync();

        public async Task<TEntity?> GetPerId(Guid id) => await DbSet.FindAsync(id);

        public async Task Remove(Guid id)
        {
            var entityToRemove = await GetPerId(id);
            if (entityToRemove != null)
            {
                DbSet.Remove(entityToRemove);
                await Context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(TEntity entity)
        {
            DbSet.Update(entity);
            await Context.SaveChangesAsync();
        }
    }
}
