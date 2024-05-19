// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WorldManifoldTest.cs
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

using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collision.NarrowPhase;
using Xunit;

namespace Alis.Core.Physic.Test.Collision.NarrowPhase
{
    /// <summary>
    ///     The world manifold test class
    /// </summary>
    public class WorldManifoldTest
    {
        /// <summary>
        /// Tests that initialize should initialize correctly
        /// </summary>
        [Fact]
        public void Initialize_ShouldInitializeCorrectly()
        {
            // Arrange
            Manifold manifold = new Manifold();
            Transform xfA = new Transform();
            float radiusA = 1.0f;
            Transform xfB = new Transform();
            float radiusB = 1.0f;
            
            // Act
            WorldManifold.Initialize(ref manifold, ref xfA, radiusA, ref xfB, radiusB, out Vector2 normal, out Vector2[] points);
            
            // Assert
            Assert.Equal(new Vector2(0,0 ), normal);
        }
    }
}