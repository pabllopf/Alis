using Alis.Extension.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    public class AudioDeviceEventTest
    {
        [Fact]
        public void AudioDeviceEvent_DefaultInitialization_FieldsHaveDefaultValues()
        {
            AudioDeviceEvent ev = new AudioDeviceEvent();

            Assert.Equal(0u, ev.type);
            Assert.Equal(0u, ev.timestamp);
            Assert.Equal(0u, ev.which);
            Assert.Equal(0, ev.isCapture);
        }

        [Fact]
        public void AudioDeviceEvent_SetFields_StoresValuesCorrectly()
        {
            AudioDeviceEvent ev = new AudioDeviceEvent
            {
                type = 1u,
                timestamp = 100u,
                which = 2u,
                isCapture = 1
            };

            Assert.Equal(1u, ev.type);
            Assert.Equal(100u, ev.timestamp);
            Assert.Equal(2u, ev.which);
            Assert.Equal(1, ev.isCapture);
        }

        [Fact]
        public void AudioDeviceEvent_IsValueType_CopyIsIndependent()
        {
            AudioDeviceEvent original = new AudioDeviceEvent { type = 1u, which = 2u };
            AudioDeviceEvent copy = original;

            copy.type = 99u;

            Assert.Equal(1u, original.type);
            Assert.Equal(99u, copy.type);
        }

        [Fact]
        public void AudioDeviceEvent_WithZeroCapture_SetsIsCaptureToZero()
        {
            AudioDeviceEvent ev = new AudioDeviceEvent { isCapture = 0 };

            Assert.Equal(0, ev.isCapture);
        }

        [Fact]
        public void AudioDeviceEvent_WithMaxValues_StoresCorrectly()
        {
            AudioDeviceEvent ev = new AudioDeviceEvent
            {
                type = uint.MaxValue,
                timestamp = uint.MaxValue,
                which = uint.MaxValue,
                isCapture = byte.MaxValue
            };

            Assert.Equal(uint.MaxValue, ev.type);
            Assert.Equal(uint.MaxValue, ev.timestamp);
            Assert.Equal(uint.MaxValue, ev.which);
            Assert.Equal(byte.MaxValue, ev.isCapture);
        }
    }
}
