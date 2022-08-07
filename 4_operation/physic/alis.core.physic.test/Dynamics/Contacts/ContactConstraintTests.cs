using Alis.Core.Physic.Dynamics.Contacts;
using Moq;
using System;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Contacts
{
    /// <summary>
    /// The contact constraint tests class
    /// </summary>
    public class ContactConstraintTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="ContactConstraintTests"/> class
        /// </summary>
        public ContactConstraintTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the contact constraint
        /// </summary>
        /// <returns>The contact constraint</returns>
        private ContactConstraint CreateContactConstraint()
        {
            return new ContactConstraint();
        }

        /// <summary>
        /// Tests that test method 1
        /// </summary>
        [Fact]
        public void TestMethod1()
        {
            // Arrange
            var contactConstraint = this.CreateContactConstraint();

            // Act


            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
