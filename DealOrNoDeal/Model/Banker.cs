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
        private const float ROUND_AMOUNT = 100;

        private int numbersInAverage;

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
            this.numbersInAverage = 0;

            this.CurrentOffer = 0;
            this.MinOffer = int.MaxValue;
            this.MaxOffer = int.MinValue;
            this.AverageOffer = 0;
        }

        public void HandleEndOfRound(IList<int> prizesStillAvailable, int briefcasesToOpenNextRound)
        {
            var latestOffer = this.CalculateOffer(prizesStillAvailable, briefcasesToOpenNextRound);
            this.updateOfferValues(latestOffer);
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

            var offer = sumOfPrizesRemaining / briefcasesToOpenNextRound / prizesStillAvailable.Count;
            offer /= ROUND_AMOUNT;
            offer = (float) Math.Round(offer);
            offer *= ROUND_AMOUNT;

            return (int) offer;
        }
        
        private void updateOfferValues(int latestOffer)
        {
            this.CurrentOffer = latestOffer;
            this.MinOffer = Math.Min(this.MinOffer, latestOffer);
            this.MaxOffer = Math.Max(this.MaxOffer, latestOffer);
            
            this.updateAverageOffer(latestOffer);
        }

        private void updateAverageOffer(int latestOffer)
        {
            //Rolling average
            float newAverage = this.AverageOffer;

            newAverage *= (float) this.numbersInAverage / (this.numbersInAverage + 1);
            newAverage += (float) latestOffer / (this.numbersInAverage + 1);

            //TODO ask if average has to be rounded
            this.AverageOffer = (int) newAverage;
            ++this.numbersInAverage;
        }
        }
    }
}
