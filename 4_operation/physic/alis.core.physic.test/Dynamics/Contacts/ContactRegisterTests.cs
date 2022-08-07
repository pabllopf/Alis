using Alis.Core.Physic.Dynamics.Contacts;
using Moq;
using System;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Contacts
{
    /// <summary>
    /// The contact register tests class
    /// </summary>
    public class ContactRegisterTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="ContactRegisterTests"/> class
        /// </summary>
        public ContactRegisterTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the contact register
        /// </summary>
        /// <returns>The contact register</returns>
        private ContactRegister CreateContactRegister()
        {
            return new ContactRegister();
        }

        /// <summary>
        /// Tests that test method 1
        /// </summary>
        [Fact]
        public void TestMethod1()
        {
            // Arrange
            var contactRegister = CreateContactRegister();

            // Act


            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }
    }
}
