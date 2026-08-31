// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SysWmEventCoverageTests.cs
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
    ///     The sys wm event coverage tests class
    /// </summary>
    public class SysWmEventCoverageTests
    {
        /// <summary>
        ///     Tests that the msg property round-trips an arbitrary pointer
        /// </summary>
        [Fact]
        public void SysWmEvent_MsgProperty_RoundTripsPointer()
        {
            SysWmEvent sysWmEvent = default;
            IntPtr expected = new IntPtr(0xCAFE);

            sysWmEvent.Msg = expected;

            Assert.Equal(expected, sysWmEvent.Msg);
        }

        /// <summary>
        ///     Tests that the msg property can be overwritten
        /// </summary>
        [Fact]
        public void SysWmEvent_MsgProperty_OverwritesPreviousValue()
        {
            SysWmEvent sysWmEvent = new SysWmEvent { Msg = new IntPtr(1) };

            sysWmEvent.Msg = new IntPtr(2);

            Assert.Equal(new IntPtr(2), sysWmEvent.Msg);
        }

        /// <summary>
        ///     Tests that the msg property defaults to zero
        /// </summary>
        [Fact]
        public void SysWmEvent_Default_MsgIsZero()
        {
            SysWmEvent sysWmEvent = default;

            Assert.Equal(IntPtr.Zero, sysWmEvent.Msg);
        }

        /// <summary>
        ///     Tests that the struct is a value type and copies are independent
        /// </summary>
        [Fact]
        public void SysWmEvent_IsValueType_CopiesAreIndependent()
        {
            SysWmEvent original = new SysWmEvent { Msg = new IntPtr(10) };
            SysWmEvent copy = original;

            copy.Msg = new IntPtr(20);

            Assert.Equal(new IntPtr(10), original.Msg);
            Assert.Equal(new IntPtr(20), copy.Msg);
        }
    }
}
