using Alis.Extension.Graphic.Ui.Extras.Plot;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot
{
    /// <summary>
    /// Provides unit coverage for <see cref="ImPlotAxisFlags"/> values and combinations.
    /// </summary>
    public class ImPlotAxisFlagsTest
    {
        /// <summary>
        /// Verifies that none is zero.
        /// </summary>
        [Fact]
        public void None_ShouldBeZero()
        {
            Assert.Equal(0, (int) ImPlotAxisFlags.None);
        }

        /// <summary>
        /// Verifies that lock and no-decorations aliases map to their documented compositions.
        /// </summary>
        [Fact]
        public void AliasCompositions_ShouldMatchExpectedValues()
        {
            ImPlotAxisFlags expectedLock = ImPlotAxisFlags.LockMin | ImPlotAxisFlags.LockMax;
            ImPlotAxisFlags expectedNoDecorations = ImPlotAxisFlags.NoLabel | ImPlotAxisFlags.NoGridLines | ImPlotAxisFlags.NoTickMarks | ImPlotAxisFlags.NoTickLabels;

            Assert.Equal(expectedLock, ImPlotAxisFlags.Lock);
            Assert.Equal(expectedNoDecorations, ImPlotAxisFlags.NoDecorations);
        }

        /// <summary>
        /// Verifies that auxiliary defaults map to opposite plus no-grid-lines.
        /// </summary>
        [Fact]
        public void AuxDefault_ShouldMatchExpectedComposition()
        {
            ImPlotAxisFlags expected = ImPlotAxisFlags.Opposite | ImPlotAxisFlags.NoGridLines;

            Assert.Equal(expected, ImPlotAxisFlags.AuxDefault);
        }
    }
}

