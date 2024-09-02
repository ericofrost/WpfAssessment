namespace Entity.Services
{
    /// <summary>
    /// The position dto
    /// </summary>
    public class PositionDto
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
    }
}
