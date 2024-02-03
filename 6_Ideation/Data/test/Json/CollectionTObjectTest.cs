// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CollectionTObjectTest.cs
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

using System;
using System.Collections.Generic;
using Alis.Core.Aspect.Data.Json;
using Xunit;

namespace Alis.Core.Aspect.Data.Test.Json
{
    /// <summary>
    /// The collection object test class
    /// </summary>
    public class CollectionTObjectTest
    {
        /// <summary>
        /// Tests that test collection t object clear
        /// </summary>
        [Fact]
        public void TestCollectionTObject_Clear()
        {
            // Arrange
            CollectionTObject<int> collection = new CollectionTObject<int> {List = new List<int> {1, 2, 3}};

            // Act
            collection.Clear();

            // Assert
            Assert.Empty((ICollection<int>) collection.List);
        }

        /// <summary>
        /// Tests that test collection t object add
        /// </summary>
        [Fact]
        public void TestCollectionTObject_Add()
        {
            // Arrange
            CollectionTObject<int> collection = new CollectionTObject<int> {List = new List<int>()};
            int value = 1;

            // Act
            collection.Add(value);

            // Assert
            Assert.Contains(value, (ICollection<int>) collection.List);
        }

        /// <summary>
        /// Tests that test collection t object add null value
        /// </summary>
        [Fact]
        public void TestCollectionTObject_Add_NullValue()
        {
            // Arrange
            CollectionTObject<int?> collection = new CollectionTObject<int?> {List = new List<int?>()};

            // Act
            Assert.Throws<JsonException>(() => collection.Add(null));
        }

        /// <summary>
        /// Tests that test collection t object add null value throws exception
        /// </summary>
        [Fact]
        public void TestCollectionTObject_Add_NullValue_ThrowsException()
        {
            // Arrange
            CollectionTObject<int> collection = new CollectionTObject<int> {List = new List<int>()};

            // Act & Assert
            Assert.Throws<JsonException>(() => collection.Add(null));
        }

        /// <summary>
        /// Tests that test collection t object add value type success
        /// </summary>
        [Fact]
        public void TestCollectionTObject_Add_ValueType_Success()
        {
            // Arrange
            CollectionTObject<int> collection = new CollectionTObject<int>();
            int value = 10;

            // Act
            Assert.Throws<NullReferenceException>(() => collection.Add(value));
        }

        /// <summary>
        /// Tests that test collection t object add reference type success
        /// </summary>
        [Fact]
        public void TestCollectionTObject_Add_ReferenceType_Success()
        {
            // Arrange
            CollectionTObject<string> collection = new CollectionTObject<string>();
            string value = "test";

            // Act
            Assert.Throws<NullReferenceException>(() => collection.Add(value));
        }

        /// <summary>
        /// Tests that test collection t object add null value reference type success
        /// </summary>
        [Fact]
        public void TestCollectionTObject_Add_NullValue_ReferenceType_Success()
        {
            // Arrange
            CollectionTObject<string> collection = new CollectionTObject<string>();
            string value = null;

            // Act
            Assert.Throws<NullReferenceException>(() => collection.Add(value));
        }

        /// <summary>
        /// Tests that test collection t object add null value value type throws exception
        /// </summary>
        [Fact]
        public void TestCollectionTObject_Add_NullValue_ValueType_ThrowsException()
        {
            // Arrange
            CollectionTObject<int> collection = new CollectionTObject<int>();
            object value = null;

            // Act
            void Action() => collection.Add(value);

            // Assert
            Assert.Throws<JsonException>(Action);
        }
    }
}