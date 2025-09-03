using Xunit;
using Alis.Extension.Graphic.Sfml.Windows;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    public class JoystickTests
    {
        [Fact]
        public void Axis_Enum_Values_AreUnique()
        {
            int[] values = (int[])System.Enum.GetValues(typeof(Joystick.Axis));
            Assert.Equal(values.Length, new System.Collections.Generic.HashSet<int>(values).Count);
        }

        [Fact]
        public void Identification_Struct_CanSetFields()
        {
            Joystick.Identification id = new Joystick.Identification
            {
                Name = "Test",
                VendorId = 123,
                ProductId = 456
            };
            Assert.Equal("Test", id.Name);
            Assert.Equal((uint)123, id.VendorId);
            Assert.Equal((uint)456, id.ProductId);
        }
    }
}

