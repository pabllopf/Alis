using Xunit;
using Alis.Extension.Graphic.Sfml.Windows;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    /// <summary>
    /// The joystick button event args tests class
    /// </summary>
    public class JoystickButtonEventArgsTests
    {
        /// <summary>
        /// Tests that constructor sets properties correctly
        /// </summary>
        [Fact]
        public void Constructor_SetsPropertiesCorrectly()
        {
            JoystickButtonEvent evt = new JoystickButtonEvent { JoystickId = 3, Button = 7 };
            JoystickButtonEventArgs args = new JoystickButtonEventArgs(evt);
            Assert.Equal((uint)3, args.JoystickId);
            Assert.Equal((uint)7, args.Button);
        }

        /// <summary>
        /// Tests that to string returns expected format
        /// </summary>
        [Fact]
        public void ToString_ReturnsExpectedFormat()
        {
            JoystickButtonEvent evt = new JoystickButtonEvent { JoystickId = 1, Button = 2 };
            JoystickButtonEventArgs args = new JoystickButtonEventArgs(evt);
            string str = args.ToString();
            Assert.Contains("JoystickId(1)", str);
            Assert.Contains("Button(2)", str);
        }
    }
}

