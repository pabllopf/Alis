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
            TestRunteable runteable = new TestRunteable();
            Assert.IsAssignableFrom<IRunteable>(runteable);
        }

        /// <summary>
        /// The test runteable class
        /// </summary>
        /// <seealso cref="IRunteable"/>
        internal sealed class TestRunteable : IRunteable { }
    }
}
