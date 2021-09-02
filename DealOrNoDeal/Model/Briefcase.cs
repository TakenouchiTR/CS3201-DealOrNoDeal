namespace DealOrNoDeal.Model
{
    /// <summary>
    ///     Stores information for a Briefcase
    /// </summary>
    public class Briefcase
    {
        /// <summary>
        /// Gets or sets the briefcase identifier.
        /// </summary>
        /// <value>
        /// The briefcase identifier.
        /// </value>
        public int BriefcaseId { get; set; }

        /// <summary>
        /// Gets or sets the prize amount.
        /// </summary>
        /// <value>
        /// The prize amount.
        /// </value>
        public int PrizeAmount { get; set; }
    }
}
