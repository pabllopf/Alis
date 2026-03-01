// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RuleTypesTest.cs
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

using Alis.Core.Ecs.Systems;
using Xunit;

namespace Alis.Core.Ecs.Test.Systems
{
    /// <summary>
    ///     The rule types test class
    /// </summary>
    /// <remarks>
    ///     Tests the RuleTypes enumeration that defines the types of rules that can be applied
    ///     in ECS queries. Rules determine whether entities must have or not have specific components.
    /// </remarks>
    public class RuleTypesTest
    {
        /// <summary>
        ///     Tests that RuleTypes enum has expected values
        /// </summary>
        /// <remarks>
        ///     Validates that all enum values are defined with correct numeric values.
        /// </remarks>
        [Fact]
        public void RuleTypes_HasExpectedValues()
        {
            // Assert
            Assert.Equal(0, (int)RuleTypes.Have);
            Assert.Equal(1, (int)RuleTypes.DoesNotHave);
        }

        /// <summary>
        ///     Tests that RuleTypes values are distinct
        /// </summary>
        /// <remarks>
        ///     Validates that all enum values are different from each other.
        /// </remarks>
        [Fact]
        public void RuleTypes_AllValuesAreDistinct()
        {
            // Assert
            Assert.NotEqual(RuleTypes.Have, RuleTypes.DoesNotHave);
        }

        /// <summary>
        ///     Tests that RuleTypes can be assigned
        /// </summary>
        /// <remarks>
        ///     Validates that RuleTypes values can be assigned to variables
        ///     and compared correctly.
        /// </remarks>
        [Fact]
        public void RuleTypes_CanBeAssigned()
        {
            // Act
            RuleTypes have = RuleTypes.Have;
            RuleTypes doesNotHave = RuleTypes.DoesNotHave;

            // Assert
            Assert.Equal(RuleTypes.Have, have);
            Assert.Equal(RuleTypes.DoesNotHave, doesNotHave);
        }

        /// <summary>
        ///     Tests that RuleTypes can be converted to string
        /// </summary>
        /// <remarks>
        ///     Validates that enum values can be converted to their string representation.
        /// </remarks>
        [Fact]
        public void RuleTypes_CanBeConvertedToString()
        {
            // Act
            string haveString = RuleTypes.Have.ToString();
            string doesNotHaveString = RuleTypes.DoesNotHave.ToString();

            // Assert
            Assert.Equal("Have", haveString);
            Assert.Equal("DoesNotHave", doesNotHaveString);
        }

        /// <summary>
        ///     Tests that RuleTypes can be cast from int
        /// </summary>
        /// <remarks>
        ///     Validates that integer values can be cast to RuleTypes enum.
        /// </remarks>
        [Fact]
        public void RuleTypes_CanBeCastFromInt()
        {
            // Act
            RuleTypes have = (RuleTypes)0;
            RuleTypes doesNotHave = (RuleTypes)1;

            // Assert
            Assert.Equal(RuleTypes.Have, have);
            Assert.Equal(RuleTypes.DoesNotHave, doesNotHave);
        }

        /// <summary>
        ///     Tests that RuleTypes works in switch statements
        /// </summary>
        /// <remarks>
        ///     Validates that enum values work correctly in switch/case statements.
        /// </remarks>
        [Fact]
        public void RuleTypes_WorksInSwitchStatements()
        {
            // Arrange
            int haveResult = 0;
            int doesNotHaveResult = 0;

            // Act
            switch (RuleTypes.Have)
            {
                case RuleTypes.Have:
                    haveResult = 1;
                    break;
                case RuleTypes.DoesNotHave:
                    haveResult = 2;
                    break;
            }

            switch (RuleTypes.DoesNotHave)
            {
                case RuleTypes.Have:
                    doesNotHaveResult = 1;
                    break;
                case RuleTypes.DoesNotHave:
                    doesNotHaveResult = 2;
                    break;
            }

            // Assert
            Assert.Equal(1, haveResult);
            Assert.Equal(2, doesNotHaveResult);
        }

        /// <summary>
        ///     Tests that RuleTypes default value is Have
        /// </summary>
        /// <remarks>
        ///     Validates that the default enum value (0) corresponds to Have.
        /// </remarks>
        [Fact]
        public void RuleTypes_DefaultValueIsHave()
        {
            // Act
            RuleTypes defaultValue = default;

            // Assert
            Assert.Equal(RuleTypes.Have, defaultValue);
            Assert.Equal(0, (int)defaultValue);
        }

        /// <summary>
        ///     Tests that RuleTypes can be used in collections
        /// </summary>
        /// <remarks>
        ///     Validates that RuleTypes values can be stored and retrieved from collections.
        /// </remarks>
        [Fact]
        public void RuleTypes_CanBeUsedInCollections()
        {
            // Arrange
            var list = new System.Collections.Generic.List<RuleTypes>
            {
                RuleTypes.Have,
                RuleTypes.DoesNotHave
            };

            // Assert
            Assert.Equal(2, list.Count);
            Assert.Contains(RuleTypes.Have, list);
            Assert.Contains(RuleTypes.DoesNotHave, list);
        }

        /// <summary>
        ///     Tests that RuleTypes can be used as dictionary keys
        /// </summary>
        /// <remarks>
        ///     Validates that RuleTypes values can be used as dictionary keys.
        /// </remarks>
        [Fact]
        public void RuleTypes_CanBeUsedAsDictionaryKey()
        {
            // Arrange
            var dict = new System.Collections.Generic.Dictionary<RuleTypes, string>
            {
                { RuleTypes.Have, "Must have component" },
                { RuleTypes.DoesNotHave, "Must not have component" }
            };

            // Assert
            Assert.Equal(2, dict.Count);
            Assert.Equal("Must have component", dict[RuleTypes.Have]);
            Assert.Equal("Must not have component", dict[RuleTypes.DoesNotHave]);
        }

        /// <summary>
        ///     Tests that RuleTypes has exactly two values
        /// </summary>
        /// <remarks>
        ///     Validates that the enum defines exactly the expected number of values.
        /// </remarks>
        [Fact]
        public void RuleTypes_HasExactlyTwoValues()
        {
            // Act
            var values = System.Enum.GetValues(typeof(RuleTypes));

            // Assert
            Assert.Equal(2, values.Length);
        }

        /// <summary>
        ///     Tests that RuleTypes enum is public
        /// </summary>
        /// <remarks>
        ///     Validates that the RuleTypes enum has public visibility.
        /// </remarks>
        [Fact]
        public void RuleTypes_IsPublic()
        {
            // Act
            System.Type type = typeof(RuleTypes);

            // Assert
            Assert.True(type.IsPublic);
            Assert.True(type.IsEnum);
        }

        /// <summary>
        ///     Tests that RuleTypes equality comparison works
        /// </summary>
        /// <remarks>
        ///     Validates that enum equality operators work correctly.
        /// </remarks>
        [Fact]
        public void RuleTypes_EqualityComparisonWorks()
        {
            // Arrange
            RuleTypes value1 = RuleTypes.Have;
            RuleTypes value2 = RuleTypes.Have;
            RuleTypes value3 = RuleTypes.DoesNotHave;

            // Assert
            Assert.True(value1 == value2);
            Assert.False(value1 == value3);
            Assert.True(value1 != value3);
            Assert.False(value1 != value2);
        }

        /// <summary>
        ///     Tests RuleTypes comparison operators
        /// </summary>
        /// <remarks>
        ///     Validates that enum values can be compared using comparison operators.
        /// </remarks>
        [Fact]
        public void RuleTypes_ComparisonOperatorsWork()
        {
            // Assert
            Assert.True(RuleTypes.Have < RuleTypes.DoesNotHave);
            Assert.False(RuleTypes.DoesNotHave < RuleTypes.Have);
            Assert.True(RuleTypes.DoesNotHave > RuleTypes.Have);
        }

        /// <summary>
        ///     Tests that RuleTypes can be used in conditional logic
        /// </summary>
        /// <remarks>
        ///     Validates that RuleTypes values work correctly in if-else conditions.
        /// </remarks>
        [Fact]
        public void RuleTypes_WorksInConditionalLogic()
        {
            // Arrange
            RuleTypes ruleType = RuleTypes.Have;
            bool isHave = false;
            bool isDoesNotHave = false;

            // Act
            if (ruleType == RuleTypes.Have)
            {
                isHave = true;
            }
            else if (ruleType == RuleTypes.DoesNotHave)
            {
                isDoesNotHave = true;
            }

            // Assert
            Assert.True(isHave);
            Assert.False(isDoesNotHave);
        }

        /// <summary>
        ///     Tests that RuleTypes GetHashCode is consistent
        /// </summary>
        /// <remarks>
        ///     Validates that enum hash codes are consistent across calls.
        /// </remarks>
        [Fact]
        public void RuleTypes_GetHashCodeIsConsistent()
        {
            // Arrange
            RuleTypes value = RuleTypes.Have;

            // Act
            int hash1 = value.GetHashCode();
            int hash2 = value.GetHashCode();

            // Assert
            Assert.Equal(hash1, hash2);
        }

        /// <summary>
        ///     Tests that different RuleTypes values have different hash codes
        /// </summary>
        /// <remarks>
        ///     Validates that different enum values produce different hash codes.
        /// </remarks>
        [Fact]
        public void RuleTypes_DifferentValues_HaveDifferentHashCodes()
        {
            // Act
            int haveHash = RuleTypes.Have.GetHashCode();
            int doesNotHaveHash = RuleTypes.DoesNotHave.GetHashCode();

            // Assert
            Assert.NotEqual(haveHash, doesNotHaveHash);
        }

        /// <summary>
        ///     Tests that RuleTypes Equals method works correctly
        /// </summary>
        /// <remarks>
        ///     Validates that the Equals method properly compares enum values.
        /// </remarks>
        [Fact]
        public void RuleTypes_EqualsMethodWorksCorrectly()
        {
            // Arrange
            RuleTypes value1 = RuleTypes.Have;
            RuleTypes value2 = RuleTypes.Have;
            RuleTypes value3 = RuleTypes.DoesNotHave;

            // Act & Assert
            Assert.True(value1.Equals(value2));
            Assert.False(value1.Equals(value3));
        }

        /// <summary>
        ///     Tests that RuleTypes can be parsed from string
        /// </summary>
        /// <remarks>
        ///     Validates that string representations can be parsed back to enum values.
        /// </remarks>
        [Fact]
        public void RuleTypes_CanBeParsedFromString()
        {
            // Act
            RuleTypes have = (RuleTypes)System.Enum.Parse(typeof(RuleTypes), "Have");
            RuleTypes doesNotHave = (RuleTypes)System.Enum.Parse(typeof(RuleTypes), "DoesNotHave");

            // Assert
            Assert.Equal(RuleTypes.Have, have);
            Assert.Equal(RuleTypes.DoesNotHave, doesNotHave);
        }
    }
}

