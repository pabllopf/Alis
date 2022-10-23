// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   BodyFactory.cs
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
using Alis.Core.Physic.Config;
using Alis.Core.Physic.Definitions;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Shared;
using Alis.Core.Physic.Tools.Triangulation.TriangulationBase;
using Alis.Core.Physic.Utilities;

namespace Alis.Core.Physic.Factories
{
    /// <summary>
    ///     The body factory class
    /// </summary>
    public static class BodyFactory
    {
        /// <summary>
        ///     Creates the body using the specified world
        /// </summary>
        /// <param name="world">The world</param>
        /// <param name="position">The position</param>
        /// <param name="rotation">The rotation</param>
        /// <param name="bodyType">The body type</param>
        /// <param name="userData">The user data</param>
        /// <returns>The body</returns>
        public static Body CreateBody(World world, Vector2 position = new Vector2(), float rotation = 0,
            BodyType bodyType = BodyType.Static, object userData = null)
        {
            BodyDef def = new BodyDef
            {
                Position = position,
                Angle = rotation,
                Type = bodyType,
                UserData = userData
            };

            return CreateFromDef(world, def);
        }

        /// <summary>
        ///     Creates the edge using the specified world
        /// </summary>
        /// <param name="world">The world</param>
        /// <param name="start">The start</param>
        /// <param name="end">The end</param>
        /// <param name="userData">The user data</param>
        /// <returns>The body</returns>
        public static Body CreateEdge(World world, Vector2 start, Vector2 end, object userData = null)
        {
            Body body = CreateBody(world);
            body.UserData = userData;

            FixtureFactory.AttachEdge(start, end, body);
            return body;
        }

        /// <summary>
        ///     Creates the chain shape using the specified world
        /// </summary>
        /// <param name="world">The world</param>
        /// <param name="vertices">The vertices</param>
        /// <param name="position">The position</param>
        /// <param name="userData">The user data</param>
        /// <returns>The body</returns>
        public static Body CreateChainShape(World world, Vertices vertices, Vector2 position = new Vector2(),
            object userData = null)
        {
            Body body = CreateBody(world, position);
            body.UserData = userData;

            FixtureFactory.AttachChainShape(vertices, body);
            return body;
        }

        /// <summary>
        ///     Creates the loop shape using the specified world
        /// </summary>
        /// <param name="world">The world</param>
        /// <param name="vertices">The vertices</param>
        /// <param name="position">The position</param>
        /// <param name="userData">The user data</param>
        /// <returns>The body</returns>
        public static Body CreateLoopShape(World world, Vertices vertices, Vector2 position = new Vector2(),
            object userData = null)
        {
            Body body = CreateBody(world, position);
            body.UserData = userData;

            FixtureFactory.AttachLoopShape(vertices, body);
            return body;
        }

        /// <summary>
        ///     Creates the rectangle using the specified world
        /// </summary>
        /// <param name="world">The world</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="density">The density</param>
        /// <param name="position">The position</param>
        /// <param name="rotation">The rotation</param>
        /// <param name="bodyType">The body type</param>
        /// <param name="userData">The user data</param>
        /// <exception cref="ArgumentOutOfRangeException">Height must be more than 0 meters</exception>
        /// <exception cref="ArgumentOutOfRangeException">Width must be more than 0 meters</exception>
        /// <returns>The body</returns>
        public static Body CreateRectangle(World world, float width, float height, float density,
            Vector2 position = new Vector2(), float rotation = 0, BodyType bodyType = BodyType.Static,
            object userData = null)
        {
            if (width <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(width), @"Width must be more than 0 meters");
            }

            if (height <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(height), @"Height must be more than 0 meters");
            }

            Body body = CreateBody(world, position, rotation, bodyType, userData);

            Vertices rectangleVertices = PolygonUtils.CreateRectangle(width / 2, height / 2);
            FixtureFactory.AttachPolygon(rectangleVertices, density, body);

            return body;
        }

        /// <summary>
        ///     Creates the circle using the specified world
        /// </summary>
        /// <param name="world">The world</param>
        /// <param name="radius">The radius</param>
        /// <param name="density">The density</param>
        /// <param name="position">The position</param>
        /// <param name="bodyType">The body type</param>
        /// <param name="userData">The user data</param>
        /// <returns>The body</returns>
        public static Body CreateCircle(World world, float radius, float density, Vector2 position = new Vector2(),
            BodyType bodyType = BodyType.Static, object userData = null)
        {
            Body body = CreateBody(world, position, 0, bodyType, userData);
            FixtureFactory.AttachCircle(radius, density, body);
            return body;
        }

        /// <summary>
        ///     Creates the ellipse using the specified world
        /// </summary>
        /// <param name="world">The world</param>
        /// <param name="xRadius">The radius</param>
        /// <param name="yRadius">The radius</param>
        /// <param name="edges">The edges</param>
        /// <param name="density">The density</param>
        /// <param name="position">The position</param>
        /// <param name="rotation">The rotation</param>
        /// <param name="bodyType">The body type</param>
        /// <param name="userData">The user data</param>
        /// <returns>The body</returns>
        public static Body CreateEllipse(World world, float xRadius, float yRadius, int edges, float density,
            Vector2 position = new Vector2(), float rotation = 0, BodyType bodyType = BodyType.Static,
            object userData = null)
        {
            Body body = CreateBody(world, position, rotation, bodyType, userData);
            FixtureFactory.AttachEllipse(xRadius, yRadius, edges, density, body);
            return body;
        }

        /// <summary>
        ///     Creates the polygon using the specified world
        /// </summary>
        /// <param name="world">The world</param>
        /// <param name="vertices">The vertices</param>
        /// <param name="density">The density</param>
        /// <param name="position">The position</param>
        /// <param name="rotation">The rotation</param>
        /// <param name="bodyType">The body type</param>
        /// <param name="userData">The user data</param>
        /// <returns>The body</returns>
        public static Body CreatePolygon(World world, Vertices vertices, float density,
            Vector2 position = new Vector2(), float rotation = 0, BodyType bodyType = BodyType.Static,
            object userData = null)
        {
            Body body = CreateBody(world, position, rotation, bodyType, userData);
            FixtureFactory.AttachPolygon(vertices, density, body);
            return body;
        }

        /// <summary>
        ///     Creates the compound polygon using the specified world
        /// </summary>
        /// <param name="world">The world</param>
        /// <param name="list">The list</param>
        /// <param name="density">The density</param>
        /// <param name="position">The position</param>
        /// <param name="rotation">The rotation</param>
        /// <param name="bodyType">The body type</param>
        /// <param name="userData">The user data</param>
        /// <returns>The body</returns>
        public static Body CreateCompoundPolygon(World world, List<Vertices> list, float density,
            Vector2 position = new Vector2(), float rotation = 0, BodyType bodyType = BodyType.Static,
            object userData = null!)
        {
            //We create a single body
            Body body = CreateBody(world, position, rotation, bodyType, userData);
            FixtureFactory.AttachCompoundPolygon(list, density, body);
            return body;
        }

        /// <summary>
        ///     Creates the gear using the specified world
        /// </summary>
        /// <param name="world">The world</param>
        /// <param name="radius">The radius</param>
        /// <param name="numberOfTeeth">The number of teeth</param>
        /// <param name="tipPercentage">The tip percentage</param>
        /// <param name="toothHeight">The tooth height</param>
        /// <param name="density">The density</param>
        /// <param name="position">The position</param>
        /// <param name="rotation">The rotation</param>
        /// <param name="bodyType">The body type</param>
        /// <param name="userData">The user data</param>
        /// <returns>The body</returns>
        public static Body CreateGear(World world, float radius, int numberOfTeeth, float tipPercentage,
            float toothHeight, float density, Vector2 position = new Vector2(), float rotation = 0,
            BodyType bodyType = BodyType.Static, object userData = null!)
        {
            Vertices gearPolygon = PolygonUtils.CreateGear(radius, numberOfTeeth, tipPercentage, toothHeight);

            //Gears can in some cases be convex
            if (!gearPolygon.IsConvex())
            {
                //Decompose the gear:
                List<Vertices> list = Triangulate.ConvexPartition(gearPolygon, TriangulationAlgorithm.Earclip);

                return CreateCompoundPolygon(world, list, density, position, rotation, bodyType, userData);
            }

            return CreatePolygon(world, gearPolygon, density, position, rotation, bodyType, userData);
        }

        /// <summary>
        ///     Creates the capsule using the specified world
        /// </summary>
        /// <param name="world">The world</param>
        /// <param name="height">The height</param>
        /// <param name="topRadius">The top radius</param>
        /// <param name="topEdges">The top edges</param>
        /// <param name="bottomRadius">The bottom radius</param>
        /// <param name="bottomEdges">The bottom edges</param>
        /// <param name="density">The density</param>
        /// <param name="position">The position</param>
        /// <param name="rotation">The rotation</param>
        /// <param name="bodyType">The body type</param>
        /// <param name="userData">The user data</param>
        /// <returns>The body</returns>
        public static Body CreateCapsule(World world, float height, float topRadius, int topEdges, float bottomRadius,
            int bottomEdges, float density, Vector2 position = new Vector2(), float rotation = 0,
            BodyType bodyType = BodyType.Static, object userData = null!)
        {
            Vertices verts = PolygonUtils.CreateCapsule(height, topRadius, topEdges, bottomRadius, bottomEdges);

            //There are too many vertices in the capsule. We decompose it.
            if (verts.Count >= Settings.MaxPolygonVertices)
            {
                List<Vertices> vertList = Triangulate.ConvexPartition(verts, TriangulationAlgorithm.Earclip);
                return CreateCompoundPolygon(world, vertList, density, position, rotation, bodyType, userData);
            }

            return CreatePolygon(world, verts, density, position, rotation, bodyType, userData);
        }

        /// <summary>
        ///     Creates the capsule using the specified world
        /// </summary>
        /// <param name="world">The world</param>
        /// <param name="height">The height</param>
        /// <param name="endRadius">The end radius</param>
        /// <param name="density">The density</param>
        /// <param name="position">The position</param>
        /// <param name="rotation">The rotation</param>
        /// <param name="bodyType">The body type</param>
        /// <param name="userData">The user data</param>
        /// <returns>The body</returns>
        public static Body CreateCapsule(World world, float height, float endRadius, float density,
            Vector2 position = new Vector2(), float rotation = 0, BodyType bodyType = BodyType.Static,
            object userData = null!)
        {
            //Create the middle rectangle
            Vertices rectangle = PolygonUtils.CreateRectangle(endRadius, height / 2);

            List<Vertices> list = new List<Vertices>
            {
                rectangle
            };

            Body body = CreateCompoundPolygon(world, list, density, position, rotation, bodyType, userData);
            FixtureFactory.AttachCircle(endRadius, density, body, new Vector2(0, height / 2));
            FixtureFactory.AttachCircle(endRadius, density, body, new Vector2(0, -(height / 2)));

            //Create the two circles
            //CircleShape topCircle = new CircleShape(endRadius, density);
            //topCircle.Position = new Vector2(0, height / 2);
            //body.CreateFixture(topCircle);

            //CircleShape bottomCircle = new CircleShape(endRadius, density);
            //bottomCircle.Position = new Vector2(0, -(height / 2));
            //body.CreateFixture(bottomCircle);
            return body;
        }

        /// <summary>
        ///     Creates the rounded rectangle using the specified world
        /// </summary>
        /// <param name="world">The world</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="xRadius">The radius</param>
        /// <param name="yRadius">The radius</param>
        /// <param name="segments">The segments</param>
        /// <param name="density">The density</param>
        /// <param name="position">The position</param>
        /// <param name="rotation">The rotation</param>
        /// <param name="bodyType">The body type</param>
        /// <param name="userData">The user data</param>
        /// <returns>The body</returns>
        public static Body CreateRoundedRectangle(World world, float width, float height, float xRadius, float yRadius,
            int segments, float density, Vector2 position = new Vector2(), float rotation = 0,
            BodyType bodyType = BodyType.Static, object userData = null!)
        {
            Vertices verts = PolygonUtils.CreateRoundedRectangle(width, height, xRadius, yRadius, segments);

            //There are too many vertices in the capsule. We decompose it.
            if (verts.Count >= Settings.MaxPolygonVertices)
            {
                List<Vertices> vertList = Triangulate.ConvexPartition(verts, TriangulationAlgorithm.Earclip);
                return CreateCompoundPolygon(world, vertList, density, position, rotation, bodyType, userData);
            }

            return CreatePolygon(world, verts, density, position, rotation, bodyType, userData);
        }

        /// <summary>
        ///     Creates the line arc using the specified world
        /// </summary>
        /// <param name="world">The world</param>
        /// <param name="radians">The radians</param>
        /// <param name="sides">The sides</param>
        /// <param name="radius">The radius</param>
        /// <param name="closed">The closed</param>
        /// <param name="position">The position</param>
        /// <param name="rotation">The rotation</param>
        /// <param name="bodyType">The body type</param>
        /// <param name="userData">The user data</param>
        /// <returns>The body</returns>
        public static Body CreateLineArc(World world, float radians, int sides, float radius, bool closed = false,
            Vector2 position = new Vector2(), float rotation = 0, BodyType bodyType = BodyType.Static,
            object userData = null!)
        {
            Body body = CreateBody(world, position, rotation, bodyType, userData);
            FixtureFactory.AttachLineArc(radians, sides, radius, closed, body);
            return body;
        }

        /// <summary>
        ///     Creates the solid arc using the specified world
        /// </summary>
        /// <param name="world">The world</param>
        /// <param name="density">The density</param>
        /// <param name="radians">The radians</param>
        /// <param name="sides">The sides</param>
        /// <param name="radius">The radius</param>
        /// <param name="position">The position</param>
        /// <param name="rotation">The rotation</param>
        /// <param name="bodyType">The body type</param>
        /// <param name="userData">The user data</param>
        /// <returns>The body</returns>
        public static Body CreateSolidArc(World world, float density, float radians, int sides, float radius,
            Vector2 position = new Vector2(), float rotation = 0, BodyType bodyType = BodyType.Static,
            object userData = null!)
        {
            Body body = CreateBody(world, position, rotation, bodyType, userData);
            FixtureFactory.AttachSolidArc(density, radians, sides, radius, body);

            return body;
        }

        /// <summary>
        ///     Creates the breakable body using the specified world
        /// </summary>
        /// <param name="world">The world</param>
        /// <param name="vertices">The vertices</param>
        /// <param name="density">The density</param>
        /// <param name="position">The position</param>
        /// <param name="rotation">The rotation</param>
        /// <returns>The breakable body</returns>
        public static BreakableBody CreateBreakableBody(World world, Vertices vertices, float density,
            Vector2 position = new Vector2(), float rotation = 0)
        {
            //TODO: Implement a Voronoi diagram algorithm to split up the vertices
            List<Vertices> triangles = Triangulate.ConvexPartition(vertices, TriangulationAlgorithm.Earclip);

            BreakableBody breakableBody = new BreakableBody(world, triangles, density, position, rotation);
            breakableBody.MainBody.Position = position;
            world.AddBreakableBody(breakableBody);
            return breakableBody;
        }

        /// <summary>
        ///     Creates the breakable body using the specified world
        /// </summary>
        /// <param name="world">The world</param>
        /// <param name="shapes">The shapes</param>
        /// <param name="position">The position</param>
        /// <param name="rotation">The rotation</param>
        /// <returns>The breakable body</returns>
        public static BreakableBody CreateBreakableBody(World world, IEnumerable<Shape> shapes,
            Vector2 position = new Vector2(), float rotation = 0)
        {
            BreakableBody breakableBody = new BreakableBody(world, shapes, position, rotation);
            breakableBody.MainBody.Position = position;
            world.AddBreakableBody(breakableBody);
            return breakableBody;
        }

        /// <summary>
        ///     Creates the from def using the specified world
        /// </summary>
        /// <param name="world">The world</param>
        /// <param name="def">The def</param>
        /// <returns>The body</returns>
        public static Body CreateFromDef(World world, BodyDef def)
        {
            Body body = new Body(def);
            world.AddBody(body);
            return body;
        }
    }
}