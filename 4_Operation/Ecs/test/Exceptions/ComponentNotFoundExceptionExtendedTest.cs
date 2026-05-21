

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
    ///     Tests the <see cref="ComponentNotFoundException" /> exception class
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
            ComponentNotFoundException ex = new ComponentNotFoundException(typeof(TestComponent));

            Assert.NotNull(ex);
            Assert.IsAssignableFrom<Exception>(ex);
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
            string customMessage = "Component lookup failed";

            ComponentNotFoundException ex = new ComponentNotFoundException(customMessage);

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
    }
}