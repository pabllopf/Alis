using System.Collections.Generic;
using Alis.Core.Ecs.Test.Helpers;
using Alis;
using Alis.Core;
using Alis.Core.Ecs.Kernel;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    /// The command buffer tests class
    /// </summary>
    public class CommandBufferTests
    {
        /// <summary>
        /// Tests that create creates gameObject on playback
        /// </summary>
        [Fact]
        public void Create_CreatesEntityOnPlayback()
        {
            using Scene scene = new Scene();
            CommandBuffer commandBuffer = new CommandBuffer(scene);

            GameObject e = commandBuffer.Entity()
                .With<Struct1>(default)
                .With<Struct2>(default)
                .With<Struct3>(default)
                .End();

            Assert.Empty(e.ComponentTypes);

            commandBuffer.Playback();

            Assert.Contains(Component<Struct1>.Id, e.ComponentTypes);
            Assert.Contains(Component<Struct2>.Id, e.ComponentTypes);
            Assert.Contains(Component<Struct3>.Id, e.ComponentTypes);
        }

        /// <summary>
        /// Tests that has buffer item returns true if buffer item exists
        /// </summary>
        [Fact]
        public void HasBufferItem_ReturnsTrueIfBufferItemExists()
        {
            using Scene scene = new Scene();
            CommandBuffer commandBuffer = new CommandBuffer(scene);

            Assert.False(commandBuffer.HasBufferItems);

            commandBuffer.Entity()
                .With<Struct1>(default)
                .With<Struct2>(default)
                .With<Struct3>(default)
                .End();

            Assert.True(commandBuffer.HasBufferItems);
        }

        /// <summary>
        /// Tests that clear clears buffer items
        /// </summary>
        [Fact]
        public void Clear_ClearsBufferItems()
        {
            using Scene scene = new Scene();
            CommandBuffer commandBuffer = new CommandBuffer(scene);

            var e = commandBuffer.Entity()
                .With<Struct1>(default)
                .With<Struct2>(default)
                .With<Struct3>(default)
                .End();

            commandBuffer.AddComponent(e, new Class1());

            commandBuffer.Clear();

            Assert.False(commandBuffer.HasBufferItems);
            Assert.Equal(0, scene.EntityCount);
        }

        /// <summary>
        /// Tests that add component generic adds component on playback
        /// </summary>
        [Fact]
        public void AddComponentGeneric_AddsComponentOnPlayback()
        {
            using Scene scene = new Scene();
            CommandBuffer commandBuffer = new CommandBuffer(scene);

            var e1 = commandBuffer.Entity()
                .End();

            var e2 = scene.Create();

            commandBuffer.AddComponent(e1, new Class1());
            commandBuffer.AddComponent(e2, new Class2());

            commandBuffer.Playback();

            Assert.Contains(Component<Class1>.Id, e1.ComponentTypes);
            Assert.Contains(Component<Class2>.Id, e2.ComponentTypes);

            Assert.NotNull(e1.Get<Class1>());
            Assert.NotNull(e2.Get<Class2>());
        }

       /// <summary>
       /// Tests that add component as adds component on playback
       /// </summary>
       [Fact]
       public void AddComponentAs_AddsComponentOnPlayback()
       {
           using Scene scene = new Scene();
           CommandBuffer commandBuffer = new CommandBuffer(scene);
       
           var e1 = commandBuffer.Entity()
               .End();
       
           Component.RegisterComponent<ChildClass>();
       
           commandBuffer.AddComponent(e1, Component<BaseClass>.Id, new ChildClass());
       
           commandBuffer.Playback();
       
           Assert.Contains(Component<BaseClass>.Id, e1.ComponentTypes);
           Assert.DoesNotContain(Component<ChildClass>.Id, e1.ComponentTypes);
       
           Assert.NotNull(e1.Get<BaseClass>());
       }

        /// <summary>
        /// Tests that delete gameObject deletes gameObject
        /// </summary>
        [Fact]
        public void DeleteEntity_DeletesEntity()
        {
            using Scene scene = new Scene();
            List<GameObject> entities = new();
            for (int i = 0; i < 100; i++)
                entities.Add(scene.Create(new Struct1(), new Struct2(), new Class1()));

            CommandBuffer commandBuffer = new CommandBuffer(scene);

            foreach (var item in entities)
            {
                commandBuffer.DeleteEntity(item);
            }

            commandBuffer.Playback();
        }

        /// <summary>
        /// Tests that remove component generic remove component on playback
        /// </summary>
        [Fact]
        public void RemoveComponentGeneric_RemoveComponentOnPlayback()
        {
            using Scene scene = new Scene();
            CommandBuffer commandBuffer = new CommandBuffer(scene);

            var e1 = commandBuffer.Entity()
                .With<Class1>(new())
                .End();

            var e2 = scene.Create(new Class2());

            commandBuffer.RemoveComponent<Class1>(e1);
            commandBuffer.RemoveComponent<Class2>(e2);

            commandBuffer.Playback();

            Assert.DoesNotContain(Component<Class1>.Id, e1.ComponentTypes);
            Assert.DoesNotContain(Component<Class2>.Id, e2.ComponentTypes);
        }

        /// <summary>
        /// Tests that remove component as remove component on playback
        /// </summary>
        [Fact]
        public void RemoveComponentAs_RemoveComponentOnPlayback()
        {
            using Scene scene = new Scene();
            CommandBuffer commandBuffer = new CommandBuffer(scene);

            var e1 = commandBuffer.Entity()
                .With<BaseClass>(new ChildClass())
                .End();

            commandBuffer.RemoveComponent(e1, Component<BaseClass>.Id);

            commandBuffer.Playback();

            Assert.DoesNotContain(Component<BaseClass>.Id, e1.ComponentTypes);
        }
    }
}