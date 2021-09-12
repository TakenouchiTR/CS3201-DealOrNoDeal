namespace DealOrNoDeal.Model
{
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

        public int[] Prizes => PrizeArrays[(int) this.GameType];

        public GameType GameType { get; }

        #endregion

        #region Constructors

        public PrizeManager(GameType gameType)
        {
            this.GameType = gameType;
        }

        #endregion

        #region Methods

        public static int[] GetPrizesForGameType(GameType gameType)
        {
            return PrizeArrays[(int) gameType];
        }

        public int[] generateShuffledPrizeArray()
        {
            var shuffledArr = (int[])this.Prizes.Clone();
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