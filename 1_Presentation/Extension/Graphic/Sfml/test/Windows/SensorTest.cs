// license header
using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    public class SensorTest
    {
        [Fact]
        public void Type_Enum_HasCorrectValues()
        {
            Assert.Equal(0, (int)Sensor.Type.Accelerometer);
            Assert.Equal(1, (int)Sensor.Type.Gyroscope);
            Assert.Equal(2, (int)Sensor.Type.Magnetometer);
            Assert.Equal(3, (int)Sensor.Type.Gravity);
            Assert.Equal(4, (int)Sensor.Type.UserAcceleration);
            Assert.Equal(5, (int)Sensor.Type.Orientation);
            Assert.Equal(6, (int)Sensor.Type.TypeCount);
        }

        [Fact]
        public void IsAvailable_Method_Exists()
        {
            Assert.NotNull(typeof(Sensor).GetMethod("IsAvailable"));
        }

        [Fact]
        public void SetEnabled_Method_Exists()
        {
            Assert.NotNull(typeof(Sensor).GetMethod("SetEnabled"));
        }

        [Fact]
        public void GetValue_Method_Exists()
        {
            Assert.NotNull(typeof(Sensor).GetMethod("GetValue"));
        }
    }
}
