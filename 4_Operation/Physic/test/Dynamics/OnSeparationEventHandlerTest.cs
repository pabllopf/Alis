using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    /// The on separation event handler test class
    /// </summary>
    public class OnSeparationEventHandlerTest
    {
        /// <summary>
        /// Tests that delegate should be invokable
        /// </summary>
        [Fact]
        public void Delegate_ShouldBeInvokable()
        {
            bool invoked = false;
            OnSeparationEventHandler callback = (sender, other, contact) => { invoked = true; };

            callback(null, null, null);

            Assert.True(invoked);
        }
    }
}

