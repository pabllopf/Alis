using Alis.Builder.Core.Ecs.Entity;
using Alis.Core.Ecs.Components.Render;
using Xunit;

namespace Alis.Test.Builder.Core.Ecs.Entity
{
    public class CameraConfigTest
    {
        [Fact]
        public void Delegate_CanBeInvoked()
        {
            CameraConfig<Camera> config = builder => { };
            Assert.NotNull(config);
        }
    }
}
