// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TextEventArgsCoverageTests.cs
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
    ///     The text event args coverage tests class
    /// </summary>
    public class TextEventArgsCoverageTests
    {
        /// <summary>
        ///     Tests that the constructor with an event converts the unicode codepoint
        /// </summary>
        [Fact]
        public void TextEventArgs_ConstructorWithEvent_ConvertsUnicodeCodepoint()
        {
            TextEventArgs args = new TextEventArgs(new TextEvent { Unicode = 0x41u });

            Assert.Equal("A", args.Unicode);
        }

        /// <summary>
        ///     Tests that the set property stores values correctly
        /// </summary>
        [Fact]
        public void TextEventArgs_SetProperty_StoresValueCorrectly()
        {
            TextEventArgs args = new TextEventArgs(new TextEvent { Unicode = 0x41u });

            args.Unicode = "Z";

            Assert.Equal("Z", args.Unicode);
        }

        /// <summary>
        ///     Tests that the to string returns the expected description
        /// </summary>
        [Fact]
        public void TextEventArgs_ToString_ReturnsExpectedDescription()
        {
            TextEventArgs args = new TextEventArgs(new TextEvent { Unicode = 0x42u });

            Assert.Equal("[TextEventArgs] Unicode(B)", args.ToString());
        }

        /// <summary>
        ///     Tests that the type derives from event args
        /// </summary>
        [Fact]
        public void TextEventArgs_DerivesFromEventArgs_IsEventArgs()
        {
            TextEventArgs args = new TextEventArgs(new TextEvent());

            Assert.IsAssignableFrom<EventArgs>(args);
        }
    }
}