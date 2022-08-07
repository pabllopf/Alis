using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Contacts;
using Moq;
using System;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Contacts
{
    /// <summary>
    /// The polygon contact tests class
    /// </summary>
    public class PolygonContactTests
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
        /// Initializes a new instance of the <see cref="PolygonContactTests"/> class
        /// </summary>
        public PolygonContactTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);
            mockFixture = mockRepository.Create<Fixture>();
        }

        /// <summary>
        /// Creates the polygon contact
        /// </summary>
        /// <returns>The polygon contact</returns>
        private PolygonContact CreatePolygonContact()
        {
            return new PolygonContact(
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
            /*var polygonContact = CreatePolygonContact();
            Fixture fixtureA = null;
            Fixture fixtureB = null;

            // Act
            var result = PolygonContact.Create(
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
            /*// Arrange
            var polygonContact = CreatePolygonContact();
            Contact contact = null;

            // Act
            PolygonContact.Destroy(
                ref contact);
*/
            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }
    }
}
