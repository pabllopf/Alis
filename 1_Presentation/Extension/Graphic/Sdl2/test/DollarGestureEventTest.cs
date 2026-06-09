using Alis.Extension.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    /// The dollar gesture event test class
    /// </summary>
    public class DollarGestureEventTest
    {
        /// <summary>
        /// Tests that dollar gesture event default initialization fields have default values
        /// </summary>
        [Fact]
        public void DollarGestureEvent_DefaultInitialization_FieldsHaveDefaultValues()
        {
            DollarGestureEvent ev = new DollarGestureEvent();

            Assert.Equal(0u, ev.type);
            Assert.Equal(0u, ev.timestamp);
            Assert.Equal(0L, ev.touchId);
            Assert.Equal(0L, ev.gestureId);
            Assert.Equal(0u, ev.numFingers);
            Assert.Equal(0f, ev.error);
            Assert.Equal(0f, ev.x);
            Assert.Equal(0f, ev.y);
        }

        /// <summary>
        /// Tests that dollar gesture event set fields stores values correctly
        /// </summary>
        [Fact]
        public void DollarGestureEvent_SetFields_StoresValuesCorrectly()
        {
            DollarGestureEvent ev = new DollarGestureEvent
            {
                type = 1u,
                timestamp = 100u,
                touchId = 12345L,
                gestureId = 67890L,
                numFingers = 3u,
                error = 0.1f,
                x = 200f,
                y = 150f
            };

            Assert.Equal(1u, ev.type);
            Assert.Equal(100u, ev.timestamp);
            Assert.Equal(12345L, ev.touchId);
            Assert.Equal(67890L, ev.gestureId);
            Assert.Equal(3u, ev.numFingers);
            Assert.Equal(0.1f, ev.error);
            Assert.Equal(200f, ev.x);
            Assert.Equal(150f, ev.y);
        }

        /// <summary>
        /// Tests that dollar gesture event is value type copy is independent
        /// </summary>
        [Fact]
        public void DollarGestureEvent_IsValueType_CopyIsIndependent()
        {
            DollarGestureEvent original = new DollarGestureEvent { touchId = 999L, gestureId = 888L };
            DollarGestureEvent copy = original;

            copy.touchId = 111L;

            Assert.Equal(999L, original.touchId);
            Assert.Equal(111L, copy.touchId);
        }
    }
}
