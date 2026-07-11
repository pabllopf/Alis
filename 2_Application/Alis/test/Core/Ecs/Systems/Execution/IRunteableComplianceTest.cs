using Alis.Core.Ecs.Systems.Execution;
using Xunit;

namespace Alis.Test.Core.Ecs.Systems.Execution
{
    /// <summary>
    /// The runteable compliance test class
    /// </summary>
    public class IRunteableComplianceTest
    {
        /// <summary>
        /// Tests that interface can be implemented
        /// </summary>
        [Fact]
        public void Interface_CanBeImplemented()
        {
            var runteable = new TestRunteable();
            Assert.IsAssignableFrom<IRunteable>(runteable);
        }

        /// <summary>
        /// Tests that interface is empty marker
        /// </summary>
        [Fact]
        public void Interface_IsEmptyMarker()
        {
            var methods = typeof(IRunteable).GetMethods();
            Assert.Empty(methods);
        }

        /// <summary>
        /// The test runteable class
        /// </summary>
        /// <seealso cref="IRunteable"/>
        private sealed class TestRunteable : IRunteable { }
    }
}
