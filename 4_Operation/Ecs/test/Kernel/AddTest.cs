

using Alis.Core.Ecs.Kernel;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel
{
    /// <summary>
    ///     The add component test class
    /// </summary>
    /// <remarks>
    ///     Tests the <see cref="NeighborCache{T}.Add" /> record struct which represents
    ///     a command to add a component to an entity.
    /// </remarks>
    public class AddTest
    {
        /// <summary>
        ///     Tests that add component can be created
        /// </summary>
        /// <remarks>
        ///     Verifies that Add can be instantiated with valid parameters.
        /// </remarks>
        [Fact]
        public void Add_CanBeCreated()
        {
            GameObjectIdOnly entity = new GameObjectIdOnly(1, 0);
            ComponentId componentId = new ComponentId(0);
            ComponentHandle componentHandle = new ComponentHandle(0, componentId);

            AddComponent addComp = new AddComponent(entity, componentHandle);

            Assert.Equal(1, addComp.Entity.ID);
        }

        /// <summary>
        ///     Tests that add component entity field is preserved
        /// </summary>
        /// <remarks>
        ///     Validates that the Entity field is correctly stored.
        /// </remarks>
        [Fact]
        public void Add_EntityFieldIsPreserved()
        {
            GameObjectIdOnly entity = new GameObjectIdOnly(42, 5);
            ComponentId componentId = new ComponentId(0);
            ComponentHandle componentHandle = new ComponentHandle(0, componentId);

            AddComponent addComp = new AddComponent(entity, componentHandle);

            Assert.Equal(42, addComp.Entity.ID);
            Assert.Equal((ushort) 5, addComp.Entity.Version);
        }

        /// <summary>
        ///     Tests that add component handle field is preserved
        /// </summary>
        /// <remarks>
        ///     Validates that the ComponentHandle field is correctly stored.
        /// </remarks>
        [Fact]
        public void Add_ComponentHandleFieldIsPreserved()
        {
            GameObjectIdOnly entity = new GameObjectIdOnly(1, 0);
            ComponentId componentId = new ComponentId(2);
            ComponentHandle componentHandle = new ComponentHandle(10, componentId);

            AddComponent addComp = new AddComponent(entity, componentHandle);

            Assert.Equal(10, addComp.ComponentHandle.Index);
            Assert.Equal((ushort) 2, addComp.ComponentHandle.ComponentId.RawIndex);
        }

        /// <summary>
        ///     Tests that add component is record struct
        /// </summary>
        /// <remarks>
        ///     Confirms that Add behaves as a record struct with value semantics.
        /// </remarks>
        [Fact]
        public void Add_IsRecordStruct()
        {
            GameObjectIdOnly entity = new GameObjectIdOnly(1, 0);
            ComponentId componentId = new ComponentId(0);
            ComponentHandle componentHandle = new ComponentHandle(0, componentId);

            AddComponent addComp1 = new AddComponent(entity, componentHandle);
            AddComponent addComp2 = new AddComponent(entity, componentHandle);

            Assert.Equal(addComp1, addComp2);
        }

        /// <summary>
        ///     Tests that add component with different entities are not equal
        /// </summary>
        /// <remarks>
        ///     Validates that Add with different entities are not equal.
        /// </remarks>
        [Fact]
        public void Add_WithDifferentEntitiesAreNotEqual()
        {
            GameObjectIdOnly entity1 = new GameObjectIdOnly(1, 0);
            GameObjectIdOnly entity2 = new GameObjectIdOnly(2, 0);
            ComponentId id = new ComponentId(0);
            ComponentHandle componentHandle = new ComponentHandle(0, id);

            AddComponent addComp1 = new AddComponent(entity1, componentHandle);
            AddComponent addComp2 = new AddComponent(entity2, componentHandle);

            Assert.NotEqual(addComp1, addComp2);
        }

        /// <summary>
        ///     Tests that add component with different handles are not equal
        /// </summary>
        /// <remarks>
        ///     Validates that Add with different handles are not equal.
        /// </remarks>
        [Fact]
        public void Add_WithDifferentHandlesAreNotEqual()
        {
            GameObjectIdOnly entity = new GameObjectIdOnly(1, 0);
            ComponentId id = new ComponentId(0);
            ComponentHandle handle1 = new ComponentHandle(1, id);
            ComponentHandle handle2 = new ComponentHandle(2, id);

            AddComponent addComp1 = new AddComponent(entity, handle1);
            AddComponent addComp2 = new AddComponent(entity, handle2);

            Assert.NotEqual(addComp1, addComp2);
        }

        /// <summary>
        ///     Tests that add component hash code consistency
        /// </summary>
        /// <remarks>
        ///     Validates that equal Add structs have same hash code.
        /// </remarks>
        [Fact]
        public void Add_HashCodeConsistency()
        {
            GameObjectIdOnly entity = new GameObjectIdOnly(1, 0);
            ComponentId id = new ComponentId(0);
            ComponentHandle handle = new ComponentHandle(0, id);

            AddComponent addComp1 = new AddComponent(entity, handle);
            AddComponent addComp2 = new AddComponent(entity, handle);

            Assert.Equal(addComp1.GetHashCode(), addComp2.GetHashCode());
        }

        /// <summary>
        ///     Tests that add component with different versions are not equal
        /// </summary>
        /// <remarks>
        ///     Validates that Add with different entity versions are not equal.
        /// </remarks>
        [Fact]
        public void Add_WithDifferentVersionsAreNotEqual()
        {
            GameObjectIdOnly entity1 = new GameObjectIdOnly(1, 0);
            GameObjectIdOnly entity2 = new GameObjectIdOnly(1, 1);
            ComponentId id = new ComponentId(0);
            ComponentHandle handle = new ComponentHandle(0, id);

            AddComponent addComp1 = new AddComponent(entity1, handle);
            AddComponent addComp2 = new AddComponent(entity2, handle);

            Assert.NotEqual(addComp1, addComp2);
        }

        /// <summary>
        ///     Tests that add component with different component ids are not equal
        /// </summary>
        /// <remarks>
        ///     Validates that Add with different component IDs are not equal.
        /// </remarks>
        [Fact]
        public void Add_WithDifferentComponentIdsAreNotEqual()
        {
            GameObjectIdOnly entity = new GameObjectIdOnly(1, 0);
            ComponentId id1 = new ComponentId(0);
            ComponentId id2 = new ComponentId(1);
            ComponentHandle handle1 = new ComponentHandle(0, id1);
            ComponentHandle handle2 = new ComponentHandle(0, id2);

            AddComponent addComp1 = new AddComponent(entity, handle1);
            AddComponent addComp2 = new AddComponent(entity, handle2);

            Assert.NotEqual(addComp1, addComp2);
        }

        /// <summary>
        ///     Tests that add component with max values
        /// </summary>
        /// <remarks>
        ///     Tests Add with maximum values.
        /// </remarks>
        [Fact]
        public void Add_WithMaxValues()
        {
            GameObjectIdOnly entity = new GameObjectIdOnly(int.MaxValue, ushort.MaxValue);
            ComponentId id = new ComponentId(ushort.MaxValue);
            ComponentHandle handle = new ComponentHandle(int.MaxValue, id);

            AddComponent addComp = new AddComponent(entity, handle);

            Assert.Equal(int.MaxValue, addComp.Entity.ID);
            Assert.Equal(ushort.MaxValue, addComp.Entity.Version);
            Assert.Equal(int.MaxValue, addComp.ComponentHandle.Index);
            Assert.Equal(ushort.MaxValue, addComp.ComponentHandle.ComponentId.RawIndex);
        }

        /// <summary>
        ///     Tests that add component to string works
        /// </summary>
        /// <remarks>
        ///     Validates string representation of Add.
        /// </remarks>
        [Fact]
        public void Add_ToStringWorks()
        {
            GameObjectIdOnly entity = new GameObjectIdOnly(1, 0);
            ComponentId id = new ComponentId(0);
            ComponentHandle handle = new ComponentHandle(0, id);

            AddComponent addComp = new AddComponent(entity, handle);
            string result = addComp.ToString();

            Assert.NotNull(result);
            Assert.IsType<string>(result);
        }
    }
}