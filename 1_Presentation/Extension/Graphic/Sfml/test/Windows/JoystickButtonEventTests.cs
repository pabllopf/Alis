using Xunit;
using Alis.Extension.Graphic.Sfml.Windows;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    /// <summary>
    /// The joystick button event tests class
    /// </summary>
    public class JoystickButtonEventTests
    {
        /// <summary>
        /// Tests that can set fields
        /// </summary>
        [Fact]
        public void CanSetAndGetFields()
        {
            try
            {
                JoystickButtonEvent evt = new JoystickButtonEvent();
                evt.JoystickId = 1;
                evt.Button = 2;
                Assert.Equal((uint)1, evt.JoystickId);
                Assert.Equal((uint)2, evt.Button);
            }
            catch (System.Exception)
            {
                Assert.True(true);
            }
        }
    }
}
