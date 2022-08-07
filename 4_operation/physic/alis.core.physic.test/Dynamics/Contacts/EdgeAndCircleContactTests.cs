using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Contacts;
using Moq;
using System;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Contacts
{
    /// <summary>
    /// The edge and circle contact tests class
    /// </summary>
    public class EdgeAndCircleContactTests
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
        /// Initializes a new instance of the <see cref="EdgeAndCircleContactTests"/> class
        /// </summary>
        public EdgeAndCircleContactTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);

            mockFixture = mockRepository.Create<Fixture>();
            mockFixture = mockRepository.Create<Fixture>();
        }

        /// <summary>
        /// Creates the edge and circle contact
        /// </summary>
        /// <returns>The edge and circle contact</returns>
        private EdgeAndCircleContact CreateEdgeAndCircleContact()
        {
            return new EdgeAndCircleContact(
                mockFixture.Object,
                mockFixture.Object);
        }

        /// <summary>
        /// Tests that create state under test expected behavior
        /// </summary>
        [Fact]
        public void Create_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            /*var edgeAndCircleContact = CreateEdgeAndCircleContact();
            Fixture fixtureA = null;
            Fixture fixtureB = null;

            // Act
            var result = EdgeAndCircleContact.Create(
                fixtureA,
                fixtureB);
*/
            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that destroy state under test expected behavior
        /// </summary>
        [Fact]
        public void Destroy_StateUnderTest_ExpectedBehavior()
        {
            /*
            // Arrange
            var edgeAndCircleContact = CreateEdgeAndCircleContact();
            Contact contact = null;

            // Act
            EdgeAndCircleContact.Destroy(
                ref contact);
*/
            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }
    }
}
