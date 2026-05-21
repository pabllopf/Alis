

using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im draw channel test class
    /// </summary>
    public class ImDrawChannelTest
    {
        /// <summary>
        ///     Tests that cmd buffer should be initialized correctly
        /// </summary>
        [Fact]
        public void CmdBuffer_ShouldBeInitializedCorrectly()
        {
            ImDrawChannel drawChannel = new ImDrawChannel();

            ImVector cmdBuffer = drawChannel.CmdBuffer;

            Assert.Equal(0, cmdBuffer.Size);
        }

        /// <summary>
        ///     Tests that idx buffer should be initialized correctly
        /// </summary>
        [Fact]
        public void IdxBuffer_ShouldBeInitializedCorrectly()
        {
            ImDrawChannel drawChannel = new ImDrawChannel();

            ImVector idxBuffer = drawChannel.IdxBuffer;

            Assert.Equal(0, idxBuffer.Size);
        }

        /// <summary>
        ///     Tests that cmd buffer ptr should return correct value
        /// </summary>
        [Fact]
        public void CmdBufferPtr_ShouldReturnCorrectValue()
        {
            ImDrawChannel drawChannel = new ImDrawChannel
            {
                CmdBuffer = new ImVector()
            };

            ImVectorG<ImDrawCmd> cmdBufferPtr = drawChannel.CmdBufferPtr;

            Assert.Equal(0, cmdBufferPtr.Size);
        }

        /// <summary>
        ///     Tests that idx buffer ptr should return correct value
        /// </summary>
        [Fact]
        public void IdxBufferPtr_ShouldReturnCorrectValue()
        {
            ImDrawChannel drawChannel = new ImDrawChannel
            {
                IdxBuffer = new ImVector()
            };

            ImVectorG<ushort> idxBufferPtr = drawChannel.IdxBufferPtr;

            Assert.Equal(0, idxBufferPtr.Size);
        }
    }
}