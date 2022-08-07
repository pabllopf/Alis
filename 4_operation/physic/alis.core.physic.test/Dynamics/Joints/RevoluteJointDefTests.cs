using Alis.Core.Physic.Dynamics.Joints;
using Moq;
using System;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    /// <summary>
    /// The revolute joint def tests class
    /// </summary>
    public class RevoluteJointDefTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="RevoluteJointDefTests"/> class
        /// </summary>
        public RevoluteJointDefTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the revolute joint def
        /// </summary>
        /// <returns>The revolute joint def</returns>
        private RevoluteJointDef CreateRevoluteJointDef()
        {
            return new RevoluteJointDef();
        }

        /// <summary>
        /// Tests that initialize state under test expected behavior
        /// </summary>
        [Fact]
        public void Initialize_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var revoluteJointDef = CreateRevoluteJointDef();
            Body body1 = null;
            Body body2 = null;
            Vector2 anchor = default(global::Alis.Aspect.Math.Vector2);

            // Act
            revoluteJointDef.Initialize(
                body1,
                body2,
                anchor);

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }
    }
}
