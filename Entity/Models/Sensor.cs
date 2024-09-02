namespace Entity.Models
{
    /// <summary>
    /// Sensor to monitor soldier
    /// </summary>
    public class Sensor : BaseObject
    {
        /// <summary>
        /// The sensor name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The sensor type
        /// </summary>
        public SensorType Type { get; set; }

        /// <summary>
        /// There must be only one active sensor per soldier
        /// </summary>
        public bool Active { get; set; } = true;

        /// <summary>
        /// The sensor's measured position
        /// </summary>
        public IEnumerable<Position> Positions { get; set; }

        #region Navigational Properties

        public Guid SoldierId { get; set; }
        public Soldier Soldier { get; set; }

        #endregion Navigational Properties
    }
}
