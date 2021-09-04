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

        //Todo rename this
        private static readonly int[][] PrizeArrays = {
            new int[] {
                0,
                5,
                10,
                25,
                50,
                75,
                100,
                250,
                500,
                750,
                1_000,
                2_500,
                5_000,
                10_000,
                25_000,
                50_000,
                75_000,
                100_000
            },
            new int[] {
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
            },
            new int[] {
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
                2_500,
                5_000,
                10_000,
                25_000,
                50_000,
                75_000,
                100_000,
                150_000,
                200_000,
                250_000,
                350_000,
                500_000

            },
            new int[] {
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
            },
            new int[] {
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
                2_500,
                5_000,
                10_000,
                25_000,
                50_000,
                75_000,
                100_000,
                150_000,
                200_000,
                250_000,
                350_000,
                500_000
            }
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
        
        private int[] Prizes => PrizeArrays[(int) this.GameType];

        private int NumberOfRounds => RoundAmounts[(int)this.GameType];

        private int BriefcaseCount => this.Prizes.Length;
        #endregion

        #region Constructors
        private RoundManager()
        {

        }

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

        #endregion
    }
}
