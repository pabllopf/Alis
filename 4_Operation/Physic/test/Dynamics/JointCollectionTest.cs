using System;
using System.Collections.Generic;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Joints;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    /// The joint collection test class
    /// </summary>
    public class JointCollectionTest
    {
        /// <summary>
        /// Tests that collection should expose joints added through world
        /// </summary>
        [Fact]
        public void Collection_ShouldExposeJointsAddedThroughWorld()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(0.5f, 1.0f, new Vector2F(-1.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(0.5f, 1.0f, new Vector2F(1.0f, 0.0f), BodyType.Dynamic);

            Joint joint = JointFactory.CreateDistanceJoint(world, bodyA, bodyB);

            Assert.Single(world.JointList);
            Assert.True(world.JointList.Contains(joint));
        }

        /// <summary>
        /// Tests that collection should be read only from i collection interface
        /// </summary>
        [Fact]
        public void Collection_ShouldBeReadOnlyFromICollectionInterface()
        {
            JointCollection collection = new WorldPhysic(Vector2F.Zero).JointList;

            Assert.True(collection.IsReadOnly);
            Assert.Throws<NotSupportedException>(() => ((ICollection<Joint>) collection).Clear());
        }

        /// <summary>
        /// Tests that collection enumerator should iterate all joints
        /// </summary>
        [Fact]
        public void Collection_Enumerator_ShouldIterateAllJoints()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(0.5f, 1.0f, new Vector2F(-2.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(0.5f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyC = world.CreateCircle(0.5f, 1.0f, new Vector2F(2.0f, 0.0f), BodyType.Dynamic);
            JointFactory.CreateDistanceJoint(world, bodyA, bodyB);
            JointFactory.CreateDistanceJoint(world, bodyB, bodyC);

            int count = 0;
            foreach (Joint _ in world.JointList)
            {
                count++;
            }

            Assert.Equal(2, count);
        }
    }
}

