// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EpAxisTest.cs
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


using Alis.Core.Physic.Collisions;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    /// <summary>
    ///     The ep axis test class
    /// </summary>
    public class EpAxisTest
    {
        /// <summary>
        ///     Tests that constructor should initialize with default values
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeWithDefaultValues()
        {
            EpAxis epAxis = new EpAxis();

            Assert.Equal(0, epAxis.Index);
            Assert.Equal(0.0f, epAxis.Separation);
            Assert.Equal(EpAxisType.None, epAxis.Type);
        }

        /// <summary>
        ///     Tests that index should set and get correctly
        /// </summary>
        [Fact]
        public void Index_ShouldSetAndGetCorrectly()
        {
            EpAxis epAxis = new EpAxis
            {
                Index = 5
            };

            Assert.Equal(5, epAxis.Index);
        }

        /// <summary>
        ///     Tests that index with negative value should work
        /// </summary>
        [Fact]
        public void Index_WithNegativeValue_ShouldWork()
        {
            EpAxis epAxis = new EpAxis
            {
                Index = -10
            };

            Assert.Equal(-10, epAxis.Index);
        }

        /// <summary>
        ///     Tests that index with max int value should work
        /// </summary>
        [Fact]
        public void Index_WithMaxIntValue_ShouldWork()
        {
            EpAxis epAxis = new EpAxis
            {
                Index = int.MaxValue
            };

            Assert.Equal(int.MaxValue, epAxis.Index);
        }

        /// <summary>
        ///     Tests that separation should set and get correctly
        /// </summary>
        [Fact]
        public void Separation_ShouldSetAndGetCorrectly()
        {
            EpAxis epAxis = new EpAxis
            {
                Separation = 3.14f
            };

            Assert.Equal(3.14f, epAxis.Separation);
        }

        /// <summary>
        ///     Tests that separation with negative value should work
        /// </summary>
        [Fact]
        public void Separation_WithNegativeValue_ShouldWork()
        {
            EpAxis epAxis = new EpAxis
            {
                Separation = -2.5f
            };

            Assert.Equal(-2.5f, epAxis.Separation);
        }

        /// <summary>
        ///     Tests that separation with zero should work
        /// </summary>
        [Fact]
        public void Separation_WithZero_ShouldWork()
        {
            EpAxis epAxis = new EpAxis
            {
                Separation = 0.0f
            };

            Assert.Equal(0.0f, epAxis.Separation);
        }

        /// <summary>
        ///     Tests that separation with very small value should work
        /// </summary>
        [Fact]
        public void Separation_WithVerySmallValue_ShouldWork()
        {
            EpAxis epAxis = new EpAxis
            {
                Separation = SettingEnv.Epsilon
            };

            Assert.Equal(SettingEnv.Epsilon, epAxis.Separation);
        }

        /// <summary>
        ///     Tests that type should set and get correctly
        /// </summary>
        [Fact]
        public void Type_ShouldSetAndGetCorrectly()
        {
            EpAxis epAxis = new EpAxis
            {
                Type = EpAxisType.ShapeA
            };

            Assert.Equal(EpAxisType.ShapeA, epAxis.Type);
        }

        /// <summary>
        ///     Tests that type with ShapeB should work
        /// </summary>
        [Fact]
        public void Type_WithShapeB_ShouldWork()
        {
            EpAxis epAxis = new EpAxis
            {
                Type = EpAxisType.ShapeB
            };

            Assert.Equal(EpAxisType.ShapeB, epAxis.Type);
        }

        /// <summary>
        ///     Tests that all properties should set correctly
        /// </summary>
        [Fact]
        public void AllProperties_ShouldSetCorrectly()
        {
            EpAxis epAxis = new EpAxis
            {
                Index = 7,
                Separation = -1.5f,
                Type = EpAxisType.ShapeA
            };

            Assert.Equal(7, epAxis.Index);
            Assert.Equal(-1.5f, epAxis.Separation);
            Assert.Equal(EpAxisType.ShapeA, epAxis.Type);
        }

        /// <summary>
        ///     Tests that ep axis with most negative separation should be selected
        /// </summary>
        [Fact]
        public void EpAxis_WithMostNegativeSeparation_ShouldBeSelected()
        {
            EpAxis epAxis = new EpAxis
            {
                Index = 3,
                Separation = -10.0f,
                Type = EpAxisType.ShapeA
            };

            Assert.Equal(3, epAxis.Index);
            Assert.Equal(-10.0f, epAxis.Separation);
            Assert.Equal(EpAxisType.ShapeA, epAxis.Type);
        }

        /// <summary>
        ///     Tests that default ep axis should have zero index
        /// </summary>
        [Fact]
        public void DefaultEpAxis_ShouldHaveZeroIndex()
        {
            EpAxis epAxis = new EpAxis();

            Assert.Equal(0, epAxis.Index);
        }

        /// <summary>
        ///     Tests that default ep axis should have zero separation
        /// </summary>
        [Fact]
        public void DefaultEpAxis_ShouldHaveZeroSeparation()
        {
            EpAxis epAxis = new EpAxis();

            Assert.Equal(0.0f, epAxis.Separation);
        }

        /// <summary>
        ///     Tests that default ep axis should have None type
        /// </summary>
        [Fact]
        public void DefaultEpAxis_ShouldHaveNoneType()
        {
            EpAxis epAxis = new EpAxis();

            Assert.Equal(EpAxisType.None, epAxis.Type);
        }

        /// <summary>
        ///     Tests that ep axis should be structurally equal with same values
        /// </summary>
        [Fact]
        public void EpAxis_ShouldBeStructurallyEqualWithSameValues()
        {
            EpAxis axis1 = new EpAxis
            {
                Index = 5,
                Separation = -2.0f,
                Type = EpAxisType.ShapeA
            };

            EpAxis axis2 = new EpAxis
            {
                Index = 5,
                Separation = -2.0f,
                Type = EpAxisType.ShapeA
            };

            Assert.Equal(axis1, axis2);
        }

        /// <summary>
        ///     Tests that ep axis should be different with different index
        /// </summary>
        [Fact]
        public void EpAxis_ShouldBeDifferentWithDifferentIndex()
        {
            EpAxis axis1 = new EpAxis
            {
                Index = 3,
                Separation = -1.0f,
                Type = EpAxisType.ShapeA
            };

            EpAxis axis2 = new EpAxis
            {
                Index = 7,
                Separation = -1.0f,
                Type = EpAxisType.ShapeA
            };

            Assert.NotEqual(axis1, axis2);
        }

        /// <summary>
        ///     Tests that ep axis should be different with different separation
        /// </summary>
        [Fact]
        public void EpAxis_ShouldBeDifferentWithDifferentSeparation()
        {
            EpAxis axis1 = new EpAxis
            {
                Index = 2,
                Separation = -3.0f,
                Type = EpAxisType.ShapeA
            };

            EpAxis axis2 = new EpAxis
            {
                Index = 2,
                Separation = -5.0f,
                Type = EpAxisType.ShapeA
            };

            Assert.NotEqual(axis1, axis2);
        }

        /// <summary>
        ///     Tests that ep axis should be different with different type
        /// </summary>
        [Fact]
        public void EpAxis_ShouldBeDifferentWithDifferentType()
        {
            EpAxis axis1 = new EpAxis
            {
                Index = 4,
                Separation = -2.0f,
                Type = EpAxisType.ShapeA
            };

            EpAxis axis2 = new EpAxis
            {
                Index = 4,
                Separation = -2.0f,
                Type = EpAxisType.ShapeB
            };

            Assert.NotEqual(axis1, axis2);
        }
    }
}
