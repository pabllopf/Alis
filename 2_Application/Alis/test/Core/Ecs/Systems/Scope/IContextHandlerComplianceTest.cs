using Alis.Core.Ecs.Systems.Scope;
using Xunit;

namespace Alis.Test.Core.Ecs.Systems.Scope
{
    public class IContextHandlerComplianceTest
    {
        [Fact]
        public void Interface_IsImplementedByContextHandler()
        {
            var ctx = new Context();
            var handler = new ContextHandler(ctx);
            Assert.IsAssignableFrom<IContextHandler<Context>>(handler);
        }
    }
}
