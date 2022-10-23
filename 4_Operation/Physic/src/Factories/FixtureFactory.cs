// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   FixtureFactory.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Numerics;
using Alis.Core.Physic.Collision.Shapes;
using Alis.Core.Physic.Definitions;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Shared;
using Alis.Core.Physic.Tools.Triangulation.TriangulationBase;
using Alis.Core.Physic.Utilities;

namespace Alis.Core.Physic.Factories
{
    /// <summary>An easy to use factory for creating bodies</summary>
    public static class FixtureFactory
    {
        /// <summary>
        ///     Attaches the edge using the specified start
        /// </summary>
        /// <param name="start">The start</param>
        /// <param name="end">The end</param>
        /// <param name="body">The body</param>
        /// <param name="userData">The user data</param>
        /// <returns>The </returns>
        public static Fixture AttachEdge(Vector2 start, Vector2 end, Body body, object? userData = null)
        {
            EdgeShape edgeShape = new EdgeShape(start, end);
            Fixture f = body.AddFixture(edgeShape);
            f.UserData = userData;
            return f;
        }

        /// <summary>
        ///     Attaches the chain shape using the specified vertices
        /// </summary>
        /// <param name="vertices">The vertices</param>
        /// <param name="body">The body</param>
        /// <param name="userData">The user data</param>
        /// <returns>The </returns>
        public static Fixture AttachChainShape(Vertices vertices, Body body, object? userData = null)
        {
            ChainShape shape = new ChainShape(vertices);
            Fixture f = body.AddFixture(shape);
            f.UserData = userData;
            return f;
        }

        /// <summary>
        ///     Attaches the loop shape using the specified vertices
        /// </summary>
        /// <param name="vertices">The vertices</param>
        /// <param name="body">The body</param>
        /// <param name="userData">The user data</param>
        /// <returns>The </returns>
        public static Fixture AttachLoopShape(Vertices vertices, Body body, object? userData = null)
        {
            ChainShape shape = new ChainShape(vertices, true);
            Fixture f = body.AddFixture(shape);
            f.UserData = userData;
            return f;
        }

        /// <summary>
        ///     Attaches the rectangle using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="density">The density</param>
        /// <param name="offset">The offset</param>
        /// <param name="body">The body</param>
        /// <param name="userData">The user data</param>
        /// <returns>The </returns>
        public static Fixture AttachRectangle(float width, float height, float density, Vector2 offset, Body body,
            object? userData = null)
        {
            Vertices rectangleVertices = PolygonUtils.CreateRectangle(width / 2, height / 2);
            rectangleVertices.Translate(ref offset);
            PolygonShape rectangleShape = new PolygonShape(rectangleVertices, density);
            Fixture f = body.AddFixture(rectangleShape);
            f.UserData = userData;
            return f;
        }

        /// <summary>
        ///     Attaches the circle using the specified radius
        /// </summary>
        /// <param name="radius">The radius</param>
        /// <param name="density">The density</param>
        /// <param name="body">The body</param>
        /// <param name="userData">The user data</param>
        /// <exception cref="ArgumentOutOfRangeException">Radius must be more than 0 meters</exception>
        /// <returns>The </returns>
        public static Fixture AttachCircle(float radius, float density, Body body, object? userData = null)
        {
            if (radius <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(radius), @"Radius must be more than 0 meters");
            }

            CircleShape circleShape = new CircleShape(radius, density);
            Fixture f = body.AddFixture(circleShape);
            f.UserData = userData;
            return f;
        }

        /// <summary>
        ///     Attaches the circle using the specified radius
        /// </summary>
        /// <param name="radius">The radius</param>
        /// <param name="density">The density</param>
        /// <param name="body">The body</param>
        /// <param name="offset">The offset</param>
        /// <param name="userData">The user data</param>
        /// <exception cref="ArgumentOutOfRangeException">Radius must be more than 0 meters</exception>
        /// <returns>The </returns>
        public static Fixture AttachCircle(float radius, float density, Body body, Vector2 offset,
            object? userData = null)
        {
            if (radius <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(radius), "Radius must be more than 0 meters");
            }

            CircleShape circleShape = new CircleShape(radius, density)
            {
                Position = offset
            };
            Fixture f = body.AddFixture(circleShape);
            f.UserData = userData;
            return f;
        }

        /// <summary>
        ///     Attaches the polygon using the specified vertices
        /// </summary>
        /// <param name="vertices">The vertices</param>
        /// <param name="density">The density</param>
        /// <param name="body">The body</param>
        /// <param name="userData">The user data</param>
        /// <exception cref="ArgumentOutOfRangeException">Too few points to be a polygon</exception>
        /// <returns>The </returns>
        public static Fixture AttachPolygon(Vertices vertices, float density, Body body, object? userData = null)
        {
            if (vertices.Count <= 1)
            {
                throw new ArgumentOutOfRangeException(nameof(vertices), "Too few points to be a polygon");
            }

            PolygonShape polygon = new PolygonShape(vertices, density);
            Fixture f = body.AddFixture(polygon);
            f.UserData = userData;
            return f;
        }

        /// <summary>
        ///     Attaches the ellipse using the specified x radius
        /// </summary>
        /// <param name="xRadius">The radius</param>
        /// <param name="yRadius">The radius</param>
        /// <param name="edges">The edges</param>
        /// <param name="density">The density</param>
        /// <param name="body">The body</param>
        /// <param name="userData">The user data</param>
        /// <exception cref="ArgumentOutOfRangeException">X-radius must be more than 0</exception>
        /// <exception cref="ArgumentOutOfRangeException">Y-radius must be more than 0</exception>
        /// <returns>The </returns>
        public static Fixture AttachEllipse(float xRadius, float yRadius, int edges, float density, Body body,
            object? userData = null)
        {
            if (xRadius <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(xRadius), "X-radius must be more than 0");
            }

            if (yRadius <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(yRadius), "Y-radius must be more than 0");
            }

            Vertices ellipseVertices = PolygonUtils.CreateEllipse(xRadius, yRadius, edges);
            PolygonShape polygonShape = new PolygonShape(ellipseVertices, density);
            Fixture f = body.AddFixture(polygonShape);
            f.UserData = userData;
            return f;
        }

        /// <summary>
        ///     Attaches the compound polygon using the specified list
        /// </summary>
        /// <param name="list">The list</param>
        /// <param name="density">The density</param>
        /// <param name="body">The body</param>
        /// <returns>The res</returns>
        public static List<Fixture> AttachCompoundPolygon(List<Vertices> list, float density, Body body)
        {
            List<Fixture> res = new List<Fixture>(list.Count);

            //Then we create several fixtures using the body
            foreach (Vertices vertices in list)
            {
                if (vertices.Count == 2)
                {
                    EdgeShape shape = new EdgeShape(vertices[0], vertices[1]);
                    res.Add(body.AddFixture(shape));
                }
                else
                {
                    PolygonShape shape = new PolygonShape(vertices, density);
                    res.Add(body.AddFixture(shape));
                }
            }

            return res;
        }

        /// <summary>
        ///     Attaches the line arc using the specified radians
        /// </summary>
        /// <param name="radians">The radians</param>
        /// <param name="sides">The sides</param>
        /// <param name="radius">The radius</param>
        /// <param name="closed">The closed</param>
        /// <param name="body">The body</param>
        /// <returns>The fixture</returns>
        public static Fixture AttachLineArc(float radians, int sides, float radius, bool closed, Body body)
        {
            Vertices arc = PolygonUtils.CreateArc(radians, sides, radius);
            arc.Rotate((MathConstants.Pi - radians) / 2);
            return closed ? AttachLoopShape(arc, body) : AttachChainShape(arc, body);
        }

        /// <summary>
        ///     Attaches the solid arc using the specified density
        /// </summary>
        /// <param name="density">The density</param>
        /// <param name="radians">The radians</param>
        /// <param name="sides">The sides</param>
        /// <param name="radius">The radius</param>
        /// <param name="body">The body</param>
        /// <returns>A list of fixture</returns>
        public static List<Fixture> AttachSolidArc(float density, float radians, int sides, float radius, Body body)
        {
            Vertices arc = PolygonUtils.CreateArc(radians, sides, radius);
            arc.Rotate((MathConstants.Pi - radians) / 2);

            //Close the arc
            arc.Add(arc[0]);

            List<Vertices> triangles = Triangulate.ConvexPartition(arc, TriangulationAlgorithm.Earclip);

            return AttachCompoundPolygon(triangles, density, body);
        }

        /// <summary>
        ///     Creates the from def using the specified body
        /// </summary>
        /// <param name="body">The body</param>
        /// <param name="fixtureDef">The fixture def</param>
        /// <returns>The fixture</returns>
        public static Fixture CreateFromDef(Body body, FixtureDef fixtureDef) => body.AddFixture(fixtureDef);
    }
}