namespace Entity.Models
{
    /// <summary>
    /// Database model that represents the soldier
    /// </summary>
    public class Soldier : BaseObject
    {
        /// <summary>
        /// The soldier name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The soldier Rank
        /// </summary>
        public string Rank { get; set; }

        /// <summary>
        /// Stores a Json with info about the soldier's skills and trainning.
        /// </summary>
        public string TrainningInfo { get; set; }

        #region Navigational Properties

        /// <summary>
        /// The soldier's country of origin
        /// </summary>
        public Country Country { get; set; }

        /// <summary>
        /// The soldier's position 
        /// </summary>
        public IEnumerable<Sensor> Sensors { get; set; }

        #endregion Navigational Properties
    }
}
