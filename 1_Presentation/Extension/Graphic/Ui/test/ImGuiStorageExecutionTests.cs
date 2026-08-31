// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiStorageExecutionTests.cs
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
using Alis.Extension.Graphic.Ui;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im gui storage execution tests class
    /// </summary>
    public class ImGuiStorageExecutionTests
    {
        /// <summary>
        ///     Tests that the data property round-trips an ImVector value
        /// </summary>
        [Fact]
        public void ImGuiStorage_Data_RoundTripsImVector()
        {
            ImGuiStorage storage = default;
            ImVector expected = new ImVector(5, 10, new IntPtr(12345));

            storage.Data = expected;

            Assert.Equal(5, storage.Data.Size);
            Assert.Equal(10, storage.Data.Capacity);
            Assert.Equal(new IntPtr(12345), storage.Data.Data);
        }

        /// <summary>
        ///     Tests that the data property can be overwritten
        /// </summary>
        [Fact]
        public void ImGuiStorage_Data_OverwritesPreviousValue()
        {
            ImGuiStorage storage = new ImGuiStorage { Data = new ImVector(1, 2, IntPtr.Zero) };

            storage.Data = new ImVector(3, 4, new IntPtr(9));

            Assert.Equal(3, storage.Data.Size);
            Assert.Equal(4, storage.Data.Capacity);
            Assert.Equal(new IntPtr(9), storage.Data.Data);
        }

        /// <summary>
        ///     Tests that the data property defaults to an empty ImVector
        /// </summary>
        [Fact]
        public void ImGuiStorage_Default_DataIsZeroedImVector()
        {
            ImGuiStorage storage = default;

            Assert.Equal(0, storage.Data.Size);
            Assert.Equal(0, storage.Data.Capacity);
            Assert.Equal(IntPtr.Zero, storage.Data.Data);
        }

        /// <summary>
        ///     Tests that the struct is a value type and copies are independent
        /// </summary>
        [Fact]
        public void ImGuiStorage_IsValueType_CopiesAreIndependent()
        {
            ImGuiStorage original = new ImGuiStorage { Data = new ImVector(1, 2, IntPtr.Zero) };
            ImGuiStorage copy = original;

            copy.Data = new ImVector(9, 9, new IntPtr(77));

            Assert.Equal(1, original.Data.Size);
            Assert.Equal(9, copy.Data.Size);
        }
    }
}
