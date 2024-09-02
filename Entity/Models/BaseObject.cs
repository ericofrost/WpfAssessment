using Entity.Converters;
using Newtonsoft.Json;

namespace Entity.Models
{
    /// <summary>
    /// Base database entity
    /// </summary>
    public class BaseObject
    {
        [JsonProperty(ItemConverterType = typeof(GuidConverter))]
        public Guid Id { get; set; } = Guid.NewGuid();
    }


}
