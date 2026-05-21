// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BreakableBody.cs
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
using Alis.Core.Physic.Common.Decomposition;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Contacts;

namespace Alis.Core.Physic.Common.Logic
{
/// <summary>
///     Represents a breakable body composed of multiple fixtures that can separate when subjected to sufficient force.
///     This class manages a collection of fixtures that belong to a main body, and when the impact force exceeds
///     a specified strength threshold, the body decomposes into separate independent bodies.
///     The breakable body tracks its state (unbroken, should break, broken) and caches velocities to ensure
///     proper physical behavior after decomposition.
///     
///     When a breakable body is subjected to a collision with an impulse greater than its Strength property,
///     it transitions from Unbroken to ShouldBreak state, and during the next Update() call it decomposes into
///     separate Body instances, each containing one of the original fixtures with preserved velocities.
///     
///     Usage example:
///     <code>
///     // Create a breakable body from a list of vertices
///     var verticesList = new List&lt;Vertices&gt; { /* polygon vertices */ };
///     var breakableBody = new BreakableBody(world, verticesList, 1.0f);
///     
///     // Adjust the strength threshold (optional)
///     breakableBody.Strength = 1000.0f;
///     
///     // In your game loop:
///     breakableBody.Update(); // Check for and handle breaking
///     </code>
/// </summary>
    public class BreakableBody
    {
/// <summary>
///     Gets the list of fixtures that make up this breakable body.
///     Each fixture represents a separate part that can break away from the main body
///     when sufficient force is applied. The list is initialized with a capacity of 8.
/// </summary>
        public readonly List<Fixture> Parts = new List<Fixture>(8);

/// <summary>
///     Gets the force threshold required to break the body apart.
///     When the impulse from a collision exceeds this value, the body will break.
///     The default value is 500.0f units of force.
/// </summary>
        public readonly float Strength = 500.0f;

        /// <summary>
        ///     The angular velocities cache
        /// </summary>
        internal float[] _angularVelocitiesCache = new float[8];

        /// <summary>
        ///     The vector
        /// </summary>
        internal Vector2F[] _velocitiesCache = new Vector2F[8];

        /// <summary>
        ///     Initializes a new instance of the <see cref="BreakableBody" /> class
        /// </summary>
        /// <param name="worldPhysic">The world</param>
        internal BreakableBody(WorldPhysic worldPhysic)
        {
            WorldPhysic = worldPhysic;
            WorldPhysic.ContactManager.PostSolve += PostSolve;

            State = BreakableBodyState.Unbroken;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="BreakableBody" /> class
        /// </summary>
        /// <param name="worldPhysic">The world</param>
        /// <param name="vertices">The vertices</param>
        /// <param name="density">The density</param>
        /// <param name="position">The position</param>
        /// <param name="rotation">The rotation</param>
        public BreakableBody(WorldPhysic worldPhysic, IEnumerable<Vertices> vertices, float density, Vector2F position = new Vector2F(), float rotation = 0) : this(worldPhysic)
        {
            MainBody = WorldPhysic.CreateBody(position, rotation, BodyType.Dynamic);

            foreach (Vertices part in vertices)
            {
                PolygonShape polygonShape = new PolygonShape(part, density);
                Fixture fixture = MainBody.CreateFixture(polygonShape);
                Parts.Add(fixture);
            }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="BreakableBody" /> class
        /// </summary>
        /// <param name="worldPhysic">The world</param>
        /// <param name="shapes">The shapes</param>
        /// <param name="position">The position</param>
        /// <param name="rotation">The rotation</param>
        public BreakableBody(WorldPhysic worldPhysic, IEnumerable<Shape> shapes, Vector2F position = new Vector2F(), float rotation = 0) : this(worldPhysic)
        {
            MainBody = WorldPhysic.CreateBody(position, rotation, BodyType.Dynamic);

            foreach (Shape part in shapes)
            {
                Fixture fixture = MainBody.CreateFixture(part);
                Parts.Add(fixture);
            }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="BreakableBody" /> class
        /// </summary>
        /// <param name="worldPhysic">The world</param>
        /// <param name="vertices">The vertices</param>
        /// <param name="density">The density</param>
        /// <param name="position">The position</param>
        /// <param name="rotation">The rotation</param>
        public BreakableBody(WorldPhysic worldPhysic, Vertices vertices, float density, Vector2F position = new Vector2F(), float rotation = 0) : this(worldPhysic)
        {
            MainBody = WorldPhysic.CreateBody(position, rotation, BodyType.Dynamic);


            List<Vertices> triangles = Triangulate.ConvexPartition(vertices, TriangulationAlgorithm.Earclip);

            foreach (Vertices part in triangles)
            {
                PolygonShape polygonShape = new PolygonShape(part, density);
                Fixture fixture = MainBody.CreateFixture(polygonShape);
                Parts.Add(fixture);
            }
        }

        /// <summary>
        ///     Gets the value of the world
        /// </summary>
        public WorldPhysic WorldPhysic { get; }

        /// <summary>
        ///     Gets the value of the main body
        /// </summary>
        public Body MainBody { get; }

        /// <summary>
        ///     Gets or sets the value of the state
        /// </summary>
        public BreakableBodyState State { get; internal set; }

        /// <summary>
        ///     Posts the solve using the specified contact
        /// </summary>
        /// <param name="contact">The contact</param>
        /// <param name="impulse">The impulse</param>
        internal void PostSolve(Contact contact, ContactVelocityConstraint impulse)
        {
            if (State != BreakableBodyState.Broken)
            {
                if (Parts.Contains(contact.FixtureA) || Parts.Contains(contact.FixtureB))
                {
                    float maxImpulse = 0.0f;
                    int count = contact.Manifold.PointCount;

                    for (int i = 0; i < count; ++i)
                    {
                        maxImpulse = Math.Max(maxImpulse, impulse.Points[i].NormalImpulse);
                    }

                    if (maxImpulse > Strength)
                    {
                        // Flag the body for breaking.
                        State = BreakableBodyState.ShouldBreak;
                    }
                }
            }
        }

        /// <summary>
        ///     Updates this instance
        /// </summary>
        public void Update()
        {
            switch (State)
            {
                case BreakableBodyState.Unbroken:
                    CacheVelocities();
                    break;
                case BreakableBodyState.ShouldBreak:
                    Decompose();
                    break;
            }
        }

        // Cache velocities to improve movement on breakage.
        /// <summary>
        ///     Caches the velocities
        /// </summary>
        internal void CacheVelocities()
        {
            //Enlarge the cache if needed
            if (Parts.Count > _angularVelocitiesCache.Length)
            {
                _velocitiesCache = new Vector2F[Parts.Count];
                _angularVelocitiesCache = new float[Parts.Count];
            }

            //Cache the linear and angular velocities.
            for (int i = 0; i < Parts.Count; i++)
            {
                _velocitiesCache[i] = Parts[i].GetBody.LinearVelocity;
                _angularVelocitiesCache[i] = Parts[i].GetBody.AngularVelocity;
            }
        }

        /// <summary>
        ///     Decomposes this instance
        /// </summary>
        /// <exception cref="InvalidOperationException">BreakableBody is allready broken</exception>
        internal void Decompose()
        {
            if (State == BreakableBodyState.Broken)
            {
                throw new InvalidOperationException("BreakableBody is allready broken");
            }

            //Unsubsribe from the PostSolve delegate
            WorldPhysic.ContactManager.PostSolve -= PostSolve;

            for (int i = 0; i < Parts.Count; i++)
            {
                Fixture oldFixture = Parts[i];

                Shape shape = oldFixture.GetShape.Clone();
                object fixtureTag = oldFixture.Tag;

                MainBody.Remove(oldFixture);

                Body body = WorldPhysic.CreateBody(MainBody.Position, MainBody.Rotation, BodyType.Dynamic);
                body.Tag = MainBody.Tag;

                Fixture newFixture = body.CreateFixture(shape);
                newFixture.Tag = fixtureTag;
                Parts[i] = newFixture;

                body.AngularVelocity = _angularVelocitiesCache[i];
                body.LinearVelocity = _velocitiesCache[i];
            }

            WorldPhysic.Remove(MainBody);

            State = BreakableBodyState.Broken;
        }
    }
}