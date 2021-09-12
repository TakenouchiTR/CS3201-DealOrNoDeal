using System;
using System.Collections.Generic;
using System.Linq;

namespace DealOrNoDeal.Model
{
    /// <summary>
    ///     Handles calculation and statistics for offers
    /// </summary>
    public class Banker
    {
        #region Data members

        private const float PrizeRoundAmount = 100;

        private int numbersInAverage;

        #endregion

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

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Banker"/> class.
        /// </summary>
        public Banker()
        {
            this.numbersInAverage = 0;

            this.CurrentOffer = 0;
            this.MinOffer = int.MaxValue;
            this.MaxOffer = int.MinValue;
            this.AverageOffer = 0;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Handles the end of round offer calculation and statistic tracking.
        ///     Precondition:  prizesStillAvailable.Count &gt; 0 &amp;&amp; briefcasesToOpenNextRound &gt; 0
        ///     Postcondition: CurrentOffer == CalculateOffer(prizesStillAvailable, briefcasesToOpenNextRound);
        ///                    MinOffer == Math.Min(CurrentOffer, MinOffer@prev);
        ///                    MaxOffer == Math.Max(CurrentOffer, MaxOffer@prev);
        ///                    AverageOffer == &lt;average of all offer&gt;
        /// </summary>
        /// <param name="prizesStillAvailable">The prizes still available.</param>
        /// <param name="briefcasesToOpenNextRound">The number briefcases to open next round.</param>
        /// <exception cref="System.ArgumentException">
        /// prizesStillAvailable.Count must contain at least one item
        /// or
        /// briefcasesToOpenNextRound must be positive
        /// </exception>
        public void HandleEndOfRound(IList<int> prizesStillAvailable, int briefcasesToOpenNextRound)
        {
            if (prizesStillAvailable.Count == 0)
            {
                throw new ArgumentException("prizesStillAvailable.Count must contain at least one item");
            }
            if (briefcasesToOpenNextRound <= 0)
            {
                throw new ArgumentException("briefcasesToOpenNextRound must be positive");
            }

            var latestOffer = this.CalculateOffer(prizesStillAvailable, briefcasesToOpenNextRound);
            this.updateOfferValues(latestOffer);
        }

        /// <summary>
        ///     Calculates the banker's offer.
        ///     Precondition:  None
        ///     Postcondition: offer = (Sum of remaining prizes) / (Number of briefcases to open next round) / (Total briefcases
        ///     remaining)
        /// </summary>
        /// <param name="prizesStillAvailable">The list of prizes still available.</param>
        /// <param name="briefcasesToOpenNextRound">The number of briefcases to open next round.</param>
        /// <returns>
        ///     An offer from the banker.
        /// </returns>
        public int CalculateOffer(IList<int> prizesStillAvailable, int briefcasesToOpenNextRound)
        {
            float sumOfPrizesRemaining = prizesStillAvailable.Sum();

            var offer = sumOfPrizesRemaining / briefcasesToOpenNextRound / prizesStillAvailable.Count;
            offer = roundNumber(offer);

            return (int) offer;
        }
        
        private void updateOfferValues(int latestOffer)
        {
            this.CurrentOffer = latestOffer;
            this.MinOffer = Math.Min(this.MinOffer, latestOffer);
            this.MaxOffer = Math.Max(this.MaxOffer, latestOffer);

            this.updateAverageOffer(latestOffer);
        }

        /// <summary>
        /// Updates the average offer.
        /// </summary>
        /// <param name="latestOffer">The latest offer.</param>
        private void updateAverageOffer(int latestOffer)
        {
            //Rolling average
            float newAverage = this.AverageOffer;

            newAverage *= (float) this.numbersInAverage / (this.numbersInAverage + 1);
            newAverage += (float) latestOffer / (this.numbersInAverage + 1);
            
            this.AverageOffer = (int) newAverage;
            ++this.numbersInAverage;
        }

        private static float roundNumber(float number)
        {
            number /= PrizeRoundAmount;
            number = (float) Math.Round(number);
            number *= PrizeRoundAmount;

            return number;
        }

        #endregion
    }
}