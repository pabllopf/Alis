using System;
using System.Runtime.CompilerServices;

namespace Alis.Core.Graphic.Imgui
{
    /// <summary>
    /// The im gui list clipper
    /// </summary>
    public unsafe partial struct ImGuiListClipper
    {
        /// <summary>
        /// The display start
        /// </summary>
        public int DisplayStart;
        /// <summary>
        /// The display end
        /// </summary>
        public int DisplayEnd;
        /// <summary>
        /// The items count
        /// </summary>
        public int ItemsCount;
        /// <summary>
        /// The items height
        /// </summary>
        public float ItemsHeight;
        /// <summary>
        /// The start pos
        /// </summary>
        public float StartPosY;
        /// <summary>
        /// The temp data
        /// </summary>
        public void* TempData;
    }
    /// <summary>
    /// The im gui list clipper ptr
    /// </summary>
    public unsafe partial struct ImGuiListClipperPtr
    {
        /// <summary>
        /// Gets the value of the native ptr
        /// </summary>
        public ImGuiListClipper* NativePtr { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ImGuiListClipperPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiListClipperPtr(ImGuiListClipper* nativePtr) => NativePtr = nativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="ImGuiListClipperPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiListClipperPtr(IntPtr nativePtr) => NativePtr = (ImGuiListClipper*)nativePtr;
        public static implicit operator ImGuiListClipperPtr(ImGuiListClipper* nativePtr) => new ImGuiListClipperPtr(nativePtr);
        public static implicit operator ImGuiListClipper* (ImGuiListClipperPtr wrappedPtr) => wrappedPtr.NativePtr;
        public static implicit operator ImGuiListClipperPtr(IntPtr nativePtr) => new ImGuiListClipperPtr(nativePtr);
        /// <summary>
        /// Gets the value of the display start
        /// </summary>
        public ref int DisplayStart => ref Unsafe.AsRef<int>(&NativePtr->DisplayStart);
        /// <summary>
        /// Gets the value of the display end
        /// </summary>
        public ref int DisplayEnd => ref Unsafe.AsRef<int>(&NativePtr->DisplayEnd);
        /// <summary>
        /// Gets the value of the items count
        /// </summary>
        public ref int ItemsCount => ref Unsafe.AsRef<int>(&NativePtr->ItemsCount);
        /// <summary>
        /// Gets the value of the items height
        /// </summary>
        public ref float ItemsHeight => ref Unsafe.AsRef<float>(&NativePtr->ItemsHeight);
        /// <summary>
        /// Gets the value of the start pos y
        /// </summary>
        public ref float StartPosY => ref Unsafe.AsRef<float>(&NativePtr->StartPosY);
        /// <summary>
        /// Gets or sets the value of the temp data
        /// </summary>
        public IntPtr TempData { get => (IntPtr)NativePtr->TempData; set => NativePtr->TempData = (void*)value; }
        /// <summary>
        /// Begins the items count
        /// </summary>
        /// <param name="items_count">The items count</param>
        public void Begin(int items_count)
        {
            float items_height = -1.0f;
            ImGuiNative.ImGuiListClipper_Begin((ImGuiListClipper*)(NativePtr), items_count, items_height);
        }
        /// <summary>
        /// Begins the items count
        /// </summary>
        /// <param name="items_count">The items count</param>
        /// <param name="items_height">The items height</param>
        public void Begin(int items_count, float items_height)
        {
            ImGuiNative.ImGuiListClipper_Begin((ImGuiListClipper*)(NativePtr), items_count, items_height);
        }
        /// <summary>
        /// Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImGuiNative.ImGuiListClipper_destroy((ImGuiListClipper*)(NativePtr));
        }
        /// <summary>
        /// Ends this instance
        /// </summary>
        public void End()
        {
            ImGuiNative.ImGuiListClipper_End((ImGuiListClipper*)(NativePtr));
        }
        /// <summary>
        /// Forces the display range by indices using the specified item min
        /// </summary>
        /// <param name="item_min">The item min</param>
        /// <param name="item_max">The item max</param>
        public void ForceDisplayRangeByIndices(int item_min, int item_max)
        {
            ImGuiNative.ImGuiListClipper_ForceDisplayRangeByIndices((ImGuiListClipper*)(NativePtr), item_min, item_max);
        }
        /// <summary>
        /// Describes whether this instance step
        /// </summary>
        /// <returns>The bool</returns>
        public bool Step()
        {
            byte ret = ImGuiNative.ImGuiListClipper_Step((ImGuiListClipper*)(NativePtr));
            return ret != 0;
        }
    }
}
