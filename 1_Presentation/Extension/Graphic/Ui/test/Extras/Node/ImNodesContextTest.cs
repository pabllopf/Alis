using System.Runtime.InteropServices;
using Alis.Extension.Graphic.Ui.Extras.Node;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Node
{
    /// <summary>
    /// Provides unit coverage for <see cref="ImNodesContext"/>.
    /// </summary>
    public class ImNodesContextTest
    {
        /// <summary>
        /// Verifies that the context type is an empty marker struct.
        /// </summary>
        [Fact]
        public void Struct_ShouldHaveZeroMarshalSize()
        {
            Assert.Equal(1, Marshal.SizeOf<ImNodesContext>());
        }
    }
}

