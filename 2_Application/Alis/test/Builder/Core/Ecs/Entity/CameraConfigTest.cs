using Alis.Builder.Core.Ecs.Entity;
using Alis.Core.Ecs.Components.Render;
using Xunit;

namespace Alis.Test.Builder.Core.Ecs.Entity
{
    /// <summary>
    /// The camera config test class
    /// </summary>
    public class CameraConfigTest
    {
        /// <summary>
        /// Tests that delegate can be invoked
        /// </summary>
        [Fact]
        public void Delegate_CanBeInvoked()
        {
            CameraConfig<Camera> config = builder => { };
            Assert.NotNull(config);
        }
    }
}
