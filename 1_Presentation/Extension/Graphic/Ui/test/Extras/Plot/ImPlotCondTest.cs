using Alis.Extension.Graphic.Ui.Extras.Plot;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot
{
    /// <summary>
    /// Provides unit coverage for <see cref="ImPlotCond"/> enum values.
    /// </summary>
    public class ImPlotCondTest
    {
        /// <summary>
        /// Verifies that condition values are defined.
        /// </summary>
        [Fact]
        public void Always_ShouldBeDefined()
        {
            ImPlotCond cond = ImPlotCond.Always;
            Assert.NotEqual(0, (int)cond);
        }

        /// <summary>
        /// Verifies that different conditions have distinct values.
        /// </summary>
        [Fact]
        public void EnumValues_ShouldBeDistinct()
        {
            ImPlotCond always = ImPlotCond.Always;
            ImPlotCond once = ImPlotCond.Once;

            Assert.NotEqual((int)always, (int)once);
        }
    }
}

