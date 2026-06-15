// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SizeEventTest.cs
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
    ///     Tests for SizeEvent and SizeEventArgs.
    /// </summary>
    public class SizeEventTest
    {
        /// <summary>
        ///     Tests SizeEvent default field values.
        /// </summary>
        [Fact]
        public void SizeEvent_Default_HasZeroValues()
        {
            SizeEvent e = new SizeEvent();
            Assert.Equal(0u, e.Width);
            Assert.Equal(0u, e.Height);
        }

        /// <summary>
        ///     Tests SizeEventArgs constructor sets properties from SizeEvent.
        /// </summary>
        [Fact]
        public void SizeEventArgs_Constructor_SetsProperties()
        {
            SizeEvent e = new SizeEvent { Width = 800, Height = 600 };
            SizeEventArgs args = new SizeEventArgs(e);
            Assert.Equal(800u, args.Width);
            Assert.Equal(600u, args.Height);
        }

        /// <summary>
        ///     Tests SizeEventArgs ToString includes property names.
        /// </summary>
        [Fact]
        public void SizeEventArgs_ToString_IncludesPropertyNames()
        {
            SizeEvent e = new SizeEvent { Width = 1024, Height = 768 };
            SizeEventArgs args = new SizeEventArgs(e);
            string str = args.ToString();
            Assert.Contains("Width", str);
            Assert.Contains("Height", str);
        }
    }
}
