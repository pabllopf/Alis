// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FrugalStackBasicTest.cs
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

using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Collections
{
    /// <summary>
    ///     The frugal stack basic test class
    /// </summary>
    /// <remarks>
    ///     Tests basic functionality of <see cref="FrugalStack{T}"/> which is a
    ///     memory-efficient stack implementation optimized for small collections.
    ///     The frugal stack uses lazy initialization and grows dynamically as needed.
    /// </remarks>
    public class FrugalStackBasicTest
    {
        /// <summary>
        ///     Tests that frugal stack can be created
        /// </summary>
        /// <remarks>
        ///     Verifies that a FrugalStack can be instantiated with the default constructor.
        /// </remarks>
        [Fact]
        public void FrugalStack_CanBeCreated()
        {
            // Act
            FrugalStack<int> stack = new FrugalStack<int>();

            // Assert
            Assert.NotNull(stack);
            Assert.False(stack.Any);
        }

        /// <summary>
        ///     Tests that values can be pushed to frugal stack
        /// </summary>
        /// <remarks>
        ///     Validates that items can be added to the stack and the Any property reflects this.
        /// </remarks>
        [Fact]
        public void FrugalStack_CanPushValues()
        {
            // Arrange
            FrugalStack<int> stack = new FrugalStack<int>();

            // Act
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            // Assert
            Assert.True(stack.Any);
        }

        /// <summary>
        ///     Tests that frugal stack initially has no elements
        /// </summary>
        /// <remarks>
        ///     Verifies that a newly created FrugalStack reports having no elements.
        /// </remarks>
        [Fact]
        public void FrugalStack_InitiallyEmpty()
        {
            // Act
            FrugalStack<int> stack = new FrugalStack<int>();

            // Assert
            Assert.False(stack.Any);
        }

        /// <summary>
        ///     Tests that frugal stack can store reference types
        /// </summary>
        /// <remarks>
        ///     Validates that FrugalStack works correctly with reference type values.
        /// </remarks>
        [Fact]
        public void FrugalStack_CanStoreReferenceTypes()
        {
            // Arrange
            FrugalStack<string> stack = new FrugalStack<string>();

            // Act
            stack.Push("First");
            stack.Push("Second");
            stack.Push("Third");

            // Assert
            Assert.True(stack.Any);
        }

        /// <summary>
        ///     Tests that frugal stack can store value types
        /// </summary>
        /// <remarks>
        ///     Verifies that FrugalStack handles value types correctly.
        /// </remarks>
        [Fact]
        public void FrugalStack_CanStoreValueTypes()
        {
            // Arrange
            FrugalStack<Position> stack = new FrugalStack<Position>();
            Position pos1 = new Position { X = 1, Y = 2 };
            Position pos2 = new Position { X = 3, Y = 4 };

            // Act
            stack.Push(pos1);
            stack.Push(pos2);

            // Assert
            Assert.True(stack.Any);
        }

        /// <summary>
        ///     Tests that frugal stack can handle many pushes
        /// </summary>
        /// <remarks>
        ///     Validates that FrugalStack can grow dynamically to accommodate
        ///     many items beyond initial capacity.
        /// </remarks>
        [Fact]
        public void FrugalStack_CanHandleManyPushes()
        {
            // Arrange
            FrugalStack<int> stack = new FrugalStack<int>();

            // Act
            for (int i = 0; i < 100; i++)
            {
                stack.Push(i);
            }

            // Assert
            Assert.True(stack.Any);
        }
    }
}

