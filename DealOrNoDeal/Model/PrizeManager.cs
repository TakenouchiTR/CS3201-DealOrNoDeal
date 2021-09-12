using System;
using System.Collections.Generic;

namespace DealOrNoDeal.Model
{
    /// <summary>
    ///     Manages prize information
    /// </summary>
    public class PrizeManager
    {
        #region Data members

        #region Data fields

        //Todo rename this
        private static readonly int[][] PrizeArrays = {
            new[] {
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
            new[] {
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
            new[] {
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
            new[] {
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
            new[] {
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

        #endregion

        #region Properties

        /// <summary>
        ///     Gets the prizes for the game.
        /// </summary>
        /// <value>
        ///     The prizes.
        /// </value>
        public int[] Prizes => PrizeArrays[(int) this.GameType];

        /// <summary>
        ///     Gets the game type.
        /// </summary>
        /// <value>
        ///     The game type.
        /// </value>
        public GameType GameType { get; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="PrizeManager" /> class.
        /// </summary>
        /// <param name="gameType">Type of the game.</param>
        public PrizeManager(GameType gameType)
        {
            this.GameType = gameType;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Gets the ordered prize array for a specified GameType.
        /// </summary>
        /// <param name="gameType">The GameType for the game.</param>
        /// <returns>An array of prizes</returns>
        public static int[] GetPrizesForGameType(GameType gameType)
        {
            return PrizeArrays[(int) gameType];
        }

        /// <summary>
        ///     Generates a shuffled array of prizes.
        /// </summary>
        /// <returns>
        ///     A randomly ordered array of prizes.
        /// </returns>
        public int[] GenerateShuffledPrizeArray()
        {
            var shuffledArr = (int[]) this.Prizes.Clone();
            var shuffledIndices = new HashSet<int>();
            var random = new Random();

            //Fisher-Yates shuffle algorithm
            for (var i = shuffledArr.Length; i > 1; --i)
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

        #endregion
    }
}