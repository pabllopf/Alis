

using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im draw list splitter test class
    /// </summary>
    public class ImDrawListSplitterTest
    {
        /// <summary>
        ///     Tests that current should set and get correctly
        /// </summary>
        [Fact]
        public void Current_Should_SetAndGetCorrectly()
        {
            ImDrawListSplitter splitter = new ImDrawListSplitter();
            splitter.Current = 1;
            Assert.Equal(1, splitter.Current);
        }

        /// <summary>
        ///     Tests that count should set and get correctly
        /// </summary>
        [Fact]
        public void Count_Should_SetAndGetCorrectly()
        {
            ImDrawListSplitter splitter = new ImDrawListSplitter();
            splitter.Count = 2;
            Assert.Equal(2, splitter.Count);
        }

        /// <summary>
        ///     Tests that channels should set and get correctly
        /// </summary>
        [Fact]
        public void Channels_Should_SetAndGetCorrectly()
        {
            ImDrawListSplitter splitter = new ImDrawListSplitter();
            ImVector channels = new ImVector();
            splitter.Channels = channels;
            Assert.Equal(channels, splitter.Channels);
        }
    }
}