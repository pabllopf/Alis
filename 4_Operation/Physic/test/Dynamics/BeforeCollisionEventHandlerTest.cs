using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    /// The before collision event handler test class
    /// </summary>
    public class BeforeCollisionEventHandlerTest
    {
        /// <summary>
        /// Tests that delegate should return expected value
        /// </summary>
        [Fact]
        public void Delegate_ShouldReturnExpectedValue()
        {
            BeforeCollisionEventHandler callback = (sender, other) => sender == null && other == null;

            bool result = callback(null, null);

            Assert.True(result);
        }
    }
}

