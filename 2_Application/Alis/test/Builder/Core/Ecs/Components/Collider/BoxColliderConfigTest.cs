using Alis.Builder.Core.Ecs.Components.Collider;
using Alis.Core.Ecs.Components.Collider;
using Xunit;

namespace Alis.Test.Builder.Core.Ecs.Components.Collider
{
    public class BoxColliderConfigTest
    {
        [Fact]
        public void Delegate_CanBeInvoked()
        {
            BoxColliderConfig<BoxCollider> config = builder => { };
            Assert.NotNull(config);
        }
    }
}
