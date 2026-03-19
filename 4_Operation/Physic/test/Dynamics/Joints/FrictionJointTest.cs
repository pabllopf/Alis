using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    /// <summary>
    /// The friction joint test class
    /// </summary>
    public class FrictionJointTest
    {
        /// <summary>
        /// Tests that friction joint type should be accessible
        /// </summary>
        [Fact]
        public void FrictionJoint_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Dynamics.Joints.FrictionJoint));
        }
    }
}

