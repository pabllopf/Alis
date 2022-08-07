using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Contacts;
using Moq;
using System;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Contacts
{
    /// <summary>
    /// The circle contact tests class
    /// </summary>
    public class CircleContactTests
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
        /// Initializes a new instance of the <see cref="CircleContactTests"/> class
        /// </summary>
        public CircleContactTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockFixture = mockRepository.Create<Fixture>();
            this.mockFixture = mockRepository.Create<Fixture>();
        }

        /// <summary>
        /// Creates the circle contact
        /// </summary>
        /// <returns>The circle contact</returns>
        private CircleContact CreateCircleContact()
        {
            return new CircleContact(
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
            var circleContact = CreateCircleContact();
            Fixture fixtureA = null;
            Fixture fixtureB = null;

            // Act
            var result = circleContact.Create(
                fixtureA,
                fixtureB);

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
            var circleContact = CreateCircleContact();
            Contact contact = null;

            // Act
            circleContact.Destroy(
                ref contact);

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }
    }
}
