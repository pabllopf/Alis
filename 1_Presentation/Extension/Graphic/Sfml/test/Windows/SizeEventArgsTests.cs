// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SizeEventArgsTests.cs
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
    ///     Unit tests for the SizeEventArgs class.
    /// </summary>
    public class SizeEventArgsTests
    {
        /// <summary>
        ///     Tests that the constructor copies the event fields.
        /// </summary>
        [Fact]
        public void Constructor_WithEvent_AssignsFields()
        {
            SizeEvent e = new SizeEvent { Width = 800u, Height = 600u };
            SizeEventArgs args = new SizeEventArgs(e);
            Assert.Equal(800u, args.Width);
            Assert.Equal(600u, args.Height);
        }

        /// <summary>
        ///     Tests that the properties can be set after construction.
        /// </summary>
        [Fact]
        public void Properties_Setters_RoundTrip()
        {
            SizeEventArgs args = new SizeEventArgs(new SizeEvent());
            args.Width = 1024u;
            args.Height = 768u;
            Assert.Equal(1024u, args.Width);
            Assert.Equal(768u, args.Height);
        }

        /// <summary>
        ///     Tests the ToString output.
        /// </summary>
        [Fact]
        public void ToString_ReturnsDescriptiveString()
        {
            SizeEventArgs args = new SizeEventArgs(new SizeEvent { Width = 3u, Height = 4u });
            Assert.Equal("[SizeEventArgs] Width(3) Height(4)", args.ToString());
        }

        /// <summary>
        ///     Tests that instances are EventArgs.
        /// </summary>
        [Fact]
        public void Instance_IsEventArgs()
        {
            SizeEventArgs args = new SizeEventArgs(new SizeEvent());
            Assert.IsAssignableFrom<EventArgs>(args);
        }
    }
}
