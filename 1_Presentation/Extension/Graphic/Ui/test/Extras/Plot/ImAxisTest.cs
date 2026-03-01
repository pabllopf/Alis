using Alis.Extension.Graphic.Ui.Extras.Plot;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot
{
    /// <summary>
    /// Provides unit coverage for <see cref="ImAxis"/> enum values.
    /// </summary>
    public class ImAxisTest
    {


        /// <summary>
        /// Verifies that different axes have distinct identifiers.
        /// </summary>
        [Fact]
        public void EnumValues_ShouldBeDistinct()
        {
            ImAxis x = ImAxis.X1;
            ImAxis y = ImAxis.Y1;
            ImAxis y2 = ImAxis.Y2;

            Assert.NotEqual((int)x, (int)y);
            Assert.NotEqual((int)y, (int)y2);
            Assert.NotEqual((int)x, (int)y2);
        }
    }
}

