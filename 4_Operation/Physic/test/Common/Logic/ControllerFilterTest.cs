using Xunit;

namespace Alis.Core.Physic.Test.Common.Logic
{
    public class ControllerFilterTest
    {
        [Fact]
        public void ControllerFilter_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Common.Logic.ControllerFilter));
        }
    }
}

