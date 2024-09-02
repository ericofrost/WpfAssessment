using Entity.Models;

namespace Interfaces.Repositories
{
    /// <summary>
    /// Sensor repository interface
    /// </summary>
    public interface ISensorsRepository : IRepository<Sensor>
    {
        //Reserved for future custom sensor methods
        IAsyncEnumerable<Position> GetPositionsBySensorId(Guid id);

        /// <summary>
        /// Returns a soldier based on a sensor identifier
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ValueTask<Soldier> GetSoldierBySensorIdAsync(Guid? id = null);
    }
}
