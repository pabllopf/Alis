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
using Alis.Core.Physic.Collision.ContactSystem;
using Alis.Core.Physic.Collision.Shapes;
using Alis.Core.Physic.Dynamics.Solver;
using Alis.Core.Physic.Factories;
using Alis.Core.Physic.Shared;

namespace Alis.Core.Physic.Dynamics
{
    /// <summary>A type of body that supports multiple fixtures that can break apart.</summary>
    public class BreakableBody
    {
        /// <summary>
        ///     The world
        /// </summary>
        private readonly World world;

        /// <summary>
        ///     The angular velocities cache
        /// </summary>
        private float[] angularVelocitiesCache = new float[8];

        /// <summary>
        ///     The break
        /// </summary>
        private bool @break;

        /// <summary>
        ///     The vector
        /// </summary>
        private Vector2F[] velocitiesCache = new Vector2F[8];

        /// <summary>
        ///     Initializes a new instance of the <see cref="BreakableBody" /> class
        /// </summary>
        /// <param name="world">The world</param>
        /// <param name="parts">The parts</param>
        /// <param name="density">The density</param>
        /// <param name="position">The position</param>
        /// <param name="rotation">The rotation</param>
        public BreakableBody(World world, ICollection<Vertices> parts, float density, Vector2F position = new Vector2F(),
            float rotation = 0)
        {
            this.world = world;
            this.world.ContactManager.PostSolve += PostSolve;
            Parts = new List<Fixture>(parts.Count);
            MainBody = BodyFactory.CreateBody(this.world, position, rotation, BodyType.Dynamic);
            Strength = 500.0f;

            foreach (Vertices part in parts)
            {
                PolygonShape polygonShape = new PolygonShape(part, density);
                Fixture fixture = MainBody.AddFixture(polygonShape);
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
        public BreakableBody(World world, IEnumerable<Shape> shapes, Vector2F position = new Vector2F(),
            float rotation = 0)
        {
            this.world = world;
            this.world.ContactManager.PostSolve += PostSolve;
            MainBody = BodyFactory.CreateBody(this.world, position, rotation, BodyType.Dynamic);
            Parts = new List<Fixture>(8);

            foreach (Shape part in shapes)
            {
                Fixture fixture = MainBody.AddFixture(part);
                Parts.Add(fixture);
            }
        }

        /// <summary>The force needed to break the body apart. Default: 500</summary>
        public float Strength { get; set; }

        /// <summary>
        ///     Gets or sets the value of the broken
        /// </summary>
        public bool Broken { get; private set; }

        /// <summary>
        ///     Gets the value of the main body
        /// </summary>
        public Body MainBody { get; }

        /// <summary>
        ///     Gets the value of the parts
        /// </summary>
        public List<Fixture> Parts { get; }

        /// <summary>
        ///     Posts the solve using the specified contact
        /// </summary>
        /// <param name="contact">The contact</param>
        /// <param name="impulse">The impulse</param>
        private void PostSolve(Contact contact, ContactVelocityConstraint impulse)
        {
            if (!Broken)
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
                        @break = true;
                    }
                }
            }
        }

        /// <summary>
        ///     Updates this instance
        /// </summary>
        public void Update()
        {
            if (@break)
            {
                Decompose();
                Broken = true;
                @break = false;
            }

            // Cache velocities to improve movement on breakage.
            if (!Broken)
            {
                //Enlarge the cache if needed
                if (Parts.Count > angularVelocitiesCache.Length)
                {
                    velocitiesCache = new Vector2F[Parts.Count];
                    angularVelocitiesCache = new float[Parts.Count];
                }

                //Cache the linear and angular velocities.
                for (int i = 0; i < Parts.Count; i++)
                {
                    velocitiesCache[i] = Parts[i].Body.LinearVelocity;
                    angularVelocitiesCache[i] = Parts[i].Body.AngularVelocity;
                }
            }
        }

        /// <summary>
        ///     Decomposes this instance
        /// </summary>
        private void Decompose()
        {
            //Unsubsribe from the PostSolve delegate
            world.ContactManager.PostSolve -= PostSolve;

            for (int i = 0; i < Parts.Count; i++)
            {
                Fixture oldFixture = Parts[i];

                Shape shape = oldFixture.Shape.Clone();
                object userData = oldFixture.UserData;

                MainBody.RemoveFixture(oldFixture);

                Body body = BodyFactory.CreateBody(world, MainBody.Position, MainBody.Rotation, BodyType.Dynamic,
                    MainBody.UserData);

                Fixture newFixture = body.AddFixture(shape);
                newFixture.UserData = userData;
                Parts[i] = newFixture;

                body.AngularVelocity = angularVelocitiesCache[i];
                body.LinearVelocity = velocitiesCache[i];
            }

            world.RemoveBody(MainBody);
            world.RemoveBreakableBody(this);
        }

        /// <summary>
        ///     Breaks this instance
        /// </summary>
        public void Break()
        {
            @break = true;
        }
    }
}