using Alis.Core.Ecs.Systems.Scope;
using Xunit;

namespace Alis.Test.Core.Ecs.Systems.Scope
{
    /// <summary>
    /// The context compliance test class
    /// </summary>
    public class IContextComplianceTest
    {
        /// <summary>
        /// Tests that interface is empty marker
        /// </summary>
        [Fact]
        public void Interface_IsEmptyMarker()
        {
            var methods = typeof(IContext).GetMethods();
            Assert.Empty(methods);
        }

        /// <summary>
        /// Tests that interface can be implemented
        /// </summary>
        [Fact]
        public void Interface_CanBeImplemented()
        {
            var context = new TestContext();
            Assert.IsAssignableFrom<IContext>(context);
        }

        /// <summary>
        /// The test context class
        /// </summary>
        /// <seealso cref="IContext"/>
        internal sealed class TestContext : IContext { }
    }
}
