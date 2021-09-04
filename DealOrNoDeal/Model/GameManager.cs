using System;
using System.Collections.Generic;
using System.Linq;

namespace DealOrNoDeal.Model
{
    /// <summary>Handles the management of the actual game play.</summary>
    public class GameManager
    {
        #region Data members
        private readonly IList<Briefcase> briefcases;
        private readonly Banker banker;
        private readonly RoundManager roundManager;
        private readonly PrizeManager prizeManager;
        #endregion

        #region Properties

        /// <summary>
        ///     Gets or sets the briefcases remaining in the round.
        /// </summary>
        /// <value>
        ///     The briefcases remaining in the round.
        /// </value>
        public int BriefcasesRemainingInRound => this.roundManager.BriefcasesRemainingInRound;

        /// <summary>
        ///     Gets or sets the current round.
        /// </summary>
        /// <value>
        ///     The current round.
        /// </value>
        public int CurrentRound => this.roundManager.CurrentRound;

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
        ///     Gets or sets the current banker offer.
        /// </summary>
        /// <value>
        ///     The current banker offer.
        /// </value>
        public int CurrentOffer => this.banker.CurrentOffer;

        /// <summary>
        ///     Gets or sets the maximum offer made by the Banker.
        /// </summary>
        /// <value>
        ///     The maximum Banker offer.
        /// </value>
        public int MaxOffer => this.banker.MaxOffer;

        /// <summary>
        ///     Gets or sets the minimum offer made by the Banker.
        /// </summary>
        /// <value>
        ///     The minimum Banker offer.
        /// </value>
        public int MinOffer => this.banker.MinOffer;

        /// <summary>
        ///     Gets or sets the average offer made by the Banker.
        /// </summary>
        /// <value>
        ///     The average Banker offer.
        /// </value>
        public int AverageOffer => this.banker.AverageOffer;
        #endregion

        #region Constructors

        //Todo update this documentation
        /// <summary>
        ///     Initializes a new instance of the <see cref="GameManager" /> class.
        /// </summary>
        public GameManager(GameType gameType)
        {
            this.briefcases = new List<Briefcase>();
            this.banker = new Banker();
            this.roundManager = new RoundManager(gameType);
            this.prizeManager = new PrizeManager(gameType);

            this.CurrentRound = 1;
            this.BriefcasesRemainingInRound = 6;
            this.FirstBriefcaseId = -1;
            this.FinalBriefcaseId = -1;

            var prizes = generateShuffledPrizeArray();
            this.populateBriefcaseList(prizes);
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Gets the number of briefcases to open in a given round.
        ///     Precondition : roundNumber &gt; 0 &amp;&amp; roundNumber &lt;= NumberOfRounds
        ///     Postcondition: None
        /// </summary>
        /// <param name="roundNumber">The round number.</param>
        /// <returns>The number of briefcases to open in the round</returns>
        /// <exception cref="System.ArgumentException">roundNumber must be a positive integer below {NumberOfRounds + 1}.</exception>
        public int GetBriefcasesToOpenInRound(int roundNumber)
        {
            return this.roundManager.GetBriefcasesToOpenInRound(roundNumber);
        }

        private void populateBriefcaseList(IList<int> prizes)
        {
            for (var i = 0; i < BriefcaseCount; ++i)
            {
                Briefcase briefcase = new Briefcase(i, prizes[i]);
                this.briefcases.Add(briefcase);
            }
        }
        
        private int[] generateShuffledPrizeArray()
        {
            var shuffledArr = (int[]) this.prizeManager.Prizes.Clone();
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

        //Todo Ask professor about post condition affecting fields
        /// <summary>
        ///     Handles the end of round logic.
        ///     Precondition: None
        ///     Postcondition: None
        /// </summary>
        public void HandleEndOfRound()
        {
            var availablePrizes = this.briefcases.Select(briefcase => briefcase.PrizeAmount).ToList();
            var briefcasesToOpenNextRound = GetBriefcasesToOpenInRound(this.CurrentRound + 1);

            this.banker.HandleEndOfRound(availablePrizes, briefcasesToOpenNextRound);
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

        //todo ask about fields in postcondition
        /// <summary>
        ///     Moves to next round by incrementing Round property and setting
        ///     initial number of cases for that round
        ///     Precondition: None
        ///     Postcondition: Round == Round@prev + 1 AND CasesRemainingInRound == (number of cases to open in the next round)
        /// </summary>
        public void MoveToNextRound()
        {
            this.roundManager.MoveToNextRound();
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