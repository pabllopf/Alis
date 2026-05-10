using System;
using System.Runtime.InteropServices;
using Alis.Extension.Graphic.Ui.Extras.Plot;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     Tests for ImPlot native wrappers when the native library is unavailable.
    /// </summary>
    public class ImPlotNativeInteropTest
    {
        /// <summary>
        ///     Verifies that EndPlot fails fast when the native library is missing.
        /// </summary>
        [Fact]
        public void EndPlot_RequiresNativeLibrary()
        {
            if (IsCimguiAvailable())
            {
                return;
            }

            Assert.Throws<DllNotFoundException>(() => ImPlot.EndPlot());
        }

        /// <summary>
        ///     Verifies that PlotStems fails fast when the native library is missing.
        /// </summary>
        [Fact]
        public void PlotStems_RequiresNativeLibrary()
        {
            if (IsCimguiAvailable())
            {
                return;
            }

            int xs = 1;
            int ys = 2;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStems("Series", ref xs, ref ys, 1));
        }

        private static bool IsCimguiAvailable()
        {
            if (NativeLibrary.TryLoad("cimgui", out IntPtr handle))
            {
                NativeLibrary.Free(handle);
                return true;
            }

            return false;
        }
    }
}
