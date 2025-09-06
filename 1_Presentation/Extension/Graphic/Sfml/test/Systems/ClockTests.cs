// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ClockTests.cs
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

using Alis.Extension.Graphic.Sfml.Systems;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Systems
{
    /// <summary>
    ///     The clock tests class
    /// </summary>
    public class ClockTests
    {
        /// <summary>
        ///     Tests that constructor creates clock
        /// </summary>
        [Fact(Skip = "Cannot test Clock without native SFML dependencies.")]
        public void Constructor_CreatesClock()
        {
            Clock clock = new Clock();
            Assert.NotNull(clock);
        }

        /// <summary>
        ///     Tests that elapsed time returns time
        /// </summary>
        [Fact(Skip = "Cannot test Clock without native SFML dependencies.")]
        public void ElapsedTime_ReturnsTime()
        {
            Clock clock = new Clock();
            Time elapsed = clock.ElapsedTime;
            Assert.IsType<Time>(elapsed);
        }

        /// <summary>
        ///     Tests that restart returns time
        /// </summary>
        [Fact(Skip = "Cannot test Clock without native SFML dependencies.")]
        public void Restart_ReturnsTime()
        {
            Clock clock = new Clock();
            Time time = clock.Restart();
            Assert.IsType<Time>(time);
        }
    }
}