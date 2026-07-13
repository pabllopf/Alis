// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectLocationRemainingCoverageTests.cs
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

using Alis.Core.Ecs;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     Tests the remaining uncovered methods of <see cref="GameObjectLocation" /> struct.
    /// </summary>
    public class GameObjectLocationRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that the two-parameter constructor sets <see cref="GameObjectLocation.Index" /> correctly.
        /// </summary>
        [Fact]
        public void Constructor_WithArchetypeAndIndex_SetsProperties()
        {
            GameObjectLocation loc = new GameObjectLocation(null!, 5);

            Assert.Equal(5, loc.Index);
        }

        /// <summary>
        ///     Tests that the three-parameter constructor sets <see cref="GameObjectLocation.Flags" /> correctly.
        /// </summary>
        [Fact]
        public void Constructor_WithArchetypeIndexAndFlags_SetsFlags()
        {
            GameObjectLocation loc = new GameObjectLocation(null!, 0, GameObjectFlags.None);

            Assert.Equal(GameObjectFlags.None, loc.Flags);
        }

        /// <summary>
        ///     Tests that <see cref="GameObjectLocation.Default" /> returns a location with <see cref="int.MaxValue" /> index.
        /// </summary>
        [Fact]
        public void Default_ReturnsLocationWithMaxIndex()
        {
            Assert.Equal(int.MaxValue, GameObjectLocation.Default.Index);
        }

        /// <summary>
        ///     Tests that <see cref="GameObjectLocation.HasEvent" /> returns <see langword="true" /> when flags match.
        /// </summary>
        [Fact]
        public void HasEvent_WithMatchingFlag_ReturnsTrue()
        {
            GameObjectLocation loc = new GameObjectLocation(null!, 0, GameObjectFlags.AddComp);

            Assert.True(loc.HasEvent(GameObjectFlags.AddComp));
        }

        /// <summary>
        ///     Tests that <see cref="GameObjectLocation.HasEvent" /> returns <see langword="false" /> when flags do not match.
        /// </summary>
        [Fact]
        public void HasEvent_WithNonMatchingFlag_ReturnsFalse()
        {
            GameObjectLocation loc = new GameObjectLocation(null!, 0, GameObjectFlags.None);

            Assert.False(loc.HasEvent(GameObjectFlags.AddComp));
        }

        /// <summary>
        ///     Tests that the static <see cref="GameObjectLocation.HasEventFlag" /> returns <see langword="true" /> for matching flags.
        /// </summary>
        [Fact]
        public void HasEventFlag_Static_WithMatchingFlag_ReturnsTrue()
        {
            Assert.True(GameObjectLocation.HasEventFlag(GameObjectFlags.AddComp, GameObjectFlags.AddComp));
        }

        /// <summary>
        ///     Tests that the static <see cref="GameObjectLocation.HasEventFlag" /> returns <see langword="false" /> for non-matching flags.
        /// </summary>
        [Fact]
        public void HasEventFlag_Static_WithNonMatchingFlag_ReturnsFalse()
        {
            Assert.False(GameObjectLocation.HasEventFlag(GameObjectFlags.None, GameObjectFlags.AddComp));
        }
    }
}
