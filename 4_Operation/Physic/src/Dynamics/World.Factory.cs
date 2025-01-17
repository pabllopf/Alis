// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:World.Factory.cs
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
using System.Diagnostics;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collision.Shapes;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Common.Decomposition;
using Alis.Core.Physic.Dynamics.Joints;

namespace Alis.Core.Physic.Dynamics
{
    /// <summary>
    ///     The world class
    /// </summary>
    public partial class World
    {
        /// <summary>
        ///     Creates the body using the specified position
        /// </summary>
        /// <param name="position">The position</param>
        /// <param name="rotation">The rotation</param>
        /// <param name="bodyType">The body type</param>
        /// <returns>The body</returns>
        public virtual Body CreateBody(Vector2F position = new Vector2F(), float rotation = 0, BodyType bodyType = BodyType.Static)
        {
            Body body = new Body();
            body.Position = position;
            body.Rotation = rotation;
            body.GetBodyType = bodyType;


            Add(body);

            return body;
        }

        /// <summary>
        ///     Creates the edge using the specified start
        /// </summary>
        /// <param name="start">The start</param>
        /// <param name="end">The end</param>
        /// <returns>The body</returns>
        public Body CreateEdge(Vector2F start, Vector2F end)
        {
            Body body = CreateBody();

            body.CreateEdge(start, end);
            return body;
        }

        /// <summary>
        ///     Creates the chain shape using the specified vertices
        /// </summary>
        /// <param name="vertices">The vertices</param>
        /// <param name="position">The position</param>
        /// <returns>The body</returns>
        public Body CreateChainShape(Vertices vertices, Vector2F position = new Vector2F())
        {
            Body body = CreateBody(position);

            body.CreateChainShape(vertices);
            return body;
        }

        /// <summary>
        ///     Creates the loop shape using the specified vertices
        /// </summary>
        /// <param name="vertices">The vertices</param>
        /// <param name="position">The position</param>
        /// <returns>The body</returns>
        public Body CreateLoopShape(Vertices vertices, Vector2F position = new Vector2F())
        {
            Body body = CreateBody(position);

            body.CreateLoopShape(vertices);
            return body;
        }

        /// <summary>
        ///     Creates the rectangle using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="density">The density</param>
        /// <param name="position">The position</param>
        /// <param name="rotation">The rotation</param>
        /// <param name="bodyType">The body type</param>
        /// <exception cref="ArgumentOutOfRangeException">height Height must be more than 0 meters</exception>
        /// <exception cref="ArgumentOutOfRangeException">width Width must be more than 0 meters</exception>
        /// <returns>The body</returns>
        public Body CreateRectangle(float width, float height, float density, Vector2F position = new Vector2F(), float rotation = 0, BodyType bodyType = BodyType.Static)
        {
            if (width <= 0)
            {
                throw new ArgumentOutOfRangeException("width", "Width must be more than 0 meters");
            }

            if (height <= 0)
            {
                throw new ArgumentOutOfRangeException("height", "Height must be more than 0 meters");
            }

            Body body = CreateBody(position, rotation, bodyType);

            Vertices rectangleVertices = PolygonTools.CreateRectangle(width / 2, height / 2);
            body.CreatePolygon(rectangleVertices, density);

            return body;
        }

        /// <summary>
        ///     Creates the circle using the specified radius
        /// </summary>
        /// <param name="radius">The radius</param>
        /// <param name="density">The density</param>
        /// <param name="position">The position</param>
        /// <param name="bodyType">The body type</param>
        /// <returns>The body</returns>
        public Body CreateCircle(float radius, float density, Vector2F position = new Vector2F(), BodyType bodyType = BodyType.Static)
        {
            Body body = CreateBody(position, 0, bodyType);
            body.CreateCircle(radius, density);
            return body;
        }

        /// <summary>
        ///     Creates the ellipse using the specified x radius
        /// </summary>
        /// <param name="xRadius">The radius</param>
        /// <param name="yRadius">The radius</param>
        /// <param name="edges">The edges</param>
        /// <param name="density">The density</param>
        /// <param name="position">The position</param>
        /// <param name="rotation">The rotation</param>
        /// <param name="bodyType">The body type</param>
        /// <returns>The body</returns>
        public Body CreateEllipse(float xRadius, float yRadius, int edges, float density, Vector2F position = new Vector2F(), float rotation = 0, BodyType bodyType = BodyType.Static)
        {
            Body body = CreateBody(position, rotation, bodyType);
            body.CreateEllipse(xRadius, yRadius, edges, density);
            return body;
        }

        /// <summary>
        ///     Creates the polygon using the specified vertices
        /// </summary>
        /// <param name="vertices">The vertices</param>
        /// <param name="density">The density</param>
        /// <param name="position">The position</param>
        /// <param name="rotation">The rotation</param>
        /// <param name="bodyType">The body type</param>
        /// <returns>The body</returns>
        public Body CreatePolygon(Vertices vertices, float density, Vector2F position = new Vector2F(), float rotation = 0, BodyType bodyType = BodyType.Static)
        {
            Body body = CreateBody(position, rotation, bodyType);
            body.CreatePolygon(vertices, density);
            return body;
        }

        /// <summary>
        ///     Creates the compound polygon using the specified list
        /// </summary>
        /// <param name="list">The list</param>
        /// <param name="density">The density</param>
        /// <param name="position">The position</param>
        /// <param name="rotation">The rotation</param>
        /// <param name="bodyType">The body type</param>
        /// <returns>The body</returns>
        public Body CreateCompoundPolygon(List<Vertices> list, float density, Vector2F position = new Vector2F(), float rotation = 0, BodyType bodyType = BodyType.Static)
        {
            //We create a single body
            Body body = CreateBody(position, rotation, bodyType);
            body.CreateCompoundPolygon(list, density);
            return body;
        }

        /// <summary>
        ///     Creates the gear using the specified radius
        /// </summary>
        /// <param name="radius">The radius</param>
        /// <param name="numberOfTeeth">The number of teeth</param>
        /// <param name="tipPercentage">The tip percentage</param>
        /// <param name="toothHeight">The tooth height</param>
        /// <param name="density">The density</param>
        /// <param name="position">The position</param>
        /// <param name="rotation">The rotation</param>
        /// <param name="bodyType">The body type</param>
        /// <returns>The body</returns>
        public Body CreateGear(float radius, int numberOfTeeth, float tipPercentage, float toothHeight, float density, Vector2F position = new Vector2F(), float rotation = 0, BodyType bodyType = BodyType.Static)
        {
            Vertices gearPolygon = PolygonTools.CreateGear(radius, numberOfTeeth, tipPercentage, toothHeight);

            //Gears can in some cases be convex
            if (!gearPolygon.IsConvex())
            {
                //Decompose the gear:
                List<Vertices> list = Triangulate.ConvexPartition(gearPolygon, TriangulationAlgorithm.Earclip);

                return CreateCompoundPolygon(list, density, position, rotation, bodyType);
            }

            return CreatePolygon(gearPolygon, density, position, rotation, bodyType);
        }

        /// <summary>
        ///     Creates the capsule using the specified height
        /// </summary>
        /// <param name="height">The height</param>
        /// <param name="topRadius">The top radius</param>
        /// <param name="topEdges">The top edges</param>
        /// <param name="bottomRadius">The bottom radius</param>
        /// <param name="bottomEdges">The bottom edges</param>
        /// <param name="density">The density</param>
        /// <param name="position">The position</param>
        /// <param name="rotation">The rotation</param>
        /// <param name="bodyType">The body type</param>
        /// <returns>The body</returns>
        public Body CreateCapsule(float height, float topRadius, int topEdges, float bottomRadius, int bottomEdges, float density, Vector2F position = new Vector2F(), float rotation = 0, BodyType bodyType = BodyType.Static)
        {
            Vertices verts = PolygonTools.CreateCapsule(height, topRadius, topEdges, bottomRadius, bottomEdges);

            //There are too many vertices in the capsule. We decompose it.
            if (verts.Count >= SettingEnv.MaxPolygonVertices)
            {
                List<Vertices> vertList = Triangulate.ConvexPartition(verts, TriangulationAlgorithm.Earclip);
                return CreateCompoundPolygon(vertList, density, position, rotation, bodyType);
            }

            return CreatePolygon(verts, density, position, rotation, bodyType);
        }

        /// <summary>
        ///     Creates the capsule using the specified height
        /// </summary>
        /// <param name="height">The height</param>
        /// <param name="endRadius">The end radius</param>
        /// <param name="density">The density</param>
        /// <param name="position">The position</param>
        /// <param name="rotation">The rotation</param>
        /// <param name="bodyType">The body type</param>
        /// <returns>The body</returns>
        public Body CreateCapsule(float height, float endRadius, float density, Vector2F position = new Vector2F(), float rotation = 0, BodyType bodyType = BodyType.Static)
        {
            //Create the middle rectangle
            Vertices rectangle = PolygonTools.CreateRectangle(endRadius, height / 2);

            List<Vertices> list = new List<Vertices>();
            list.Add(rectangle);

            Body body = CreateCompoundPolygon(list, density, position, rotation, bodyType);
            body.CreateCircle(endRadius, density, new Vector2F(0, height / 2));
            body.CreateCircle(endRadius, density, new Vector2F(0, -(height / 2)));

            //Create the two circles
            //CircleShape topCircle = new CircleShape(endRadius, density);
            //topCircle.Position = new Vector2F(0, height / 2);
            //body.CreateFixture(topCircle);

            //CircleShape bottomCircle = new CircleShape(endRadius, density);
            //bottomCircle.Position = new Vector2F(0, -(height / 2));
            //body.CreateFixture(bottomCircle);
            return body;
        }

        /// <summary>
        ///     Creates the rounded rectangle using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="xRadius">The radius</param>
        /// <param name="yRadius">The radius</param>
        /// <param name="segments">The segments</param>
        /// <param name="density">The density</param>
        /// <param name="position">The position</param>
        /// <param name="rotation">The rotation</param>
        /// <param name="bodyType">The body type</param>
        /// <returns>The body</returns>
        public Body CreateRoundedRectangle(float width, float height, float xRadius, float yRadius, int segments, float density, Vector2F position = new Vector2F(), float rotation = 0, BodyType bodyType = BodyType.Static)
        {
            Vertices verts = PolygonTools.CreateRoundedRectangle(width, height, xRadius, yRadius, segments);

            //There are too many vertices in the capsule. We decompose it.
            if (verts.Count >= SettingEnv.MaxPolygonVertices)
            {
                List<Vertices> vertList = Triangulate.ConvexPartition(verts, TriangulationAlgorithm.Earclip);
                return CreateCompoundPolygon(vertList, density, position, rotation, bodyType);
            }

            return CreatePolygon(verts, density, position, rotation, bodyType);
        }

        /// <summary>
        ///     Creates the line arc using the specified radians
        /// </summary>
        /// <param name="radians">The radians</param>
        /// <param name="sides">The sides</param>
        /// <param name="radius">The radius</param>
        /// <param name="closed">The closed</param>
        /// <param name="position">The position</param>
        /// <param name="rotation">The rotation</param>
        /// <param name="bodyType">The body type</param>
        /// <returns>The body</returns>
        public Body CreateLineArc(float radians, int sides, float radius, bool closed = false, Vector2F position = new Vector2F(), float rotation = 0, BodyType bodyType = BodyType.Static)
        {
            Body body = CreateBody(position, rotation, bodyType);
            body.CreateLineArc(radians, sides, radius, closed);
            return body;
        }

        /// <summary>
        ///     Creates the solid arc using the specified density
        /// </summary>
        /// <param name="density">The density</param>
        /// <param name="radians">The radians</param>
        /// <param name="sides">The sides</param>
        /// <param name="radius">The radius</param>
        /// <param name="position">The position</param>
        /// <param name="rotation">The rotation</param>
        /// <param name="bodyType">The body type</param>
        /// <returns>The body</returns>
        public Body CreateSolidArc(float density, float radians, int sides, float radius, Vector2F position = new Vector2F(), float rotation = 0, BodyType bodyType = BodyType.Static)
        {
            Body body = CreateBody(position, rotation, bodyType);
            body.CreateSolidArc(density, radians, sides, radius);

            return body;
        }

        /// <summary>
        ///     Creates a chain.
        /// </summary>
        /// <param name="world">The world.</param>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <param name="linkWidth">The width.</param>
        /// <param name="linkHeight">The height.</param>
        /// <param name="numberOfLinks">The number of links.</param>
        /// <param name="linkDensity">The link density.</param>
        /// <param name="attachRopeJoint">
        ///     Creates a rope joint between start and end. This enforces the length of the rope. Said in
        ///     another way: it makes the rope less bouncy.
        /// </param>
        /// <returns></returns>
        public Path CreateChain(Vector2F start, Vector2F end, float linkWidth, float linkHeight, int numberOfLinks, float linkDensity, bool attachRopeJoint)
        {
            Debug.Assert(numberOfLinks >= 2);

            //Chain start / end
            Path path = new Path();
            path.Add(start);
            path.Add(end);

            //A single chainlink
            PolygonShape shape = new PolygonShape(PolygonTools.CreateRectangle(linkWidth, linkHeight), linkDensity);

            //Use PathManager to create all the chainlinks based on the chainlink created before.
            List<Body> chainLinks = PathManager.EvenlyDistributeShapesAlongPath(this, path, shape, BodyType.Dynamic, numberOfLinks);


            //if (fixStart)
            //{
            //    //Fix the first chainlink to the world
            //    JointFactory.CreateFixedRevoluteJoint(this, chainLinks[0], new Vector2F(0, -(linkHeight / 2)),
            //                                          chainLinks[0].Position);
            //}

            //if (fixEnd)
            //{
            //    //Fix the last chainlink to the world
            //    JointFactory.CreateFixedRevoluteJoint(this, chainLinks[chainLinks.Count - 1],
            //                                          new Vector2F(0, (linkHeight / 2)),
            //                                          chainLinks[chainLinks.Count - 1].Position);
            //}

            //Attach all the chainlinks together with a revolute joint
            PathManager.AttachBodiesWithRevoluteJoint(this, chainLinks, new Vector2F(0, -linkHeight), new Vector2F(0, linkHeight), false, false);

            if (attachRopeJoint)
            {
                JointFactory.CreateRopeJoint(this, chainLinks[0], chainLinks[chainLinks.Count - 1], Vector2F.Zero, Vector2F.Zero);
            }

            return path;
        }
    }
}