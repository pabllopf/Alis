using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using Alis.Core.Graphic.ImGui.Utils;

namespace Alis.Core.Graphic.Imgui
{
    /// <summary>
    /// The im gui viewport
    /// </summary>
    public unsafe partial struct ImGuiViewport
    {
        /// <summary>
        /// The id
        /// </summary>
        public uint ID;
        /// <summary>
        /// The flags
        /// </summary>
        public ImGuiViewportFlags Flags;
        /// <summary>
        /// The pos
        /// </summary>
        public Vector2 Pos;
        /// <summary>
        /// The size
        /// </summary>
        public Vector2 Size;
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
        /// <summary>
        /// The parent viewport id
        /// </summary>
        public uint ParentViewportId;
        /// <summary>
        /// The draw data
        /// </summary>
        public ImDrawData* DrawData;
        /// <summary>
        /// The renderer user data
        /// </summary>
        public void* RendererUserData;
        /// <summary>
        /// The platform user data
        /// </summary>
        public void* PlatformUserData;
        /// <summary>
        /// The platform handle
        /// </summary>
        public void* PlatformHandle;
        /// <summary>
        /// The platform handle raw
        /// </summary>
        public void* PlatformHandleRaw;
        /// <summary>
        /// The platform window created
        /// </summary>
        public byte PlatformWindowCreated;
        /// <summary>
        /// The platform request move
        /// </summary>
        public byte PlatformRequestMove;
        /// <summary>
        /// The platform request resize
        /// </summary>
        public byte PlatformRequestResize;
        /// <summary>
        /// The platform request close
        /// </summary>
        public byte PlatformRequestClose;
    }
    /// <summary>
    /// The im gui viewport ptr
    /// </summary>
    public unsafe partial struct ImGuiViewportPtr
    {
        /// <summary>
        /// Gets the value of the native ptr
        /// </summary>
        public ImGuiViewport* NativePtr { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ImGuiViewportPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiViewportPtr(ImGuiViewport* nativePtr) => NativePtr = nativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="ImGuiViewportPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiViewportPtr(IntPtr nativePtr) => NativePtr = (ImGuiViewport*)nativePtr;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiViewportPtr(ImGuiViewport* nativePtr) => new ImGuiViewportPtr(nativePtr);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiViewport* (ImGuiViewportPtr wrappedPtr) => wrappedPtr.NativePtr;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiViewportPtr(IntPtr nativePtr) => new ImGuiViewportPtr(nativePtr);
        /// <summary>
        /// Gets the value of the id
        /// </summary>
        public ref uint ID => ref Unsafe.AsRef<uint>(&NativePtr->ID);
        /// <summary>
        /// Gets the value of the flags
        /// </summary>
        public ref ImGuiViewportFlags Flags => ref Unsafe.AsRef<ImGuiViewportFlags>(&NativePtr->Flags);
        /// <summary>
        /// Gets the value of the pos
        /// </summary>
        public ref Vector2 Pos => ref Unsafe.AsRef<Vector2>(&NativePtr->Pos);
        /// <summary>
        /// Gets the value of the size
        /// </summary>
        public ref Vector2 Size => ref Unsafe.AsRef<Vector2>(&NativePtr->Size);
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
        /// Gets the value of the parent viewport id
        /// </summary>
        public ref uint ParentViewportId => ref Unsafe.AsRef<uint>(&NativePtr->ParentViewportId);
        /// <summary>
        /// Gets the value of the draw data
        /// </summary>
        public ImDrawDataPtr DrawData => new ImDrawDataPtr(NativePtr->DrawData);
        /// <summary>
        /// Gets or sets the value of the renderer user data
        /// </summary>
        public IntPtr RendererUserData { get => (IntPtr)NativePtr->RendererUserData; set => NativePtr->RendererUserData = (void*)value; }
        /// <summary>
        /// Gets or sets the value of the platform user data
        /// </summary>
        public IntPtr PlatformUserData { get => (IntPtr)NativePtr->PlatformUserData; set => NativePtr->PlatformUserData = (void*)value; }
        /// <summary>
        /// Gets or sets the value of the platform handle
        /// </summary>
        public IntPtr PlatformHandle { get => (IntPtr)NativePtr->PlatformHandle; set => NativePtr->PlatformHandle = (void*)value; }
        /// <summary>
        /// Gets or sets the value of the platform handle raw
        /// </summary>
        public IntPtr PlatformHandleRaw { get => (IntPtr)NativePtr->PlatformHandleRaw; set => NativePtr->PlatformHandleRaw = (void*)value; }
        /// <summary>
        /// Gets the value of the platform window created
        /// </summary>
        public ref bool PlatformWindowCreated => ref Unsafe.AsRef<bool>(&NativePtr->PlatformWindowCreated);
        /// <summary>
        /// Gets the value of the platform request move
        /// </summary>
        public ref bool PlatformRequestMove => ref Unsafe.AsRef<bool>(&NativePtr->PlatformRequestMove);
        /// <summary>
        /// Gets the value of the platform request resize
        /// </summary>
        public ref bool PlatformRequestResize => ref Unsafe.AsRef<bool>(&NativePtr->PlatformRequestResize);
        /// <summary>
        /// Gets the value of the platform request close
        /// </summary>
        public ref bool PlatformRequestClose => ref Unsafe.AsRef<bool>(&NativePtr->PlatformRequestClose);
        /// <summary>
        /// Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImGuiNative.ImGuiViewport_destroy((ImGuiViewport*)(NativePtr));
        }
        /// <summary>
        /// Gets the center
        /// </summary>
        /// <returns>The retval</returns>
        public Vector2 GetCenter()
        {
            Vector2 __retval;
            ImGuiNative.ImGuiViewport_GetCenter(&__retval, (ImGuiViewport*)(NativePtr));
            return __retval;
        }
        /// <summary>
        /// Gets the work center
        /// </summary>
        /// <returns>The retval</returns>
        public Vector2 GetWorkCenter()
        {
            Vector2 __retval;
            ImGuiNative.ImGuiViewport_GetWorkCenter(&__retval, (ImGuiViewport*)(NativePtr));
            return __retval;
        }
    }
}
