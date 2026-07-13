// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RangePtrAccessorRemainingCoverageTests.cs
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
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The range ptr accessor remaining coverage tests class
    /// </summary>
    public class RangePtrAccessorRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that constructor should set data and count
        /// </summary>
        [Fact]
        public void Constructor_ShouldSetDataAndCount()
        {
            IntPtr data = new IntPtr(42);
            RangePtrAccessor<int> accessor = new RangePtrAccessor<int>(data, 5);
            Assert.Equal(data, accessor.Data);
            Assert.Equal(5, accessor.Count);
        }

        /// <summary>
        ///     Tests that indexer throws when index is out of range
        /// </summary>
        [Fact]
        public void Indexer_Throws_WhenIndexOutOfRange()
        {
            RangePtrAccessor<int> accessor = new RangePtrAccessor<int>(new IntPtr(1), 3);
            Assert.Throws<CustomIndexOutOfRangeException>(() => accessor[3]);
        }

        /// <summary>
        ///     Tests that indexer throws when index is negative
        /// </summary>
        [Fact]
        public void Indexer_Throws_WhenIndexNegative()
        {
            RangePtrAccessor<int> accessor = new RangePtrAccessor<int>(new IntPtr(1), 3);
            Assert.Throws<CustomIndexOutOfRangeException>(() => accessor[-1]);
        }

        /// <summary>
        ///     Tests that indexer throws when count is zero
        /// </summary>
        [Fact]
        public void Indexer_Throws_WhenCountZero()
        {
            RangePtrAccessor<int> accessor = new RangePtrAccessor<int>(new IntPtr(1), 0);
            Assert.Throws<CustomIndexOutOfRangeException>(() => accessor[0]);
        }
    }
}
