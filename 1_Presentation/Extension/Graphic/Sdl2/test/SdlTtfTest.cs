// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SdlTtfTest.cs
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

using Alis.Extension.Graphic.Sdl2.Sdl2Ttf;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    /// The sdl ttf test class
    /// </summary>
    public class SdlTtfTest
    {
        /// <summary>
        /// Tests that should have correct constant values
        /// </summary>
        [Fact]
        public void ShouldHaveCorrectConstantValues()
        {
            Assert.Equal(0xFEFF, SdlTtf.UnicodeBomNative);
            Assert.Equal(0xFFFE, SdlTtf.UnicodeBomSwapped);
            Assert.Equal(0x00, SdlTtf.TtfStyleNormal);
            Assert.Equal(0x01, SdlTtf.TtfStyleBold);
            Assert.Equal(0x02, SdlTtf.TtfStyleItalic);
            Assert.Equal(0x04, SdlTtf.TtfStyleUnderline);
            Assert.Equal(0x08, SdlTtf.TtfStyleStrikethrough);
            Assert.Equal(0, SdlTtf.TtfHintingNormal);
            Assert.Equal(1, SdlTtf.TtfHintingLight);
            Assert.Equal(2, SdlTtf.TtfHintingMono);
            Assert.Equal(3, SdlTtf.TtfHintingNone);
            Assert.Equal(4, SdlTtf.TtfHintingLightSubpixel);
        }
    }
}
