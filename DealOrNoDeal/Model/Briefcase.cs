namespace DealOrNoDeal.Model
{
    /// <summary>
    ///     Stores information for a Briefcase
    /// </summary>
    public class Briefcase
    {
        #region Properties
        /// <summary>
        /// Gets or sets the briefcase identifier.
        /// </summary>
        /// <value>
        /// The briefcase identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the prize amount.
        /// </summary>
        /// <value>
        /// The prize amount.
        /// </value>
        public int PrizeAmount { get; set; }
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="Briefcase"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="prizeAmount">The prize amount.</param>
        public Briefcase(int id, int prizeAmount)
        {
            this.Id = id;
            this.PrizeAmount = prizeAmount;
        }
    }
}
