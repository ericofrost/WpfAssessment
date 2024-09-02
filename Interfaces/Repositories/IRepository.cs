using Entity.Models;

namespace Interfaces.Repositories
{
    /// <summary>
    /// Generic repository interface
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> where TEntity : BaseObject
    {
        /// <summary>
        /// Returns all entities
        /// </summary>
        /// <returns></returns>
        IAsyncEnumerable<TEntity> GetAllAsync();

        /// <summary>
        /// Returns entities by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ValueTask<TEntity> GetByIdAsync(Guid? id = null);

        /// <summary>
        /// Returns entities by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ValueTask<TEntity> CreateAsync(TEntity data);

        /// <summary>
        /// Update the entity object in the database
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        ValueTask<TEntity> UpdateAsync(TEntity data);

        /// <summary>
        /// Deletes the object from the database
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        ValueTask<TEntity> DeleteAsync(TEntity data);
    }
}
