// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ClipboardExecutionTests.cs
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

using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    /// <summary>
    ///     Executes the <see cref="Clipboard" /> wrapper against the real native clipboard of the
    ///     desktop session. The getter is a pure read; the setter test round trips a known value
    ///     and always restores the original contents in a finally block.
    /// </summary>
    public class ClipboardExecutionTests
    {
        /// <summary>
        ///     Tests that the clipboard contents can be read.
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Contents_Get_ReturnsNonNullString()
        {
            string contents = Clipboard.Contents;
            Assert.NotNull(contents);
        }

        /// <summary>
        ///     Tests that the clipboard contents round trip and the original value is restored.
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Contents_SetThenGet_RoundTripsAndRestores()
        {
            string original = Clipboard.Contents;
            try
            {
                Clipboard.Contents = "alis-clipboard-roundtrip";
                Assert.Equal("alis-clipboard-roundtrip", Clipboard.Contents);
            }
            finally
            {
                Clipboard.Contents = original;
            }
        }
    }
}
