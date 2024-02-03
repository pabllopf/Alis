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
    /// The key value type dictionary test class
    /// </summary>
    public class KeyValueTypeDictionaryTest
    {
        /// <summary>
        /// Tests that test key value type dictionary add throws exception
        /// </summary>
        [Fact]
        public void TestKeyValueTypeDictionary_Add_ThrowsException()
        {
            // Arrange
            List<string> list = new List<string> { "value" };
            KeyValueTypeDictionary dictionary = new KeyValueTypeDictionary(list);
            if (dictionary == null)
            {
                throw new ArgumentNullException(nameof(dictionary));
            }

            // Act & Assert
            Assert.Throws<NotSupportedException>(() => dictionary.Add("key", "value"));
        }

        /// <summary>
        /// Tests that test key value type dictionary clear throws exception
        /// </summary>
        [Fact]
        public void TestKeyValueTypeDictionary_Clear_ThrowsException()
        {
            // Arrange
            List<string> list = new List<string> { "value" };
            KeyValueTypeDictionary dictionary = new KeyValueTypeDictionary(list);
            if (dictionary == null)
            {
                throw new ArgumentNullException(nameof(dictionary));
            }

            // Act & Assert
            Assert.Throws<NotSupportedException>(() => dictionary.Clear());
        }

        /// <summary>
        /// Tests that test key value type dictionary contains throws exception
        /// </summary>
        [Fact]
        public void TestKeyValueTypeDictionary_Contains_ThrowsException()
        {
            // Arrange
            List<string> list = new List<string> { "value" };
            KeyValueTypeDictionary dictionary = new KeyValueTypeDictionary(list);
            if (dictionary == null)
            {
                throw new ArgumentNullException(nameof(dictionary));
            }

            // Act & Assert
            Assert.Throws<NotSupportedException>(() => dictionary.Contains("key"));
        }

        /// <summary>
        /// Tests that test key value type dictionary remove throws exception
        /// </summary>
        [Fact]
        public void TestKeyValueTypeDictionary_Remove_ThrowsException()
        {
            // Arrange
            List<string> list = new List<string> { "value" };
            KeyValueTypeDictionary dictionary = new KeyValueTypeDictionary(list);
            if (dictionary == null)
            {
                throw new ArgumentNullException(nameof(dictionary));
            }

            // Act & Assert
            Assert.Throws<NotSupportedException>(() => dictionary.Remove("key"));
        }

        /// <summary>
        /// Tests that test key value type dictionary copy to throws exception
        /// </summary>
        [Fact]
        public void TestKeyValueTypeDictionary_CopyTo_ThrowsException()
        {
            // Arrange
            List<string> list = new List<string> { "value" };
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
        /// Tests that test key value type dictionary get enumerator throws exception
        /// </summary>
        [Fact]
        public void TestKeyValueTypeDictionary_GetEnumerator_ThrowsException()
        {
            // Arrange
            List<string> list = new List<string> { "value" };
            KeyValueTypeDictionary dictionary = new KeyValueTypeDictionary(list);

            // Act & Assert
            Assert.Throws<NotSupportedException>(() => ((IEnumerable) dictionary).GetEnumerator());
        }

        /// <summary>
        /// Tests that test key value type dictionary indexer throws exception
        /// </summary>
        [Fact]
        public void TestKeyValueTypeDictionary_Indexer_ThrowsException()
        {
            // Arrange
            List<string> list = new List<string> { "value" };
            KeyValueTypeDictionary dictionary = new KeyValueTypeDictionary(list);
            if (dictionary == null)
            {
                throw new ArgumentNullException(nameof(dictionary));
            }

            // Act & Assert
            Assert.Throws<NotSupportedException>(() => dictionary["key"] = "value");
        }
    }
}