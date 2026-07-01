// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SettingEnvTest.cs
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
using Xunit;

namespace Alis.Core.Physic.Test
{
    /// <summary>
    /// The setting env test class
    /// </summary>
    public class SettingEnvTest
    {
        /// <summary>
        /// Tests that setting env type should be accessible
        /// </summary>
        [Fact]
        public void SettingEnv_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(SettingEnv));
            Assert.True(SettingEnv.MaxFloat > 0.0f);
        }

        /// <summary>
        /// Tests that polygon radius is derived from linear slop
        /// </summary>
        [Fact]
        public void PolygonRadius_ShouldBeDerivedFromLinearSlop()
        {
            Assert.Equal(2.0f * SettingEnv.LinearSlop, SettingEnv.PolygonRadius);
        }

        /// <summary>
        /// Tests that max translation squared is consistent with max translation
        /// </summary>
        [Fact]
        public void MaxTranslationSquared_ShouldBeConsistentWithMaxTranslation()
        {
            Assert.Equal(SettingEnv.MaxTranslation * SettingEnv.MaxTranslation, SettingEnv.MaxTranslationSquared);
        }

        /// <summary>
        /// Tests that max rotation squared is consistent with max rotation
        /// </summary>
        [Fact]
        public void MaxRotationSquared_ShouldBeConsistentWithMaxRotation()
        {
            Assert.Equal(SettingEnv.MaxRotation * SettingEnv.MaxRotation, SettingEnv.MaxRotationSquared);
        }

        /// <summary>
        /// Tests that angular slop is correct in radians
        /// </summary>
        [Fact]
        public void AngularSlop_ShouldBeTwoDegreesInRadians()
        {
            float expected = 2.0f / 180.0f * (float)Math.PI;
            Assert.Equal(expected, SettingEnv.AngularSlop, 6);
        }

        /// <summary>
        /// Tests that max angular correction is correct in radians
        /// </summary>
        [Fact]
        public void MaxAngularCorrection_ShouldBeEightDegreesInRadians()
        {
            float expected = 8.0f / 180.0f * (float)Math.PI;
            Assert.Equal(expected, SettingEnv.MaxAngularCorrection, 6);
        }

        /// <summary>
        /// Tests that diagnostics are enabled by default
        /// </summary>
        [Fact]
        public void EnableDiagnostics_ShouldBeTrue()
        {
            Assert.True(SettingEnv.EnableDiagnostics);
        }

        /// <summary>
        /// Tests that auto clear forces is enabled by default
        /// </summary>
        [Fact]
        public void AutoClearForces_ShouldBeTrue()
        {
            Assert.True(SettingEnv.AutoClearForces);
        }

        /// <summary>
        /// Tests that MixFriction returns geometric mean of two values
        /// </summary>
        [Fact]
        public void MixFriction_TwoEqualValues_ReturnsSameValue()
        {
            float result = SettingEnv.MixFriction(0.5f, 0.5f);
            Assert.Equal(0.5f, result, 6);
        }

        /// <summary>
        /// Tests that MixFriction with zero returns zero
        /// </summary>
        [Fact]
        public void MixFriction_WithZero_ReturnsZero()
        {
            float result = SettingEnv.MixFriction(0.0f, 0.5f);
            Assert.Equal(0.0f, result, 6);
        }

        /// <summary>
        /// Tests that MixFriction with two different values returns geometric mean
        /// </summary>
        [Fact]
        public void MixFriction_TwoDifferentValues_ReturnsGeometricMean()
        {
            float result = SettingEnv.MixFriction(0.25f, 0.36f);
            float expected = (float)Math.Sqrt(0.25f * 0.36f);
            Assert.Equal(expected, result, 6);
        }

        /// <summary>
        /// Tests that MixFriction with max float returns max sqrt
        /// </summary>
        [Fact]
        public void MixFriction_WithMaxFloat_ReturnsMaxSqrt()
        {
            float result = SettingEnv.MixFriction(SettingEnv.MaxFloat, SettingEnv.MaxFloat);
            float expected = (float)Math.Sqrt(SettingEnv.MaxFloat * SettingEnv.MaxFloat);
            Assert.Equal(expected, result, 6);
        }

        /// <summary>
        /// Tests that MixRestitution returns the larger of two values
        /// </summary>
        [Fact]
        public void MixRestitution_FirstLarger_ReturnsFirst()
        {
            float result = SettingEnv.MixRestitution(0.8f, 0.2f);
            Assert.Equal(0.8f, result);
        }

        /// <summary>
        /// Tests that MixRestitution returns the larger of two values when second is larger
        /// </summary>
        [Fact]
        public void MixRestitution_SecondLarger_ReturnsSecond()
        {
            float result = SettingEnv.MixRestitution(0.2f, 0.8f);
            Assert.Equal(0.8f, result);
        }

        /// <summary>
        /// Tests that MixRestitution with equal values returns the same
        /// </summary>
        [Fact]
        public void MixRestitution_EqualValues_ReturnsSame()
        {
            float result = SettingEnv.MixRestitution(0.5f, 0.5f);
            Assert.Equal(0.5f, result);
        }

        /// <summary>
        /// Tests that MixRestitution with zero and one returns one
        /// </summary>
        [Fact]
        public void MixRestitution_WithZero_ReturnsLarger()
        {
            float result = SettingEnv.MixRestitution(0.0f, 1.0f);
            Assert.Equal(1.0f, result);
        }

        /// <summary>
        /// Tests that MixRestitution with negative values works correctly
        /// </summary>
        [Fact]
        public void MixRestitution_NegativeValues_ReturnsLarger()
        {
            float result = SettingEnv.MixRestitution(-0.5f, -0.1f);
            Assert.Equal(-0.1f, result);
        }
    }
}

