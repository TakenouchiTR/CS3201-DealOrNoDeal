using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealOrNoDeal.Model
{
    public class PrizeManager
    {
        #region Data fields
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
        #endregion

        #region Properties
        public int[] Prizes => PrizeArrays[(int)this.GameType];

        public GameType GameType { get; private set; }
        #endregion

        #region Constructors
        public PrizeManager(GameType gameType)
        {
            this.GameType = gameType;
        }
        #endregion

        #region Methods
        #endregion
    }
}
