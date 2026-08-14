// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Ivec2RemainingCoverageTests.cs
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

using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Sfml.Render;
using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    ///     The ivec 2 remaining coverage tests class
    /// </summary>
    public class Ivec2RemainingCoverageTests
    {
        /// <summary>
        ///     Tests that constructor assigns coordinates
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Constructor_AssignsCoordinates()
        {
            Ivec2 vec = new Ivec2(1, 2);

            Assert.Equal(1, vec.X);
            Assert.Equal(2, vec.Y);
        }

        /// <summary>
        ///     Tests that constructor from vector 2 f assigns components
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Constructor_FromVector2F_AssignsComponents()
        {
            Vector2F source = new Vector2F(3.0f, 4.0f);

            Ivec2 vec = new Ivec2(source);

            Assert.Equal(3, vec.X);
            Assert.Equal(4, vec.Y);
        }

        /// <summary>
        ///     Tests that implicit cast from vector 2 f assigns components
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void ImplicitCast_FromVector2F_AssignsComponents()
        {
            Vector2F source = new Vector2F(5.0f, 6.0f);

            Ivec2 vec = source;

            Assert.Equal(5, vec.X);
            Assert.Equal(6, vec.Y);
        }
    }
}
