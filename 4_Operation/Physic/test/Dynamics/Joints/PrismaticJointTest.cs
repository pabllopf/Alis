using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    /// <summary>
    /// The prismatic joint test class
    /// </summary>
    public class PrismaticJointTest
    {
        /// <summary>
        /// Tests that prismatic joint type should be accessible
        /// </summary>
        [Fact]
        public void PrismaticJoint_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Dynamics.Joints.PrismaticJoint));
        }

        /// <summary>
        /// Tests that joint translation follows the configured axis.
        /// </summary>
        [Fact]
        public void PrismaticJoint_JointTranslation_TracksAxisDisplacement()
        {
            Body bodyA = new Body {GetBodyType = BodyType.Dynamic, Position = new Vector2F(0.0f, 0.0f)};
            Body bodyB = new Body {GetBodyType = BodyType.Dynamic, Position = new Vector2F(5.0f, 0.0f)};

            var joint = new global::Alis.Core.Physic.Dynamics.Joints.PrismaticJoint(
                bodyA,
                bodyB,
                new Vector2F(0.0f, 0.0f),
                new Vector2F(1.0f, 0.0f));

            Assert.Equal(5.0f, joint.JointTranslation, 5);
        }

        /// <summary>
        /// Tests that the joint speed matches linear velocity projected onto the axis.
        /// </summary>
        [Fact]
        public void PrismaticJoint_JointSpeed_UsesRelativeAxisVelocity()
        {
            Body bodyA = new Body {GetBodyType = BodyType.Dynamic, Position = new Vector2F(0.0f, 0.0f)};
            Body bodyB = new Body {GetBodyType = BodyType.Dynamic, Position = new Vector2F(2.0f, 0.0f)};

            var joint = new global::Alis.Core.Physic.Dynamics.Joints.PrismaticJoint(
                bodyA,
                bodyB,
                new Vector2F(0.0f, 0.0f),
                new Vector2F(1.0f, 0.0f));

            bodyA.LinearVelocity = new Vector2F(1.0f, 0.0f);
            bodyB.LinearVelocity = new Vector2F(3.0f, 0.0f);

            Assert.Equal(2.0f, joint.JointSpeed, 5);
        }

        /// <summary>
        /// Tests that the axis is normalized and stored in local coordinates.
        /// </summary>
        [Fact]
        public void PrismaticJoint_Axis1_NormalizesLocalAxis()
        {
            Body bodyA = new Body {GetBodyType = BodyType.Dynamic};
            Body bodyB = new Body {GetBodyType = BodyType.Dynamic};

            var joint = new global::Alis.Core.Physic.Dynamics.Joints.PrismaticJoint(
                bodyA,
                bodyB,
                new Vector2F(0.0f, 0.0f),
                new Vector2F(2.0f, 0.0f));

            Assert.Equal(1.0f, joint.LocalXAxis.X, 5);
            Assert.Equal(0.0f, joint.LocalXAxis.Y, 5);
        }
    }
}
