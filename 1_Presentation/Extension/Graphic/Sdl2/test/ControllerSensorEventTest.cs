using Alis.Extension.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    public class ControllerSensorEventTest
    {
        [Fact]
        public void ControllerSensorEvent_DefaultInitialization_FieldsHaveDefaultValues()
        {
            ControllerSensorEvent ev = new ControllerSensorEvent();

            Assert.Equal(0u, ev.type);
            Assert.Equal(0u, ev.timestamp);
            Assert.Equal(0, ev.which);
            Assert.Equal(0, ev.sensor);
            Assert.Equal(0f, ev.data1);
            Assert.Equal(0f, ev.data2);
            Assert.Equal(0f, ev.data3);
        }

        [Fact]
        public void ControllerSensorEvent_IsValueType_CopyIsIndependent()
        {
            ControllerSensorEvent original = new ControllerSensorEvent();
            ControllerSensorEvent copy = original;

            Assert.Equal(original.type, copy.type);
            Assert.Equal(original.timestamp, copy.timestamp);
            Assert.Equal(original.which, copy.which);
            Assert.Equal(original.sensor, copy.sensor);
            Assert.Equal(original.data1, copy.data1);
        }
    }
}
