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

        public GameType GameType { get; private set; }
        public int CurrentRound { get; private set; }

        public int[] Prizes => PrizeArrays[(int) this.GameType];

        public int NumberOfRounds => RoundAmounts[(int)this.GameType];

        public int BriefcaseCount => this.Prizes.Length;

        private RoundManager()
        {

        }

        public RoundManager(GameType gameType)
        {
            this.CurrentRound = 1;
            this.GameType = gameType;
        }
        
    }
}
