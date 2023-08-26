using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using Alis.Core.Graphic.ImGui.Utils;

namespace Alis.Core.Graphic.Imgui.Extras.ImNodes
{
    /// <summary>
    /// The im nodes style
    /// </summary>
    public unsafe struct ImNodesStyle
    {
        /// <summary>
        /// The grid spacing
        /// </summary>
        public float GridSpacing;
        /// <summary>
        /// The node corner rounding
        /// </summary>
        public float NodeCornerRounding;
        /// <summary>
        /// The node padding
        /// </summary>
        public Vector2 NodePadding;
        /// <summary>
        /// The node border thickness
        /// </summary>
        public float NodeBorderThickness;
        /// <summary>
        /// The link thickness
        /// </summary>
        public float LinkThickness;
        /// <summary>
        /// The link line segments per length
        /// </summary>
        public float LinkLineSegmentsPerLength;
        /// <summary>
        /// The link hover distance
        /// </summary>
        public float LinkHoverDistance;
        /// <summary>
        /// The pin circle radius
        /// </summary>
        public float PinCircleRadius;
        /// <summary>
        /// The pin quad side length
        /// </summary>
        public float PinQuadSideLength;
        /// <summary>
        /// The pin triangle side length
        /// </summary>
        public float PinTriangleSideLength;
        /// <summary>
        /// The pin line thickness
        /// </summary>
        public float PinLineThickness;
        /// <summary>
        /// The pin hover radius
        /// </summary>
        public float PinHoverRadius;
        /// <summary>
        /// The pin offset
        /// </summary>
        public float PinOffset;
        /// <summary>
        /// The mini map padding
        /// </summary>
        public Vector2 MiniMapPadding;
        /// <summary>
        /// The mini map offset
        /// </summary>
        public Vector2 MiniMapOffset;
        /// <summary>
        /// The flags
        /// </summary>
        public ImNodesStyleFlags Flags;
        /// <summary>
        /// The colors
        /// </summary>
        public fixed uint Colors[29];
    }
    /// <summary>
    /// The im nodes style ptr
    /// </summary>
    public unsafe struct ImNodesStylePtr
    {
        /// <summary>
        /// Gets the value of the native ptr
        /// </summary>
        public ImNodesStyle* NativePtr { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ImNodesStylePtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImNodesStylePtr(ImNodesStyle* nativePtr) => NativePtr = nativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="ImNodesStylePtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImNodesStylePtr(IntPtr nativePtr) => NativePtr = (ImNodesStyle*)nativePtr;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImNodesStylePtr(ImNodesStyle* nativePtr) => new ImNodesStylePtr(nativePtr);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator ImNodesStyle* (ImNodesStylePtr wrappedPtr) => wrappedPtr.NativePtr;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImNodesStylePtr(IntPtr nativePtr) => new ImNodesStylePtr(nativePtr);
        /// <summary>
        /// Gets the value of the grid spacing
        /// </summary>
        public ref float GridSpacing => ref Unsafe.AsRef<float>(&NativePtr->GridSpacing);
        /// <summary>
        /// Gets the value of the node corner rounding
        /// </summary>
        public ref float NodeCornerRounding => ref Unsafe.AsRef<float>(&NativePtr->NodeCornerRounding);
        /// <summary>
        /// Gets the value of the node padding
        /// </summary>
        public ref Vector2 NodePadding => ref Unsafe.AsRef<Vector2>(&NativePtr->NodePadding);
        /// <summary>
        /// Gets the value of the node border thickness
        /// </summary>
        public ref float NodeBorderThickness => ref Unsafe.AsRef<float>(&NativePtr->NodeBorderThickness);
        /// <summary>
        /// Gets the value of the link thickness
        /// </summary>
        public ref float LinkThickness => ref Unsafe.AsRef<float>(&NativePtr->LinkThickness);
        /// <summary>
        /// Gets the value of the link line segments per length
        /// </summary>
        public ref float LinkLineSegmentsPerLength => ref Unsafe.AsRef<float>(&NativePtr->LinkLineSegmentsPerLength);
        /// <summary>
        /// Gets the value of the link hover distance
        /// </summary>
        public ref float LinkHoverDistance => ref Unsafe.AsRef<float>(&NativePtr->LinkHoverDistance);
        /// <summary>
        /// Gets the value of the pin circle radius
        /// </summary>
        public ref float PinCircleRadius => ref Unsafe.AsRef<float>(&NativePtr->PinCircleRadius);
        /// <summary>
        /// Gets the value of the pin quad side length
        /// </summary>
        public ref float PinQuadSideLength => ref Unsafe.AsRef<float>(&NativePtr->PinQuadSideLength);
        /// <summary>
        /// Gets the value of the pin triangle side length
        /// </summary>
        public ref float PinTriangleSideLength => ref Unsafe.AsRef<float>(&NativePtr->PinTriangleSideLength);
        /// <summary>
        /// Gets the value of the pin line thickness
        /// </summary>
        public ref float PinLineThickness => ref Unsafe.AsRef<float>(&NativePtr->PinLineThickness);
        /// <summary>
        /// Gets the value of the pin hover radius
        /// </summary>
        public ref float PinHoverRadius => ref Unsafe.AsRef<float>(&NativePtr->PinHoverRadius);
        /// <summary>
        /// Gets the value of the pin offset
        /// </summary>
        public ref float PinOffset => ref Unsafe.AsRef<float>(&NativePtr->PinOffset);
        /// <summary>
        /// Gets the value of the mini map padding
        /// </summary>
        public ref Vector2 MiniMapPadding => ref Unsafe.AsRef<Vector2>(&NativePtr->MiniMapPadding);
        /// <summary>
        /// Gets the value of the mini map offset
        /// </summary>
        public ref Vector2 MiniMapOffset => ref Unsafe.AsRef<Vector2>(&NativePtr->MiniMapOffset);
        /// <summary>
        /// Gets the value of the flags
        /// </summary>
        public ref ImNodesStyleFlags Flags => ref Unsafe.AsRef<ImNodesStyleFlags>(&NativePtr->Flags);
        /// <summary>
        /// Gets the value of the colors
        /// </summary>
        public RangeAccessor<uint> Colors => new RangeAccessor<uint>(NativePtr->Colors, 29);
        /// <summary>
        /// Destroys this instance
        /// </summary>
        public void Destroy()
        {
            imnodesNative.ImNodesStyle_destroy((ImNodesStyle*)(NativePtr));
        }
    }
}
