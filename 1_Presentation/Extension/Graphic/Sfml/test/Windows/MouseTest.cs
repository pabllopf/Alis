// license header

using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    /// <summary>
    /// The mouse test class
    /// </summary>
    public class MouseTest
    {
        /// <summary>
        /// Tests that button enum has correct values
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Button_Enum_HasCorrectValues()
        {
            Assert.Equal(0, (int)Mouse.Button.Left);
            Assert.Equal(1, (int)Mouse.Button.Right);
            Assert.Equal(2, (int)Mouse.Button.Middle);
            Assert.Equal(3, (int)Mouse.Button.XButton1);
            Assert.Equal(4, (int)Mouse.Button.XButton2);
            Assert.Equal(5, (int)Mouse.Button.ButtonCount);
        }

        /// <summary>
        /// Tests that wheel enum has correct values
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Wheel_Enum_HasCorrectValues()
        {
            Assert.Equal(0, (int)Mouse.Wheel.VerticalWheel);
            Assert.Equal(1, (int)Mouse.Wheel.HorizontalWheel);
        }

        /// <summary>
        /// Tests that is button pressed method exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void IsButtonPressed_Method_Exists()
        {
            Assert.NotNull(typeof(Mouse).GetMethod("IsButtonPressed"));
        }

        /// <summary>
        /// Tests that get position method exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void GetPosition_Method_Exists()
        {
            Assert.NotNull(typeof(Mouse).GetMethod("GetPosition", new[] { typeof(Window) }));
        }

        /// <summary>
        /// Tests that get position no param method exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void GetPosition_NoParam_Method_Exists()
        {
            Assert.NotNull(typeof(Mouse).GetMethod("GetPosition", System.Type.EmptyTypes));
        }

        /// <summary>
        /// Tests that set position method exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void SetPosition_Method_Exists()
        {
            Assert.NotNull(typeof(Mouse).GetMethod("SetPosition", new[] { typeof(Alis.Core.Aspect.Math.Vector.Vector2F) }));
        }

        /// <summary>
        /// Tests that set position with window method exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void SetPosition_WithWindow_Method_Exists()
        {
            Assert.NotNull(typeof(Mouse).GetMethod("SetPosition", new[] { typeof(Alis.Core.Aspect.Math.Vector.Vector2F), typeof(Window) }));
        }
    }
}
