// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImVectorRemainingCoverageTests.cs
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
    ///     The im vector remaining coverage tests class
    /// </summary>
    public class ImVectorRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that default size should be zero
        /// </summary>
        [Fact]
        public void DefaultSize_ShouldBeZero()
        {
            ImVector vector = default;
            Assert.Equal(0, vector.Size);
        }

        /// <summary>
        ///     Tests that default capacity should be zero
        /// </summary>
        [Fact]
        public void DefaultCapacity_ShouldBeZero()
        {
            ImVector vector = default;
            Assert.Equal(0, vector.Capacity);
        }

        /// <summary>
        ///     Tests that default data should be zero
        /// </summary>
        [Fact]
        public void DefaultData_ShouldBeZero()
        {
            ImVector vector = default;
            Assert.Equal(IntPtr.Zero, vector.Data);
        }

        /// <summary>
        ///     Tests that constructor should set properties
        /// </summary>
        [Fact]
        public void Constructor_ShouldSetProperties()
        {
            IntPtr data = new IntPtr(42);
            ImVector vector = new ImVector(5, 10, data);
            Assert.Equal(5, vector.Size);
            Assert.Equal(10, vector.Capacity);
            Assert.Equal(data, vector.Data);
        }

        /// <summary>
        ///     Tests that properties should be mutable
        /// </summary>
        [Fact]
        public void Properties_ShouldBeMutable()
        {
            ImVector vector = default;
            vector.Size = 7;
            vector.Capacity = 14;
            IntPtr data = new IntPtr(99);
            vector.Data = data;
            Assert.Equal(7, vector.Size);
            Assert.Equal(14, vector.Capacity);
            Assert.Equal(data, vector.Data);
        }
    }
}
