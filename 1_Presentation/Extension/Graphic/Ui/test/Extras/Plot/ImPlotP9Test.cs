using System;
using System.Linq;
using System.Reflection;
using Alis.Extension.Graphic.Ui.Extras.Plot;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot
{
    /// <summary>
    /// Provides focused unit coverage for API members implemented in <c>ImPlotP9.cs</c>.
    /// </summary>
    public class ImPlotP9Test
    {
        /// <summary>
        /// Verifies that <c>PlotLine</c> exposes all expected overloads from this partial segment.
        /// </summary>
        [Fact]
        public void PlotLine_ShouldExposeExpectedOverloadCount()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotLine");

            Assert.True(overloads.Length >= 16);
        }

        /// <summary>
        /// Verifies that <c>PlotLine</c> includes by-ref overloads for all integer families.
        /// </summary>
        [Fact]
        public void PlotLine_ShouldExposeAllExpectedByRefNumericFamilies()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotLine");

            Assert.Contains(overloads, method => HasByRefParameter(method, typeof(int)));
            Assert.Contains(overloads, method => HasByRefParameter(method, typeof(uint)));
            Assert.Contains(overloads, method => HasByRefParameter(method, typeof(long)));
            Assert.Contains(overloads, method => HasByRefParameter(method, typeof(ulong)));
        }

        /// <summary>
        /// Verifies that <c>PlotLine</c> contains overloads with flags, offset and stride parameters.
        /// </summary>
        [Fact]
        public void PlotLine_ShouldExposeFlagsOffsetAndStrideOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotLine");

            Assert.Contains(overloads, method => method.GetParameters().Any(parameter => parameter.ParameterType == typeof(ImPlotLineFlags)));
            Assert.Contains(overloads, method => method.GetParameters().Length >= 6 && method.GetParameters()[5].ParameterType == typeof(int));
            Assert.Contains(overloads, method => method.GetParameters().Length >= 7 && method.GetParameters()[6].ParameterType == typeof(int));
        }

        /// <summary>
        /// Verifies that <c>PlotLineG</c> exposes both default and flags overloads.
        /// </summary>
        [Fact]
        public void PlotLineG_ShouldExposeExpectedOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotLineG");

            Assert.True(overloads.Length >= 2);
            Assert.Contains(overloads, method => method.GetParameters().Length == 4);
            Assert.Contains(overloads, method => method.GetParameters().Length == 5 && method.GetParameters().Any(parameter => parameter.ParameterType == typeof(ImPlotLineFlags)));
        }

        /// <summary>
        /// Verifies that <c>PlotPieChart</c> exposes a large overload matrix.
        /// </summary>
        [Fact]
        public void PlotPieChart_ShouldExposeExpectedOverloadCount()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotPieChart");

            Assert.True(overloads.Length >= 20);
        }

        /// <summary>
        /// Verifies that <c>PlotPieChart</c> supports multiple values array element types.
        /// </summary>
        [Fact]
        public void PlotPieChart_ShouldExposeExpectedValueArrayFamilies()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotPieChart");

            Assert.Contains(overloads, method => HasArrayParameter(method, typeof(float)));
            Assert.Contains(overloads, method => HasArrayParameter(method, typeof(double)));
            Assert.Contains(overloads, method => HasArrayParameter(method, typeof(sbyte)));
            Assert.Contains(overloads, method => HasArrayParameter(method, typeof(byte)));
            Assert.Contains(overloads, method => HasArrayParameter(method, typeof(short)));
            Assert.Contains(overloads, method => HasArrayParameter(method, typeof(ushort)));
        }

        /// <summary>
        /// Verifies that <c>PlotPieChart</c> includes formatting, angle and flags overloads.
        /// </summary>
        [Fact]
        public void PlotPieChart_ShouldExposeLabelFormatAngleAndFlagsOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotPieChart");

            Assert.Contains(overloads, method => method.GetParameters().Any(parameter => parameter.ParameterType == typeof(string)));
            Assert.Contains(overloads, method => method.GetParameters().Any(parameter => parameter.ParameterType == typeof(double)) && method.GetParameters().Length >= 8);
            Assert.Contains(overloads, method => method.GetParameters().Any(parameter => parameter.ParameterType == typeof(ImPlotPieChartFlags)));
        }

        /// <summary>
        /// Verifies that passing a null label to <c>PlotLine</c> throws before native invocation.
        /// </summary>
        [Fact]
        public void PlotLine_WithNullLabel_ShouldThrowArgumentNullException()
        {
            int xs = 1;
            int ys = 2;

            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotLine(null, ref xs, ref ys, 1)));
        }

        /// <summary>
        /// Verifies that passing a null label to <c>PlotLineG</c> throws before native invocation.
        /// </summary>
        [Fact]
        public void PlotLineG_WithNullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotLineG(null, IntPtr.Zero, IntPtr.Zero, 1)));
        }

        /// <summary>
        /// Verifies that a null labels array in <c>PlotPieChart</c> fails before native invocation.
        /// </summary>
        [Fact]
        public void PlotPieChart_WithNullLabelsArray_ShouldThrowNullReferenceException()
        {
            float[] values = {1f, 2f};

            Assert.Throws<NullReferenceException>((Action)(() => ImPlot.PlotPieChart(null, values, 2, 0.0, 0.0, 1.0)));
        }

        /// <summary>
        /// Verifies that a null label element in <c>PlotPieChart</c> throws before native invocation.
        /// </summary>
        [Fact]
        public void PlotPieChart_WithNullLabelItem_ShouldThrowArgumentNullException()
        {
            string[] labels = {"A", null};
            float[] values = {1f, 2f};

            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotPieChart(labels, values, 2, 0.0, 0.0, 1.0)));
        }

        /// <summary>
        /// Verifies that a null label format in <c>PlotPieChart</c> throws before native invocation.
        /// </summary>
        [Fact]
        public void PlotPieChart_WithNullLabelFormat_ShouldThrowArgumentNullException()
        {
            string[] labels = {"A", "B"};
            float[] values = {1f, 2f};

            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotPieChart(labels, values, 2, 0.0, 0.0, 1.0, null)));
        }

        /// <summary>
        /// Gets all public static methods with the requested name.
        /// </summary>
        /// <param name="name">The method name.</param>
        /// <returns>The matching method array.</returns>
        private static MethodInfo[] GetPublicStaticMethods(string name)
        {
            return typeof(ImPlot)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(method => method.Name == name)
                .ToArray();
        }

        /// <summary>
        /// Determines whether a method has a by-reference parameter for the provided element type.
        /// </summary>
        /// <param name="method">The method to inspect.</param>
        /// <param name="elementType">The by-reference element type.</param>
        /// <returns><c>true</c> if a matching by-reference parameter is found; otherwise <c>false</c>.</returns>
        private static bool HasByRefParameter(MethodInfo method, Type elementType)
        {
            return method.GetParameters().Any(parameter => parameter.ParameterType.IsByRef && parameter.ParameterType.GetElementType() == elementType);
        }

        /// <summary>
        /// Determines whether a method has an array parameter whose element type matches the provided type.
        /// </summary>
        /// <param name="method">The method to inspect.</param>
        /// <param name="elementType">The target array element type.</param>
        /// <returns><c>true</c> when a matching array parameter exists; otherwise <c>false</c>.</returns>
        private static bool HasArrayParameter(MethodInfo method, Type elementType)
        {
            return method.GetParameters().Any(parameter => parameter.ParameterType.IsArray && parameter.ParameterType.GetElementType() == elementType);
        }
    }
}

