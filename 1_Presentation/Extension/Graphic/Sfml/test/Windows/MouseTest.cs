// license header
using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    public class MouseTest
    {
        [Fact]
        public void Button_Enum_HasCorrectValues()
        {
            Assert.Equal(0, (int)Mouse.Button.Left);
            Assert.Equal(1, (int)Mouse.Button.Right);
            Assert.Equal(2, (int)Mouse.Button.Middle);
            Assert.Equal(3, (int)Mouse.Button.XButton1);
            Assert.Equal(4, (int)Mouse.Button.XButton2);
            Assert.Equal(5, (int)Mouse.Button.ButtonCount);
        }

        [Fact]
        public void Wheel_Enum_HasCorrectValues()
        {
            Assert.Equal(0, (int)Mouse.Wheel.VerticalWheel);
            Assert.Equal(1, (int)Mouse.Wheel.HorizontalWheel);
        }

        [Fact]
        public void IsButtonPressed_Method_Exists()
        {
            Assert.NotNull(typeof(Mouse).GetMethod("IsButtonPressed"));
        }

        [Fact]
        public void GetPosition_Method_Exists()
        {
            Assert.NotNull(typeof(Mouse).GetMethod("GetPosition", new[] { typeof(Window) }));
        }

        [Fact]
        public void GetPosition_NoParam_Method_Exists()
        {
            Assert.NotNull(typeof(Mouse).GetMethod("GetPosition", System.Type.EmptyTypes));
        }

        [Fact]
        public void SetPosition_Method_Exists()
        {
            Assert.NotNull(typeof(Mouse).GetMethod("SetPosition", new[] { typeof(Alis.Core.Aspect.Math.Vector.Vector2F) }));
        }

        [Fact]
        public void SetPosition_WithWindow_Method_Exists()
        {
            Assert.NotNull(typeof(Mouse).GetMethod("SetPosition", new[] { typeof(Alis.Core.Aspect.Math.Vector.Vector2F), typeof(Window) }));
        }
    }
}
