using Xunit;
using Alis.Extension.Graphic.Sfml.Windows;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    public class ClipboardTests
    {
        [Fact(Skip = "Cannot test Clipboard without native SFML dependencies.")]
        public void Contents_GetSet_Works()
        {
            Clipboard.Contents = "test";
            Assert.Equal("test", Clipboard.Contents);
        }
    }
}

