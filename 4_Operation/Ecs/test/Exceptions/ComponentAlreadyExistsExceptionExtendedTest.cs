

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
    ///     Tests the <see cref="ComponentAlreadyExistsException" /> exception class
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
            ComponentAlreadyExistsException ex = new ComponentAlreadyExistsException();

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
            Type testType = typeof(Position);

            ComponentAlreadyExistsException ex = new ComponentAlreadyExistsException();
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
            string customMessage = "Custom error message";

            ComponentAlreadyExistsException ex = new ComponentAlreadyExistsException(customMessage);

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
            Exception thrownException = null;
            try
            {
                throw new ComponentAlreadyExistsException();
            }
            catch (Exception ex)
            {
                thrownException = ex;
            }

            Assert.NotNull(thrownException);
            Assert.IsAssignableFrom<ComponentAlreadyExistsException>(thrownException);
        }
    }
}