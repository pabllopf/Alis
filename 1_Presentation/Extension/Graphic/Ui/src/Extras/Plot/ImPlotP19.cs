

using System.Text;

namespace Alis.Extension.Graphic.Ui.Extras.Plot
{
    /// <summary>
    ///     The im plot class
    /// </summary>
    public static partial class ImPlot
    {
        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        public static void PlotStairs(string labelId, byte[] values, int count, double xscale, double xstart, ImPlotStairsFlags flags)
        {
            ImPlotNative.ImPlot_PlotStairs_U8PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, 0, sizeof(byte));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotStairs(string labelId, byte[] values, int count, double xscale, double xstart, ImPlotStairsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotStairs_U8PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, offset, sizeof(byte));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotStairs(string labelId, byte[] values, int count, double xscale, double xstart, ImPlotStairsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotStairs_U8PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotStairs(string labelId, short[] values, int count)
        {
            ImPlotNative.ImPlot_PlotStairs_S16PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, 1, 0, 0, 0, sizeof(short));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        public static void PlotStairs(string labelId, short[] values, int count, double xscale)
        {
            ImPlotNative.ImPlot_PlotStairs_S16PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, 0, 0, 0, sizeof(short));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        public static void PlotStairs(string labelId, short[] values, int count, double xscale, double xstart)
        {
            ImPlotNative.ImPlot_PlotStairs_S16PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, 0, 0, sizeof(short));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        public static void PlotStairs(string labelId, short[] values, int count, double xscale, double xstart, ImPlotStairsFlags flags)
        {
            ImPlotNative.ImPlot_PlotStairs_S16PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, 0, sizeof(short));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotStairs(string labelId, short[] values, int count, double xscale, double xstart, ImPlotStairsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotStairs_S16PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, offset, sizeof(short));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotStairs(string labelId, short[] values, int count, double xscale, double xstart, ImPlotStairsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotStairs_S16PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotStairs(string labelId, ushort[] values, int count)
        {
            ImPlotNative.ImPlot_PlotStairs_U16PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, 1, 0, 0, 0, sizeof(ushort));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        public static void PlotStairs(string labelId, ushort[] values, int count, double xscale)
        {
            ImPlotNative.ImPlot_PlotStairs_U16PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, 0, 0, 0, sizeof(ushort));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        public static void PlotStairs(string labelId, ushort[] values, int count, double xscale, double xstart)
        {
            ImPlotNative.ImPlot_PlotStairs_U16PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, 0, 0, sizeof(ushort));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        public static void PlotStairs(string labelId, ushort[] values, int count, double xscale, double xstart, ImPlotStairsFlags flags)
        {
            ImPlotNative.ImPlot_PlotStairs_U16PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, 0, sizeof(ushort));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotStairs(string labelId, ushort[] values, int count, double xscale, double xstart, ImPlotStairsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotStairs_U16PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, offset, sizeof(ushort));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotStairs(string labelId, ushort[] values, int count, double xscale, double xstart, ImPlotStairsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotStairs_U16PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotStairs(string labelId, int[] values, int count)
        {
            ImPlotNative.ImPlot_PlotStairs_S32PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, 1, 0, 0, 0, sizeof(int));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        public static void PlotStairs(string labelId, int[] values, int count, double xscale)
        {
            ImPlotNative.ImPlot_PlotStairs_S32PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, 0, 0, 0, sizeof(int));
        }


        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        public static void PlotStairs(string labelId, int[] values, int count, double xscale, double xstart)
        {
            ImPlotNative.ImPlot_PlotStairs_S32PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, 0, 0, sizeof(int));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        public static void PlotStairs(string labelId, int[] values, int count, double xscale, double xstart, ImPlotStairsFlags flags)
        {
            ImPlotNative.ImPlot_PlotStairs_S32PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, 0, sizeof(int));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotStairs(string labelId, int[] values, int count, double xscale, double xstart, ImPlotStairsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotStairs_S32PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, offset, sizeof(int));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotStairs(string labelId, int[] values, int count, double xscale, double xstart, ImPlotStairsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotStairs_S32PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotStairs(string labelId, uint[] values, int count)
        {
            ImPlotNative.ImPlot_PlotStairs_U32PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, 1, 0, 0, 0, sizeof(uint));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        public static void PlotStairs(string labelId, uint[] values, int count, double xscale)
        {
            ImPlotNative.ImPlot_PlotStairs_U32PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, 0, 0, 0, sizeof(uint));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        public static void PlotStairs(string labelId, uint[] values, int count, double xscale, double xstart)
        {
            ImPlotNative.ImPlot_PlotStairs_U32PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, 0, 0, sizeof(uint));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        public static void PlotStairs(string labelId, uint[] values, int count, double xscale, double xstart, ImPlotStairsFlags flags)
        {
            ImPlotNative.ImPlot_PlotStairs_U32PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, 0, sizeof(uint));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotStairs(string labelId, uint[] values, int count, double xscale, double xstart, ImPlotStairsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotStairs_U32PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, offset, sizeof(uint));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotStairs(string labelId, uint[] values, int count, double xscale, double xstart, ImPlotStairsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotStairs_U32PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotStairs(string labelId, long[] values, int count)
        {
            ImPlotNative.ImPlot_PlotStairs_S64PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, 1, 0, 0, 0, sizeof(long));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        public static void PlotStairs(string labelId, long[] values, int count, double xscale)
        {
            ImPlotNative.ImPlot_PlotStairs_S64PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, 0, 0, 0, sizeof(long));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        public static void PlotStairs(string labelId, long[] values, int count, double xscale, double xstart)
        {
            ImPlotNative.ImPlot_PlotStairs_S64PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, 0, 0, sizeof(long));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        public static void PlotStairs(string labelId, long[] values, int count, double xscale, double xstart, ImPlotStairsFlags flags)
        {
            ImPlotNative.ImPlot_PlotStairs_S64PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, 0, sizeof(long));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotStairs(string labelId, long[] values, int count, double xscale, double xstart, ImPlotStairsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotStairs_S64PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, offset, sizeof(long));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotStairs(string labelId, long[] values, int count, double xscale, double xstart, ImPlotStairsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotStairs_S64PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotStairs(string labelId, ulong[] values, int count)
        {
            ImPlotNative.ImPlot_PlotStairs_U64PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, 1, 0, 0, 0, sizeof(ulong));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        public static void PlotStairs(string labelId, ulong[] values, int count, double xscale)
        {
            ImPlotNative.ImPlot_PlotStairs_U64PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, 0, 0, 0, sizeof(ulong));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        public static void PlotStairs(string labelId, ulong[] values, int count, double xscale, double xstart)
        {
            ImPlotNative.ImPlot_PlotStairs_U64PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, 0, 0, sizeof(ulong));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        public static void PlotStairs(string labelId, ulong[] values, int count, double xscale, double xstart, ImPlotStairsFlags flags)
        {
            ImPlotNative.ImPlot_PlotStairs_U64PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, 0, sizeof(ulong));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotStairs(string labelId, ulong[] values, int count, double xscale, double xstart, ImPlotStairsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotStairs_U64PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, offset, sizeof(ulong));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotStairs(string labelId, ulong[] values, int count, double xscale, double xstart, ImPlotStairsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotStairs_U64PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotStairs(string labelId, ref float xs, ref float ys, int count)
        {
            ImPlotNative.ImPlot_PlotStairs_FloatPtrFloatPtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, 0, 0, sizeof(float));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotStairs(string labelId, ref float xs, ref float ys, int count, ImPlotStairsFlags flags)
        {
            ImPlotNative.ImPlot_PlotStairs_FloatPtrFloatPtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, 0, sizeof(float));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotStairs(string labelId, ref float xs, ref float ys, int count, ImPlotStairsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotStairs_FloatPtrFloatPtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, sizeof(float));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotStairs(string labelId, ref float xs, ref float ys, int count, ImPlotStairsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotStairs_FloatPtrFloatPtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotStairs(string labelId, ref double xs, ref double ys, int count)
        {
            ImPlotNative.ImPlot_PlotStairs_doublePtrdoublePtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, 0, 0, sizeof(double));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotStairs(string labelId, ref double xs, ref double ys, int count, ImPlotStairsFlags flags)
        {
            ImPlotNative.ImPlot_PlotStairs_doublePtrdoublePtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, 0, sizeof(double));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotStairs(string labelId, ref double xs, ref double ys, int count, ImPlotStairsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotStairs_doublePtrdoublePtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, sizeof(double));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotStairs(string labelId, ref double xs, ref double ys, int count, ImPlotStairsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotStairs_doublePtrdoublePtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotStairs(string labelId, ref sbyte xs, ref sbyte ys, int count)
        {
            ImPlotNative.ImPlot_PlotStairs_S8PtrS8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, 0, 0, sizeof(sbyte));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotStairs(string labelId, ref sbyte xs, ref sbyte ys, int count, ImPlotStairsFlags flags)
        {
            ImPlotNative.ImPlot_PlotStairs_S8PtrS8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, 0, sizeof(sbyte));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotStairs(string labelId, ref sbyte xs, ref sbyte ys, int count, ImPlotStairsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotStairs_S8PtrS8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, sizeof(sbyte));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotStairs(string labelId, ref sbyte xs, ref sbyte ys, int count, ImPlotStairsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotStairs_S8PtrS8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotStairs(string labelId, ref byte xs, ref byte ys, int count)
        {
            ImPlotNative.ImPlot_PlotStairs_U8PtrU8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, 0, 0, sizeof(byte));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotStairs(string labelId, ref byte xs, ref byte ys, int count, ImPlotStairsFlags flags)
        {
            ImPlotNative.ImPlot_PlotStairs_U8PtrU8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, 0, sizeof(byte));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotStairs(string labelId, ref byte xs, ref byte ys, int count, ImPlotStairsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotStairs_U8PtrU8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, sizeof(byte));
        }
    }
}