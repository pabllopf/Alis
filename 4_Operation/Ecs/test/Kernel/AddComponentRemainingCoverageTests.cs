// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AddComponentRemainingCoverageTests.cs
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

using Alis.Core.Ecs.Kernel;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel
{
    /// <summary>
    ///     The add component remaining coverage tests class
    /// </summary>
    public class AddComponentRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that constructor with defaults creates instance
        /// </summary>
        [Fact]
        public void Constructor_WithDefaults_CreatesInstance()
        {
            AddComponent cmd = new AddComponent(new GameObjectIdOnly(1, 1), default);

            Assert.Equal(1, cmd.Entity.ID);
        }

        /// <summary>
        ///     Tests that constructor with specific entity sets entity
        /// </summary>
        [Fact]
        public void Constructor_WithSpecificEntity_SetsEntity()
        {
            AddComponent cmd = new AddComponent(new GameObjectIdOnly(42, 3), default);

            Assert.Equal(42, cmd.Entity.ID);
            Assert.Equal((ushort)3, cmd.Entity.Version);
        }

        /// <summary>
        ///     Tests that record struct equals returns true for same values
        /// </summary>
        [Fact]
        public void RecordStruct_Equals_SameValues_ReturnsTrue()
        {
            AddComponent a = new AddComponent(new GameObjectIdOnly(5, 2), default);
            AddComponent b = new AddComponent(new GameObjectIdOnly(5, 2), default);

            Assert.True(a == b);
        }

        /// <summary>
        ///     Tests that record struct equals returns false for different values
        /// </summary>
        [Fact]
        public void RecordStruct_Equals_DifferentValues_ReturnsFalse()
        {
            AddComponent a = new AddComponent(new GameObjectIdOnly(1, 1), default);
            AddComponent b = new AddComponent(new GameObjectIdOnly(2, 1), default);

            Assert.True(a != b);
        }
    }
}