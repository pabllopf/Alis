

using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im gui storage test class
    /// </summary>
    public class ImGuiStorageTest
    {
        /// <summary>
        ///     Tests that data should set and get correctly
        /// </summary>
        [Fact]
        public void Data_Should_SetAndGetCorrectly()
        {
            ImGuiStorage storage = new ImGuiStorage();
            ImVector data = new ImVector();
            storage.Data = data;
            Assert.Equal(data, storage.Data);
        }
    }
}