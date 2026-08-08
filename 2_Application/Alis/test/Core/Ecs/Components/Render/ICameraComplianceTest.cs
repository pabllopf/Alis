using Alis.Core.Ecs.Components.Render;
using Xunit;

namespace Alis.Test.Core.Ecs.Components.Render
{
    /// <summary>
    /// The camera compliance test class
    /// </summary>
    public class ICameraComplianceTest
    {
        /// <summary>
        /// Tests that interface is implemented by camera
        /// </summary>
        [Fact]
        public void Interface_IsImplementedByCamera()
        {
            Camera camera = new Camera();
            Assert.IsAssignableFrom<ICamera>(camera);
        }
    }
}
