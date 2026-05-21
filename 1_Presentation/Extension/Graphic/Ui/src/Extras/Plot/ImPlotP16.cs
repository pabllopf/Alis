

using System.Text;

namespace Alis.Extension.Graphic.Ui.Extras.Plot
{
    /// <summary>
    ///     The im plot class
    /// </summary>
    public static partial class ImPlot
    {
        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        public static void PlotBars(string labelId, uint[] values, int count, double barSize)
        {
            ImPlotNative.ImPlot_PlotBars_U32PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, barSize, 0, 0, 0, sizeof(uint));
        }

        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="shift">The shift</param>
        public static void PlotBars(string labelId, uint[] values, int count, double barSize, double shift)
        {
            ImPlotNative.ImPlot_PlotBars_U32PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, barSize, shift, 0, 0, sizeof(uint));
        }

        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="shift">The shift</param>
        /// <param name="flags">The flags</param>
        public static void PlotBars(string labelId, uint[] values, int count, double barSize, double shift, ImPlotBarsFlags flags)
        {
            ImPlotNative.ImPlot_PlotBars_U32PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, barSize, shift, flags, 0, sizeof(uint));
        }

        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="shift">The shift</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotBars(string labelId, uint[] values, int count, double barSize, double shift, ImPlotBarsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotBars_U32PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, barSize, shift, flags, offset, sizeof(uint));
        }

        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="shift">The shift</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotBars(string labelId, uint[] values, int count, double barSize, double shift, ImPlotBarsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotBars_U32PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, barSize, shift, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotBars(string labelId, long[] values, int count)
        {
            ImPlotNative.ImPlot_PlotBars_S64PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, 0.67, 0, 0, 0, sizeof(long));
        }

        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        public static void PlotBars(string labelId, long[] values, int count, double barSize)
        {
            ImPlotNative.ImPlot_PlotBars_S64PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, barSize, 0, 0, 0, sizeof(long));
        }

        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="shift">The shift</param>
        public static void PlotBars(string labelId, long[] values, int count, double barSize, double shift)
        {
            ImPlotNative.ImPlot_PlotBars_S64PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, barSize, shift, 0, 0, sizeof(long));
        }

        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="shift">The shift</param>
        /// <param name="flags">The flags</param>
        public static void PlotBars(string labelId, long[] values, int count, double barSize, double shift, ImPlotBarsFlags flags)
        {
            ImPlotNative.ImPlot_PlotBars_S64PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, barSize, shift, flags, 0, sizeof(long));
        }

        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="shift">The shift</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotBars(string labelId, long[] values, int count, double barSize, double shift, ImPlotBarsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotBars_S64PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, barSize, shift, flags, offset, sizeof(long));
        }

        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="shift">The shift</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotBars(string labelId, long[] values, int count, double barSize, double shift, ImPlotBarsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotBars_S64PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, barSize, shift, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotBars(string labelId, ulong[] values, int count)
        {
            ImPlotNative.ImPlot_PlotBars_U64PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, 0.67, 0, 0, 0, sizeof(ulong));
        }

        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        public static void PlotBars(string labelId, ulong[] values, int count, double barSize)
        {
            ImPlotNative.ImPlot_PlotBars_U64PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, barSize, 0, 0, 0, sizeof(ulong));
        }

        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="shift">The shift</param>
        public static void PlotBars(string labelId, ulong[] values, int count, double barSize, double shift)
        {
            ImPlotNative.ImPlot_PlotBars_U64PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, barSize, shift, 0, 0, sizeof(ulong));
        }

        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="shift">The shift</param>
        /// <param name="flags">The flags</param>
        public static void PlotBars(string labelId, ulong[] values, int count, double barSize, double shift, ImPlotBarsFlags flags)
        {
            ImPlotNative.ImPlot_PlotBars_U64PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, barSize, shift, flags, 0, sizeof(ulong));
        }

        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="shift">The shift</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotBars(string labelId, ulong[] values, int count, double barSize, double shift, ImPlotBarsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotBars_U64PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, barSize, shift, flags, offset, sizeof(ulong));
        }

        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="shift">The shift</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotBars(string labelId, ulong[] values, int count, double barSize, double shift, ImPlotBarsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotBars_U64PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, barSize, shift, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        public static void PlotBars(string labelId, ref float xs, ref float ys, int count, double barSize)
        {
            ImPlotNative.ImPlot_PlotBars_FloatPtrFloatPtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, barSize, 0, 0, sizeof(float));
        }

        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="flags">The flags</param>
        public static void PlotBars(string labelId, ref float xs, ref float ys, int count, double barSize, ImPlotBarsFlags flags)
        {
            ImPlotNative.ImPlot_PlotBars_FloatPtrFloatPtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, barSize, flags, 0, sizeof(float));
        }

        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotBars(string labelId, ref float xs, ref float ys, int count, double barSize, ImPlotBarsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotBars_FloatPtrFloatPtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, barSize, flags, offset, sizeof(float));
        }

        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotBars(string labelId, ref float xs, ref float ys, int count, double barSize, ImPlotBarsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotBars_FloatPtrFloatPtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, barSize, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        public static void PlotBars(string labelId, ref double xs, ref double ys, int count, double barSize)
        {
            ImPlotNative.ImPlot_PlotBars_doublePtrdoublePtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, barSize, 0, 0, sizeof(double));
        }

        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="flags">The flags</param>
        public static void PlotBars(string labelId, ref double xs, ref double ys, int count, double barSize, ImPlotBarsFlags flags)
        {
            ImPlotNative.ImPlot_PlotBars_doublePtrdoublePtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, barSize, flags, 0, sizeof(double));
        }

        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotBars(string labelId, ref double xs, ref double ys, int count, double barSize, ImPlotBarsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotBars_doublePtrdoublePtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, barSize, flags, offset, sizeof(double));
        }

        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotBars(string labelId, ref double xs, ref double ys, int count, double barSize, ImPlotBarsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotBars_doublePtrdoublePtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, barSize, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        public static void PlotBars(string labelId, ref sbyte xs, ref sbyte ys, int count, double barSize)
        {
            ImPlotNative.ImPlot_PlotBars_S8PtrS8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, barSize, 0, 0, sizeof(sbyte));
        }

        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="flags">The flags</param>
        public static void PlotBars(string labelId, ref sbyte xs, ref sbyte ys, int count, double barSize, ImPlotBarsFlags flags)
        {
            ImPlotNative.ImPlot_PlotBars_S8PtrS8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, barSize, flags, 0, sizeof(sbyte));
        }

        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotBars(string labelId, ref sbyte xs, ref sbyte ys, int count, double barSize, ImPlotBarsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotBars_S8PtrS8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, barSize, flags, offset, sizeof(sbyte));
        }

        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotBars(string labelId, ref sbyte xs, ref sbyte ys, int count, double barSize, ImPlotBarsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotBars_S8PtrS8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, barSize, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        public static void PlotBars(string labelId, ref byte xs, ref byte ys, int count, double barSize)
        {
            ImPlotNative.ImPlot_PlotBars_U8PtrU8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, barSize, 0, 0, sizeof(byte));
        }

        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="flags">The flags</param>
        public static void PlotBars(string labelId, ref byte xs, ref byte ys, int count, double barSize, ImPlotBarsFlags flags)
        {
            ImPlotNative.ImPlot_PlotBars_U8PtrU8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, barSize, flags, 0, sizeof(byte));
        }

        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotBars(string labelId, ref byte xs, ref byte ys, int count, double barSize, ImPlotBarsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotBars_U8PtrU8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, barSize, flags, offset, sizeof(byte));
        }

        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotBars(string labelId, ref byte xs, ref byte ys, int count, double barSize, ImPlotBarsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotBars_U8PtrU8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, barSize, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        public static void PlotBars(string labelId, ref short xs, ref short ys, int count, double barSize)
        {
            ImPlotNative.ImPlot_PlotBars_S16PtrS16Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, barSize, 0, 0, sizeof(short));
        }

        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="flags">The flags</param>
        public static void PlotBars(string labelId, ref short xs, ref short ys, int count, double barSize, ImPlotBarsFlags flags)
        {
            ImPlotNative.ImPlot_PlotBars_S16PtrS16Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, barSize, flags, 0, sizeof(short));
        }

        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotBars(string labelId, ref short xs, ref short ys, int count, double barSize, ImPlotBarsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotBars_S16PtrS16Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, barSize, flags, offset, sizeof(short));
        }

        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotBars(string labelId, ref short xs, ref short ys, int count, double barSize, ImPlotBarsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotBars_S16PtrS16Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, barSize, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        public static void PlotBars(string labelId, ref ushort xs, ref ushort ys, int count, double barSize)
        {
            ImPlotNative.ImPlot_PlotBars_U16PtrU16Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, barSize, 0, 0, sizeof(ushort));
        }

        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="flags">The flags</param>
        public static void PlotBars(string labelId, ref ushort xs, ref ushort ys, int count, double barSize, ImPlotBarsFlags flags)
        {
            ImPlotNative.ImPlot_PlotBars_U16PtrU16Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, barSize, flags, 0, sizeof(ushort));
        }

        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotBars(string labelId, ref ushort xs, ref ushort ys, int count, double barSize, ImPlotBarsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotBars_U16PtrU16Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, barSize, flags, offset, sizeof(ushort));
        }

        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotBars(string labelId, ref ushort xs, ref ushort ys, int count, double barSize, ImPlotBarsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotBars_U16PtrU16Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, barSize, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        public static void PlotBars(string labelId, ref int xs, ref int ys, int count, double barSize)
        {
            ImPlotNative.ImPlot_PlotBars_S32PtrS32Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, barSize, 0, 0, sizeof(int));
        }

        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="flags">The flags</param>
        public static void PlotBars(string labelId, ref int xs, ref int ys, int count, double barSize, ImPlotBarsFlags flags)
        {
            ImPlotNative.ImPlot_PlotBars_S32PtrS32Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, barSize, flags, 0, sizeof(int));
        }

        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotBars(string labelId, ref int xs, ref int ys, int count, double barSize, ImPlotBarsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotBars_S32PtrS32Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, barSize, flags, offset, sizeof(int));
        }

        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotBars(string labelId, ref int xs, ref int ys, int count, double barSize, ImPlotBarsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotBars_S32PtrS32Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, barSize, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        public static void PlotBars(string labelId, ref uint xs, ref uint ys, int count, double barSize)
        {
            ImPlotNative.ImPlot_PlotBars_U32PtrU32Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, barSize, 0, 0, sizeof(uint));
        }

        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="flags">The flags</param>
        public static void PlotBars(string labelId, ref uint xs, ref uint ys, int count, double barSize, ImPlotBarsFlags flags)
        {
            ImPlotNative.ImPlot_PlotBars_U32PtrU32Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, barSize, flags, 0, sizeof(uint));
        }

        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotBars(string labelId, ref uint xs, ref uint ys, int count, double barSize, ImPlotBarsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotBars_U32PtrU32Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, barSize, flags, offset, sizeof(uint));
        }

        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotBars(string labelId, ref uint xs, ref uint ys, int count, double barSize, ImPlotBarsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotBars_U32PtrU32Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, barSize, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        public static void PlotBars(string labelId, ref long xs, ref long ys, int count, double barSize)
        {
            ImPlotNative.ImPlot_PlotBars_S64PtrS64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, barSize, 0, 0, sizeof(long));
        }

        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="flags">The flags</param>
        public static void PlotBars(string labelId, ref long xs, ref long ys, int count, double barSize, ImPlotBarsFlags flags)
        {
            ImPlotNative.ImPlot_PlotBars_S64PtrS64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, barSize, flags, 0, sizeof(long));
        }

        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotBars(string labelId, ref long xs, ref long ys, int count, double barSize, ImPlotBarsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotBars_S64PtrS64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, barSize, flags, offset, sizeof(long));
        }
    }
}