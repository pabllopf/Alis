// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MouseWheelScrollEventTests.cs
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
    /// <summary>
    ///     The mouse wheel scroll event tests class
    /// </summary>
    public class MouseWheelScrollEventTests
    {
        /// <summary>
        ///     Tests that can set fields
        /// </summary>
        [Fact]
        public void CanSetFields()
        {
            MouseWheelScrollEvent evt = new MouseWheelScrollEvent {Wheel = Mouse.Wheel.VerticalWheel, Delta = 1.5f, X = 10, Y = 20};
            Assert.Equal(Mouse.Wheel.VerticalWheel, evt.Wheel);
            Assert.Equal(1.5f, evt.Delta);
            Assert.Equal(10, evt.X);
            Assert.Equal(20, evt.Y);
        }
    }
}