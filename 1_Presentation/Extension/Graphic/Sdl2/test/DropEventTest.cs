// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DropEventTest.cs
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

using Alis.Extension.Graphic.Sdl2.Structs;
using Alis.Extension.Graphic.Sdl2.Test.Attributes;
using System.Runtime.InteropServices;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    ///     Contract tests for the <see cref="DropEvent" /> blittable struct.
    /// </summary>
    public class DropEventTest
    {
        /// <summary>
        ///     Verifies that DropEvent is a value type.
        /// </summary>
        [RequireSdl2ImageFact]
        public void DropEvent_ShouldBeValueType()
        {
            Assert.True(typeof(DropEvent).IsValueType);
        }

        /// <summary>
        ///     Verifies that DropEvent has sequential layout.
        /// </summary>
        [RequireSdl2ImageFact]
        public void DropEvent_ShouldHaveSequentialLayout()
        {
            StructLayoutAttribute attribute = typeof(DropEvent).StructLayoutAttribute;

            Assert.NotNull(attribute);
            Assert.Equal(LayoutKind.Sequential, attribute.Value);
        }

        /// <summary>
        ///     Verifies that default DropEvent has zero type.
        /// </summary>
        [RequireSdl2ImageFact]
        public void DefaultInstance_Type_ShouldBeZero()
        {
            DropEvent dropEvent = default;

            Assert.Equal(0, (int)dropEvent.type);
        }

        /// <summary>
        ///     Verifies that default DropEvent has zero timestamp.
        /// </summary>
        [RequireSdl2ImageFact]
        public void DefaultInstance_Timestamp_ShouldBeZero()
        {
            DropEvent dropEvent = default;

            Assert.Equal(0u, dropEvent.timestamp);
        }

        /// <summary>
        ///     Verifies that File property can be set and read.
        /// </summary>
        [RequireSdl2ImageFact]
        public void File_ShouldBeSettable()
        {
            DropEvent dropEvent = default;
            System.IntPtr expected = new System.IntPtr(12345);

            dropEvent.File = expected;

            Assert.Equal(expected, dropEvent.File);
        }

        /// <summary>
        ///     Verifies that default DropEvent has zero windowID.
        /// </summary>
        [RequireSdl2ImageFact]
        public void DefaultInstance_WindowID_ShouldBeZero()
        {
            DropEvent dropEvent = default;

            Assert.Equal(0u, dropEvent.windowID);
        }
    }
}
