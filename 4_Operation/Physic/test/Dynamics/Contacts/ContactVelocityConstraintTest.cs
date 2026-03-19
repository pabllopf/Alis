using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Contacts
{
    /// <summary>
    /// The contact velocity constraint test class
    /// </summary>
    public class ContactVelocityConstraintTest
    {
        /// <summary>
        /// Tests that contact velocity constraint type should be accessible
        /// </summary>
        [Fact]
        public void ContactVelocityConstraint_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Dynamics.Contacts.ContactVelocityConstraint));
        }
    }
}

