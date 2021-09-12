namespace DealOrNoDeal.Model
{
    /// <summary>
    ///     Represents the different game type options
    /// </summary>
    public enum GameType
    {
        /// <summary>
        ///     A five-round game (Quickplay)
        /// </summary>
        FiveRound,
        /// <summary>
        ///     A seven-round game with standard prizes
        /// </summary>
        SevenRoundStandard,
        /// <summary>
        ///     A seven-round game with syndicated prizes
        /// </summary>
        SevenRoundSyndicated,
        /// <summary>
        ///     A ten-round game with standard prizes
        /// </summary>
        TenRoundStandard,
        /// <summary>
        ///     A ten-round game with syndicated prizes
        /// </summary>
        TenRoundSyndicated
    }
}