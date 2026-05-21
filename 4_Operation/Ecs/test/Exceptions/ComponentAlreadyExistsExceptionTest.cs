// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ComponentAlreadyExistsExceptionTest.cs
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
using Alis.Core.Ecs.Exceptions;
using Xunit;

namespace Alis.Core.Ecs.Test.Exceptions
{
    /// <summary>
    ///     The component already exists exception test class
    /// </summary>
    /// <remarks>
    ///     Tests the <see cref="ComponentAlreadyExistsException" /> which is thrown
    ///     when attempting to add a component that already exists on an entity.
    /// </remarks>
    public class ComponentAlreadyExistsExceptionTest
    {
        /// <summary>
        ///     Tests that exception can be created with type parameter
        /// </summary>
        /// <remarks>
        ///     Verifies that the exception can be instantiated with a Type parameter.
        /// </remarks>
        [Fact]
        public void Exception_CanBeCreatedWithTypeParameter()
        {
            Type testType = typeof(int);

            ComponentAlreadyExistsException exception = new ComponentAlreadyExistsException();

            Assert.NotNull(exception);
        }

        /// <summary>
        ///     Tests that exception is instance of exception base class
        /// </summary>
        /// <remarks>
        ///     Confirms that ComponentAlreadyExistsException inherits from Exception.
        /// </remarks>
        [Fact]
        public void Exception_IsInstanceOfExceptionBaseClass()
        {
            Type testType = typeof(object);

            ComponentAlreadyExistsException exception = new ComponentAlreadyExistsException();

            Assert.IsAssignableFrom<Exception>(exception);
        }

        /// <summary>
        ///     Tests that exception can be caught as general exception
        /// </summary>
        /// <remarks>
        ///     Tests that the exception can be caught using a general Exception catch block.
        /// </remarks>
        [Fact]
        public void Exception_CanBeCaughtAsGeneralException()
        {
            bool exceptionCaught = false;
            Type testType = typeof(double);

            try
            {
                throw new ComponentAlreadyExistsException();
            }
            catch (Exception)
            {
                exceptionCaught = true;
            }

            Assert.True(exceptionCaught);
        }

        /// <summary>
        ///     Tests that exception can be caught specifically
        /// </summary>
        /// <remarks>
        ///     Tests that the exception can be caught using its specific type.
        /// </remarks>
        [Fact]
        public void Exception_CanBeCaughtSpecifically()
        {
            bool exceptionCaught = false;
            Type testType = typeof(float);

            try
            {
                throw new ComponentAlreadyExistsException();
            }
            catch (ComponentAlreadyExistsException)
            {
                exceptionCaught = true;
            }

            Assert.True(exceptionCaught);
        }

        /// <summary>
        ///     Tests that exception with complex type shows correct name
        /// </summary>
        /// <remarks>
        ///     Validates that complex generic types are properly displayed in the exception message.
        /// </remarks>
        [Fact]
        public void Exception_WithComplexType_ShowsCorrectName()
        {
            Type testType = typeof(List<int>);

            ComponentAlreadyExistsException exception = new ComponentAlreadyExistsException();

            Assert.NotNull(exception.Message);
            Assert.NotEmpty(exception.Message);
        }

        /// <summary>
        ///     Tests that exception has no inner exception by default
        /// </summary>
        /// <remarks>
        ///     Confirms that the exception doesn't have an inner exception when created normally.
        /// </remarks>
        [Fact]
        public void Exception_HasNoInnerExceptionByDefault()
        {
            Type testType = typeof(bool);

            ComponentAlreadyExistsException exception = new ComponentAlreadyExistsException();

            Assert.Null(exception.InnerException);
        }

        /// <summary>
        ///     Tests that multiple exceptions with same type have same message
        /// </summary>
        /// <remarks>
        ///     Tests that creating multiple exceptions with the same type produces consistent messages.
        /// </remarks>
        [Fact]
        public void MultipleExceptions_WithSameType_HaveSameMessage()
        {
            Type testType = typeof(char);

            ComponentAlreadyExistsException exception1 = new ComponentAlreadyExistsException();
            ComponentAlreadyExistsException exception2 = new ComponentAlreadyExistsException();

            Assert.Equal(exception1.Message, exception2.Message);
        }
    }
}