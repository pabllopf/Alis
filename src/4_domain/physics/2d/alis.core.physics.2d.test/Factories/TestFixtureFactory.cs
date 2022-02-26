// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   TestFixtureFactory.cs
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
using Alis.Core.Systems.Physics2D.Collision.Shapes;
using Alis.Core.Systems.Physics2D.Definitions;
using Alis.Core.Systems.Physics2D.Dynamics;
using Alis.Core.Systems.Physics2D.Factories;
using NUnit.Framework;

namespace Alis.Core.Systems.Physics2D.Test.Factories
{
    /// <summary>
    ///     The test fixture factory class
    /// </summary>
    public class TestFixtureFactory
    {
        /// <summary>
        ///     The fixture
        /// </summary>
        private Fixture fixture;

        /// <summary>
        ///     Setup this instance
        /// </summary>
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        ///     Tests that test 1
        /// </summary>
        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        /// <summary>
        ///     Tests that test create from def
        /// </summary>
        [Test]
        public void TestCreateFromDef()
        {
            Body? body = BodyFactory.CreateBody(new World(new Vector2(0, 0)));
            CircleShape? shape = new CircleShape(1, 1);
            FixtureDef? fixtureDef = new FixtureDef
            {
                Shape = shape,
                Friction = 0.3f,
                Restitution = 0.5f
            };

            fixture = FixtureFactory.CreateFromDef(body, fixtureDef);
        }
    }
}