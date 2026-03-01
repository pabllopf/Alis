using Alis.Extension.Graphic.Ui.Extras.Node;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Node
{
    /// <summary>
    /// Provides unit coverage for <see cref="StyleFlags"/> enum flag values.
    /// </summary>
    public class StyleFlagsTest
    {
        /// <summary>
        /// Verifies that None flag is defined.
        /// </summary>
        [Fact]
        public void None_ShouldBeZero()
        {
            StyleFlags flags = StyleFlags.None;
            Assert.Equal(0, (int)flags);
        }


    }
}

