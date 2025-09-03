using Xunit;
using Alis.Extension.Graphic.Sfml.Windows;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    public class JoystickConnectEventTests
    {
        [Fact]
        public void CanSetFields()
        {
            JoystickConnectEvent evt = new JoystickConnectEvent { JoystickId = 7 };
            Assert.Equal((uint)7, evt.JoystickId);
        }
    }

    public class JoystickConnectEventArgsTests
    {
        [Fact]
        public void Constructor_SetsPropertiesCorrectly()
        {
            JoystickConnectEvent evt = new JoystickConnectEvent { JoystickId = 5 };
            JoystickConnectEventArgs args = new JoystickConnectEventArgs(evt);
            Assert.Equal((uint)5, args.JoystickId);
        }

        [Fact]
        public void ToString_ReturnsExpectedFormat()
        {
            JoystickConnectEvent evt = new JoystickConnectEvent { JoystickId = 2 };
            JoystickConnectEventArgs args = new JoystickConnectEventArgs(evt);
            string str = args.ToString();
            Assert.Contains("JoystickId(2)", str);
        }
    }
}

