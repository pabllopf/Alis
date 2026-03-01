using Alis.Extension.Graphic.Ui.Extras.Node;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Node
{
    /// <summary>
    /// Provides unit coverage for <see cref="StyleVar"/> enum values.
    /// </summary>
    public class StyleVarTest
    {
        [Fact]
        public void StyleVar_Values_Should_Be_As_Expected()
        {
            Assert.Equal(6, (int)StyleVar.LinkLineSegmentsPerLength);
            Assert.Equal(7, (int)StyleVar.LinkHoverDistance);
            Assert.Equal(8, (int)StyleVar.PinCircleRadius);
        }
    }
}

