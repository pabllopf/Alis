// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SimpleExplosionTest.cs
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

using System.Collections.Generic;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Common.Logic;
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Logic
{
    /// <summary>
    /// The simple explosion test class
    /// </summary>
    public class SimpleExplosionTest
    {
        /// <summary>
        /// Tests that simple explosion type should be accessible
        /// </summary>
        [Fact]
        public void SimpleExplosion_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(SimpleExplosion));
        }

        /// <summary>
        /// Tests that constructor sets default power to one
        /// </summary>
        [Fact]
        public void Constructor_SetsDefaultPowerToOne()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            SimpleExplosion explosion = new SimpleExplosion(world);

            Assert.Equal(1.0f, explosion.Power);
        }

        /// <summary>
        /// Tests that get percent returns positive value for distance within radius
        /// </summary>
        [Fact]
        public void GetPercent_WithinRadius_ReturnsPositive()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            SimpleExplosion explosion = new SimpleExplosion(world);

            float percent = explosion.GetPercent(0f, 5f);

            Assert.Equal(1.0f, percent);
        }

        /// <summary>
        /// Tests that get percent returns zero when distance equals radius
        /// </summary>
        [Fact]
        public void GetPercent_AtRadius_ReturnsZero()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            SimpleExplosion explosion = new SimpleExplosion(world);

            float percent = explosion.GetPercent(5f, 5f);

            Assert.Equal(0.0f, percent);
        }

        /// <summary>
        /// Tests that get percent returns clamped value when distance exceeds twice radius
        /// </summary>
        [Fact]
        public void GetPercent_BeyondRadius_ReturnsNegative()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            SimpleExplosion explosion = new SimpleExplosion(world);

            float percent = explosion.GetPercent(12f, 5f);

            Assert.Equal(0.0f, percent);
        }

        /// <summary>
        /// Tests that get percent with non integer power and negative base returns zero
        /// </summary>
        [Fact]
        public void GetPercent_WithNonIntegerPower_ReturnsZeroForNaN()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            SimpleExplosion explosion = new SimpleExplosion(world);
            explosion.Power = 0.5f;

            float percent = explosion.GetPercent(11f, 5f);

            Assert.Equal(0.0f, percent);
        }

        /// <summary>
        /// Tests that apply impulse applies force to active body
        /// </summary>
        [Fact]
        public void ApplyImpulse_WithActiveBody_AppliesForce()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body body = world.CreateBody(new Vector2F(10f, 0f), 0f, BodyType.Dynamic);
            CircleShape shape = new CircleShape(0.5f, 1.0f);
            body.CreateFixture(shape);
            SimpleExplosion explosion = new SimpleExplosion(world);
            HashSet<Body> bodies = new HashSet<Body> { body };

            Dictionary<Body, Vector2F> forces = explosion.ApplyImpulse(new Vector2F(0f, 0f), 20f, 100f, float.MaxValue, bodies);

            Assert.Single(forces);
            Assert.True(forces.ContainsKey(body));
        }

        /// <summary>
        /// Tests that apply impulse skips inactive body
        /// </summary>
        [Fact]
        public void ApplyImpulse_WithInactiveBody_SkipsBody()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body body = world.CreateBody(new Vector2F(10f, 0f), 0f, BodyType.Static);
            SimpleExplosion explosion = new SimpleExplosion(world);
            HashSet<Body> bodies = new HashSet<Body> { body };

            Dictionary<Body, Vector2F> forces = explosion.ApplyImpulse(new Vector2F(0f, 0f), 20f, 100f, float.MaxValue, bodies);

            Assert.Empty(forces);
        }

        /// <summary>
        /// Tests that apply impulse applies max force when force exceeds limit
        /// </summary>
        [Fact]
        public void ApplyImpulse_WithMaxForce_ClampsToLimit()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body body = world.CreateBody(new Vector2F(10f, 0f), 0f, BodyType.Dynamic);
            CircleShape shape = new CircleShape(0.5f, 1.0f);
            body.CreateFixture(shape);
            SimpleExplosion explosion = new SimpleExplosion(world);
            HashSet<Body> bodies = new HashSet<Body> { body };
            float maxForce = 5f;

            Dictionary<Body, Vector2F> forces = explosion.ApplyImpulse(new Vector2F(0f, 0f), 20f, 100f, maxForce, bodies);

            Assert.Single(forces);
            Assert.True(forces.ContainsKey(body));
            float appliedMagnitude = forces[body].Length();
            Assert.True(appliedMagnitude <= maxForce);
        }

        /// <summary>
        /// Tests that activate returns forces for bodies within explosion radius
        /// </summary>
        [Fact]
        public void Activate_WithBodyInRange_ReturnsForce()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body body = world.CreateBody(new Vector2F(5f, 0f), 0f, BodyType.Dynamic);
            CircleShape shape = new CircleShape(0.5f, 1.0f);
            body.CreateFixture(shape);
            SimpleExplosion explosion = new SimpleExplosion(world);

            Dictionary<Body, Vector2F> forces = explosion.Activate(new Vector2F(0f, 0f), 20f, 100f);

            Assert.NotEmpty(forces);
            Assert.True(forces.ContainsKey(body));
        }

        /// <summary>
        /// Tests that activate returns empty for body outside explosion radius
        /// </summary>
        [Fact]
        public void Activate_WithBodyOutsideRange_ReturnsEmpty()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body body = world.CreateBody(new Vector2F(100f, 0f), 0f, BodyType.Dynamic);
            CircleShape shape = new CircleShape(0.5f, 1.0f);
            body.CreateFixture(shape);
            SimpleExplosion explosion = new SimpleExplosion(world);

            Dictionary<Body, Vector2F> forces = explosion.Activate(new Vector2F(0f, 0f), 5f, 100f);

            Assert.Empty(forces);
        }
    }
}

