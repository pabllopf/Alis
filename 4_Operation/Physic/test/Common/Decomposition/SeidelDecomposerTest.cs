using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition
{
    public class SeidelDecomposerTest
    {
        [Fact]
        public void SeidelDecomposer_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Common.Decomposition.SeidelDecomposer));
        }
    }
}

