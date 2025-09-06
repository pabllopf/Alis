using Xunit;
using Alis.Extension.Graphic.Sfml.Windows;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    public class CursorTests
    {
        [Fact(Skip = "Cannot test Cursor without native SFML dependencies.")]
        public void Constructor_SystemCursorType_DoesNotThrow()
        {
            Cursor cursor = new Cursor(Cursor.CursorType.Arrow);
            Assert.NotNull(cursor);
        }

        [Fact(Skip = "Cannot test Cursor without native SFML dependencies.")]
        public void Constructor_Pixels_DoesNotThrow()
        {
            byte[] pixels = new byte[16 * 16 * 4];
            Vector2F size = new Vector2F(16, 16);
            Vector2F hotspot = new Vector2F(0, 0);
            Cursor cursor = new Cursor(pixels, size, hotspot);
            Assert.NotNull(cursor);
        }

        [Fact(Skip = "Cannot test Cursor without native SFML dependencies.")]
        public void Destroy_DoesNotThrow()
        {
            Cursor cursor = new Cursor(Cursor.CursorType.Arrow);
            cursor.Destroy(true);
        }
    }
}

