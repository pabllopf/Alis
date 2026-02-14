// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Body.Factory.cs
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
using System.Collections.Generic;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Common.Decomposition;

namespace Alis.Core.Physic.Dynamics
{
    // An easy to use factory for creating bodies
    /// <summary>
    ///     The body class
    /// </summary>
    public partial class Body
    {
        /// <summary>
        /// </summary>
        /// <param name="shape"></param>
        /// <returns></returns>
        public virtual Fixture CreateFixture(Shape shape)
        {
            Fixture fixture = new Fixture(shape);
            Add(fixture);
            return fixture;
        }

        /// <summary>
        ///     Creates the edge using the specified start
        /// </summary>
        /// <param name="start">The start</param>
        /// <param name="end">The end</param>
        /// <returns>The fixture</returns>
        public Fixture CreateEdge(Vector2F start, Vector2F end)
        {
            EdgeShape edgeShape = new EdgeShape(start, end);
            return CreateFixture(edgeShape);
        }

        /// <summary>
        ///     Creates the chain shape using the specified vertices
        /// </summary>
        /// <param name="vertices">The vertices</param>
        /// <returns>The fixture</returns>
        public Fixture CreateChainShape(Vertices vertices)
        {
            ChainShape shape = new ChainShape(vertices);
            return CreateFixture(shape);
        }

        /// <summary>
        ///     Creates the loop shape using the specified vertices
        /// </summary>
        /// <param name="vertices">The vertices</param>
        /// <returns>The fixture</returns>
        public Fixture CreateLoopShape(Vertices vertices)
        {
            ChainShape shape = new ChainShape(vertices, true);
            return CreateFixture(shape);
        }

        /// <summary>
        ///     Creates the rectangle using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="density">The density</param>
        /// <param name="offset">The offset</param>
        /// <returns>The fixture</returns>
        public Fixture CreateRectangle(float width, float height, float density, Vector2F offset)
        {
            Vertices rectangleVertices = PolygonTools.CreateRectangle(width / 2, height / 2);
            rectangleVertices.Translate(ref offset);
            PolygonShape rectangleShape = new PolygonShape(rectangleVertices, density);
            return CreateFixture(rectangleShape);
        }

        /// <summary>
        ///     Creates the circle using the specified radius
        /// </summary>
        /// <param name="radius">The radius</param>
        /// <param name="density">The density</param>
        /// <exception cref="ArgumentOutOfRangeException">radius Radius must be more than 0 meters</exception>
        /// <returns>The fixture</returns>
        public Fixture CreateCircle(float radius, float density)
        {
            if (radius <= 0)
            {
                throw new ArgumentOutOfRangeException("radius", "Radius must be more than 0 meters");
            }

            CircleShape circleShape = new CircleShape(radius, density);
            return CreateFixture(circleShape);
        }

        /// <summary>
        ///     Creates the circle using the specified radius
        /// </summary>
        /// <param name="radius">The radius</param>
        /// <param name="density">The density</param>
        /// <param name="offset">The offset</param>
        /// <exception cref="ArgumentOutOfRangeException">radius Radius must be more than 0 meters</exception>
        /// <returns>The fixture</returns>
        public Fixture CreateCircle(float radius, float density, Vector2F offset)
        {
            if (radius <= 0)
            {
                throw new ArgumentOutOfRangeException("radius", "Radius must be more than 0 meters");
            }

            CircleShape circleShape = new CircleShape(radius, density);
            circleShape.Position = offset;
            return CreateFixture(circleShape);
        }

        /// <summary>
        ///     Creates the polygon using the specified vertices
        /// </summary>
        /// <param name="vertices">The vertices</param>
        /// <param name="density">The density</param>
        /// <exception cref="ArgumentOutOfRangeException">vertices Too few points to be a polygon</exception>
        /// <returns>The fixture</returns>
        public Fixture CreatePolygon(Vertices vertices, float density)
        {
            if (vertices.Count <= 1)
            {
                throw new ArgumentOutOfRangeException("vertices", "Too few points to be a polygon");
            }

            PolygonShape polygon = new PolygonShape(vertices, density);
            return CreateFixture(polygon);
        }

        /// <summary>
        ///     Creates the ellipse using the specified x radius
        /// </summary>
        /// <param name="xRadius">The radius</param>
        /// <param name="yRadius">The radius</param>
        /// <param name="edges">The edges</param>
        /// <param name="density">The density</param>
        /// <exception cref="ArgumentOutOfRangeException">xRadius X-radius must be more than 0</exception>
        /// <exception cref="ArgumentOutOfRangeException">yRadius Y-radius must be more than 0</exception>
        /// <returns>The fixture</returns>
        public Fixture CreateEllipse(float xRadius, float yRadius, int edges, float density)
        {
            if (xRadius <= 0)
            {
                throw new ArgumentOutOfRangeException("xRadius", "X-radius must be more than 0");
            }

            if (yRadius <= 0)
            {
                throw new ArgumentOutOfRangeException("yRadius", "Y-radius must be more than 0");
            }

            Vertices ellipseVertices = PolygonTools.CreateEllipse(xRadius, yRadius, edges);
            PolygonShape polygonShape = new PolygonShape(ellipseVertices, density);
            return CreateFixture(polygonShape);
        }

        /// <summary>
        ///     Creates the compound polygon using the specified list
        /// </summary>
        /// <param name="list">The list</param>
        /// <param name="density">The density</param>
        /// <returns>The res</returns>
        public List<Fixture> CreateCompoundPolygon(List<Vertices> list, float density)
        {
            List<Fixture> res = new List<Fixture>(list.Count);

            //Then we create several fixtures using the body
            foreach (Vertices vertices in list)
            {
                if (vertices.Count == 2)
                {
                    EdgeShape shape = new EdgeShape(vertices[0], vertices[1]);
                    res.Add(CreateFixture(shape));
                }
                else
                {
                    PolygonShape shape = new PolygonShape(vertices, density);
                    res.Add(CreateFixture(shape));
                }
            }

            return res;
        }

        /// <summary>
        ///     Creates the line arc using the specified radians
        /// </summary>
        /// <param name="radians">The radians</param>
        /// <param name="sides">The sides</param>
        /// <param name="radius">The radius</param>
        /// <param name="closed">The closed</param>
        /// <returns>The fixture</returns>
        public Fixture CreateLineArc(float radians, int sides, float radius, bool closed)
        {
            Vertices arc = PolygonTools.CreateArc(radians, sides, radius);
            arc.Rotate((Constant.Pi - radians) / 2);
            return closed ? CreateLoopShape(arc) : CreateChainShape(arc);
        }

        /// <summary>
        ///     Creates the solid arc using the specified density
        /// </summary>
        /// <param name="density">The density</param>
        /// <param name="radians">The radians</param>
        /// <param name="sides">The sides</param>
        /// <param name="radius">The radius</param>
        /// <returns>A list of fixture</returns>
        public List<Fixture> CreateSolidArc(float density, float radians, int sides, float radius)
        {
            Vertices arc = PolygonTools.CreateArc(radians, sides, radius);
            arc.Rotate((Constant.Pi - radians) / 2);

            //Close the arc
            arc.Add(arc[0]);

            List<Vertices> triangles = Triangulate.ConvexPartition(arc, TriangulationAlgorithm.Earclip);

            return CreateCompoundPolygon(triangles, density);
        }
    }
}