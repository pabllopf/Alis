

using System.Text;

namespace Alis.Extension.Graphic.Ui.Extras.Plot
{
    /// <summary>
    ///     The im plot class
    /// </summary>
    public static partial class ImPlot
    {
        /// <summary>
        ///     Plots the heatmap using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        /// <param name="labelFmt">The label fmt</param>
        /// <param name="boundsMin">The bounds min</param>
        public static void PlotHeatmap(string labelId, double[] values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt, ImPlotPoint boundsMin)
        {
            ImPlotNative.ImPlot_PlotHeatmap_doublePtr(Encoding.UTF8.GetBytes(labelId), values, rows, cols, scaleMin, scaleMax, Encoding.UTF8.GetBytes(labelFmt), boundsMin, new ImPlotPoint(), ImPlotHeatmapFlags.None);
        }

        /// <summary>
        ///     Plots the heatmap using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        /// <param name="labelFmt">The label fmt</param>
        /// <param name="boundsMin">The bounds min</param>
        /// <param name="boundsMax">The bounds max</param>
        public static void PlotHeatmap(string labelId, double[] values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt, ImPlotPoint boundsMin, ImPlotPoint boundsMax)
        {
            ImPlotNative.ImPlot_PlotHeatmap_doublePtr(Encoding.UTF8.GetBytes(labelId), values, rows, cols, scaleMin, scaleMax, Encoding.UTF8.GetBytes(labelFmt), boundsMin, boundsMax, ImPlotHeatmapFlags.None);
        }

        /// <summary>
        ///     Plots the heatmap using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        /// <param name="labelFmt">The label fmt</param>
        /// <param name="boundsMin">The bounds min</param>
        /// <param name="boundsMax">The bounds max</param>
        /// <param name="flags">The flags</param>
        public static void PlotHeatmap(string labelId, double[] values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt, ImPlotPoint boundsMin, ImPlotPoint boundsMax, ImPlotHeatmapFlags flags)
        {
            ImPlotNative.ImPlot_PlotHeatmap_doublePtr(Encoding.UTF8.GetBytes(labelId), values, rows, cols, scaleMin, scaleMax, Encoding.UTF8.GetBytes(labelFmt), boundsMin, boundsMax, flags);
        }

        /// <summary>
        ///     Plots the heatmap using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        public static void PlotHeatmap(string labelId, sbyte[] values, int rows, int cols)
        {
            ImPlotNative.ImPlot_PlotHeatmap_S8Ptr(Encoding.UTF8.GetBytes(labelId), values, rows, cols, 0, 0, Encoding.UTF8.GetBytes("%.1f"), new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}, ImPlotHeatmapFlags.None);
        }

        /// <summary>
        ///     Plots the heatmap using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="scaleMin">The scale min</param>
        public static void PlotHeatmap(string labelId, sbyte[] values, int rows, int cols, double scaleMin)
        {
            ImPlotNative.ImPlot_PlotHeatmap_S8Ptr(Encoding.UTF8.GetBytes(labelId), values, rows, cols, scaleMin, 0, Encoding.UTF8.GetBytes("%.1f"), new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}, ImPlotHeatmapFlags.None);
        }

        /// <summary>
        ///     Plots the heatmap using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        public static void PlotHeatmap(string labelId, sbyte[] values, int rows, int cols, double scaleMin, double scaleMax)
        {
            ImPlotNative.ImPlot_PlotHeatmap_S8Ptr(Encoding.UTF8.GetBytes(labelId), values, rows, cols, scaleMin, scaleMax, Encoding.UTF8.GetBytes("%.1f"), new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}, ImPlotHeatmapFlags.None);
        }

        /// <summary>
        ///     Plots the heatmap using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        /// <param name="labelFmt">The label fmt</param>
        public static void PlotHeatmap(string labelId, sbyte[] values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt)
        {
            ImPlotNative.ImPlot_PlotHeatmap_S8Ptr(Encoding.UTF8.GetBytes(labelId), values, rows, cols, scaleMin, scaleMax, Encoding.UTF8.GetBytes(labelFmt), new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}, ImPlotHeatmapFlags.None);
        }

        /// <summary>
        ///     Plots the heatmap using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        /// <param name="labelFmt">The label fmt</param>
        /// <param name="boundsMin">The bounds min</param>
        public static void PlotHeatmap(string labelId, sbyte[] values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt, ImPlotPoint boundsMin)
        {
            ImPlotNative.ImPlot_PlotHeatmap_S8Ptr(Encoding.UTF8.GetBytes(labelId), values, rows, cols, scaleMin, scaleMax, Encoding.UTF8.GetBytes(labelFmt), boundsMin, new ImPlotPoint {X = 1, Y = 1}, ImPlotHeatmapFlags.None);
        }

        /// <summary>
        ///     Plots the heatmap using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        /// <param name="labelFmt">The label fmt</param>
        /// <param name="boundsMin">The bounds min</param>
        /// <param name="boundsMax">The bounds max</param>
        public static void PlotHeatmap(string labelId, sbyte[] values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt, ImPlotPoint boundsMin, ImPlotPoint boundsMax)
        {
            ImPlotNative.ImPlot_PlotHeatmap_S8Ptr(Encoding.UTF8.GetBytes(labelId), values, rows, cols, scaleMin, scaleMax, Encoding.UTF8.GetBytes(labelFmt), boundsMin, boundsMax, ImPlotHeatmapFlags.None);
        }

        /// <summary>
        ///     Plots the heatmap using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        /// <param name="labelFmt">The label fmt</param>
        /// <param name="boundsMin">The bounds min</param>
        /// <param name="boundsMax">The bounds max</param>
        /// <param name="flags">The flags</param>
        public static void PlotHeatmap(string labelId, sbyte[] values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt, ImPlotPoint boundsMin, ImPlotPoint boundsMax, ImPlotHeatmapFlags flags)
        {
            ImPlotNative.ImPlot_PlotHeatmap_S8Ptr(Encoding.UTF8.GetBytes(labelId), values, rows, cols, scaleMin, scaleMax, Encoding.UTF8.GetBytes(labelFmt), boundsMin, boundsMax, flags);
        }

        /// <summary>
        ///     Plots the heatmap using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        public static void PlotHeatmap(string labelId, byte[] values, int rows, int cols)
        {
            ImPlotNative.ImPlot_PlotHeatmap_U8Ptr(Encoding.UTF8.GetBytes(labelId), values, rows, cols, 0, 0, Encoding.UTF8.GetBytes("%.1f"), new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}, ImPlotHeatmapFlags.None);
        }

        /// <summary>
        ///     Plots the heatmap using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="scaleMin">The scale min</param>
        public static void PlotHeatmap(string labelId, byte[] values, int rows, int cols, double scaleMin)
        {
            ImPlotNative.ImPlot_PlotHeatmap_U8Ptr(Encoding.UTF8.GetBytes(labelId), values, rows, cols, scaleMin, 0, Encoding.UTF8.GetBytes("%.1f"), new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}, ImPlotHeatmapFlags.None);
        }

        /// <summary>
        ///     Plots the heatmap using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        public static void PlotHeatmap(string labelId, byte[] values, int rows, int cols, double scaleMin, double scaleMax)
        {
            ImPlotNative.ImPlot_PlotHeatmap_U8Ptr(Encoding.UTF8.GetBytes(labelId), values, rows, cols, scaleMin, scaleMax, Encoding.UTF8.GetBytes("%.1f"), new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}, ImPlotHeatmapFlags.None);
        }

        /// <summary>
        ///     Plots the heatmap using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        /// <param name="labelFmt">The label fmt</param>
        public static void PlotHeatmap(string labelId, byte[] values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt)
        {
            ImPlotNative.ImPlot_PlotHeatmap_U8Ptr(Encoding.UTF8.GetBytes(labelId), values, rows, cols, scaleMin, scaleMax, Encoding.UTF8.GetBytes(labelFmt), new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}, ImPlotHeatmapFlags.None);
        }

        /// <summary>
        ///     Plots the heatmap using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        /// <param name="labelFmt">The label fmt</param>
        /// <param name="boundsMin">The bounds min</param>
        public static void PlotHeatmap(string labelId, byte[] values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt, ImPlotPoint boundsMin)
        {
            ImPlotNative.ImPlot_PlotHeatmap_U8Ptr(Encoding.UTF8.GetBytes(labelId), values, rows, cols, scaleMin, scaleMax, Encoding.UTF8.GetBytes(labelFmt), boundsMin, new ImPlotPoint {X = 1, Y = 1}, ImPlotHeatmapFlags.None);
        }

        /// <summary>
        ///     Plots the heatmap using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        /// <param name="labelFmt">The label fmt</param>
        /// <param name="boundsMin">The bounds min</param>
        /// <param name="boundsMax">The bounds max</param>
        public static void PlotHeatmap(string labelId, byte[] values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt, ImPlotPoint boundsMin, ImPlotPoint boundsMax)
        {
            ImPlotNative.ImPlot_PlotHeatmap_U8Ptr(Encoding.UTF8.GetBytes(labelId), values, rows, cols, scaleMin, scaleMax, Encoding.UTF8.GetBytes(labelFmt), boundsMin, boundsMax, ImPlotHeatmapFlags.None);
        }

        /// <summary>
        ///     Plots the heatmap using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        /// <param name="labelFmt">The label fmt</param>
        /// <param name="boundsMin">The bounds min</param>
        /// <param name="boundsMax">The bounds max</param>
        /// <param name="flags">The flags</param>
        public static void PlotHeatmap(string labelId, byte[] values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt, ImPlotPoint boundsMin, ImPlotPoint boundsMax, ImPlotHeatmapFlags flags)
        {
            ImPlotNative.ImPlot_PlotHeatmap_U8Ptr(Encoding.UTF8.GetBytes(labelId), values, rows, cols, scaleMin, scaleMax, Encoding.UTF8.GetBytes(labelFmt), boundsMin, boundsMax, flags);
        }

        /// <summary>
        ///     Plots the heatmap using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        public static void PlotHeatmap(string labelId, short[] values, int rows, int cols)
        {
            ImPlotNative.ImPlot_PlotHeatmap_S16Ptr(Encoding.UTF8.GetBytes(labelId), values, rows, cols, 0, 0, Encoding.UTF8.GetBytes("%.1f"), new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}, ImPlotHeatmapFlags.None);
        }

        /// <summary>
        ///     Plots the heatmap using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="scaleMin">The scale min</param>
        public static void PlotHeatmap(string labelId, short[] values, int rows, int cols, double scaleMin)
        {
            ImPlotNative.ImPlot_PlotHeatmap_S16Ptr(Encoding.UTF8.GetBytes(labelId), values, rows, cols, scaleMin, 0, Encoding.UTF8.GetBytes("%.1f"), new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}, ImPlotHeatmapFlags.None);
        }

        /// <summary>
        ///     Plots the heatmap using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        public static void PlotHeatmap(string labelId, short[] values, int rows, int cols, double scaleMin, double scaleMax)
        {
            ImPlotNative.ImPlot_PlotHeatmap_S16Ptr(Encoding.UTF8.GetBytes(labelId), values, rows, cols, scaleMin, scaleMax, Encoding.UTF8.GetBytes("%.1f"), new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}, ImPlotHeatmapFlags.None);
        }

        /// <summary>
        ///     Plots the heatmap using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        /// <param name="labelFmt">The label fmt</param>
        public static void PlotHeatmap(string labelId, short[] values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt)
        {
            ImPlotNative.ImPlot_PlotHeatmap_S16Ptr(Encoding.UTF8.GetBytes(labelId), values, rows, cols, scaleMin, scaleMax, Encoding.UTF8.GetBytes(labelFmt), new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}, ImPlotHeatmapFlags.None);
        }

        /// <summary>
        ///     Plots the heatmap using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        /// <param name="labelFmt">The label fmt</param>
        /// <param name="boundsMin">The bounds min</param>
        public static void PlotHeatmap(string labelId, short[] values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt, ImPlotPoint boundsMin)
        {
            ImPlotNative.ImPlot_PlotHeatmap_S16Ptr(Encoding.UTF8.GetBytes(labelId), values, rows, cols, scaleMin, scaleMax, Encoding.UTF8.GetBytes(labelFmt), boundsMin, new ImPlotPoint {X = 1, Y = 1}, ImPlotHeatmapFlags.None);
        }

        /// <summary>
        ///     Plots the heatmap using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        /// <param name="labelFmt">The label fmt</param>
        /// <param name="boundsMin">The bounds min</param>
        /// <param name="boundsMax">The bounds max</param>
        public static void PlotHeatmap(string labelId, short[] values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt, ImPlotPoint boundsMin, ImPlotPoint boundsMax)
        {
            ImPlotNative.ImPlot_PlotHeatmap_S16Ptr(Encoding.UTF8.GetBytes(labelId), values, rows, cols, scaleMin, scaleMax, Encoding.UTF8.GetBytes(labelFmt), boundsMin, boundsMax, ImPlotHeatmapFlags.None);
        }

        /// <summary>
        ///     Plots the heatmap using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        /// <param name="labelFmt">The label fmt</param>
        /// <param name="boundsMin">The bounds min</param>
        /// <param name="boundsMax">The bounds max</param>
        /// <param name="flags">The flags</param>
        public static void PlotHeatmap(string labelId, short[] values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt, ImPlotPoint boundsMin, ImPlotPoint boundsMax, ImPlotHeatmapFlags flags)
        {
            ImPlotNative.ImPlot_PlotHeatmap_S16Ptr(Encoding.UTF8.GetBytes(labelId), values, rows, cols, scaleMin, scaleMax, Encoding.UTF8.GetBytes(labelFmt), boundsMin, boundsMax, flags);
        }

        /// <summary>
        ///     Plots the heatmap using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        public static void PlotHeatmap(string labelId, ushort[] values, int rows, int cols)
        {
            ImPlotNative.ImPlot_PlotHeatmap_U16Ptr(Encoding.UTF8.GetBytes(labelId), values, rows, cols, 0, 0, Encoding.UTF8.GetBytes("%.1f"), new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}, ImPlotHeatmapFlags.None);
        }

        /// <summary>
        ///     Plots the heatmap using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="scaleMin">The scale min</param>
        public static void PlotHeatmap(string labelId, ushort[] values, int rows, int cols, double scaleMin)
        {
            ImPlotNative.ImPlot_PlotHeatmap_U16Ptr(Encoding.UTF8.GetBytes(labelId), values, rows, cols, scaleMin, 0, Encoding.UTF8.GetBytes("%.1f"), new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}, ImPlotHeatmapFlags.None);
        }

        /// <summary>
        ///     Plots the heatmap using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        public static void PlotHeatmap(string labelId, ushort[] values, int rows, int cols, double scaleMin, double scaleMax)
        {
            ImPlotNative.ImPlot_PlotHeatmap_U16Ptr(Encoding.UTF8.GetBytes(labelId), values, rows, cols, scaleMin, scaleMax, Encoding.UTF8.GetBytes("%.1f"), new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}, ImPlotHeatmapFlags.None);
        }

        /// <summary>
        ///     Plots the heatmap using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        /// <param name="labelFmt">The label fmt</param>
        public static void PlotHeatmap(string labelId, ushort[] values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt)
        {
            ImPlotNative.ImPlot_PlotHeatmap_U16Ptr(Encoding.UTF8.GetBytes(labelId), values, rows, cols, scaleMin, scaleMax, Encoding.UTF8.GetBytes(labelFmt), new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}, ImPlotHeatmapFlags.None);
        }

        /// <summary>
        ///     Plots the heatmap using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        /// <param name="labelFmt">The label fmt</param>
        /// <param name="boundsMin">The bounds min</param>
        public static void PlotHeatmap(string labelId, ushort[] values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt, ImPlotPoint boundsMin)
        {
            ImPlotNative.ImPlot_PlotHeatmap_U16Ptr(Encoding.UTF8.GetBytes(labelId), values, rows, cols, scaleMin, scaleMax, Encoding.UTF8.GetBytes(labelFmt), boundsMin, new ImPlotPoint {X = 1, Y = 1}, ImPlotHeatmapFlags.None);
        }

        /// <summary>
        ///     Plots the heatmap using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        /// <param name="labelFmt">The label fmt</param>
        /// <param name="boundsMin">The bounds min</param>
        /// <param name="boundsMax">The bounds max</param>
        public static void PlotHeatmap(string labelId, ushort[] values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt, ImPlotPoint boundsMin, ImPlotPoint boundsMax)
        {
            ImPlotNative.ImPlot_PlotHeatmap_U16Ptr(Encoding.UTF8.GetBytes(labelId), values, rows, cols, scaleMin, scaleMax, Encoding.UTF8.GetBytes(labelFmt), boundsMin, boundsMax, ImPlotHeatmapFlags.None);
        }

        /// <summary>
        ///     Plots the heatmap using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        /// <param name="labelFmt">The label fmt</param>
        /// <param name="boundsMin">The bounds min</param>
        /// <param name="boundsMax">The bounds max</param>
        /// <param name="flags">The flags</param>
        public static void PlotHeatmap(string labelId, ushort[] values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt, ImPlotPoint boundsMin, ImPlotPoint boundsMax, ImPlotHeatmapFlags flags)
        {
            ImPlotNative.ImPlot_PlotHeatmap_U16Ptr(Encoding.UTF8.GetBytes(labelId), values, rows, cols, scaleMin, scaleMax, Encoding.UTF8.GetBytes(labelFmt), boundsMin, boundsMax, flags);
        }

        /// <summary>
        ///     Plots the heatmap using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        public static void PlotHeatmap(string labelId, int[] values, int rows, int cols)
        {
            ImPlotNative.ImPlot_PlotHeatmap_S32Ptr(Encoding.UTF8.GetBytes(labelId), values, rows, cols, 0, 0, Encoding.UTF8.GetBytes("%.1f"), new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}, ImPlotHeatmapFlags.None);
        }

        /// <summary>
        ///     Plots the heatmap using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="scaleMin">The scale min</param>
        public static void PlotHeatmap(string labelId, int[] values, int rows, int cols, double scaleMin)
        {
            ImPlotNative.ImPlot_PlotHeatmap_S32Ptr(Encoding.UTF8.GetBytes(labelId), values, rows, cols, scaleMin, 0, Encoding.UTF8.GetBytes("%.1f"), new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}, ImPlotHeatmapFlags.None);
        }

        /// <summary>
        ///     Plots the heatmap using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        public static void PlotHeatmap(string labelId, int[] values, int rows, int cols, double scaleMin, double scaleMax)
        {
            ImPlotNative.ImPlot_PlotHeatmap_S32Ptr(Encoding.UTF8.GetBytes(labelId), values, rows, cols, scaleMin, scaleMax, Encoding.UTF8.GetBytes("%.1f"), new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}, ImPlotHeatmapFlags.None);
        }

        /// <summary>
        ///     Plots the heatmap using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        /// <param name="labelFmt">The label fmt</param>
        public static void PlotHeatmap(string labelId, int[] values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt)
        {
            ImPlotNative.ImPlot_PlotHeatmap_S32Ptr(Encoding.UTF8.GetBytes(labelId), values, rows, cols, scaleMin, scaleMax, Encoding.UTF8.GetBytes(labelFmt), new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}, ImPlotHeatmapFlags.None);
        }

        /// <summary>
        ///     Plots the heatmap using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        /// <param name="labelFmt">The label fmt</param>
        /// <param name="boundsMin">The bounds min</param>
        public static void PlotHeatmap(string labelId, int[] values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt, ImPlotPoint boundsMin)
        {
            ImPlotNative.ImPlot_PlotHeatmap_S32Ptr(Encoding.UTF8.GetBytes(labelId), values, rows, cols, scaleMin, scaleMax, Encoding.UTF8.GetBytes(labelFmt), boundsMin, new ImPlotPoint {X = 1, Y = 1}, ImPlotHeatmapFlags.None);
        }
    }
}