// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: ValidationExtensionsTest.cs
// 
//  Author: Pablo Perdomo Falcón
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

using Xunit;

namespace Alis.Core.Aspect.Memory.Test
{
    /// <summary>
    ///     The validation extensions test class
    /// </summary>
    public class ValidationExtensionsTest
    {
        /// <summary>
        ///     Tests that validate with multiple valid values should return same values
        /// </summary>
        [Fact]
        public void Validate_WithMultipleValidValues_ShouldReturnSameValues()
        {
            // Arrange
            const string validString = "Hello, World!";
            const int validInt = 100;

            // Act
            string resultString = validString.Validate();
            int resultInt = validInt.Validate();

            // Assert
            Assert.Equal(validString, resultString);
            Assert.Equal(validInt, resultInt);
        }

        /// <summary>
        ///     Tests that validate with valid value should return same value
        /// </summary>
        [Fact]
        public void Validate_WithValidValue_ShouldReturnSameValue()
        {
            // Arrange
            int validValue = 42;

            // Act
            int result = validValue.Validate();

            // Assert
            Assert.Equal(validValue, result);
        }
    }
}