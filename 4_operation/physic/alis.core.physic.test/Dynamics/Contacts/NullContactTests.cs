using Alis.Core.Physic.Dynamics.Contacts;
using Moq;
using System;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Contacts
{
    /// <summary>
    /// The null contact tests class
    /// </summary>
    public class NullContactTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="NullContactTests"/> class
        /// </summary>
        public NullContactTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the null contact
        /// </summary>
        /// <returns>The null contact</returns>
        private NullContact CreateNullContact()
        {
            return new NullContact();
        }

        /// <summary>
        /// Tests that test method 1
        /// </summary>
        [Fact]
        public void TestMethod1()
        {
            // Arrange
            var nullContact = CreateNullContact();

            // Act


            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }
    }
}
