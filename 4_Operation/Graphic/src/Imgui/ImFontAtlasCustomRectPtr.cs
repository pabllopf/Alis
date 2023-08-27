using System;
using System.Numerics;
using Alis.Core.Graphic.ImGui.Utils;

namespace Alis.Core.Graphic.Imgui
{
    /// <summary>
    /// The im font atlas custom rect ptr
    /// </summary>
    public unsafe struct ImFontAtlasCustomRectPtr
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