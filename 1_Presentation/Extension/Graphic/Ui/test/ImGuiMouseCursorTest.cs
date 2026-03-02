using Alis.Extension.Graphic.Ui;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    /// Provides unit coverage for <see cref="ImGuiMouseCursor"/> values.
    /// </summary>
    public class ImGuiMouseCursorTest
    {
        /// <summary>
        /// Verifies that none keeps the sentinel negative value.
        /// </summary>
        [Fact]
        public void None_ShouldBeNegativeOne()
        {
            Assert.Equal(-1, (int) ImGuiMouseCursor.None);
        }

        /// <summary>
        /// Verifies that count is one step after the last defined cursor.
        /// </summary>
        [Fact]
        public void Count_ShouldFollowNotAllowed()
        {
            Assert.Equal((int) ImGuiMouseCursor.NotAllowed + 1, (int) ImGuiMouseCursor.Count);
        }
    }
}

