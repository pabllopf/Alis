// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DisableTest.cs
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

using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     The disable test class
    /// </summary>
    /// <remarks>
    ///     Tests the <see cref="Disable"/> tag which is used to disable entities in the ECS system.
    ///     Entities with this tag should not be updated during normal scene updates.
    /// </remarks>
    public class DisableTest
    {
        /// <summary>
        ///     Tests that disable is record struct
        /// </summary>
        /// <remarks>
        ///     Verifies that the Disable type is properly defined as a record struct,
        ///     which ensures value-type semantics and proper equality comparison.
        /// </remarks>
        [Fact]
        public void Disable_IsRecordStruct()
        {
            // Arrange & Act
            Disable disable1 = new Disable();
            Disable disable2 = new Disable();

            // Assert
            Assert.Equal(disable1, disable2);
        }

        /// <summary>
        ///     Tests that disable instances are equal
        /// </summary>
        /// <remarks>
        ///     Confirms that all Disable instances are equal since it's a tag with no data.
        /// </remarks>
        [Fact]
        public void Disable_AllInstancesAreEqual()
        {
            // Arrange
            Disable disable1 = default;
            Disable disable2 = new Disable();

            // Assert
            Assert.Equal(disable1, disable2);
            Assert.True(disable1.Equals(disable2));
        }

        /// <summary>
        ///     Tests that disable has same hashcode
        /// </summary>
        /// <remarks>
        ///     Validates that all Disable instances return the same hash code,
        ///     which is important for collection operations.
        /// </remarks>
        [Fact]
        public void Disable_HasSameHashCode()
        {
            // Arrange
            Disable disable1 = new Disable();
            Disable disable2 = new Disable();

            // Assert
            Assert.Equal(disable1.GetHashCode(), disable2.GetHashCode());
        }

        /// <summary>
        ///     Tests that disable to string returns expected format
        /// </summary>
        /// <remarks>
        ///     Ensures the ToString method returns a consistent representation.
        /// </remarks>
        [Fact]
        public void Disable_ToStringReturnsExpectedFormat()
        {
            // Arrange
            Disable disable = new Disable();

            // Act
            string result = disable.ToString();

            // Assert
            Assert.NotNull(result);
            Assert.Contains("Disable", result);
        }
    }
}

