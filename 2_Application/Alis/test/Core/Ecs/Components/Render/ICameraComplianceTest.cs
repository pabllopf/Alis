using Alis.Core.Ecs.Components.Render;
using Xunit;

namespace Alis.Test.Core.Ecs.Components.Render
{
    public class ICameraComplianceTest
    {
        [Fact]
        public void Interface_IsImplementedByCamera()
        {
            var camera = new Camera();
            Assert.IsAssignableFrom<ICamera>(camera);
        }
    }
}
