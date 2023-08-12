using System;
using System.Runtime.CompilerServices;

namespace Alis.Core.Graphic.Imgui
{
    /// <summary>
    /// The im font glyph
    /// </summary>
    public unsafe partial struct ImFontGlyph
    {
        /// <summary>
        /// The colored
        /// </summary>
        public uint Colored;
        /// <summary>
        /// The visible
        /// </summary>
        public uint Visible;
        /// <summary>
        /// The codepoint
        /// </summary>
        public uint Codepoint;
        /// <summary>
        /// The advance
        /// </summary>
        public float AdvanceX;
        /// <summary>
        /// The 
        /// </summary>
        public float X0;
        /// <summary>
        /// The 
        /// </summary>
        public float Y0;
        /// <summary>
        /// The 
        /// </summary>
        public float X1;
        /// <summary>
        /// The 
        /// </summary>
        public float Y1;
        /// <summary>
        /// The 
        /// </summary>
        public float U0;
        /// <summary>
        /// The 
        /// </summary>
        public float V0;
        /// <summary>
        /// The 
        /// </summary>
        public float U1;
        /// <summary>
        /// The 
        /// </summary>
        public float V1;
    }
    /// <summary>
    /// The im font glyph ptr
    /// </summary>
    public unsafe partial struct ImFontGlyphPtr
    {
        /// <summary>
        /// Gets the value of the native ptr
        /// </summary>
        public ImFontGlyph* NativePtr { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ImFontGlyphPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImFontGlyphPtr(ImFontGlyph* nativePtr) => NativePtr = nativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="ImFontGlyphPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImFontGlyphPtr(IntPtr nativePtr) => NativePtr = (ImFontGlyph*)nativePtr;
        public static implicit operator ImFontGlyphPtr(ImFontGlyph* nativePtr) => new ImFontGlyphPtr(nativePtr);
        public static implicit operator ImFontGlyph* (ImFontGlyphPtr wrappedPtr) => wrappedPtr.NativePtr;
        public static implicit operator ImFontGlyphPtr(IntPtr nativePtr) => new ImFontGlyphPtr(nativePtr);
        /// <summary>
        /// Gets the value of the colored
        /// </summary>
        public ref uint Colored => ref Unsafe.AsRef<uint>(&NativePtr->Colored);
        /// <summary>
        /// Gets the value of the visible
        /// </summary>
        public ref uint Visible => ref Unsafe.AsRef<uint>(&NativePtr->Visible);
        /// <summary>
        /// Gets the value of the codepoint
        /// </summary>
        public ref uint Codepoint => ref Unsafe.AsRef<uint>(&NativePtr->Codepoint);
        /// <summary>
        /// Gets the value of the advance x
        /// </summary>
        public ref float AdvanceX => ref Unsafe.AsRef<float>(&NativePtr->AdvanceX);
        /// <summary>
        /// Gets the value of the x 0
        /// </summary>
        public ref float X0 => ref Unsafe.AsRef<float>(&NativePtr->X0);
        /// <summary>
        /// Gets the value of the y 0
        /// </summary>
        public ref float Y0 => ref Unsafe.AsRef<float>(&NativePtr->Y0);
        /// <summary>
        /// Gets the value of the x 1
        /// </summary>
        public ref float X1 => ref Unsafe.AsRef<float>(&NativePtr->X1);
        /// <summary>
        /// Gets the value of the y 1
        /// </summary>
        public ref float Y1 => ref Unsafe.AsRef<float>(&NativePtr->Y1);
        /// <summary>
        /// Gets the value of the u 0
        /// </summary>
        public ref float U0 => ref Unsafe.AsRef<float>(&NativePtr->U0);
        /// <summary>
        /// Gets the value of the v 0
        /// </summary>
        public ref float V0 => ref Unsafe.AsRef<float>(&NativePtr->V0);
        /// <summary>
        /// Gets the value of the u 1
        /// </summary>
        public ref float U1 => ref Unsafe.AsRef<float>(&NativePtr->U1);
        /// <summary>
        /// Gets the value of the v 1
        /// </summary>
        public ref float V1 => ref Unsafe.AsRef<float>(&NativePtr->V1);
    }
}
