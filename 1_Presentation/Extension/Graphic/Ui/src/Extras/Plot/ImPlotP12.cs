

using System.Text;

namespace Alis.Extension.Graphic.Ui.Extras.Plot
{
    /// <summary>
    ///     The im plot class
    /// </summary>
    public static partial class ImPlot
    {
        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="bins">The bins</param>
        /// <param name="barScale">The bar scale</param>
        /// <param name="range">The range</param>
        /// <returns>The double</returns>
        public static double PlotHistogram(string labelId, byte[] values, int count, int bins, double barScale, ImPlotRange range)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram_U8Ptr(Encoding.UTF8.GetBytes(labelId), values, count, bins, barScale, range, 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="bins">The bins</param>
        /// <param name="barScale">The bar scale</param>
        /// <param name="range">The range</param>
        /// <param name="flags">The flags</param>
        /// <returns>The double</returns>
        public static double PlotHistogram(string labelId, byte[] values, int count, int bins, double barScale, ImPlotRange range, ImPlotHistogramFlags flags)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram_U8Ptr(Encoding.UTF8.GetBytes(labelId), values, count, bins, barScale, range, flags);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <returns>The double</returns>
        public static double PlotHistogram(string labelId, short[] values, int count)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram_S16Ptr(Encoding.UTF8.GetBytes(labelId), values, count, 0, 1.0, new ImPlotRange(), 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="bins">The bins</param>
        /// <returns>The double</returns>
        public static double PlotHistogram(string labelId, short[] values, int count, int bins)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram_S16Ptr(Encoding.UTF8.GetBytes(labelId), values, count, bins, 1.0, new ImPlotRange(), 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="bins">The bins</param>
        /// <param name="barScale">The bar scale</param>
        /// <returns>The double</returns>
        public static double PlotHistogram(string labelId, short[] values, int count, int bins, double barScale)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram_S16Ptr(Encoding.UTF8.GetBytes(labelId), values, count, bins, barScale, new ImPlotRange(), 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="bins">The bins</param>
        /// <param name="barScale">The bar scale</param>
        /// <param name="range">The range</param>
        /// <returns>The double</returns>
        public static double PlotHistogram(string labelId, short[] values, int count, int bins, double barScale, ImPlotRange range)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram_S16Ptr(Encoding.UTF8.GetBytes(labelId), values, count, bins, barScale, range, 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="bins">The bins</param>
        /// <param name="barScale">The bar scale</param>
        /// <param name="range">The range</param>
        /// <param name="flags">The flags</param>
        /// <returns>The double</returns>
        public static double PlotHistogram(string labelId, short[] values, int count, int bins, double barScale, ImPlotRange range, ImPlotHistogramFlags flags)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram_S16Ptr(Encoding.UTF8.GetBytes(labelId), values, count, bins, barScale, range, flags);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <returns>The double</returns>
        public static double PlotHistogram(string labelId, ushort[] values, int count)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram_U16Ptr(Encoding.UTF8.GetBytes(labelId), values, count, 0, 1.0, new ImPlotRange(), 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="bins">The bins</param>
        /// <returns>The double</returns>
        public static double PlotHistogram(string labelId, ushort[] values, int count, int bins)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram_U16Ptr(Encoding.UTF8.GetBytes(labelId), values, count, bins, 1.0, new ImPlotRange(), 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="bins">The bins</param>
        /// <param name="barScale">The bar scale</param>
        /// <returns>The double</returns>
        public static double PlotHistogram(string labelId, ushort[] values, int count, int bins, double barScale)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram_U16Ptr(Encoding.UTF8.GetBytes(labelId), values, count, bins, barScale, new ImPlotRange(), 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="bins">The bins</param>
        /// <param name="barScale">The bar scale</param>
        /// <param name="range">The range</param>
        /// <returns>The double</returns>
        public static double PlotHistogram(string labelId, ushort[] values, int count, int bins, double barScale, ImPlotRange range)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram_U16Ptr(Encoding.UTF8.GetBytes(labelId), values, count, bins, barScale, range, 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="bins">The bins</param>
        /// <param name="barScale">The bar scale</param>
        /// <param name="range">The range</param>
        /// <param name="flags">The flags</param>
        /// <returns>The double</returns>
        public static double PlotHistogram(string labelId, ushort[] values, int count, int bins, double barScale, ImPlotRange range, ImPlotHistogramFlags flags)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram_U16Ptr(Encoding.UTF8.GetBytes(labelId), values, count, bins, barScale, range, flags);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <returns>The double</returns>
        public static double PlotHistogram(string labelId, int[] values, int count)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram_S32Ptr(Encoding.UTF8.GetBytes(labelId), values, count, 0, 1.0, new ImPlotRange(), 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="bins">The bins</param>
        /// <returns>The double</returns>
        public static double PlotHistogram(string labelId, int[] values, int count, int bins)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram_S32Ptr(Encoding.UTF8.GetBytes(labelId), values, count, bins, 1.0, new ImPlotRange(), 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="bins">The bins</param>
        /// <param name="barScale">The bar scale</param>
        /// <returns>The double</returns>
        public static double PlotHistogram(string labelId, int[] values, int count, int bins, double barScale)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram_S32Ptr(Encoding.UTF8.GetBytes(labelId), values, count, bins, barScale, new ImPlotRange(), 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="bins">The bins</param>
        /// <param name="barScale">The bar scale</param>
        /// <param name="range">The range</param>
        /// <returns>The double</returns>
        public static double PlotHistogram(string labelId, int[] values, int count, int bins, double barScale, ImPlotRange range)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram_S32Ptr(Encoding.UTF8.GetBytes(labelId), values, count, bins, barScale, range, 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="bins">The bins</param>
        /// <param name="barScale">The bar scale</param>
        /// <param name="range">The range</param>
        /// <param name="flags">The flags</param>
        /// <returns>The double</returns>
        public static double PlotHistogram(string labelId, int[] values, int count, int bins, double barScale, ImPlotRange range, ImPlotHistogramFlags flags)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram_S32Ptr(Encoding.UTF8.GetBytes(labelId), values, count, bins, barScale, range, flags);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <returns>The double</returns>
        public static double PlotHistogram(string labelId, uint[] values, int count)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram_U32Ptr(Encoding.UTF8.GetBytes(labelId), values, count, 0, 1.0, new ImPlotRange(), 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="bins">The bins</param>
        /// <returns>The double</returns>
        public static double PlotHistogram(string labelId, uint[] values, int count, int bins)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram_U32Ptr(Encoding.UTF8.GetBytes(labelId), values, count, bins, 1.0, new ImPlotRange(), 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="bins">The bins</param>
        /// <param name="barScale">The bar scale</param>
        /// <returns>The double</returns>
        public static double PlotHistogram(string labelId, uint[] values, int count, int bins, double barScale)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram_U32Ptr(Encoding.UTF8.GetBytes(labelId), values, count, bins, barScale, new ImPlotRange(), 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="bins">The bins</param>
        /// <param name="barScale">The bar scale</param>
        /// <param name="range">The range</param>
        /// <returns>The double</returns>
        public static double PlotHistogram(string labelId, uint[] values, int count, int bins, double barScale, ImPlotRange range)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram_U32Ptr(Encoding.UTF8.GetBytes(labelId), values, count, bins, barScale, range, 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="bins">The bins</param>
        /// <param name="barScale">The bar scale</param>
        /// <param name="range">The range</param>
        /// <param name="flags">The flags</param>
        /// <returns>The double</returns>
        public static double PlotHistogram(string labelId, uint[] values, int count, int bins, double barScale, ImPlotRange range, ImPlotHistogramFlags flags)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram_U32Ptr(Encoding.UTF8.GetBytes(labelId), values, count, bins, barScale, range, flags);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <returns>The double</returns>
        public static double PlotHistogram(string labelId, long[] values, int count)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram_S64Ptr(Encoding.UTF8.GetBytes(labelId), values, count, 0, 1.0, new ImPlotRange(), 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="bins">The bins</param>
        /// <returns>The double</returns>
        public static double PlotHistogram(string labelId, long[] values, int count, int bins)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram_S64Ptr(Encoding.UTF8.GetBytes(labelId), values, count, bins, 1.0, new ImPlotRange(), 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="bins">The bins</param>
        /// <param name="barScale">The bar scale</param>
        /// <returns>The double</returns>
        public static double PlotHistogram(string labelId, long[] values, int count, int bins, double barScale)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram_S64Ptr(Encoding.UTF8.GetBytes(labelId), values, count, bins, barScale, new ImPlotRange(), 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="bins">The bins</param>
        /// <param name="barScale">The bar scale</param>
        /// <param name="range">The range</param>
        /// <returns>The double</returns>
        public static double PlotHistogram(string labelId, long[] values, int count, int bins, double barScale, ImPlotRange range)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram_S64Ptr(Encoding.UTF8.GetBytes(labelId), values, count, bins, barScale, range, 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="bins">The bins</param>
        /// <param name="barScale">The bar scale</param>
        /// <param name="range">The range</param>
        /// <param name="flags">The flags</param>
        /// <returns>The double</returns>
        public static double PlotHistogram(string labelId, long[] values, int count, int bins, double barScale, ImPlotRange range, ImPlotHistogramFlags flags)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram_S64Ptr(Encoding.UTF8.GetBytes(labelId), values, count, bins, barScale, range, flags);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <returns>The double</returns>
        public static double PlotHistogram(string labelId, ulong[] values, int count)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram_U64Ptr(Encoding.UTF8.GetBytes(labelId), values, count, 0, 1.0, new ImPlotRange(), 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="bins">The bins</param>
        /// <returns>The double</returns>
        public static double PlotHistogram(string labelId, ulong[] values, int count, int bins)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram_U64Ptr(Encoding.UTF8.GetBytes(labelId), values, count, bins, 1.0, new ImPlotRange(), 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="bins">The bins</param>
        /// <param name="barScale">The bar scale</param>
        /// <returns>The double</returns>
        public static double PlotHistogram(string labelId, ulong[] values, int count, int bins, double barScale)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram_U64Ptr(Encoding.UTF8.GetBytes(labelId), values, count, bins, barScale, new ImPlotRange(), 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="bins">The bins</param>
        /// <param name="barScale">The bar scale</param>
        /// <param name="range">The range</param>
        /// <returns>The double</returns>
        public static double PlotHistogram(string labelId, ulong[] values, int count, int bins, double barScale, ImPlotRange range)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram_U64Ptr(Encoding.UTF8.GetBytes(labelId), values, count, bins, barScale, range, 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="bins">The bins</param>
        /// <param name="barScale">The bar scale</param>
        /// <param name="range">The range</param>
        /// <param name="flags">The flags</param>
        /// <returns>The double</returns>
        public static double PlotHistogram(string labelId, ulong[] values, int count, int bins, double barScale, ImPlotRange range, ImPlotHistogramFlags flags)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram_U64Ptr(Encoding.UTF8.GetBytes(labelId), values, count, bins, barScale, range, flags);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <returns>The double</returns>
        public static double PlotHistogram2D(string labelId, ref float xs, ref float ys, int count)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram2D_FloatPtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, 0, 0, new ImPlotRect(), 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="xBins">The bins</param>
        /// <returns>The double</returns>
        public static double PlotHistogram2D(string labelId, ref float xs, ref float ys, int count, int xBins)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram2D_FloatPtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, xBins, 0, new ImPlotRect(), 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="xBins">The bins</param>
        /// <param name="yBins">The bins</param>
        /// <returns>The double</returns>
        public static double PlotHistogram2D(string labelId, ref float xs, ref float ys, int count, int xBins, int yBins)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram2D_FloatPtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, xBins, yBins, new ImPlotRect(), 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="xBins">The bins</param>
        /// <param name="yBins">The bins</param>
        /// <param name="range">The range</param>
        /// <returns>The double</returns>
        public static double PlotHistogram2D(string labelId, ref float xs, ref float ys, int count, int xBins, int yBins, ImPlotRect range)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram2D_FloatPtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, xBins, yBins, range, 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="xBins">The bins</param>
        /// <param name="yBins">The bins</param>
        /// <param name="range">The range</param>
        /// <param name="flags">The flags</param>
        /// <returns>The double</returns>
        public static double PlotHistogram2D(string labelId, ref float xs, ref float ys, int count, int xBins, int yBins, ImPlotRect range, ImPlotHistogramFlags flags)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram2D_FloatPtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, xBins, yBins, range, flags);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <returns>The double</returns>
        public static double PlotHistogram2D(string labelId, ref double xs, ref double ys, int count)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram2D_doublePtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, 0, 0, new ImPlotRect(), 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="xBins">The bins</param>
        /// <returns>The double</returns>
        public static double PlotHistogram2D(string labelId, ref double xs, ref double ys, int count, int xBins)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram2D_doublePtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, xBins, 0, new ImPlotRect(), 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="xBins">The bins</param>
        /// <param name="yBins">The bins</param>
        /// <returns>The double</returns>
        public static double PlotHistogram2D(string labelId, ref double xs, ref double ys, int count, int xBins, int yBins)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram2D_doublePtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, xBins, yBins, new ImPlotRect(), 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="xBins">The bins</param>
        /// <param name="yBins">The bins</param>
        /// <param name="range">The range</param>
        /// <returns>The double</returns>
        public static double PlotHistogram2D(string labelId, ref double xs, ref double ys, int count, int xBins, int yBins, ImPlotRect range)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram2D_doublePtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, xBins, yBins, range, 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="xBins">The bins</param>
        /// <param name="yBins">The bins</param>
        /// <param name="range">The range</param>
        /// <param name="flags">The flags</param>
        /// <returns>The double</returns>
        public static double PlotHistogram2D(string labelId, ref double xs, ref double ys, int count, int xBins, int yBins, ImPlotRect range, ImPlotHistogramFlags flags)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram2D_doublePtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, xBins, yBins, range, flags);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <returns>The double</returns>
        public static double PlotHistogram2D(string labelId, ref sbyte xs, ref sbyte ys, int count)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram2D_S8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, 0, 0, new ImPlotRect(), 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="xBins">The bins</param>
        /// <returns>The double</returns>
        public static double PlotHistogram2D(string labelId, ref sbyte xs, ref sbyte ys, int count, int xBins)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram2D_S8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, xBins, 0, new ImPlotRect(), 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="xBins">The bins</param>
        /// <param name="yBins">The bins</param>
        /// <returns>The double</returns>
        public static double PlotHistogram2D(string labelId, ref sbyte xs, ref sbyte ys, int count, int xBins, int yBins)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram2D_S8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, xBins, yBins, new ImPlotRect(), 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="xBins">The bins</param>
        /// <param name="yBins">The bins</param>
        /// <param name="range">The range</param>
        /// <returns>The double</returns>
        public static double PlotHistogram2D(string labelId, ref sbyte xs, ref sbyte ys, int count, int xBins, int yBins, ImPlotRect range)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram2D_S8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, xBins, yBins, range, 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="xBins">The bins</param>
        /// <param name="yBins">The bins</param>
        /// <param name="range">The range</param>
        /// <param name="flags">The flags</param>
        /// <returns>The double</returns>
        public static double PlotHistogram2D(string labelId, ref sbyte xs, ref sbyte ys, int count, int xBins, int yBins, ImPlotRect range, ImPlotHistogramFlags flags)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram2D_S8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, xBins, yBins, range, flags);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <returns>The double</returns>
        public static double PlotHistogram2D(string labelId, ref byte xs, ref byte ys, int count)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram2D_U8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, 0, 0, new ImPlotRect(), 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="xBins">The bins</param>
        /// <returns>The double</returns>
        public static double PlotHistogram2D(string labelId, ref byte xs, ref byte ys, int count, int xBins)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram2D_U8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, xBins, 0, new ImPlotRect(), 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram 2 d using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="xBins">The bins</param>
        /// <param name="yBins">The bins</param>
        /// <returns>The double</returns>
        public static double PlotHistogram2D(string labelId, ref byte xs, ref byte ys, int count, int xBins, int yBins)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram2D_U8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, xBins, yBins, new ImPlotRect(), 0);
            return ret;
        }
    }
}