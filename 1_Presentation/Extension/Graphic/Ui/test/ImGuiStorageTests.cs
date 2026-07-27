// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiStorageTests.cs
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
    ///     The im gui storage tests class
    /// </summary>
    public class ImGuiStorageTests
    {
        /// <summary>
        ///     Tests that default data should be default im vector
        /// </summary>
        [Fact]
        public void DefaultData_ShouldBeDefaultImVector()
        {
            ImGuiStorage storage = default;
            Assert.Equal(0, storage.Data.Size);
            Assert.Equal(0, storage.Data.Capacity);
            Assert.Equal(IntPtr.Zero, storage.Data.Data);
        }

        /// <summary>
        ///     Tests that data property should be mutable
        /// </summary>
        [Fact]
        public void DataProperty_ShouldBeMutable()
        {
            ImGuiStorage storage = default;
            IntPtr data = new IntPtr(42);
            ImVector vector = new ImVector(5, 10, data);
            storage.Data = vector;
            Assert.Equal(5, storage.Data.Size);
            Assert.Equal(10, storage.Data.Capacity);
            Assert.Equal(data, storage.Data.Data);
        }

        /// <summary>
        ///     Tests that setting data should return same values
        /// </summary>
        [Fact]
        public void SettingData_ShouldReturnSameValues()
        {
            ImGuiStorage storage = default;
            storage.Data = new ImVector(3, 6, IntPtr.Zero);
            Assert.Equal(3, storage.Data.Size);
            Assert.Equal(6, storage.Data.Capacity);
            Assert.Equal(IntPtr.Zero, storage.Data.Data);
        }
    }
}
