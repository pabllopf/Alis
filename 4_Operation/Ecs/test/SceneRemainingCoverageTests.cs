// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SceneRemainingCoverageTests.cs
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

using System;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     The scene remaining coverage tests class
    /// </summary>
    public class SceneRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that create many with zero count throws argument out of range
        /// </summary>
        [Fact]
        public void CreateMany_WithZeroCount_ThrowsArgumentOutOfRange()
        {
            using Scene scene = new Scene();

            Assert.Throws<ArgumentOutOfRangeException>(() => scene.CreateMany<Position, Health>(0));
        }

        /// <summary>
        ///     Tests that create many with negative count throws argument out of range
        /// </summary>
        [Fact]
        public void CreateMany_WithNegativeCount_ThrowsArgumentOutOfRange()
        {
            using Scene scene = new Scene();

            Assert.Throws<ArgumentOutOfRangeException>(() => scene.CreateMany<Position, Health>(-1));
        }

        /// <summary>
        ///     Tests that create many with positive count creates entities
        /// </summary>
        [Fact]
        public void CreateMany_WithPositiveCount_CreatesEntities()
        {
            using Scene scene = new Scene();

            var chunk = scene.CreateMany<Position, Health>(5);

            Assert.Equal(5, chunk.Span1.Length);
        }
    }
}
