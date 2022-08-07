using Alis.Core.Physic.Dynamics.Contacts;
using Moq;
using System;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Contacts
{
    /// <summary>
    /// The contact constraint point tests class
    /// </summary>
    public class ContactConstraintPointTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="ContactConstraintPointTests"/> class
        /// </summary>
        public ContactConstraintPointTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the contact constraint point
        /// </summary>
        /// <returns>The contact constraint point</returns>
        private ContactConstraintPoint CreateContactConstraintPoint()
        {
            return new ContactConstraintPoint();
        }

        /// <summary>
        /// Tests that test method 1
        /// </summary>
        [Fact]
        public void TestMethod1()
        {
            // Arrange
            var contactConstraintPoint = CreateContactConstraintPoint();

            // Act


            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }
    }
}
