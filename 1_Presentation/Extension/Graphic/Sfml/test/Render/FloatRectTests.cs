using Xunit;
using Alis.Extension.Graphic.Sfml.Render;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    /// The float rect tests class
    /// </summary>
    public class FloatRectTests
    {
        /// <summary>
        /// Tests that constructor sets fields correctly
        /// </summary>
        [Fact]
        public void Constructor_SetsFieldsCorrectly()
        {
            FloatRect rect = new FloatRect(1.1f, 2.2f, 3.3f, 4.4f);
            Assert.Equal(1.1f, rect.Left);
            Assert.Equal(2.2f, rect.Top);
            Assert.Equal(3.3f, rect.Width);
            Assert.Equal(4.4f, rect.Height);
        }

        /// <summary>
        /// Tests that constructor from position and size sets fields correctly
        /// </summary>
        [Fact]
        public void Constructor_FromPositionAndSize_SetsFieldsCorrectly()
        {
            Vector2F pos = new Vector2F(5, 6);
            Vector2F size = new Vector2F(7, 8);
            FloatRect rect = new FloatRect(pos, size);
            Assert.Equal(5, rect.Left);
            Assert.Equal(6, rect.Top);
            Assert.Equal(7, rect.Width);
            Assert.Equal(8, rect.Height);
        }

        /// <summary>
        /// Tests that contains returns true for point inside
        /// </summary>
        [Fact]
        public void Contains_ReturnsTrueForPointInside()
        {
            FloatRect rect = new FloatRect(0, 0, 10, 10);
            Assert.True(rect.Contains(5, 5));
        }

        /// <summary>
        /// Tests that contains returns false for point outside
        /// </summary>
        [Fact]
        public void Contains_ReturnsFalseForPointOutside()
        {
            FloatRect rect = new FloatRect(0, 0, 10, 10);
            Assert.False(rect.Contains(15, 5));
        }

        /// <summary>
        /// Tests that intersects returns true for overlapping rects
        /// </summary>
        [Fact]
        public void Intersects_ReturnsTrueForOverlappingRects()
        {
            FloatRect r1 = new FloatRect(0, 0, 10, 10);
            FloatRect r2 = new FloatRect(5, 5, 10, 10);
            Assert.True(r1.Intersects(r2));
        }

        /// <summary>
        /// Tests that intersects returns false for non overlapping rects
        /// </summary>
        [Fact]
        public void Intersects_ReturnsFalseForNonOverlappingRects()
        {
            FloatRect r1 = new FloatRect(0, 0, 10, 10);
            FloatRect r2 = new FloatRect(20, 20, 5, 5);
            Assert.False(r1.Intersects(r2));
        }

        /// <summary>
        /// Tests that intersects out overlap is correct
        /// </summary>
        [Fact]
        public void Intersects_OutOverlapIsCorrect()
        {
            FloatRect r1 = new FloatRect(0, 0, 10, 10);
            FloatRect r2 = new FloatRect(5, 5, 10, 10);
            Assert.True(r1.Intersects(r2, out FloatRect overlap));
            Assert.Equal(5, overlap.Left);
            Assert.Equal(5, overlap.Top);
            Assert.Equal(5, overlap.Width);
            Assert.Equal(5, overlap.Height);
        }

        /// <summary>
        /// Tests that to string returns expected format
        /// </summary>
        [Fact]
        public void ToString_ReturnsExpectedFormat()
        {
            FloatRect rect = new FloatRect(1, 2, 3, 4);
            string str = rect.ToString();
            Assert.Contains("Left(1)", str);
            Assert.Contains("Top(2)", str);
            Assert.Contains("Width(3)", str);
            Assert.Contains("Height(4)", str);
        }

        /// <summary>
        /// Tests that equality operators work
        /// </summary>
        [Fact]
        public void Equality_Operators_Work()
        {
            FloatRect a = new FloatRect(1, 2, 3, 4);
            FloatRect b = new FloatRect(1, 2, 3, 4);
            FloatRect c = new FloatRect(5, 6, 7, 8);
            Assert.True(a == b);
            Assert.False(a != b);
            Assert.False(a == c);
            Assert.True(a != c);
        }

        /// <summary>
        /// Tests that get hash code is consistent
        /// </summary>
        [Fact]
        public void GetHashCode_IsConsistent()
        {
            FloatRect a = new FloatRect(1, 2, 3, 4);
            FloatRect b = new FloatRect(1, 2, 3, 4);
            Assert.Equal(a.GetHashCode(), b.GetHashCode());
        }
    }
}

