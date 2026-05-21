

using System;
using Alis.Core.Physic.Common.Decomposition.CDT.Delaunay.Sweep;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition.CDT.Delaunay.Sweep
{
    /// <summary>
    ///     The point on edge exception test class
    /// </summary>
    public class PointOnEdgeExceptionTest
    {
        /// <summary>
        ///     Tests that constructor should initialize with message
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeWithMessage()
        {
            string message = "Point is on edge";

            PointOnEdgeException exception = new PointOnEdgeException(message);

            Assert.Equal(message, exception.Message);
        }

        /// <summary>
        ///     Tests that point on edge exception should inherit from not implemented exception
        /// </summary>
        [Fact]
        public void PointOnEdgeException_ShouldInheritFromNotImplementedException()
        {
            PointOnEdgeException exception = new PointOnEdgeException("test");

            Assert.IsAssignableFrom<NotImplementedException>(exception);
        }

        /// <summary>
        ///     Tests that exception should be catchable as not implemented exception
        /// </summary>
        [Fact]
        public void Exception_ShouldBeCatchableAsNotImplementedException()
        {
            bool caught = false;

            try
            {
                throw new PointOnEdgeException("Test");
            }
            catch (NotImplementedException)
            {
                caught = true;
            }

            Assert.True(caught);
        }

        /// <summary>
        ///     Tests that exception should preserve message
        /// </summary>
        [Fact]
        public void Exception_ShouldPreserveMessage()
        {
            string expectedMessage = "Custom error message";

            try
            {
                throw new PointOnEdgeException(expectedMessage);
            }
            catch (PointOnEdgeException ex)
            {
                Assert.Equal(expectedMessage, ex.Message);
            }
        }

        /// <summary>
        ///     Tests that exception should handle empty message
        /// </summary>
        [Fact]
        public void Exception_ShouldHandleEmptyMessage()
        {
            PointOnEdgeException exception = new PointOnEdgeException(string.Empty);

            Assert.Equal(string.Empty, exception.Message);
        }


        /// <summary>
        ///     Tests that exception should be catchable in generic exception handler
        /// </summary>
        [Fact]
        public void Exception_ShouldBeCatchableInGenericExceptionHandler()
        {
            bool caught = false;

            try
            {
                throw new PointOnEdgeException("Test");
            }
            catch (Exception)
            {
                caught = true;
            }

            Assert.True(caught);
        }

        /// <summary>
        ///     Tests that exception should support different messages
        /// </summary>
        [Fact]
        public void Exception_ShouldSupportDifferentMessages()
        {
            PointOnEdgeException ex1 = new PointOnEdgeException("Message 1");
            PointOnEdgeException ex2 = new PointOnEdgeException("Message 2");

            Assert.NotEqual(ex1.Message, ex2.Message);
        }

        /// <summary>
        ///     Tests that exception should have stack trace when thrown
        /// </summary>
        [Fact]
        public void Exception_ShouldHaveStackTraceWhenThrown()
        {
            try
            {
                throw new PointOnEdgeException("Test");
            }
            catch (PointOnEdgeException ex)
            {
                Assert.NotNull(ex.StackTrace);
            }
        }
    }
}