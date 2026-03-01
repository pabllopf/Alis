// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MemoryTrimmingTest.cs
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

using Alis.Core.Ecs.Redifinition;
using Xunit;

namespace Alis.Core.Ecs.Test.Redifinition
{
    /// <summary>
    ///     The memory trimming test class
    /// </summary>
    /// <remarks>
    ///     Tests the MemoryTrimming enumeration that specifies different levels
    ///     of memory trimming for Alis internal buffers. This is critical for
    ///     memory management strategies in the ECS.
    /// </remarks>
    public class MemoryTrimmingTest
    {
        /// <summary>
        ///     Tests that MemoryTrimming enum has expected values
        /// </summary>
        /// <remarks>
        ///     Validates that all enum values are defined with correct numeric values.
        /// </remarks>
        [Fact]
        public void MemoryTrimming_HasExpectedValues()
        {
            // Assert
            Assert.Equal(0, (int)MemoryTrimming.Always);
            Assert.Equal(1, (int)MemoryTrimming.Normal);
            Assert.Equal(2, (int)MemoryTrimming.Never);
        }

        /// <summary>
        ///     Tests that MemoryTrimming enum can be assigned
        /// </summary>
        /// <remarks>
        ///     Validates that MemoryTrimming values can be assigned to variables
        ///     and compared correctly.
        /// </remarks>
        [Fact]
        public void MemoryTrimming_CanBeAssigned()
        {
            // Act
            MemoryTrimming always = MemoryTrimming.Always;
            MemoryTrimming normal = MemoryTrimming.Normal;
            MemoryTrimming never = MemoryTrimming.Never;

            // Assert
            Assert.Equal(MemoryTrimming.Always, always);
            Assert.Equal(MemoryTrimming.Normal, normal);
            Assert.Equal(MemoryTrimming.Never, never);
        }

        /// <summary>
        ///     Tests that MemoryTrimming values are distinct
        /// </summary>
        /// <remarks>
        ///     Validates that all enum values are different from each other.
        /// </remarks>
        [Fact]
        public void MemoryTrimming_AllValuesAreDistinct()
        {
            // Assert
            Assert.NotEqual(MemoryTrimming.Always, MemoryTrimming.Normal);
            Assert.NotEqual(MemoryTrimming.Always, MemoryTrimming.Never);
            Assert.NotEqual(MemoryTrimming.Normal, MemoryTrimming.Never);
        }

        /// <summary>
        ///     Tests that MemoryTrimming can be converted to string
        /// </summary>
        /// <remarks>
        ///     Validates that enum values can be converted to their string representation.
        /// </remarks>
        [Fact]
        public void MemoryTrimming_CanBeConvertedToString()
        {
            // Act
            string alwaysString = MemoryTrimming.Always.ToString();
            string normalString = MemoryTrimming.Normal.ToString();
            string neverString = MemoryTrimming.Never.ToString();

            // Assert
            Assert.Equal("Always", alwaysString);
            Assert.Equal("Normal", normalString);
            Assert.Equal("Never", neverString);
        }

        /// <summary>
        ///     Tests that MemoryTrimming can be cast from int
        /// </summary>
        /// <remarks>
        ///     Validates that integer values can be cast to MemoryTrimming enum.
        /// </remarks>
        [Fact]
        public void MemoryTrimming_CanBeCastFromInt()
        {
            // Act
            MemoryTrimming always = (MemoryTrimming)0;
            MemoryTrimming normal = (MemoryTrimming)1;
            MemoryTrimming never = (MemoryTrimming)2;

            // Assert
            Assert.Equal(MemoryTrimming.Always, always);
            Assert.Equal(MemoryTrimming.Normal, normal);
            Assert.Equal(MemoryTrimming.Never, never);
        }

        /// <summary>
        ///     Tests that MemoryTrimming can be used in switch statements
        /// </summary>
        /// <remarks>
        ///     Validates that enum values work correctly in switch/case statements.
        /// </remarks>
        [Fact]
        public void MemoryTrimming_WorksInSwitchStatements()
        {
            // Arrange
            int alwaysResult = 0;
            int normalResult = 0;
            int neverResult = 0;

            // Act
            switch (MemoryTrimming.Always)
            {
                case MemoryTrimming.Always:
                    alwaysResult = 1;
                    break;
            }

            switch (MemoryTrimming.Normal)
            {
                case MemoryTrimming.Normal:
                    normalResult = 1;
                    break;
            }

            switch (MemoryTrimming.Never)
            {
                case MemoryTrimming.Never:
                    neverResult = 1;
                    break;
            }

            // Assert
            Assert.Equal(1, alwaysResult);
            Assert.Equal(1, normalResult);
            Assert.Equal(1, neverResult);
        }

        /// <summary>
        ///     Tests that MemoryTrimming comparison works correctly
        /// </summary>
        /// <remarks>
        ///     Validates that enum values can be compared using comparison operators.
        /// </remarks>
        [Fact]
        public void MemoryTrimming_ComparisonWorksCorrectly()
        {
            // Assert
            Assert.True(MemoryTrimming.Always < MemoryTrimming.Normal);
            Assert.True(MemoryTrimming.Normal < MemoryTrimming.Never);
            Assert.True(MemoryTrimming.Always < MemoryTrimming.Never);
            Assert.True(MemoryTrimming.Never > MemoryTrimming.Always);
        }

        /// <summary>
        ///     Tests that MemoryTrimming default value is Always
        /// </summary>
        /// <remarks>
        ///     Validates that the default enum value (0) corresponds to Always.
        /// </remarks>
        [Fact]
        public void MemoryTrimming_DefaultValueIsAlways()
        {
            // Act
            MemoryTrimming defaultValue = default;

            // Assert
            Assert.Equal(MemoryTrimming.Always, defaultValue);
            Assert.Equal(0, (int)defaultValue);
        }

        /// <summary>
        ///     Tests that MemoryTrimming can be used in collections
        /// </summary>
        /// <remarks>
        ///     Validates that MemoryTrimming values can be stored and retrieved from collections.
        /// </remarks>
        [Fact]
        public void MemoryTrimming_CanBeUsedInCollections()
        {
            // Arrange
            var list = new System.Collections.Generic.List<MemoryTrimming>
            {
                MemoryTrimming.Always,
                MemoryTrimming.Normal,
                MemoryTrimming.Never
            };

            // Assert
            Assert.Equal(3, list.Count);
            Assert.Contains(MemoryTrimming.Always, list);
            Assert.Contains(MemoryTrimming.Normal, list);
            Assert.Contains(MemoryTrimming.Never, list);
        }

        /// <summary>
        ///     Tests that MemoryTrimming can be used in dictionary keys
        /// </summary>
        /// <remarks>
        ///     Validates that MemoryTrimming values can be used as dictionary keys.
        /// </remarks>
        [Fact]
        public void MemoryTrimming_CanBeUsedAsDictionaryKey()
        {
            // Arrange
            var dict = new System.Collections.Generic.Dictionary<MemoryTrimming, string>
            {
                { MemoryTrimming.Always, "Always trim" },
                { MemoryTrimming.Normal, "Normal trim" },
                { MemoryTrimming.Never, "Never trim" }
            };

            // Assert
            Assert.Equal(3, dict.Count);
            Assert.Equal("Always trim", dict[MemoryTrimming.Always]);
            Assert.Equal("Normal trim", dict[MemoryTrimming.Normal]);
            Assert.Equal("Never trim", dict[MemoryTrimming.Never]);
        }

        /// <summary>
        ///     Tests that MemoryTrimming has exactly three values
        /// </summary>
        /// <remarks>
        ///     Validates that the enum defines exactly the expected number of values.
        /// </remarks>
        [Fact]
        public void MemoryTrimming_HasExactlyThreeValues()
        {
            // Act
            var values = System.Enum.GetValues(typeof(MemoryTrimming));

            // Assert
            Assert.Equal(3, values.Length);
        }

        /// <summary>
        ///     Tests that MemoryTrimming enum is public
        /// </summary>
        /// <remarks>
        ///     Validates that the MemoryTrimming enum has public visibility.
        /// </remarks>
        [Fact]
        public void MemoryTrimming_IsPublic()
        {
            // Act
            System.Type type = typeof(MemoryTrimming);

            // Assert
            Assert.True(type.IsPublic);
            Assert.True(type.IsEnum);
        }

        /// <summary>
        ///     Tests MemoryTrimming equality comparison
        /// </summary>
        /// <remarks>
        ///     Validates that enum equality operators work correctly.
        /// </remarks>
        [Fact]
        public void MemoryTrimming_EqualityComparisonWorks()
        {
            // Arrange
            MemoryTrimming value1 = MemoryTrimming.Normal;
            MemoryTrimming value2 = MemoryTrimming.Normal;
            MemoryTrimming value3 = MemoryTrimming.Always;

            // Assert
            Assert.True(value1 == value2);
            Assert.False(value1 == value3);
            Assert.True(value1 != value3);
            Assert.False(value1 != value2);
        }
    }
}

