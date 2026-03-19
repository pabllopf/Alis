using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Contacts
{
    public class ContactSolverTest
    {
        [Fact]
        public void ContactSolver_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Dynamics.Contacts.ContactSolver));
        }
    }
}

