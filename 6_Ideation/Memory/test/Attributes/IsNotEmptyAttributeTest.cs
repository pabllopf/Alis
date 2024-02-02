// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NotEmptyAttributeTest.cs
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

using System.Collections.Concurrent;
using System.Collections.Generic;
using Alis.Core.Aspect.Memory.Attributes;
using Alis.Core.Aspect.Memory.Exceptions;
using Xunit;

namespace Alis.Core.Aspect.Memory.Test.Attributes
{
    /// <summary>
    ///     The not empty attribute test class
    /// </summary>
    public class IsNotEmptyAttributeTest
    {
       [IsNotEmpty] private ConcurrentBag<int> emptyConcurrentBag1;

        /// <summary>
        /// Tests that validate with empty string should throw exception
        /// </summary>
        [Fact]
        public void Validate_WithEmptyString_ShouldThrowException()
        {
            // Arrange
            IsNotEmptyAttribute attribute = new IsNotEmptyAttribute();
            string emptyString = string.Empty;

            // Act and Assert
            Assert.Throws<NotEmptyException>(() => attribute.Validate(emptyString, nameof(emptyString)));
        }


        /// <summary>
        /// Tests that validate with empty string v 4 should throw exception
        /// </summary>
        [Fact]
        public void Validate_WithEmptyString_v4_ShouldThrowException()
        {
            // Arrange
            IsNotEmptyAttribute attribute = new IsNotEmptyAttribute();
            string emptyString = "";

            // Act and Assert
            Assert.Throws<NotEmptyException>(() => attribute.Validate(emptyString, nameof(emptyString)));
        }

        /// <summary>
        /// Tests that validate with not empty string should not throw exception
        /// </summary>
        [Fact]
        public void Validate_WithNotEmptyString_ShouldNotThrowException()
        {
            // Arrange
            IsNotEmptyAttribute attribute = new IsNotEmptyAttribute();
            string notEmptyString = "Test";

            // Act
            attribute.Validate(notEmptyString, nameof(notEmptyString));

            // Assert
            Assert.True(true);
        }

        /// <summary>
        /// Tests that validate with empty array should throw exception
        /// </summary>
        [Fact]
        public void Validate_WithEmptyArray_ShouldThrowException()
        {
            // Arrange
            IsNotEmptyAttribute attribute = new IsNotEmptyAttribute();
            object[] emptyArray = new object[0];

            // Act and Assert
            Assert.Throws<NotEmptyException>(() => attribute.Validate(emptyArray, nameof(emptyArray)));
        }

        /// <summary>
        /// Tests that validate with not empty array should not throw exception
        /// </summary>
        [Fact]
        public void Validate_WithNotEmptyArray_ShouldNotThrowException()
        {
            // Arrange
            IsNotEmptyAttribute attribute = new IsNotEmptyAttribute();
            object[] notEmptyArray = new object[] {1};

            // Act
            attribute.Validate(notEmptyArray, nameof(notEmptyArray));

            // Assert
            Assert.True(true);
        }

        /// <summary>
        /// Tests that validate with empty collection should throw exception
        /// </summary>
        [Fact]
        public void Validate_WithEmptyCollection_ShouldThrowException()
        {
            // Arrange
            IsNotEmptyAttribute attribute = new IsNotEmptyAttribute();
            List<int> emptyCollection = new System.Collections.Generic.List<int>();

            // Act and Assert
            Assert.Throws<NotEmptyException>(() => attribute.Validate(emptyCollection, nameof(emptyCollection)));
        }

        /// <summary>
        /// Tests that validate with not empty collection should not throw exception
        /// </summary>
        [Fact]
        public void Validate_WithNotEmptyCollection_ShouldNotThrowException()
        {
            // Arrange
            IsNotEmptyAttribute attribute = new IsNotEmptyAttribute();
            List<int> notEmptyCollection = new System.Collections.Generic.List<int> {1};

            // Act
            attribute.Validate(notEmptyCollection, nameof(notEmptyCollection));

            // Assert
            Assert.True(true);
        }

        /// <summary>
        /// Tests that validate with empty dictionary should throw exception
        /// </summary>
        [Fact]
        public void Validate_WithEmptyDictionary_ShouldThrowException()
        {
            // Arrange
            IsNotEmptyAttribute attribute = new IsNotEmptyAttribute();
            Dictionary<string, string> emptyDictionary = new System.Collections.Generic.Dictionary<string, string>();

            // Act and Assert
            Assert.Throws<NotEmptyException>(() => attribute.Validate(emptyDictionary, nameof(emptyDictionary)));
        }

        /// <summary>
        /// Tests that validate with not empty dictionary should not throw exception
        /// </summary>
        [Fact]
        public void Validate_WithNotEmptyDictionary_ShouldNotThrowException()
        {
            // Arrange
            IsNotEmptyAttribute attribute = new IsNotEmptyAttribute();
            Dictionary<string, string> notEmptyDictionary = new System.Collections.Generic.Dictionary<string, string> {{"key", "value"}};

            // Act
            attribute.Validate(notEmptyDictionary, nameof(notEmptyDictionary));

            // Assert
            Assert.True(true);
        }
        
        /// <summary>
        /// Tests that validate with empty hash set should throw exception
        /// </summary>
        [Fact]
        public void Validate_WithEmptyHashSet_ShouldThrowException()
        {
            // Arrange
            IsNotEmptyAttribute attribute = new IsNotEmptyAttribute();
            HashSet<int> emptyHashSet = new HashSet<int>();

            // Act and Assert
            Assert.Throws<NotEmptyException>(() => attribute.Validate(emptyHashSet, nameof(emptyHashSet)));
        }

        /// <summary>
        /// Tests that validate with not empty hash set should not throw exception
        /// </summary>
        [Fact]
        public void Validate_WithNotEmptyHashSet_ShouldNotThrowException()
        {
            // Arrange
            IsNotEmptyAttribute attribute = new IsNotEmptyAttribute();
            HashSet<int> notEmptyHashSet = new HashSet<int> { 1 };

            // Act
            attribute.Validate(notEmptyHashSet, nameof(notEmptyHashSet));

            // Assert
            Assert.True(true);
        }
        
        /// <summary>
        /// Tests that validate with empty hash set v 2 should throw exception
        /// </summary>
        [Fact]
        public void Validate_WithEmptyHashSet_v2_ShouldThrowException()
        {
            // Arrange
            IsNotEmptyAttribute attribute = new IsNotEmptyAttribute();
            HashSet<int> emptyHashSet = new HashSet<int>();

            // Act and Assert
            Assert.Throws<NotEmptyException>(() => attribute.Validate(emptyHashSet, nameof(emptyHashSet)));
        }

        /// <summary>
        /// Tests that validate with not empty hash set v 2 should not throw exception
        /// </summary>
        [Fact]
        public void Validate_WithNotEmptyHashSet_v2_ShouldNotThrowException()
        {
            // Arrange
            IsNotEmptyAttribute attribute = new IsNotEmptyAttribute();
            HashSet<int> notEmptyHashSet = new HashSet<int> { 1 };

            // Act
            attribute.Validate(notEmptyHashSet, nameof(notEmptyHashSet));

            // Assert
            Assert.True(true);
        }
        
        /// <summary>
        /// Tests that validate with empty stack should throw exception
        /// </summary>
        [Fact]
        public void Validate_WithEmptyStack_ShouldThrowException()
        {
            // Arrange
            IsNotEmptyAttribute attribute = new IsNotEmptyAttribute();
            Stack<int> emptyStack = new Stack<int>();

            // Act and Assert
            Assert.Throws<NotEmptyException>(() => attribute.Validate(emptyStack, nameof(emptyStack)));
        }

        /// <summary>
        /// Tests that validate with not empty stack should not throw exception
        /// </summary>
        [Fact]
        public void Validate_WithNotEmptyStack_ShouldNotThrowException()
        {
            // Arrange
            IsNotEmptyAttribute attribute = new IsNotEmptyAttribute();
            Stack<int> notEmptyStack = new Stack<int>();
            notEmptyStack.Push(1);

            // Act
            attribute.Validate(notEmptyStack, nameof(notEmptyStack));

            // Assert
            Assert.True(true);
        }
        
        /// <summary>
        /// Tests that validate with empty linked list should throw exception
        /// </summary>
        [Fact]
        public void Validate_WithEmptyLinkedList_ShouldThrowException()
        {
            // Arrange
            IsNotEmptyAttribute attribute = new IsNotEmptyAttribute();
            LinkedList<int> emptyLinkedList = new LinkedList<int>();

            // Act and Assert
            Assert.Throws<NotEmptyException>(() => attribute.Validate(emptyLinkedList, nameof(emptyLinkedList)));
        }

        /// <summary>
        /// Tests that validate with not empty linked list should not throw exception
        /// </summary>
        [Fact]
        public void Validate_WithNotEmptyLinkedList_ShouldNotThrowException()
        {
            // Arrange
            IsNotEmptyAttribute attribute = new IsNotEmptyAttribute();
            LinkedList<int> notEmptyLinkedList = new LinkedList<int>();
            notEmptyLinkedList.AddLast(1);

            // Act
            attribute.Validate(notEmptyLinkedList, nameof(notEmptyLinkedList));

            // Assert
            Assert.True(true);
        }
        
        /// <summary>
        /// Tests that validate with empty concurrent queue should throw exception
        /// </summary>
        [Fact]
        public void Validate_WithEmptyConcurrentQueue_ShouldThrowException()
        {
            // Arrange
            IsNotEmptyAttribute attribute = new IsNotEmptyAttribute();
            ConcurrentQueue<int> emptyConcurrentQueue = new ConcurrentQueue<int>();

            // Act and Assert
            Assert.Throws<NotEmptyException>(() => attribute.Validate(emptyConcurrentQueue, nameof(emptyConcurrentQueue)));
        }

        /// <summary>
        /// Tests that validate with not empty concurrent queue should not throw exception
        /// </summary>
        [Fact]
        public void Validate_WithNotEmptyConcurrentQueue_ShouldNotThrowException()
        {
            // Arrange
            IsNotEmptyAttribute attribute = new IsNotEmptyAttribute();
            ConcurrentQueue<int> notEmptyConcurrentQueue = new ConcurrentQueue<int>();
            notEmptyConcurrentQueue.Enqueue(1);

            // Act
            attribute.Validate(notEmptyConcurrentQueue, nameof(notEmptyConcurrentQueue));

            // Assert
            Assert.True(true);
        }
        
        /// <summary>
        /// Tests that validate with empty concurrent stack should throw exception
        /// </summary>
        [Fact]
        public void Validate_WithEmptyConcurrentStack_ShouldThrowException()
        {
            // Arrange
            IsNotEmptyAttribute attribute = new IsNotEmptyAttribute();
            ConcurrentStack<int> emptyConcurrentStack = new ConcurrentStack<int>();

            // Act and Assert
            Assert.Throws<NotEmptyException>(() => attribute.Validate(emptyConcurrentStack, nameof(emptyConcurrentStack)));
        }

        /// <summary>
        /// Tests that validate with not empty concurrent stack should not throw exception
        /// </summary>
        [Fact]
        public void Validate_WithNotEmptyConcurrentStack_ShouldNotThrowException()
        {
            // Arrange
            IsNotEmptyAttribute attribute = new IsNotEmptyAttribute();
            ConcurrentStack<int> notEmptyConcurrentStack = new ConcurrentStack<int>();
            notEmptyConcurrentStack.Push(1);

            // Act
            attribute.Validate(notEmptyConcurrentStack, nameof(notEmptyConcurrentStack));

            // Assert
            Assert.True(true);
        }
        /// <summary>
        /// Tests that validate with empty concurrent bag should throw exception
        /// </summary>
        [Fact]
        public void Validate_WithEmptyConcurrentBag_ShouldThrowException()
        {
            // Arrange
            IsNotEmptyAttribute attribute = new IsNotEmptyAttribute();
            emptyConcurrentBag1 = new ConcurrentBag<int>();

            // Act and Assert
            Assert.Throws<NotEmptyException>(() => attribute.Validate(emptyConcurrentBag1, nameof(emptyConcurrentBag1)));
        }

        /// <summary>
        /// Tests that validate with not empty concurrent bag should not throw exception
        /// </summary>
        [Fact]
        public void Validate_WithNotEmptyConcurrentBag_ShouldNotThrowException()
        {
            // Arrange
            IsNotEmptyAttribute attribute = new IsNotEmptyAttribute();
            ConcurrentBag<int> notEmptyConcurrentBag = new ConcurrentBag<int>();
            notEmptyConcurrentBag.Add(1);

            // Act
            attribute.Validate(notEmptyConcurrentBag, nameof(notEmptyConcurrentBag));

            // Assert
            Assert.True(true);
        }
    }
}