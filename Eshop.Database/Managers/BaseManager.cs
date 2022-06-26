using Eshop.Database.ApplicationDb;
using Eshop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using BaseEntityState = Eshop.Domain.Enums.EntityState;

namespace Eshop.Domain.Infrastructure
{
    public class BaseManager<TEntity> : IBaseManager<TEntity> where TEntity : BaseEntity
    {
        private readonly ApplicationDbContext _ctx;
        private readonly DbSet<TEntity> _dbSet;

        public BaseManager(ApplicationDbContext context)
        {
            _ctx = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = context.Set<TEntity>();
        }

        public Task<int> CountAsync(CancellationToken cancellationToken = default)
            => _dbSet.CountAsync(cancellationToken);

        public int Count()
            => _dbSet.Count();

        public IQueryable<TEntity> GetAllAsync(CancellationToken cancellationToken = default)
            => _dbSet;

        public IQueryable<TEntity> GetAll()
            => _dbSet;

        public async Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
            => await _dbSet.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

        public TEntity GetById(Guid id)
            => _dbSet.FirstOrDefault(e => e.Id == id);

        public async Task<int> CreateAsync(TEntity entity, Guid userCreatedById, CancellationToken cancellationToken = default)
        {
            entity.UserCreatedById = userCreatedById;
            entity.EntityState = BaseEntityState.Active;

            await _dbSet.AddAsync(entity, cancellationToken);

            return await _ctx.SaveChangesAsync(cancellationToken);
        }

        public int Create(TEntity entity, Guid userCreatedById)
        {
            entity.UserCreatedById = userCreatedById;
            entity.EntityState = BaseEntityState.Active;

            _dbSet.Add(entity);

            return _ctx.SaveChanges();
        }

        public async Task UpdateAsync(TEntity entity, Guid userUpdatedById, CancellationToken cancellationToken = default)
        {
            entity.UserUpdatedById = userUpdatedById;

            _dbSet.Update(entity);

            await _ctx.SaveChangesAsync(cancellationToken);
        }

        public void Update(TEntity entity, Guid userUpdatedById)
        {
            entity.UserUpdatedById = userUpdatedById;

            _dbSet.Update(entity);

            _ctx.SaveChanges();
        }

        public async Task DeleteAsync(Guid id, Guid userDeletedById, CancellationToken cancellationToken = default)
        {
            var entity = await GetByIdAsync(id, cancellationToken);
            
            if (!entity.Equals(default))
            {
                entity.UserDeletedById = userDeletedById;
                entity.EntityState = BaseEntityState.Deleted;

                _dbSet.Update(entity);

                await _ctx.SaveChangesAsync(cancellationToken);
            }
        }

        public void Delete(Guid id, Guid userDeletedById)
        {
            var entity = GetById(id);

            if (!entity.Equals(default))
            {
                entity.UserDeletedById = userDeletedById;
                entity.EntityState = BaseEntityState.Deleted;

                _dbSet.Update(entity);

                _ctx.SaveChanges();
            }
        }

        public async Task<bool> ChangeEntityStateAsync(Guid id, BaseEntityState entityState, Guid userId, CancellationToken cancellationToken = default)
        {
            switch (entityState)
            {
                case BaseEntityState.Deleted:
                    await DeleteAsync(id, userId, cancellationToken);
                    return true;
                default:
                    var entity = await GetByIdAsync(id, cancellationToken);

                    if (entity.Equals(default))
                        return false;

                    entity.EntityState = entityState;
                    await UpdateAsync(entity, userId, cancellationToken);
                    return true;
            }
        }

        public bool ChangeEntityState(Guid id, BaseEntityState entityState, Guid userId)
        {
            switch (entityState)
            {
                case BaseEntityState.Deleted:
                    Delete(id, userId);
                    return true;
                default:
                    var entity = GetById(id);

                    if (entity.Equals(default))
                        return false;

                    entity.EntityState = entityState;
                    Update(entity, userId);
                    return true;
            }
        }
    }
}