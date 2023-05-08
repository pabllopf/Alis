using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace ImGuiNET
{
    /// <summary>
    /// The im gui window
    /// </summary>
    public unsafe partial struct ImGuiWindowClass
    {
        /// <summary>
        /// The class id
        /// </summary>
        public uint ClassId;
        /// <summary>
        /// The parent viewport id
        /// </summary>
        public uint ParentViewportId;
        /// <summary>
        /// The viewport flags override set
        /// </summary>
        public ImGuiViewportFlags ViewportFlagsOverrideSet;
        /// <summary>
        /// The viewport flags override clear
        /// </summary>
        public ImGuiViewportFlags ViewportFlagsOverrideClear;
        /// <summary>
        /// The tab item flags override set
        /// </summary>
        public ImGuiTabItemFlags TabItemFlagsOverrideSet;
        /// <summary>
        /// The dock node flags override set
        /// </summary>
        public ImGuiDockNodeFlags DockNodeFlagsOverrideSet;
        /// <summary>
        /// The docking always tab bar
        /// </summary>
        public byte DockingAlwaysTabBar;
        /// <summary>
        /// The docking allow unclassed
        /// </summary>
        public byte DockingAllowUnclassed;
    }
    /// <summary>
    /// The im gui window class ptr
    /// </summary>
    public unsafe partial struct ImGuiWindowClassPtr
    {
        /// <summary>
        /// Gets the value of the native ptr
        /// </summary>
        public ImGuiWindowClass* NativePtr { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ImGuiWindowClassPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiWindowClassPtr(ImGuiWindowClass* nativePtr) => NativePtr = nativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="ImGuiWindowClassPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiWindowClassPtr(IntPtr nativePtr) => NativePtr = (ImGuiWindowClass*)nativePtr;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiWindowClassPtr(ImGuiWindowClass* nativePtr) => new ImGuiWindowClassPtr(nativePtr);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiWindowClass* (ImGuiWindowClassPtr wrappedPtr) => wrappedPtr.NativePtr;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiWindowClassPtr(IntPtr nativePtr) => new ImGuiWindowClassPtr(nativePtr);
        /// <summary>
        /// Gets the value of the class id
        /// </summary>
        public ref uint ClassId => ref Unsafe.AsRef<uint>(&NativePtr->ClassId);
        /// <summary>
        /// Gets the value of the parent viewport id
        /// </summary>
        public ref uint ParentViewportId => ref Unsafe.AsRef<uint>(&NativePtr->ParentViewportId);
        /// <summary>
        /// Gets the value of the viewport flags override set
        /// </summary>
        public ref ImGuiViewportFlags ViewportFlagsOverrideSet => ref Unsafe.AsRef<ImGuiViewportFlags>(&NativePtr->ViewportFlagsOverrideSet);
        /// <summary>
        /// Gets the value of the viewport flags override clear
        /// </summary>
        public ref ImGuiViewportFlags ViewportFlagsOverrideClear => ref Unsafe.AsRef<ImGuiViewportFlags>(&NativePtr->ViewportFlagsOverrideClear);
        /// <summary>
        /// Gets the value of the tab item flags override set
        /// </summary>
        public ref ImGuiTabItemFlags TabItemFlagsOverrideSet => ref Unsafe.AsRef<ImGuiTabItemFlags>(&NativePtr->TabItemFlagsOverrideSet);
        /// <summary>
        /// Gets the value of the dock node flags override set
        /// </summary>
        public ref ImGuiDockNodeFlags DockNodeFlagsOverrideSet => ref Unsafe.AsRef<ImGuiDockNodeFlags>(&NativePtr->DockNodeFlagsOverrideSet);
        /// <summary>
        /// Gets the value of the docking always tab bar
        /// </summary>
        public ref bool DockingAlwaysTabBar => ref Unsafe.AsRef<bool>(&NativePtr->DockingAlwaysTabBar);
        /// <summary>
        /// Gets the value of the docking allow unclassed
        /// </summary>
        public ref bool DockingAllowUnclassed => ref Unsafe.AsRef<bool>(&NativePtr->DockingAllowUnclassed);
        /// <summary>
        /// Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImGuiNative.ImGuiWindowClass_destroy((ImGuiWindowClass*)(NativePtr));
        }
    }
}
