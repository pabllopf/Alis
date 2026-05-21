

using System;
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
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotBars(string labelId, ref long xs, ref long ys, int count, double barSize, ImPlotBarsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotBars_S64PtrS64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, barSize, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        public static void PlotBars(string labelId, ref ulong xs, ref ulong ys, int count, double barSize)
        {
            ImPlotNative.ImPlot_PlotBars_U64PtrU64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, barSize, 0, 0, sizeof(ulong));
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
        public static void PlotBars(string labelId, ref ulong xs, ref ulong ys, int count, double barSize, ImPlotBarsFlags flags)
        {
            ImPlotNative.ImPlot_PlotBars_U64PtrU64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, barSize, flags, 0, sizeof(ulong));
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
        public static void PlotBars(string labelId, ref ulong xs, ref ulong ys, int count, double barSize, ImPlotBarsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotBars_U64PtrU64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, barSize, flags, offset, sizeof(ulong));
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
        public static void PlotBars(string labelId, ref ulong xs, ref ulong ys, int count, double barSize, ImPlotBarsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotBars_U64PtrU64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, barSize, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the bars g using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="getter">The getter</param>
        /// <param name="data">The data</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        public static void PlotBarsG(string labelId, IntPtr getter, IntPtr data, int count, double barSize)
        {
            ImPlotNative.ImPlot_PlotBarsG(Encoding.UTF8.GetBytes(labelId), getter, data, count, barSize, 0);
        }

        /// <summary>
        ///     Plots the bars g using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="getter">The getter</param>
        /// <param name="data">The data</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="flags">The flags</param>
        public static void PlotBarsG(string labelId, IntPtr getter, IntPtr data, int count, double barSize, ImPlotBarsFlags flags)
        {
            ImPlotNative.ImPlot_PlotBarsG(Encoding.UTF8.GetBytes(labelId), getter, data, count, barSize, flags);
        }

        /// <summary>
        ///     Plots the digital using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotDigital(string labelId, ref float xs, ref float ys, int count)
        {
            ImPlotNative.ImPlot_PlotDigital_FloatPtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, 0, 0, sizeof(float));
        }

        /// <summary>
        ///     Plots the digital using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotDigital(string labelId, ref float xs, ref float ys, int count, ImPlotDigitalFlags flags)
        {
            ImPlotNative.ImPlot_PlotDigital_FloatPtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, 0, sizeof(float));
        }

        /// <summary>
        ///     Plots the digital using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotDigital(string labelId, ref float xs, ref float ys, int count, ImPlotDigitalFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotDigital_FloatPtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, sizeof(float));
        }

        /// <summary>
        ///     Plots the digital using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotDigital(string labelId, ref float xs, ref float ys, int count, ImPlotDigitalFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotDigital_FloatPtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the digital using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotDigital(string labelId, ref double xs, ref double ys, int count)
        {
            ImPlotNative.ImPlot_PlotDigital_doublePtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, 0, 0, sizeof(double));
        }

        /// <summary>
        ///     Plots the digital using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotDigital(string labelId, ref double xs, ref double ys, int count, ImPlotDigitalFlags flags)
        {
            ImPlotNative.ImPlot_PlotDigital_doublePtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, 0, sizeof(double));
        }

        /// <summary>
        ///     Plots the digital using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotDigital(string labelId, ref double xs, ref double ys, int count, ImPlotDigitalFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotDigital_doublePtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, sizeof(double));
        }

        /// <summary>
        ///     Plots the digital using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotDigital(string labelId, ref double xs, ref double ys, int count, ImPlotDigitalFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotDigital_doublePtr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the digital using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotDigital(string labelId, ref sbyte xs, ref sbyte ys, int count)
        {
            ImPlotNative.ImPlot_PlotDigital_S8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, 0, 0, sizeof(sbyte));
        }

        /// <summary>
        ///     Plots the digital using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotDigital(string labelId, ref sbyte xs, ref sbyte ys, int count, ImPlotDigitalFlags flags)
        {
            ImPlotNative.ImPlot_PlotDigital_S8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, 0, sizeof(sbyte));
        }

        /// <summary>
        ///     Plots the digital using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotDigital(string labelId, ref sbyte xs, ref sbyte ys, int count, ImPlotDigitalFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotDigital_S8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, sizeof(sbyte));
        }

        /// <summary>
        ///     Plots the digital using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotDigital(string labelId, ref sbyte xs, ref sbyte ys, int count, ImPlotDigitalFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotDigital_S8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the digital using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotDigital(string labelId, ref byte xs, ref byte ys, int count)
        {
            ImPlotNative.ImPlot_PlotDigital_U8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, 0, 0, sizeof(byte));
        }

        /// <summary>
        ///     Plots the digital using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotDigital(string labelId, ref byte xs, ref byte ys, int count, ImPlotDigitalFlags flags)
        {
            ImPlotNative.ImPlot_PlotDigital_U8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, 0, sizeof(byte));
        }

        /// <summary>
        ///     Plots the digital using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotDigital(string labelId, ref byte xs, ref byte ys, int count, ImPlotDigitalFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotDigital_U8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, sizeof(byte));
        }

        /// <summary>
        ///     Plots the digital using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotDigital(string labelId, ref byte xs, ref byte ys, int count, ImPlotDigitalFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotDigital_U8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the digital using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotDigital(string labelId, ref short xs, ref short ys, int count)
        {
            ImPlotNative.ImPlot_PlotDigital_S16Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, 0, 0, sizeof(short));
        }

        /// <summary>
        ///     Plots the digital using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotDigital(string labelId, ref short xs, ref short ys, int count, ImPlotDigitalFlags flags)
        {
            ImPlotNative.ImPlot_PlotDigital_S16Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, 0, sizeof(short));
        }

        /// <summary>
        ///     Plots the digital using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotDigital(string labelId, ref short xs, ref short ys, int count, ImPlotDigitalFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotDigital_S16Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, sizeof(short));
        }

        /// <summary>
        ///     Plots the digital using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotDigital(string labelId, ref short xs, ref short ys, int count, ImPlotDigitalFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotDigital_S16Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the digital using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotDigital(string labelId, ref ushort xs, ref ushort ys, int count)
        {
            ImPlotNative.ImPlot_PlotDigital_U16Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, 0, 0, sizeof(ushort));
        }

        /// <summary>
        ///     Plots the digital using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotDigital(string labelId, ref ushort xs, ref ushort ys, int count, ImPlotDigitalFlags flags)
        {
            ImPlotNative.ImPlot_PlotDigital_U16Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, 0, sizeof(ushort));
        }

        /// <summary>
        ///     Plots the digital using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotDigital(string labelId, ref ushort xs, ref ushort ys, int count, ImPlotDigitalFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotDigital_U16Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, sizeof(ushort));
        }

        /// <summary>
        ///     Plots the digital using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotDigital(string labelId, ref ushort xs, ref ushort ys, int count, ImPlotDigitalFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotDigital_U16Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the digital using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotDigital(string labelId, ref int xs, ref int ys, int count)
        {
            ImPlotNative.ImPlot_PlotDigital_S32Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, 0, 0, sizeof(int));
        }

        /// <summary>
        ///     Plots the digital using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotDigital(string labelId, ref int xs, ref int ys, int count, ImPlotDigitalFlags flags)
        {
            ImPlotNative.ImPlot_PlotDigital_S32Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, 0, sizeof(int));
        }

        /// <summary>
        ///     Plots the digital using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotDigital(string labelId, ref int xs, ref int ys, int count, ImPlotDigitalFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotDigital_S32Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, sizeof(int));
        }

        /// <summary>
        ///     Plots the digital using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotDigital(string labelId, ref int xs, ref int ys, int count, ImPlotDigitalFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotDigital_S32Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the digital using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotDigital(string labelId, ref uint xs, ref uint ys, int count)
        {
            ImPlotNative.ImPlot_PlotDigital_U32Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, 0, 0, sizeof(uint));
        }

        /// <summary>
        ///     Plots the digital using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotDigital(string labelId, ref uint xs, ref uint ys, int count, ImPlotDigitalFlags flags)
        {
            ImPlotNative.ImPlot_PlotDigital_U32Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, 0, sizeof(uint));
        }

        /// <summary>
        ///     Plots the digital using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotDigital(string labelId, ref uint xs, ref uint ys, int count, ImPlotDigitalFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotDigital_U32Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, sizeof(uint));
        }

        /// <summary>
        ///     Plots the digital using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotDigital(string labelId, ref uint xs, ref uint ys, int count, ImPlotDigitalFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotDigital_U32Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the digital using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotDigital(string labelId, ref long xs, ref long ys, int count)
        {
            ImPlotNative.ImPlot_PlotDigital_S64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, 0, 0, sizeof(long));
        }

        /// <summary>
        ///     Plots the digital using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotDigital(string labelId, ref long xs, ref long ys, int count, ImPlotDigitalFlags flags)
        {
            ImPlotNative.ImPlot_PlotDigital_S64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, 0, sizeof(long));
        }

        /// <summary>
        ///     Plots the digital using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotDigital(string labelId, ref long xs, ref long ys, int count, ImPlotDigitalFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotDigital_S64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, sizeof(long));
        }

        /// <summary>
        ///     Plots the digital using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotDigital(string labelId, ref long xs, ref long ys, int count, ImPlotDigitalFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotDigital_S64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the digital using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotDigital(string labelId, ref ulong xs, ref ulong ys, int count)
        {
            ImPlotNative.ImPlot_PlotDigital_U64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, 0, 0, sizeof(ulong));
        }

        /// <summary>
        ///     Plots the digital using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotDigital(string labelId, ref ulong xs, ref ulong ys, int count, ImPlotDigitalFlags flags)
        {
            ImPlotNative.ImPlot_PlotDigital_U64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, 0, sizeof(ulong));
        }

        /// <summary>
        ///     Plots the digital using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotDigital(string labelId, ref ulong xs, ref ulong ys, int count, ImPlotDigitalFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotDigital_U64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, sizeof(ulong));
        }

        /// <summary>
        ///     Plots the digital using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotDigital(string labelId, ref ulong xs, ref ulong ys, int count, ImPlotDigitalFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotDigital_U64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the digital g using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="getter">The getter</param>
        /// <param name="data">The data</param>
        /// <param name="count">The count</param>
        public static void PlotDigitalG(string labelId, IntPtr getter, IntPtr data, int count)
        {
            ImPlotNative.ImPlot_PlotDigitalG(Encoding.UTF8.GetBytes(labelId), getter, data, count, 0);
        }

        /// <summary>
        ///     Plots the digital g using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="getter">The getter</param>
        /// <param name="data">The data</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotDigitalG(string labelId, IntPtr getter, IntPtr data, int count, ImPlotDigitalFlags flags)
        {
            ImPlotNative.ImPlot_PlotDigitalG(Encoding.UTF8.GetBytes(labelId), getter, data, count, flags);
        }

        /// <summary>
        ///     Plots the dummy using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        public static void PlotDummy(string labelId)
        {
            ImPlotNative.ImPlot_PlotDummy(Encoding.UTF8.GetBytes(labelId), 0);
        }

        /// <summary>
        ///     Plots the dummy using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="flags">The flags</param>
        public static void PlotDummy(string labelId, ImPlotDummyFlags flags)
        {
            ImPlotNative.ImPlot_PlotDummy(Encoding.UTF8.GetBytes(labelId), flags);
        }

        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="err">The err</param>
        /// <param name="count">The count</param>
        public static void PlotErrorBars(string labelId, ref float xs, ref float ys, ref float err, int count)
        {
            ImPlotNative.ImPlot_PlotErrorBars_FloatPtrFloatPtrFloatPtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, err, count, 0, 0, sizeof(float));
        }

        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="err">The err</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotErrorBars(string labelId, ref float xs, ref float ys, ref float err, int count, ImPlotErrorBarsFlags flags)
        {
            ImPlotNative.ImPlot_PlotErrorBars_FloatPtrFloatPtrFloatPtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, err, count, flags, 0, sizeof(float));
        }
    }
}