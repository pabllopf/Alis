using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Contacts
{
    /// <summary>
    /// The contact test class
    /// </summary>
    public class ContactTest
    {
        /// <summary>
        /// Tests that contact type should be accessible
        /// </summary>
        [Fact]
        public void Contact_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Dynamics.Contacts.Contact));
        }
    }
}

