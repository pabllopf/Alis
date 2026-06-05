// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TouchEventTest.cs
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

using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    public class TouchEventTest
    {
        [Fact]
        public void TouchEvent_Default_HasZeroValues()
        {
            TouchEvent e = new TouchEvent();
            Assert.Equal(0u, e.Finger);
            Assert.Equal(0, e.X);
            Assert.Equal(0, e.Y);
        }

        [Fact]
        public void TouchEventArgs_Constructor_SetsProperties()
        {
            TouchEvent e = new TouchEvent { Finger = 1u, X = 50, Y = 100 };
            TouchEventArgs args = new TouchEventArgs(e);
            Assert.Equal(1u, args.Finger);
            Assert.Equal(50, args.X);
            Assert.Equal(100, args.Y);
        }

        [Fact]
        public void TouchEventArgs_ToString_IncludesPropertyNames()
        {
            TouchEvent e = new TouchEvent { Finger = 0u };
            TouchEventArgs args = new TouchEventArgs(e);
            Assert.Contains("Finger", args.ToString());
            Assert.Contains("X", args.ToString());
            Assert.Contains("Y", args.ToString());
        }
    }
}
