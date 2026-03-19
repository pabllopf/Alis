using System;
using System.Collections.Generic;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Controllers;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    /// The controller collection test class
    /// </summary>
    public class ControllerCollectionTest
    {
        /// <summary>
        /// Tests that collection should expose controllers added through world
        /// </summary>
        [Fact]
        public void Collection_ShouldExposeControllersAddedThroughWorld()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            GravityController controller = new GravityController(1.0f);

            world.Add(controller);

            Assert.Single(world.ControllerList);
            Assert.True(world.ControllerList.Contains(controller));
        }

        /// <summary>
        /// Tests that collection should be read only from i collection interface
        /// </summary>
        [Fact]
        public void Collection_ShouldBeReadOnlyFromICollectionInterface()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            ControllerCollection collection = world.ControllerList;

            Assert.True(collection.IsReadOnly);
            Assert.Throws<NotSupportedException>(() => ((ICollection<Controller>) collection).Add(new GravityController(1.0f)));
            Assert.Throws<NotSupportedException>(() => ((ICollection<Controller>) collection).Clear());
        }

        /// <summary>
        /// Tests that collection enumerator should iterate all controllers
        /// </summary>
        [Fact]
        public void Collection_Enumerator_ShouldIterateAllControllers()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.Add(new GravityController(1.0f));
            world.Add(new VelocityLimitController());

            int count = 0;
            foreach (Controller _ in world.ControllerList)
            {
                count++;
            }

            Assert.Equal(2, count);
        }
    }
}

