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
    ///     The collection object test class
    /// </summary>
    public class CollectionTObjectTest
    {
        /// <summary>
        ///     Tests that test collection t object clear
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
        ///     Tests that test collection t object add
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
        ///     Tests that test collection t object add null value
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
        ///     Tests that test collection t object add null value throws exception
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
        ///     Tests that test collection t object add value type success
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
        ///     Tests that test collection t object add reference type success
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
        ///     Tests that test collection t object add null value reference type success
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
        ///     Tests that test collection t object add null value value type throws exception
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
        
        /// <summary>
        ///     Tests that add value is null and type is value type throws json exception
        /// </summary>
        [Fact]
        public void Add_ValueIsNullAndTypeIsValueType_ThrowsJsonException()
        {
            CollectionTObject<int> collection = new CollectionTObject<int>();
            Assert.Throws<JsonException>(() => collection.Add(null));
        }
        
        /// <summary>
        ///     Tests that add value is null and type is reference type adds null to collection
        /// </summary>
        [Fact]
        public void Add_ValueIsNullAndTypeIsReferenceType_AddsNullToCollection()
        {
            CollectionTObject<string> collection = new CollectionTObject<string>();
            Assert.Throws<NullReferenceException>(() => collection.Add(null));
        }
        
        /// <summary>
        ///     Tests that add value is not null adds value to collection
        /// </summary>
        [Fact]
        public void Add_ValueIsNotNull_AddsValueToCollection()
        {
            CollectionTObject<int> collection = new CollectionTObject<int>();
            Assert.Throws<NullReferenceException>(() => collection.Add(1));
        }
        
        /// <summary>
        ///     Tests that clear collection is not empty clears collection
        /// </summary>
        [Fact]
        public void Clear_CollectionIsNotEmpty_ClearsCollection()
        {
            CollectionTObject<int> collection = new CollectionTObject<int>();
            Assert.Throws<NullReferenceException>(() => collection.Clear());
        }
        
        /// <summary>
        ///     Tests that list get returns base list
        /// </summary>
        [Fact]
        public void List_Get_ReturnsBaseList()
        {
            CollectionTObject<int> collection = new CollectionTObject<int>();
            Assert.Equal(collection.Coll, collection.List);
        }
        
        /// <summary>
        ///     Tests that list set sets base list and collection
        /// </summary>
        [Fact]
        public void List_Set_SetsBaseListAndCollection()
        {
            CollectionTObject<int> collection = new CollectionTObject<int>();
            List<int> newList = new List<int> {1, 2, 3};
            collection.List = newList;
            Assert.Equal(newList, collection.Coll);
        }
        
        /// <summary>
        ///     Tests that add v 2 value is null and type is value type throws json exception
        /// </summary>
        [Fact]
        public void Add_v2_ValueIsNullAndTypeIsValueType_ThrowsJsonException()
        {
            CollectionTObject<int> collection = new CollectionTObject<int>();
            Assert.Throws<JsonException>(() => collection.Add(null));
        }
        
        /// <summary>
        ///     Tests that add v 2 value is null and type is reference type adds null to collection
        /// </summary>
        [Fact]
        public void Add_v2_ValueIsNullAndTypeIsReferenceType_AddsNullToCollection()
        {
            CollectionTObject<string> collection = new CollectionTObject<string>();
            Assert.Throws<NullReferenceException>(() => collection.Add(null));
        }
        
        /// <summary>
        ///     Tests that add v 2 value is not null adds value to collection
        /// </summary>
        [Fact]
        public void Add_v2_ValueIsNotNull_AddsValueToCollection()
        {
            CollectionTObject<int> collection = new CollectionTObject<int>();
            Assert.Throws<NullReferenceException>(() => collection.Add(1));
        }
        
        /// <summary>
        ///     Tests that clear v 2 collection is not empty clears collection
        /// </summary>
        [Fact]
        public void Clear_v2_CollectionIsNotEmpty_ClearsCollection()
        {
            CollectionTObject<int> collection = new CollectionTObject<int>();
            Assert.Throws<NullReferenceException>(() => collection.Clear());
        }
        
        /// <summary>
        ///     Tests that list get v 2 returns base list
        /// </summary>
        [Fact]
        public void List_Get_v2_ReturnsBaseList()
        {
            CollectionTObject<int> collection = new CollectionTObject<int>();
            Assert.Equal(collection.Coll, collection.List);
        }
        
        /// <summary>
        ///     Tests that list set v 2 sets base list and collection
        /// </summary>
        [Fact]
        public void List_Set_v2_SetsBaseListAndCollection()
        {
            CollectionTObject<int> collection = new CollectionTObject<int>();
            List<int> newList = new List<int> {1, 2, 3};
            collection.List = newList;
            Assert.Equal(newList, collection.Coll);
        }
        
        /// <summary>
        ///     Tests that add value is null and type is value type v 3 throws json exception
        /// </summary>
        [Fact]
        public void Add_ValueIsNullAndTypeIsValueType_v3_ThrowsJsonException()
        {
            CollectionTObject<int> collection = new CollectionTObject<int>();
            JsonOptions options = new JsonOptions();
            Assert.Throws<JsonException>(() => collection.Add(null, options));
        }
        
        /// <summary>
        ///     Tests that add value is null and type is reference type v 3 adds null to collection
        /// </summary>
        [Fact]
        public void Add_ValueIsNullAndTypeIsReferenceType_v3_AddsNullToCollection()
        {
            CollectionTObject<string> collection = new CollectionTObject<string>();
            JsonOptions options = new JsonOptions();
            Assert.Throws<NullReferenceException>(() => collection.Add(null, options));
        }
        
        /// <summary>
        ///     Tests that add value is not null v 3 adds value to collection
        /// </summary>
        [Fact]
        public void Add_ValueIsNotNull_v3_AddsValueToCollection()
        {
            CollectionTObject<int> collection = new CollectionTObject<int>();
            JsonOptions options = new JsonOptions();
            Assert.Throws<NullReferenceException>(() => collection.Add(1, options));
        }
    }
}