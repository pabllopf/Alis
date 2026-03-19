using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Contacts
{
    /// <summary>
    /// The contact solver test class
    /// </summary>
    public class ContactSolverTest
    {
        /// <summary>
        /// Tests that contact solver type should be accessible
        /// </summary>
        [Fact]
        public void ContactSolver_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Dynamics.Contacts.ContactSolver));
        }
    }
}

