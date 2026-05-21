

using Alis.Core.Ecs.Kernel;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     Tests the <see cref="EntityWorldInfoAccess" /> struct.
    /// </summary>
    public class EntityWorldInfoAccessTest
    {
        /// <summary>
        ///     Tests that entity id only can be set and retrieved.
        /// </summary>
        [Fact]
        public void EntityIDOnly_SetAndGet_ShouldWorkCorrectly()
        {
            EntityWorldInfoAccess info = new EntityWorldInfoAccess();
            GameObjectIdOnly entityIdOnly = new GameObjectIdOnly(42, 1);

            info.EntityIDOnly = entityIdOnly;

            Assert.Equal(42, info.EntityIDOnly.ID);
            Assert.Equal((ushort) 1, info.EntityIDOnly.Version);
        }

        /// <summary>
        ///     Tests that world id can be set and retrieved.
        /// </summary>
        [Fact]
        public void WorldID_SetAndGet_ShouldWorkCorrectly()
        {
            EntityWorldInfoAccess info = new EntityWorldInfoAccess();

            info.WorldID = 5;

            Assert.Equal((ushort) 5, info.WorldID);
        }

        /// <summary>
        ///     Tests that both fields can be set independently.
        /// </summary>
        [Fact]
        public void BothFields_SetIndependently_ShouldNotInterfere()
        {
            EntityWorldInfoAccess info = new EntityWorldInfoAccess();
            GameObjectIdOnly entityIdOnly = new GameObjectIdOnly(100, 2);

            info.EntityIDOnly = entityIdOnly;
            info.WorldID = 10;

            Assert.Equal(100, info.EntityIDOnly.ID);
            Assert.Equal((ushort) 2, info.EntityIDOnly.Version);
            Assert.Equal((ushort) 10, info.WorldID);
        }

        /// <summary>
        ///     Tests that default values are initialized correctly.
        /// </summary>
        [Fact]
        public void DefaultValues_ShouldBeInitialized()
        {
            EntityWorldInfoAccess info = new EntityWorldInfoAccess();

            Assert.Equal(0, info.EntityIDOnly.ID);
            Assert.Equal((ushort) 0, info.EntityIDOnly.Version);
            Assert.Equal((ushort) 0, info.WorldID);
        }

        /// <summary>
        ///     Tests that maximum ushort values can be stored for world id.
        /// </summary>
        [Fact]
        public void WorldID_MaxValue_ShouldBeStoredCorrectly()
        {
            EntityWorldInfoAccess info = new EntityWorldInfoAccess();

            info.WorldID = ushort.MaxValue;

            Assert.Equal(ushort.MaxValue, info.WorldID);
        }

        /// <summary>
        ///     Tests that entity id only with maximum values can be stored.
        /// </summary>
        [Fact]
        public void EntityIDOnly_MaxValues_ShouldBeStoredCorrectly()
        {
            EntityWorldInfoAccess info = new EntityWorldInfoAccess();
            GameObjectIdOnly entityIdOnly = new GameObjectIdOnly(int.MaxValue, ushort.MaxValue);

            info.EntityIDOnly = entityIdOnly;

            Assert.Equal(int.MaxValue, info.EntityIDOnly.ID);
            Assert.Equal(ushort.MaxValue, info.EntityIDOnly.Version);
        }

        /// <summary>
        ///     Tests that multiple instances maintain separate data.
        /// </summary>
        [Fact]
        public void MultipleInstances_ShouldMaintainSeparateData()
        {
            EntityWorldInfoAccess info1 = new EntityWorldInfoAccess();
            EntityWorldInfoAccess info2 = new EntityWorldInfoAccess();
            GameObjectIdOnly entityIdOnly1 = new GameObjectIdOnly(10, 1);
            GameObjectIdOnly entityIdOnly2 = new GameObjectIdOnly(20, 2);

            info1.EntityIDOnly = entityIdOnly1;
            info1.WorldID = 5;
            info2.EntityIDOnly = entityIdOnly2;
            info2.WorldID = 10;

            Assert.Equal(10, info1.EntityIDOnly.ID);
            Assert.Equal((ushort) 5, info1.WorldID);
            Assert.Equal(20, info2.EntityIDOnly.ID);
            Assert.Equal((ushort) 10, info2.WorldID);
        }
    }
}