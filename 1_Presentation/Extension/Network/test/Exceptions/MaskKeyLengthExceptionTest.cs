

using Alis.Extension.Network.Exceptions;
using Xunit;

namespace Alis.Extension.Network.Test.Exceptions
{
    /// <summary>
    ///     The mask key length exception test class
    /// </summary>
    public class MaskKeyLengthExceptionTest
    {
        /// <summary>
        ///     Tests that mask key length exception default constructor
        /// </summary>
        [Fact]
        public void MaskKeyLengthException_DefaultConstructor()
        {
            MaskKeyLengthException exception = new MaskKeyLengthException("Test message");
            Assert.NotNull(exception);
            Assert.Equal("Test message", exception.Message);
        }
    }
}