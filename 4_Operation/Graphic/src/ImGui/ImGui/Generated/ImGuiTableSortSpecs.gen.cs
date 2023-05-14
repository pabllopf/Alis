using System;
using System.Runtime.CompilerServices;

namespace ImGuiNET
{
    /// <summary>
    /// The im gui table sort specs
    /// </summary>
    public unsafe partial struct ImGuiTableSortSpecs
    {
        /// <summary>
        /// The specs
        /// </summary>
        public ImGuiTableColumnSortSpecs* Specs;
        /// <summary>
        /// The specs count
        /// </summary>
        public int SpecsCount;
        /// <summary>
        /// The specs dirty
        /// </summary>
        public byte SpecsDirty;
    }
    /// <summary>
    /// The im gui table sort specs ptr
    /// </summary>
    public unsafe partial struct ImGuiTableSortSpecsPtr
    {
        /// <summary>
        /// Gets the value of the native ptr
        /// </summary>
        public ImGuiTableSortSpecs* NativePtr { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ImGuiTableSortSpecsPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiTableSortSpecsPtr(ImGuiTableSortSpecs* nativePtr) => NativePtr = nativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="ImGuiTableSortSpecsPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiTableSortSpecsPtr(IntPtr nativePtr) => NativePtr = (ImGuiTableSortSpecs*)nativePtr;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiTableSortSpecsPtr(ImGuiTableSortSpecs* nativePtr) => new ImGuiTableSortSpecsPtr(nativePtr);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiTableSortSpecs* (ImGuiTableSortSpecsPtr wrappedPtr) => wrappedPtr.NativePtr;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiTableSortSpecsPtr(IntPtr nativePtr) => new ImGuiTableSortSpecsPtr(nativePtr);
        /// <summary>
        /// Gets the value of the specs
        /// </summary>
        public ImGuiTableColumnSortSpecsPtr Specs => new ImGuiTableColumnSortSpecsPtr(NativePtr->Specs);
        /// <summary>
        /// Gets the value of the specs count
        /// </summary>
        public ref int SpecsCount => ref Unsafe.AsRef<int>(&NativePtr->SpecsCount);
        /// <summary>
        /// Gets the value of the specs dirty
        /// </summary>
        public ref bool SpecsDirty => ref Unsafe.AsRef<bool>(&NativePtr->SpecsDirty);
        /// <summary>
        /// Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImGuiNative.ImGuiTableSortSpecs_destroy((ImGuiTableSortSpecs*)(NativePtr));
        }
    }
}
