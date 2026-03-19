using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Contacts;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    /// The post solve delegate test class
    /// </summary>
    public class PostSolveDelegateTest
    {
        /// <summary>
        /// Tests that delegate should be invokable
        /// </summary>
        [Fact]
        public void Delegate_ShouldBeInvokable()
        {
            bool invoked = false;
            Contact capturedContact = null;
            ContactVelocityConstraint capturedImpulse = null;
            PostSolveDelegate callback = (contact, impulse) =>
            {
                invoked = true;
                capturedContact = contact;
                capturedImpulse = impulse;
            };

            ContactVelocityConstraint impulseArg = new ContactVelocityConstraint();
            callback(null, impulseArg);

            Assert.True(invoked);
            Assert.Null(capturedContact);
            Assert.Equal(impulseArg, capturedImpulse);
        }
    }
}

