// license header
using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    public class TouchTest
    {
        [Fact]
        public void IsDown_Method_Exists()
        {
            Assert.NotNull(typeof(Touch).GetMethod("IsDown"));
        }

        [Fact]
        public void GetPosition_Method_Exists()
        {
            Assert.NotNull(typeof(Touch).GetMethod("GetPosition", new[] { typeof(uint) }));
            Assert.NotNull(typeof(Touch).GetMethod("GetPosition", new[] { typeof(uint), typeof(Window) }));
        }
    }
}
