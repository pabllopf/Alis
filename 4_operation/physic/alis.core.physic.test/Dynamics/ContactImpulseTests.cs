using Alis.Core.Physic.Dynamics;
using Moq;
using System;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    /// The contact impulse tests class
    /// </summary>
    public class ContactImpulseTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="ContactImpulseTests"/> class
        /// </summary>
        public ContactImpulseTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the contact impulse
        /// </summary>
        /// <returns>The contact impulse</returns>
        private ContactImpulse CreateContactImpulse()
        {
            return new ContactImpulse();
        }

        /// <summary>
        /// Tests that test method 1
        /// </summary>
        [Fact]
        public void TestMethod1()
        {
            // Arrange
            var contactImpulse = this.CreateContactImpulse();

            // Act


            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
