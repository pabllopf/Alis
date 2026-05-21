

using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im gui storage pair test class
    /// </summary>
    public class ImGuiStoragePairTest
    {
        /// <summary>
        ///     Tests that key should set and get correctly
        /// </summary>
        [Fact]
        public void Key_Should_SetAndGetCorrectly()
        {
            ImGuiStoragePair storagePair = new ImGuiStoragePair();
            storagePair.Key = 123u;
            Assert.Equal(123u, storagePair.Key);
        }

        /// <summary>
        ///     Tests that value should set and get correctly
        /// </summary>
        [Fact]
        public void Value_Should_SetAndGetCorrectly()
        {
            ImGuiStoragePair storagePair = new ImGuiStoragePair();
            UnionValue value = new UnionValue {ValueI32 = 123};
            storagePair.Value = value;
            Assert.Equal(value, storagePair.Value);
        }
    }
}