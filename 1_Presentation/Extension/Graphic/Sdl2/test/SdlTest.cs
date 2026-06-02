
using Alis.Extension.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    public class SdlTest
    {
        /// <summary>
        ///     Tests that constant TextEditingEventTextSize has correct value.
        /// </summary>
        [Fact]
        public void TextEditingEventTextSize_HasCorrectValue()
        {
            Assert.Equal(32, Sdl.TextEditingEventTextSize);
        }
}
}
