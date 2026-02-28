using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Xunit;
using Alis.Extension.Graphic.Sfml.Windows;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    /// <summary>
    /// Unit tests for the Clipboard class.
    /// </summary>
    public class ClipboardTest
    {
        /// <summary>
        /// Tests that the Clipboard class can be instantiated.
        /// </summary>
        [Fact]
        public void Constructor_CreatesObject()
        {
            var clipboard = new Clipboard();
            Assert.NotNull(clipboard);
        }
    }
}

