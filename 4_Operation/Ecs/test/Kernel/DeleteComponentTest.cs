

using Alis.Core.Ecs.Kernel;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel
{
    /// <summary>
    ///     The delete component test class
    /// </summary>
    /// <remarks>
    ///     Tests the <see cref="DeleteComponent" /> record struct which represents
    ///     a command to remove a component from an entity.
    /// </remarks>
    public class DeleteComponentTest
    {
        /// <summary>
        ///     Tests that delete component can be created
        /// </summary>
        /// <remarks>
        ///     Verifies that DeleteComponent can be instantiated with valid parameters.
        /// </remarks>
        [Fact]
        public void DeleteComponent_CanBeCreated()
        {
            GameObjectIdOnly entity = new GameObjectIdOnly(1, 0);
            ComponentId componentId = new ComponentId(0);

            DeleteComponent deleteComp = new DeleteComponent(entity, componentId);

            Assert.NotNull(deleteComp);
            Assert.Equal(1, deleteComp.Entity.ID);
        }

        /// <summary>
        ///     Tests that delete component entity field is preserved
        /// </summary>
        /// <remarks>
        ///     Validates that the Entity field is correctly stored.
        /// </remarks>
        [Fact]
        public void DeleteComponent_EntityFieldIsPreserved()
        {
            GameObjectIdOnly entity = new GameObjectIdOnly(99, 10);
            ComponentId componentId = new ComponentId(5);

            DeleteComponent deleteComp = new DeleteComponent(entity, componentId);

            Assert.Equal(99, deleteComp.Entity.ID);
            Assert.Equal((ushort) 10, deleteComp.Entity.Version);
        }

        /// <summary>
        ///     Tests that delete component id field is preserved
        /// </summary>
        /// <remarks>
        ///     Validates that the ComponentId field is correctly stored.
        /// </remarks>
        [Fact]
        public void DeleteComponent_ComponentIdFieldIsPreserved()
        {
            GameObjectIdOnly entity = new GameObjectIdOnly(1, 0);
            ComponentId componentId = new ComponentId(42);

            DeleteComponent deleteComp = new DeleteComponent(entity, componentId);

            Assert.Equal((ushort) 42, deleteComp.ComponentId.RawIndex);
        }

        /// <summary>
        ///     Tests that delete component is record struct
        /// </summary>
        /// <remarks>
        ///     Confirms that DeleteComponent behaves as a record struct with value semantics.
        /// </remarks>
        [Fact]
        public void DeleteComponent_IsRecordStruct()
        {
            GameObjectIdOnly entity = new GameObjectIdOnly(1, 0);
            ComponentId componentId = new ComponentId(5);

            DeleteComponent deleteComp1 = new DeleteComponent(entity, componentId);
            DeleteComponent deleteComp2 = new DeleteComponent(entity, componentId);

            Assert.Equal(deleteComp1, deleteComp2);
        }

        /// <summary>
        ///     Tests that delete component with different entities are not equal
        /// </summary>
        /// <remarks>
        ///     Validates that DeleteComponent with different entities are not equal.
        /// </remarks>
        [Fact]
        public void DeleteComponent_WithDifferentEntitiesAreNotEqual()
        {
            GameObjectIdOnly entity1 = new GameObjectIdOnly(1, 0);
            GameObjectIdOnly entity2 = new GameObjectIdOnly(2, 0);
            ComponentId componentId = new ComponentId(5);

            DeleteComponent deleteComp1 = new DeleteComponent(entity1, componentId);
            DeleteComponent deleteComp2 = new DeleteComponent(entity2, componentId);

            Assert.NotEqual(deleteComp1, deleteComp2);
        }

        /// <summary>
        ///     Tests that delete component with different ids are not equal
        /// </summary>
        /// <remarks>
        ///     Validates that DeleteComponent with different component IDs are not equal.
        /// </remarks>
        [Fact]
        public void DeleteComponent_WithDifferentComponentIdsAreNotEqual()
        {
            GameObjectIdOnly entity = new GameObjectIdOnly(1, 0);
            ComponentId componentId1 = new ComponentId(5);
            ComponentId componentId2 = new ComponentId(10);

            DeleteComponent deleteComp1 = new DeleteComponent(entity, componentId1);
            DeleteComponent deleteComp2 = new DeleteComponent(entity, componentId2);

            Assert.NotEqual(deleteComp1, deleteComp2);
        }
    }
}