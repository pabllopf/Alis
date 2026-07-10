using Alis.Core.Ecs.Components.Collider;
using Xunit;

namespace Alis.Test.Core.Ecs.Components.Collider
{
    public class IBoxColliderComplianceTest
    {
        [Fact]
        public void Interface_IsImplementedByBoxCollider()
        {
            var collider = new BoxCollider();
            Assert.IsAssignableFrom<IBoxCollider>(collider);
        }
    }
}
