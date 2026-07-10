using Alis.Core.Ecs.Systems.Execution;
using Xunit;

namespace Alis.Test.Core.Ecs.Systems.Execution
{
    public class IRunteableComplianceTest
    {
        [Fact]
        public void Interface_CanBeImplemented()
        {
            var runteable = new TestRunteable();
            Assert.IsAssignableFrom<IRunteable>(runteable);
        }

        [Fact]
        public void Interface_IsEmptyMarker()
        {
            var methods = typeof(IRunteable).GetMethods();
            Assert.Empty(methods);
        }

        private sealed class TestRunteable : IRunteable { }
    }
}
