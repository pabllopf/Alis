// license header

using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    /// <summary>
    /// The touch test class
    /// </summary>
    public class TouchTest
    {
        /// <summary>
        /// Tests that is down method exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void IsDown_Method_Exists()
        {
            Assert.NotNull(typeof(Touch).GetMethod("IsDown"));
        }

        /// <summary>
        /// Tests that get position method exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void GetPosition_Method_Exists()
        {
            Assert.NotNull(typeof(Touch).GetMethod("GetPosition", new[] { typeof(uint) }));
            Assert.NotNull(typeof(Touch).GetMethod("GetPosition", new[] { typeof(uint), typeof(Window) }));
        }
    }
}
