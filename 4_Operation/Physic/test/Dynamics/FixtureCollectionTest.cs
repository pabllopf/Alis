// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FixtureCollectionTest.cs
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
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    /// The fixture collection test class
    /// </summary>
    public class FixtureCollectionTest
    {
        /// <summary>
        /// Tests that collection should expose fixtures added to body
        /// </summary>
        [Fact]
        public void Collection_ShouldExposeFixturesAddedToBody()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Fixture fixture = body.CreateCircle(0.4f, 1.0f);

            Assert.Single(body.FixtureList);
            Assert.True(body.FixtureList.Contains(fixture));
        }

        /// <summary>
        /// Tests that collection should be read only from i collection interface
        /// </summary>
        [Fact]
        public void Collection_ShouldBeReadOnlyFromICollectionInterface()
        {
            Body body = new Body();
            FixtureCollection collection = new FixtureCollection(body);

            Assert.True(collection.IsReadOnly);
            Assert.Throws<NotSupportedException>(() => ((ICollection<Fixture>) collection).Add(new Fixture(new CircleShape(0.3f, 1.0f))));
            Assert.Throws<NotSupportedException>(() => ((ICollection<Fixture>) collection).Clear());
        }

        /// <summary>
        /// Tests that collection enumerator should iterate fixtures
        /// </summary>
        [Fact]
        public void Collection_Enumerator_ShouldIterateFixtures()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);
            body.CreateRectangle(0.5f, 0.5f, 1.0f, Vector2F.Zero);

            int count = 0;
            foreach (Fixture _ in body.FixtureList)
            {
                count++;
            }

            Assert.Equal(2, count);
        }
    }
}

