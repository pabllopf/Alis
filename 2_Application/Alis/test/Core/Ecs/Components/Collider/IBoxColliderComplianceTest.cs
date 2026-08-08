using Alis.Core.Ecs.Components.Collider;
using Xunit;

namespace Alis.Test.Core.Ecs.Components.Collider
{
    /// <summary>
    /// The box collider compliance test class
    /// </summary>
    public class IBoxColliderComplianceTest
    {
        /// <summary>
        /// Tests that interface is implemented by box collider
        /// </summary>
        [Fact]
        public void Interface_IsImplementedByBoxCollider()
        {
            BoxCollider collider = new BoxCollider();
            Assert.IsAssignableFrom<IBoxCollider>(collider);
        }
    }
}
