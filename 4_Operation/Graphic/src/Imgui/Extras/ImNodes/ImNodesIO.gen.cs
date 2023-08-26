using System;
using System.Runtime.CompilerServices;
using Alis.Core.Graphic.ImGui.Utils;

namespace Alis.Core.Graphic.Imgui.Extras.ImNodes
{
    /// <summary>
    /// The im nodes io
    /// </summary>
    public unsafe struct ImNodesIO
    {
        /// <summary>
        /// The emulate three button mouse
        /// </summary>
        public EmulateThreeButtonMouse EmulateThreeButtonMouse;
        /// <summary>
        /// The link detach with modifier click
        /// </summary>
        public LinkDetachWithModifierClick LinkDetachWithModifierClick;
        /// <summary>
        /// The multiple select modifier
        /// </summary>
        public MultipleSelectModifier MultipleSelectModifier;
        /// <summary>
        /// The alt mouse button
        /// </summary>
        public int AltMouseButton;
        /// <summary>
        /// The auto panning speed
        /// </summary>
        public float AutoPanningSpeed;
    }
    /// <summary>
    /// The im nodes io ptr
    /// </summary>
    public unsafe struct ImNodesIOPtr
    {
        /// <summary>
        /// Gets the value of the native ptr
        /// </summary>
        public ImNodesIO* NativePtr { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ImNodesIOPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImNodesIOPtr(ImNodesIO* nativePtr) => NativePtr = nativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="ImNodesIOPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImNodesIOPtr(IntPtr nativePtr) => NativePtr = (ImNodesIO*)nativePtr;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImNodesIOPtr(ImNodesIO* nativePtr) => new ImNodesIOPtr(nativePtr);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator ImNodesIO* (ImNodesIOPtr wrappedPtr) => wrappedPtr.NativePtr;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImNodesIOPtr(IntPtr nativePtr) => new ImNodesIOPtr(nativePtr);
        /// <summary>
        /// Gets the value of the emulate three button mouse
        /// </summary>
        public ref EmulateThreeButtonMouse EmulateThreeButtonMouse => ref Unsafe.AsRef<EmulateThreeButtonMouse>(&NativePtr->EmulateThreeButtonMouse);
        /// <summary>
        /// Gets the value of the link detach with modifier click
        /// </summary>
        public ref LinkDetachWithModifierClick LinkDetachWithModifierClick => ref Unsafe.AsRef<LinkDetachWithModifierClick>(&NativePtr->LinkDetachWithModifierClick);
        /// <summary>
        /// Gets the value of the multiple select modifier
        /// </summary>
        public ref MultipleSelectModifier MultipleSelectModifier => ref Unsafe.AsRef<MultipleSelectModifier>(&NativePtr->MultipleSelectModifier);
        /// <summary>
        /// Gets the value of the alt mouse button
        /// </summary>
        public ref int AltMouseButton => ref Unsafe.AsRef<int>(&NativePtr->AltMouseButton);
        /// <summary>
        /// Gets the value of the auto panning speed
        /// </summary>
        public ref float AutoPanningSpeed => ref Unsafe.AsRef<float>(&NativePtr->AutoPanningSpeed);
        /// <summary>
        /// Destroys this instance
        /// </summary>
        public void Destroy()
        {
            imnodesNative.ImNodesIO_destroy((ImNodesIO*)(NativePtr));
        }
    }
}
