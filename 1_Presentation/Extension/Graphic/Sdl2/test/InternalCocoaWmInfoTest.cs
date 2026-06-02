// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:InternalCocoaWmInfoTest.cs
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

using Xunit;
using System;
using Alis.Extension.Graphic.Sdl2.Structs;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    public class InternalCocoaWmInfoTest
    {
        [Fact]
        public void ShouldDefaultToZero()
        {
            var obj = new InternalCocoaWmInfo();
            Assert.Equal(IntPtr.Zero, obj.Window);
        }

        [Fact]
        public void ShouldAssignAndRetrieveProperties()
        {
            var obj = new InternalCocoaWmInfo();
            var testWindow = IntPtr.Zero + 1;
            obj.Window = testWindow;
            Assert.Equal(testWindow, obj.Window);
        }
    }
}
