using System;
using System.Collections.Generic;
using System.Linq;

namespace DealOrNoDeal.Model
{
    /// <summary>Handles the management of the actual game play.</summary>
    public class GameManager
    {
        #region Data members

        /// <summary>
        ///     The total number of briefcases
        /// </summary>
        public const int BriefcaseCount = 26;

        /// <summary>
        ///     The maximum briefcases to open in a single round
        /// </summary>
        public const int MaxBriefcasesToOpen = 6;

        /// <summary>
        ///     The number of rounds in a game
        /// </summary>
        public const int NumberOfRounds = 10;

        /// <summary>
        ///     The prize amounts in ascending order
        /// </summary>
        public static readonly int[] PrizeAmounts = 
        {
            0,
            1,
            5,
            10,
            25,
            50,
            75,
            100,
            200,
            300,
            400,
            500,
            750,
            1_000,
            5_000,
            10_000,
            25_000,
            50_000,
            75_000,
            100_000,
            200_000,
            300_000,
            400_000,
            500_000,
            750_000,
            1_000_000
        };

        private readonly IList<Briefcase> briefcases;

        #endregion

        #region Properties

        /// <summary>
        ///     Gets or sets the briefcases remaining in the round.
        /// </summary>
        /// <value>
        ///     The briefcases remaining in the round.
        /// </value>
        public int BriefcasesRemainingInRound { get; set; }

        /// <summary>
        ///     Gets or sets the current banker offer.
        /// </summary>
        /// <value>
        ///     The current banker offer.
        /// </value>
        public int CurrentOffer { get; set; }

        /// <summary>
        ///     Gets or sets the current round.
        /// </summary>
        /// <value>
        ///     The current round.
        /// </value>
        public int CurrentRound { get; set; }

        /// <summary>
        ///     Gets or sets the identifier for the first briefcase selected.
        /// </summary>
        /// <value>
        ///     The first briefcase's identifier.
        /// </value>
        public int FirstBriefcaseId { get; set; }

        /// <summary>
        ///     Gets the first briefcase's number.
        /// </summary>
        /// <value>
        ///     The first briefcase's number.
        /// </value>
        public int FirstBriefcaseNumber => this.FirstBriefcaseId + 1;

        /// <summary>
        ///     Gets or sets the identifier for the final briefcase remaining.
        /// </summary>
        /// <value>
        ///     The final briefcase's identifier.
        /// </value>
        public int FinalBriefcaseId { get; set; }
        
        /// <summary>
        ///     Gets the final briefcase's number.
        /// </summary>
        /// <value>
        ///     The final briefcase's number.
        /// </value>
        public int FinalBriefcaseNumber => this.FinalBriefcaseId + 1;

        /// <summary>
        ///     Gets or sets the maximum offer made by the Banker.
        /// </summary>
        /// <value>
        ///     The maximum Banker offer.
        /// </value>
        public int MaxOffer { get; set; }

        /// <summary>
        ///     Gets or sets the minimum offer made by the Banker.
        /// </summary>
        /// <value>
        ///     The minimum Banker offer.
        /// </value>
        public int MinOffer { get; set; }

        public int AverageOffer { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="GameManager" /> class.
        /// </summary>
        public GameManager()
        {
            this.briefcases = new List<Briefcase>();
            this.CurrentRound = 1;
            this.BriefcasesRemainingInRound = 6;
            this.FirstBriefcaseId = -1;
            this.FinalBriefcaseId = -1;
            this.CurrentOffer = 0;
            this.MinOffer = int.MaxValue;
            this.MaxOffer = int.MinValue;

            var prizes = generateShuffledPrizeArray();
            this.populateBriefcaseList(prizes);
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Calculates the number of briefcases to open in a given round.
        ///     Precondition : roundNumber &gt; 0 &amp;&amp; roundNumber &lt;= NumberOfRounds
        ///     Postcondition: result = Math.Max(MaxBriefcasesToOpen - roundNumber + 1, 1)
        /// </summary>
        /// <param name="roundNumber">The round number.</param>
        /// <returns>The number of briefcases to open in the round</returns>
        /// <exception cref="System.ArgumentException">roundNumber must be a positive integer below {NumberOfRounds + 1}.</exception>
        public static int CalculateBriefcasesToOpenInRound(int roundNumber)
        {
            if (roundNumber <= 0 || roundNumber > NumberOfRounds)
            {
                throw new ArgumentException($"roundNumber must be a positive integer below {NumberOfRounds + 1}.");
            }

            return Math.Max(MaxBriefcasesToOpen - roundNumber + 1, 1);
        }

        private void populateBriefcaseList(IList<int> prizes)
        {
            for (var i = 0; i < BriefcaseCount; ++i)
            {
                Briefcase briefcase = new Briefcase(i, prizes[i]);
                this.briefcases.Add(briefcase);
            }
        }
        
        private static int[] generateShuffledPrizeArray()
        {
            var shuffledArr = (int[])PrizeAmounts.Clone();
            var shuffledIndices = new HashSet<int>();
            var random = new Random();

            //Fisher-Yates shuffle algorithm
            for (var i = BriefcaseCount - 1; i > 1; --i)
            {
                var targetIndex = random.Next(0, i);
                if (shuffledIndices.Contains(targetIndex))
                {
                    continue;
                }

                (shuffledArr[i], shuffledArr[targetIndex]) = (shuffledArr[targetIndex], shuffledArr[i]);

                shuffledIndices.Add(targetIndex);
            }

            return shuffledArr;
        }

        /// <summary>
        ///     Removes the specified briefcase from play.
        ///     Precondition: id &gt;= 0 &amp;&amp; id &amp; briefcases.Count &amp;&amp;
        ///     Postcondition: None
        /// </summary>
        /// <param name="id">The id of the briefcase to remove from play.</param>
        /// <returns>Dollar amount stored in the case, or -1 if case not found.</returns>
        public int RemoveBriefcaseFromPlay(int id)
        {
            for (var i = 0; i < this.briefcases.Count; ++i)
            {
                if (this.briefcases[i].Id == id)
                {
                    var prizeAmount = this.briefcases[i].PrizeAmount;
                    this.briefcases.RemoveAt(i);
                    return prizeAmount;
                }
            }

            return -1;
        }

        /// <summary>
        ///     Gets an offer from the Banker.
        /// </summary>
        /// <returns>An offer from the Banker.</returns>
        public int GetOffer()
        {
            var availablePrizes = this.briefcases.Select(briefcase => briefcase.PrizeAmount).ToList();
            var briefcasesToOpenNextRound = CalculateBriefcasesToOpenInRound(this.CurrentRound + 1);

            return Banker.CalculateOffer(availablePrizes, briefcasesToOpenNextRound);
        }

        /// <summary>
        /// Updates the current, min, max, and average offer values.
        /// </summary>
        public void UpdateOfferValues(int currentOffer)
        {
            this.CurrentOffer = currentOffer;
            this.MinOffer = Math.Min(this.MinOffer, currentOffer);
            this.MaxOffer = Math.Min(this.MaxOffer, currentOffer);

            //Rolling average calculation
            this.AverageOffer *= (this.CurrentRound - 1) / this.CurrentRound;
            this.AverageOffer += currentOffer / this.CurrentRound;
        }

        /// <summary>
        ///     Gets the prize amount stored in a certain briefcase.
        ///     Precondition: id &gt;= 0 &amp;&amp; id &amp; briefcases.Count &amp;&amp;
        ///     Postcondition: None
        /// </summary>
        /// <param name="id">The briefcase's id number.</param>
        /// <returns>
        ///     Dollar amount stored in the case, or -1 if case not found.
        /// </returns>
        public int GetPrizeAmountFromBriefcaseId(int id)
        {
            foreach (var briefcase in this.briefcases)
            {
                if (briefcase.Id == id)
                {
                    return briefcase.PrizeAmount;
                }
            }

            return -1;
        }

        /// <summary>
        ///     Moves to next round by incrementing Round property and setting
        ///     initial number of cases for that round
        ///     Precondition: None
        ///     Postcondition: Round == Round@prev + 1 AND CasesRemainingInRound == (number of cases to open in the next round)
        /// </summary>
        public void MoveToNextRound()
        {
            ++this.CurrentRound;
            this.BriefcasesRemainingInRound = CalculateBriefcasesToOpenInRound(this.CurrentRound);
        }

        /// <summary>
        ///     Determines whether the game is [on the final round].
        ///     Precondition: None
        ///     Postcondition: result == (CurrentRound == NumberOfRounds)
        /// </summary>
        /// <returns>
        ///     <c>true</c> if the game [is on final round]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsOnFinalRound()
        {
            return this.CurrentRound == NumberOfRounds;
        }

        /// <summary>
        ///     Determines whether the game [has remaining briefcases in round].
        /// </summary>
        /// <returns>
        ///     <c>true</c> if [has opened all briefcases in round]; otherwise, <c>false</c>.
        /// </returns>
        public bool HasOpenedAllBriefcasesInRound()
        {
            return this.BriefcasesRemainingInRound == 0;
        }

        /// <summary>
        ///     Determines whether the game [has first briefcase claimed].
        /// </summary>
        /// <returns>
        ///     <c>true</c> if the game [has first briefcase claimed]; otherwise, <c>false</c>.
        /// </returns>
        public bool HasFirstBriefcaseClaimed()
        {
            return this.FirstBriefcaseId != -1;
        }

        #endregion
    }
}