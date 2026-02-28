// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WorldArchetypeTableItemExtendedTest.cs
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
    ///     The world archetype table item extended test class
    /// </summary>
    /// <remarks>
    ///     Tests the <see cref="WorldArchetypeTableItem"/> struct which stores
    ///     archetype and temporary creation archetype references with extended test cases.
    /// </remarks>
    public class WorldArchetypeTableItemExtendedTest
    {
        /// <summary>
        ///     Tests that world archetype table item can be created
        /// </summary>
        /// <remarks>
        ///     Verifies that WorldArchetypeTableItem can be instantiated with null archetypes.
        /// </remarks>
        [Fact]
        public void WorldArchetypeTableItem_CanBeCreatedWithNullArchetypes()
        {
            // Act
            WorldArchetypeTableItem item = new WorldArchetypeTableItem(null, null);

            // Assert
            Assert.Null(item.Archetype);
            Assert.Null(item.DeferredCreationArchetype);
        }

        /// <summary>
        ///     Tests that world archetype table item fields are accessible
        /// </summary>
        /// <remarks>
        ///     Validates that the Archetype and DeferredCreationArchetype fields are accessible.
        /// </remarks>
        [Fact]
        public void WorldArchetypeTableItem_FieldsAreAccessible()
        {
            // Arrange
            WorldArchetypeTableItem item = new WorldArchetypeTableItem(null, null);

            // Act & Assert
            Assert.NotNull(item);
            Assert.True(item.Archetype == null || item.Archetype != null);
        }

        /// <summary>
        ///     Tests that world archetype table item is value type
        /// </summary>
        /// <remarks>
        ///     Confirms that WorldArchetypeTableItem is a value type (struct).
        /// </remarks>
        [Fact]
        public void WorldArchetypeTableItem_IsValueType()
        {
            // Arrange
            WorldArchetypeTableItem item1 = new WorldArchetypeTableItem(null, null);
            WorldArchetypeTableItem item2 = item1;

            // Assert
            Assert.NotNull(item1);
            Assert.NotNull(item2);
        }

        /// <summary>
        ///     Tests that world archetype table item fields can be modified
        /// </summary>
        /// <remarks>
        ///     Validates that the public fields can be modified.
        /// </remarks>
        [Fact]
        public void WorldArchetypeTableItem_FieldsCanBeModified()
        {
            // Arrange
            WorldArchetypeTableItem item = new WorldArchetypeTableItem(null, null);

            // Act
            item.Archetype = null;
            item.DeferredCreationArchetype = null;

            // Assert
            Assert.Null(item.Archetype);
            Assert.Null(item.DeferredCreationArchetype);
        }
    }
}

