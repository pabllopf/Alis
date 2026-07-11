using Alis.Builder.Core.Ecs.Components.Collider;
using Alis.Core.Ecs.Components.Collider;
using Xunit;

namespace Alis.Test.Builder.Core.Ecs.Components.Collider
{
    /// <summary>
    /// The box collider config test class
    /// </summary>
    public class BoxColliderConfigTest
    {
        /// <summary>
        /// Tests that delegate can be invoked
        /// </summary>
        [Fact]
        public void Delegate_CanBeInvoked()
        {
            BoxColliderConfig<BoxCollider> config = builder => { };
            Assert.NotNull(config);
        }
    }
}
