// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameStateExample.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

namespace Alis.Extension.Ads.GoogleAds.Sample
{
    /// <summary>
    ///     Example game state class for integration demonstration
    /// </summary>
    public class GameStateExample
    {
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
        ///     Initializes a new instance of the <see cref="GameStateExample" /> class
        /// </summary>
        public GameStateExample()
        {
            IsPremium = false;
            CurrentLevel = 1;
            Coins = 100;
        }

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