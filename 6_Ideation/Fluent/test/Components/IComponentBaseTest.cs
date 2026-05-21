

using Alis.Core.Aspect.Fluent.Components;
using Xunit;

namespace Alis.Core.Aspect.Fluent.Test.Components
{
    /// <summary>
    ///     Unit tests for the IComponentBase interface.
    ///     As a marker interface, this test ensures it can be implemented and recognized.
    /// </summary>
    public class IComponentBaseTest
    {
        /// <summary>
        ///     Ensures that IComponentBase can be implemented and recognized as such.
        /// </summary>
        [Fact]
        public void CanImplementIComponentBase()
        {
            DummyComponent component = new DummyComponent();
            Assert.IsAssignableFrom<IComponentBase>(component);
        }

        /// <summary>
        ///     Dummy implementation for testing purposes.
        /// </summary>
        private class DummyComponent : IComponentBase
        {
        }
    }
}