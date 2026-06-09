using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    /// <summary>
    /// The cursor test class
    /// </summary>
    public class CursorTest
    {
        /// <summary>
        /// Tests that cursor type has expected values
        /// </summary>
        [Fact]
        public void CursorType_HasExpectedValues()
        {
            Assert.Equal(0, (int)Cursor.CursorType.Arrow);
            Assert.Equal(1, (int)Cursor.CursorType.ArrowWait);
            Assert.Equal(2, (int)Cursor.CursorType.Wait);
            Assert.Equal(3, (int)Cursor.CursorType.Text);
            Assert.Equal(4, (int)Cursor.CursorType.Hand);
            Assert.Equal(5, (int)Cursor.CursorType.SizeHorinzontal);
            Assert.Equal(6, (int)Cursor.CursorType.SizeVertical);
            Assert.Equal(7, (int)Cursor.CursorType.SizeTopLeftBottomRight);
            Assert.Equal(8, (int)Cursor.CursorType.SizeBottomLeftTopRight);
            Assert.Equal(9, (int)Cursor.CursorType.SizeAll);
            Assert.Equal(10, (int)Cursor.CursorType.Cross);
            Assert.Equal(11, (int)Cursor.CursorType.Help);
            Assert.Equal(12, (int)Cursor.CursorType.NotAllowed);
        }
    }
}
