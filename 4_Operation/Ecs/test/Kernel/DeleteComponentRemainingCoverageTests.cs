// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DeleteComponentRemainingCoverageTests.cs
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
    ///     Remaining coverage tests for the <see cref="DeleteComponent" /> record struct.
    /// </summary>
    public class DeleteComponentRemainingCoverageTests
    {
        /// <summary>
        ///     Verifies that the positional constructor sets the entity and component identifier values.
        /// </summary>
        [Fact]
        public void Constructor_WithValues_SetsProperties()
        {
            DeleteComponent command = new DeleteComponent(new GameObjectIdOnly(5, 3), new ComponentId((ushort)7));

            Assert.Equal(5, command.Entity.ID);
            Assert.Equal((ushort)7, command.ComponentId.RawIndex);
        }

        /// <summary>
        ///     Verifies that two instances with the same values are considered equal via the equality operator.
        /// </summary>
        [Fact]
        public void Equals_SameValues_ReturnsTrue()
        {
            DeleteComponent a = new DeleteComponent(new GameObjectIdOnly(5, 3), new ComponentId((ushort)7));
            DeleteComponent b = new DeleteComponent(new GameObjectIdOnly(5, 3), new ComponentId((ushort)7));

            Assert.True(a == b);
        }

        /// <summary>
        ///     Verifies that two instances with different values are not equal via the inequality operator.
        /// </summary>
        [Fact]
        public void Equals_DifferentValues_ReturnsFalse()
        {
            DeleteComponent a = new DeleteComponent(new GameObjectIdOnly(5, 3), new ComponentId((ushort)7));
            DeleteComponent b = new DeleteComponent(new GameObjectIdOnly(5, 3), new ComponentId((ushort)9));

            Assert.True(a != b);
        }

        /// <summary>
        ///     Verifies that the default constructor sets all fields to their default values.
        /// </summary>
        [Fact]
        public void DefaultConstructor_ValuesAreDefault()
        {
            DeleteComponent command = new DeleteComponent();

            Assert.Equal(0, command.Entity.ID);
            Assert.Equal((ushort)0, command.ComponentId.RawIndex);
        }
    }
}