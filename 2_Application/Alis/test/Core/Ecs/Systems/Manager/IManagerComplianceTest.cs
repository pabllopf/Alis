using Alis.Core.Ecs.Systems.Manager;
using Xunit;
using System.Linq;

namespace Alis.Test.Core.Ecs.Systems.Manager
{
    /// <summary>
    /// The manager compliance test class
    /// </summary>
    public class IManagerComplianceTest
    {
        /// <summary>
        /// Tests that interface extends i runtime
        /// </summary>
        [Fact]
        public void Interface_ExtendsIRuntime()
        {
            Assert.True(typeof(IManager).GetInterfaces().Any(i => i.Name == "IRuntime"));
        }

        /// <summary>
        /// Tests that interface is implemented by a manager
        /// </summary>
        [Fact]
        public void Interface_IsImplementedByAManager()
        {
            Assert.True(typeof(IManager).IsAssignableFrom(typeof(AManager)));
        }
    }
}
