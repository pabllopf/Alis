using System;
using System.Runtime.CompilerServices;

namespace ImGuiNET
{
    /// <summary>
    /// The im gui key data
    /// </summary>
    public unsafe partial struct ImGuiKeyData
    {
        /// <summary>
        /// The down
        /// </summary>
        public byte Down;
        /// <summary>
        /// The down duration
        /// </summary>
        public float DownDuration;
        /// <summary>
        /// The down duration prev
        /// </summary>
        public float DownDurationPrev;
        /// <summary>
        /// The analog value
        /// </summary>
        public float AnalogValue;
    }
    /// <summary>
    /// The im gui key data ptr
    /// </summary>
    public unsafe partial struct ImGuiKeyDataPtr
    {
        /// <summary>
        /// Gets the value of the native ptr
        /// </summary>
        public ImGuiKeyData* NativePtr { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ImGuiKeyDataPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiKeyDataPtr(ImGuiKeyData* nativePtr) => NativePtr = nativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="ImGuiKeyDataPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiKeyDataPtr(IntPtr nativePtr) => NativePtr = (ImGuiKeyData*)nativePtr;
        public static implicit operator ImGuiKeyDataPtr(ImGuiKeyData* nativePtr) => new ImGuiKeyDataPtr(nativePtr);
        public static implicit operator ImGuiKeyData* (ImGuiKeyDataPtr wrappedPtr) => wrappedPtr.NativePtr;
        public static implicit operator ImGuiKeyDataPtr(IntPtr nativePtr) => new ImGuiKeyDataPtr(nativePtr);
        /// <summary>
        /// Gets the value of the down
        /// </summary>
        public ref bool Down => ref Unsafe.AsRef<bool>(&NativePtr->Down);
        /// <summary>
        /// Gets the value of the down duration
        /// </summary>
        public ref float DownDuration => ref Unsafe.AsRef<float>(&NativePtr->DownDuration);
        /// <summary>
        /// Gets the value of the down duration prev
        /// </summary>
        public ref float DownDurationPrev => ref Unsafe.AsRef<float>(&NativePtr->DownDurationPrev);
        /// <summary>
        /// Gets the value of the analog value
        /// </summary>
        public ref float AnalogValue => ref Unsafe.AsRef<float>(&NativePtr->AnalogValue);
    }
}
