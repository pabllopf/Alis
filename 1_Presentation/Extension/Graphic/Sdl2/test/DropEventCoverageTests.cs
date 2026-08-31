// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DropEventCoverageTests.cs
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
using Alis.Extension.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    ///     The drop event coverage tests class
    /// </summary>
    public class DropEventCoverageTests
    {
        /// <summary>
        ///     Tests that the file property can store and retrieve an arbitrary pointer
        /// </summary>
        [Fact]
        public void DropEvent_FileProperty_RoundTripsPointer()
        {
            DropEvent dropEvent = default;
            IntPtr expected = new IntPtr(12345);

            dropEvent.File = expected;

            Assert.Equal(expected, dropEvent.File);
        }

        /// <summary>
        ///     Tests that the file property can be overwritten with a new pointer value
        /// </summary>
        [Fact]
        public void DropEvent_FileProperty_OverwritesPreviousValue()
        {
            DropEvent dropEvent = new DropEvent { File = new IntPtr(1) };

            dropEvent.File = new IntPtr(2);

            Assert.Equal(new IntPtr(2), dropEvent.File);
        }

        /// <summary>
        ///     Tests that the file property default value is zero
        /// </summary>
        [Fact]
        public void DropEvent_Default_FileIsZero()
        {
            DropEvent dropEvent = default;

            Assert.Equal(IntPtr.Zero, dropEvent.File);
        }

        /// <summary>
        ///     Tests that DropEvent is a value type and copies are independent
        /// </summary>
        [Fact]
        public void DropEvent_IsValueType_CopiesAreIndependent()
        {
            DropEvent original = new DropEvent { File = new IntPtr(10) };
            DropEvent copy = original;

            copy.File = new IntPtr(20);

            Assert.Equal(new IntPtr(10), original.File);
            Assert.Equal(new IntPtr(20), copy.File);
        }
    }
}
