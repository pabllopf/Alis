using System;
using System.Runtime.CompilerServices;

namespace Alis.Core.Graphic.Imgui
{
    /// <summary>
    /// The stb textedit row
    /// </summary>
    public unsafe partial struct StbTexteditRow
    {
        /// <summary>
        /// The 
        /// </summary>
        public float x0;
        /// <summary>
        /// The 
        /// </summary>
        public float x1;
        /// <summary>
        /// The baseline delta
        /// </summary>
        public float baseline_y_delta;
        /// <summary>
        /// The ymin
        /// </summary>
        public float ymin;
        /// <summary>
        /// The ymax
        /// </summary>
        public float ymax;
        /// <summary>
        /// The num chars
        /// </summary>
        public int num_chars;
    }
    /// <summary>
    /// The stb textedit row ptr
    /// </summary>
    public unsafe partial struct StbTexteditRowPtr
    {
        /// <summary>
        /// Gets the value of the native ptr
        /// </summary>
        public StbTexteditRow* NativePtr { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="StbTexteditRowPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public StbTexteditRowPtr(StbTexteditRow* nativePtr) => NativePtr = nativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="StbTexteditRowPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public StbTexteditRowPtr(IntPtr nativePtr) => NativePtr = (StbTexteditRow*)nativePtr;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator StbTexteditRowPtr(StbTexteditRow* nativePtr) => new StbTexteditRowPtr(nativePtr);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator StbTexteditRow* (StbTexteditRowPtr wrappedPtr) => wrappedPtr.NativePtr;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator StbTexteditRowPtr(IntPtr nativePtr) => new StbTexteditRowPtr(nativePtr);
        /// <summary>
        /// Gets the value of the x 0
        /// </summary>
        public ref float x0 => ref Unsafe.AsRef<float>(&NativePtr->x0);
        /// <summary>
        /// Gets the value of the x 1
        /// </summary>
        public ref float x1 => ref Unsafe.AsRef<float>(&NativePtr->x1);
        /// <summary>
        /// Gets the value of the baseline y delta
        /// </summary>
        public ref float baseline_y_delta => ref Unsafe.AsRef<float>(&NativePtr->baseline_y_delta);
        /// <summary>
        /// Gets the value of the ymin
        /// </summary>
        public ref float ymin => ref Unsafe.AsRef<float>(&NativePtr->ymin);
        /// <summary>
        /// Gets the value of the ymax
        /// </summary>
        public ref float ymax => ref Unsafe.AsRef<float>(&NativePtr->ymax);
        /// <summary>
        /// Gets the value of the num chars
        /// </summary>
        public ref int num_chars => ref Unsafe.AsRef<int>(&NativePtr->num_chars);
    }
}
