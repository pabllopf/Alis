using Xunit;
using Alis.Extension.Graphic.Sfml.Windows;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    /// <summary>
    /// The event type tests class
    /// </summary>
    public class EventTypeTests
    {
        /// <summary>
        /// Tests that event type enum values are unique
        /// </summary>
        [Fact]
        public void EventType_Enum_Values_AreUnique()
        {
            int[] values = (int[])System.Enum.GetValues(typeof(EventType));
            Assert.Equal(values.Length, new System.Collections.Generic.HashSet<int>(values).Count);
        }
    }
}

