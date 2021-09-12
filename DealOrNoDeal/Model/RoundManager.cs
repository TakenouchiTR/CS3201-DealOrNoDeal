using System;

namespace DealOrNoDeal.Model
{
    /// <summary>
    ///     Manages round information.
    /// </summary>
    public class RoundManager
    {
        #region Data fields

        private static readonly int[] TotalBriefcasesPerGameType = {
            18,
            26,
            26,
            26,
            26
        };

        private static readonly int[] NumberOfRoundsPerGameType = {
            5,
            7,
            7,
            10,
            10
        };
        
        private static readonly int[][] BriefcasesPerRoundPerGameType = {
            new[] {6, 5, 3, 2, 1},
            new[] {8, 6, 4, 3, 2, 1, 1},
            new[] {8, 6, 4, 3, 2, 1, 1},
            new[] {6, 5, 4, 3, 2, 1, 1, 1, 1, 1},
            new[] {6, 5, 4, 3, 2, 1, 1, 1, 1, 1}
        };

        #endregion

        #region Properties
        
        /// <summary>
        ///     Gets the current round.
        /// </summary>
        /// <value>
        ///     The current round.
        /// </value>
        public int CurrentRound { get; private set; }

        /// <summary>
        ///     Gets or sets the briefcases remaining in the round.
        /// </summary>
        /// <value>
        ///     The briefcases remaining in the round.
        /// </value>
        public int BriefcasesRemainingInRound { get; set; }

        private int NumberOfRounds { get; }

        /// <summary>
        ///     Gets the total briefcases in the game.
        /// </summary>
        /// <value>
        ///     The total briefcases.
        /// </value>
        public int TotalBriefcases { get; }

        private int[] BriefcasesPerRound { get; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="RoundManager" /> class.
        /// </summary>
        /// <param name="gameType">Type of the game.</param>
        public RoundManager(GameType gameType)
        {
            this.CurrentRound = 1;

            this.NumberOfRounds = NumberOfRoundsPerGameType[(int) gameType];
            this.TotalBriefcases = TotalBriefcasesPerGameType[(int) gameType];
            this.BriefcasesPerRound = BriefcasesPerRoundPerGameType[(int) gameType];

            this.BriefcasesRemainingInRound = this.GetBriefcasesToOpenInRound(1);
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Proceeds to the next round.
        ///     Precondition: CurrentRound != NumberOfRounds
        ///     Postcondition: CurrentRound == CurrentRound@prev + 1;
        ///     BriefcasesRemainingInRound = GetBriefcasesToOpenInRound(CurrentRound)
        /// </summary>
        public void MoveToNextRound()
        {
            ++this.CurrentRound;
            this.BriefcasesRemainingInRound = this.GetBriefcasesToOpenInRound(this.CurrentRound);
        }

        /// <summary>
        ///     Gets the briefcases to open in a specified round.
        ///     Precondition: roundNumber &gt; 0 &amp;&amp; roundNumber &lt; NumberOfRounds + 1
        ///     PostCondition: None
        /// </summary>
        /// <param name="roundNumber">The round number.</param>
        /// <returns>The number of briefcases to open in a specified round</returns>
        /// <exception cref="System.ArgumentException">roundNumber must be a positive integer below {NumberOfRounds + 1}.</exception>
        public int GetBriefcasesToOpenInRound(int roundNumber)
        {
            if (roundNumber < 1 || roundNumber > this.NumberOfRounds)
            {
                throw new ArgumentException($"roundNumber must be a positive integer below {this.NumberOfRounds + 1}.");
            }

            return this.BriefcasesPerRound[roundNumber - 1];
        }

        /// <summary>
        ///     Checks whether the game is on the final round.
        ///     Precondition: None
        ///     PostCondition: None
        /// </summary>
        /// <returns>
        ///     <c>true</c> if [is on final round]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsOnFinalRound()
        {
            return this.CurrentRound == this.NumberOfRounds;
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

        #endregion
    }
}