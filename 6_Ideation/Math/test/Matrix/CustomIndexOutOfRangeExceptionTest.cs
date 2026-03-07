using Alis.Core.Aspect.Math.Matrix;
using Xunit;

namespace Alis.Core.Aspect.Math.Test.Matrix
{
    /// <summary>
    /// The custom index out of range exception test class
    /// </summary>
    public class CustomIndexOutOfRangeExceptionTest
    {
        /// <summary>
        /// Tests that default constructor creates exception
        /// </summary>
        [Fact]
        public void DefaultConstructor_CreatesException()
        {
            CustomIndexOutOfRangeException exception = new CustomIndexOutOfRangeException();

            Assert.IsType<CustomIndexOutOfRangeException>(exception);
        }

        /// <summary>
        /// Tests that message constructor preserves message
        /// </summary>
        [Fact]
        public void MessageConstructor_PreservesMessage()
        {
            const string message = "Invalid matrix index.";

            CustomIndexOutOfRangeException exception = new CustomIndexOutOfRangeException(message);

            Assert.Equal(message, exception.Message);
        }
    }
}

