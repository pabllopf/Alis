

using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im gui text buffer test class
    /// </summary>
    public class ImGuiTextBufferTest
    {
        /// <summary>
        ///     Tests that buf should set and get correctly
        /// </summary>
        [Fact]
        public void Buf_Should_SetAndGetCorrectly()
        {
            ImGuiTextBuffer textBuffer = new ImGuiTextBuffer();
            ImVector buf = new ImVector();
            textBuffer.Buf = buf;
            Assert.Equal(buf, textBuffer.Buf);
        }
    }
}