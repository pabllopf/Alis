using Xunit;
using Alis.Extension.Graphic.Sfml.Render;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    /// Unit tests for the FloatRect struct.
    /// </summary>
    public class FloatRectTest
    {
        /// <summary>
        /// Tests the constructors and field assignment.
        /// </summary>
        [Fact]
        public void Constructor_AssignsFields()
        {
            var rect = new FloatRect(1, 2, 3, 4);
            Assert.Equal(1, rect.Left);
            Assert.Equal(2, rect.Top);
            Assert.Equal(3, rect.Width);
            Assert.Equal(4, rect.Height);
        }

        /// <summary>
        /// Tests Contains method for points inside and outside.
        /// </summary>
        [Fact]
        public void Contains_Works()
        {
            var rect = new FloatRect(0, 0, 10, 10);
            Assert.True(rect.Contains(5, 5));
            Assert.False(rect.Contains(15, 5));
        }

        /// <summary>
        /// Tests Intersects method for overlapping and non-overlapping rectangles.
        /// </summary>
        [Fact]
        public void Intersects_Works()
        {
            var r1 = new FloatRect(0, 0, 10, 10);
            var r2 = new FloatRect(5, 5, 10, 10);
            var r3 = new FloatRect(20, 20, 5, 5);
            Assert.True(r1.Intersects(r2));
            Assert.False(r1.Intersects(r3));
        }

        /// <summary>
        /// Tests Intersects with overlap output.
        /// </summary>
        [Fact]
        public void Intersects_OverlapOutput_Works()
        {
            var r1 = new FloatRect(0, 0, 10, 10);
            var r2 = new FloatRect(5, 5, 10, 10);
            Assert.True(r1.Intersects(r2, out var overlap));
            Assert.Equal(5, overlap.Left);
            Assert.Equal(5, overlap.Top);
            Assert.Equal(5, overlap.Width);
            Assert.Equal(5, overlap.Height);
        }

        /// <summary>
        /// Tests ToString returns a non-empty string.
        /// </summary>
        [Fact]
        public void ToString_NotEmpty()
        {
            var rect = new FloatRect(1, 2, 3, 4);
            Assert.False(string.IsNullOrWhiteSpace(rect.ToString()));
        }
    }
}

