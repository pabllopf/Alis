using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Contacts
{
    public class ContactVelocityConstraintTest
    {
        [Fact]
        public void ContactVelocityConstraint_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Dynamics.Contacts.ContactVelocityConstraint));
        }
    }
}

