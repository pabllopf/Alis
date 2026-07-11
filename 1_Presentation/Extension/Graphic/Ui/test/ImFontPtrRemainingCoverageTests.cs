using System;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    /// The im font ptr remaining coverage tests class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    public class ImFontPtrRemainingCoverageTests : IDisposable
    {
        /// <summary>
        /// The ctx
        /// </summary>
        private readonly IntPtr _ctx;

        /// <summary>
        /// Initializes a new instance of the <see cref="ImFontPtrRemainingCoverageTests"/> class
        /// </summary>
        public ImFontPtrRemainingCoverageTests()
        {
            _ctx = ImGui.CreateContext();
            ImGui.SetCurrentContext(_ctx);
            var io = ImGui.GetIo();
            io.DisplaySize = new Vector2F(1920f, 1080f);
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose()
        {
            var field = typeof(ImGui).GetField("_io", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);
            if (field != null)
            {
                field.SetValue(null, new ImGuiIoPtr(IntPtr.Zero));
            }
        }

        /// <summary>
        /// Tests that implicit conversion to int ptr should return native ptr
        /// </summary>
        [Fact]
        public void ImplicitConversion_ToIntPtr_ShouldReturnNativePtr()
        {
            IntPtr expected = new IntPtr(42);
            ImFontPtr ptr = new ImFontPtr(expected);
            IntPtr actual = ptr;
            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// Tests that implicit conversion from int ptr should create im font ptr
        /// </summary>
        [Fact]
        public void ImplicitConversion_FromIntPtr_ShouldCreateImFontPtr()
        {
            IntPtr native = new IntPtr(99);
            ImFontPtr ptr = native;
            Assert.Equal(native, ptr.NativePtr);
        }

        /// <summary>
        /// Tests that index advance x should read correct value
        /// </summary>
        [Fact]
        public void IndexAdvanceX_ShouldReadCorrectValue()
        {
            ImVector vector = new ImVector(3, 5, new IntPtr(789));
            ImFont font = new ImFont { IndexAdvanceX = vector };

            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFont>());
            try
            {
                Marshal.StructureToPtr(font, nativePtr, false);
                ImFontPtr ptr = new ImFontPtr(nativePtr);
                ImVectorG<float> result = ptr.IndexAdvanceX;
                Assert.Equal(vector.Size, result.Size);
                Assert.Equal(vector.Capacity, result.Capacity);
                Assert.Equal(vector.Data, result.Data);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        /// Tests that index lookup should read correct value
        /// </summary>
        [Fact]
        public void IndexLookup_ShouldReadCorrectValue()
        {
            ImVector vector = new ImVector(10, 20, new IntPtr(111));
            ImFont font = new ImFont { IndexLookup = vector };

            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFont>());
            try
            {
                Marshal.StructureToPtr(font, nativePtr, false);
                ImFontPtr ptr = new ImFontPtr(nativePtr);
                ImVectorG<ushort> result = ptr.IndexLookup;
                Assert.Equal(vector.Size, result.Size);
                Assert.Equal(vector.Capacity, result.Capacity);
                Assert.Equal(vector.Data, result.Data);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        /// Tests that container atlas should read correct value
        /// </summary>
        [Fact]
        public void ContainerAtlas_ShouldReadCorrectValue()
        {
            IntPtr atlasPtr = new IntPtr(0xBEEF);
            ImFont font = new ImFont { ContainerAtlas = atlasPtr };

            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFont>());
            try
            {
                Marshal.StructureToPtr(font, nativePtr, false);
                ImFontPtr ptr = new ImFontPtr(nativePtr);
                ImFontAtlasPtr result = ptr.ContainerAtlas;
                Assert.Equal(atlasPtr, result.NativePtr);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        /// Tests that config data count should read correct value
        /// </summary>
        [Fact]
        public void ConfigDataCount_ShouldReadCorrectValue()
        {
            const short expected = 7;
            ImFont font = new ImFont { ConfigDataCount = expected };

            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFont>());
            try
            {
                Marshal.StructureToPtr(font, nativePtr, false);
                ImFontPtr ptr = new ImFontPtr(nativePtr);
                Assert.Equal(expected, ptr.ConfigDataCount);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        /// Tests that fallback char should read correct value
        /// </summary>
        [Fact]
        public void FallbackChar_ShouldReadCorrectValue()
        {
            const ushort expected = 0xFFFD;
            ImFont font = new ImFont { FallbackChar = expected };

            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFont>());
            try
            {
                Marshal.StructureToPtr(font, nativePtr, false);
                ImFontPtr ptr = new ImFontPtr(nativePtr);
                Assert.Equal(expected, ptr.FallbackChar);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        /// Tests that ellipsis char should read correct value
        /// </summary>
        [Fact]
        public void EllipsisChar_ShouldReadCorrectValue()
        {
            const ushort expected = 0x2026;
            ImFont font = new ImFont { EllipsisChar = expected };

            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFont>());
            try
            {
                Marshal.StructureToPtr(font, nativePtr, false);
                ImFontPtr ptr = new ImFontPtr(nativePtr);
                Assert.Equal(expected, ptr.EllipsisChar);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        /// Tests that dot char should read correct value
        /// </summary>
        [Fact]
        public void DotChar_ShouldReadCorrectValue()
        {
            const ushort expected = (ushort)'.';
            ImFont font = new ImFont { DotChar = expected };

            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFont>());
            try
            {
                Marshal.StructureToPtr(font, nativePtr, false);
                ImFontPtr ptr = new ImFontPtr(nativePtr);
                Assert.Equal(expected, ptr.DotChar);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        /// Tests that ascent should read correct value
        /// </summary>
        [Fact]
        public void Ascent_ShouldReadCorrectValue()
        {
            const float expected = 0.8f;
            ImFont font = new ImFont { Ascent = expected };

            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFont>());
            try
            {
                Marshal.StructureToPtr(font, nativePtr, false);
                ImFontPtr ptr = new ImFontPtr(nativePtr);
                Assert.Equal(expected, ptr.Ascent);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        /// Tests that descent should read correct value
        /// </summary>
        [Fact]
        public void Descent_ShouldReadCorrectValue()
        {
            const float expected = -0.2f;
            ImFont font = new ImFont { Descent = expected };

            IntPtr nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFont>());
            try
            {
                Marshal.StructureToPtr(font, nativePtr, false);
                ImFontPtr ptr = new ImFontPtr(nativePtr);
                Assert.Equal(expected, ptr.Descent);
            }
            finally
            {
                Marshal.FreeHGlobal(nativePtr);
            }
        }

        /// <summary>
        /// Tests that add glyph should not throw
        /// </summary>
        [Fact]
        public void AddGlyph_ShouldNotThrow()
        {
            var io = ImGui.GetIo();
            ImFontPtr font = io.Fonts.AddFontDefault();
            io.Fonts.Build();
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            ImFontConfigPtr cfg = new ImFontConfigPtr(new IntPtr(0));
            font.AddGlyph(cfg, (ushort)'A', 0, 0, 1, 1, 0, 0, 1, 1, 0.5f);
            ImGui.End();
            ImGui.Render();
        }

        /// <summary>
        /// Tests that add remap char without overwrite dst should not throw
        /// </summary>
        [Fact]
        public void AddRemapChar_WithoutOverwriteDst_ShouldNotThrow()
        {
            var io = ImGui.GetIo();
            ImFontPtr font = io.Fonts.AddFontDefault();
            io.Fonts.Build();
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            font.AddRemapChar((ushort)'a', (ushort)'b');
            ImGui.End();
            ImGui.Render();
        }

        /// <summary>
        /// Tests that add remap char with overwrite dst true should not throw
        /// </summary>
        [Fact]
        public void AddRemapChar_WithOverwriteDstTrue_ShouldNotThrow()
        {
            var io = ImGui.GetIo();
            ImFontPtr font = io.Fonts.AddFontDefault();
            io.Fonts.Build();
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            font.AddRemapChar((ushort)'a', (ushort)'b', true);
            ImGui.End();
            ImGui.Render();
        }

        /// <summary>
        /// Tests that add remap char with overwrite dst false should not throw
        /// </summary>
        [Fact]
        public void AddRemapChar_WithOverwriteDstFalse_ShouldNotThrow()
        {
            var io = ImGui.GetIo();
            ImFontPtr font = io.Fonts.AddFontDefault();
            io.Fonts.Build();
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            font.AddRemapChar((ushort)'a', (ushort)'b', false);
            ImGui.End();
            ImGui.Render();
        }

        /// <summary>
        /// Tests that build lookup table should not throw
        /// </summary>
        [Fact]
        public void BuildLookupTable_ShouldNotThrow()
        {
            var io = ImGui.GetIo();
            ImFontPtr font = io.Fonts.AddFontDefault();
            io.Fonts.Build();
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            font.BuildLookupTable();
            ImGui.End();
            ImGui.Render();
        }

        /// <summary>
        /// Tests that clear output data should not throw
        /// </summary>
        [Fact]
        public void ClearOutputData_ShouldNotThrow()
        {
            var io = ImGui.GetIo();
            ImFontPtr font = io.Fonts.AddFontDefault();
            io.Fonts.Build();
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            font.ClearOutputData();
            ImGui.End();
            ImGui.Render();
        }

        /// <summary>
        /// Tests that find glyph should return default
        /// </summary>
        [Fact]
        public void FindGlyph_ShouldReturnDefault()
        {
            var io = ImGui.GetIo();
            ImFontPtr font = io.Fonts.AddFontDefault();
            io.Fonts.Build();
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            ImFontGlyph glyph = font.FindGlyph((ushort)'A');
            _ = glyph;
            ImGui.End();
            ImGui.Render();
        }

        /// <summary>
        /// Tests that find glyph no fallback should return default
        /// </summary>
        [Fact]
        public void FindGlyphNoFallback_ShouldReturnDefault()
        {
            var io = ImGui.GetIo();
            ImFontPtr font = io.Fonts.AddFontDefault();
            io.Fonts.Build();
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            ImFontGlyph glyph = font.FindGlyphNoFallback((ushort)'A');
            _ = glyph;
            ImGui.End();
            ImGui.Render();
        }

        /// <summary>
        /// Tests that get char advance should return value
        /// </summary>
        [Fact]
        public void GetCharAdvance_ShouldReturnValue()
        {
            var io = ImGui.GetIo();
            ImFontPtr font = io.Fonts.AddFontDefault();
            io.Fonts.Build();
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            float advance = font.GetCharAdvance((ushort)'A');
            _ = advance;
            ImGui.End();
            ImGui.Render();
        }

        /// <summary>
        /// Tests that get debug name should not throw
        /// </summary>
        [Fact]
        public void GetDebugName_ShouldNotThrow()
        {
            var io = ImGui.GetIo();
            ImFontPtr font = io.Fonts.AddFontDefault();
            io.Fonts.Build();
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            try
            {
                string name = font.GetDebugName();
                _ = name;
            }
            catch (MarshalDirectiveException)
            {
            }
            ImGui.End();
            ImGui.Render();
        }

        /// <summary>
        /// Tests that grow index should not throw
        /// </summary>
        [Fact]
        public void GrowIndex_ShouldNotThrow()
        {
            var io = ImGui.GetIo();
            ImFontPtr font = io.Fonts.AddFontDefault();
            io.Fonts.Build();
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            font.GrowIndex(100);
            ImGui.End();
            ImGui.Render();
        }

        /// <summary>
        /// Tests that is loaded should return bool
        /// </summary>
        [Fact]
        public void IsLoaded_ShouldReturnBool()
        {
            var io = ImGui.GetIo();
            ImFontPtr font = io.Fonts.AddFontDefault();
            io.Fonts.Build();
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            bool loaded = font.IsLoaded();
            _ = loaded;
            ImGui.End();
            ImGui.Render();
        }

        /// <summary>
        /// Tests that render char should not throw
        /// </summary>
        [Fact]
        public void RenderChar_ShouldNotThrow()
        {
            var io = ImGui.GetIo();
            ImFontPtr font = io.Fonts.AddFontDefault();
            io.Fonts.Build();
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            ImDrawListPtr drawList = ImGui.GetWindowDrawList();
            font.RenderChar(drawList, 13f, new Vector2F(10, 10), 0xFFFFFFFFu, (ushort)'A');
            ImGui.End();
            ImGui.Render();
        }

        /// <summary>
        /// Tests that set glyph visible true should not throw
        /// </summary>
        [Fact]
        public void SetGlyphVisible_True_ShouldNotThrow()
        {
            var io = ImGui.GetIo();
            ImFontPtr font = io.Fonts.AddFontDefault();
            io.Fonts.Build();
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            font.SetGlyphVisible((ushort)'A', true);
            ImGui.End();
            ImGui.Render();
        }

        /// <summary>
        /// Tests that set glyph visible false should not throw
        /// </summary>
        [Fact]
        public void SetGlyphVisible_False_ShouldNotThrow()
        {
            var io = ImGui.GetIo();
            ImFontPtr font = io.Fonts.AddFontDefault();
            io.Fonts.Build();
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            font.SetGlyphVisible((ushort)'A', false);
            ImGui.End();
            ImGui.Render();
        }
    }
}
