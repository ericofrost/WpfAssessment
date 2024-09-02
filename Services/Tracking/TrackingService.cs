using Entity.Services.TrackingService;
using Interfaces.Repositories;
using Interfaces.Services;

namespace Services.Tracking
{
    /// <inheritdoc/>
    public partial class TrackingService : ITrackingService
    {
        private readonly ISensorsRepository sensorsRepository;

        /// <summary>
        /// Default parameter constructor
        /// </summary>
        /// <param name="sensorsRepository"></param>
        public TrackingService(ISensorsRepository sensorsRepository)
        {
            this.sensorsRepository = sensorsRepository;
        }

        /// <inheritdoc/>
        public GetActiveSensorsOutputDto GetActiveSensorsAsync()
        {
            var output = new GetActiveSensorsOutputDto();

            output.Result = this.sensorsRepository.GetAllAsync();

            return output;
        }

        /// <inheritdoc/>
        public async ValueTask<GetSoldierInfoOutputDto> GetSoldierInfoAsync(Guid sensorId)
        {
            var output = new GetSoldierInfoOutputDto();

            if (IsSensorIdValid(sensorId, output))
            {
                var sensor = await this.sensorsRepository.GetSoldierBySensorIdAsync(sensorId);

                output.Result = this.MapSoldierDto(sensor);
            }

            return output;
        }

        /// <inheritdoc/>
        public async ValueTask<TrackSoldierMovimentOutputDto> TrackSoldierMovimentAsync(Guid sensorId)
        {
            var output = new TrackSoldierMovimentOutputDto();

            if (!IsSensorIdValid(sensorId, output))
            {
                await Task.Run(() =>
                {

                    var positions = this.sensorsRepository.GetPositionsBySensorId(sensorId);

                    output.Result = new Entity.Services.SoldierMovementHistoryDto
                    {
                        Positions = positions
                    };

                });
            }

            return output;
        }
    }
}
