// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   TestBodyFactory.cs
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

using System.Numerics;
using Alis.Core.Systems.Physics2D.Dynamics;
using Alis.Core.Systems.Physics2D.Factories;
using NUnit.Framework;

namespace Alis.Core.Systems.Physics2D.Test.Factories
{
    /// <summary>
    ///     The test body factory class
    /// </summary>
    public class TestBodyFactory
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
        ///     Tests that test create body
        /// </summary>
        [Test]
        public void TestCreateBody()
        {
            Body body = BodyFactory.CreateRectangle(world, 1, 1, 1);
            Assert.IsNotNull(body);
        }

        /// <summary>
        ///     Tests that test create circle
        /// </summary>
        [Test]
        public void TestCreateCircle()
        {
            Body body = BodyFactory.CreateCircle(world, 1, 1);

            Assert.IsNotNull(body);
        }

        /// <summary>
        ///     Tests that test create edge
        /// </summary>
        [Test]
        public void TestCreateEdge()
        {
            Body body = BodyFactory.CreateEdge(world, new Vector2(1, 1), new Vector2(2, 2));
            Assert.IsNotNull(body);
        }

        /// <summary>
        ///     Tests that create body
        /// </summary>
        [Test]
        public void CreateBody()
        {
            Body body = BodyFactory.CreateBody(world, new Vector2(0, 0), 0f, BodyType.Dynamic);

            Assert.AreEqual(BodyType.Dynamic, body.BodyType);
            Assert.AreEqual(0.0f, body.Position.X);
            Assert.AreEqual(0.0f, body.Position.Y);
            Assert.AreEqual(0.0f, body.Rotation);
            Assert.AreEqual(0.0f, body.LinearDamping);
            Assert.AreEqual(0.0f, body.LinearVelocity.X);
            Assert.AreEqual(0.0f, body.LinearVelocity.Y);
            Assert.AreEqual(0.0f, body.AngularVelocity);
            Assert.AreEqual(0.0f, body.AngularDamping);
            Assert.AreEqual(0.0f, body.Inertia);
            Assert.AreEqual(0.0f, body.Mass);
            Assert.AreEqual(0.0f, body.Inertia);
            Assert.AreEqual(false, body.IsStatic);
            Assert.AreEqual(false, body.IsKinematic);
            Assert.AreEqual(1.0f, body.GravityScale);
        }
    }
}