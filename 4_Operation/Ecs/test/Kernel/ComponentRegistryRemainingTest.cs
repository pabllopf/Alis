using System;
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel
{
    /// <summary>
    /// The component registry remaining test class
    /// </summary>
    public class ComponentRegistryRemainingTest
    {
        /// <summary>
        /// Tests that get component table for void type returns null
        /// </summary>
        [Fact] public void GetComponentTable_ForVoidType_ReturnsNull()
        {
            Assert.NotNull(typeof(Component));
        }

        /// <summary>
        /// Tests that get component id for existing type returns stable id
        /// </summary>
        [Fact] public void GetComponentId_ForExistingType_ReturnsStableId()
        {
            ComponentId id1 = Component.GetComponentId(typeof(Position));
            ComponentId id2 = Component.GetComponentId(typeof(Position));

            Assert.Equal(id1, id2);
        }

        /// <summary>
        /// Tests that get existing or setup new component for new type returns valid delegates
        /// </summary>
        [Fact] public void GetExistingOrSetupNewComponent_ForNewType_ReturnsValidDelegates()
        {
            (ComponentId ComponentID, IdTable<Velocity> Stack, ComponentDelegates<Velocity>.InitDelegate Initer, ComponentDelegates<Velocity>.DestroyDelegate Destroyer) result = Component.GetExistingOrSetupNewComponent<Velocity>();
        }

        /// <summary>
        /// Tests that register component already registered does not overwrite
        /// </summary>
        [Fact] public void RegisterComponent_AlreadyRegistered_DoesNotOverwrite()
        {
            Component.RegisterComponent<Velocity>();
            Component.RegisterComponent<Velocity>();

            ComponentId id = Component.GetComponentId(typeof(Velocity));
            Assert.True(id.RawIndex >= 0);
        }
        
        /// <summary>
        /// Tests that get component id after register component returns valid id
        /// </summary>
        [Fact] public void GetComponentId_AfterRegisterComponent_ReturnsValidId()
        {
            Component.RegisterComponent<Uri>();

            ComponentId id = Component.GetComponentId(typeof(Uri));

            Assert.True(id.RawIndex >= 0);
        }

        /// <summary>
        /// Tests that get existing or setup new component existing type returns cached delegates
        /// </summary>
        [Fact] public void GetExistingOrSetupNewComponent_ExistingType_ReturnsCachedDelegates()
        {
            (ComponentId ComponentID, IdTable<Damage> Stack, ComponentDelegates<Damage>.InitDelegate Initer, ComponentDelegates<Damage>.DestroyDelegate Destroyer) first = Component.GetExistingOrSetupNewComponent<Damage>();
            (ComponentId ComponentID, IdTable<Damage> Stack, ComponentDelegates<Damage>.InitDelegate Initer, ComponentDelegates<Damage>.DestroyDelegate Destroyer) second = Component.GetExistingOrSetupNewComponent<Damage>();

            Assert.Equal(first.ComponentID, second.ComponentID);
            Assert.Equal(first.Initer, second.Initer);
        }

        /// <summary>
        /// Tests that get component id non existent plain type throws with register message
        /// </summary>
        [Fact] public void GetComponentId_NonExistentPlainType_ThrowsWithRegisterMessage()
        {
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
                Component.GetComponentFactoryFromType(typeof(DateTime)));

            Assert.Contains("RegisterComponent", ex.Message);
        }
    }
}
