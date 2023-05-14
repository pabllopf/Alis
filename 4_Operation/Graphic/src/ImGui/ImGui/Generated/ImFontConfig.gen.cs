using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using Unsafe = Alis.Core.Graphic.ImGui.ImGui.UnsafeCode.Unsafe;

namespace ImGuiNET
{
    /// <summary>
    /// The im font config
    /// </summary>
    public unsafe partial struct ImFontConfig
    {
        /// <summary>
        /// The font data
        /// </summary>
        public void* FontData;
        /// <summary>
        /// The font data size
        /// </summary>
        public int FontDataSize;
        /// <summary>
        /// The font data owned by atlas
        /// </summary>
        public byte FontDataOwnedByAtlas;
        /// <summary>
        /// The font no
        /// </summary>
        public int FontNo;
        /// <summary>
        /// The size pixels
        /// </summary>
        public float SizePixels;
        /// <summary>
        /// The oversample
        /// </summary>
        public int OversampleH;
        /// <summary>
        /// The oversample
        /// </summary>
        public int OversampleV;
        /// <summary>
        /// The pixel snap
        /// </summary>
        public byte PixelSnapH;
        /// <summary>
        /// The glyph extra spacing
        /// </summary>
        public Vector2 GlyphExtraSpacing;
        /// <summary>
        /// The glyph offset
        /// </summary>
        public Vector2 GlyphOffset;
        /// <summary>
        /// The glyph ranges
        /// </summary>
        public ushort* GlyphRanges;
        /// <summary>
        /// The glyph min advance
        /// </summary>
        public float GlyphMinAdvanceX;
        /// <summary>
        /// The glyph max advance
        /// </summary>
        public float GlyphMaxAdvanceX;
        /// <summary>
        /// The merge mode
        /// </summary>
        public byte MergeMode;
        /// <summary>
        /// The font builder flags
        /// </summary>
        public uint FontBuilderFlags;
        /// <summary>
        /// The rasterizer multiply
        /// </summary>
        public float RasterizerMultiply;
        /// <summary>
        /// The ellipsis char
        /// </summary>
        public ushort EllipsisChar;
        /// <summary>
        /// The name
        /// </summary>
        public fixed byte Name[40];
        /// <summary>
        /// The dst font
        /// </summary>
        public ImFont* DstFont;
    }
    /// <summary>
    /// The im font config ptr
    /// </summary>
    public unsafe partial struct ImFontConfigPtr
    {
        /// <summary>
        /// Gets the value of the native ptr
        /// </summary>
        public ImFontConfig* NativePtr { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ImFontConfigPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImFontConfigPtr(ImFontConfig* nativePtr) => NativePtr = nativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="ImFontConfigPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImFontConfigPtr(IntPtr nativePtr) => NativePtr = (ImFontConfig*)nativePtr;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImFontConfigPtr(ImFontConfig* nativePtr) => new ImFontConfigPtr(nativePtr);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator ImFontConfig* (ImFontConfigPtr wrappedPtr) => wrappedPtr.NativePtr;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImFontConfigPtr(IntPtr nativePtr) => new ImFontConfigPtr(nativePtr);
        /// <summary>
        /// Gets or sets the value of the font data
        /// </summary>
        public IntPtr FontData { get => (IntPtr)NativePtr->FontData; set => NativePtr->FontData = (void*)value; }
        /// <summary>
        /// Gets the value of the font data size
        /// </summary>
        public ref int FontDataSize => ref Unsafe.AsRef<int>(&NativePtr->FontDataSize);
        /// <summary>
        /// Gets the value of the font data owned by atlas
        /// </summary>
        public ref bool FontDataOwnedByAtlas => ref Unsafe.AsRef<bool>(&NativePtr->FontDataOwnedByAtlas);
        /// <summary>
        /// Gets the value of the font no
        /// </summary>
        public ref int FontNo => ref Unsafe.AsRef<int>(&NativePtr->FontNo);
        /// <summary>
        /// Gets the value of the size pixels
        /// </summary>
        public ref float SizePixels => ref Unsafe.AsRef<float>(&NativePtr->SizePixels);
        /// <summary>
        /// Gets the value of the oversample h
        /// </summary>
        public ref int OversampleH => ref Unsafe.AsRef<int>(&NativePtr->OversampleH);
        /// <summary>
        /// Gets the value of the oversample v
        /// </summary>
        public ref int OversampleV => ref Unsafe.AsRef<int>(&NativePtr->OversampleV);
        /// <summary>
        /// Gets the value of the pixel snap h
        /// </summary>
        public ref bool PixelSnapH => ref Unsafe.AsRef<bool>(&NativePtr->PixelSnapH);
        /// <summary>
        /// Gets the value of the glyph extra spacing
        /// </summary>
        public ref Vector2 GlyphExtraSpacing => ref Unsafe.AsRef<Vector2>(&NativePtr->GlyphExtraSpacing);
        /// <summary>
        /// Gets the value of the glyph offset
        /// </summary>
        public ref Vector2 GlyphOffset => ref Unsafe.AsRef<Vector2>(&NativePtr->GlyphOffset);
        /// <summary>
        /// Gets or sets the value of the glyph ranges
        /// </summary>
        public IntPtr GlyphRanges { get => (IntPtr)NativePtr->GlyphRanges; set => NativePtr->GlyphRanges = (ushort*)value; }
        /// <summary>
        /// Gets the value of the glyph min advance x
        /// </summary>
        public ref float GlyphMinAdvanceX => ref Unsafe.AsRef<float>(&NativePtr->GlyphMinAdvanceX);
        /// <summary>
        /// Gets the value of the glyph max advance x
        /// </summary>
        public ref float GlyphMaxAdvanceX => ref Unsafe.AsRef<float>(&NativePtr->GlyphMaxAdvanceX);
        /// <summary>
        /// Gets the value of the merge mode
        /// </summary>
        public ref bool MergeMode => ref Unsafe.AsRef<bool>(&NativePtr->MergeMode);
        /// <summary>
        /// Gets the value of the font builder flags
        /// </summary>
        public ref uint FontBuilderFlags => ref Unsafe.AsRef<uint>(&NativePtr->FontBuilderFlags);
        /// <summary>
        /// Gets the value of the rasterizer multiply
        /// </summary>
        public ref float RasterizerMultiply => ref Unsafe.AsRef<float>(&NativePtr->RasterizerMultiply);
        /// <summary>
        /// Gets the value of the ellipsis char
        /// </summary>
        public ref ushort EllipsisChar => ref Unsafe.AsRef<ushort>(&NativePtr->EllipsisChar);
        /// <summary>
        /// Gets the value of the name
        /// </summary>
        public RangeAccessor<byte> Name => new RangeAccessor<byte>(NativePtr->Name, 40);
        /// <summary>
        /// Gets the value of the dst font
        /// </summary>
        public ImFontPtr DstFont => new ImFontPtr(NativePtr->DstFont);
        /// <summary>
        /// Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImGuiNative.ImFontConfig_destroy((ImFontConfig*)(NativePtr));
        }
    }
}
