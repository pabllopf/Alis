using System;
using System.Runtime.InteropServices;
using static Alis.Core.Graphic.Backends.Metal.ObjectiveCRuntime;

namespace Alis.Core.Graphic.Backends.Metal
{
    /// <summary>
    /// The mtl compile options
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLCompileOptions
    {
        /// <summary>
        /// The native ptr
        /// </summary>
        public readonly IntPtr NativePtr;

        public static implicit operator IntPtr(MTLCompileOptions mco) => mco.NativePtr;

        /// <summary>
        /// News
        /// </summary>
        /// <returns>The mtl compile options</returns>
        public static MTLCompileOptions New()
        {
            return s_class.AllocInit<MTLCompileOptions>();
        }

        /// <summary>
        /// Gets or sets the value of the fast math enabled
        /// </summary>
        public Bool8 fastMathEnabled
        {
            get => bool8_objc_msgSend(NativePtr, sel_fastMathEnabled);
            set => objc_msgSend(NativePtr, sel_setFastMathEnabled, value);
        }

        /// <summary>
        /// Gets or sets the value of the language version
        /// </summary>
        public MTLLanguageVersion languageVersion
        {
            get => (MTLLanguageVersion)uint_objc_msgSend(NativePtr, sel_languageVersion);
            set => objc_msgSend(NativePtr, sel_setLanguageVersion, (uint)value);
        }

        /// <summary>
        /// The mtl compile options
        /// </summary>
        private static readonly ObjCClass s_class = new ObjCClass(nameof(MTLCompileOptions));
        /// <summary>
        /// The sel fastmathenabled
        /// </summary>
        private static readonly Selector sel_fastMathEnabled = "fastMathEnabled";
        /// <summary>
        /// The sel setfastmathenabled
        /// </summary>
        private static readonly Selector sel_setFastMathEnabled = "setFastMathEnabled:";
        /// <summary>
        /// The sel languageversion
        /// </summary>
        private static readonly Selector sel_languageVersion = "languageVersion";
        /// <summary>
        /// The sel setlanguageversion
        /// </summary>
        private static readonly Selector sel_setLanguageVersion = "setLanguageVersion:";
    }
}