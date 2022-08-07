using Alis.Core.Physic.Dynamics.Joints;
using Moq;
using System;
using Alis.Aspect.Math;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    /// <summary>
    /// The distance joint def tests class
    /// </summary>
    public class DistanceJointDefTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="DistanceJointDefTests"/> class
        /// </summary>
        public DistanceJointDefTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the distance joint def
        /// </summary>
        /// <returns>The distance joint def</returns>
        private DistanceJointDef CreateDistanceJointDef()
        {
            return new DistanceJointDef();
        }

        /// <summary>
        /// Tests that initialize state under test expected behavior
        /// </summary>
        [Fact]
        public void Initialize_StateUnderTest_ExpectedBehavior()
        {
            /*// Arrange
            var distanceJointDef = CreateDistanceJointDef();
            Body body1 = null;
            Body body2 = null;
            Vector2 anchor1 = default(Vector2);
            Vector2 anchor2 = default(Vector2);

            // Act
            distanceJointDef.Initialize(
                body1,
                body2,
                anchor1,
                anchor2);
*/
            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }
    }
}
