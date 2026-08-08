// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Vec2Test.cs
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
    ///     Unit tests for the Vec2 struct.
    /// </summary>
    public class Vec2Test
    {
        /// <summary>
        ///     Tests the constructor and field assignment.
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Constructor_AssignsFields()
        {
            Vec2 v = new Vec2(1.5f, 2.5f);
            Assert.Equal(1.5f, v.X, 5);
            Assert.Equal(2.5f, v.Y, 5);
        }

        /// <summary>
        ///     Tests the implicit cast from Vector2F.
        /// </summary>
        [RequireCSfmlSystemFact]
        public void ImplicitCast_FromVector2F_Works()
        {
            Vector2F vec2f = new Vector2F(3.5f, 4.5f);
            Vec2 v = vec2f;
            Assert.Equal(3.5f, v.X, 5);
            Assert.Equal(4.5f, v.Y, 5);
        }
    }
}