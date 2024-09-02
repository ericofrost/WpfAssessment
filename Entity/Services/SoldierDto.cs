using Entity.Models;

namespace Entity.Services
{
    /// <summary>
    /// Soldier Data Transfer Object
    /// </summary>
    public class SoldierDto : BaseObject
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

        /// <summary>
        /// The Country Name
        /// </summary>
        public string Country { get; set; }
    }
}
