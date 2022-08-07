using Alis.Core.Physic.Dynamics;
using Moq;
using System;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    /// The contact filter tests class
    /// </summary>
    public class ContactFilterTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="ContactFilterTests"/> class
        /// </summary>
        public ContactFilterTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the contact filter
        /// </summary>
        /// <returns>The contact filter</returns>
        private ContactFilter CreateContactFilter()
        {
            return new ContactFilter();
        }

        /// <summary>
        /// Tests that should collide state under test expected behavior
        /// </summary>
        [Fact]
        public void ShouldCollide_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var contactFilter = CreateContactFilter();
            Fixture fixtureA = null;
            Fixture fixtureB = null;

            // Act
            var result = contactFilter.ShouldCollide(
                fixtureA,
                fixtureB);

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that ray collide state under test expected behavior
        /// </summary>
        [Fact]
        public void RayCollide_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var contactFilter = CreateContactFilter();
            object userData = null;
            Fixture fixture = null;

            // Act
            var result = contactFilter.RayCollide(
                userData,
                fixture);

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }
    }
}
