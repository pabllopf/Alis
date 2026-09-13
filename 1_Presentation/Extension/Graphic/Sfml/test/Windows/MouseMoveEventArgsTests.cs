// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MouseMoveEventArgsTests.cs
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
using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    /// <summary>
    ///     Unit tests for the MouseMoveEventArgs class.
    /// </summary>
    public class MouseMoveEventArgsTests
    {
        /// <summary>
        ///     Tests that the constructor copies the event fields.
        /// </summary>
        [Fact]
        public void Constructor_WithEvent_AssignsFields()
        {
            MouseMoveEvent e = new MouseMoveEvent { X = 120, Y = 340 };
            MouseMoveEventArgs args = new MouseMoveEventArgs(e);
            Assert.Equal(120, args.X);
            Assert.Equal(340, args.Y);
        }

        /// <summary>
        ///     Tests that the properties can be set after construction.
        /// </summary>
        [Fact]
        public void Properties_Setters_RoundTrip()
        {
            MouseMoveEventArgs args = new MouseMoveEventArgs(new MouseMoveEvent());
            args.X = -5;
            args.Y = 2;
            Assert.Equal(-5, args.X);
            Assert.Equal(2, args.Y);
        }

        /// <summary>
        ///     Tests the ToString output.
        /// </summary>
        [Fact]
        public void ToString_ReturnsDescriptiveString()
        {
            MouseMoveEventArgs args = new MouseMoveEventArgs(new MouseMoveEvent { X = 7, Y = 9 });
            Assert.Equal("[MouseMoveEventArgs] X(7) Y(9)", args.ToString());
        }

        /// <summary>
        ///     Tests that instances are EventArgs.
        /// </summary>
        [Fact]
        public void Instance_IsEventArgs()
        {
            MouseMoveEventArgs args = new MouseMoveEventArgs(new MouseMoveEvent());
            Assert.IsAssignableFrom<EventArgs>(args);
        }
    }
}
