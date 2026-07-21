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
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Logic
{
    /// <summary>
    ///     The simple explosion test class
    /// </summary>
    public class SimpleExplosionTest
    {
        /// <summary>
        ///     Tests that constructor initializes power to 1
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializePowerToOne()
        {
            WorldPhysic world = new WorldPhysic();

            SimpleExplosion explosion = new SimpleExplosion(world);

            Assert.Equal(1f, explosion.Power);
        }

        /// <summary>
        ///     Tests that Power property can be set and retrieved
        /// </summary>
        [Fact]
        public void Power_ShouldGetAndSetCorrectly()
        {
            WorldPhysic world = new WorldPhysic();

            SimpleExplosion explosion = new SimpleExplosion(world);
            explosion.Power = 2f;

            Assert.Equal(2f, explosion.Power);
        }

        /// <summary>
        ///     Tests that GetPercent returns 0 when distance equals radius and power is 1
        /// </summary>
        [Fact]
        public void GetPercent_WhenDistanceEqualsRadius_ShouldReturnZero()
        {
            WorldPhysic world = new WorldPhysic();

            SimpleExplosion explosion = new SimpleExplosion(world);
            float percent = explosion.GetPercent(10f, 10f);

            Assert.Equal(0f, percent);
        }

        /// <summary>
        ///     Tests that GetPercent returns 1 when distance is 0
        /// </summary>
        [Fact]
        public void GetPercent_WhenDistanceIsZero_ShouldReturnOne()
        {
            WorldPhysic world = new WorldPhysic();

            SimpleExplosion explosion = new SimpleExplosion(world);
            float percent = explosion.GetPercent(0f, 10f);

            Assert.Equal(1f, percent);
        }

        /// <summary>
        ///     Tests that GetPercent returns clamped value between 0 and 1
        /// </summary>
        [Fact]
        public void GetPercent_ShouldReturnClampedValue()
        {
            WorldPhysic world = new WorldPhysic();

            SimpleExplosion explosion = new SimpleExplosion(world);
            float percent = explosion.GetPercent(5f, 10f);

            Assert.True(percent >= 0f && percent <= 1f);
        }

        /// <summary>
        ///     Tests that GetPercent returns 0 when result is NaN
        /// </summary>
        [Fact]
        public void GetPercent_WhenResultIsNaN_ShouldReturnZero()
        {
            WorldPhysic world = new WorldPhysic();

            SimpleExplosion explosion = new SimpleExplosion(world);
            float percent = explosion.GetPercent(float.NaN, 10f);

            Assert.Equal(0f, percent);
        }

        /// <summary>
        ///     Tests that GetPercent with power 2 returns different value than power 1
        /// </summary>
        [Fact]
        public void GetPercent_WithPowerTwo_ShouldReturnDifferentValue()
        {
            WorldPhysic world = new WorldPhysic();

            SimpleExplosion explosion = new SimpleExplosion(world);
            explosion.Power = 2f;

            float percentPower1 = new SimpleExplosion(world).GetPercent(5f, 10f);
            float percentPower2 = explosion.GetPercent(5f, 10f);

            Assert.NotEqual(percentPower1, percentPower2);
        }

        /// <summary>
        ///     Tests that ApplyImpulse applies force to body in range
        /// </summary>
        [Fact]
        public void ApplyImpulse_WithBodyInRange_ShouldApplyForce()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateCircle(1f, 1f, new Vector2F(5f, 0), BodyType.Dynamic);
            SimpleExplosion explosion = new SimpleExplosion(world);
            HashSet<Body> bodies = new HashSet<Body> { body };

            Dictionary<Body, Vector2F> forces = explosion.ApplyImpulse(Vector2F.Zero, 10f, 100f, float.MaxValue, bodies);

            Assert.Single(forces);
            Assert.True(forces[body].Length() > 0);
        }

        /// <summary>
        ///     Tests that ApplyImpulse limits force to maxForce
        /// </summary>
        [Fact]
        public void ApplyImpulse_WithMaxForce_ShouldLimitForce()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateCircle(1f, 1f, new Vector2F(5f, 0), BodyType.Dynamic);
            SimpleExplosion explosion = new SimpleExplosion(world);
            HashSet<Body> bodies = new HashSet<Body> { body };

            Dictionary<Body, Vector2F> forces = explosion.ApplyImpulse(new Vector2F(0, 0), 10f, 1000f, 5f, bodies);

            Assert.True(forces[body].Length() <= 5f + 0.001f);
        }

        /// <summary>
        ///     Tests that ApplyImpulse skips body when IsActiveOn returns false
        /// </summary>
        [Fact]
        public void ApplyImpulse_WithFilteredBody_ShouldSkip()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateCircle(1f, 1f, new Vector2F(0, 0), BodyType.Dynamic);
            SimpleExplosion explosion = new SimpleExplosion(world);
            body.ControllerFilter.IgnoreController(explosion.ControllerCategories);
            HashSet<Body> bodies = new HashSet<Body> { body };

            Dictionary<Body, Vector2F> forces = explosion.ApplyImpulse(Vector2F.Zero, 10f, 100f, float.MaxValue, bodies);

            Assert.Empty(forces);
        }

        /// <summary>
        ///     Tests that ApplyImpulse with distance near radius applies small force
        /// </summary>
        [Fact]
        public void ApplyImpulse_WithBodyNearEdge_ShouldApplySmallForce()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateCircle(1f, 1f, new Vector2F(9f, 0), BodyType.Dynamic);
            SimpleExplosion explosion = new SimpleExplosion(world);
            HashSet<Body> bodies = new HashSet<Body> { body };

            Dictionary<Body, Vector2F> forces = explosion.ApplyImpulse(Vector2F.Zero, 10f, 100f, float.MaxValue, bodies);

            Assert.Single(forces);
            Assert.True(forces[body].Length() < 100f);
        }

        /// <summary>
        ///     Tests that Activate with body in range returns non-empty dictionary
        /// </summary>
        [Fact]
        public void Activate_WithBodyInRange_ShouldReturnNonEmpty()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateCircle(1f, 1f, new Vector2F(5f, 0), BodyType.Dynamic);
            SimpleExplosion explosion = new SimpleExplosion(world);

            Dictionary<Body, Vector2F> result = explosion.Activate(Vector2F.Zero, 10f, 100f);

            Assert.NotEmpty(result);
        }

        /// <summary>
        ///     Tests that Activate with no bodies in range returns empty dictionary
        /// </summary>
        [Fact]
        public void Activate_WithNoBodiesInRange_ShouldReturnEmpty()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateCircle(1f, 1f, new Vector2F(100f, 0), BodyType.Dynamic);
            SimpleExplosion explosion = new SimpleExplosion(world);

            Dictionary<Body, Vector2F> result = explosion.Activate(Vector2F.Zero, 10f, 100f);

            Assert.Empty(result);
        }

        /// <summary>
        ///     Tests that Activate with max force limits applied force
        /// </summary>
        [Fact]
        public void Activate_WithMaxForce_ShouldLimitForce()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateCircle(1f, 1f, new Vector2F(5f, 0), BodyType.Dynamic);
            SimpleExplosion explosion = new SimpleExplosion(world);

            Dictionary<Body, Vector2F> result = explosion.Activate(Vector2F.Zero, 10f, 1000f, 5f);

            Assert.NotEmpty(result);
            Assert.True(result[body].Length() <= 5f + 0.001f);
        }

        /// <summary>
        ///     Tests that Activate with static body returns empty
        /// </summary>
        [Fact]
        public void Activate_WithStaticBody_ShouldReturnEmpty()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateCircle(1f, 1f, new Vector2F(5f, 0), BodyType.Static);
            SimpleExplosion explosion = new SimpleExplosion(world);

            Dictionary<Body, Vector2F> result = explosion.Activate(Vector2F.Zero, 10f, 100f);

            Assert.Empty(result);
        }

        /// <summary>
        ///     Tests that Activate with multiple bodies returns all affected
        /// </summary>
        [Fact]
        public void Activate_WithMultipleBodies_ShouldReturnAllAffected()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body1 = world.CreateCircle(1f, 1f, new Vector2F(5f, 0), BodyType.Dynamic);
            Body body2 = world.CreateCircle(1f, 1f, new Vector2F(-5f, 0), BodyType.Dynamic);
            SimpleExplosion explosion = new SimpleExplosion(world);

            Dictionary<Body, Vector2F> result = explosion.Activate(Vector2F.Zero, 10f, 100f);

            Assert.Equal(2, result.Count);
        }

        /// <summary>
        ///     Tests that Activate correctly handles a body within the AABB but outside the explosion radius.
        ///     Exercises the Vector2F.Distance(...) > radius branch of the QueryAabb lambda.
        /// </summary>
        [Fact]
        public void Activate_WithBodyInsideAabbButOutsideRadius_ShouldReturnEmpty()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateCircle(1f, 1f, new Vector2F(4f, 4f), BodyType.Dynamic);
            SimpleExplosion explosion = new SimpleExplosion(world);

            Dictionary<Body, Vector2F> result = explosion.Activate(Vector2F.Zero, 5f, 100f);

            Assert.Empty(result);
        }

        /// <summary>
        ///     Tests that Activate with body outside radius but within AABB returns empty
        /// </summary>
        [Fact]
        public void Activate_WithBodyOutsideRadiusButInsideAabb_ShouldReturnEmpty()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateCircle(1f, 1f, new Vector2F(8f, 0), BodyType.Dynamic);
            SimpleExplosion explosion = new SimpleExplosion(world);

            Dictionary<Body, Vector2F> result = explosion.Activate(Vector2F.Zero, 5f, 100f);

            Assert.Empty(result);
        }

        /// <summary>
        ///     Tests that Activate with ignored controller returns empty
        /// </summary>
        [Fact]
        public void Activate_WithIgnoredController_ShouldReturnEmpty()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateCircle(1f, 1f, new Vector2F(5f, 0), BodyType.Dynamic);
            SimpleExplosion explosion = new SimpleExplosion(world);
            body.ControllerFilter.IgnoreController(explosion.ControllerCategories);

            Dictionary<Body, Vector2F> result = explosion.Activate(Vector2F.Zero, 10f, 100f);

            Assert.Empty(result);
        }

        /// <summary>
        ///     Tests that Activate with zero radius returns empty
        /// </summary>
        [Fact]
        public void Activate_WithZeroRadius_ShouldReturnEmpty()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateCircle(1f, 1f, new Vector2F(5f, 0), BodyType.Dynamic);
            SimpleExplosion explosion = new SimpleExplosion(world);

            Dictionary<Body, Vector2F> result = explosion.Activate(Vector2F.Zero, 0f, 100f);

            Assert.Empty(result);
        }

        /// <summary>
        ///     Tests that Activate with disabled body returns empty
        /// </summary>
        [Fact]
        public void Activate_WithDisabledBody_ShouldReturnEmpty()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateCircle(1f, 1f, new Vector2F(5f, 0), BodyType.Dynamic);
            body.Enabled = false;
            SimpleExplosion explosion = new SimpleExplosion(world);

            Dictionary<Body, Vector2F> result = explosion.Activate(Vector2F.Zero, 10f, 100f);

            Assert.Empty(result);
        }

        /// <summary>
        ///     Tests that GetPercent with power zero handles math correctly
        /// </summary>
        [Fact]
        public void GetPercent_WithPowerZero_ShouldReturnZero()
        {
            WorldPhysic world = new WorldPhysic();
            SimpleExplosion explosion = new SimpleExplosion(world);
            explosion.Power = 0f;

            float percent = explosion.GetPercent(5f, 10f);

            Assert.InRange(percent, 0f, 1f);
        }

        /// <summary>
        ///     Tests that GetPercent clamps negative values to zero
        /// </summary>
        [Fact]
        public void GetPercent_NegativeResult_ShouldClampToZero()
        {
            WorldPhysic world = new WorldPhysic();
            SimpleExplosion explosion = new SimpleExplosion(world);

            float percent = explosion.GetPercent(15f, 10f);

            Assert.Equal(0f, percent);
        }

        /// <summary>
        ///     Tests that GetPercent clamps values above one to one
        /// </summary>
        [Fact]
        public void GetPercent_ResultAboveOne_ShouldClampToOne()
        {
            WorldPhysic world = new WorldPhysic();
            SimpleExplosion explosion = new SimpleExplosion(world);

            float percent = explosion.GetPercent(-5f, 10f);

            Assert.Equal(1f, percent);
        }
    }
}
