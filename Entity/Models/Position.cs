namespace Entity.Models
{
    /// <summary>
    /// The soldier's position
    /// </summary>
    public class Position : BaseObject
    {
        /// <summary>
        /// The position's latitude
        /// </summary>
        public decimal Latitude { get; set; }

        /// <summary>
        /// The position's longitude
        /// </summary>
        public decimal Longitude { get; set; }

        /// <summary>
        /// The position's date and time
        /// </summary>
        public DateTime Time { get; set; }

        #region Navigational Properties

        public Guid SensorId { get; set; }
        public Sensor Sensor { get; set; }

        #endregion Navigational Properties
    }
}
