// license header
using Alis.Extension.Graphic.Sfml.Render;
using Alis.Extension.Graphic.Sfml.Systems;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    /// The view test class
    /// </summary>
    public class ViewTest
    {
        /// <summary>
        /// Tests that view is assignable from object base
        /// </summary>
        [Fact]
        public void View_IsAssignableFromObjectBase()
        {
            Assert.True(typeof(ObjectBase).IsAssignableFrom(typeof(View)));
        }

        /// <summary>
        /// Tests that center size rotation viewport properties exist
        /// </summary>
        [Fact]
        public void Center_Size_Rotation_Viewport_Properties_Exist()
        {
            Assert.NotNull(typeof(View).GetProperty("Center"));
            Assert.NotNull(typeof(View).GetProperty("Size"));
            Assert.NotNull(typeof(View).GetProperty("Rotation"));
            Assert.NotNull(typeof(View).GetProperty("Viewport"));
        }

        /// <summary>
        /// Tests that reset move rotate zoom methods exist
        /// </summary>
        [Fact]
        public void Reset_Move_Rotate_Zoom_Methods_Exist()
        {
            Assert.NotNull(typeof(View).GetMethod("Reset"));
            Assert.NotNull(typeof(View).GetMethod("Move"));
            Assert.NotNull(typeof(View).GetMethod("Rotate"));
            Assert.NotNull(typeof(View).GetMethod("Zoom"));
        }
    }
}
