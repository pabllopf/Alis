// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TextEventTest.cs
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
    ///     Tests for TextEvent and TextEventArgs.
    /// </summary>
    public class TextEventTest
    {
        /// <summary>
        ///     Tests TextEvent default field values.
        /// </summary>
        [Fact]
        public void TextEvent_Default_HasZeroValue()
        {
            TextEvent e = new TextEvent();
            Assert.Equal(0u, e.Unicode);
        }

        /// <summary>
        ///     Tests TextEventArgs constructor sets Unicode from TextEvent.
        /// </summary>
        [Fact]
        public void TextEventArgs_Constructor_SetsUnicode()
        {
            TextEvent e = new TextEvent { Unicode = 65 };
            TextEventArgs args = new TextEventArgs(e);
            Assert.Equal("A", args.Unicode);
        }

        /// <summary>
        ///     Tests TextEventArgs ToString includes property name.
        /// </summary>
        [Fact]
        public void TextEventArgs_ToString_IncludesUnicode()
        {
            TextEvent e = new TextEvent { Unicode = 65 };
            TextEventArgs args = new TextEventArgs(e);
            string str = args.ToString();
            Assert.Contains("Unicode", str);
        }
    }
}
