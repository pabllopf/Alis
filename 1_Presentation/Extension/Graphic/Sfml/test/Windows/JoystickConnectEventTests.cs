using Xunit;
using Alis.Extension.Graphic.Sfml.Windows;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    /// <summary>
    /// The joystick connect event tests class
    /// </summary>
    public class JoystickConnectEventTests
    {
        /// <summary>
        /// Tests that can set fields
        /// </summary>
        [Fact]
        public void CanSetFields()
        {
            JoystickConnectEvent evt = new JoystickConnectEvent { JoystickId = 7 };
            Assert.Equal((uint)7, evt.JoystickId);
        }
    }

    /// <summary>
    /// The joystick connect event args tests class
    /// </summary>
    public class JoystickConnectEventArgsTests
    {
        /// <summary>
        /// Tests that constructor sets properties correctly
        /// </summary>
        [Fact]
        public void Constructor_SetsPropertiesCorrectly()
        {
            JoystickConnectEvent evt = new JoystickConnectEvent { JoystickId = 5 };
            JoystickConnectEventArgs args = new JoystickConnectEventArgs(evt);
            Assert.Equal((uint)5, args.JoystickId);
        }

        /// <summary>
        /// Tests that to string returns expected format
        /// </summary>
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

