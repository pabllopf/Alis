using System.Runtime.InteropServices;
using Alis.Extension.Graphic.Ui.Extras.Node;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Node
{
    /// <summary>
    /// Provides unit coverage for <see cref="ImNodesEditorContext"/>.
    /// </summary>
    public class ImNodesEditorContextTest
    {
        /// <summary>
        /// Verifies that the editor context is represented as an empty marker struct.
        /// </summary>
        [Fact]
        public void Struct_ShouldHaveZeroMarshalSize()
        {
            Assert.Equal(1, Marshal.SizeOf<ImNodesEditorContext>());
        }
    }
}

