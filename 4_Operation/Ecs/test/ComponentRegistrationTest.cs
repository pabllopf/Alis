

using System;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     Tests for component registration and ID management
    /// </summary>
    /// <remarks>
    ///     Validates that components are properly registered and assigned unique IDs.
    ///     Tests the Component<T>.Id property and Component.GetComponentId() method.
    /// </remarks>
    public class ComponentRegistrationTest
    {
        /// <summary>
        ///     Tests that each component type gets unique ID
        /// </summary>
        [Fact]
        public void Component_EachTypeGetsUniqueId()
        {
            ComponentId positionId = Component<Position>.Id;
            ComponentId healthId = Component<Health>.Id;
            ComponentId velocityId = Component<Velocity>.Id;

            Assert.NotEqual(positionId, healthId);
            Assert.NotEqual(healthId, velocityId);
            Assert.NotEqual(positionId, velocityId);
        }

        /// <summary>
        ///     Tests that component IDs are consistent across multiple accesses
        /// </summary>
        [Fact]
        public void Component_IdIsConsistentAcrossAccesses()
        {
            ComponentId id1 = Component<Position>.Id;
            ComponentId id2 = Component<Position>.Id;
            ComponentId id3 = Component<Position>.Id;

            Assert.Equal(id1, id2);
            Assert.Equal(id2, id3);
        }

        /// <summary>
        ///     Tests getting component ID by type
        /// </summary>
        [Fact]
        public void Component_GetComponentIdByType()
        {
            Type positionType = typeof(Position);
            ComponentId genericId = Component<Position>.Id;
            ComponentId typeId = Component.GetComponentId(positionType);

            Assert.Equal(genericId, typeId);
        }

        /// <summary>
        ///     Tests that component IDs are non-zero
        /// </summary>
        [Fact]
        public void Component_IdsAreNonZero()
        {
            ComponentId posId = Component<Position>.Id;
            ComponentId healthId = Component<Health>.Id;

            Assert.NotEqual(default(ComponentId), posId);
            Assert.NotEqual(default(ComponentId), healthId);
        }
    }
}