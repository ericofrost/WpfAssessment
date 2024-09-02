using Entity.BaseEntities;
using Entity.Models;
using Entity.Services;

namespace Services.Tracking
{
    /// <summary>
    /// Partial class to store the private methods of the TrackingService
    /// </summary>
    public partial class TrackingService
    {
        private bool IsSensorIdValid(Guid sensorId, object outputDto)
        {
            if (sensorId == Guid.Empty)
            {
                var type = outputDto.GetType();

                outputDto ??= Activator.CreateInstance(type);

                type.GetProperty("ErrorList").SetValue(outputDto, new List<Error> { new Error { Code = "1", Message = "The sensor Id is invalid" } });

                return false;
            }

            return true;
        }

        private SoldierDto MapSoldierDto(Soldier soldier)
        {
            return new SoldierDto
            {
                Name = soldier?.Name,
                Country = soldier?.Country?.Name,
                Id = soldier?.Id ?? Guid.Empty,
                Rank = soldier?.Rank,
                TrainningInfo = soldier?.TrainningInfo
            };
        }
    }
}
