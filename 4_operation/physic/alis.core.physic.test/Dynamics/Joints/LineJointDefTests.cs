using Alis.Core.Physic.Dynamics.Joints;
using Moq;
using System;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    /// <summary>
    /// The line joint def tests class
    /// </summary>
    public class LineJointDefTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="LineJointDefTests"/> class
        /// </summary>
        public LineJointDefTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the line joint def
        /// </summary>
        /// <returns>The line joint def</returns>
        private LineJointDef CreateLineJointDef()
        {
            return new LineJointDef();
        }

        /// <summary>
        /// Tests that initialize state under test expected behavior
        /// </summary>
        [Fact]
        public void Initialize_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var lineJointDef = CreateLineJointDef();
            Body body1 = null;
            Body body2 = null;
            Vector2 anchor = default(global::Alis.Aspect.Math.Vector2);
            Vector2 axis = default(global::Alis.Aspect.Math.Vector2);

            // Act
            lineJointDef.Initialize(
                body1,
                body2,
                anchor,
                axis);

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }
    }
}
