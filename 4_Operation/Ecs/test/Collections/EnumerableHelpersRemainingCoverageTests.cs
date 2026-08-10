// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EnumerableHelpersRemainingCoverageTests.cs
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

using System.Collections.Generic;
using Alis.Core.Ecs.Collections;
using Xunit;

namespace Alis.Core.Ecs.Test.Collections
{
    /// <summary>
    ///     The enumerable helpers remaining coverage tests class
    /// </summary>
    public class EnumerableHelpersRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that to array with more than four elements grows buffer
        /// </summary>
        [Fact]
        public void ToArray_WithMoreThanFourElements_GrowsBuffer()
        {
            IEnumerable<int> source = YieldFiveElements();

            int[] result = EnumerableHelpers.ToArray(source, out int length);

            Assert.Equal(5, length);
            Assert.True(result.Length >= 5);
            Assert.Equal(1, result[0]);
            Assert.Equal(5, result[4]);
        }

        /// <summary>
        ///     Yields the five elements
        /// </summary>
        /// <returns>The enumerable</returns>
        private static IEnumerable<int> YieldFiveElements()
        {
            yield return 1;
            yield return 2;
            yield return 3;
            yield return 4;
            yield return 5;
        }
    }
}
