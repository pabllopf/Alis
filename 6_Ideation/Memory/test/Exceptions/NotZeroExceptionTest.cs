// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NotZeroExceptionTest.cs
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

using Alis.Core.Aspect.Memory.Attributes;
using Alis.Core.Aspect.Memory.Exceptions;
using Xunit;

namespace Alis.Core.Aspect.Memory.Test.Exceptions
{
    /// <summary>
    ///     The not zero exception test class
    /// </summary>
    public class NotZeroExceptionTest
    {
        /// <summary>
        /// Tests that not zero exception with message should set message
        /// </summary>
        [Fact]
        public void NotZeroException_WithMessage_ShouldSetMessage()
        {
            // Arrange
            const string message = "Test message";

            // Act
            NotZeroException exception = new NotZeroException(message);

            // Assert
            Assert.Equal(message, exception.Message);
        }
        
        /// <summary>
        /// Tests that validate with zero double should throw exception
        /// </summary>
        [Fact]
        public void Validate_WithZeroDouble_ShouldThrowException()
        {
            // Arrange
            IsNotZeroAttribute attribute = new IsNotZeroAttribute();
            double zeroValue = 0.0;

            // Act and Assert
            Assert.Throws<NotZeroException>(() => attribute.Validate(zeroValue, nameof(zeroValue)));
        }

        /// <summary>
        /// Tests that validate with zero decimal should throw exception
        /// </summary>
        [Fact]
        public void Validate_WithZeroDecimal_ShouldThrowException()
        {
            // Arrange
            IsNotZeroAttribute attribute = new IsNotZeroAttribute();
            decimal zeroValue = 0;

            // Act and Assert
            Assert.Throws<NotZeroException>(() => attribute.Validate(zeroValue, nameof(zeroValue)));
        }

        
        /// <summary>
        /// Tests that validate with zero float should throw exception
        /// </summary>
        [Fact]
        public void Validate_WithZeroFloat_ShouldThrowException()
        {
            // Arrange
            IsNotZeroAttribute attribute = new IsNotZeroAttribute();
            float zeroValue = 0.0f;

            // Act and Assert
            Assert.Throws<NotZeroException>(() => attribute.Validate(zeroValue, nameof(zeroValue)));
        }

        /// <summary>
        /// Tests that validate with zero long should throw exception
        /// </summary>
        [Fact]
        public void Validate_WithZeroLong_ShouldThrowException()
        {
            // Arrange
            IsNotZeroAttribute attribute = new IsNotZeroAttribute();
            long zeroValue = 0L;

            // Act and Assert
            Assert.Throws<NotZeroException>(() => attribute.Validate(zeroValue, nameof(zeroValue)));
        }
        
        /// <summary>
        /// Tests that validate with zero int should throw exception
        /// </summary>
        [Fact]
        public void Validate_WithZeroInt_ShouldThrowException()
        {
            // Arrange
            IsNotZeroAttribute attribute = new IsNotZeroAttribute();
            const int zeroValue = 0;

            // Act and Assert
            Assert.Throws<NotZeroException>(() => attribute.Validate(zeroValue, nameof(zeroValue)));
        }
        
        
        /// <summary>
        /// Tests that validate with zero short should throw exception
        /// </summary>
        [Fact]
        public void Validate_WithZeroShort_ShouldThrowException()
        {
            // Arrange
            IsNotZeroAttribute attribute = new IsNotZeroAttribute();
            const short zeroValue = 0;

            // Act and Assert
            Assert.Throws<NotZeroException>(() => attribute.Validate(zeroValue, nameof(zeroValue)));
        }
        
        /// <summary>
        /// Tests that validate with zero byte should throw exception
        /// </summary>
        [Fact]
        public void Validate_WithZeroByte_ShouldThrowException()
        {
            // Arrange
            IsNotZeroAttribute attribute = new IsNotZeroAttribute();
            const byte zeroValue = 0;

            // Act and Assert
            Assert.Throws<NotZeroException>(() => attribute.Validate(zeroValue, nameof(zeroValue)));
        }
        
        /// <summary>
        /// Tests that validate with zero sbyte should throw exception
        /// </summary>
        [Fact]
        public void Validate_WithZeroSbyte_ShouldThrowException()
        {
            // Arrange
            IsNotZeroAttribute attribute = new IsNotZeroAttribute();
            const sbyte zeroValue = 0;

            // Act and Assert
            Assert.Throws<NotZeroException>(() => attribute.Validate(zeroValue, nameof(zeroValue)));
        }
        
        /// <summary>
        /// Tests that validate with zero ushort should throw exception
        /// </summary>
        [Fact]
        public void Validate_WithZeroUshort_ShouldThrowException()
        {
            // Arrange
            IsNotZeroAttribute attribute = new IsNotZeroAttribute();
            const ushort zeroValue = 0;

            // Act and Assert
            Assert.Throws<NotZeroException>(() => attribute.Validate(zeroValue, nameof(zeroValue)));
        }
        
        /// <summary>
        /// Tests that validate with zero uint should throw exception
        /// </summary>
        [Fact]
        public void Validate_WithZeroUint_ShouldThrowException()
        {
            // Arrange
            IsNotZeroAttribute attribute = new IsNotZeroAttribute();
            const uint zeroValue = 0;

            // Act and Assert
            Assert.Throws<NotZeroException>(() => attribute.Validate(zeroValue, nameof(zeroValue)));
        }
        
        /// <summary>
        /// Tests that validate with zero ulong should throw exception
        /// </summary>
        [Fact]
        public void Validate_WithZeroUlong_ShouldThrowException()
        {
            // Arrange
            IsNotZeroAttribute attribute = new IsNotZeroAttribute();
            const ulong zeroValue = 0;

            // Act and Assert
            Assert.Throws<NotZeroException>(() => attribute.Validate(zeroValue, nameof(zeroValue)));
        }
        
        /// <summary>
        /// Tests that validate with non zero int should not throw exception
        /// </summary>
        [Fact]
        public void Validate_WithNonZeroInt_ShouldNotThrowException()
        {
            // Arrange
            IsNotZeroAttribute attribute = new IsNotZeroAttribute();
            int nonZeroValue = 1;

            // Act
            attribute.Validate(nonZeroValue, nameof(nonZeroValue));

            // Assert
            Assert.True(true);
        }
    }
}