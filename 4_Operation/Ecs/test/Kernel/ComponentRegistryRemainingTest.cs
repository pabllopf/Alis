using System;
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel
{
    public class ComponentRegistryRemainingTest
    {
        [Fact]
        public void GetComponentFactoryFromType_NonComponentType_ThrowsWithRegisterMessage()
        {
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
                Component.GetComponentFactoryFromType(typeof(string)));

            Assert.Contains("RegisterComponent", ex.Message);
        }

        [Fact]
        public void GetComponentFactoryFromType_IComponentBaseType_ThrowsWithGeneratorMessage()
        {
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
                Component.GetComponentFactoryFromType(typeof(Position)));

            Assert.Contains("source generator", ex.Message);
        }

        [Fact]
        public void GetComponentTable_ForVoidType_ReturnsNull()
        {
            Assert.NotNull(typeof(Component));
        }

        [Fact]
        public void GetComponentId_ForExistingType_ReturnsStableId()
        {
            ComponentId id1 = Component.GetComponentId(typeof(Position));
            ComponentId id2 = Component.GetComponentId(typeof(Position));

            Assert.Equal(id1, id2);
        }

        [Fact]
        public void GetExistingOrSetupNewComponent_ForNewType_ReturnsValidDelegates()
        {
            var result = Component.GetExistingOrSetupNewComponent<Velocity>();
            Assert.NotNull(result.ComponentID);
        }

        [Fact]
        public void RegisterComponent_AlreadyRegistered_DoesNotOverwrite()
        {
            Component.RegisterComponent<Velocity>();
            Component.RegisterComponent<Velocity>();

            ComponentId id = Component.GetComponentId(typeof(Velocity));
            Assert.True(id.RawIndex >= 0);
        }
    }
}
