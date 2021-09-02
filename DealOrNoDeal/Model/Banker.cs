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
        public static int CalculateOffer(IList<int> prizesStillAvailable, int briefcasesToOpenNextRound)
        {
            float sumOfPrizesRemaining = prizesStillAvailable.Sum();

            float offer = sumOfPrizesRemaining / briefcasesToOpenNextRound / prizesStillAvailable.Count;

            return (int) Math.Round(offer);
        }
    }
}
