// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TagOperationsTest.cs
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
    ///     The tag operations test class
    /// </summary>
    /// <remarks>
    ///     Tests for tag operations including attachment, removal, and checking.
    ///     Tags are lightweight markers for categorizing entities.
    /// </remarks>
    public class TagOperationsTest
    {
        /// <summary>
        ///     Tests that tags can be attached to entities
        /// </summary>
        /// <remarks>
        ///     Validates that a tag can be successfully attached to an entity.
        /// </remarks>
        [Fact]
        public void Tag_CanBeAttached()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 0, Y = 0 });

            // Act
            entity.Tag<PlayerTag>();

            // Assert
            Assert.True(entity.Tagged<PlayerTag>());
        }


        /// <summary>
        ///     Tests that multiple tags can be attached
        /// </summary>
        /// <remarks>
        ///     Validates that an entity can have multiple tags simultaneously.
        /// </remarks>
        [Fact]
        public void Tag_MultipleTagsCanBeAttached()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 0, Y = 0 });

            // Act
            entity.Tag<PlayerTag>();
            entity.Tag<EnemyTag>();

            // Assert
            Assert.True(entity.Tagged<PlayerTag>());
            Assert.True(entity.Tagged<EnemyTag>());
        }
        


    }
}

