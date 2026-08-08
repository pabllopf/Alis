using Alis.Core.Ecs.Systems.Scope;
using Xunit;

namespace Alis.Test.Core.Ecs.Systems.Scope
{
    /// <summary>
    /// The context handler compliance test class
    /// </summary>
    public class IContextHandlerComplianceTest
    {
        /// <summary>
        /// Tests that interface is implemented by context handler
        /// </summary>
        [Fact]
        public void Interface_IsImplementedByContextHandler()
        {
            Context ctx = new Context();
            ContextHandler handler = new ContextHandler(ctx);
            Assert.IsAssignableFrom<IContextHandler<Context>>(handler);
        }
    }
}
