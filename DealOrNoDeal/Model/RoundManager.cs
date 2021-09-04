using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DealOrNoDeal.Model
{
    public class RoundManager
    {
        #region Data fields
        private static readonly int[] CaseAmounts = 
        {
            18,
            26,
            26,
            26,
            26
        };

        private static readonly int[] RoundAmounts = 
        {
            5,
            7,
            7,
            10,
            10
        };

        //todo rename this as well
        private static readonly int[][] BriefcasesInRound =
        {
            new int[] { 6, 5, 3, 2, 1 },
            new int[] { 8, 6, 4, 3, 2, 1, 1},
            new int[] { 8, 6, 4, 3, 2, 1, 1},
            new int[] { 6, 5, 4, 3, 2, 1, 1, 1, 1, 1},
            new int[] { 6, 5, 4, 3, 2, 1, 1, 1, 1, 1}
        };
        #endregion

        #region Properties
        public GameType GameType { get; private set; }

        public int CurrentRound { get; private set; }
        
        /// <summary>
        ///     Gets or sets the briefcases remaining in the round.
        /// </summary>
        /// <value>
        ///     The briefcases remaining in the round.
        /// </value>
        public int BriefcasesRemainingInRound { get; set; }
        
        private int NumberOfRounds => RoundAmounts[(int) this.GameType];

        public int TotalBriefcases => CaseAmounts[(int) this.GameType];
        #endregion

        #region Constructors
        public RoundManager(GameType gameType)
        {
            this.GameType = gameType;

            this.CurrentRound = 1;
            this.BriefcasesRemainingInRound = this.GetBriefcasesToOpenInRound(1);
        }
        #endregion

        #region Methods
        public void MoveToNextRound()
        {
            ++this.CurrentRound;
            this.BriefcasesRemainingInRound = this.GetBriefcasesToOpenInRound(this.CurrentRound);
        }

        public int GetBriefcasesToOpenInRound(int roundNumber)
        {
            if (roundNumber < 1 || roundNumber > this.NumberOfRounds)
            {
                throw new ArgumentException($"roundNumber must be a positive integer below {this.NumberOfRounds + 1}.");
            }

            return BriefcasesInRound[(int) this.GameType][roundNumber - 1];
        }

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
