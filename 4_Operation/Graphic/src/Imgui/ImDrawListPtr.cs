using System;
using System.Numerics;
using Alis.Core.Graphic.ImGui.Utils;

namespace Alis.Core.Graphic.Imgui
{
    /// <summary>
    /// The im draw list ptr
    /// </summary>
    public unsafe partial struct ImDrawListPtr
    {
        /// <summary>
        /// Gets the value of the native ptr
        /// </summary>
        public ImDrawList* NativePtr { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ImDrawListPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImDrawListPtr(ImDrawList* nativePtr) => NativePtr = nativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="ImDrawListPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImDrawListPtr(IntPtr nativePtr) => NativePtr = (ImDrawList*)nativePtr;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImDrawListPtr(ImDrawList* nativePtr) => new ImDrawListPtr(nativePtr);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator ImDrawList* (ImDrawListPtr wrappedPtr) => wrappedPtr.NativePtr;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImDrawListPtr(IntPtr nativePtr) => new ImDrawListPtr(nativePtr);
        /// <summary>
        /// Gets the value of the cmd buffer
        /// </summary>
        public ImPtrVector<ImDrawCmdPtr> CmdBuffer => new ImPtrVector<ImDrawCmdPtr>(NativePtr->CmdBuffer, Unsafe.SizeOf<ImDrawCmd>());
        /// <summary>
        /// Gets the value of the idx buffer
        /// </summary>
        public ImVector<ushort> IdxBuffer => new ImVector<ushort>(NativePtr->IdxBuffer);
        /// <summary>
        /// Gets the value of the vtx buffer
        /// </summary>
        public ImPtrVector<ImDrawVertPtr> VtxBuffer => new ImPtrVector<ImDrawVertPtr>(NativePtr->VtxBuffer, Unsafe.SizeOf<ImDrawVert>());
        /// <summary>
        /// Gets the value of the flags
        /// </summary>
        public ref ImDrawListFlags Flags => ref Unsafe.AsRef<ImDrawListFlags>(&NativePtr->Flags);
        /// <summary>
        /// Gets the value of the  vtxcurrentidx
        /// </summary>
        public ref uint VtxCurrentIdx => ref Unsafe.AsRef<uint>(&NativePtr->VtxCurrentIdx);
        /// <summary>
        /// Gets the value of the  data
        /// </summary>
        public ref IntPtr Data => ref Unsafe.AsRef<IntPtr>(&NativePtr->Data);
        /// <summary>
        /// Gets the value of the  ownername
        /// </summary>
        public NullTerminatedString OwnerName => new NullTerminatedString(NativePtr->OwnerName);
        /// <summary>
        /// Gets the value of the  vtxwriteptr
        /// </summary>
        public ImDrawVertPtr VtxWritePtr => new ImDrawVertPtr(NativePtr->VtxWritePtr);
        /// <summary>
        /// Gets or sets the value of the  idxwriteptr
        /// </summary>
        public IntPtr IdxWritePtr { get => (IntPtr)NativePtr->IdxWritePtr; set => NativePtr->IdxWritePtr = (ushort*)value; }
        /// <summary>
        /// Gets the value of the  cliprectstack
        /// </summary>
        public ImVector<Vector4> ClipRectStack => new ImVector<Vector4>(NativePtr->ClipRectStack);
        /// <summary>
        /// Gets the value of the  textureidstack
        /// </summary>
        public ImVector<IntPtr> TextureIdStack => new ImVector<IntPtr>(NativePtr->TextureIdStack);
        /// <summary>
        /// Gets the value of the  path
        /// </summary>
        public ImVector<Vector2> Path => new ImVector<Vector2>(NativePtr->Path);
        /// <summary>
        /// Gets the value of the  cmdheader
        /// </summary>
        public ref ImDrawCmdHeader CmdHeader => ref Unsafe.AsRef<ImDrawCmdHeader>(&NativePtr->CmdHeader);
        /// <summary>
        /// Gets the value of the  splitter
        /// </summary>
        public ref ImDrawListSplitter Splitter => ref Unsafe.AsRef<ImDrawListSplitter>(&NativePtr->Splitter);
        /// <summary>
        /// Gets the value of the  fringescale
        /// </summary>
        public ref float FringeScale => ref Unsafe.AsRef<float>(&NativePtr->FringeScale);
        /// <summary>
        /// Calcs the circle auto segment count using the specified radius
        /// </summary>
        /// <param name="radius">The radius</param>
        /// <returns>The ret</returns>
        public int _CalcCircleAutoSegmentCount(float radius)
        {
            int ret = ImGuiNative.ImDrawList__CalcCircleAutoSegmentCount((ImDrawList*)(NativePtr), radius);
            return ret;
        }
        /// <summary>
        /// Clears the free memory
        /// </summary>
        public void _ClearFreeMemory()
        {
            ImGuiNative.ImDrawList__ClearFreeMemory((ImDrawList*)(NativePtr));
        }
        /// <summary>
        /// Ons the changed clip rect
        /// </summary>
        public void _OnChangedClipRect()
        {
            ImGuiNative.ImDrawList__OnChangedClipRect((ImDrawList*)(NativePtr));
        }
        /// <summary>
        /// Ons the changed texture id
        /// </summary>
        public void _OnChangedTextureID()
        {
            ImGuiNative.ImDrawList__OnChangedTextureID((ImDrawList*)(NativePtr));
        }
        /// <summary>
        /// Ons the changed vtx offset
        /// </summary>
        public void _OnChangedVtxOffset()
        {
            ImGuiNative.ImDrawList__OnChangedVtxOffset((ImDrawList*)(NativePtr));
        }
        /// <summary>
        /// Paths the arc to fast ex using the specified center
        /// </summary>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="aMinSample">The min sample</param>
        /// <param name="aMaxSample">The max sample</param>
        /// <param name="aStep">The step</param>
        public void _PathArcToFastEx(Vector2 center, float radius, int aMinSample, int aMaxSample, int aStep)
        {
            ImGuiNative.ImDrawList__PathArcToFastEx((ImDrawList*)(NativePtr), center, radius, aMinSample, aMaxSample, aStep);
        }
        /// <summary>
        /// Paths the arc to n using the specified center
        /// </summary>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="aMin">The min</param>
        /// <param name="aMax">The max</param>
        /// <param name="numSegments">The num segments</param>
        public void _PathArcToN(Vector2 center, float radius, float aMin, float aMax, int numSegments)
        {
            ImGuiNative.ImDrawList__PathArcToN((ImDrawList*)(NativePtr), center, radius, aMin, aMax, numSegments);
        }
        /// <summary>
        /// Pops the unused draw cmd
        /// </summary>
        public void _PopUnusedDrawCmd()
        {
            ImGuiNative.ImDrawList__PopUnusedDrawCmd((ImDrawList*)(NativePtr));
        }
        /// <summary>
        /// Resets the for new frame
        /// </summary>
        public void _ResetForNewFrame()
        {
            ImGuiNative.ImDrawList__ResetForNewFrame((ImDrawList*)(NativePtr));
        }
        /// <summary>
        /// Tries the merge draw cmds
        /// </summary>
        public void _TryMergeDrawCmds()
        {
            ImGuiNative.ImDrawList__TryMergeDrawCmds((ImDrawList*)(NativePtr));
        }
        /// <summary>
        /// Adds the bezier cubic using the specified p 1
        /// </summary>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="p4">The </param>
        /// <param name="col">The col</param>
        /// <param name="thickness">The thickness</param>
        public void AddBezierCubic(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, uint col, float thickness)
        {
            int numSegments = 0;
            ImGuiNative.ImDrawList_AddBezierCubic((ImDrawList*)(NativePtr), p1, p2, p3, p4, col, thickness, numSegments);
        }
        /// <summary>
        /// Adds the bezier cubic using the specified p 1
        /// </summary>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="p4">The </param>
        /// <param name="col">The col</param>
        /// <param name="thickness">The thickness</param>
        /// <param name="numSegments">The num segments</param>
        public void AddBezierCubic(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, uint col, float thickness, int numSegments)
        {
            ImGuiNative.ImDrawList_AddBezierCubic((ImDrawList*)(NativePtr), p1, p2, p3, p4, col, thickness, numSegments);
        }
        /// <summary>
        /// Adds the bezier quadratic using the specified p 1
        /// </summary>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="col">The col</param>
        /// <param name="thickness">The thickness</param>
        public void AddBezierQuadratic(Vector2 p1, Vector2 p2, Vector2 p3, uint col, float thickness)
        {
            int numSegments = 0;
            ImGuiNative.ImDrawList_AddBezierQuadratic((ImDrawList*)(NativePtr), p1, p2, p3, col, thickness, numSegments);
        }
        /// <summary>
        /// Adds the bezier quadratic using the specified p 1
        /// </summary>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="col">The col</param>
        /// <param name="thickness">The thickness</param>
        /// <param name="numSegments">The num segments</param>
        public void AddBezierQuadratic(Vector2 p1, Vector2 p2, Vector2 p3, uint col, float thickness, int numSegments)
        {
            ImGuiNative.ImDrawList_AddBezierQuadratic((ImDrawList*)(NativePtr), p1, p2, p3, col, thickness, numSegments);
        }
        /// <summary>
        /// Adds the callback using the specified callback
        /// </summary>
        /// <param name="callback">The callback</param>
        /// <param name="callbackData">The callback data</param>
        public void AddCallback(IntPtr callback, IntPtr callbackData)
        {
            void* nativeCallbackData = (void*)callbackData.ToPointer();
            ImGuiNative.ImDrawList_AddCallback((ImDrawList*)(NativePtr), callback, nativeCallbackData);
        }
        /// <summary>
        /// Adds the circle using the specified center
        /// </summary>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="col">The col</param>
        public void AddCircle(Vector2 center, float radius, uint col)
        {
            int numSegments = 0;
            float thickness = 1.0f;
            ImGuiNative.ImDrawList_AddCircle((ImDrawList*)(NativePtr), center, radius, col, numSegments, thickness);
        }
        /// <summary>
        /// Adds the circle using the specified center
        /// </summary>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="col">The col</param>
        /// <param name="numSegments">The num segments</param>
        public void AddCircle(Vector2 center, float radius, uint col, int numSegments)
        {
            float thickness = 1.0f;
            ImGuiNative.ImDrawList_AddCircle((ImDrawList*)(NativePtr), center, radius, col, numSegments, thickness);
        }
        /// <summary>
        /// Adds the circle using the specified center
        /// </summary>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="col">The col</param>
        /// <param name="numSegments">The num segments</param>
        /// <param name="thickness">The thickness</param>
        public void AddCircle(Vector2 center, float radius, uint col, int numSegments, float thickness)
        {
            ImGuiNative.ImDrawList_AddCircle((ImDrawList*)(NativePtr), center, radius, col, numSegments, thickness);
        }
        /// <summary>
        /// Adds the circle filled using the specified center
        /// </summary>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="col">The col</param>
        public void AddCircleFilled(Vector2 center, float radius, uint col)
        {
            int numSegments = 0;
            ImGuiNative.ImDrawList_AddCircleFilled((ImDrawList*)(NativePtr), center, radius, col, numSegments);
        }
        /// <summary>
        /// Adds the circle filled using the specified center
        /// </summary>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="col">The col</param>
        /// <param name="numSegments">The num segments</param>
        public void AddCircleFilled(Vector2 center, float radius, uint col, int numSegments)
        {
            ImGuiNative.ImDrawList_AddCircleFilled((ImDrawList*)(NativePtr), center, radius, col, numSegments);
        }
        /// <summary>
        /// Adds the convex poly filled using the specified points
        /// </summary>
        /// <param name="points">The points</param>
        /// <param name="numPoints">The num points</param>
        /// <param name="col">The col</param>
        public void AddConvexPolyFilled(ref Vector2 points, int numPoints, uint col)
        {
            fixed (Vector2* nativePoints = &points)
            {
                ImGuiNative.ImDrawList_AddConvexPolyFilled((ImDrawList*)(NativePtr), nativePoints, numPoints, col);
            }
        }
        /// <summary>
        /// Adds the draw cmd
        /// </summary>
        public void AddDrawCmd()
        {
            ImGuiNative.ImDrawList_AddDrawCmd((ImDrawList*)(NativePtr));
        }
        /// <summary>
        /// Adds the image using the specified user texture id
        /// </summary>
        /// <param name="userTextureId">The user texture id</param>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        public void AddImage(IntPtr userTextureId, Vector2 pMin, Vector2 pMax)
        {
            Vector2 uvMin = new Vector2();
            Vector2 uvMax = new Vector2(1, 1);
            uint col = 4294967295;
            ImGuiNative.ImDrawList_AddImage((ImDrawList*)(NativePtr), userTextureId, pMin, pMax, uvMin, uvMax, col);
        }
        /// <summary>
        /// Adds the image using the specified user texture id
        /// </summary>
        /// <param name="userTextureId">The user texture id</param>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <param name="uvMin">The uv min</param>
        public void AddImage(IntPtr userTextureId, Vector2 pMin, Vector2 pMax, Vector2 uvMin)
        {
            Vector2 uvMax = new Vector2(1, 1);
            uint col = 4294967295;
            ImGuiNative.ImDrawList_AddImage((ImDrawList*)(NativePtr), userTextureId, pMin, pMax, uvMin, uvMax, col);
        }
        /// <summary>
        /// Adds the image using the specified user texture id
        /// </summary>
        /// <param name="userTextureId">The user texture id</param>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <param name="uvMin">The uv min</param>
        /// <param name="uvMax">The uv max</param>
        public void AddImage(IntPtr userTextureId, Vector2 pMin, Vector2 pMax, Vector2 uvMin, Vector2 uvMax)
        {
            uint col = 4294967295;
            ImGuiNative.ImDrawList_AddImage((ImDrawList*)(NativePtr), userTextureId, pMin, pMax, uvMin, uvMax, col);
        }
        /// <summary>
        /// Adds the image using the specified user texture id
        /// </summary>
        /// <param name="userTextureId">The user texture id</param>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <param name="uvMin">The uv min</param>
        /// <param name="uvMax">The uv max</param>
        /// <param name="col">The col</param>
        public void AddImage(IntPtr userTextureId, Vector2 pMin, Vector2 pMax, Vector2 uvMin, Vector2 uvMax, uint col)
        {
            ImGuiNative.ImDrawList_AddImage((ImDrawList*)(NativePtr), userTextureId, pMin, pMax, uvMin, uvMax, col);
        }
        /// <summary>
        /// Adds the image quad using the specified user texture id
        /// </summary>
        /// <param name="userTextureId">The user texture id</param>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="p4">The </param>
        public void AddImageQuad(IntPtr userTextureId, Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4)
        {
            Vector2 uv1 = new Vector2();
            Vector2 uv2 = new Vector2(1, 0);
            Vector2 uv3 = new Vector2(1, 1);
            Vector2 uv4 = new Vector2(0, 1);
            uint col = 4294967295;
            ImGuiNative.ImDrawList_AddImageQuad((ImDrawList*)(NativePtr), userTextureId, p1, p2, p3, p4, uv1, uv2, uv3, uv4, col);
        }
        /// <summary>
        /// Adds the image quad using the specified user texture id
        /// </summary>
        /// <param name="userTextureId">The user texture id</param>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="p4">The </param>
        /// <param name="uv1">The uv</param>
        public void AddImageQuad(IntPtr userTextureId, Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, Vector2 uv1)
        {
            Vector2 uv2 = new Vector2(1, 0);
            Vector2 uv3 = new Vector2(1, 1);
            Vector2 uv4 = new Vector2(0, 1);
            uint col = 4294967295;
            ImGuiNative.ImDrawList_AddImageQuad((ImDrawList*)(NativePtr), userTextureId, p1, p2, p3, p4, uv1, uv2, uv3, uv4, col);
        }
        /// <summary>
        /// Adds the image quad using the specified user texture id
        /// </summary>
        /// <param name="userTextureId">The user texture id</param>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="p4">The </param>
        /// <param name="uv1">The uv</param>
        /// <param name="uv2">The uv</param>
        public void AddImageQuad(IntPtr userTextureId, Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, Vector2 uv1, Vector2 uv2)
        {
            Vector2 uv3 = new Vector2(1, 1);
            Vector2 uv4 = new Vector2(0, 1);
            uint col = 4294967295;
            ImGuiNative.ImDrawList_AddImageQuad((ImDrawList*)(NativePtr), userTextureId, p1, p2, p3, p4, uv1, uv2, uv3, uv4, col);
        }
        /// <summary>
        /// Adds the image quad using the specified user texture id
        /// </summary>
        /// <param name="userTextureId">The user texture id</param>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="p4">The </param>
        /// <param name="uv1">The uv</param>
        /// <param name="uv2">The uv</param>
        /// <param name="uv3">The uv</param>
        public void AddImageQuad(IntPtr userTextureId, Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, Vector2 uv1, Vector2 uv2, Vector2 uv3)
        {
            Vector2 uv4 = new Vector2(0, 1);
            uint col = 4294967295;
            ImGuiNative.ImDrawList_AddImageQuad((ImDrawList*)(NativePtr), userTextureId, p1, p2, p3, p4, uv1, uv2, uv3, uv4, col);
        }
        /// <summary>
        /// Adds the image quad using the specified user texture id
        /// </summary>
        /// <param name="userTextureId">The user texture id</param>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="p4">The </param>
        /// <param name="uv1">The uv</param>
        /// <param name="uv2">The uv</param>
        /// <param name="uv3">The uv</param>
        /// <param name="uv4">The uv</param>
        public void AddImageQuad(IntPtr userTextureId, Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, Vector2 uv1, Vector2 uv2, Vector2 uv3, Vector2 uv4)
        {
            uint col = 4294967295;
            ImGuiNative.ImDrawList_AddImageQuad((ImDrawList*)(NativePtr), userTextureId, p1, p2, p3, p4, uv1, uv2, uv3, uv4, col);
        }
        /// <summary>
        /// Adds the image quad using the specified user texture id
        /// </summary>
        /// <param name="userTextureId">The user texture id</param>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="p4">The </param>
        /// <param name="uv1">The uv</param>
        /// <param name="uv2">The uv</param>
        /// <param name="uv3">The uv</param>
        /// <param name="uv4">The uv</param>
        /// <param name="col">The col</param>
        public void AddImageQuad(IntPtr userTextureId, Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, Vector2 uv1, Vector2 uv2, Vector2 uv3, Vector2 uv4, uint col)
        {
            ImGuiNative.ImDrawList_AddImageQuad((ImDrawList*)(NativePtr), userTextureId, p1, p2, p3, p4, uv1, uv2, uv3, uv4, col);
        }
        /// <summary>
        /// Adds the image rounded using the specified user texture id
        /// </summary>
        /// <param name="userTextureId">The user texture id</param>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <param name="uvMin">The uv min</param>
        /// <param name="uvMax">The uv max</param>
        /// <param name="col">The col</param>
        /// <param name="rounding">The rounding</param>
        public void AddImageRounded(IntPtr userTextureId, Vector2 pMin, Vector2 pMax, Vector2 uvMin, Vector2 uvMax, uint col, float rounding)
        {
            ImDrawFlags flags = (ImDrawFlags)0;
            ImGuiNative.ImDrawList_AddImageRounded((ImDrawList*)(NativePtr), userTextureId, pMin, pMax, uvMin, uvMax, col, rounding, flags);
        }
        /// <summary>
        /// Adds the image rounded using the specified user texture id
        /// </summary>
        /// <param name="userTextureId">The user texture id</param>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <param name="uvMin">The uv min</param>
        /// <param name="uvMax">The uv max</param>
        /// <param name="col">The col</param>
        /// <param name="rounding">The rounding</param>
        /// <param name="flags">The flags</param>
        public void AddImageRounded(IntPtr userTextureId, Vector2 pMin, Vector2 pMax, Vector2 uvMin, Vector2 uvMax, uint col, float rounding, ImDrawFlags flags)
        {
            ImGuiNative.ImDrawList_AddImageRounded((ImDrawList*)(NativePtr), userTextureId, pMin, pMax, uvMin, uvMax, col, rounding, flags);
        }
        /// <summary>
        /// Adds the line using the specified p 1
        /// </summary>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="col">The col</param>
        public void AddLine(Vector2 p1, Vector2 p2, uint col)
        {
            float thickness = 1.0f;
            ImGuiNative.ImDrawList_AddLine((ImDrawList*)(NativePtr), p1, p2, col, thickness);
        }
        /// <summary>
        /// Adds the line using the specified p 1
        /// </summary>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="col">The col</param>
        /// <param name="thickness">The thickness</param>
        public void AddLine(Vector2 p1, Vector2 p2, uint col, float thickness)
        {
            ImGuiNative.ImDrawList_AddLine((ImDrawList*)(NativePtr), p1, p2, col, thickness);
        }
        /// <summary>
        /// Adds the ngon using the specified center
        /// </summary>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="col">The col</param>
        /// <param name="numSegments">The num segments</param>
        public void AddNgon(Vector2 center, float radius, uint col, int numSegments)
        {
            float thickness = 1.0f;
            ImGuiNative.ImDrawList_AddNgon((ImDrawList*)(NativePtr), center, radius, col, numSegments, thickness);
        }
        /// <summary>
        /// Adds the ngon using the specified center
        /// </summary>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="col">The col</param>
        /// <param name="numSegments">The num segments</param>
        /// <param name="thickness">The thickness</param>
        public void AddNgon(Vector2 center, float radius, uint col, int numSegments, float thickness)
        {
            ImGuiNative.ImDrawList_AddNgon((ImDrawList*)(NativePtr), center, radius, col, numSegments, thickness);
        }
        /// <summary>
        /// Adds the ngon filled using the specified center
        /// </summary>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="col">The col</param>
        /// <param name="numSegments">The num segments</param>
        public void AddNgonFilled(Vector2 center, float radius, uint col, int numSegments)
        {
            ImGuiNative.ImDrawList_AddNgonFilled((ImDrawList*)(NativePtr), center, radius, col, numSegments);
        }
        /// <summary>
        /// Adds the polyline using the specified points
        /// </summary>
        /// <param name="points">The points</param>
        /// <param name="numPoints">The num points</param>
        /// <param name="col">The col</param>
        /// <param name="flags">The flags</param>
        /// <param name="thickness">The thickness</param>
        public void AddPolyline(ref Vector2 points, int numPoints, uint col, ImDrawFlags flags, float thickness)
        {
            fixed (Vector2* nativePoints = &points)
            {
                ImGuiNative.ImDrawList_AddPolyline((ImDrawList*)(NativePtr), nativePoints, numPoints, col, flags, thickness);
            }
        }
        /// <summary>
        /// Adds the quad using the specified p 1
        /// </summary>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="p4">The </param>
        /// <param name="col">The col</param>
        public void AddQuad(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, uint col)
        {
            float thickness = 1.0f;
            ImGuiNative.ImDrawList_AddQuad((ImDrawList*)(NativePtr), p1, p2, p3, p4, col, thickness);
        }
        /// <summary>
        /// Adds the quad using the specified p 1
        /// </summary>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="p4">The </param>
        /// <param name="col">The col</param>
        /// <param name="thickness">The thickness</param>
        public void AddQuad(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, uint col, float thickness)
        {
            ImGuiNative.ImDrawList_AddQuad((ImDrawList*)(NativePtr), p1, p2, p3, p4, col, thickness);
        }
        /// <summary>
        /// Adds the quad filled using the specified p 1
        /// </summary>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="p4">The </param>
        /// <param name="col">The col</param>
        public void AddQuadFilled(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, uint col)
        {
            ImGuiNative.ImDrawList_AddQuadFilled((ImDrawList*)(NativePtr), p1, p2, p3, p4, col);
        }
        /// <summary>
        /// Adds the rect using the specified p min
        /// </summary>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <param name="col">The col</param>
        public void AddRect(Vector2 pMin, Vector2 pMax, uint col)
        {
            float rounding = 0.0f;
            ImDrawFlags flags = (ImDrawFlags)0;
            float thickness = 1.0f;
            ImGuiNative.ImDrawList_AddRect((ImDrawList*)(NativePtr), pMin, pMax, col, rounding, flags, thickness);
        }
        /// <summary>
        /// Adds the rect using the specified p min
        /// </summary>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <param name="col">The col</param>
        /// <param name="rounding">The rounding</param>
        public void AddRect(Vector2 pMin, Vector2 pMax, uint col, float rounding)
        {
            ImDrawFlags flags = (ImDrawFlags)0;
            float thickness = 1.0f;
            ImGuiNative.ImDrawList_AddRect((ImDrawList*)(NativePtr), pMin, pMax, col, rounding, flags, thickness);
        }
        /// <summary>
        /// Adds the rect using the specified p min
        /// </summary>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <param name="col">The col</param>
        /// <param name="rounding">The rounding</param>
        /// <param name="flags">The flags</param>
        public void AddRect(Vector2 pMin, Vector2 pMax, uint col, float rounding, ImDrawFlags flags)
        {
            float thickness = 1.0f;
            ImGuiNative.ImDrawList_AddRect((ImDrawList*)(NativePtr), pMin, pMax, col, rounding, flags, thickness);
        }
        /// <summary>
        /// Adds the rect using the specified p min
        /// </summary>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <param name="col">The col</param>
        /// <param name="rounding">The rounding</param>
        /// <param name="flags">The flags</param>
        /// <param name="thickness">The thickness</param>
        public void AddRect(Vector2 pMin, Vector2 pMax, uint col, float rounding, ImDrawFlags flags, float thickness)
        {
            ImGuiNative.ImDrawList_AddRect((ImDrawList*)(NativePtr), pMin, pMax, col, rounding, flags, thickness);
        }
        /// <summary>
        /// Adds the rect filled using the specified p min
        /// </summary>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <param name="col">The col</param>
        public void AddRectFilled(Vector2 pMin, Vector2 pMax, uint col)
        {
            float rounding = 0.0f;
            ImDrawFlags flags = (ImDrawFlags)0;
            ImGuiNative.ImDrawList_AddRectFilled((ImDrawList*)(NativePtr), pMin, pMax, col, rounding, flags);
        }
        /// <summary>
        /// Adds the rect filled using the specified p min
        /// </summary>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <param name="col">The col</param>
        /// <param name="rounding">The rounding</param>
        public void AddRectFilled(Vector2 pMin, Vector2 pMax, uint col, float rounding)
        {
            ImDrawFlags flags = (ImDrawFlags)0;
            ImGuiNative.ImDrawList_AddRectFilled((ImDrawList*)(NativePtr), pMin, pMax, col, rounding, flags);
        }
        /// <summary>
        /// Adds the rect filled using the specified p min
        /// </summary>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <param name="col">The col</param>
        /// <param name="rounding">The rounding</param>
        /// <param name="flags">The flags</param>
        public void AddRectFilled(Vector2 pMin, Vector2 pMax, uint col, float rounding, ImDrawFlags flags)
        {
            ImGuiNative.ImDrawList_AddRectFilled((ImDrawList*)(NativePtr), pMin, pMax, col, rounding, flags);
        }
        /// <summary>
        /// Adds the rect filled multi color using the specified p min
        /// </summary>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <param name="colUprLeft">The col upr left</param>
        /// <param name="colUprRight">The col upr right</param>
        /// <param name="colBotRight">The col bot right</param>
        /// <param name="colBotLeft">The col bot left</param>
        public void AddRectFilledMultiColor(Vector2 pMin, Vector2 pMax, uint colUprLeft, uint colUprRight, uint colBotRight, uint colBotLeft)
        {
            ImGuiNative.ImDrawList_AddRectFilledMultiColor((ImDrawList*)(NativePtr), pMin, pMax, colUprLeft, colUprRight, colBotRight, colBotLeft);
        }
        /// <summary>
        /// Adds the triangle using the specified p 1
        /// </summary>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="col">The col</param>
        public void AddTriangle(Vector2 p1, Vector2 p2, Vector2 p3, uint col)
        {
            float thickness = 1.0f;
            ImGuiNative.ImDrawList_AddTriangle((ImDrawList*)(NativePtr), p1, p2, p3, col, thickness);
        }
        /// <summary>
        /// Adds the triangle using the specified p 1
        /// </summary>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="col">The col</param>
        /// <param name="thickness">The thickness</param>
        public void AddTriangle(Vector2 p1, Vector2 p2, Vector2 p3, uint col, float thickness)
        {
            ImGuiNative.ImDrawList_AddTriangle((ImDrawList*)(NativePtr), p1, p2, p3, col, thickness);
        }
        /// <summary>
        /// Adds the triangle filled using the specified p 1
        /// </summary>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="col">The col</param>
        public void AddTriangleFilled(Vector2 p1, Vector2 p2, Vector2 p3, uint col)
        {
            ImGuiNative.ImDrawList_AddTriangleFilled((ImDrawList*)(NativePtr), p1, p2, p3, col);
        }
        /// <summary>
        /// Channelses the merge
        /// </summary>
        public void ChannelsMerge()
        {
            ImGuiNative.ImDrawList_ChannelsMerge((ImDrawList*)(NativePtr));
        }
        /// <summary>
        /// Channelses the set current using the specified n
        /// </summary>
        /// <param name="n">The </param>
        public void ChannelsSetCurrent(int n)
        {
            ImGuiNative.ImDrawList_ChannelsSetCurrent((ImDrawList*)(NativePtr), n);
        }
        /// <summary>
        /// Channelses the split using the specified count
        /// </summary>
        /// <param name="count">The count</param>
        public void ChannelsSplit(int count)
        {
            ImGuiNative.ImDrawList_ChannelsSplit((ImDrawList*)(NativePtr), count);
        }
        /// <summary>
        /// Clones the output
        /// </summary>
        /// <returns>The im draw list ptr</returns>
        public ImDrawListPtr CloneOutput()
        {
            ImDrawList* ret = ImGuiNative.ImDrawList_CloneOutput((ImDrawList*)(NativePtr));
            return new ImDrawListPtr(ret);
        }
        /// <summary>
        /// Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImGuiNative.ImDrawList_destroy((ImDrawList*)(NativePtr));
        }
        /// <summary>
        /// Gets the clip rect max
        /// </summary>
        /// <returns>The retval</returns>
        public Vector2 GetClipRectMax()
        {
            Vector2 retval;
            ImGuiNative.ImDrawList_GetClipRectMax(&retval, (ImDrawList*)(NativePtr));
            return retval;
        }
        /// <summary>
        /// Gets the clip rect min
        /// </summary>
        /// <returns>The retval</returns>
        public Vector2 GetClipRectMin()
        {
            Vector2 retval;
            ImGuiNative.ImDrawList_GetClipRectMin(&retval, (ImDrawList*)(NativePtr));
            return retval;
        }
        /// <summary>
        /// Paths the arc to using the specified center
        /// </summary>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="aMin">The min</param>
        /// <param name="aMax">The max</param>
        public void PathArcTo(Vector2 center, float radius, float aMin, float aMax)
        {
            int numSegments = 0;
            ImGuiNative.ImDrawList_PathArcTo((ImDrawList*)(NativePtr), center, radius, aMin, aMax, numSegments);
        }
        /// <summary>
        /// Paths the arc to using the specified center
        /// </summary>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="aMin">The min</param>
        /// <param name="aMax">The max</param>
        /// <param name="numSegments">The num segments</param>
        public void PathArcTo(Vector2 center, float radius, float aMin, float aMax, int numSegments)
        {
            ImGuiNative.ImDrawList_PathArcTo((ImDrawList*)(NativePtr), center, radius, aMin, aMax, numSegments);
        }
        /// <summary>
        /// Paths the arc to fast using the specified center
        /// </summary>
        /// <param name="center">The center</param>
        /// <param name="radius">The radius</param>
        /// <param name="aMinOf12">The min of 12</param>
        /// <param name="aMaxOf12">The max of 12</param>
        public void PathArcToFast(Vector2 center, float radius, int aMinOf12, int aMaxOf12)
        {
            ImGuiNative.ImDrawList_PathArcToFast((ImDrawList*)(NativePtr), center, radius, aMinOf12, aMaxOf12);
        }
        /// <summary>
        /// Paths the bezier cubic curve to using the specified p 2
        /// </summary>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="p4">The </param>
        public void PathBezierCubicCurveTo(Vector2 p2, Vector2 p3, Vector2 p4)
        {
            int numSegments = 0;
            ImGuiNative.ImDrawList_PathBezierCubicCurveTo((ImDrawList*)(NativePtr), p2, p3, p4, numSegments);
        }
        /// <summary>
        /// Paths the bezier cubic curve to using the specified p 2
        /// </summary>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="p4">The </param>
        /// <param name="numSegments">The num segments</param>
        public void PathBezierCubicCurveTo(Vector2 p2, Vector2 p3, Vector2 p4, int numSegments)
        {
            ImGuiNative.ImDrawList_PathBezierCubicCurveTo((ImDrawList*)(NativePtr), p2, p3, p4, numSegments);
        }
        /// <summary>
        /// Paths the bezier quadratic curve to using the specified p 2
        /// </summary>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        public void PathBezierQuadraticCurveTo(Vector2 p2, Vector2 p3)
        {
            int numSegments = 0;
            ImGuiNative.ImDrawList_PathBezierQuadraticCurveTo((ImDrawList*)(NativePtr), p2, p3, numSegments);
        }
        /// <summary>
        /// Paths the bezier quadratic curve to using the specified p 2
        /// </summary>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        /// <param name="numSegments">The num segments</param>
        public void PathBezierQuadraticCurveTo(Vector2 p2, Vector2 p3, int numSegments)
        {
            ImGuiNative.ImDrawList_PathBezierQuadraticCurveTo((ImDrawList*)(NativePtr), p2, p3, numSegments);
        }
        /// <summary>
        /// Paths the clear
        /// </summary>
        public void PathClear()
        {
            ImGuiNative.ImDrawList_PathClear((ImDrawList*)(NativePtr));
        }
        /// <summary>
        /// Paths the fill convex using the specified col
        /// </summary>
        /// <param name="col">The col</param>
        public void PathFillConvex(uint col)
        {
            ImGuiNative.ImDrawList_PathFillConvex((ImDrawList*)(NativePtr), col);
        }
        /// <summary>
        /// Paths the line to using the specified pos
        /// </summary>
        /// <param name="pos">The pos</param>
        public void PathLineTo(Vector2 pos)
        {
            ImGuiNative.ImDrawList_PathLineTo((ImDrawList*)(NativePtr), pos);
        }
        /// <summary>
        /// Paths the line to merge duplicate using the specified pos
        /// </summary>
        /// <param name="pos">The pos</param>
        public void PathLineToMergeDuplicate(Vector2 pos)
        {
            ImGuiNative.ImDrawList_PathLineToMergeDuplicate((ImDrawList*)(NativePtr), pos);
        }
        /// <summary>
        /// Paths the rect using the specified rect min
        /// </summary>
        /// <param name="rectMin">The rect min</param>
        /// <param name="rectMax">The rect max</param>
        public void PathRect(Vector2 rectMin, Vector2 rectMax)
        {
            float rounding = 0.0f;
            ImDrawFlags flags = (ImDrawFlags)0;
            ImGuiNative.ImDrawList_PathRect((ImDrawList*)(NativePtr), rectMin, rectMax, rounding, flags);
        }
        /// <summary>
        /// Paths the rect using the specified rect min
        /// </summary>
        /// <param name="rectMin">The rect min</param>
        /// <param name="rectMax">The rect max</param>
        /// <param name="rounding">The rounding</param>
        public void PathRect(Vector2 rectMin, Vector2 rectMax, float rounding)
        {
            ImDrawFlags flags = (ImDrawFlags)0;
            ImGuiNative.ImDrawList_PathRect((ImDrawList*)(NativePtr), rectMin, rectMax, rounding, flags);
        }
        /// <summary>
        /// Paths the rect using the specified rect min
        /// </summary>
        /// <param name="rectMin">The rect min</param>
        /// <param name="rectMax">The rect max</param>
        /// <param name="rounding">The rounding</param>
        /// <param name="flags">The flags</param>
        public void PathRect(Vector2 rectMin, Vector2 rectMax, float rounding, ImDrawFlags flags)
        {
            ImGuiNative.ImDrawList_PathRect((ImDrawList*)(NativePtr), rectMin, rectMax, rounding, flags);
        }
        /// <summary>
        /// Paths the stroke using the specified col
        /// </summary>
        /// <param name="col">The col</param>
        public void PathStroke(uint col)
        {
            ImDrawFlags flags = (ImDrawFlags)0;
            float thickness = 1.0f;
            ImGuiNative.ImDrawList_PathStroke((ImDrawList*)(NativePtr), col, flags, thickness);
        }
        /// <summary>
        /// Paths the stroke using the specified col
        /// </summary>
        /// <param name="col">The col</param>
        /// <param name="flags">The flags</param>
        public void PathStroke(uint col, ImDrawFlags flags)
        {
            float thickness = 1.0f;
            ImGuiNative.ImDrawList_PathStroke((ImDrawList*)(NativePtr), col, flags, thickness);
        }
        /// <summary>
        /// Paths the stroke using the specified col
        /// </summary>
        /// <param name="col">The col</param>
        /// <param name="flags">The flags</param>
        /// <param name="thickness">The thickness</param>
        public void PathStroke(uint col, ImDrawFlags flags, float thickness)
        {
            ImGuiNative.ImDrawList_PathStroke((ImDrawList*)(NativePtr), col, flags, thickness);
        }
        /// <summary>
        /// Pops the clip rect
        /// </summary>
        public void PopClipRect()
        {
            ImGuiNative.ImDrawList_PopClipRect((ImDrawList*)(NativePtr));
        }
        /// <summary>
        /// Pops the texture id
        /// </summary>
        public void PopTextureId()
        {
            ImGuiNative.ImDrawList_PopTextureID((ImDrawList*)(NativePtr));
        }
        /// <summary>
        /// Prims the quad uv using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="c">The </param>
        /// <param name="d">The </param>
        /// <param name="uvA">The uv</param>
        /// <param name="uvB">The uv</param>
        /// <param name="uvC">The uv</param>
        /// <param name="uvD">The uv</param>
        /// <param name="col">The col</param>
        public void PrimQuadUv(Vector2 a, Vector2 b, Vector2 c, Vector2 d, Vector2 uvA, Vector2 uvB, Vector2 uvC, Vector2 uvD, uint col)
        {
            ImGuiNative.ImDrawList_PrimQuadUV((ImDrawList*)(NativePtr), a, b, c, d, uvA, uvB, uvC, uvD, col);
        }
        /// <summary>
        /// Prims the rect using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="col">The col</param>
        public void PrimRect(Vector2 a, Vector2 b, uint col)
        {
            ImGuiNative.ImDrawList_PrimRect((ImDrawList*)(NativePtr), a, b, col);
        }
        /// <summary>
        /// Prims the rect uv using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="uvA">The uv</param>
        /// <param name="uvB">The uv</param>
        /// <param name="col">The col</param>
        public void PrimRectUv(Vector2 a, Vector2 b, Vector2 uvA, Vector2 uvB, uint col)
        {
            ImGuiNative.ImDrawList_PrimRectUV((ImDrawList*)(NativePtr), a, b, uvA, uvB, col);
        }
        /// <summary>
        /// Prims the reserve using the specified idx count
        /// </summary>
        /// <param name="idxCount">The idx count</param>
        /// <param name="vtxCount">The vtx count</param>
        public void PrimReserve(int idxCount, int vtxCount)
        {
            ImGuiNative.ImDrawList_PrimReserve((ImDrawList*)(NativePtr), idxCount, vtxCount);
        }
        /// <summary>
        /// Prims the unreserve using the specified idx count
        /// </summary>
        /// <param name="idxCount">The idx count</param>
        /// <param name="vtxCount">The vtx count</param>
        public void PrimUnreserve(int idxCount, int vtxCount)
        {
            ImGuiNative.ImDrawList_PrimUnreserve((ImDrawList*)(NativePtr), idxCount, vtxCount);
        }
        /// <summary>
        /// Prims the vtx using the specified pos
        /// </summary>
        /// <param name="pos">The pos</param>
        /// <param name="uv">The uv</param>
        /// <param name="col">The col</param>
        public void PrimVtx(Vector2 pos, Vector2 uv, uint col)
        {
            ImGuiNative.ImDrawList_PrimVtx((ImDrawList*)(NativePtr), pos, uv, col);
        }
        /// <summary>
        /// Prims the write idx using the specified idx
        /// </summary>
        /// <param name="idx">The idx</param>
        public void PrimWriteIdx(ushort idx)
        {
            ImGuiNative.ImDrawList_PrimWriteIdx((ImDrawList*)(NativePtr), idx);
        }
        /// <summary>
        /// Prims the write vtx using the specified pos
        /// </summary>
        /// <param name="pos">The pos</param>
        /// <param name="uv">The uv</param>
        /// <param name="col">The col</param>
        public void PrimWriteVtx(Vector2 pos, Vector2 uv, uint col)
        {
            ImGuiNative.ImDrawList_PrimWriteVtx((ImDrawList*)(NativePtr), pos, uv, col);
        }
        /// <summary>
        /// Pushes the clip rect using the specified clip rect min
        /// </summary>
        /// <param name="clipRectMin">The clip rect min</param>
        /// <param name="clipRectMax">The clip rect max</param>
        public void PushClipRect(Vector2 clipRectMin, Vector2 clipRectMax)
        {
            byte intersectWithCurrentClipRect = 0;
            ImGuiNative.ImDrawList_PushClipRect((ImDrawList*)(NativePtr), clipRectMin, clipRectMax, intersectWithCurrentClipRect);
        }
        /// <summary>
        /// Pushes the clip rect using the specified clip rect min
        /// </summary>
        /// <param name="clipRectMin">The clip rect min</param>
        /// <param name="clipRectMax">The clip rect max</param>
        /// <param name="intersectWithCurrentClipRect">The intersect with current clip rect</param>
        public void PushClipRect(Vector2 clipRectMin, Vector2 clipRectMax, bool intersectWithCurrentClipRect)
        {
            byte nativeIntersectWithCurrentClipRect = intersectWithCurrentClipRect ? (byte)1 : (byte)0;
            ImGuiNative.ImDrawList_PushClipRect((ImDrawList*)(NativePtr), clipRectMin, clipRectMax, nativeIntersectWithCurrentClipRect);
        }
        /// <summary>
        /// Pushes the clip rect full screen
        /// </summary>
        public void PushClipRectFullScreen()
        {
            ImGuiNative.ImDrawList_PushClipRectFullScreen((ImDrawList*)(NativePtr));
        }
        /// <summary>
        /// Pushes the texture id using the specified texture id
        /// </summary>
        /// <param name="textureId">The texture id</param>
        public void PushTextureId(IntPtr textureId)
        {
            ImGuiNative.ImDrawList_PushTextureID((ImDrawList*)(NativePtr), textureId);
        }
    }
}