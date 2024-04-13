// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:KeyValueTypeEnumeratorTest.cs
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
using System.Collections;
using System.Collections.Generic;
using Alis.Core.Aspect.Data.Json;
using Xunit;

namespace Alis.Core.Aspect.Data.Test.Json
{
    /// <summary>
    ///     The key value type enumerator test class
    /// </summary>
    public class KeyValueTypeEnumeratorTest
    {
        /// <summary>
        ///     Tests that test key value type enumerator move next
        /// </summary>
        [Fact]
        public void TestKeyValueTypeEnumerator_MoveNext()
        {
            // Arrange
            Dictionary<string, int> dictionary = new Dictionary<string, int> {{"test", 1}};
            KeyValueTypeEnumerator enumerator = new KeyValueTypeEnumerator(dictionary);
            
            // Act
            bool result = enumerator.MoveNext();
            
            // Assert
            Assert.True(result);
        }
        
        /// <summary>
        ///     Tests that test key value type enumerator reset
        /// </summary>
        [Fact]
        public void TestKeyValueTypeEnumerator_Reset()
        {
            // Arrange
            Dictionary<string, int> dictionary = new Dictionary<string, int> {{"test", 1}};
            KeyValueTypeEnumerator enumerator = new KeyValueTypeEnumerator(dictionary);
            enumerator.MoveNext();
            
            // Act
            enumerator.Reset();
            bool result = enumerator.MoveNext();
            
            // Assert
            Assert.True(result);
        }
        
        /// <summary>
        ///     Tests that test key value type enumerator entry
        /// </summary>
        [Fact]
        public void TestKeyValueTypeEnumerator_Entry()
        {
            // Arrange
            Dictionary<string, int> dictionary = new Dictionary<string, int> {{"test", 1}};
            KeyValueTypeEnumerator enumerator = new KeyValueTypeEnumerator(dictionary);
            enumerator.MoveNext();
            
            // Act
            DictionaryEntry result = enumerator.Entry;
            
            // Assert
            Assert.Equal(new DictionaryEntry("test", 1), result);
        }
        
        /// <summary>
        ///     Tests that test key value type enumerator key
        /// </summary>
        [Fact]
        public void TestKeyValueTypeEnumerator_Key()
        {
            // Arrange
            Dictionary<string, int> dictionary = new Dictionary<string, int> {{"test", 1}};
            KeyValueTypeEnumerator enumerator = new KeyValueTypeEnumerator(dictionary);
            enumerator.MoveNext();
            
            // Act
            string result = enumerator.Key as string;
            
            // Assert
            Assert.Equal("test", result);
        }
        
        /// <summary>
        ///     Tests that test key value type enumerator value
        /// </summary>
        [Fact]
        public void TestKeyValueTypeEnumerator_Value()
        {
            // Arrange
            Dictionary<string, int> dictionary = new Dictionary<string, int> {{"test", 1}};
            KeyValueTypeEnumerator enumerator = new KeyValueTypeEnumerator(dictionary);
            enumerator.MoveNext();
            
            // Act
            if (enumerator.Value is int result)
            {
                // Assert
                Assert.Equal(1, result);
            }
        }
        
        /// <summary>
        ///     Tests that test key value type enumerator current
        /// </summary>
        [Fact]
        public void TestKeyValueTypeEnumerator_Current()
        {
            // Arrange
            Dictionary<string, int> dictionary = new Dictionary<string, int> {{"test", 1}};
            KeyValueTypeEnumerator enumerator = new KeyValueTypeEnumerator(dictionary);
            enumerator.MoveNext();
            
            // Act
            if (enumerator.Current != null)
            {
                DictionaryEntry result = (DictionaryEntry) enumerator.Current;
                
                // Assert
                Assert.Equal(new DictionaryEntry("test", 1), result);
            }
        }
        
        /// <summary>
        ///     Tests that entry key prop is null and enumerator current is null throws invalid operation exception
        /// </summary>
        [Fact]
        public void Entry_KeyPropIsNullAndEnumeratorCurrentIsNull_ThrowsInvalidOperationException()
        {
            KeyValueTypeEnumerator enumerator = new KeyValueTypeEnumerator(new Dictionary<string, int>());
            Assert.Throws<InvalidOperationException>(() => enumerator.Entry);
        }
        
        /// <summary>
        ///     Tests that entry key prop is null and enumerator current is not null sets key prop and value prop
        /// </summary>
        [Fact]
        public void Entry_KeyPropIsNullAndEnumeratorCurrentIsNotNull_SetsKeyPropAndValueProp()
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int> {{"test", 1}};
            KeyValueTypeEnumerator enumerator = new KeyValueTypeEnumerator(dictionary);
            enumerator.MoveNext();
            DictionaryEntry entry = enumerator.Entry;
            Assert.Equal(new DictionaryEntry("test", 1), entry);
        }
        
        /// <summary>
        ///     Tests that entry value prop is null throws invalid operation exception
        /// </summary>
        [Fact]
        public void Entry_ValuePropIsNull_ThrowsInvalidOperationException()
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int> {{"test", 1}};
            KeyValueTypeEnumerator enumerator = new KeyValueTypeEnumerator(dictionary);
            Assert.Throws<InvalidOperationException>(() => enumerator.Entry);
        }
        
        /// <summary>
        ///     Tests that entry key prop is not null and value prop is not null returns dictionary entry
        /// </summary>
        [Fact]
        public void Entry_KeyPropIsNotNullAndValuePropIsNotNull_ReturnsDictionaryEntry()
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int> {{"test", 1}};
            KeyValueTypeEnumerator enumerator = new KeyValueTypeEnumerator(dictionary);
            enumerator.MoveNext();
            DictionaryEntry entry = enumerator.Entry;
            Assert.Equal(new DictionaryEntry("test", 1), entry);
        }
        
        /// <summary>
        ///     Tests that indexer set throws not supported exception
        /// </summary>
        [Fact]
        public void Indexer_Set_ThrowsNotSupportedException()
        {
            KeyValueTypeDictionary dictionary = new KeyValueTypeDictionary(new List<int>());
            Assert.Throws<NotSupportedException>(() => { dictionary["test"] = "value"; });
        }
        
        
        /// <summary>
        ///     Tests that test move next with empty collection returns false
        /// </summary>
        [Fact]
        public void TestMoveNext_WithEmptyCollection_ReturnsFalse()
        {
            // Arrange
            List<KeyValuePair<string, string>> emptyCollection = new List<KeyValuePair<string, string>>();
            KeyValueTypeEnumerator enumerator = new KeyValueTypeEnumerator(emptyCollection);
            
            // Act
            bool result = enumerator.MoveNext();
            
            // Assert
            Assert.False(result);
        }
        
        /// <summary>
        ///     Tests that test move next with non empty collection returns true
        /// </summary>
        [Fact]
        public void TestMoveNext_WithNonEmptyCollection_ReturnsTrue()
        {
            // Arrange
            List<KeyValuePair<string, string>> collection = new List<KeyValuePair<string, string>> {new KeyValuePair<string, string>("key", "value")};
            KeyValueTypeEnumerator enumerator = new KeyValueTypeEnumerator(collection);
            
            // Act
            bool result = enumerator.MoveNext();
            
            // Assert
            Assert.True(result);
        }
        
        
        /// <summary>
        ///     Tests that dispose when called disposes enumerator and value if disposable
        /// </summary>
        [Fact]
        public void Dispose_WhenCalled_DisposesEnumeratorAndValueIfDisposable()
        {
            // Arrange
            List<DisposableTracker> disposableTrackers = new List<DisposableTracker> {new DisposableTracker(), new DisposableTracker()};
            Dictionary<string, DisposableTracker> dictionary = new Dictionary<string, DisposableTracker>();
            foreach (DisposableTracker tracker in disposableTrackers)
            {
                dictionary.Add(Guid.NewGuid().ToString(), tracker);
            }
            
            KeyValueTypeEnumerator enumerator = new KeyValueTypeEnumerator(dictionary);
            
            // Act
            enumerator.Dispose();
            
            // Assert
            foreach (DisposableTracker tracker in disposableTrackers)
            {
                Assert.False(tracker.IsDisposed);
            }
        }
    }
}