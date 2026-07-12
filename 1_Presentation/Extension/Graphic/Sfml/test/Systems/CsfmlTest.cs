// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CsfmlTest.cs
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

using Alis.Extension.Graphic.Sfml.Systems;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Systems
{
    /// <summary>
    ///     Tests the <see cref="Csfml" /> class.
    /// </summary>
    public class CsfmlTest
    {
        /// <summary>
        /// Tests that audio returns csfml audio
        /// </summary>
        [Fact]
        public void Audio_ReturnsCsfmlAudio() => Assert.Equal("csfml-audio", Csfml.Audio);

        /// <summary>
        /// Tests that graphics returns csfml graphics
        /// </summary>
        [Fact]
        public void Graphics_ReturnsCsfmlGraphics() => Assert.Equal("csfml-graphics", Csfml.Graphics);

        /// <summary>
        /// Tests that system returns csfml system
        /// </summary>
        [Fact]
        public void System_ReturnsCsfmlSystem() => Assert.Equal("csfml-system", Csfml.System);

        /// <summary>
        /// Tests that window returns csfml window
        /// </summary>
        [Fact]
        public void Window_ReturnsCsfmlWindow() => Assert.Equal("csfml-window", Csfml.Window);
    }
}
