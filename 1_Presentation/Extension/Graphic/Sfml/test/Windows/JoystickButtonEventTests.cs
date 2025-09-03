using Xunit;
using Alis.Extension.Graphic.Sfml.Windows;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    public class JoystickButtonEventTests
    {
        [Fact]
        public void CanSetFields()
        {
            JoystickButtonEvent evt = new JoystickButtonEvent { JoystickId = 1, Button = 2 };
            Assert.Equal((uint)1, evt.JoystickId);
            Assert.Equal((uint)2, evt.Button);
        }
    }
}

