using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace ImGuiNET
{
    /// <summary>
    /// The im gui platform monitor
    /// </summary>
    public unsafe partial struct ImGuiPlatformMonitor
    {
        /// <summary>
        /// The main pos
        /// </summary>
        public Vector2 MainPos;
        /// <summary>
        /// The main size
        /// </summary>
        public Vector2 MainSize;
        /// <summary>
        /// The work pos
        /// </summary>
        public Vector2 WorkPos;
        /// <summary>
        /// The work size
        /// </summary>
        public Vector2 WorkSize;
        /// <summary>
        /// The dpi scale
        /// </summary>
        public float DpiScale;
    }
    /// <summary>
    /// The im gui platform monitor ptr
    /// </summary>
    public unsafe partial struct ImGuiPlatformMonitorPtr
    {
        /// <summary>
        /// Gets the value of the native ptr
        /// </summary>
        public ImGuiPlatformMonitor* NativePtr { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ImGuiPlatformMonitorPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiPlatformMonitorPtr(ImGuiPlatformMonitor* nativePtr) => NativePtr = nativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="ImGuiPlatformMonitorPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiPlatformMonitorPtr(IntPtr nativePtr) => NativePtr = (ImGuiPlatformMonitor*)nativePtr;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiPlatformMonitorPtr(ImGuiPlatformMonitor* nativePtr) => new ImGuiPlatformMonitorPtr(nativePtr);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiPlatformMonitor* (ImGuiPlatformMonitorPtr wrappedPtr) => wrappedPtr.NativePtr;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiPlatformMonitorPtr(IntPtr nativePtr) => new ImGuiPlatformMonitorPtr(nativePtr);
        /// <summary>
        /// Gets the value of the main pos
        /// </summary>
        public ref Vector2 MainPos => ref Unsafe.AsRef<Vector2>(&NativePtr->MainPos);
        /// <summary>
        /// Gets the value of the main size
        /// </summary>
        public ref Vector2 MainSize => ref Unsafe.AsRef<Vector2>(&NativePtr->MainSize);
        /// <summary>
        /// Gets the value of the work pos
        /// </summary>
        public ref Vector2 WorkPos => ref Unsafe.AsRef<Vector2>(&NativePtr->WorkPos);
        /// <summary>
        /// Gets the value of the work size
        /// </summary>
        public ref Vector2 WorkSize => ref Unsafe.AsRef<Vector2>(&NativePtr->WorkSize);
        /// <summary>
        /// Gets the value of the dpi scale
        /// </summary>
        public ref float DpiScale => ref Unsafe.AsRef<float>(&NativePtr->DpiScale);
        /// <summary>
        /// Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImGuiNative.ImGuiPlatformMonitor_destroy((ImGuiPlatformMonitor*)(NativePtr));
        }
    }
}
