using Xunit;
using Alis.Extension.Graphic.Sfml.Windows;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    /// <summary>
    /// The clipboard tests class
    /// </summary>
    public class ClipboardTests
    {
        /// <summary>
        /// Tests that contents get set works
        /// </summary>
        [Fact(Skip = "Cannot test Clipboard without native SFML dependencies.")]
        public void Contents_GetSet_Works()
        {
            Clipboard.Contents = "test";
            Assert.Equal("test", Clipboard.Contents);
        }
    }
}

