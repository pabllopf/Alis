// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Vec2RemainingCoverageTests.cs
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
    ///     The vec 2 remaining coverage tests class
    /// </summary>
    public class Vec2RemainingCoverageTests
    {
        /// <summary>
        ///     Tests that constructor assigns coordinates
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Constructor_AssignsCoordinates()
        {
            Vec2 vec = new Vec2(1.0f, 2.0f);

            Assert.Equal(1.0f, vec.X);
            Assert.Equal(2.0f, vec.Y);
        }

        /// <summary>
        ///     Tests that constructor from vector 2 f assigns components
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Constructor_FromVector2F_AssignsComponents()
        {
            Vector2F source = new Vector2F(3.0f, 4.0f);

            Vec2 vec = new Vec2(source);

            Assert.Equal(3.0f, vec.X);
            Assert.Equal(4.0f, vec.Y);
        }

        /// <summary>
        ///     Tests that implicit cast from vector 2 f assigns components
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void ImplicitCast_FromVector2F_AssignsComponents()
        {
            Vector2F source = new Vector2F(5.0f, 6.0f);

            Vec2 vec = source;

            Assert.Equal(5.0f, vec.X);
            Assert.Equal(6.0f, vec.Y);
        }
    }
}
