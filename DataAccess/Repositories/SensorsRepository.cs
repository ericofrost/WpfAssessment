using DataAccess.Contexts;
using Entity.Models;
using Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataAccess.Repositories
{
    public class SensorsRepository : Repository<Sensor>, ISensorsRepository
    {
        public SensorsRepository(ApplicationDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Rerturns only the active sensors
        /// </summary>
        /// <returns></returns>
        public override async IAsyncEnumerable<Sensor> GetAllAsync()
        {
            await foreach (var sensor in this._dbSet.Include(x => x.Positions).AsAsyncEnumerable())
            {
                if (sensor?.Active ?? false)
                    yield return sensor;
            }
        }

        /// <summary>
        /// Retrieves information about a sensor by its identifier including the soldier it is assigned to
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async ValueTask<Soldier> GetSoldierBySensorIdAsync(Guid? id = null)
        {
            try
            {
                return await this._context.Soldiers.Include(s => s.Sensors).Include(x => x.Country).FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                this.LogError(ex, MethodBase.GetCurrentMethod().Name);

                return null;
            }
        }

        /// <summary>
        /// Rreturns all the positions of a sensor by its identifier
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IAsyncEnumerable<Position> GetPositionsBySensorId(Guid id)
        {
            try
            {
                return _context.Positions.Include(p => p.Sensor).Where(p => p.SensorId == id).AsAsyncEnumerable();
            }
            catch (Exception ex)
            {
                this.LogError(ex, MethodBase.GetCurrentMethod().Name);

                return null;
            }
        }
    }
}
