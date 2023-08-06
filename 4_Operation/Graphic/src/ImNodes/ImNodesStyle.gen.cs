using System;
using System.Numerics;
using Alis.Core.Graphic.ImGui.Structs;
using Alis.Core.Graphic.ImGui.Utils;

namespace imnodesNET
{
    public unsafe partial struct ImNodesStyle
    {
        public float GridSpacing;
        public float NodeCornerRounding;
        public Vector2 NodePadding;
        public float NodeBorderThickness;
        public float LinkThickness;
        public float LinkLineSegmentsPerLength;
        public float LinkHoverDistance;
        public float PinCircleRadius;
        public float PinQuadSideLength;
        public float PinTriangleSideLength;
        public float PinLineThickness;
        public float PinHoverRadius;
        public float PinOffset;
        public Vector2 MiniMapPadding;
        public Vector2 MiniMapOffset;
        public ImNodesStyleFlags Flags;
        public fixed uint Colors[29];
    }
    public unsafe partial struct ImNodesStylePtr
    {
        public ImNodesStyle* NativePtr { get; }
        public ImNodesStylePtr(ImNodesStyle* nativePtr) => NativePtr = nativePtr;
        public ImNodesStylePtr(IntPtr nativePtr) => NativePtr = (ImNodesStyle*)nativePtr;
        public static implicit operator ImNodesStylePtr(ImNodesStyle* nativePtr) => new ImNodesStylePtr(nativePtr);
        public static implicit operator ImNodesStyle* (ImNodesStylePtr wrappedPtr) => wrappedPtr.NativePtr;
        public static implicit operator ImNodesStylePtr(IntPtr nativePtr) => new ImNodesStylePtr(nativePtr);
        public ref float GridSpacing => ref Unsafe.AsRef<float>(&NativePtr->GridSpacing);
        public ref float NodeCornerRounding => ref Unsafe.AsRef<float>(&NativePtr->NodeCornerRounding);
        public ref Vector2 NodePadding => ref Unsafe.AsRef<Vector2>(&NativePtr->NodePadding);
        public ref float NodeBorderThickness => ref Unsafe.AsRef<float>(&NativePtr->NodeBorderThickness);
        public ref float LinkThickness => ref Unsafe.AsRef<float>(&NativePtr->LinkThickness);
        public ref float LinkLineSegmentsPerLength => ref Unsafe.AsRef<float>(&NativePtr->LinkLineSegmentsPerLength);
        public ref float LinkHoverDistance => ref Unsafe.AsRef<float>(&NativePtr->LinkHoverDistance);
        public ref float PinCircleRadius => ref Unsafe.AsRef<float>(&NativePtr->PinCircleRadius);
        public ref float PinQuadSideLength => ref Unsafe.AsRef<float>(&NativePtr->PinQuadSideLength);
        public ref float PinTriangleSideLength => ref Unsafe.AsRef<float>(&NativePtr->PinTriangleSideLength);
        public ref float PinLineThickness => ref Unsafe.AsRef<float>(&NativePtr->PinLineThickness);
        public ref float PinHoverRadius => ref Unsafe.AsRef<float>(&NativePtr->PinHoverRadius);
        public ref float PinOffset => ref Unsafe.AsRef<float>(&NativePtr->PinOffset);
        public ref Vector2 MiniMapPadding => ref Unsafe.AsRef<Vector2>(&NativePtr->MiniMapPadding);
        public ref Vector2 MiniMapOffset => ref Unsafe.AsRef<Vector2>(&NativePtr->MiniMapOffset);
        public ref ImNodesStyleFlags Flags => ref Unsafe.AsRef<ImNodesStyleFlags>(&NativePtr->Flags);
        public RangeAccessor<uint> Colors => new RangeAccessor<uint>(NativePtr->Colors, 29);
        public void Destroy()
        {
            imnodesNative.ImNodesStyle_destroy((ImNodesStyle*)(NativePtr));
        }
    }
}
