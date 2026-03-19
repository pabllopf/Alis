using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Contacts
{
    /// <summary>
    /// The contact position constraint test class
    /// </summary>
    public class ContactPositionConstraintTest
    {
        /// <summary>
        /// Tests that contact position constraint type should be accessible
        /// </summary>
        [Fact]
        public void ContactPositionConstraint_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Dynamics.Contacts.ContactPositionConstraint));
        }
    }
}

