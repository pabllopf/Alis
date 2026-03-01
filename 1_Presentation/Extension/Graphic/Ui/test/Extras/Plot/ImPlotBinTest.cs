using System.Runtime.InteropServices;
using Alis.Extension.Graphic.Ui.Extras.Plot;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot
{
    /// <summary>
    /// Provides unit coverage for <see cref="ImPlotBin"/> enum values.
    /// </summary>
    public class ImPlotBinTest
    {
        /// <summary>
        /// Verifies that Sqrt bin mode is defined.
        /// </summary>
        [Fact]
        public void Sqrt_ShouldBeDefined()
        {
            ImPlotBin bin = ImPlotBin.Sqrt;
            Assert.NotEqual(0, (int)bin);
        }

        /// <summary>
        /// Verifies enum values are distinct.
        /// </summary>
        [Fact]
        public void EnumValues_ShouldBeDistinct()
        {
            ImPlotBin sqrt = ImPlotBin.Sqrt;
            ImPlotBin sturges = ImPlotBin.Sturges;

            Assert.NotEqual((int)sqrt, (int)sturges);
        }
    }
}

