// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ComponentAlreadyExistsExceptionExtendedTest.cs
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
using Alis.Core.Ecs.Exceptions;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Exceptions
{
    /// <summary>
    ///     The component already exists exception extended test class
    /// </summary>
    /// <remarks>
    ///     Tests the <see cref="ComponentAlreadyExistsException"/> exception class
    ///     with more comprehensive test cases.
    /// </remarks>
    public class ComponentAlreadyExistsExceptionExtendedTest
    {
        /// <summary>
        ///     Tests that exception can be created with type
        /// </summary>
        /// <remarks>
        ///     Verifies that ComponentAlreadyExistsException can be instantiated with a type.
        /// </remarks>
        [Fact]
        public void ComponentAlreadyExistsException_CanBeCreatedWithType()
        {
            // Act
            ComponentAlreadyExistsException ex = new ComponentAlreadyExistsException(typeof(TestComponent));

            // Assert
            Assert.NotNull(ex);
            Assert.IsAssignableFrom<Exception>(ex);
        }

        /// <summary>
        ///     Tests that exception message contains type name
        /// </summary>
        /// <remarks>
        ///     Validates that the exception message includes the type name.
        /// </remarks>
        [Fact]
        public void ComponentAlreadyExistsException_MessageContainsTypeName()
        {
            // Arrange
            Type testType = typeof(Position);

            // Act
            ComponentAlreadyExistsException ex = new ComponentAlreadyExistsException(testType);

            // Assert
            Assert.Contains("Position", ex.Message);
            Assert.Contains("already exists", ex.Message);
        }

        /// <summary>
        ///     Tests that exception can be created with message
        /// </summary>
        /// <remarks>
        ///     Tests creating the exception with a custom message.
        /// </remarks>
        [Fact]
        public void ComponentAlreadyExistsException_CanBeCreatedWithMessage()
        {
            // Arrange
            string customMessage = "Custom error message";

            // Act
            ComponentAlreadyExistsException ex = new ComponentAlreadyExistsException(customMessage);

            // Assert
            Assert.NotNull(ex);
            Assert.Equal(customMessage, ex.Message);
        }

        /// <summary>
        ///     Tests that exception is catchable as Exception
        /// </summary>
        /// <remarks>
        ///     Validates that the exception can be caught as a base Exception.
        /// </remarks>
        [Fact]
        public void ComponentAlreadyExistsException_IsCatchableAsException()
        {
            // Act & Assert
            Exception thrownException = null;
            try
            {
                throw new ComponentAlreadyExistsException(typeof(TestComponent));
            }
            catch (Exception ex)
            {
                thrownException = ex;
            }

            Assert.NotNull(thrownException);
            Assert.IsAssignableFrom<ComponentAlreadyExistsException>(thrownException);
        }

        /// <summary>
        ///     Tests that exception with different types have different messages
        /// </summary>
        /// <remarks>
        ///     Validates that different component types produce different exception messages.
        /// </remarks>
        [Fact]
        public void ComponentAlreadyExistsException_DifferentTypesDifferentMessages()
        {
            // Act
            ComponentAlreadyExistsException ex1 = new ComponentAlreadyExistsException(typeof(TestComponent));
            ComponentAlreadyExistsException ex2 = new ComponentAlreadyExistsException(typeof(Position));

            // Assert
            Assert.NotEqual(ex1.Message, ex2.Message);
            Assert.Contains("TestComponent", ex1.Message);
            Assert.Contains("Position", ex2.Message);
        }
    }
}

