using Entity.Services.TrackingService;

namespace Interfaces.Services
{
    /// <summary>
    /// Service used to track soldiers based on their sensors.
    /// </summary>
    public interface ITrackingService
    {
        /// <summary>
        /// Returns the active sensors
        /// </summary>
        /// <returns></returns>
        GetActiveSensorsOutputDto GetActiveSensorsAsync();

        /// <summary>
        /// Retrieves Soldier Information based on the Id
        /// </summary>
        /// <param name="soldierId"></param>
        /// <returns></returns>
        ValueTask<GetSoldierInfoOutputDto> GetSoldierInfoAsync(Guid soldierId);

        /// <summary>
        /// Tracks the soldier moviment history based on the sensor id 
        /// </summary>
        /// <param name="sensorId"></param>
        /// <returns></returns>
        ValueTask<TrackSoldierMovimentOutputDto> TrackSoldierMovimentAsync(Guid sensorId);
    }
}
