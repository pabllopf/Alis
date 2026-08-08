// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CollisionTests.cs
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
    /// The collision tests class
    /// </summary>
    public class CollisionTests
    {
        /// <summary>
        /// Tests that collide polygons local search loop body both branches
        /// </summary>
        [Fact]
        public void CollidePolygons_LocalSearchLoopBody_BothBranches()
        {
            for (int iter = 0; iter < 5000; iter++)
            {
                float wA = ((iter % 20) + 1) * 0.15f;
                float hA = ((iter / 20) % 15 + 1) * 0.15f;
                float wB = ((iter / 300) % 15 + 1) * 0.15f;
                float hB = ((iter / 4500) % 10 + 1) * 0.15f;
                float x = (iter % 80) * 0.06f - 2.4f;
                float rot = (iter % 30) * ((float)Math.PI / 15.0f);
                PolygonShape polyA = new PolygonShape(PolygonTools.CreateRectangle(wA, hA), 1.0f);
                PolygonShape polyB = new PolygonShape(PolygonTools.CreateRectangle(wB, hB), 1.0f);
                ControllerTransform xfA = ControllerTransform.Identity;
                ControllerTransform xfB = new ControllerTransform(new Vector2F(x, 0.0f), rot);
                Manifold manifold = new Manifold();
                Collision.CollidePolygons(ref manifold, polyA, ref xfA, polyB, ref xfB);
            }
        }

        /// <summary>
        /// Tests that collide polygons clip underflow extreme sweep
        /// </summary>
        [Fact]
        public void CollidePolygons_ClipUnderflow_ExtremeSweep()
        {
            for (int iter = 0; iter < 5000; iter++)
            {
                float s = ((iter % 30) + 1) * 0.08f;
                float x = (iter % 200) * 0.04f - 4.0f;
                float rot = (iter / 200 % 20) * ((float)Math.PI / 10.0f);
                PolygonShape polyA = new PolygonShape(PolygonTools.CreateRectangle(s, s), 1.0f);
                PolygonShape polyB = new PolygonShape(PolygonTools.CreateRectangle(s * 0.7f, s * 0.7f), 1.0f);
                ControllerTransform xfA = ControllerTransform.Identity;
                ControllerTransform xfB = new ControllerTransform(new Vector2F(x, 0.0f), rot);
                Manifold manifold = new Manifold();
                Collision.CollidePolygons(ref manifold, polyA, ref xfA, polyB, ref xfB);
            }
        }

        /// <summary>
        /// Tests that collide polygons first clip underflow specific
        /// </summary>
        [Fact]
        public void CollidePolygons_FirstClipUnderflow_Specific()
        {
            for (int iter = 0; iter < 5000; iter++)
            {
                float wA = ((iter % 25) + 1) * 0.2f;
                float hA = ((iter / 25) % 20 + 1) * 0.2f;
                float wB = ((iter / 500) % 20 + 1) * 0.2f;
                float hB = ((iter / 10000) % 10 + 1) * 0.2f;
                float x = (iter % 120) * 0.05f - 3.0f;
                float y = (iter / 120 % 60) * 0.05f - 1.5f;
                float rot = (iter % 24) * ((float)Math.PI / 12.0f);
                PolygonShape polyA = new PolygonShape(PolygonTools.CreateRectangle(wA, hA), 1.0f);
                PolygonShape polyB = new PolygonShape(PolygonTools.CreateRectangle(wB, hB), 1.0f);
                ControllerTransform xfA = ControllerTransform.Identity;
                ControllerTransform xfB = new ControllerTransform(new Vector2F(x, y), rot);
                Manifold manifold = new Manifold();
                Collision.CollidePolygons(ref manifold, polyA, ref xfA, polyB, ref xfB);
            }
        }

        /// <summary>
        /// Tests that collide edge and polygon second clip underflow ep collider
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_SecondClipUnderflow_EpCollider()
        {
            for (int iter = 0; iter < 5000; iter++)
            {
                float w = ((iter % 25) + 1) * 0.1f;
                float h = ((iter / 25) % 25 + 1) * 0.1f;
                float x = (iter % 100) * 0.06f - 3.0f;
                float y = (iter / 100 % 60) * 0.04f - 1.2f;
                float rot = (iter % 30) * ((float)Math.PI / 15.0f);
                EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                    {
                        HasVertex0 = (iter % 3) == 0,
                        Vertex0 = new Vector2F(-1.0f, (iter % 7) * 0.3f - 0.9f),
                        HasVertex3 = (iter % 4) == 0,
                        Vertex3 = new Vector2F(3.0f, ((iter / 7) % 7) * 0.3f - 0.9f)
                    };
                PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(w, h), 1.0f);
                ControllerTransform xfEdge = ControllerTransform.Identity;
                ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(x, y), rot);
                Manifold manifold = new Manifold();
                Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);
            }
        }

        /// <summary>
        /// Tests that collide edge and polygon select primary axis unknown
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_SelectPrimaryAxisUnknown()
        {
            for (int iter = 0; iter < 5000; iter++)
            {
                float x = (iter % 120) * 0.05f - 3.0f;
                float y = (iter / 120 % 60) * 0.05f - 1.5f;
                float rot = (iter % 30) * ((float)Math.PI / 15.0f);
                float w = ((iter % 20) + 1) * 0.1f;
                float h = ((iter / 20) % 20 + 1) * 0.1f;
                bool hv0 = (iter % 3) == 0;
                bool hv3 = (iter % 5) == 0;
                EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                    {
                        HasVertex0 = hv0,
                        Vertex0 = new Vector2F(-1.0f, (iter % 5) * 0.3f - 0.6f),
                        HasVertex3 = hv3,
                        Vertex3 = new Vector2F(3.0f, ((iter / 5) % 5) * 0.3f - 0.6f)
                    };
                PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(w, h), 1.0f);
                ControllerTransform xfEdge = ControllerTransform.Identity;
                ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(x, y), rot);
                Manifold manifold = new Manifold();
                Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);
            }
        }

        /// <summary>
        /// Tests that collide edge and polygon massive sweep ep collider
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_MassiveSweep_EpCollider()
        {
            for (int iter = 0; iter < 10000; iter++)
            {
                float w = ((iter % 30) + 1) * 0.08f;
                float h = ((iter / 30) % 30 + 1) * 0.08f;
                float x = (iter % 150) * 0.04f - 3.0f;
                float y = (iter / 150 % 80) * 0.03f - 1.2f;
                float rot = (iter % 36) * ((float)Math.PI / 18.0f);
                EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                    {
                        HasVertex0 = (iter % 2) == 0,
                        Vertex0 = new Vector2F(-1.0f, (iter % 11) * 0.2f - 1.0f),
                        HasVertex3 = (iter % 3) == 0,
                        Vertex3 = new Vector2F(3.0f, ((iter / 11) % 11) * 0.2f - 1.0f)
                    };
                PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(w, h), 1.0f);
                ControllerTransform xfEdge = ControllerTransform.Identity;
                ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(x, y), rot);
                Manifold manifold = new Manifold();
                Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);
            }
        }
    }
}
