using Xunit;
using Alis.Extension.Graphic.Sfml.Windows;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    public class EventTests
    {
        [Fact]
        public void CanSetAndGetFields()
        {
            Event evt = new Event();
            evt.Type = EventType.Closed;
            evt.Size.Width = 100;
            evt.Size.Height = 200;
            Assert.Equal(EventType.Closed, evt.Type);
            Assert.Equal((uint)100, evt.Size.Width);
            Assert.Equal((uint)200, evt.Size.Height);
        }
    }
}

