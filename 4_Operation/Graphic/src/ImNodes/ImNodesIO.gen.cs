using System;
using Alis.Core.Graphic.ImGui.Utils;

namespace imnodesNET
{
    public unsafe partial struct ImNodesIO
    {
        public EmulateThreeButtonMouse EmulateThreeButtonMouse;
        public LinkDetachWithModifierClick LinkDetachWithModifierClick;
        public MultipleSelectModifier MultipleSelectModifier;
        public int AltMouseButton;
        public float AutoPanningSpeed;
    }
    public unsafe partial struct ImNodesIOPtr
    {
        public ImNodesIO* NativePtr { get; }
        public ImNodesIOPtr(ImNodesIO* nativePtr) => NativePtr = nativePtr;
        public ImNodesIOPtr(IntPtr nativePtr) => NativePtr = (ImNodesIO*)nativePtr;
        public static implicit operator ImNodesIOPtr(ImNodesIO* nativePtr) => new ImNodesIOPtr(nativePtr);
        public static implicit operator ImNodesIO* (ImNodesIOPtr wrappedPtr) => wrappedPtr.NativePtr;
        public static implicit operator ImNodesIOPtr(IntPtr nativePtr) => new ImNodesIOPtr(nativePtr);
        public ref EmulateThreeButtonMouse EmulateThreeButtonMouse => ref Unsafe.AsRef<EmulateThreeButtonMouse>(&NativePtr->EmulateThreeButtonMouse);
        public ref LinkDetachWithModifierClick LinkDetachWithModifierClick => ref Unsafe.AsRef<LinkDetachWithModifierClick>(&NativePtr->LinkDetachWithModifierClick);
        public ref MultipleSelectModifier MultipleSelectModifier => ref Unsafe.AsRef<MultipleSelectModifier>(&NativePtr->MultipleSelectModifier);
        public ref int AltMouseButton => ref Unsafe.AsRef<int>(&NativePtr->AltMouseButton);
        public ref float AutoPanningSpeed => ref Unsafe.AsRef<float>(&NativePtr->AutoPanningSpeed);
        public void Destroy()
        {
            imnodesNative.ImNodesIO_destroy((ImNodesIO*)(NativePtr));
        }
    }
}
