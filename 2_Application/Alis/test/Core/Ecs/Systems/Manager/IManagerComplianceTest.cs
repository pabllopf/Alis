using Alis.Core.Ecs.Systems.Manager;
using Xunit;
using System.Linq;

namespace Alis.Test.Core.Ecs.Systems.Manager
{
    public class IManagerComplianceTest
    {
        [Fact]
        public void Interface_ExtendsIRuntime()
        {
            Assert.True(typeof(IManager).GetInterfaces().Any(i => i.Name == "IRuntime"));
        }

        [Fact]
        public void Interface_IsImplementedByAManager()
        {
            Assert.True(typeof(IManager).IsAssignableFrom(typeof(AManager)));
        }
    }
}
