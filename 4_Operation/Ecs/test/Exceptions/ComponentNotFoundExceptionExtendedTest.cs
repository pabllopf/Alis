// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ComponentNotFoundExceptionExtendedTest.cs
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
    ///     The component not found exception extended test class
    /// </summary>
    /// <remarks>
    ///     Tests the <see cref="ComponentNotFoundException"/> exception class
    ///     with more comprehensive test cases.
    /// </remarks>
    public class ComponentNotFoundExceptionExtendedTest
    {
        /// <summary>
        ///     Tests that exception can be created with type
        /// </summary>
        /// <remarks>
        ///     Verifies that ComponentNotFoundException can be instantiated with a type.
        /// </remarks>
        [Fact]
        public void ComponentNotFoundException_CanBeCreatedWithType()
        {
            // Act
            ComponentNotFoundException ex = new ComponentNotFoundException(typeof(TestComponent));

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
        public void ComponentNotFoundException_MessageContainsTypeName()
        {
            // Arrange
            Type testType = typeof(Health);

            // Act
            ComponentNotFoundException ex = new ComponentNotFoundException(testType);

            // Assert
            Assert.Contains("Health", ex.Message);
            Assert.Contains("not found", ex.Message);
        }

        /// <summary>
        ///     Tests that exception can be created with message
        /// </summary>
        /// <remarks>
        ///     Tests creating the exception with a custom message.
        /// </remarks>
        [Fact]
        public void ComponentNotFoundException_CanBeCreatedWithMessage()
        {
            // Arrange
            string customMessage = "Component lookup failed";

            // Act
            ComponentNotFoundException ex = new ComponentNotFoundException(customMessage);

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
        public void ComponentNotFoundException_IsCatchableAsException()
        {
            // Act & Assert
            Exception thrownException = null;
            try
            {
                throw new ComponentNotFoundException(typeof(Position));
            }
            catch (Exception ex)
            {
                thrownException = ex;
            }

            Assert.NotNull(thrownException);
            Assert.IsAssignableFrom<ComponentNotFoundException>(thrownException);
        }

        /// <summary>
        ///     Tests that exception with different types have different messages
        /// </summary>
        /// <remarks>
        ///     Validates that different component types produce different exception messages.
        /// </remarks>
        [Fact]
        public void ComponentNotFoundException_DifferentTypesDifferentMessages()
        {
            // Act
            ComponentNotFoundException ex1 = new ComponentNotFoundException(typeof(TestComponent));
            ComponentNotFoundException ex2 = new ComponentNotFoundException(typeof(Position));

            // Assert
            Assert.NotEqual(ex1.Message, ex2.Message);
            Assert.Contains("TestComponent", ex1.Message);
            Assert.Contains("Position", ex2.Message);
        }

        /// <summary>
        ///     Tests that exception with full type name
        /// </summary>
        /// <remarks>
        ///     Validates that the full type name is included in the message.
        /// </remarks>
        [Fact]
        public void ComponentNotFoundException_ContainsFullTypeName()
        {
            // Act
            ComponentNotFoundException ex = new ComponentNotFoundException(typeof(Position));

            // Assert
            Assert.Contains("Alis.Core.Ecs.Test.Models.Position", ex.Message);
        }
    }
}

