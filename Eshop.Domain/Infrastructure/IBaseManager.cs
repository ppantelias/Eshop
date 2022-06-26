using Eshop.Domain.Enums;
using Eshop.Domain.Models;

namespace Eshop.Domain.Infrastructure
{
    public interface IBaseManager<TEntity> where TEntity : BaseEntity
    {
        /// <summary>
        /// Counts all entities asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
        /// <returns>the number <see cref="int"/> of total entities.</returns>
        Task<int> CountAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Counts all entities synchronously.
        /// </summary>
        /// <returns>the number <see cref="int"/> of total entities.</returns>
        int Count();

        /// <summary>
        /// Returns all entities asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
        /// <returns><see cref="IQueryable{TEntity}"/></returns>
        IQueryable<TEntity> GetAllAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns all entities synchronously.
        /// </summary>
        /// <returns><see cref="IQueryable{TEntity}"/></returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// Returns the entity with the specific id asynchronously.
        /// </summary>
        /// <param name="id">The <see cref="Guid"/> id to search</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns><see cref="Task{TEntity}"/></returns>
        Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns the entity with the specific id synchronously.
        /// </summary>
        /// <param name="id">The <see cref="Guid"/> id to search</param>
        /// <returns><see cref="TEntity"/></returns>
        TEntity GetById(Guid id);

        /// <summary>
        /// Creates an entity asynchronously.
        /// </summary>
        /// <param name="entity">The <see cref="TEntity"/> to create.</param>
        /// <param name="userCreatedById">The <see cref="Guid"/> id of the user that created this entity.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
        /// <returns><see cref="Task{int}"/>.</returns>
        Task<int> CreateAsync(TEntity entity, Guid userCreatedById, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates an entity synchronously.
        /// </summary>
        /// <param name="entity">The <see cref="TEntity"/> to create.</param>
        /// <param name="userCreatedById">The <see cref="Guid"/> id of the user that created this entity.</param>
        /// <returns><see cref="int"/>.</returns>
        int Create(TEntity entity, Guid userCreatedById);

        /// <summary>
        /// Updates the existing entity asynchronously.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="userUpdatedById">The <see cref="Guid"/> id of the user that last updated this entity.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
        /// <returns></returns>
        Task UpdateAsync(TEntity entity, Guid userUpdatedById, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates the existing entity synchronously.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="userUpdatedById">The <see cref="Guid"/> id of the user that last updated this entity.</param>
        /// <returns></returns>
        void Update(TEntity entity, Guid userUpdatedById);

        /// <summary>
        /// Fake Deletes entity with the given id asynchronously.
        /// Actually it updates the deletion fields of the entity
        /// <see cref="TEntity.UserDeletedById"/>, <see cref="TEntity.DateDeleted"/>, <see cref="TEntity.EntityState"/>.
        /// </summary>
        /// <param name="id">The <see cref="Guid"/> id of the user that deleted this entity.</param>
        /// <param name="userDeletedById"><see cref=""/></param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
        /// <returns></returns>
        Task DeleteAsync(Guid id, Guid userDeletedById, CancellationToken cancellationToken = default);

        /// <summary>
        /// Fake Deletes entity with the given id synchronously.
        /// Actually it updates the deletion fields of the entity
        /// <see cref="TEntity.UserDeletedById"/>, <see cref="TEntity.DateDeleted"/>, <see cref="TEntity.EntityState"/>.
        /// </summary>
        /// <param name="id">The <see cref="Guid"/> id of the user that deleted this entity.</param>
        /// <param name="userDeletedById"><see cref=""/></param>
        /// <returns></returns>
        void Delete(Guid id, Guid userDeletedById);

        /// <summary>
        /// Changes the entity state asynchronously.
        /// </summary>
        /// <param name="id">The <see cref="Guid"/> id of the entity to search for.</param>
        /// <param name="entityState">The <see cref="EntityState"/> value to update.</param>
        /// <param name="userId">The <see cref="Guid"/> id of the user that performs the action.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
        /// <returns><see cref="Task{true}"/> if entity state changed correctly or <see cref="Task{false}"/> if the entity does not exist.</returns>
        Task<bool> ChangeEntityStateAsync(Guid id, EntityState entityState, Guid userId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Changes the entity state synchronously.
        /// </summary>
        /// <param name="id">The <see cref="Guid"/> id of the entity to search for.</param>
        /// <param name="entityState">The <see cref="EntityState"/> value to update.</param>
        /// <param name="userId">The <see cref="Guid"/> id of the user that performs the action.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
        /// <returns><see cref="true"/> if entity state changed correctly or <see cref="false"/> if the entity does not exist.</returns>
        bool ChangeEntityState(Guid id, EntityState entityState, Guid userId);
    }
}