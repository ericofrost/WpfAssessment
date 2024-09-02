using DataAccess.Contexts;
using Entity.Models;
using Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataAccess.Repositories
{
    /// <summary>
    /// /// <inheritdoc cref="IRepository{TEntity}"/>
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseObject
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        /// <summary>
        /// Default parameter constructor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="logger"></param>
        public Repository(ApplicationDbContext context)
        {
            this._context = context;
            this._dbSet = this._context.Set<TEntity>();
        }

        /// <inheritdoc/>
        public virtual IAsyncEnumerable<TEntity> GetAllAsync()
        {
            try
            {
                return this._dbSet.AsAsyncEnumerable();
            }
            catch (Exception ex)
            {
                this.LogError(ex, MethodBase.GetCurrentMethod().Name);
            }

            return null;
        }

        /// <inheritdoc/>
        public virtual async ValueTask<TEntity> CreateAsync(TEntity data)
        {
            try
            {
                var result = await this._dbSet.AddAsync(data);

                if (result.State == EntityState.Added)
                {
                    await this._context.SaveChangesAsync();
                }
                else
                {
                    data = null;
                }
            }
            catch (Exception ex)
            {
                this.LogError(ex, MethodBase.GetCurrentMethod().Name);

                data = null;
            }

            return data;
        }

        /// <inheritdoc/>
        public virtual async ValueTask<TEntity> GetByIdAsync(Guid? id = null)
        {
            try
            {
                return id.HasValue ? await this._dbSet.FirstOrDefaultAsync(x => x.Id == id.Value) : await this._dbSet.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                this.LogError(ex, MethodBase.GetCurrentMethod().Name);

                return null;
            }
        }

        /// <inheritdoc/>
        public virtual async ValueTask<TEntity> UpdateAsync(TEntity obj)
        {
            try
            {
                var local = await this.GetByIdAsync(obj.Id);

                if (local != null)
                {
                    local = obj;

                    this._dbSet.Update(local);
                }
                else
                {
                    return null;
                }

                await this._context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                this.LogError(ex, MethodBase.GetCurrentMethod().Name);

                obj = null;
            }

            return obj;
        }

        /// <inheritdoc/>
        public virtual async ValueTask<TEntity> DeleteAsync(TEntity obj)
        {
            try
            {
                this._dbSet.Remove(obj);

                await this._context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                this.LogError(ex, MethodBase.GetCurrentMethod().Name);

                obj = null;
            }

            return obj;
        }

        /// <summary>
        /// Logs errors
        /// </summary>
        /// <param name="ex"></param>
        protected virtual void LogError(Exception ex, string message)
        {
            //future implementation
        }
    }
}
