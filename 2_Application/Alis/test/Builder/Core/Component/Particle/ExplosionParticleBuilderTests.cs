using Alis.Builder.Core.Component.Particle;
using Moq;
using System;
using Xunit;

namespace Alis.Test.Builder.Core.Component.Particle
{
    /// <summary>
    /// The explosion particle builder tests class
    /// </summary>
    public class ExplosionParticleBuilderTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="ExplosionParticleBuilderTests"/> class
        /// </summary>
        public ExplosionParticleBuilderTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the explosion particle builder
        /// </summary>
        /// <returns>The explosion particle builder</returns>
        private ExplosionParticleBuilder CreateExplosionParticleBuilder()
        {
            return new ExplosionParticleBuilder();
        }

        /// <summary>
        /// Tests that build state under test expected behavior
        /// </summary>
        [Fact]
        public void Build_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var explosionParticleBuilder = this.CreateExplosionParticleBuilder();

            // Act
            var result = explosionParticleBuilder.Build();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
