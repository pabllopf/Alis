using Xunit;
using Alis.Extension.Graphic.Sfml.Windows;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    public class JoystickMoveEventTests
    {
        [Fact]
        public void CanSetFields()
        {
            JoystickMoveEvent evt = new JoystickMoveEvent { JoystickId = 2, Axis = Joystick.Axis.X, Position = 42.5f };
            Assert.Equal((uint)2, evt.JoystickId);
            Assert.Equal(Joystick.Axis.X, evt.Axis);
            Assert.Equal(42.5f, evt.Position);
        }
    }

    public class JoystickMoveEventArgsTests
    {
        [Fact]
        public void Constructor_SetsPropertiesCorrectly()
        {
            JoystickMoveEvent evt = new JoystickMoveEvent { JoystickId = 3, Axis = Joystick.Axis.Y, Position = 99.9f };
            JoystickMoveEventArgs args = new JoystickMoveEventArgs(evt);
            Assert.Equal((uint)3, args.JoystickId);
            Assert.Equal(Joystick.Axis.Y, args.Axis);
            Assert.Equal(99.9f, args.Position);
        }

        [Fact]
        public void ToString_ReturnsExpectedFormat()
        {
            JoystickMoveEvent evt = new JoystickMoveEvent { JoystickId = 1, Axis = Joystick.Axis.Z, Position = -12.3f };
            JoystickMoveEventArgs args = new JoystickMoveEventArgs(evt);
            string str = args.ToString();
            Assert.Contains("JoystickId(1)", str);
            Assert.Contains("Axis(Z)", str);
        }
    }
}

