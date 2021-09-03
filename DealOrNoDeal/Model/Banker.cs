using System;
using System.Collections.Generic;
using System.Linq;

namespace DealOrNoDeal.Model
{
    /// <summary>
    ///   Calculates an offer for the player
    /// </summary>
    public class Banker
    {
        #region Properties
        /// <summary>
        ///     Gets or sets the current offer.
        /// </summary>
        /// <value>
        ///     The current offer.
        /// </value>
        public int CurrentOffer { get; set; }

        /// <summary>
        ///     Gets or sets the maximum offer made.
        /// </summary>
        /// <value>
        ///     The maximum offer.
        /// </value>
        public int MaxOffer { get; set; }

        /// <summary>
        ///     Gets or sets the minimum offer made.
        /// </summary>
        /// <value>
        ///     The minimum Banker offer.
        /// </value>
        public int MinOffer { get; set; }

        /// <summary>
        ///     Gets or sets the average offer made.
        /// </summary>
        /// <value>
        ///     The average offer.
        /// </value>
        public int AverageOffer { get; set; }
        #endregion

        public Banker()
        {
            this.CurrentOffer = 0;
            this.MinOffer = int.MaxValue;
            this.MaxOffer = int.MinValue;
            this.AverageOffer = 0;
        }

        /// <summary>
        ///     Calculates the banker's offer.
        ///     Precondition:  None
        ///     Postcondition: offer = (Sum of remaining prizes) / (Number of briefcases to open next round) / (Total briefcases remaining)
        /// </summary>
        /// <param name="prizesStillAvailable">The list of prizes still available.</param>
        /// <param name="briefcasesToOpenNextRound">The number of briefcases to open next round.</param>
        /// <returns>
        ///   An offer from the banker.
        /// </returns>
        public int CalculateOffer(IList<int> prizesStillAvailable, int briefcasesToOpenNextRound)
        {
            float sumOfPrizesRemaining = prizesStillAvailable.Sum();

            float offer = sumOfPrizesRemaining / briefcasesToOpenNextRound / prizesStillAvailable.Count;
            offer /= 100;
            offer = (float) Math.Round(offer);
            offer *= 100;

            return (int) offer;
        }
    }
}
