// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GraphicsExtensiveParametrizedTest.cs
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

using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Alis.Core.Graphic.Test
{
    /// <summary>
    ///     Comprehensive parametrized tests for graphics system.
    /// </summary>
    public class GraphicsExtensiveParametrizedTest
    {
        /// <summary>
        ///     Generates the resolution combinations
        /// </summary>
        /// <returns>An enumerable of object array</returns>
        public static IEnumerable<object[]> GenerateResolutionCombinations()
        {
            int[] widths = {320, 640, 800, 1024, 1280, 1920};
            int[] heights = {240, 480, 600, 768, 720, 1080};

            foreach (int w in widths)
            {
                foreach (int h in heights.Take(3))
                {
                    yield return new object[] {w, h};
                }
            }
        }

        /// <summary>
        ///     Tests that graphics resolution combinations
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        [Theory, MemberData(nameof(GenerateResolutionCombinations))]
        public void Graphics_ResolutionCombinations(int width, int height)
        {
            Assert.True(width > 0);
            Assert.True(height > 0);
        }

        /// <summary>
        ///     Generates the color combinations
        /// </summary>
        /// <returns>An enumerable of object array</returns>
        public static IEnumerable<object[]> GenerateColorCombinations()
        {
            byte[] channels = {0, 64, 128, 192, 255};

            foreach (byte r in channels)
            {
                foreach (byte g in channels.Take(3))
                {
                    foreach (byte b in channels.Take(3))
                    {
                        yield return new object[] {r, g, b};
                    }
                }
            }
        }

        /// <summary>
        ///     Tests that graphics color combinations
        /// </summary>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        [Theory, MemberData(nameof(GenerateColorCombinations))]
        public void Graphics_ColorCombinations(byte r, byte g, byte b)
        {
            Assert.InRange(r, (byte) 0, byte.MaxValue);
            Assert.InRange(g, (byte) 0, byte.MaxValue);
            Assert.InRange(b, (byte) 0, byte.MaxValue);
        }
    }
}