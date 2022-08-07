using Alis.Core.Physic.Dynamics;
using Moq;
using System;
using Alis.Core.Physic.Dynamics.Contacts;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    /// The contact manager tests class
    /// </summary>
    public class ContactManagerTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="ContactManagerTests"/> class
        /// </summary>
        public ContactManagerTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the manager
        /// </summary>
        /// <returns>The contact manager</returns>
        private ContactManager CreateManager()
        {
            return new ContactManager();
        }

        /// <summary>
        /// Tests that pair added state under test expected behavior
        /// </summary>
        [Fact]
        public void PairAdded_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var manager = CreateManager();
            object proxyUserDataA = null;
            object proxyUserDataB = null;

            // Act
            var result = manager.PairAdded(
                proxyUserDataA,
                proxyUserDataB);

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that pair removed state under test expected behavior
        /// </summary>
        [Fact]
        public void PairRemoved_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var manager = CreateManager();
            object proxyUserData1 = null;
            object proxyUserData2 = null;
            object pairUserData = null;

            // Act
            manager.PairRemoved(
                proxyUserData1,
                proxyUserData2,
                pairUserData);

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that destroy state under test expected behavior
        /// </summary>
        [Fact]
        public void Destroy_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var manager = CreateManager();
            Contact c = null;

            // Act
            manager.Destroy(
                c);

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that collide state under test expected behavior
        /// </summary>
        [Fact]
        public void Collide_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var manager = CreateManager();

            // Act
            manager.Collide();

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }
    }
}
