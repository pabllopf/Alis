// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   TestWorld.cs
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

using System.Collections.Generic;
using System.Numerics;
using Alis.Core.Systems.Physics2D.Definitions;
using Alis.Core.Systems.Physics2D.Dynamics;
using NUnit.Framework;

namespace Alis.Core.Systems.Physics2D.Test
{
    /// <summary>
    ///     The test world class
    /// </summary>
    public class TestWorld
    {
        /// <summary>
        ///     The world
        /// </summary>
        public World world;

        /// <summary>
        ///     Setup this instance
        /// </summary>
        [SetUp]
        public void Setup() => world = new World(Vector2.Zero);

        /// <summary>
        ///     Tests that test world creation
        /// </summary>
        [Test]
        public void TestWorldCreation()
        {
            Assert.IsNotNull(world);
        }

        /// <summary>
        ///     Tests that test world add body
        /// </summary>
        /// <param name="numBodies">The num bodies</param>
        [Test, TestCase(0), TestCase(1), TestCase(100)]
        public void TestWorldAddBody(int numBodies)
        {
            for (int i = 0; i < numBodies; i++)
            {
                world.AddBody(new Body(new BodyDef
                {
                    Position = new Vector2(1 * i + 1, 1 * i + 1),
                    Type = BodyType.Dynamic
                }));
            }

            Assert.AreEqual(numBodies, world.BodyList.Count);
        }

        /// <summary>
        ///     Tests that test remove body
        /// </summary>
        /// <param name="numBodies">The num bodies</param>
        [Test, TestCase(0), TestCase(1), TestCase(100)]
        public void TestRemoveBody(int numBodies)
        {
            List<Body> bodies = new List<Body>();

            for (int i = 0; i < numBodies; i++)
            {
                Body body = new Body(new BodyDef
                {
                    Position = new Vector2(1 * i + 1, 1 * i + 1),
                    Type = BodyType.Dynamic
                });

                bodies.Add(body);
                world.AddBody(body);
            }

            for (int i = 0; i < numBodies; i++)
            {
                world.RemoveBody(bodies[i]);
            }

            Assert.AreEqual(0, world.BodyList.Count);
        }


        /// <summary>
        ///     Tests that test clear forces
        /// </summary>
        /// <param name="numBodies">The num bodies</param>
        [Test, TestCase(0), TestCase(1), TestCase(100)]
        public void TestClearForces(int numBodies)
        {
            for (int i = 0; i < numBodies; i++)
            {
                world.AddBody(new Body(new BodyDef
                {
                    Position = new Vector2(1 * i + 1, 1 * i + 1),
                    Type = BodyType.Dynamic
                }));
            }

            world.ClearForces();
            Assert.AreEqual(numBodies, world.BodyList.Count);
            for (int i = 0; i < world.BodyList.Count; i++)
            {
                Assert.AreEqual(new Vector2(0.0f, 0.0f), world.BodyList[i].Force);
                Assert.AreEqual(0.0f, world.BodyList[i].Torque);
            }
        }
    }
}