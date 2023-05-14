using System;
using System.Numerics;

namespace Alis.Core.Graphic.ImGui.ImGui
{
    /// <summary>
    /// The im font atlas custom rect
    /// </summary>
    public unsafe partial struct ImFontAtlasCustomRect
    {
        /// <summary>
        /// The width
        /// </summary>
        public ushort Width;
        /// <summary>
        /// The height
        /// </summary>
        public ushort Height;
        /// <summary>
        /// The 
        /// </summary>
        public ushort X;
        /// <summary>
        /// The 
        /// </summary>
        public ushort Y;
        /// <summary>
        /// The glyph id
        /// </summary>
        public uint GlyphID;
        /// <summary>
        /// The glyph advance
        /// </summary>
        public float GlyphAdvanceX;
        /// <summary>
        /// The glyph offset
        /// </summary>
        public Vector2 GlyphOffset;
        /// <summary>
        /// The font
        /// </summary>
        public ImFont* Font;
    }
    /// <summary>
    /// The im font atlas custom rect ptr
    /// </summary>
    public unsafe partial struct ImFontAtlasCustomRectPtr
    {
        /// <summary>
        /// Gets the value of the native ptr
        /// </summary>
        public ImFontAtlasCustomRect* NativePtr { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ImFontAtlasCustomRectPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImFontAtlasCustomRectPtr(ImFontAtlasCustomRect* nativePtr) => NativePtr = nativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="ImFontAtlasCustomRectPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImFontAtlasCustomRectPtr(IntPtr nativePtr) => NativePtr = (ImFontAtlasCustomRect*)nativePtr;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImFontAtlasCustomRectPtr(ImFontAtlasCustomRect* nativePtr) => new ImFontAtlasCustomRectPtr(nativePtr);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator ImFontAtlasCustomRect* (ImFontAtlasCustomRectPtr wrappedPtr) => wrappedPtr.NativePtr;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImFontAtlasCustomRectPtr(IntPtr nativePtr) => new ImFontAtlasCustomRectPtr(nativePtr);
        /// <summary>
        /// Gets the value of the width
        /// </summary>
        public ref ushort Width => ref Unsafe.AsRef<ushort>(&NativePtr->Width);
        /// <summary>
        /// Gets the value of the height
        /// </summary>
        public ref ushort Height => ref Unsafe.AsRef<ushort>(&NativePtr->Height);
        /// <summary>
        /// Gets the value of the x
        /// </summary>
        public ref ushort X => ref Unsafe.AsRef<ushort>(&NativePtr->X);
        /// <summary>
        /// Gets the value of the y
        /// </summary>
        public ref ushort Y => ref Unsafe.AsRef<ushort>(&NativePtr->Y);
        /// <summary>
        /// Gets the value of the glyph id
        /// </summary>
        public ref uint GlyphID => ref Unsafe.AsRef<uint>(&NativePtr->GlyphID);
        /// <summary>
        /// Gets the value of the glyph advance x
        /// </summary>
        public ref float GlyphAdvanceX => ref Unsafe.AsRef<float>(&NativePtr->GlyphAdvanceX);
        /// <summary>
        /// Gets the value of the glyph offset
        /// </summary>
        public ref Vector2 GlyphOffset => ref Unsafe.AsRef<Vector2>(&NativePtr->GlyphOffset);
        /// <summary>
        /// Gets the value of the font
        /// </summary>
        public ImFontPtr Font => new ImFontPtr(NativePtr->Font);
        /// <summary>
        /// Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImGuiNative.ImFontAtlasCustomRect_destroy((ImFontAtlasCustomRect*)(NativePtr));
        }
        /// <summary>
        /// Describes whether this instance is packed
        /// </summary>
        /// <returns>The bool</returns>
        public bool IsPacked()
        {
            byte ret = ImGuiNative.ImFontAtlasCustomRect_IsPacked((ImFontAtlasCustomRect*)(NativePtr));
            return ret != 0;
        }
    }
}
