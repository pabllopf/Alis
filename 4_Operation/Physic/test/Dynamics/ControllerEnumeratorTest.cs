using System;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Controllers;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    /// The controller enumerator test class
    /// </summary>
    public class ControllerEnumeratorTest
    {
        /// <summary>
        /// Tests that move next and current should enumerate controllers
        /// </summary>
        [Fact]
        public void MoveNext_AndCurrent_ShouldEnumerateControllers()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            GravityController first = new GravityController(1.0f);
            GravityController second = new GravityController(2.0f);
            world.Add(first);
            world.Add(second);

            ControllerEnumerator enumerator = world.ControllerList.GetEnumerator();

            Assert.True(enumerator.MoveNext());
            Assert.Equal(first, enumerator.Current);
            Assert.True(enumerator.MoveNext());
            Assert.Equal(second, enumerator.Current);
            Assert.False(enumerator.MoveNext());
        }

        /// <summary>
        /// Tests that move next should throw when collection was modified
        /// </summary>
        [Fact]
        public void MoveNext_ShouldThrow_WhenCollectionWasModified()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.Add(new GravityController(1.0f));
            ControllerEnumerator enumerator = world.ControllerList.GetEnumerator();

            world.Add(new GravityController(2.0f));

            Assert.Throws<InvalidOperationException>(() => enumerator.MoveNext());
        }
    }
}

