// license header
using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    public class JoystickTest
    {
        [Fact]
        public void Axis_Enum_HasCorrectValues()
        {
            Assert.Equal(0, (int)Joystick.Axis.X);
            Assert.Equal(1, (int)Joystick.Axis.Y);
            Assert.Equal(2, (int)Joystick.Axis.Z);
            Assert.Equal(3, (int)Joystick.Axis.R);
            Assert.Equal(4, (int)Joystick.Axis.U);
            Assert.Equal(5, (int)Joystick.Axis.V);
            Assert.Equal(6, (int)Joystick.Axis.PovX);
            Assert.Equal(7, (int)Joystick.Axis.PovY);
        }

        [Fact]
        public void Constants_AreCorrect()
        {
            Assert.Equal(8u, Joystick.Count);
            Assert.Equal(32u, Joystick.ButtonCount);
            Assert.Equal(8u, Joystick.AxisCount);
        }

        [Fact]
        public void IsConnected_Method_Exists()
        {
            Assert.NotNull(typeof(Joystick).GetMethod("IsConnected"));
        }

        [Fact]
        public void GetButtonCount_Method_Exists()
        {
            Assert.NotNull(typeof(Joystick).GetMethod("GetButtonCount"));
        }

        [Fact]
        public void HasAxis_Method_Exists()
        {
            Assert.NotNull(typeof(Joystick).GetMethod("HasAxis"));
        }

        [Fact]
        public void IsButtonPressed_Method_Exists()
        {
            Assert.NotNull(typeof(Joystick).GetMethod("IsButtonPressed"));
        }

        [Fact]
        public void GetAxisPosition_Method_Exists()
        {
            Assert.NotNull(typeof(Joystick).GetMethod("GetAxisPosition"));
        }

        [Fact]
        public void Update_Method_Exists()
        {
            Assert.NotNull(typeof(Joystick).GetMethod("Update"));
        }

        [Fact]
        public void GetIdentification_Method_Exists()
        {
            Assert.NotNull(typeof(Joystick).GetMethod("GetIdentification"));
        }

        [Fact]
        public void Identification_Struct_HasProperties()
        {
            var identType = typeof(Joystick.Identification);
            Assert.NotNull(identType.GetProperty("Name"));
            Assert.NotNull(identType.GetProperty("VendorId"));
            Assert.NotNull(identType.GetProperty("ProductId"));
        }
    }
}
