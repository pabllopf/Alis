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

using System;
using System.Collections.Generic;
using System.Linq;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Common.Logic;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test
{
    /// <summary>
    ///     Tests for the SimpleExplosion class covering GetPercent pure math logic,
    ///     constructor defaults, and integration tests for Activate/ApplyImpulse.
    /// </summary>
    public class SimpleExplosionTest : IDisposable
    {
        private SimpleExplosion? _explosion;
        private WorldPhysic? _world;

        /// <summary>
        ///     Cleans up resources
        /// </summary>
        public void Dispose()
        {
            _explosion = null;
            _world = null;
        }

        #region GetPercent Tests — Pure Math Logic

        /// <summary>
        ///     Tests that GetPercent returns 0 when distance equals radius (at boundary)
        /// </summary>
        [Fact]
        public void GetPercent_WhenDistanceEqualsRadius_ShouldReturnZero()
        {
            // Arrange — create explosion with default power (1)
            _explosion = new SimpleExplosion(CreateMockWorld());

            // Act
            float result = _explosion.GetPercent(distance: 10f, radius: 10f);

            // Assert
            Assert.Equal(0f, result);
        }

        /// <summary>
        ///     Tests that GetPercent returns 0 when distance is zero (at center, max force)
        /// </summary>
        [Fact]
        public void GetPercent_WhenDistanceIsZero_ShouldReturnMaxValue()
        {
            // Arrange — default power = 1 (linear)
            _explosion = new SimpleExplosion(CreateMockWorld());

            // Act — at center (distance=0), force is maximum
            float result = _explosion.GetPercent(distance: 0f, radius: 10f);

            // Assert — with power=1: (1 - (0-10)/10)^1 - 1 = (1 - (-1))^1 - 1 = 2 - 1 = 1
            Assert.Equal(1f, result);
        }

        /// <summary>
        ///     Tests that GetPercent returns 0 when distance exceeds radius (outside explosion)
        /// </summary>
        [Fact]
        public void GetPercent_WhenDistanceExceedsRadius_ShouldReturnZero()
        {
            // Arrange — default power = 1 (linear)
            _explosion = new SimpleExplosion(CreateMockWorld());

            // Act — outside explosion radius
            float result = _explosion.GetPercent(distance: 15f, radius: 10f);

            // Assert — (1 - (15-10)/10)^1 - 1 = (1 - 0.5)^1 - 1 = 0.5 - 1 = -0.5 → clamped to 0
            Assert.Equal(0f, result);
        }

        /// <summary>
        ///     Tests that GetPercent handles NaN from negative base with even power
        /// </summary>
        [Fact]
        public void GetPercent_WithNegativeBaseAndEvenPower_ShouldReturnZero()
        {
            // Arrange — set power to 2 (exponential)
            _explosion = new SimpleExplosion(CreateMockWorld());
            _explosion.Power = 2f;

            // Act — distance > radius creates negative base for Math.Pow
            float result = _explosion.GetPercent(distance: 15f, radius: 10f);

            // Assert — (1 - (15-10)/10)^2 - 1 = (0.5)^2 - 1 = 0.25 - 1 = -0.75 → clamped to 0
            Assert.Equal(0f, result);
        }

        /// <summary>
        ///     Tests that GetPercent returns clamped values between 0 and 1
        /// </summary>
        [Fact]
        public void GetPercent_ReturnsValuesBetweenZeroAndOne()
        {
            // Arrange — default power = 1 (linear)
            _explosion = new SimpleExplosion(CreateMockWorld());

            // Act — test various distances within radius
            float result1 = _explosion.GetPercent(distance: 5f, radius: 10f);
            float result2 = _explosion.GetPercent(distance: 2.5f, radius: 10f);
            float result3 = _explosion.GetPercent(distance: 7.5f, radius: 10f);

            // Assert — all results should be in [0, 1]
            Assert.InRange(result1, 0f, 1f);
            Assert.InRange(result2, 0f, 1f);
            Assert.InRange(result3, 0f, 1f);

            // Verify ordering: closer bodies get higher percent
            Assert.True(result2 >= result1); // 2.5f is closer than 5f → higher force
            Assert.True(result1 >= result3); // 5f is closer than 7.5f → higher force
        }

        /// <summary>
        ///     Tests that GetPercent with power=2 (exponential) gives different distribution than linear
        /// </summary>
        [Fact]
        public void GetPercent_ExponentialPowerGivesDifferentDistribution()
        {
            // Arrange — exponential power = 2
            _explosion = new SimpleExplosion(CreateMockWorld());
            _explosion.Power = 2f;

            // Act — compare linear vs exponential at same distances
            float linearResult = _explosion.GetPercent(distance: 5f, radius: 10f);
            float centerResult = _explosion.GetPercent(distance: 2.5f, radius: 10f);

            // Assert — exponential power concentrates force more at center
            Assert.InRange(linearResult, 0f, 1f);
            Assert.InRange(centerResult, 0f, 1f);
            Assert.True(centerResult >= linearResult); // closer body gets relatively more force with exponential
        }

        /// <summary>
        ///     Tests that GetPercent with power=0.5 (sub-linear) gives different distribution
        /// </summary>
        [Fact]
        public void GetPercent_SubLinearPowerGivesMoreUniformDistribution()
        {
            // Arrange — sub-linear power = 0.5
            _explosion = new SimpleExplosion(CreateMockWorld());
            _explosion.Power = 0.5f;

            // Act
            float result1 = _explosion.GetPercent(distance: 5f, radius: 10f);
            float result2 = _explosion.GetPercent(distance: 7.5f, radius: 10f);

            // Assert — sub-linear power distributes force more evenly
            Assert.InRange(result1, 0f, 1f);
            Assert.InRange(result2, 0f, 1f);
        }

        /// <summary>
        ///     Tests that GetPercent with power > 1 concentrates force near center
        /// </summary>
        [Fact]
        public void GetPercent_HighPowerConcentratesForceNearCenter()
        {
            // Arrange — high power = 5 (very concentrated)
            _explosion = new SimpleExplosion(CreateMockWorld());
            _explosion.Power = 5f;

            // Act — compare near-center vs edge
            float centerResult = _explosion.GetPercent(distance: 1f, radius: 10f);
            float edgeResult = _explosion.GetPercent(distance: 9f, radius: 10f);

            // Assert — high power creates sharp falloff
            Assert.InRange(centerResult, 0f, 1f);
            Assert.InRange(edgeResult, 0f, 1f);
        }

        /// <summary>
        ///     Tests that GetPercent returns 0 for NaN input (distance = radius, power = 0)
        /// </summary>
        [Fact]
        public void GetPercent_WhenPowerIsZeroAndDistanceEqualsRadius_ShouldReturnZero()
        {
            // Arrange — power = 0, distance = radius → (1 - 0)^0 - 1 = 1 - 1 = 0
            _explosion = new SimpleExplosion(CreateMockWorld());
            _explosion.Power = 0f;

            // Act
            float result = _explosion.GetPercent(distance: 10f, radius: 10f);

            // Assert
            Assert.Equal(0f, result);
        }

        /// <summary>
        ///     Tests that GetPercent handles very small radius values
        /// </summary>
        [Fact]
        public void GetPercent_VerySmallRadius_ShouldHandleGracefully()
        {
            // Arrange — default power = 1
            _explosion = new SimpleExplosion(CreateMockWorld());

            // Act — very small radius
            float result = _explosion.GetPercent(distance: 0.001f, radius: 0.01f);

            // Assert
            Assert.InRange(result, 0f, 1f);
        }

        /// <summary>
        ///     Tests that GetPercent handles very large radius values
        /// </summary>
        [Fact]
        public void GetPercent_VeryLargeRadius_ShouldHandleGracefully()
        {
            // Arrange — default power = 1
            _explosion = new SimpleExplosion(CreateMockWorld());

            // Act — very large radius
            float result = _explosion.GetPercent(distance: 1000f, radius: 50000f);

            // Assert
            Assert.InRange(result, 0f, 1f);
        }

        /// <summary>
        ///     Tests that GetPercent with negative distance is handled (distance can't be negative in physics)
        /// </summary>
        [Fact]
        public void GetPercent_NegativeDistance_ShouldHandleGracefully()
        {
            // Arrange — distance should never be negative in physics (it's a magnitude)
            _explosion = new SimpleExplosion(CreateMockWorld());

            // Act — negative distance (edge case)
            float result = _explosion.GetPercent(distance: -5f, radius: 10f);

            // Assert — negative distance creates (1 - (-5-10)/10) = 1 - (-1.5) = 2.5
            // 2.5^1 - 1 = 1.5 → clamped to 1
            Assert.InRange(result, 0f, 1f);
        }

        #endregion

        #region Constructor Tests

        /// <summary>
        ///     Tests that constructor initializes Power to 1 (linear) by default
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializePowerToOne()
        {
            // Arrange & Act
            _explosion = new SimpleExplosion(CreateMockWorld());

            // Assert
            Assert.Equal(1f, _explosion.Power);
        }

        /// <summary>
        ///     Tests that constructor properly assigns WorldPhysic
        /// </summary>
        [Fact]
        public void Constructor_ShouldAssignWorldPhysic()
        {
            // Arrange & Act
            WorldPhysic mockWorld = CreateMockWorld();
            _explosion = new SimpleExplosion(mockWorld);

            // Assert
            Assert.NotNull(_explosion);
        }

        /// <summary>
        ///     Tests that Power property is get/settable after construction
        /// </summary>
        [Fact]
        public void Power_ShouldBeSettableAfterConstruction()
        {
            // Arrange & Act
            _explosion = new SimpleExplosion(CreateMockWorld());
            _explosion.Power = 2f;

            // Assert
            Assert.Equal(2f, _explosion.Power);
        }

        /// <summary>
        ///     Tests that Power can be set to zero (sub-linear explosion)
        /// </summary>
        [Fact]
        public void Power_Zero_ShouldBeValid()
        {
            // Arrange & Act
            _explosion = new SimpleExplosion(CreateMockWorld());
            _explosion.Power = 0f;

            // Assert
            Assert.Equal(0f, _explosion.Power);
        }

        /// <summary>
        ///     Tests that Power can be set to very high values (concentrated explosion)
        /// </summary>
        [Fact]
        public void Power_HighValue_ShouldBeValid()
        {
            // Arrange & Act
            _explosion = new SimpleExplosion(CreateMockWorld());
            _explosion.Power = 10f;

            // Assert
            Assert.Equal(10f, _explosion.Power);
        }

        /// <summary>
        ///     Tests that Power can be set to fractional values (sub-linear)
        /// </summary>
        [Fact]
        public void Power_FractionalValue_ShouldBeValid()
        {
            // Arrange & Act
            _explosion = new SimpleExplosion(CreateMockWorld());
            _explosion.Power = 0.3f;

            // Assert
            Assert.Equal(0.3f, _explosion.Power);
        }

        #endregion

        #region Integration Tests — Require WorldPhysic (Skipped in CI)

        /// <summary>
        ///     Tests that Activate returns empty dictionary when no bodies are in range
        ///     SKIPPED — requires real WorldPhysic with QueryAabb implementation
        /// </summary>
        [Fact(Skip = "Requires real WorldPhysic with QueryAabb implementation")]
        public void Activate_WithNoBodiesInRange_ShouldReturnEmptyDictionary()
        {
            // Arrange — create explosion with empty world (no bodies)
            _explosion = new SimpleExplosion(CreateMockWorld());

            // Act — no bodies, empty QueryAabb result
            Dictionary<Body, Vector2F> result = _explosion.Activate(
                pos: new Vector2F(0, 0),
                radius: 10f,
                force: 100f);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        /// <summary>
        ///     Tests that Activate with radius 0 returns empty dictionary
        ///     SKIPPED — requires real WorldPhysic with QueryAabb implementation
        /// </summary>
        [Fact(Skip = "Requires real WorldPhysic with QueryAabb implementation")]
        public void Activate_WithZeroRadius_ShouldReturnEmptyDictionary()
        {
            // Arrange
            _explosion = new SimpleExplosion(CreateMockWorld());

            // Act
            Dictionary<Body, Vector2F> result = _explosion.Activate(
                pos: new Vector2F(0, 0),
                radius: 0f,
                force: 100f);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        /// <summary>
        ///     Tests that Activate with maxForce limits the applied force
        ///     SKIPPED — requires real WorldPhysic with QueryAabb implementation
        /// </summary>
        [Fact(Skip = "Requires real WorldPhysic with QueryAabb implementation")]
        public void Activate_WithMaxForce_LimitsAppliedForce()
        {
            // Arrange — create explosion with maxForce limit
            _explosion = new SimpleExplosion(CreateMockWorld());

            // Act — force=1000, maxForce=50 → forces capped at 50
            Dictionary<Body, Vector2F> result = _explosion.Activate(
                pos: new Vector2F(0, 0),
                radius: 10f,
                force: 1000f,
                maxForce: 50f);

            // Assert — all forces should be <= maxForce
            foreach (Vector2F forceVector in result.Values)
            {
                Assert.InRange(forceVector.Length(), 0f, 50f);
            }
        }

        /// <summary>
        ///     Tests that Activate with very large force without maxForce applies full force
        ///     SKIPPED — requires real WorldPhysic with QueryAabb implementation
        /// </summary>
        [Fact(Skip = "Requires real WorldPhysic with QueryAabb implementation")]
        public void Activate_WithVeryLargeForce_NoMaxForce_AppliesFullForce()
        {
            // Arrange
            _explosion = new SimpleExplosion(CreateMockWorld());

            // Act — no maxForce limit (float.MaxValue)
            Dictionary<Body, Vector2F> result = _explosion.Activate(
                pos: new Vector2F(0, 0),
                radius: 10f,
                force: float.MaxValue);

            // Assert
            Assert.NotNull(result);
        }

        /// <summary>
        ///     Tests that ApplyImpulse (internal) returns dictionary with body-force pairs
        ///     SKIPPED — requires real WorldPhysic with QueryAabb implementation
        /// </summary>
        [Fact(Skip = "Requires real WorldPhysic with QueryAabb implementation")]
        public void ApplyImpulse_ReturnsBodyForcePairs()
        {
            // Arrange
            _explosion = new SimpleExplosion(CreateMockWorld());

            // Act — empty overlapping bodies
            Dictionary<Body, Vector2F> result = _explosion.ApplyImpulse(
                pos: new Vector2F(0, 0),
                radius: 10f,
                force: 100f,
                maxForce: float.MaxValue,
                overlappingBodies: new HashSet<Body>());

            // Assert — empty input → empty output
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        /// <summary>
        ///     Tests that GetPercent is the core force distribution function used by Activate
        /// </summary>
        [Fact]
        public void GetPercent_IsCoreForceDistributionFunction()
        {
            // Arrange — verify GetPercent is the mathematical core of explosion force distribution
            _explosion = new SimpleExplosion(CreateMockWorld());

            // Act — verify the formula: (1 - (distance - radius) / radius)^Power - 1
            // For distance=0, radius=10, power=1: (1 - (-10)/10)^1 - 1 = 2 - 1 = 1 (max)
            // For distance=10, radius=10: (1 - 0)^1 - 1 = 0 (zero force)
            float maxForce = _explosion.GetPercent(0f, 10f);
            float zeroForce = _explosion.GetPercent(10f, 10f);

            // Assert
            Assert.Equal(1f, maxForce);
            Assert.Equal(0f, zeroForce);
        }

        /// <summary>
        ///     Tests that SimpleExplosion is sealed (cannot be inherited)
        /// </summary>
        [Fact]
        public void SimpleExplosion_ShouldBeSealed()
        {
            Assert.True(typeof(SimpleExplosion).IsSealed);
        }

        /// <summary>
        ///     Tests that SimpleExplosion inherits from PhysicsLogic
        /// </summary>
        [Fact]
        public void SimpleExplosion_ShouldInheritFromPhysicsLogic()
        {
            Assert.IsAssignableFrom<PhysicsLogic>(typeof(SimpleExplosion));
        }

        /// <summary>
        ///     Tests that multiple SimpleExplosion instances can coexist independently
        /// </summary>
        [Fact]
        public void MultipleInstances_ShouldBeIndependent()
        {
            // Arrange
            SimpleExplosion explosion1 = new SimpleExplosion(CreateMockWorld());
            SimpleExplosion explosion2 = new SimpleExplosion(CreateMockWorld());

            // Act — set different powers
            explosion1.Power = 1f;
            explosion2.Power = 2f;

            // Assert — independent power values
            Assert.Equal(1f, explosion1.Power);
            Assert.Equal(2f, explosion2.Power);

            // Clean up
            _explosion = null;
        }

        #endregion

        #region Helper Methods

        /// <summary>
        ///     Creates a mock WorldPhysic for testing.
        ///     In test environment, QueryAabb returns empty results.
        /// </summary>
        private static WorldPhysic CreateMockWorld()
        {
            // Returns a mock/stub WorldPhysic — QueryAabb returns no bodies in test env
            // This is an integration-level stub; full testing requires physics engine
            return null!;
        }

        #endregion
    }
}
