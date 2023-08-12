using System;
using System.Runtime.CompilerServices;

namespace Alis.Core.Graphic.Imgui.Extras.ImPlot
{
    /// <summary>
    /// The im plot input map
    /// </summary>
    public unsafe partial struct ImPlotInputMap
    {
        /// <summary>
        /// The pan
        /// </summary>
        public ImGuiMouseButton Pan;
        /// <summary>
        /// The pan mod
        /// </summary>
        public ImGuiModFlags PanMod;
        /// <summary>
        /// The fit
        /// </summary>
        public ImGuiMouseButton Fit;
        /// <summary>
        /// The select
        /// </summary>
        public ImGuiMouseButton Select;
        /// <summary>
        /// The select cancel
        /// </summary>
        public ImGuiMouseButton SelectCancel;
        /// <summary>
        /// The select mod
        /// </summary>
        public ImGuiModFlags SelectMod;
        /// <summary>
        /// The select horz mod
        /// </summary>
        public ImGuiModFlags SelectHorzMod;
        /// <summary>
        /// The select vert mod
        /// </summary>
        public ImGuiModFlags SelectVertMod;
        /// <summary>
        /// The menu
        /// </summary>
        public ImGuiMouseButton Menu;
        /// <summary>
        /// The override mod
        /// </summary>
        public ImGuiModFlags OverrideMod;
        /// <summary>
        /// The zoom mod
        /// </summary>
        public ImGuiModFlags ZoomMod;
        /// <summary>
        /// The zoom rate
        /// </summary>
        public float ZoomRate;
    }
    /// <summary>
    /// The im plot input map ptr
    /// </summary>
    public unsafe partial struct ImPlotInputMapPtr
    {
        /// <summary>
        /// Gets the value of the native ptr
        /// </summary>
        public ImPlotInputMap* NativePtr { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ImPlotInputMapPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImPlotInputMapPtr(ImPlotInputMap* nativePtr) => NativePtr = nativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="ImPlotInputMapPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImPlotInputMapPtr(IntPtr nativePtr) => NativePtr = (ImPlotInputMap*)nativePtr;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImPlotInputMapPtr(ImPlotInputMap* nativePtr) => new ImPlotInputMapPtr(nativePtr);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator ImPlotInputMap* (ImPlotInputMapPtr wrappedPtr) => wrappedPtr.NativePtr;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImPlotInputMapPtr(IntPtr nativePtr) => new ImPlotInputMapPtr(nativePtr);
        /// <summary>
        /// Gets the value of the pan
        /// </summary>
        public ref ImGuiMouseButton Pan => ref Unsafe.AsRef<ImGuiMouseButton>(&NativePtr->Pan);
        /// <summary>
        /// Gets the value of the pan mod
        /// </summary>
        public ref ImGuiModFlags PanMod => ref Unsafe.AsRef<ImGuiModFlags>(&NativePtr->PanMod);
        /// <summary>
        /// Gets the value of the fit
        /// </summary>
        public ref ImGuiMouseButton Fit => ref Unsafe.AsRef<ImGuiMouseButton>(&NativePtr->Fit);
        /// <summary>
        /// Gets the value of the select
        /// </summary>
        public ref ImGuiMouseButton Select => ref Unsafe.AsRef<ImGuiMouseButton>(&NativePtr->Select);
        /// <summary>
        /// Gets the value of the select cancel
        /// </summary>
        public ref ImGuiMouseButton SelectCancel => ref Unsafe.AsRef<ImGuiMouseButton>(&NativePtr->SelectCancel);
        /// <summary>
        /// Gets the value of the select mod
        /// </summary>
        public ref ImGuiModFlags SelectMod => ref Unsafe.AsRef<ImGuiModFlags>(&NativePtr->SelectMod);
        /// <summary>
        /// Gets the value of the select horz mod
        /// </summary>
        public ref ImGuiModFlags SelectHorzMod => ref Unsafe.AsRef<ImGuiModFlags>(&NativePtr->SelectHorzMod);
        /// <summary>
        /// Gets the value of the select vert mod
        /// </summary>
        public ref ImGuiModFlags SelectVertMod => ref Unsafe.AsRef<ImGuiModFlags>(&NativePtr->SelectVertMod);
        /// <summary>
        /// Gets the value of the menu
        /// </summary>
        public ref ImGuiMouseButton Menu => ref Unsafe.AsRef<ImGuiMouseButton>(&NativePtr->Menu);
        /// <summary>
        /// Gets the value of the override mod
        /// </summary>
        public ref ImGuiModFlags OverrideMod => ref Unsafe.AsRef<ImGuiModFlags>(&NativePtr->OverrideMod);
        /// <summary>
        /// Gets the value of the zoom mod
        /// </summary>
        public ref ImGuiModFlags ZoomMod => ref Unsafe.AsRef<ImGuiModFlags>(&NativePtr->ZoomMod);
        /// <summary>
        /// Gets the value of the zoom rate
        /// </summary>
        public ref float ZoomRate => ref Unsafe.AsRef<float>(&NativePtr->ZoomRate);
        /// <summary>
        /// Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImPlotNative.ImPlotInputMap_destroy((ImPlotInputMap*)(NativePtr));
        }
    }
}
