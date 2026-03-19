using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    /// The on collision event handler test class
    /// </summary>
    public class OnCollisionEventHandlerTest
    {
        /// <summary>
        /// Tests that delegate should be invokable and return value
        /// </summary>
        [Fact]
        public void Delegate_ShouldBeInvokableAndReturnValue()
        {
            bool invoked = false;
            OnCollisionEventHandler callback = (sender, other, contact) =>
            {
                invoked = true;
                return (sender == null) && (other == null) && (contact == null);
            };

            bool result = callback(null, null, null);

            Assert.True(invoked);
            Assert.True(result);
        }
    }
}

