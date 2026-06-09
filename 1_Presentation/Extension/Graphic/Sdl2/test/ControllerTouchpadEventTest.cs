using Alis.Extension.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    /// The controller touchpad event test class
    /// </summary>
    public class ControllerTouchpadEventTest
    {
        /// <summary>
        /// Tests that controller touchpad event default initialization fields have default values
        /// </summary>
        [Fact]
        public void ControllerTouchpadEvent_DefaultInitialization_FieldsHaveDefaultValues()
        {
            ControllerTouchpadEvent ev = new ControllerTouchpadEvent();

            Assert.Equal(0u, ev.type);
            Assert.Equal(0u, ev.timestamp);
            Assert.Equal(0, ev.which);
            Assert.Equal(0, ev.touchpad);
            Assert.Equal(0, ev.finger);
            Assert.Equal(0f, ev.x);
            Assert.Equal(0f, ev.y);
            Assert.Equal(0f, ev.pressure);
        }

        /// <summary>
        /// Tests that controller touchpad event set fields stores values correctly
        /// </summary>
        [Fact]
        public void ControllerTouchpadEvent_SetFields_StoresValuesCorrectly()
        {
            ControllerTouchpadEvent ev = new ControllerTouchpadEvent
            {
                type = 1u,
                timestamp = 100u,
                which = 2,
                touchpad = 3,
                finger = 4,
                x = 0.5f,
                y = 0.75f,
                pressure = 0.9f
            };

            Assert.Equal(1u, ev.type);
            Assert.Equal(100u, ev.timestamp);
            Assert.Equal(2, ev.which);
            Assert.Equal(3, ev.touchpad);
            Assert.Equal(4, ev.finger);
            Assert.Equal(0.5f, ev.x);
            Assert.Equal(0.75f, ev.y);
            Assert.Equal(0.9f, ev.pressure);
        }

        /// <summary>
        /// Tests that controller touchpad event is value type copy is independent
        /// </summary>
        [Fact]
        public void ControllerTouchpadEvent_IsValueType_CopyIsIndependent()
        {
            ControllerTouchpadEvent original = new ControllerTouchpadEvent { type = 1u, finger = 4 };
            ControllerTouchpadEvent copy = original;

            copy.finger = 99;

            Assert.Equal(4, original.finger);
            Assert.Equal(99, copy.finger);
        }

        /// <summary>
        /// Tests that controller touchpad event with negative coordinates stores correctly
        /// </summary>
        [Fact]
        public void ControllerTouchpadEvent_WithNegativeCoordinates_StoresCorrectly()
        {
            ControllerTouchpadEvent ev = new ControllerTouchpadEvent { x = -1.0f, y = -2.5f };

            Assert.Equal(-1.0f, ev.x);
            Assert.Equal(-2.5f, ev.y);
        }
    }
}
