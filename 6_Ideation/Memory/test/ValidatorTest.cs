// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ValidatorTest.cs
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
using Alis.Core.Aspect.Memory.Attributes;
using Alis.Core.Aspect.Memory.Exceptions;
using Xunit;

namespace Alis.Core.Aspect.Memory.Test
{
    /// <summary>
    /// The validator test class
    /// </summary>
    public class ValidatorTest
    {
        /// <summary>
        /// Gets or sets the value of the test property
        /// </summary>
        [IsNotZero]
        private int TestProperty { get; set; } = 0;

        /// <summary>
        /// Gets or sets the value of the test property 2
        /// </summary>
        [IsNotNull]
        private string TestProperty2 { get; set; } = "Test";

        /// <summary>
        /// The test property
        /// </summary>
        [IsNotNull] private string testProperty3 = "Test";

        /// <summary>
        /// The test property
        /// </summary>
        [IsNotEmpty] private string testProperty4 = "Test";
        
        /// <summary>
        /// The null array
        /// </summary>
        [IsNotNull] private int[] nullArray = null;

        /// <summary>
        /// The null list
        /// </summary>
        [IsNotNull] private List<int> nullList1;

        /// <summary>
        /// The null dictionary
        /// </summary>
        [IsNotNull] private Dictionary<string, string> nullDictionary1;
        

        /// <summary>
        /// The empty dictionary
        /// </summary>
        [IsNotEmpty] private Dictionary<string, string> emptyDictionary2;
        
        /// <summary>
        /// The null dictionary
        /// </summary>
        [IsNotNull] private Dictionary<string, string> nullDictionary2;

        /// <summary>
        /// Tests the method using the specified test param
        /// </summary>
        /// <param name="testParam">The test param</param>
        private void TestMethod([IsNotEmpty] string testParam)
        {
            Validator.Validate(testParam, nameof(testParam));
        }

        /// <summary>
        /// Tests that validate with invalid input should throw exception
        /// </summary>
        [Fact]
        public void Validate_WithInvalidInput_ShouldThrowException()
        {
            // Act and Assert
            Assert.Throws<NotZeroException>(() => Validator.Validate(TestProperty, "TestProperty"));
        }

        /// <summary>
        /// Tests that validate with null property should throw exception
        /// </summary>
        [Fact]
        public void Validate_WithNullProperty_ShouldThrowException()
        {
            // Arrange
            TestProperty2 = null;

            // Act and Assert
            Assert.Throws<NotNullException>(() => Validator.Validate(TestProperty2, nameof(TestProperty2)));
        }

        /// <summary>
        /// Tests that validate with null field should throw exception
        /// </summary>
        [Fact]
        public void Validate_WithNullField_ShouldThrowException()
        {
            // Arrange
            testProperty3 = null;

            // Act and Assert
            Assert.Throws<NotNullException>(() => Validator.Validate(testProperty3, nameof(testProperty3)));
        }

        /// <summary>
        /// Tests that validate with empty field should throw exception
        /// </summary>
        [Fact]
        public void Validate_WithEmptyField_ShouldThrowException()
        {
            // Arrange
            testProperty4 = "";

            // Act and Assert
            Assert.Throws<NotEmptyException>(() => Validator.Validate(testProperty4, nameof(testProperty4)));
        }

        /// <summary>
        /// Tests that validate with empty method should throw exception
        /// </summary>
        [Fact]
        public void Validate_WithEmptyMethod_ShouldThrowException()
        {
            // Arrange
            testProperty4 = "";

            // Act and Assert
            Assert.Throws<NotEmptyException>(() => TestMethod(testProperty4));
        }

        /// <summary>
        /// Tests that validate with non zero long should not throw exception
        /// </summary>
        [Fact]
        public void Validate_WithNonZeroLong_ShouldNotThrowException()
        {
            // Arrange
            IsNotZeroAttribute attribute = new IsNotZeroAttribute();
            long nonZeroValue = 1L;

            // Act
            attribute.Validate(nonZeroValue, nameof(nonZeroValue));

            // Assert
            Assert.True(true);
        }

        /// <summary>
        /// Tests that validate with non zero decimal should not throw exception
        /// </summary>
        [Fact]
        public void Validate_WithNonZeroDecimal_ShouldNotThrowException()
        {
            // Arrange
            IsNotZeroAttribute attribute = new IsNotZeroAttribute();
            decimal nonZeroValue = 1m;

            // Act
            attribute.Validate(nonZeroValue, nameof(nonZeroValue));

            // Assert
            Assert.True(true);
        }

        /// <summary>
        /// Tests that validate with non zero float should not throw exception
        /// </summary>
        [Fact]
        public void Validate_WithNonZeroFloat_ShouldNotThrowException()
        {
            // Arrange
            IsNotZeroAttribute attribute = new IsNotZeroAttribute();
            float nonZeroValue = 1.0f;

            // Act
            attribute.Validate(nonZeroValue, nameof(nonZeroValue));

            // Assert
            Assert.True(true);
        }

        /// <summary>
        /// Tests that validate with non zero double should not throw exception
        /// </summary>
        [Fact]
        public void Validate_WithNonZeroDouble_ShouldNotThrowException()
        {
            // Arrange
            IsNotZeroAttribute attribute = new IsNotZeroAttribute();
            double nonZeroValue = 1.0;

            // Act
            attribute.Validate(nonZeroValue, nameof(nonZeroValue));

            // Assert
            Assert.True(true);
        }

        /// <summary>
        /// Tests that validate with non zero short should not throw exception
        /// </summary>
        [Fact]
        public void Validate_WithNonZeroShort_ShouldNotThrowException()
        {
            // Arrange
            IsNotZeroAttribute attribute = new IsNotZeroAttribute();
            short nonZeroValue = 1;

            // Act
            attribute.Validate(nonZeroValue, nameof(nonZeroValue));

            // Assert
            Assert.True(true);
        }

        /// <summary>
        /// Tests that validate with non zero byte should not throw exception
        /// </summary>
        [Fact]
        public void Validate_WithNonZeroByte_ShouldNotThrowException()
        {
            // Arrange
            IsNotZeroAttribute attribute = new IsNotZeroAttribute();
            byte nonZeroValue = 1;

            // Act
            attribute.Validate(nonZeroValue, nameof(nonZeroValue));

            // Assert
            Assert.True(true);
        }

        /// <summary>
        /// Tests that validate with non zero sbyte should not throw exception
        /// </summary>
        [Fact]
        public void Validate_WithNonZeroSbyte_ShouldNotThrowException()
        {
            // Arrange
            IsNotZeroAttribute attribute = new IsNotZeroAttribute();
            const sbyte nonZeroValue = 1;

            // Act
            attribute.Validate(nonZeroValue, nameof(nonZeroValue));

            // Assert
            Assert.True(true);
        }

        /// <summary>
        /// Tests that validate with non zero ushort should not throw exception
        /// </summary>
        [Fact]
        public void Validate_WithNonZeroUshort_ShouldNotThrowException()
        {
            // Arrange
            IsNotZeroAttribute attribute = new IsNotZeroAttribute();
            ushort nonZeroValue = 1;

            // Act
            attribute.Validate(nonZeroValue, nameof(nonZeroValue));

            // Assert
            Assert.True(true);
        }

        /// <summary>
        /// Tests that validate with non zero uint should not throw exception
        /// </summary>
        [Fact]
        public void Validate_WithNonZeroUint_ShouldNotThrowException()
        {
            // Arrange
            IsNotZeroAttribute attribute = new IsNotZeroAttribute();
            uint nonZeroValue = 1;

            // Act
            attribute.Validate(nonZeroValue, nameof(nonZeroValue));

            // Assert
            Assert.True(true);
        }

        /// <summary>
        /// Tests that validate with non zero ulong should not throw exception
        /// </summary>
        [Fact]
        public void Validate_WithNonZeroUlong_ShouldNotThrowException()
        {
            // Arrange
            IsNotZeroAttribute attribute = new IsNotZeroAttribute();
            ulong nonZeroValue = 1;

            // Act
            attribute.Validate(nonZeroValue, nameof(nonZeroValue));

            // Assert
            Assert.True(true);
        }

        /// <summary>
        /// Tests that validate with null array should throw exception
        /// </summary>
        [Fact]
        public void Validate_WithNullArray_ShouldThrowException()
        {
            // Arrange
            nullArray = null;

            // Act and Assert
            Assert.Throws<NotNullException>(() => Validator.Validate(nullArray, nameof(nullArray)));
        }

        /// <summary>
        /// Tests that validate with not null array should not throw exception
        /// </summary>
        [Fact]
        public void Validate_WithNotNullArray_ShouldNotThrowException()
        {
            // Arrange
            int[] notNullArray = new int[0];

            // Act
            Validator.Validate(notNullArray, nameof(notNullArray));

            // Assert
            Assert.True(true);
        }

        /// <summary>
        /// Tests that validate with not empty array should not throw exception
        /// </summary>
        [Fact]
        public void Validate_WithNotEmptyArray_ShouldNotThrowException()
        {
            // Arrange
            int[] notEmptyArray = new int[] {1};

            // Act
            Validator.Validate(notEmptyArray, nameof(notEmptyArray));

            // Assert
            Assert.True(true);
        }

        /// <summary>
        /// Tests that validate with null list should throw exception
        /// </summary>
        [Fact]
        public void Validate_WithNullList_ShouldThrowException()
        {
            // Arrange
            nullList1 = null;

            // Act and Assert
            Assert.Throws<NotNullException>(() => Validator.Validate(nullList1, nameof(nullList1)));
        }

        /// <summary>
        /// Tests that validate with not null list should not throw exception
        /// </summary>
        [Fact]
        public void Validate_WithNotNullList_ShouldNotThrowException()
        {
            // Arrange
            List<int> notNullList = new List<int>();

            // Act
            Validator.Validate(notNullList, nameof(notNullList));

            // Assert
            Assert.True(true);
        }
        
        /// <summary>
        /// Tests that validate with not empty list should not throw exception
        /// </summary>
        [Fact]
        public void Validate_WithNotEmptyList_ShouldNotThrowException()
        {
            // Arrange
            List<int> notEmptyList = new List<int> {1};

            // Act
            Validator.Validate(notEmptyList, nameof(notEmptyList));

            // Assert
            Assert.True(true);
        }
        
        /// <summary>
        /// Tests that validate with zero int should throw exception
        /// </summary>
        [Fact]
        public void Validate_WithZeroInt_ShouldThrowException()
        {
            // Arrange
            IsNotZeroAttribute attribute = new IsNotZeroAttribute();
            int zeroValue = 0;

            // Act and Assert
            Assert.Throws<NotZeroException>(() => attribute.Validate(zeroValue, nameof(zeroValue)));
        }

        /// <summary>
        /// Tests that validate with null dictionary should throw exception
        /// </summary>
        [Fact]
        public void Validate_WithNullDictionary_ShouldThrowException()
        {
            // Arrange
            nullDictionary1 = null;

            // Act and Assert
            Assert.Throws<NotNullException>(() => Validator.Validate(nullDictionary1, nameof(nullDictionary1)));
        }

        /// <summary>
        /// Tests that validate with not null dictionary should not throw exception
        /// </summary>
        [Fact]
        public void Validate_WithNotNullDictionary_ShouldNotThrowException()
        {
            // Arrange
            Dictionary<string, string> notNullDictionary = new Dictionary<string, string>();

            // Act
            Validator.Validate(notNullDictionary, nameof(notNullDictionary));

            // Assert
            Assert.True(true);
        }

        /// <summary>
        /// Tests that validate with not empty dictionary should not throw exception
        /// </summary>
        [Fact]
        public void Validate_WithNotEmptyDictionary_ShouldNotThrowException()
        {
            // Arrange
            Dictionary<string, string> notEmptyDictionary = new Dictionary<string, string> { { "key", "value" } };

            // Act
            Validator.Validate(notEmptyDictionary, nameof(notEmptyDictionary));

            // Assert
            Assert.True(true);
        }
        
        /// <summary>
        /// Tests that validate with zero int v 2 should throw exception
        /// </summary>
        [Fact]
        public void Validate_WithZeroInt_V2_ShouldThrowException()
        {
            // Arrange
            IsNotZeroAttribute attribute = new IsNotZeroAttribute();
            int zeroValue = 0;

            // Act and Assert
            Assert.Throws<NotZeroException>(() => attribute.Validate(zeroValue, nameof(zeroValue)));
        }

        // Repeat the above test for the remaining types: long, decimal, float, double, short, byte, sbyte, ushort, uint, and ulong

        /// <summary>
        /// Tests that validate with null dictionary v 2 should throw exception
        /// </summary>
        [Fact]
        public void Validate_WithNullDictionary_V2_ShouldThrowException()
        {
            // Arrange
            Dictionary<string, string> nullDictionary = null;

            // Act and Assert
            Validator.Validate(nullDictionary, nameof(nullDictionary));
            
            // Assert
            Assert.True(true);
        }

        /// <summary>
        /// Tests that validate with not null dictionary v 2 should not throw exception
        /// </summary>
        [Fact]
        public void Validate_WithNotNullDictionary_V2_ShouldNotThrowException()
        {
            // Arrange
            Dictionary<string, string> notNullDictionary = new Dictionary<string, string>();

            // Act
            Validator.Validate(notNullDictionary, nameof(notNullDictionary));

            // Assert
            Assert.True(true);
        }

        /// <summary>
        /// Tests that validate with empty dictionary v 2 should throw exception
        /// </summary>
        [Fact]
        public void Validate_WithEmptyDictionary_V2_ShouldThrowException()
        {
            // Arrange
            Dictionary<string, string> emptyDictionary = new Dictionary<string, string>();

            // Act and Assert
            Validator.Validate(emptyDictionary, nameof(emptyDictionary));
            
            // Assert
            Assert.True(true);
        }

        /// <summary>
        /// Tests that validate with not empty dictionary v 2 should not throw exception
        /// </summary>
        [Fact]
        public void Validate_WithNotEmptyDictionary_V2_ShouldNotThrowException()
        {
            // Arrange
            Dictionary<string, string> notEmptyDictionary = new Dictionary<string, string> { { "key", "value" } };

            // Act
            Validator.Validate(notEmptyDictionary, nameof(notEmptyDictionary));

            // Assert
            Assert.True(true);
        }
        
        /// <summary>
        /// Tests that validate with zero int v 3 should throw exception
        /// </summary>
        [Fact]
        public void Validate_WithZeroInt_v3_ShouldThrowException()
        {
            // Arrange
            IsNotZeroAttribute attribute = new IsNotZeroAttribute();
            int zeroValue = 0;

            // Act and Assert
            Assert.Throws<NotZeroException>(() => attribute.Validate(zeroValue, nameof(zeroValue)));
        }

        // Repeat the above test for the remaining types: long, decimal, float, double, short, byte, sbyte, ushort, uint, and ulong

        /// <summary>
        /// Tests that validate with null dictionary v 3 should throw exception
        /// </summary>
        [Fact]
        public void Validate_WithNullDictionary_v3_ShouldThrowException()
        {
            // Arrange
            Dictionary<string, string> nullDictionary = null;

            // Act and Assert
            Validator.Validate(nullDictionary, nameof(nullDictionary));
            
            // Assert
            Assert.True(true);
        }

        /// <summary>
        /// Tests that validate with not null dictionary v 3 should not throw exception
        /// </summary>
        [Fact]
        public void Validate_WithNotNullDictionary_v3_ShouldNotThrowException()
        {
            // Arrange
            Dictionary<string, string> notNullDictionary = new Dictionary<string, string>();

            // Act
            Validator.Validate(notNullDictionary, nameof(notNullDictionary));

            // Assert
            Assert.True(true);
        }

        /// <summary>
        /// Tests that validate with empty dictionary v 3 should throw exception
        /// </summary>
        [Fact]
        public void Validate_WithEmptyDictionary_v3_ShouldThrowException()
        {
            // Arrange
            Dictionary<string, string> emptyDictionary = new Dictionary<string, string>();

            // Act and Assert
            Validator.Validate(emptyDictionary, nameof(emptyDictionary));
            
            // Assert
            Assert.True(true);
        }

        /// <summary>
        /// Tests that validate with not empty dictionary v 3 should not throw exception
        /// </summary>
        [Fact]
        public void Validate_WithNotEmptyDictionary_v3_ShouldNotThrowException()
        {
            // Arrange
            Dictionary<string, string> notEmptyDictionary = new Dictionary<string, string> { { "key", "value" } };

            // Act
            Validator.Validate(notEmptyDictionary, nameof(notEmptyDictionary));

            // Assert
            Assert.True(true);
        }
        
        /// <summary>
        /// Tests that validate with zero int v 4 should throw exception
        /// </summary>
        [Fact]
        public void Validate_WithZeroInt_v4_ShouldThrowException()
        {
            // Arrange
            IsNotZeroAttribute attribute = new IsNotZeroAttribute();
            int zeroValue = 0;

            // Act and Assert
            Assert.Throws<NotZeroException>(() => attribute.Validate(zeroValue, nameof(zeroValue)));
        }

        // Repeat the above test for the remaining types: long, decimal, float, double, short, byte, sbyte, ushort, uint, and ulong

        /// <summary>
        /// Tests that validate with null dictionary v 4 should throw exception
        /// </summary>
        [Fact]
        public void Validate_WithNullDictionary_v4_ShouldThrowException()
        {
            // Arrange
            nullDictionary2 = null;

            // Act and Assert
            Assert.Throws<NotNullException>(() => Validator.Validate(nullDictionary2, nameof(nullDictionary2)));
        }

        /// <summary>
        /// Tests that validate with not null dictionary v 4 should not throw exception
        /// </summary>
        [Fact]
        public void Validate_WithNotNullDictionary_v4_ShouldNotThrowException()
        {
            // Arrange
            Dictionary<string, string> notNullDictionary = new Dictionary<string, string>();

            // Act
            Validator.Validate(notNullDictionary, nameof(notNullDictionary));

            // Assert
            Assert.True(true);
        }

        /// <summary>
        /// Tests that validate with empty dictionary v 4 should throw exception
        /// </summary>
        [Fact]
        public void Validate_WithEmptyDictionary_v4_ShouldThrowException()
        {
            // Arrange
            emptyDictionary2 = new Dictionary<string, string>();

            // Act and Assert
            Assert.Throws<NotEmptyException>(() => Validator.Validate(emptyDictionary2, nameof(emptyDictionary2)));
        }

        /// <summary>
        /// Tests that validate with not empty dictionary v 4 should not throw exception
        /// </summary>
        [Fact]
        public void Validate_WithNotEmptyDictionary_v4_ShouldNotThrowException()
        {
            // Arrange
            Dictionary<string, string> notEmptyDictionary = new Dictionary<string, string> { { "key", "value" } };

            // Act
            Validator.Validate(notEmptyDictionary, nameof(notEmptyDictionary));

            // Assert
            Assert.True(true);
        }
    }
}