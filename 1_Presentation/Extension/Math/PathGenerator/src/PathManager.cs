// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PathManager.cs
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
using Alis.Core.Physic;
using Alis.Core.Physic.Collision.Shapes;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Joints;
using Alis.Core.Physic.Shared;
using Alis.Extension.Math.PathGenerator.Triangulation;

namespace Alis.Extension.Math.PathGenerator
{
    /// <summary>An easy to use manager for creating paths.</summary>
    public static class PathManager
    {
        //Contributed by Matthew Bettcher
        
        /// <summary>Convert a path into a set of edges and attaches them to the specified body. Note: use only for static edges.</summary>
        /// <param name="path">The path.</param>
        /// <param name="body">The body.</param>
        /// <param name="subdivisions">The subdivisions.</param>
        public static void ConvertPathToEdges(Path path, Body body, int subdivisions)
        {
            Vertices verts = path.GetVertices(subdivisions);
            
            if (path.Closed)
            {
                ChainShape chain = new ChainShape(verts, true);
                body.AddFixture(chain);
            }
            else
            {
                for (int i = 1; i < verts.Count; i++)
                {
                    body.AddFixture(new EdgeShape(verts[i], verts[i - 1]));
                }
            }
        }
        
        /// <summary>Convert a closed path into a polygon. Convex decomposition is automatically performed.</summary>
        /// <param name="path">The path.</param>
        /// <param name="body">The body.</param>
        /// <param name="density">The density.</param>
        /// <param name="subdivisions">The subdivisions.</param>
        public static void ConvertPathToPolygon(Path path, Body body, float density, int subdivisions)
        {
            if (!path.Closed)
            {
                throw new Exception("The path must be closed to convert to a polygon.");
            }
            
            List<Vector2> verts = path.GetVertices(subdivisions);
            
            List<Vertices> decomposedVerts =
                Triangulate.ConvexPartition(new Vertices(verts), TriangulationAlgorithm.BayaZit);
            
            foreach (Vertices item in decomposedVerts)
            {
                body.AddFixture(new PolygonShape(item, density));
            }
        }
        
        /// <summary>Duplicates the given Body along the given path for approximately the given copies.</summary>
        /// <param name="world">The world.</param>
        /// <param name="path">The path.</param>
        /// <param name="shapes">The shapes.</param>
        /// <param name="type">The type.</param>
        /// <param name="copies">The copies.</param>
        /// <param name="userData"></param>
        /// <returns></returns>
        public static List<Body> EvenlyDistributeShapesAlongPath(World world, Path path, IEnumerable<Shape> shapes,
            BodyType type, int copies, object userData = null)
        {
            List<Vector3> centers = path.SubdivideEvenly(copies);
            List<Body> bodyList = new List<Body>();
            
            for (int i = 0; i < centers.Count; i++)
            {
                Body b = new Body(
                    new Vector2(centers[i].X, centers[i].Y),
                    new Vector2(centers[i].X, centers[i].Y),
                    BodyType.Static,
                    centers[i].Z
                );
                
                world.AddBody(b);
                
                foreach (Shape shape in shapes)
                {
                    b.AddFixture(shape);
                }
                
                bodyList.Add(b);
            }
            
            return bodyList;
        }
        
        /// <summary>Duplicates the given Body along the given path for approximately the given copies.</summary>
        /// <param name="world">The world.</param>
        /// <param name="path">The path.</param>
        /// <param name="shape">The shape.</param>
        /// <param name="type">The type.</param>
        /// <param name="copies">The copies.</param>
        /// <param name="userData">The user data.</param>
        public static List<Body> EvenlyDistributeShapesAlongPath(World world, Path path, Shape shape, BodyType type,
            int copies, object userData = null)
        {
            List<Shape> shapes = new List<Shape>(1)
            {
                shape
            };
            
            return EvenlyDistributeShapesAlongPath(world, path, shapes, type, copies, userData);
        }
        
        /// <summary>Moves the given body along the defined path.</summary>
        /// <param name="path">The path.</param>
        /// <param name="body">The body.</param>
        /// <param name="time">The time.</param>
        /// <param name="strength">The strength.</param>
        /// <param name="timeStep">The time step.</param>
        public static void MoveBodyOnPath(Path path, Body body, float time, float strength, float timeStep)
        {
            Vector2 destination = path.GetPosition(time);
            Vector2 positionDelta = body.Position - destination;
            Vector2 velocity = positionDelta / timeStep * strength;
            
            body.LinearVelocity = -velocity;
        }
        
        /// <summary>Attaches the bodies with revolute joints.</summary>
        /// <param name="world">The world.</param>
        /// <param name="bodies">The bodies.</param>
        /// <param name="localAnchorA">The local anchor A.</param>
        /// <param name="localAnchorB">The local anchor B.</param>
        /// <param name="connectFirstAndLast">if set to <c>true</c> [connect first and last].</param>
        /// <param name="collideConnected">if set to <c>true</c> [collide connected].</param>
        public static List<RevoluteJoint> AttachBodiesWithRevoluteJoint(World world, List<Body> bodies,
            Vector2 localAnchorA, Vector2 localAnchorB, bool connectFirstAndLast, bool collideConnected)
        {
            List<RevoluteJoint> joints = new List<RevoluteJoint>(bodies.Count + 1);
            
            for (int i = 1; i < bodies.Count; i++)
            {
                RevoluteJoint joint = new RevoluteJoint(bodies[i], bodies[i - 1], localAnchorA, localAnchorB)
                {
                    CollideConnected = collideConnected
                };
                world.AddJoint(joint);
                joints.Add(joint);
            }
            
            if (connectFirstAndLast)
            {
                RevoluteJoint lastjoint =
                    new RevoluteJoint(bodies[0], bodies[bodies.Count - 1], localAnchorA, localAnchorB)
                    {
                        CollideConnected = collideConnected
                    };
                world.AddJoint(lastjoint);
                joints.Add(lastjoint);
            }
            
            return joints;
        }
    }
}