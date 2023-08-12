using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace Alis.Core.Graphic.Imgui
{
    /// <summary>
    /// The im font atlas
    /// </summary>
    public unsafe partial struct ImFontAtlas
    {
        /// <summary>
        /// The flags
        /// </summary>
        public ImFontAtlasFlags Flags;
        /// <summary>
        /// The tex id
        /// </summary>
        public IntPtr TexID;
        /// <summary>
        /// The tex desired width
        /// </summary>
        public int TexDesiredWidth;
        /// <summary>
        /// The tex glyph padding
        /// </summary>
        public int TexGlyphPadding;
        /// <summary>
        /// The locked
        /// </summary>
        public byte Locked;
        /// <summary>
        /// The tex ready
        /// </summary>
        public byte TexReady;
        /// <summary>
        /// The tex pixels use colors
        /// </summary>
        public byte TexPixelsUseColors;
        /// <summary>
        /// The tex pixels alpha
        /// </summary>
        public byte* TexPixelsAlpha8;
        /// <summary>
        /// The tex pixels rgba 32
        /// </summary>
        public uint* TexPixelsRGBA32;
        /// <summary>
        /// The tex width
        /// </summary>
        public int TexWidth;
        /// <summary>
        /// The tex height
        /// </summary>
        public int TexHeight;
        /// <summary>
        /// The tex uv scale
        /// </summary>
        public Vector2 TexUvScale;
        /// <summary>
        /// The tex uv white pixel
        /// </summary>
        public Vector2 TexUvWhitePixel;
        /// <summary>
        /// The fonts
        /// </summary>
        public ImVector Fonts;
        /// <summary>
        /// The custom rects
        /// </summary>
        public ImVector CustomRects;
        /// <summary>
        /// The config data
        /// </summary>
        public ImVector ConfigData;
        /// <summary>
        /// The texuvlines
        /// </summary>
        public Vector4 TexUvLines_0;
        /// <summary>
        /// The texuvlines
        /// </summary>
        public Vector4 TexUvLines_1;
        /// <summary>
        /// The texuvlines
        /// </summary>
        public Vector4 TexUvLines_2;
        /// <summary>
        /// The texuvlines
        /// </summary>
        public Vector4 TexUvLines_3;
        /// <summary>
        /// The texuvlines
        /// </summary>
        public Vector4 TexUvLines_4;
        /// <summary>
        /// The texuvlines
        /// </summary>
        public Vector4 TexUvLines_5;
        /// <summary>
        /// The texuvlines
        /// </summary>
        public Vector4 TexUvLines_6;
        /// <summary>
        /// The texuvlines
        /// </summary>
        public Vector4 TexUvLines_7;
        /// <summary>
        /// The texuvlines
        /// </summary>
        public Vector4 TexUvLines_8;
        /// <summary>
        /// The texuvlines
        /// </summary>
        public Vector4 TexUvLines_9;
        /// <summary>
        /// The texuvlines 10
        /// </summary>
        public Vector4 TexUvLines_10;
        /// <summary>
        /// The texuvlines 11
        /// </summary>
        public Vector4 TexUvLines_11;
        /// <summary>
        /// The texuvlines 12
        /// </summary>
        public Vector4 TexUvLines_12;
        /// <summary>
        /// The texuvlines 13
        /// </summary>
        public Vector4 TexUvLines_13;
        /// <summary>
        /// The texuvlines 14
        /// </summary>
        public Vector4 TexUvLines_14;
        /// <summary>
        /// The texuvlines 15
        /// </summary>
        public Vector4 TexUvLines_15;
        /// <summary>
        /// The texuvlines 16
        /// </summary>
        public Vector4 TexUvLines_16;
        /// <summary>
        /// The texuvlines 17
        /// </summary>
        public Vector4 TexUvLines_17;
        /// <summary>
        /// The texuvlines 18
        /// </summary>
        public Vector4 TexUvLines_18;
        /// <summary>
        /// The texuvlines 19
        /// </summary>
        public Vector4 TexUvLines_19;
        /// <summary>
        /// The texuvlines 20
        /// </summary>
        public Vector4 TexUvLines_20;
        /// <summary>
        /// The texuvlines 21
        /// </summary>
        public Vector4 TexUvLines_21;
        /// <summary>
        /// The texuvlines 22
        /// </summary>
        public Vector4 TexUvLines_22;
        /// <summary>
        /// The texuvlines 23
        /// </summary>
        public Vector4 TexUvLines_23;
        /// <summary>
        /// The texuvlines 24
        /// </summary>
        public Vector4 TexUvLines_24;
        /// <summary>
        /// The texuvlines 25
        /// </summary>
        public Vector4 TexUvLines_25;
        /// <summary>
        /// The texuvlines 26
        /// </summary>
        public Vector4 TexUvLines_26;
        /// <summary>
        /// The texuvlines 27
        /// </summary>
        public Vector4 TexUvLines_27;
        /// <summary>
        /// The texuvlines 28
        /// </summary>
        public Vector4 TexUvLines_28;
        /// <summary>
        /// The texuvlines 29
        /// </summary>
        public Vector4 TexUvLines_29;
        /// <summary>
        /// The texuvlines 30
        /// </summary>
        public Vector4 TexUvLines_30;
        /// <summary>
        /// The texuvlines 31
        /// </summary>
        public Vector4 TexUvLines_31;
        /// <summary>
        /// The texuvlines 32
        /// </summary>
        public Vector4 TexUvLines_32;
        /// <summary>
        /// The texuvlines 33
        /// </summary>
        public Vector4 TexUvLines_33;
        /// <summary>
        /// The texuvlines 34
        /// </summary>
        public Vector4 TexUvLines_34;
        /// <summary>
        /// The texuvlines 35
        /// </summary>
        public Vector4 TexUvLines_35;
        /// <summary>
        /// The texuvlines 36
        /// </summary>
        public Vector4 TexUvLines_36;
        /// <summary>
        /// The texuvlines 37
        /// </summary>
        public Vector4 TexUvLines_37;
        /// <summary>
        /// The texuvlines 38
        /// </summary>
        public Vector4 TexUvLines_38;
        /// <summary>
        /// The texuvlines 39
        /// </summary>
        public Vector4 TexUvLines_39;
        /// <summary>
        /// The texuvlines 40
        /// </summary>
        public Vector4 TexUvLines_40;
        /// <summary>
        /// The texuvlines 41
        /// </summary>
        public Vector4 TexUvLines_41;
        /// <summary>
        /// The texuvlines 42
        /// </summary>
        public Vector4 TexUvLines_42;
        /// <summary>
        /// The texuvlines 43
        /// </summary>
        public Vector4 TexUvLines_43;
        /// <summary>
        /// The texuvlines 44
        /// </summary>
        public Vector4 TexUvLines_44;
        /// <summary>
        /// The texuvlines 45
        /// </summary>
        public Vector4 TexUvLines_45;
        /// <summary>
        /// The texuvlines 46
        /// </summary>
        public Vector4 TexUvLines_46;
        /// <summary>
        /// The texuvlines 47
        /// </summary>
        public Vector4 TexUvLines_47;
        /// <summary>
        /// The texuvlines 48
        /// </summary>
        public Vector4 TexUvLines_48;
        /// <summary>
        /// The texuvlines 49
        /// </summary>
        public Vector4 TexUvLines_49;
        /// <summary>
        /// The texuvlines 50
        /// </summary>
        public Vector4 TexUvLines_50;
        /// <summary>
        /// The texuvlines 51
        /// </summary>
        public Vector4 TexUvLines_51;
        /// <summary>
        /// The texuvlines 52
        /// </summary>
        public Vector4 TexUvLines_52;
        /// <summary>
        /// The texuvlines 53
        /// </summary>
        public Vector4 TexUvLines_53;
        /// <summary>
        /// The texuvlines 54
        /// </summary>
        public Vector4 TexUvLines_54;
        /// <summary>
        /// The texuvlines 55
        /// </summary>
        public Vector4 TexUvLines_55;
        /// <summary>
        /// The texuvlines 56
        /// </summary>
        public Vector4 TexUvLines_56;
        /// <summary>
        /// The texuvlines 57
        /// </summary>
        public Vector4 TexUvLines_57;
        /// <summary>
        /// The texuvlines 58
        /// </summary>
        public Vector4 TexUvLines_58;
        /// <summary>
        /// The texuvlines 59
        /// </summary>
        public Vector4 TexUvLines_59;
        /// <summary>
        /// The texuvlines 60
        /// </summary>
        public Vector4 TexUvLines_60;
        /// <summary>
        /// The texuvlines 61
        /// </summary>
        public Vector4 TexUvLines_61;
        /// <summary>
        /// The texuvlines 62
        /// </summary>
        public Vector4 TexUvLines_62;
        /// <summary>
        /// The texuvlines 63
        /// </summary>
        public Vector4 TexUvLines_63;
        /// <summary>
        /// The font builder io
        /// </summary>
        public IntPtr* FontBuilderIO;
        /// <summary>
        /// The font builder flags
        /// </summary>
        public uint FontBuilderFlags;
        /// <summary>
        /// The pack id mouse cursors
        /// </summary>
        public int PackIdMouseCursors;
        /// <summary>
        /// The pack id lines
        /// </summary>
        public int PackIdLines;
    }
    /// <summary>
    /// The im font atlas ptr
    /// </summary>
    public unsafe partial struct ImFontAtlasPtr
    {
        /// <summary>
        /// Gets the value of the native ptr
        /// </summary>
        public ImFontAtlas* NativePtr { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ImFontAtlasPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImFontAtlasPtr(ImFontAtlas* nativePtr) => NativePtr = nativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="ImFontAtlasPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImFontAtlasPtr(IntPtr nativePtr) => NativePtr = (ImFontAtlas*)nativePtr;
        public static implicit operator ImFontAtlasPtr(ImFontAtlas* nativePtr) => new ImFontAtlasPtr(nativePtr);
        public static implicit operator ImFontAtlas* (ImFontAtlasPtr wrappedPtr) => wrappedPtr.NativePtr;
        public static implicit operator ImFontAtlasPtr(IntPtr nativePtr) => new ImFontAtlasPtr(nativePtr);
        /// <summary>
        /// Gets the value of the flags
        /// </summary>
        public ref ImFontAtlasFlags Flags => ref Unsafe.AsRef<ImFontAtlasFlags>(&NativePtr->Flags);
        /// <summary>
        /// Gets the value of the tex id
        /// </summary>
        public ref IntPtr TexID => ref Unsafe.AsRef<IntPtr>(&NativePtr->TexID);
        /// <summary>
        /// Gets the value of the tex desired width
        /// </summary>
        public ref int TexDesiredWidth => ref Unsafe.AsRef<int>(&NativePtr->TexDesiredWidth);
        /// <summary>
        /// Gets the value of the tex glyph padding
        /// </summary>
        public ref int TexGlyphPadding => ref Unsafe.AsRef<int>(&NativePtr->TexGlyphPadding);
        /// <summary>
        /// Gets the value of the locked
        /// </summary>
        public ref bool Locked => ref Unsafe.AsRef<bool>(&NativePtr->Locked);
        /// <summary>
        /// Gets the value of the tex ready
        /// </summary>
        public ref bool TexReady => ref Unsafe.AsRef<bool>(&NativePtr->TexReady);
        /// <summary>
        /// Gets the value of the tex pixels use colors
        /// </summary>
        public ref bool TexPixelsUseColors => ref Unsafe.AsRef<bool>(&NativePtr->TexPixelsUseColors);
        /// <summary>
        /// Gets or sets the value of the tex pixels alpha 8
        /// </summary>
        public IntPtr TexPixelsAlpha8 { get => (IntPtr)NativePtr->TexPixelsAlpha8; set => NativePtr->TexPixelsAlpha8 = (byte*)value; }
        /// <summary>
        /// Gets or sets the value of the tex pixels rgba 32
        /// </summary>
        public IntPtr TexPixelsRGBA32 { get => (IntPtr)NativePtr->TexPixelsRGBA32; set => NativePtr->TexPixelsRGBA32 = (uint*)value; }
        /// <summary>
        /// Gets the value of the tex width
        /// </summary>
        public ref int TexWidth => ref Unsafe.AsRef<int>(&NativePtr->TexWidth);
        /// <summary>
        /// Gets the value of the tex height
        /// </summary>
        public ref int TexHeight => ref Unsafe.AsRef<int>(&NativePtr->TexHeight);
        /// <summary>
        /// Gets the value of the tex uv scale
        /// </summary>
        public ref Vector2 TexUvScale => ref Unsafe.AsRef<Vector2>(&NativePtr->TexUvScale);
        /// <summary>
        /// Gets the value of the tex uv white pixel
        /// </summary>
        public ref Vector2 TexUvWhitePixel => ref Unsafe.AsRef<Vector2>(&NativePtr->TexUvWhitePixel);
        /// <summary>
        /// Gets the value of the fonts
        /// </summary>
        public ImVector<ImFontPtr> Fonts => new ImVector<ImFontPtr>(NativePtr->Fonts);
        /// <summary>
        /// Gets the value of the custom rects
        /// </summary>
        public ImPtrVector<ImFontAtlasCustomRectPtr> CustomRects => new ImPtrVector<ImFontAtlasCustomRectPtr>(NativePtr->CustomRects, Unsafe.SizeOf<ImFontAtlasCustomRect>());
        /// <summary>
        /// Gets the value of the config data
        /// </summary>
        public ImPtrVector<ImFontConfigPtr> ConfigData => new ImPtrVector<ImFontConfigPtr>(NativePtr->ConfigData, Unsafe.SizeOf<ImFontConfig>());
        /// <summary>
        /// Gets the value of the tex uv lines
        /// </summary>
        public RangeAccessor<Vector4> TexUvLines => new RangeAccessor<Vector4>(&NativePtr->TexUvLines_0, 64);
        /// <summary>
        /// Gets or sets the value of the font builder io
        /// </summary>
        public IntPtr FontBuilderIO { get => (IntPtr)NativePtr->FontBuilderIO; set => NativePtr->FontBuilderIO = (IntPtr*)value; }
        /// <summary>
        /// Gets the value of the font builder flags
        /// </summary>
        public ref uint FontBuilderFlags => ref Unsafe.AsRef<uint>(&NativePtr->FontBuilderFlags);
        /// <summary>
        /// Gets the value of the pack id mouse cursors
        /// </summary>
        public ref int PackIdMouseCursors => ref Unsafe.AsRef<int>(&NativePtr->PackIdMouseCursors);
        /// <summary>
        /// Gets the value of the pack id lines
        /// </summary>
        public ref int PackIdLines => ref Unsafe.AsRef<int>(&NativePtr->PackIdLines);
        /// <summary>
        /// Adds the custom rect font glyph using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="id">The id</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="advance_x">The advance</param>
        /// <returns>The ret</returns>
        public int AddCustomRectFontGlyph(ImFontPtr font, ushort id, int width, int height, float advance_x)
        {
            ImFont* native_font = font.NativePtr;
            Vector2 offset = new Vector2();
            int ret = ImGuiNative.ImFontAtlas_AddCustomRectFontGlyph((ImFontAtlas*)(NativePtr), native_font, id, width, height, advance_x, offset);
            return ret;
        }
        /// <summary>
        /// Adds the custom rect font glyph using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="id">The id</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="advance_x">The advance</param>
        /// <param name="offset">The offset</param>
        /// <returns>The ret</returns>
        public int AddCustomRectFontGlyph(ImFontPtr font, ushort id, int width, int height, float advance_x, Vector2 offset)
        {
            ImFont* native_font = font.NativePtr;
            int ret = ImGuiNative.ImFontAtlas_AddCustomRectFontGlyph((ImFontAtlas*)(NativePtr), native_font, id, width, height, advance_x, offset);
            return ret;
        }
        /// <summary>
        /// Adds the custom rect regular using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <returns>The ret</returns>
        public int AddCustomRectRegular(int width, int height)
        {
            int ret = ImGuiNative.ImFontAtlas_AddCustomRectRegular((ImFontAtlas*)(NativePtr), width, height);
            return ret;
        }
        /// <summary>
        /// Adds the font using the specified font cfg
        /// </summary>
        /// <param name="font_cfg">The font cfg</param>
        /// <returns>The im font ptr</returns>
        public ImFontPtr AddFont(ImFontConfigPtr font_cfg)
        {
            ImFontConfig* native_font_cfg = font_cfg.NativePtr;
            ImFont* ret = ImGuiNative.ImFontAtlas_AddFont((ImFontAtlas*)(NativePtr), native_font_cfg);
            return new ImFontPtr(ret);
        }
        /// <summary>
        /// Adds the font default
        /// </summary>
        /// <returns>The im font ptr</returns>
        public ImFontPtr AddFontDefault()
        {
            ImFontConfig* font_cfg = null;
            ImFont* ret = ImGuiNative.ImFontAtlas_AddFontDefault((ImFontAtlas*)(NativePtr), font_cfg);
            return new ImFontPtr(ret);
        }
        /// <summary>
        /// Adds the font default using the specified font cfg
        /// </summary>
        /// <param name="font_cfg">The font cfg</param>
        /// <returns>The im font ptr</returns>
        public ImFontPtr AddFontDefault(ImFontConfigPtr font_cfg)
        {
            ImFontConfig* native_font_cfg = font_cfg.NativePtr;
            ImFont* ret = ImGuiNative.ImFontAtlas_AddFontDefault((ImFontAtlas*)(NativePtr), native_font_cfg);
            return new ImFontPtr(ret);
        }
        /// <summary>
        /// Adds the font from file ttf using the specified filename
        /// </summary>
        /// <param name="filename">The filename</param>
        /// <param name="size_pixels">The size pixels</param>
        /// <returns>The im font ptr</returns>
        public ImFontPtr AddFontFromFileTTF(string filename, float size_pixels)
        {
            byte* native_filename;
            int filename_byteCount = 0;
            if (filename != null)
            {
                filename_byteCount = Encoding.UTF8.GetByteCount(filename);
                if (filename_byteCount > Util.StackAllocationSizeLimit)
                {
                    native_filename = Util.Allocate(filename_byteCount + 1);
                }
                else
                {
                    byte* native_filename_stackBytes = stackalloc byte[filename_byteCount + 1];
                    native_filename = native_filename_stackBytes;
                }
                int native_filename_offset = Util.GetUtf8(filename, native_filename, filename_byteCount);
                native_filename[native_filename_offset] = 0;
            }
            else { native_filename = null; }
            ImFontConfig* font_cfg = null;
            ushort* glyph_ranges = null;
            ImFont* ret = ImGuiNative.ImFontAtlas_AddFontFromFileTTF((ImFontAtlas*)(NativePtr), native_filename, size_pixels, font_cfg, glyph_ranges);
            if (filename_byteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(native_filename);
            }
            return new ImFontPtr(ret);
        }
        /// <summary>
        /// Adds the font from file ttf using the specified filename
        /// </summary>
        /// <param name="filename">The filename</param>
        /// <param name="size_pixels">The size pixels</param>
        /// <param name="font_cfg">The font cfg</param>
        /// <returns>The im font ptr</returns>
        public ImFontPtr AddFontFromFileTTF(string filename, float size_pixels, ImFontConfigPtr font_cfg)
        {
            byte* native_filename;
            int filename_byteCount = 0;
            if (filename != null)
            {
                filename_byteCount = Encoding.UTF8.GetByteCount(filename);
                if (filename_byteCount > Util.StackAllocationSizeLimit)
                {
                    native_filename = Util.Allocate(filename_byteCount + 1);
                }
                else
                {
                    byte* native_filename_stackBytes = stackalloc byte[filename_byteCount + 1];
                    native_filename = native_filename_stackBytes;
                }
                int native_filename_offset = Util.GetUtf8(filename, native_filename, filename_byteCount);
                native_filename[native_filename_offset] = 0;
            }
            else { native_filename = null; }
            ImFontConfig* native_font_cfg = font_cfg.NativePtr;
            ushort* glyph_ranges = null;
            ImFont* ret = ImGuiNative.ImFontAtlas_AddFontFromFileTTF((ImFontAtlas*)(NativePtr), native_filename, size_pixels, native_font_cfg, glyph_ranges);
            if (filename_byteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(native_filename);
            }
            return new ImFontPtr(ret);
        }
        /// <summary>
        /// Adds the font from file ttf using the specified filename
        /// </summary>
        /// <param name="filename">The filename</param>
        /// <param name="size_pixels">The size pixels</param>
        /// <param name="font_cfg">The font cfg</param>
        /// <param name="glyph_ranges">The glyph ranges</param>
        /// <returns>The im font ptr</returns>
        public ImFontPtr AddFontFromFileTTF(string filename, float size_pixels, ImFontConfigPtr font_cfg, IntPtr glyph_ranges)
        {
            byte* native_filename;
            int filename_byteCount = 0;
            if (filename != null)
            {
                filename_byteCount = Encoding.UTF8.GetByteCount(filename);
                if (filename_byteCount > Util.StackAllocationSizeLimit)
                {
                    native_filename = Util.Allocate(filename_byteCount + 1);
                }
                else
                {
                    byte* native_filename_stackBytes = stackalloc byte[filename_byteCount + 1];
                    native_filename = native_filename_stackBytes;
                }
                int native_filename_offset = Util.GetUtf8(filename, native_filename, filename_byteCount);
                native_filename[native_filename_offset] = 0;
            }
            else { native_filename = null; }
            ImFontConfig* native_font_cfg = font_cfg.NativePtr;
            ushort* native_glyph_ranges = (ushort*)glyph_ranges.ToPointer();
            ImFont* ret = ImGuiNative.ImFontAtlas_AddFontFromFileTTF((ImFontAtlas*)(NativePtr), native_filename, size_pixels, native_font_cfg, native_glyph_ranges);
            if (filename_byteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(native_filename);
            }
            return new ImFontPtr(ret);
        }
        /// <summary>
        /// Adds the font from memory compressed base 85 ttf using the specified compressed font data base85
        /// </summary>
        /// <param name="compressed_font_data_base85">The compressed font data base85</param>
        /// <param name="size_pixels">The size pixels</param>
        /// <returns>The im font ptr</returns>
        public ImFontPtr AddFontFromMemoryCompressedBase85TTF(string compressed_font_data_base85, float size_pixels)
        {
            byte* native_compressed_font_data_base85;
            int compressed_font_data_base85_byteCount = 0;
            if (compressed_font_data_base85 != null)
            {
                compressed_font_data_base85_byteCount = Encoding.UTF8.GetByteCount(compressed_font_data_base85);
                if (compressed_font_data_base85_byteCount > Util.StackAllocationSizeLimit)
                {
                    native_compressed_font_data_base85 = Util.Allocate(compressed_font_data_base85_byteCount + 1);
                }
                else
                {
                    byte* native_compressed_font_data_base85_stackBytes = stackalloc byte[compressed_font_data_base85_byteCount + 1];
                    native_compressed_font_data_base85 = native_compressed_font_data_base85_stackBytes;
                }
                int native_compressed_font_data_base85_offset = Util.GetUtf8(compressed_font_data_base85, native_compressed_font_data_base85, compressed_font_data_base85_byteCount);
                native_compressed_font_data_base85[native_compressed_font_data_base85_offset] = 0;
            }
            else { native_compressed_font_data_base85 = null; }
            ImFontConfig* font_cfg = null;
            ushort* glyph_ranges = null;
            ImFont* ret = ImGuiNative.ImFontAtlas_AddFontFromMemoryCompressedBase85TTF((ImFontAtlas*)(NativePtr), native_compressed_font_data_base85, size_pixels, font_cfg, glyph_ranges);
            if (compressed_font_data_base85_byteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(native_compressed_font_data_base85);
            }
            return new ImFontPtr(ret);
        }
        /// <summary>
        /// Adds the font from memory compressed base 85 ttf using the specified compressed font data base85
        /// </summary>
        /// <param name="compressed_font_data_base85">The compressed font data base85</param>
        /// <param name="size_pixels">The size pixels</param>
        /// <param name="font_cfg">The font cfg</param>
        /// <returns>The im font ptr</returns>
        public ImFontPtr AddFontFromMemoryCompressedBase85TTF(string compressed_font_data_base85, float size_pixels, ImFontConfigPtr font_cfg)
        {
            byte* native_compressed_font_data_base85;
            int compressed_font_data_base85_byteCount = 0;
            if (compressed_font_data_base85 != null)
            {
                compressed_font_data_base85_byteCount = Encoding.UTF8.GetByteCount(compressed_font_data_base85);
                if (compressed_font_data_base85_byteCount > Util.StackAllocationSizeLimit)
                {
                    native_compressed_font_data_base85 = Util.Allocate(compressed_font_data_base85_byteCount + 1);
                }
                else
                {
                    byte* native_compressed_font_data_base85_stackBytes = stackalloc byte[compressed_font_data_base85_byteCount + 1];
                    native_compressed_font_data_base85 = native_compressed_font_data_base85_stackBytes;
                }
                int native_compressed_font_data_base85_offset = Util.GetUtf8(compressed_font_data_base85, native_compressed_font_data_base85, compressed_font_data_base85_byteCount);
                native_compressed_font_data_base85[native_compressed_font_data_base85_offset] = 0;
            }
            else { native_compressed_font_data_base85 = null; }
            ImFontConfig* native_font_cfg = font_cfg.NativePtr;
            ushort* glyph_ranges = null;
            ImFont* ret = ImGuiNative.ImFontAtlas_AddFontFromMemoryCompressedBase85TTF((ImFontAtlas*)(NativePtr), native_compressed_font_data_base85, size_pixels, native_font_cfg, glyph_ranges);
            if (compressed_font_data_base85_byteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(native_compressed_font_data_base85);
            }
            return new ImFontPtr(ret);
        }
        /// <summary>
        /// Adds the font from memory compressed base 85 ttf using the specified compressed font data base85
        /// </summary>
        /// <param name="compressed_font_data_base85">The compressed font data base85</param>
        /// <param name="size_pixels">The size pixels</param>
        /// <param name="font_cfg">The font cfg</param>
        /// <param name="glyph_ranges">The glyph ranges</param>
        /// <returns>The im font ptr</returns>
        public ImFontPtr AddFontFromMemoryCompressedBase85TTF(string compressed_font_data_base85, float size_pixels, ImFontConfigPtr font_cfg, IntPtr glyph_ranges)
        {
            byte* native_compressed_font_data_base85;
            int compressed_font_data_base85_byteCount = 0;
            if (compressed_font_data_base85 != null)
            {
                compressed_font_data_base85_byteCount = Encoding.UTF8.GetByteCount(compressed_font_data_base85);
                if (compressed_font_data_base85_byteCount > Util.StackAllocationSizeLimit)
                {
                    native_compressed_font_data_base85 = Util.Allocate(compressed_font_data_base85_byteCount + 1);
                }
                else
                {
                    byte* native_compressed_font_data_base85_stackBytes = stackalloc byte[compressed_font_data_base85_byteCount + 1];
                    native_compressed_font_data_base85 = native_compressed_font_data_base85_stackBytes;
                }
                int native_compressed_font_data_base85_offset = Util.GetUtf8(compressed_font_data_base85, native_compressed_font_data_base85, compressed_font_data_base85_byteCount);
                native_compressed_font_data_base85[native_compressed_font_data_base85_offset] = 0;
            }
            else { native_compressed_font_data_base85 = null; }
            ImFontConfig* native_font_cfg = font_cfg.NativePtr;
            ushort* native_glyph_ranges = (ushort*)glyph_ranges.ToPointer();
            ImFont* ret = ImGuiNative.ImFontAtlas_AddFontFromMemoryCompressedBase85TTF((ImFontAtlas*)(NativePtr), native_compressed_font_data_base85, size_pixels, native_font_cfg, native_glyph_ranges);
            if (compressed_font_data_base85_byteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(native_compressed_font_data_base85);
            }
            return new ImFontPtr(ret);
        }
        /// <summary>
        /// Adds the font from memory compressed ttf using the specified compressed font data
        /// </summary>
        /// <param name="compressed_font_data">The compressed font data</param>
        /// <param name="compressed_font_size">The compressed font size</param>
        /// <param name="size_pixels">The size pixels</param>
        /// <returns>The im font ptr</returns>
        public ImFontPtr AddFontFromMemoryCompressedTTF(IntPtr compressed_font_data, int compressed_font_size, float size_pixels)
        {
            void* native_compressed_font_data = (void*)compressed_font_data.ToPointer();
            ImFontConfig* font_cfg = null;
            ushort* glyph_ranges = null;
            ImFont* ret = ImGuiNative.ImFontAtlas_AddFontFromMemoryCompressedTTF((ImFontAtlas*)(NativePtr), native_compressed_font_data, compressed_font_size, size_pixels, font_cfg, glyph_ranges);
            return new ImFontPtr(ret);
        }
        /// <summary>
        /// Adds the font from memory compressed ttf using the specified compressed font data
        /// </summary>
        /// <param name="compressed_font_data">The compressed font data</param>
        /// <param name="compressed_font_size">The compressed font size</param>
        /// <param name="size_pixels">The size pixels</param>
        /// <param name="font_cfg">The font cfg</param>
        /// <returns>The im font ptr</returns>
        public ImFontPtr AddFontFromMemoryCompressedTTF(IntPtr compressed_font_data, int compressed_font_size, float size_pixels, ImFontConfigPtr font_cfg)
        {
            void* native_compressed_font_data = (void*)compressed_font_data.ToPointer();
            ImFontConfig* native_font_cfg = font_cfg.NativePtr;
            ushort* glyph_ranges = null;
            ImFont* ret = ImGuiNative.ImFontAtlas_AddFontFromMemoryCompressedTTF((ImFontAtlas*)(NativePtr), native_compressed_font_data, compressed_font_size, size_pixels, native_font_cfg, glyph_ranges);
            return new ImFontPtr(ret);
        }
        /// <summary>
        /// Adds the font from memory compressed ttf using the specified compressed font data
        /// </summary>
        /// <param name="compressed_font_data">The compressed font data</param>
        /// <param name="compressed_font_size">The compressed font size</param>
        /// <param name="size_pixels">The size pixels</param>
        /// <param name="font_cfg">The font cfg</param>
        /// <param name="glyph_ranges">The glyph ranges</param>
        /// <returns>The im font ptr</returns>
        public ImFontPtr AddFontFromMemoryCompressedTTF(IntPtr compressed_font_data, int compressed_font_size, float size_pixels, ImFontConfigPtr font_cfg, IntPtr glyph_ranges)
        {
            void* native_compressed_font_data = (void*)compressed_font_data.ToPointer();
            ImFontConfig* native_font_cfg = font_cfg.NativePtr;
            ushort* native_glyph_ranges = (ushort*)glyph_ranges.ToPointer();
            ImFont* ret = ImGuiNative.ImFontAtlas_AddFontFromMemoryCompressedTTF((ImFontAtlas*)(NativePtr), native_compressed_font_data, compressed_font_size, size_pixels, native_font_cfg, native_glyph_ranges);
            return new ImFontPtr(ret);
        }
        /// <summary>
        /// Adds the font from memory ttf using the specified font data
        /// </summary>
        /// <param name="font_data">The font data</param>
        /// <param name="font_size">The font size</param>
        /// <param name="size_pixels">The size pixels</param>
        /// <returns>The im font ptr</returns>
        public ImFontPtr AddFontFromMemoryTTF(IntPtr font_data, int font_size, float size_pixels)
        {
            void* native_font_data = (void*)font_data.ToPointer();
            ImFontConfig* font_cfg = null;
            ushort* glyph_ranges = null;
            ImFont* ret = ImGuiNative.ImFontAtlas_AddFontFromMemoryTTF((ImFontAtlas*)(NativePtr), native_font_data, font_size, size_pixels, font_cfg, glyph_ranges);
            return new ImFontPtr(ret);
        }
        /// <summary>
        /// Adds the font from memory ttf using the specified font data
        /// </summary>
        /// <param name="font_data">The font data</param>
        /// <param name="font_size">The font size</param>
        /// <param name="size_pixels">The size pixels</param>
        /// <param name="font_cfg">The font cfg</param>
        /// <returns>The im font ptr</returns>
        public ImFontPtr AddFontFromMemoryTTF(IntPtr font_data, int font_size, float size_pixels, ImFontConfigPtr font_cfg)
        {
            void* native_font_data = (void*)font_data.ToPointer();
            ImFontConfig* native_font_cfg = font_cfg.NativePtr;
            ushort* glyph_ranges = null;
            ImFont* ret = ImGuiNative.ImFontAtlas_AddFontFromMemoryTTF((ImFontAtlas*)(NativePtr), native_font_data, font_size, size_pixels, native_font_cfg, glyph_ranges);
            return new ImFontPtr(ret);
        }
        /// <summary>
        /// Adds the font from memory ttf using the specified font data
        /// </summary>
        /// <param name="font_data">The font data</param>
        /// <param name="font_size">The font size</param>
        /// <param name="size_pixels">The size pixels</param>
        /// <param name="font_cfg">The font cfg</param>
        /// <param name="glyph_ranges">The glyph ranges</param>
        /// <returns>The im font ptr</returns>
        public ImFontPtr AddFontFromMemoryTTF(IntPtr font_data, int font_size, float size_pixels, ImFontConfigPtr font_cfg, IntPtr glyph_ranges)
        {
            void* native_font_data = (void*)font_data.ToPointer();
            ImFontConfig* native_font_cfg = font_cfg.NativePtr;
            ushort* native_glyph_ranges = (ushort*)glyph_ranges.ToPointer();
            ImFont* ret = ImGuiNative.ImFontAtlas_AddFontFromMemoryTTF((ImFontAtlas*)(NativePtr), native_font_data, font_size, size_pixels, native_font_cfg, native_glyph_ranges);
            return new ImFontPtr(ret);
        }
        /// <summary>
        /// Describes whether this instance build
        /// </summary>
        /// <returns>The bool</returns>
        public bool Build()
        {
            byte ret = ImGuiNative.ImFontAtlas_Build((ImFontAtlas*)(NativePtr));
            return ret != 0;
        }
        /// <summary>
        /// Calcs the custom rect uv using the specified rect
        /// </summary>
        /// <param name="rect">The rect</param>
        /// <param name="out_uv_min">The out uv min</param>
        /// <param name="out_uv_max">The out uv max</param>
        public void CalcCustomRectUV(ImFontAtlasCustomRectPtr rect, out Vector2 out_uv_min, out Vector2 out_uv_max)
        {
            ImFontAtlasCustomRect* native_rect = rect.NativePtr;
            fixed (Vector2* native_out_uv_min = &out_uv_min)
            {
                fixed (Vector2* native_out_uv_max = &out_uv_max)
                {
                    ImGuiNative.ImFontAtlas_CalcCustomRectUV((ImFontAtlas*)(NativePtr), native_rect, native_out_uv_min, native_out_uv_max);
                }
            }
        }
        /// <summary>
        /// Clears this instance
        /// </summary>
        public void Clear()
        {
            ImGuiNative.ImFontAtlas_Clear((ImFontAtlas*)(NativePtr));
        }
        /// <summary>
        /// Clears the fonts
        /// </summary>
        public void ClearFonts()
        {
            ImGuiNative.ImFontAtlas_ClearFonts((ImFontAtlas*)(NativePtr));
        }
        /// <summary>
        /// Clears the input data
        /// </summary>
        public void ClearInputData()
        {
            ImGuiNative.ImFontAtlas_ClearInputData((ImFontAtlas*)(NativePtr));
        }
        /// <summary>
        /// Clears the tex data
        /// </summary>
        public void ClearTexData()
        {
            ImGuiNative.ImFontAtlas_ClearTexData((ImFontAtlas*)(NativePtr));
        }
        /// <summary>
        /// Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImGuiNative.ImFontAtlas_destroy((ImFontAtlas*)(NativePtr));
        }
        /// <summary>
        /// Gets the custom rect by index using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The im font atlas custom rect ptr</returns>
        public ImFontAtlasCustomRectPtr GetCustomRectByIndex(int index)
        {
            ImFontAtlasCustomRect* ret = ImGuiNative.ImFontAtlas_GetCustomRectByIndex((ImFontAtlas*)(NativePtr), index);
            return new ImFontAtlasCustomRectPtr(ret);
        }
        /// <summary>
        /// Gets the glyph ranges chinese full
        /// </summary>
        /// <returns>The int ptr</returns>
        public IntPtr GetGlyphRangesChineseFull()
        {
            ushort* ret = ImGuiNative.ImFontAtlas_GetGlyphRangesChineseFull((ImFontAtlas*)(NativePtr));
            return (IntPtr)ret;
        }
        /// <summary>
        /// Gets the glyph ranges chinese simplified common
        /// </summary>
        /// <returns>The int ptr</returns>
        public IntPtr GetGlyphRangesChineseSimplifiedCommon()
        {
            ushort* ret = ImGuiNative.ImFontAtlas_GetGlyphRangesChineseSimplifiedCommon((ImFontAtlas*)(NativePtr));
            return (IntPtr)ret;
        }
        /// <summary>
        /// Gets the glyph ranges cyrillic
        /// </summary>
        /// <returns>The int ptr</returns>
        public IntPtr GetGlyphRangesCyrillic()
        {
            ushort* ret = ImGuiNative.ImFontAtlas_GetGlyphRangesCyrillic((ImFontAtlas*)(NativePtr));
            return (IntPtr)ret;
        }
        /// <summary>
        /// Gets the glyph ranges default
        /// </summary>
        /// <returns>The int ptr</returns>
        public IntPtr GetGlyphRangesDefault()
        {
            ushort* ret = ImGuiNative.ImFontAtlas_GetGlyphRangesDefault((ImFontAtlas*)(NativePtr));
            return (IntPtr)ret;
        }
        /// <summary>
        /// Gets the glyph ranges greek
        /// </summary>
        /// <returns>The int ptr</returns>
        public IntPtr GetGlyphRangesGreek()
        {
            ushort* ret = ImGuiNative.ImFontAtlas_GetGlyphRangesGreek((ImFontAtlas*)(NativePtr));
            return (IntPtr)ret;
        }
        /// <summary>
        /// Gets the glyph ranges japanese
        /// </summary>
        /// <returns>The int ptr</returns>
        public IntPtr GetGlyphRangesJapanese()
        {
            ushort* ret = ImGuiNative.ImFontAtlas_GetGlyphRangesJapanese((ImFontAtlas*)(NativePtr));
            return (IntPtr)ret;
        }
        /// <summary>
        /// Gets the glyph ranges korean
        /// </summary>
        /// <returns>The int ptr</returns>
        public IntPtr GetGlyphRangesKorean()
        {
            ushort* ret = ImGuiNative.ImFontAtlas_GetGlyphRangesKorean((ImFontAtlas*)(NativePtr));
            return (IntPtr)ret;
        }
        /// <summary>
        /// Gets the glyph ranges thai
        /// </summary>
        /// <returns>The int ptr</returns>
        public IntPtr GetGlyphRangesThai()
        {
            ushort* ret = ImGuiNative.ImFontAtlas_GetGlyphRangesThai((ImFontAtlas*)(NativePtr));
            return (IntPtr)ret;
        }
        /// <summary>
        /// Gets the glyph ranges vietnamese
        /// </summary>
        /// <returns>The int ptr</returns>
        public IntPtr GetGlyphRangesVietnamese()
        {
            ushort* ret = ImGuiNative.ImFontAtlas_GetGlyphRangesVietnamese((ImFontAtlas*)(NativePtr));
            return (IntPtr)ret;
        }
        /// <summary>
        /// Describes whether this instance get mouse cursor tex data
        /// </summary>
        /// <param name="cursor">The cursor</param>
        /// <param name="out_offset">The out offset</param>
        /// <param name="out_size">The out size</param>
        /// <param name="out_uv_border">The out uv border</param>
        /// <param name="out_uv_fill">The out uv fill</param>
        /// <returns>The bool</returns>
        public bool GetMouseCursorTexData(ImGuiMouseCursor cursor, out Vector2 out_offset, out Vector2 out_size, out Vector2 out_uv_border, out Vector2 out_uv_fill)
        {
            fixed (Vector2* native_out_offset = &out_offset)
            {
                fixed (Vector2* native_out_size = &out_size)
                {
                    fixed (Vector2* native_out_uv_border = &out_uv_border)
                    {
                        fixed (Vector2* native_out_uv_fill = &out_uv_fill)
                        {
                            byte ret = ImGuiNative.ImFontAtlas_GetMouseCursorTexData((ImFontAtlas*)(NativePtr), cursor, native_out_offset, native_out_size, native_out_uv_border, native_out_uv_fill);
                            return ret != 0;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Gets the tex data as alpha 8 using the specified out pixels
        /// </summary>
        /// <param name="out_pixels">The out pixels</param>
        /// <param name="out_width">The out width</param>
        /// <param name="out_height">The out height</param>
        public void GetTexDataAsAlpha8(out byte* out_pixels, out int out_width, out int out_height)
        {
            int* out_bytes_per_pixel = null;
            fixed (byte** native_out_pixels = &out_pixels)
            {
                fixed (int* native_out_width = &out_width)
                {
                    fixed (int* native_out_height = &out_height)
                    {
                        ImGuiNative.ImFontAtlas_GetTexDataAsAlpha8((ImFontAtlas*)(NativePtr), native_out_pixels, native_out_width, native_out_height, out_bytes_per_pixel);
                    }
                }
            }
        }
        /// <summary>
        /// Gets the tex data as alpha 8 using the specified out pixels
        /// </summary>
        /// <param name="out_pixels">The out pixels</param>
        /// <param name="out_width">The out width</param>
        /// <param name="out_height">The out height</param>
        /// <param name="out_bytes_per_pixel">The out bytes per pixel</param>
        public void GetTexDataAsAlpha8(out byte* out_pixels, out int out_width, out int out_height, out int out_bytes_per_pixel)
        {
            fixed (byte** native_out_pixels = &out_pixels)
            {
                fixed (int* native_out_width = &out_width)
                {
                    fixed (int* native_out_height = &out_height)
                    {
                        fixed (int* native_out_bytes_per_pixel = &out_bytes_per_pixel)
                        {
                            ImGuiNative.ImFontAtlas_GetTexDataAsAlpha8((ImFontAtlas*)(NativePtr), native_out_pixels, native_out_width, native_out_height, native_out_bytes_per_pixel);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Gets the tex data as alpha 8 using the specified out pixels
        /// </summary>
        /// <param name="out_pixels">The out pixels</param>
        /// <param name="out_width">The out width</param>
        /// <param name="out_height">The out height</param>
        public void GetTexDataAsAlpha8(out IntPtr out_pixels, out int out_width, out int out_height)
        {
            int* out_bytes_per_pixel = null;
            fixed (IntPtr* native_out_pixels = &out_pixels)
            {
                fixed (int* native_out_width = &out_width)
                {
                    fixed (int* native_out_height = &out_height)
                    {
                        ImGuiNative.ImFontAtlas_GetTexDataAsAlpha8((ImFontAtlas*)(NativePtr), native_out_pixels, native_out_width, native_out_height, out_bytes_per_pixel);
                    }
                }
            }
        }
        /// <summary>
        /// Gets the tex data as alpha 8 using the specified out pixels
        /// </summary>
        /// <param name="out_pixels">The out pixels</param>
        /// <param name="out_width">The out width</param>
        /// <param name="out_height">The out height</param>
        /// <param name="out_bytes_per_pixel">The out bytes per pixel</param>
        public void GetTexDataAsAlpha8(out IntPtr out_pixels, out int out_width, out int out_height, out int out_bytes_per_pixel)
        {
            fixed (IntPtr* native_out_pixels = &out_pixels)
            {
                fixed (int* native_out_width = &out_width)
                {
                    fixed (int* native_out_height = &out_height)
                    {
                        fixed (int* native_out_bytes_per_pixel = &out_bytes_per_pixel)
                        {
                            ImGuiNative.ImFontAtlas_GetTexDataAsAlpha8((ImFontAtlas*)(NativePtr), native_out_pixels, native_out_width, native_out_height, native_out_bytes_per_pixel);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Gets the tex data as rgba 32 using the specified out pixels
        /// </summary>
        /// <param name="out_pixels">The out pixels</param>
        /// <param name="out_width">The out width</param>
        /// <param name="out_height">The out height</param>
        public void GetTexDataAsRGBA32(out byte* out_pixels, out int out_width, out int out_height)
        {
            int* out_bytes_per_pixel = null;
            fixed (byte** native_out_pixels = &out_pixels)
            {
                fixed (int* native_out_width = &out_width)
                {
                    fixed (int* native_out_height = &out_height)
                    {
                        ImGuiNative.ImFontAtlas_GetTexDataAsRGBA32((ImFontAtlas*)(NativePtr), native_out_pixels, native_out_width, native_out_height, out_bytes_per_pixel);
                    }
                }
            }
        }
        /// <summary>
        /// Gets the tex data as rgba 32 using the specified out pixels
        /// </summary>
        /// <param name="out_pixels">The out pixels</param>
        /// <param name="out_width">The out width</param>
        /// <param name="out_height">The out height</param>
        /// <param name="out_bytes_per_pixel">The out bytes per pixel</param>
        public void GetTexDataAsRGBA32(out byte* out_pixels, out int out_width, out int out_height, out int out_bytes_per_pixel)
        {
            fixed (byte** native_out_pixels = &out_pixels)
            {
                fixed (int* native_out_width = &out_width)
                {
                    fixed (int* native_out_height = &out_height)
                    {
                        fixed (int* native_out_bytes_per_pixel = &out_bytes_per_pixel)
                        {
                            ImGuiNative.ImFontAtlas_GetTexDataAsRGBA32((ImFontAtlas*)(NativePtr), native_out_pixels, native_out_width, native_out_height, native_out_bytes_per_pixel);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Gets the tex data as rgba 32 using the specified out pixels
        /// </summary>
        /// <param name="out_pixels">The out pixels</param>
        /// <param name="out_width">The out width</param>
        /// <param name="out_height">The out height</param>
        public void GetTexDataAsRGBA32(out IntPtr out_pixels, out int out_width, out int out_height)
        {
            int* out_bytes_per_pixel = null;
            fixed (IntPtr* native_out_pixels = &out_pixels)
            {
                fixed (int* native_out_width = &out_width)
                {
                    fixed (int* native_out_height = &out_height)
                    {
                        ImGuiNative.ImFontAtlas_GetTexDataAsRGBA32((ImFontAtlas*)(NativePtr), native_out_pixels, native_out_width, native_out_height, out_bytes_per_pixel);
                    }
                }
            }
        }
        /// <summary>
        /// Gets the tex data as rgba 32 using the specified out pixels
        /// </summary>
        /// <param name="out_pixels">The out pixels</param>
        /// <param name="out_width">The out width</param>
        /// <param name="out_height">The out height</param>
        /// <param name="out_bytes_per_pixel">The out bytes per pixel</param>
        public void GetTexDataAsRGBA32(out IntPtr out_pixels, out int out_width, out int out_height, out int out_bytes_per_pixel)
        {
            fixed (IntPtr* native_out_pixels = &out_pixels)
            {
                fixed (int* native_out_width = &out_width)
                {
                    fixed (int* native_out_height = &out_height)
                    {
                        fixed (int* native_out_bytes_per_pixel = &out_bytes_per_pixel)
                        {
                            ImGuiNative.ImFontAtlas_GetTexDataAsRGBA32((ImFontAtlas*)(NativePtr), native_out_pixels, native_out_width, native_out_height, native_out_bytes_per_pixel);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Describes whether this instance is built
        /// </summary>
        /// <returns>The bool</returns>
        public bool IsBuilt()
        {
            byte ret = ImGuiNative.ImFontAtlas_IsBuilt((ImFontAtlas*)(NativePtr));
            return ret != 0;
        }
        /// <summary>
        /// Sets the tex id using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        public void SetTexID(IntPtr id)
        {
            ImGuiNative.ImFontAtlas_SetTexID((ImFontAtlas*)(NativePtr), id);
        }
    }
}
