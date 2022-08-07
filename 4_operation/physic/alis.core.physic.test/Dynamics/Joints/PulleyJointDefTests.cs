using Alis.Core.Physic.Dynamics.Joints;
using Moq;
using System;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    /// <summary>
    /// The pulley joint def tests class
    /// </summary>
    public class PulleyJointDefTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="PulleyJointDefTests"/> class
        /// </summary>
        public PulleyJointDefTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the pulley joint def
        /// </summary>
        /// <returns>The pulley joint def</returns>
        private PulleyJointDef CreatePulleyJointDef()
        {
            return new PulleyJointDef();
        }

        /// <summary>
        /// Tests that initialize state under test expected behavior
        /// </summary>
        [Fact]
        public void Initialize_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var pulleyJointDef = this.CreatePulleyJointDef();
            Body body1 = null;
            Body body2 = null;
            Vector2 groundAnchor1 = default(global::Alis.Aspect.Math.Vector2);
            Vector2 groundAnchor2 = default(global::Alis.Aspect.Math.Vector2);
            Vector2 anchor1 = default(global::Alis.Aspect.Math.Vector2);
            Vector2 anchor2 = default(global::Alis.Aspect.Math.Vector2);
            float ratio = 0;

            // Act
            pulleyJointDef.Initialize(
                body1,
                body2,
                groundAnchor1,
                groundAnchor2,
                anchor1,
                anchor2,
                ratio);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
