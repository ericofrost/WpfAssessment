using Entity.BaseEntities;
using Entity.Models;

namespace Entity.Services.TrackingService
{
    /// <summary>
    /// Output DTO for the GetActiveSensors method
    /// </summary>
    public class GetActiveSensorsOutputDto : BaseOutputDto<IAsyncEnumerable<Sensor>>
    {
        //Reserved for future information if needed
    }
}
