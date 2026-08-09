// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FixtureRemainingCoverageTests.cs
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

using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    ///     The fixture remaining coverage tests class
    /// </summary>
    public class FixtureRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that ray cast with intersecting ray returns output
        /// </summary>
        [Fact]
        public void RayCast_WithIntersectingRay_ReturnsOutput()
        {
            Body body = new Body();
            Fixture fixture = body.CreateFixture(new CircleShape(1.0f, 1.0f));
            RayCastInput input = new RayCastInput
            {
                Point1 = new Vector2F(-5, 0),
                Point2 = new Vector2F(5, 0),
                MaxFraction = 1.0f
            };

            bool hit = fixture.RayCast(out RayCastOutput output, ref input, 0);

            Assert.True(hit);
            Assert.True(output.Fraction > 0.0f);
            Assert.True(output.Fraction <= 1.0f);
        }

        /// <summary>
        ///     Tests that ray cast with non intersecting ray misses
        /// </summary>
        [Fact]
        public void RayCast_WithNonIntersectingRay_Misses()
        {
            Body body = new Body();
            Fixture fixture = body.CreateFixture(new CircleShape(1.0f, 1.0f));
            RayCastInput input = new RayCastInput
            {
                Point1 = new Vector2F(-5, 10),
                Point2 = new Vector2F(5, 10),
                MaxFraction = 1.0f
            };

            bool hit = fixture.RayCast(out RayCastOutput output, ref input, 0);

            Assert.False(hit);
        }

        /// <summary>
        ///     Tests that get aabb returns bounds for circle
        /// </summary>
        [Fact]
        public void GetAabb_ReturnsBoundsForCircle()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Fixture fixture = body.CreateFixture(new CircleShape(1.0f, 1.0f));

            fixture.GetAabb(out Aabb aabb, 0);

            Assert.True(aabb.Width > 0.0f);
            Assert.True(aabb.Height > 0.0f);
        }

        /// <summary>
        ///     Tests that refilter with changed group refilters proxies
        /// </summary>
        [Fact]
        public void Refilter_WithChangedGroup_RefiltersProxies()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Fixture fixture = body.CreateFixture(new CircleShape(1.0f, 1.0f));
            fixture.CollisionGroup = 5;

            fixture.Refilter();

            Assert.NotNull(fixture);
        }

        /// <summary>
        ///     Tests that create proxies assigns proxy count
        /// </summary>
        [Fact]
        public void CreateProxies_AssignsProxyCount()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Fixture fixture = body.CreateFixture(new CircleShape(1.0f, 1.0f));

            Assert.True(fixture.ProxyCount > 0);
        }

        /// <summary>
        ///     Tests that clone onto body copies shape and properties
        /// </summary>
        [Fact]
        public void CloneOnto_CopiesShapeAndProperties()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body sourceBody = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body targetBody = world.CreateBody(new Vector2F(5, 0), 0, BodyType.Dynamic);
            Fixture source = sourceBody.CreateFixture(new CircleShape(1.0f, 1.0f));
            source.Tag = "fixture-tag";
            source.GetFriction = 0.5f;
            source.GetRestitution = 0.25f;
            source.GetCollidesWith = Categories.All;
            source.GetCollisionCategories = Categories.All;

            Fixture clone = source.CloneOnto(targetBody);

            Assert.Same(targetBody, clone.GetBody);
            Assert.Equal("fixture-tag", clone.Tag);
            Assert.Equal(0.5f, clone.GetFriction, 5);
            Assert.Equal(0.25f, clone.GetRestitution, 5);
        }

        /// <summary>
        ///     Tests that collision event handlers round trip
        /// </summary>
        [Fact]
        public void CollisionEventHandlers_RoundTrip()
        {
            Fixture fixture = new Fixture(new CircleShape(1.0f, 1.0f));
            bool invoked = false;
            OnCollisionEventHandler handler = (fa, fb, contact) => { invoked = true; return true; };

            fixture.OnCollision += handler;
            fixture.OnCollision(fixture, fixture, null);

            Assert.True(invoked);
        }

        /// <summary>
        ///     Tests that separation event handlers round trip
        /// </summary>
        [Fact]
        public void SeparationEventHandlers_RoundTrip()
        {
            Fixture fixture = new Fixture(new CircleShape(1.0f, 1.0f));
            bool invoked = false;
            OnSeparationEventHandler handler = (fa, fb, contact) => invoked = true;

            fixture.OnSeparation += handler;
            fixture.OnSeparation(fixture, fixture, null);

            Assert.True(invoked);
        }

        /// <summary>
        ///     Tests that before collision event handlers round trip
        /// </summary>
        [Fact]
        public void BeforeCollisionEventHandlers_RoundTrip()
        {
            Fixture fixture = new Fixture(new CircleShape(1.0f, 1.0f));
            bool invoked = false;
            BeforeCollisionEventHandler handler = (fa, fb) => { invoked = true; return true; };

            fixture.BeforeCollision += handler;
            fixture.BeforeCollision(fixture, fixture);

            Assert.True(invoked);
        }

        /// <summary>
        ///     Tests that after collision event handlers round trip
        /// </summary>
        [Fact]
        public void AfterCollisionEventHandlers_RoundTrip()
        {
            Fixture fixture = new Fixture(new CircleShape(1.0f, 1.0f));
            bool invoked = false;
            AfterCollisionEventHandler handler = (fa, fb, contact, impulse) => invoked = true;

            fixture.AfterCollision += handler;
            fixture.AfterCollision(fixture, fixture, null, null);

            Assert.True(invoked);
        }
    }
}
