using Alis.Core.Physic.Dynamics.Joints;
using Moq;
using System;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    /// <summary>
    /// The prismatic joint def tests class
    /// </summary>
    public class PrismaticJointDefTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="PrismaticJointDefTests"/> class
        /// </summary>
        public PrismaticJointDefTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the prismatic joint def
        /// </summary>
        /// <returns>The prismatic joint def</returns>
        private PrismaticJointDef CreatePrismaticJointDef()
        {
            return new PrismaticJointDef();
        }

        /// <summary>
        /// Tests that initialize state under test expected behavior
        /// </summary>
        [Fact]
        public void Initialize_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var prismaticJointDef = this.CreatePrismaticJointDef();
            Body body1 = null;
            Body body2 = null;
            Vector2 anchor = default(global::Alis.Aspect.Math.Vector2);
            Vector2 axis = default(global::Alis.Aspect.Math.Vector2);

            // Act
            prismaticJointDef.Initialize(
                body1,
                body2,
                anchor,
                axis);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
