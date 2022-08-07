using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Contacts;
using Moq;
using System;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Contacts
{
    /// <summary>
    /// The poly and edge contact tests class
    /// </summary>
    public class PolyAndEdgeContactTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;

        /// <summary>
        /// The mock fixture
        /// </summary>
        private Mock<Fixture> mockFixture;
        /// <summary>
        /// The mock fixture
        /// </summary>
        private Mock<Fixture> mockFixture;

        /// <summary>
        /// Initializes a new instance of the <see cref="PolyAndEdgeContactTests"/> class
        /// </summary>
        public PolyAndEdgeContactTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockFixture = this.mockRepository.Create<Fixture>();
            this.mockFixture = this.mockRepository.Create<Fixture>();
        }

        /// <summary>
        /// Creates the poly and edge contact
        /// </summary>
        /// <returns>The poly and edge contact</returns>
        private PolyAndEdgeContact CreatePolyAndEdgeContact()
        {
            return new PolyAndEdgeContact(
                this.mockFixture.Object,
                this.mockFixture.Object);
        }

        /// <summary>
        /// Tests that create state under test expected behavior
        /// </summary>
        [Fact]
        public void Create_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var polyAndEdgeContact = this.CreatePolyAndEdgeContact();
            Fixture fixtureA = null;
            Fixture fixtureB = null;

            // Act
            var result = polyAndEdgeContact.Create(
                fixtureA,
                fixtureB);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that destroy state under test expected behavior
        /// </summary>
        [Fact]
        public void Destroy_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var polyAndEdgeContact = this.CreatePolyAndEdgeContact();
            Contact contact = null;

            // Act
            polyAndEdgeContact.Destroy(
                ref contact);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
