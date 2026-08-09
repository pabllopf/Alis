// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PolygonShapeRemainingCoverageTests.cs
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
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions.Shapes
{
    /// <summary>
    ///     The polygon shape remaining coverage tests class
    /// </summary>
    public class PolygonShapeRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that compute submerged area with quad partially submerged returns partial area
        /// </summary>
        [Fact]
        public void ComputeSubmergedArea_QuadPartiallySubmerged_ReturnsPartialArea()
        {
            Vertices vertices = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(2, 0),
                new Vector2F(2, 2),
                new Vector2F(0, 2)
            };
            PolygonShape polygon = new PolygonShape(vertices, 1.0f);
            ControllerTransform transform = ControllerTransform.Identity;
            Vector2F normal = new Vector2F(0, 1);

            float area = polygon.ComputeSubmergedArea(ref normal, 1, ref transform, out Vector2F sc);

            Assert.True(area > 0);
            Assert.True(area <= polygon.MassData.Mass);
        }

        /// <summary>
        ///     Tests that compute submerged area with pentagon partially submerged returns partial area
        /// </summary>
        [Fact]
        public void ComputeSubmergedArea_PentagonPartiallySubmerged_ReturnsPartialArea()
        {
            Vertices vertices = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(2, 0),
                new Vector2F(3, 1),
                new Vector2F(2, 2),
                new Vector2F(0, 2)
            };
            PolygonShape polygon = new PolygonShape(vertices, 1.0f);
            ControllerTransform transform = ControllerTransform.Identity;
            Vector2F normal = new Vector2F(0, 1);

            float area = polygon.ComputeSubmergedArea(ref normal, 1, ref transform, out Vector2F sc);

            Assert.True(area > 0);
        }
    }
}
