using Xunit;

namespace Alis.Core.Physic.Test.Common.Logic
{
    /// <summary>
    /// The controller filter test class
    /// </summary>
    public class ControllerFilterTest
    {
        /// <summary>
        /// Tests that controller filter type should be accessible
        /// </summary>
        [Fact]
        public void ControllerFilter_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Common.Logic.ControllerFilter));
        }
    }
}

