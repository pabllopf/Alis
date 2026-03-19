using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Contacts
{
    public class ContactTest
    {
        [Fact]
        public void Contact_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Dynamics.Contacts.Contact));
        }
    }
}

