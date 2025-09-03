using Xunit;
using Alis.Extension.Graphic.Sfml.Windows;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    public class EventTypeTests
    {
        [Fact]
        public void EventType_Enum_Values_AreUnique()
        {
            int[] values = (int[])System.Enum.GetValues(typeof(EventType));
            Assert.Equal(values.Length, new System.Collections.Generic.HashSet<int>(values).Count);
        }
    }
}

