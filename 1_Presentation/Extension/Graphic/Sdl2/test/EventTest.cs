using Alis.Extension.Graphic.Sdl2.Enums;
using Alis.Extension.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    public class EventTest
    {
        [Fact]
        public void Event_DefaultInitialization_FieldsHaveDefaultValues()
        {
            Event ev = new Event();

            Assert.Equal(EventType.FirstEvent, ev.type);
        }

        [Fact]
        public void Event_ExplicitLayout_TypeFieldIsAccessible()
        {
            Event ev = new Event();

            ev.type = EventType.Quit;

            Assert.Equal(EventType.Quit, ev.type);
        }

        [Fact]
        public void Event_IsValueType_CopyIsIndependent()
        {
            Event original = new Event();
            Event copy = original;

            Assert.Equal(original.type, copy.type);
        }
    }
}
