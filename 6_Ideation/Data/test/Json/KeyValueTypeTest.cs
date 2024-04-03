// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:KeyValueTypeTest.cs
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
using Alis.Core.Aspect.Data.Json;
using Xunit;

namespace Alis.Core.Aspect.Data.Test.Json
{

    /// <summary>
    /// The key value type tests class
    /// </summary>
    public class KeyValueTypeTests
    {
        /// <summary>
        /// Tests that key type set get
        /// </summary>
        [Fact]
        public void KeyType_Set_Get()
        {
            // Arrange
            KeyValueType keyValueType = new KeyValueType();
            Type expectedType = typeof(int);

            // Act
            keyValueType.KeyType = expectedType;

            // Assert
            Assert.Equal(expectedType, keyValueType.KeyType);
        }

        /// <summary>
        /// Tests that value type set get
        /// </summary>
        [Fact]
        public void ValueType_Set_Get()
        {
            // Arrange
            KeyValueType keyValueType = new KeyValueType();
            Type expectedType = typeof(string);

            // Act
            keyValueType.ValueType = expectedType;

            // Assert
            Assert.Equal(expectedType, keyValueType.ValueType);
        }
    }
}