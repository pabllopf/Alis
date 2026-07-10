using Alis.Core.Ecs.Systems.Scope;
using Xunit;

namespace Alis.Test.Core.Ecs.Systems.Scope
{
    public class IContextComplianceTest
    {
        [Fact]
        public void Interface_IsEmptyMarker()
        {
            var methods = typeof(IContext).GetMethods();
            Assert.Empty(methods);
        }

        [Fact]
        public void Interface_CanBeImplemented()
        {
            var context = new TestContext();
            Assert.IsAssignableFrom<IContext>(context);
        }

        private sealed class TestContext : IContext { }
    }
}
