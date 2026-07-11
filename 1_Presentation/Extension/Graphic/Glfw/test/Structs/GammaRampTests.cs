// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GammaRampTests.cs
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
using Alis.Extension.Graphic.Glfw.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test.Structs
{
    public class GammaRampTests
    {
        [Fact]
        public void Constructor_WithValidArrays_SetsProperties()
        {
            ushort[] red = new ushort[] { 0, 128, 255 };
            ushort[] green = new ushort[] { 0, 128, 255 };
            ushort[] blue = new ushort[] { 0, 128, 255 };

            GammaRamp ramp = new GammaRamp(red, green, blue);

            Assert.Equal(red, ramp.Red);
            Assert.Equal(green, ramp.Green);
            Assert.Equal(blue, ramp.Blue);
            Assert.Equal(3u, ramp.Size);
        }

        [Fact]
        public void Constructor_WithUnequalLengthArrays_ThrowsArgumentException()
        {
            ushort[] red = new ushort[] { 0, 128, 255 };
            ushort[] green = new ushort[] { 0, 128 };
            ushort[] blue = new ushort[] { 0, 128, 255 };

            Assert.Throws<ArgumentException>(() => new GammaRamp(red, green, blue));
        }

        [Fact]
        public void Constructor_WithAllDifferentLengths_ThrowsArgumentException()
        {
            ushort[] red = new ushort[] { 0, 128 };
            ushort[] green = new ushort[] { 0, 128, 255 };
            ushort[] blue = new ushort[] { 0, 128, 255, 512 };

            Assert.Throws<ArgumentException>(() => new GammaRamp(red, green, blue));
        }

        [Fact]
        public void Constructor_WithNullArrays_ThrowsNullReferenceException()
        {
            Assert.Throws<NullReferenceException>(() => new GammaRamp(null, new ushort[0], new ushort[0]));
        }

        [Fact]
        public void Constructor_WithSingleElementArrays_SetsSizeToOne()
        {
            ushort[] red = new ushort[] { 100 };
            ushort[] green = new ushort[] { 100 };
            ushort[] blue = new ushort[] { 100 };

            GammaRamp ramp = new GammaRamp(red, green, blue);

            Assert.Equal(1u, ramp.Size);
        }

        [Fact]
        public void Constructor_WithEmptyArrays_SetsSizeToZero()
        {
            ushort[] red = Array.Empty<ushort>();
            ushort[] green = Array.Empty<ushort>();
            ushort[] blue = Array.Empty<ushort>();

            GammaRamp ramp = new GammaRamp(red, green, blue);

            Assert.Equal(0u, ramp.Size);
        }

        [Fact]
        public void Fields_AreMutable()
        {
            GammaRamp ramp = new GammaRamp(new ushort[] { 1 }, new ushort[] { 2 }, new ushort[] { 3 });

            ramp.Red = new ushort[] { 10 };
            ramp.Green = new ushort[] { 20 };
            ramp.Blue = new ushort[] { 30 };

            Assert.Equal(10, ramp.Red[0]);
            Assert.Equal(20, ramp.Green[0]);
            Assert.Equal(30, ramp.Blue[0]);
        }
    }
}
