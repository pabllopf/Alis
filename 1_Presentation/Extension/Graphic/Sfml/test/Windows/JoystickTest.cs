// license header
using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    /// <summary>
    /// The joystick test class
    /// </summary>
    public class JoystickTest
    {
        /// <summary>
        /// Tests that axis enum has correct values
        /// </summary>
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

        /// <summary>
        /// Tests that constants are correct
        /// </summary>
        [Fact]
        public void Constants_AreCorrect()
        {
            Assert.Equal(8u, Joystick.Count);
            Assert.Equal(32u, Joystick.ButtonCount);
            Assert.Equal(8u, Joystick.AxisCount);
        }

        /// <summary>
        /// Tests that is connected method exists
        /// </summary>
        [Fact]
        public void IsConnected_Method_Exists()
        {
            Assert.NotNull(typeof(Joystick).GetMethod("IsConnected"));
        }

        /// <summary>
        /// Tests that get button count method exists
        /// </summary>
        [Fact]
        public void GetButtonCount_Method_Exists()
        {
            Assert.NotNull(typeof(Joystick).GetMethod("GetButtonCount"));
        }

        /// <summary>
        /// Tests that has axis method exists
        /// </summary>
        [Fact]
        public void HasAxis_Method_Exists()
        {
            Assert.NotNull(typeof(Joystick).GetMethod("HasAxis"));
        }

        /// <summary>
        /// Tests that is button pressed method exists
        /// </summary>
        [Fact]
        public void IsButtonPressed_Method_Exists()
        {
            Assert.NotNull(typeof(Joystick).GetMethod("IsButtonPressed"));
        }

        /// <summary>
        /// Tests that get axis position method exists
        /// </summary>
        [Fact]
        public void GetAxisPosition_Method_Exists()
        {
            Assert.NotNull(typeof(Joystick).GetMethod("GetAxisPosition"));
        }

        /// <summary>
        /// Tests that update method exists
        /// </summary>
        [Fact]
        public void Update_Method_Exists()
        {
            Assert.NotNull(typeof(Joystick).GetMethod("Update"));
        }

        /// <summary>
        /// Tests that get identification method exists
        /// </summary>
        [Fact]
        public void GetIdentification_Method_Exists()
        {
            Assert.NotNull(typeof(Joystick).GetMethod("GetIdentification"));
        }

        /// <summary>
        /// Tests that identification struct has properties
        /// </summary>
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
