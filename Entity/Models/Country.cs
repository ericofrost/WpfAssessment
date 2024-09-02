namespace Entity.Models
{
    /// <summary>
    /// Database model to store countries
    /// </summary>
    public class Country : BaseObject
    {
        /// <summary>
        /// The country Name
        /// </summary>
        public string Name { get; set; }

        #region Navigational Properties

        public Guid SoldierId { get; set; }
        public Soldier Soldier { get; set; }

        #endregion Navigational Properties
    }
}
