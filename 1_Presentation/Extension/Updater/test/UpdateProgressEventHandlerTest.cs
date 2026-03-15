using Xunit;
using Alis.Extension.Updater.Events;

namespace Alis.Extension.Updater.Test
{
    /// <summary>
    /// The update progress event handler test class
    /// </summary>
    public class UpdateProgressEventHandlerTest
    {

        /// <summary>
        /// Tests that delegate invokes with expected parameters
        /// </summary>
        [Fact]
        public void Delegate_Invokes_WithExpectedParameters()
        {
            float receivedProgress = 0;
            string receivedMessage = null;

            UpdateProgressEventHandler handler = (progress, message) =>
            {
                receivedProgress = progress;
                receivedMessage = message;
            };

            handler(0.42f, "working");

            Assert.Equal(0.42f, receivedProgress);
            Assert.Equal("working", receivedMessage);
        }
    }
}
