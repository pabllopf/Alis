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
using Alis.Core.Physic.Collision.Shapes;
using Alis.Core.Physic.Common.Decomposition;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Contacts;

namespace Alis.Core.Physic.Common.PhysicsLogic
{
    /// <summary>
    ///     A type of body that supports multiple fixtures that can break apart.
    /// </summary>
    public class BreakableBody
    {
        /// <summary>
        ///     The angular velocities cache
        /// </summary>
        private float[] _angularVelocitiesCache = new float[8];

        /// <summary>
        ///     The vector
        /// </summary>
        private Vector2F[] _velocitiesCache = new Vector2F[8];

        /// <summary>
        ///     The fixture
        /// </summary>
        public List<Fixture> Parts = new List<Fixture>(8);

        /// <summary>
        ///     The force needed to break the body apart.
        ///     Default: 500
        /// </summary>
        public float Strength = 500.0f;

        /// <summary>
        ///     Initializes a new instance of the <see cref="BreakableBody" /> class
        /// </summary>
        /// <param name="world">The world</param>
        private BreakableBody(World world)
        {
            World = world;
            World.ContactManager.PostSolve += PostSolve;

            State = BreakableBodyState.Unbroken;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="BreakableBody" /> class
        /// </summary>
        /// <param name="world">The world</param>
        /// <param name="vertices">The vertices</param>
        /// <param name="density">The density</param>
        /// <param name="position">The position</param>
        /// <param name="rotation">The rotation</param>
        public BreakableBody(World world, IEnumerable<Vertices> vertices, float density, Vector2F position = new Vector2F(), float rotation = 0) : this(world)
        {
            MainBody = World.CreateBody(position, rotation, BodyType.Dynamic);

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
        /// <param name="world">The world</param>
        /// <param name="shapes">The shapes</param>
        /// <param name="position">The position</param>
        /// <param name="rotation">The rotation</param>
        public BreakableBody(World world, IEnumerable<Shape> shapes, Vector2F position = new Vector2F(), float rotation = 0) : this(world)
        {
            MainBody = World.CreateBody(position, rotation, BodyType.Dynamic);

            foreach (Shape part in shapes)
            {
                Fixture fixture = MainBody.CreateFixture(part);
                Parts.Add(fixture);
            }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="BreakableBody" /> class
        /// </summary>
        /// <param name="world">The world</param>
        /// <param name="vertices">The vertices</param>
        /// <param name="density">The density</param>
        /// <param name="position">The position</param>
        /// <param name="rotation">The rotation</param>
        public BreakableBody(World world, Vertices vertices, float density, Vector2F position = new Vector2F(), float rotation = 0) : this(world)
        {
            MainBody = World.CreateBody(position, rotation, BodyType.Dynamic);


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
        public World World { get; }

        /// <summary>
        ///     Gets the value of the main body
        /// </summary>
        public Body MainBody { get; }

        /// <summary>
        ///     Gets or sets the value of the state
        /// </summary>
        public BreakableBodyState State { get; private set; }

        /// <summary>
        ///     Posts the solve using the specified contact
        /// </summary>
        /// <param name="contact">The contact</param>
        /// <param name="impulse">The impulse</param>
        private void PostSolve(Contact contact, ContactVelocityConstraint impulse)
        {
            if (State != BreakableBodyState.Broken)
            {
                if (Parts.Contains(contact.FixtureA) || Parts.Contains(contact.FixtureB))
                {
                    float maxImpulse = 0.0f;
                    int count = contact.Manifold.PointCount;

                    for (int i = 0; i < count; ++i)
                    {
                        maxImpulse = Math.Max(maxImpulse, impulse.points[i].normalImpulse);
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
        private void CacheVelocities()
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
                _velocitiesCache[i] = Parts[i].Body.LinearVelocity;
                _angularVelocitiesCache[i] = Parts[i].Body.AngularVelocity;
            }
        }

        /// <summary>
        ///     Decomposes this instance
        /// </summary>
        /// <exception cref="InvalidOperationException">BreakableBody is allready broken</exception>
        private void Decompose()
        {
            if (State == BreakableBodyState.Broken)
            {
                throw new InvalidOperationException("BreakableBody is allready broken");
            }

            //Unsubsribe from the PostSolve delegate
            World.ContactManager.PostSolve -= PostSolve;

            for (int i = 0; i < Parts.Count; i++)
            {
                Fixture oldFixture = Parts[i];

                Shape shape = oldFixture.Shape.Clone();
                object fixtureTag = oldFixture.Tag;

                MainBody.Remove(oldFixture);

                Body body = World.CreateBody(MainBody.Position, MainBody.Rotation, BodyType.Dynamic);
                body.Tag = MainBody.Tag;

                Fixture newFixture = body.CreateFixture(shape);
                newFixture.Tag = fixtureTag;
                Parts[i] = newFixture;

                body.AngularVelocity = _angularVelocitiesCache[i];
                body.LinearVelocity = _velocitiesCache[i];
            }

            World.Remove(MainBody);

            State = BreakableBodyState.Broken;
        }
    }
}