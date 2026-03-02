using System;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using Alis.Extension.Graphic.Ui.Extras.Plot;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot
{
    /// <summary>
    /// Provides reflection-based contract tests for internal ImPlot native bindings.
    /// </summary>
    public class ImPlotNativeTest
    {
        /// <summary>
        /// Verifies that the native binding type exists and is static.
        /// </summary>
        [Fact]
        public void Type_ShouldExistAsStaticClass()
        {
            Type nativeType = ResolveNativeType();

            Assert.True(nativeType.IsClass);
            Assert.True(nativeType.IsAbstract);
            Assert.True(nativeType.IsSealed);
        }

        /// <summary>
        /// Verifies that the native library constant is cimgui.
        /// </summary>
        [Fact]
        public void DllName_ShouldBeCimgui()
        {
            Type nativeType = ResolveNativeType();
            FieldInfo dllName = nativeType.GetField("DllName", BindingFlags.NonPublic | BindingFlags.Static);

            Assert.NotNull(dllName);
            Assert.True(dllName.IsLiteral);
            Assert.Equal("cimgui", dllName.GetRawConstantValue() as string);
        }

        /// <summary>
        /// Verifies that a representative subset of bindings keeps stable entry points.
        /// </summary>
        [Fact]
        public void RepresentativeBindings_ShouldHaveExpectedDllImportMetadata()
        {
            Type nativeType = ResolveNativeType();

            AssertDllImport(nativeType, "ImPlot_CreateContext", "ImPlot_CreateContext");
            AssertDllImport(nativeType, "ImPlot_DestroyContext", "ImPlot_DestroyContext");
            AssertDllImport(nativeType, "ImPlot_BeginPlot", "ImPlot_BeginPlot");
            AssertDllImport(nativeType, "ImPlot_EndPlot", "ImPlot_EndPlot");
            AssertDllImport(nativeType, "ImPlot_SetupAxis", "ImPlot_SetupAxis");
            AssertDllImport(nativeType, "ImPlot_PlotLine_FloatPtrFloatPtr", "ImPlot_PlotLine_FloatPtrFloatPtr");
        }

        /// <summary>
        /// Verifies that the native binding surface is broad enough to cover generated wrappers.
        /// </summary>
        [Fact]
        public void NativeSurface_ShouldContainManyExternMethods()
        {
            Type nativeType = ResolveNativeType();
            MethodInfo[] methods = nativeType
                .GetMethods(BindingFlags.NonPublic | BindingFlags.Static)
                .Where(method => method.GetCustomAttribute<DllImportAttribute>() != null)
                .ToArray();

            Assert.True(methods.Length > 300);
        }

        /// <summary>
        /// Resolves the internal native type from the plot assembly.
        /// </summary>
        /// <returns>The reflected internal native type.</returns>
        private static Type ResolveNativeType()
        {
            Type nativeType = typeof(ImPlot).Assembly.GetType("Alis.Extension.Graphic.Ui.Extras.Plot.ImPlotNative", throwOnError: false);

            Assert.NotNull(nativeType);
            return nativeType;
        }

        /// <summary>
        /// Asserts DllImport metadata for one method.
        /// </summary>
        /// <param name="type">The native type.</param>
        /// <param name="methodName">The managed method name.</param>
        /// <param name="entryPoint">The expected native entry point.</param>
        private static void AssertDllImport(Type type, string methodName, string entryPoint)
        {
            MethodInfo method = type.GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Static);

            Assert.NotNull(method);
            DllImportAttribute attribute = method.GetCustomAttribute<DllImportAttribute>();

            Assert.NotNull(attribute);
            Assert.Equal("cimgui", attribute.Value);
            Assert.Equal(entryPoint, attribute.EntryPoint);
            Assert.Equal(CallingConvention.Cdecl, attribute.CallingConvention);
        }
    }
}

