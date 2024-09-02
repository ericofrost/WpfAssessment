using Entity.Models;

namespace Entity.Services
{
    /// <summary>
    /// The soldier moviment history data transfer object
    /// </summary>
    public class SoldierMovementHistoryDto
    {
        /// <summary>
        /// Positions in time
        /// </summary>
        public IAsyncEnumerable<Position> Positions { get; set; }
    }
}
