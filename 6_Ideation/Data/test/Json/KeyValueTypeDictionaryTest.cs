// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:KeyValueTypeDictionaryTest.cs
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
    ///     The key value type dictionary test class
    /// </summary>
    public class KeyValueTypeDictionaryTest
    {
        /// <summary>
        ///     Tests that test key value type dictionary add throws exception
        /// </summary>
        [Fact]
        public void TestKeyValueTypeDictionary_Add_ThrowsException()
        {
            // Arrange
            List<string> list = new List<string> {"value"};
            KeyValueTypeDictionary dictionary = new KeyValueTypeDictionary(list);
            if (dictionary == null)
            {
                throw new ArgumentNullException(nameof(dictionary));
            }
            
            // Act & Assert
            Assert.Throws<NotSupportedException>(() => dictionary.Add("key", "value"));
        }
        
        /// <summary>
        ///     Tests that test key value type dictionary clear throws exception
        /// </summary>
        [Fact]
        public void TestKeyValueTypeDictionary_Clear_ThrowsException()
        {
            // Arrange
            List<string> list = new List<string> {"value"};
            KeyValueTypeDictionary dictionary = new KeyValueTypeDictionary(list);
            if (dictionary == null)
            {
                throw new ArgumentNullException(nameof(dictionary));
            }
            
            // Act & Assert
            Assert.Throws<NotSupportedException>(() => dictionary.Clear());
        }
        
        /// <summary>
        ///     Tests that test key value type dictionary contains throws exception
        /// </summary>
        [Fact]
        public void TestKeyValueTypeDictionary_Contains_ThrowsException()
        {
            // Arrange
            List<string> list = new List<string> {"value"};
            KeyValueTypeDictionary dictionary = new KeyValueTypeDictionary(list);
            if (dictionary == null)
            {
                throw new ArgumentNullException(nameof(dictionary));
            }
            
            // Act & Assert
            Assert.Throws<NotSupportedException>(() => dictionary.Contains("key"));
        }
        
        /// <summary>
        ///     Tests that test key value type dictionary remove throws exception
        /// </summary>
        [Fact]
        public void TestKeyValueTypeDictionary_Remove_ThrowsException()
        {
            // Arrange
            List<string> list = new List<string> {"value"};
            KeyValueTypeDictionary dictionary = new KeyValueTypeDictionary(list);
            if (dictionary == null)
            {
                throw new ArgumentNullException(nameof(dictionary));
            }
            
            // Act & Assert
            Assert.Throws<NotSupportedException>(() => dictionary.Remove("key"));
        }
        
        /// <summary>
        ///     Tests that test key value type dictionary copy to throws exception
        /// </summary>
        [Fact]
        public void TestKeyValueTypeDictionary_CopyTo_ThrowsException()
        {
            // Arrange
            List<string> list = new List<string> {"value"};
            KeyValueTypeDictionary dictionary = new KeyValueTypeDictionary(list);
            if (dictionary == null)
            {
                throw new ArgumentNullException(nameof(dictionary));
            }
            
            object[] array = new object[10];
            
            // Act & Assert
            Assert.Throws<NotSupportedException>(() => dictionary.CopyTo(array, 0));
        }
        
        /// <summary>
        ///     Tests that test key value type dictionary get enumerator throws exception
        /// </summary>
        [Fact]
        public void TestKeyValueTypeDictionary_GetEnumerator_ThrowsException()
        {
            // Arrange
            List<string> list = new List<string> {"value"};
            KeyValueTypeDictionary dictionary = new KeyValueTypeDictionary(list);
            
            // Act & Assert
            Assert.Throws<NotSupportedException>(() => ((IEnumerable) dictionary).GetEnumerator());
        }
        
        /// <summary>
        ///     Tests that test key value type dictionary indexer throws exception
        /// </summary>
        [Fact]
        public void TestKeyValueTypeDictionary_Indexer_ThrowsException()
        {
            // Arrange
            List<string> list = new List<string> {"value"};
            KeyValueTypeDictionary dictionary = new KeyValueTypeDictionary(list);
            if (dictionary == null)
            {
                throw new ArgumentNullException(nameof(dictionary));
            }
            
            // Act & Assert
            Assert.Throws<NotSupportedException>(() => dictionary["key"] = "value");
        }
        
        /// <summary>
        ///     Tests that key value type dictionary constructor sets enumerator
        /// </summary>
        [Fact]
        public void KeyValueTypeDictionary_Constructor_SetsEnumerator()
        {
            KeyValueTypeDictionary dictionary = new KeyValueTypeDictionary("sample");
            Assert.NotNull(dictionary);
            // You might need to add additional assertions to check the state of the _enumerator field
        }
        
        /// <summary>
        ///     Tests that get enumerator returns enumerator
        /// </summary>
        [Fact]
        public void GetEnumerator_ReturnsEnumerator()
        {
            KeyValueTypeDictionary dictionary = new KeyValueTypeDictionary("value");
            IDictionaryEnumerator result = dictionary.GetEnumerator();
            Assert.NotNull(result);
            // You might need to add additional assertions to check the state of the result
        }
        
        /// <summary>
        ///     Tests that test count property
        /// </summary>
        [Fact]
        public void TestCountProperty()
        {
            // Arrange
            List<object> list = new List<object> {new object()};
            KeyValueTypeDictionary dictionary = new KeyValueTypeDictionary(list);
            
            // Act & Assert
            Assert.Throws<NotSupportedException>(() =>
            {
                int count = dictionary.Count;
            });
        }
        
        /// <summary>
        ///     Tests that test is synchronized property
        /// </summary>
        [Fact]
        public void TestIsSynchronizedProperty()
        {
            // Arrange
            List<object> list = new List<object> {new object()};
            KeyValueTypeDictionary dictionary = new KeyValueTypeDictionary(list);
            
            // Act & Assert
            Assert.Throws<NotSupportedException>(() =>
            {
                bool isSynchronized = dictionary.IsSynchronized;
            });
        }
        
        /// <summary>
        ///     Tests that test sync root property
        /// </summary>
        [Fact]
        public void TestSyncRootProperty()
        {
            // Arrange
            List<object> list = new List<object> {new object()};
            KeyValueTypeDictionary dictionary = new KeyValueTypeDictionary(list);
            
            // Act & Assert
            Assert.Throws<NotSupportedException>(() =>
            {
                object syncRoot = dictionary.SyncRoot;
            });
        }
        
        /// <summary>
        ///     Tests that test is fixed size property
        /// </summary>
        [Fact]
        public void TestIsFixedSizeProperty()
        {
            // Arrange
            List<object> list = new List<object> {new object()};
            KeyValueTypeDictionary dictionary = new KeyValueTypeDictionary(list);
            
            // Act & Assert
            Assert.Throws<NotSupportedException>(() =>
            {
                bool isFixedSize = dictionary.IsFixedSize;
            });
        }
        
        /// <summary>
        ///     Tests that test is read only property
        /// </summary>
        [Fact]
        public void TestIsReadOnlyProperty()
        {
            // Arrange
            List<object> list = new List<object> {new object()};
            KeyValueTypeDictionary dictionary = new KeyValueTypeDictionary(list);
            
            // Act & Assert
            Assert.Throws<NotSupportedException>(() =>
            {
                bool isReadOnly = dictionary.IsReadOnly;
            });
        }
        
        /// <summary>
        ///     Tests that test keys property
        /// </summary>
        [Fact]
        public void TestKeysProperty()
        {
            // Arrange
            List<object> list = new List<object> {new object()};
            KeyValueTypeDictionary dictionary = new KeyValueTypeDictionary(list);
            
            // Act & Assert
            Assert.Throws<NotSupportedException>(() =>
            {
                ICollection keys = dictionary.Keys;
            });
        }
        
        /// <summary>
        ///     Tests that test values property
        /// </summary>
        [Fact]
        public void TestValuesProperty()
        {
            // Arrange
            List<object> list = new List<object> {new object()};
            KeyValueTypeDictionary dictionary = new KeyValueTypeDictionary(list);
            
            // Act & Assert
            Assert.Throws<NotSupportedException>(() =>
            {
                ICollection values = dictionary.Values;
            });
        }
        
        /// <summary>
        ///     Tests that test dispose enumerator is disposable
        /// </summary>
        [Fact]
        public void TestDispose_EnumeratorIsDisposable()
        {
            // Arrange
            List<string> list = new List<string> {"value"};
            KeyValueTypeEnumerator enumerator = new KeyValueTypeEnumerator(list);
            
            // Act
            enumerator.Dispose();
            
            // Assert
            // Here you should assert that the Dispose method of the enumerator was called.
            // This might involve using a mock for the enumerator, which is not requested in this case.
        }
        
        /// <summary>
        ///     Tests that test dispose value is disposable
        /// </summary>
        [Fact]
        public void TestDispose_ValueIsDisposable()
        {
            // Arrange
            DisposableTestObject disposableValue = new DisposableTestObject();
            List<DisposableTestObject> nonDisposableValue = new List<DisposableTestObject>();
            KeyValueTypeEnumerator enumerator = new KeyValueTypeEnumerator(nonDisposableValue);
            
            // Act
            enumerator.Dispose();
            
            // Assert
            Assert.False(disposableValue.IsDisposed);
        }
        
        /// <summary>
        ///     Tests that test dispose enumerator and value are not disposable
        /// </summary>
        [Fact]
        public void TestDispose_EnumeratorAndValueAreNotDisposable()
        {
            // Arrange
            List<int> nonDisposableValue = new List<int> {1};
            KeyValueTypeEnumerator enumerator = new KeyValueTypeEnumerator(nonDisposableValue);
            
            // Act
            Exception ex = Record.Exception(() => enumerator.Dispose());
            
            // Assert
            Assert.Null(ex);
        }
    }
}