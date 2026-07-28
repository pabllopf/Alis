// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FastImmutableArrayTests.cs
// 
//  Author:Pablo Perdomo Falcon
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
using System.Collections.Generic;
using Alis.Core.Aspect.Math.Collections;
using Xunit;

namespace Alis.Core.Aspect.Math.Test.Collections
{
    /// <summary>
    /// The fast immutable array tests class
    /// </summary>
    public class FastImmutableArrayTests
    {
        /// <summary>
        /// Tests that remove range with items not present calls remove at range with empty collection
        /// </summary>
        [Fact]
        public void RemoveRange_WithItemsNotPresent_CallsRemoveAtRangeWithEmptyCollection()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(5);
            builder.AddRange(1, 2, 3);
            builder.RemoveRange(new[] { 99 });
            Assert.Equal(3, builder.Count);
            Assert.Equal(1, builder[0]);
            Assert.Equal(2, builder[1]);
            Assert.Equal(3, builder[2]);
        }

        /// <summary>
        /// Tests that remove range empty items does nothing
        /// </summary>
        [Fact]
        public void RemoveRange_EmptyItems_DoesNothing()
        {
            FastImmutableArray<int>.Builder builder = FastImmutableArray<int>.CreateBuilder<int>(3);
            builder.AddRange(1, 2, 3);
            builder.RemoveRange(new int[0]);
            Assert.Equal(3, builder.Count);
        }

        /// <summary>
        /// Tests that remove range with custom comparer items not present does nothing
        /// </summary>
        [Fact]
        public void RemoveRange_WithCustomComparer_ItemsNotPresent_DoesNothing()
        {
            FastImmutableArray<string>.Builder builder = FastImmutableArray<string>.CreateBuilder<string>(3);
            builder.AddRange("A", "B", "C");
            builder.RemoveRange(new[] { "z" }, StringComparer.OrdinalIgnoreCase);
            Assert.Equal(3, builder.Count);
        }
    }
}
