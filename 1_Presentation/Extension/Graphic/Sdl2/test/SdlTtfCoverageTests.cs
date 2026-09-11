// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SdlTtfCoverageTests.cs
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
using Alis.Core.Aspect.Math.Definition;
using Alis.Extension.Graphic.Sdl2.Sdl2Ttf;
using Alis.Extension.Graphic.Sdl2.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    ///     Coverage tests for the sdl ttf wrapper class
    /// </summary>
    public class SdlTtfCoverageTests
    {
        /// <summary>
        ///     Opens the sample font and asserts it is valid
        /// </summary>
        /// <returns>The font handle</returns>
        private static IntPtr OpenSampleFont()
        {
            string fontFile = Sdl2TestAssets.Find("FontSample.otf");
            Assert.NotNull(fontFile);

            int initResult = SdlTtf.Init();
            Assert.Equal(0, initResult);

            IntPtr font = SdlTtf.OpenFont(fontFile, 24);
            Assert.NotEqual(IntPtr.Zero, font);

            return font;
        }
    }
}