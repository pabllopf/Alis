// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Vec4RemainingCoverageTests.cs
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

using Alis.Extension.Graphic.Sfml.Render;
using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    ///     The vec 4 remaining coverage tests class
    /// </summary>
    public class Vec4RemainingCoverageTests
    {
        /// <summary>
        ///     Tests that constructor assigns coordinates
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Constructor_AssignsCoordinates()
        {
            Vec4 vec = new Vec4(1.0f, 2.0f, 3.0f, 4.0f);

            Assert.Equal(1.0f, vec.X);
            Assert.Equal(2.0f, vec.Y);
            Assert.Equal(3.0f, vec.Z);
            Assert.Equal(4.0f, vec.W);
        }

        /// <summary>
        ///     Tests that constructor from color normalizes components
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Constructor_FromColor_NormalizesComponents()
        {
            Color color = new Color(255, 128, 0, 64);

            Vec4 vec = new Vec4(color);

            Assert.Equal(1.0f, vec.X, 5);
            Assert.Equal(128.0f / 255.0f, vec.Y, 5);
            Assert.Equal(0.0f, vec.Z, 5);
            Assert.Equal(64.0f / 255.0f, vec.W, 5);
        }
    }
}
