using Alis.Core.Physic.Dynamics.Contacts;
using Moq;
using System;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Contacts
{
    /// <summary>
    /// The contact edge tests class
    /// </summary>
    public class ContactEdgeTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="ContactEdgeTests"/> class
        /// </summary>
        public ContactEdgeTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the contact edge
        /// </summary>
        /// <returns>The contact edge</returns>
        private ContactEdge CreateContactEdge()
        {
            return new ContactEdge();
        }

        /// <summary>
        /// Tests that test method 1
        /// </summary>
        [Fact]
        public void TestMethod1()
        {
            // Arrange
            var contactEdge = this.CreateContactEdge();

            // Act


            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
