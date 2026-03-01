using Alis.Extension.Graphic.Ui.Extras.Node;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Node
{
    /// <summary>
    /// Provides unit coverage for <see cref="PinShape"/> enum values.
    /// </summary>
    public class PinShapeTest
    {
        /// <summary>
        /// Verifies that circle shape is defined.
        /// </summary>
        [Fact]
        public void Circle_ShouldBeDefined()
        {
            PinShape shape = PinShape.Circle;
            Assert.Equal(0, (int)shape);
        }
        
    }
}

