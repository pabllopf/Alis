// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectAdvancedTest.cs
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

using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     The game object advanced test class
    /// </summary>
    /// <remarks>
    ///     Tests advanced GameObject functionality including lifecycle,
    ///     versioning, validity checking, and complex scenarios.
    /// </remarks>
    public class GameObjectAdvancedTest
    {
        
        /// <summary>
        ///     Tests game object equality comparison
        /// </summary>
        /// <remarks>
        ///     Validates that the same GameObject instance equals itself.
        /// </remarks>
        [Fact]
        public void GameObject_EqualityComparison()
        {
            // Arrange
            Scene scene = new Scene();
            GameObject e1 = scene.Create();
            GameObject e2 = e1;

            // Act & Assert
            Assert.True(e1.Equals(e2));
            Assert.Equal(e1, e2);

            // Cleanup
            scene.Dispose();
        }

        /// <summary>
        ///     Tests different game objects are not equal
        /// </summary>
        /// <remarks>
        ///     Verifies that different GameObject instances are not equal.
        /// </remarks>
        [Fact]
        public void GameObject_DifferentObjectsNotEqual()
        {
            // Arrange
            Scene scene = new Scene();
            GameObject e1 = scene.Create();
            GameObject e2 = scene.Create();

            // Act & Assert
            Assert.False(e1.Equals(e2));
            Assert.NotEqual(e1, e2);

            // Cleanup
            scene.Dispose();
        }

        /// <summary>
        ///     Tests game object null comparison
        /// </summary>
        /// <remarks>
        ///     Validates that GameObjects have proper null comparison behavior.
        /// </remarks>
        [Fact]
        public void GameObject_NullComparison()
        {
            // Arrange
            Scene scene = new Scene();
            GameObject entity = scene.Create();

            // Act & Assert
            Assert.False(entity.Equals(null));

            // Cleanup
            scene.Dispose();
        }
        
        /// <summary>
        ///     Tests hash code consistency for game objects
        /// </summary>
        /// <remarks>
        ///     Validates that GetHashCode returns consistent values for the same entity.
        /// </remarks>
        [Fact]
        public void GameObject_HashCodeConsistency()
        {
            // Arrange
            Scene scene = new Scene();
            GameObject entity = scene.Create();

            // Act
            int hash1 = entity.GetHashCode();
            int hash2 = entity.GetHashCode();

            // Assert
            Assert.Equal(hash1, hash2);

            // Cleanup
            scene.Dispose();
        }

        /// <summary>
        ///     Tests different game objects have different hash codes
        /// </summary>
        /// <remarks>
        ///     Validates that different GameObjects produce different hash codes.
        /// </remarks>
        [Fact]
        public void GameObject_DifferentObjectsDifferentHashCodes()
        {
            // Arrange
            Scene scene = new Scene();
            GameObject e1 = scene.Create();
            GameObject e2 = scene.Create();

            // Act
            int hash1 = e1.GetHashCode();
            int hash2 = e2.GetHashCode();

            // Assert
            Assert.NotEqual(hash1, hash2);

            // Cleanup
            scene.Dispose();
        }
    }
}

