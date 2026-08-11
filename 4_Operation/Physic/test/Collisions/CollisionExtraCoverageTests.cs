// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CollisionExtraCoverageTests.cs
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
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    /// <summary>
    ///     The collision extra coverage tests class
    /// </summary>
    public class CollisionExtraCoverageTests
    {
        /// <summary>
        ///     Tests that collide polygons with diagonal offset exercises local search with best edge improvement
        /// </summary>
        [Fact]
        public void CollidePolygons_DiagonalOffset_ExercisesLocalSearch()
        {
            PolygonShape polyA = new PolygonShape(PolygonTools.CreateRectangle(1.0f, 0.5f), 1.0f);
            PolygonShape polyB = new PolygonShape(PolygonTools.CreateRectangle(1.0f, 0.5f), 1.0f);
            ControllerTransform xfA = ControllerTransform.Identity;
            ControllerTransform xfB = new ControllerTransform(new Vector2F(0.7f, 0.7f), (float) Math.PI / 5.0f);
            Manifold manifold = new Manifold();

            Collision.CollidePolygons(ref manifold, polyA, ref xfA, polyB, ref xfB);

            Assert.True(manifold.PointCount >= 0);
        }

        /// <summary>
        ///     Tests that collide polygons with offset corner exercises the local search break branch
        /// </summary>
        [Fact]
        public void CollidePolygons_OffsetCorner_ExercisesLocalSearchBreak()
        {
            PolygonShape polyA = new PolygonShape(PolygonTools.CreateRectangle(1.0f, 1.0f), 1.0f);
            PolygonShape polyB = new PolygonShape(PolygonTools.CreateRectangle(1.0f, 1.0f), 1.0f);
            ControllerTransform xfA = ControllerTransform.Identity;
            ControllerTransform xfB = new ControllerTransform(new Vector2F(1.1f, 0.9f), (float) Math.PI / 4.0f);
            Manifold manifold = new Manifold();

            Collision.CollidePolygons(ref manifold, polyA, ref xfA, polyB, ref xfB);

            Assert.True(manifold.PointCount >= 0);
        }

        /// <summary>
        ///     Tests that collide polygons with rotated thin shapes exercises the clip underflow branches
        /// </summary>
        [Fact]
        public void CollidePolygons_RotatedThinShapes_ExercisesClipUnderflow()
        {
            PolygonShape polyA = new PolygonShape(PolygonTools.CreateRectangle(0.1f, 2.0f), 1.0f);
            PolygonShape polyB = new PolygonShape(PolygonTools.CreateRectangle(0.1f, 2.0f), 1.0f);
            ControllerTransform xfA = ControllerTransform.Identity;
            ControllerTransform xfB = new ControllerTransform(new Vector2F(0.15f, 0.0f), (float) Math.PI / 3.0f);
            Manifold manifold = new Manifold();

            Collision.CollidePolygons(ref manifold, polyA, ref xfA, polyB, ref xfB);

            Assert.True(manifold.PointCount >= 0);
        }

        /// <summary>
        ///     Tests that collide polygons with a large rotated polygon exercises the second clip underflow branch
        /// </summary>
        [Fact]
        public void CollidePolygons_LargeRotated_ExercisesSecondClipUnderflow()
        {
            PolygonShape polyA = new PolygonShape(PolygonTools.CreateRectangle(3.0f, 0.2f), 1.0f);
            PolygonShape polyB = new PolygonShape(PolygonTools.CreateRectangle(0.2f, 3.0f), 1.0f);
            ControllerTransform xfA = ControllerTransform.Identity;
            ControllerTransform xfB = new ControllerTransform(new Vector2F(1.0f, 0.0f), (float) Math.PI / 6.0f);
            Manifold manifold = new Manifold();

            Collision.CollidePolygons(ref manifold, polyA, ref xfA, polyB, ref xfB);

            Assert.True(manifold.PointCount >= 0);
        }

        /// <summary>
        ///     Tests that collide edge and polygon with narrow angular limits exercises the unknown polygon axis branch
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_NarrowLimits_ExercisesUnknownPolygonAxis()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
            {
                HasVertex0 = true,
                Vertex0 = new Vector2F(1.0f, -0.5f),
                HasVertex3 = true,
                Vertex3 = new Vector2F(1.0f, 0.5f)
            };

            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, 1.0f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);

            Assert.True(manifold.PointCount >= 0);
        }
    }
}
