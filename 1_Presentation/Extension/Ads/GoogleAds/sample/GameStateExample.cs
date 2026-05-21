

namespace Alis.Extension.Ads.GoogleAds.Sample
{
    /// <summary>
    ///     Example game state class for integration demonstration
    /// </summary>
    public class GameStateExample
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="GameStateExample" /> class
        /// </summary>
        public GameStateExample()
        {
            IsPremium = false;
            CurrentLevel = 1;
            Coins = 100;
        }

        /// <summary>
        ///     Gets or sets whether the player has premium status
        /// </summary>
        public bool IsPremium { get; set; }

        /// <summary>
        ///     Gets or sets the current game level
        /// </summary>
        public int CurrentLevel { get; set; }

        /// <summary>
        ///     Gets or sets the player's coins
        /// </summary>
        public int Coins { get; set; }

        /// <summary>
        ///     Adds coins to the player's balance
        /// </summary>
        /// <param name="amount">The amount to add</param>
        public void AddCoins(int amount)
        {
            Coins += amount;
        }
    }
}