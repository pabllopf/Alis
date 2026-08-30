// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImgAnimationCoverageTests.cs
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
using Alis.Extension.Graphic.Sdl2.Sdl2Image;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    ///     The img animation coverage tests class
    /// </summary>
    public class ImgAnimationCoverageTests
    {
        /// <summary>
        ///     Tests that default initialization properties have default values
        /// </summary>
        [Fact]
        public void ImgAnimation_DefaultInitialization_PropertiesHaveDefaultValues()
        {
            ImgAnimation animation = default(ImgAnimation);

            Assert.Equal(0, animation.W);
            Assert.Equal(0, animation.H);
            Assert.Equal(IntPtr.Zero, animation.Frames);
            Assert.Equal(IntPtr.Zero, animation.Delays);
        }

        /// <summary>
        ///     Tests that set properties stores values correctly
        /// </summary>
        [Fact]
        public void ImgAnimation_SetProperties_StoresValuesCorrectly()
        {
            ImgAnimation animation = new ImgAnimation
            {
                W = 100,
                H = 200,
                Frames = new IntPtr(1),
                Delays = new IntPtr(2)
            };

            Assert.Equal(100, animation.W);
            Assert.Equal(200, animation.H);
            Assert.Equal(new IntPtr(1), animation.Frames);
            Assert.Equal(new IntPtr(2), animation.Delays);
        }

        /// <summary>
        ///     Tests that the struct is a value type and copies are independent
        /// </summary>
        [Fact]
        public void ImgAnimation_IsValueType_CopyIsIndependent()
        {
            ImgAnimation original = new ImgAnimation { W = 100 };
            ImgAnimation copy = original;

            copy.W = 200;

            Assert.Equal(100, original.W);
            Assert.Equal(200, copy.W);
        }
    }
}