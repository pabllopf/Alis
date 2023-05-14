using System;
using System.Runtime.CompilerServices;

namespace ImGuiNET
{
    /// <summary>
    /// The im gui table column sort specs
    /// </summary>
    public unsafe partial struct ImGuiTableColumnSortSpecs
    {
        /// <summary>
        /// The column user id
        /// </summary>
        public uint ColumnUserID;
        /// <summary>
        /// The column index
        /// </summary>
        public short ColumnIndex;
        /// <summary>
        /// The sort order
        /// </summary>
        public short SortOrder;
        /// <summary>
        /// The sort direction
        /// </summary>
        public ImGuiSortDirection SortDirection;
    }
    /// <summary>
    /// The im gui table column sort specs ptr
    /// </summary>
    public unsafe partial struct ImGuiTableColumnSortSpecsPtr
    {
        /// <summary>
        /// Gets the value of the native ptr
        /// </summary>
        public ImGuiTableColumnSortSpecs* NativePtr { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ImGuiTableColumnSortSpecsPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiTableColumnSortSpecsPtr(ImGuiTableColumnSortSpecs* nativePtr) => NativePtr = nativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="ImGuiTableColumnSortSpecsPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiTableColumnSortSpecsPtr(IntPtr nativePtr) => NativePtr = (ImGuiTableColumnSortSpecs*)nativePtr;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiTableColumnSortSpecsPtr(ImGuiTableColumnSortSpecs* nativePtr) => new ImGuiTableColumnSortSpecsPtr(nativePtr);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiTableColumnSortSpecs* (ImGuiTableColumnSortSpecsPtr wrappedPtr) => wrappedPtr.NativePtr;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiTableColumnSortSpecsPtr(IntPtr nativePtr) => new ImGuiTableColumnSortSpecsPtr(nativePtr);
        /// <summary>
        /// Gets the value of the column user id
        /// </summary>
        public ref uint ColumnUserID => ref Unsafe.AsRef<uint>(&NativePtr->ColumnUserID);
        /// <summary>
        /// Gets the value of the column index
        /// </summary>
        public ref short ColumnIndex => ref Unsafe.AsRef<short>(&NativePtr->ColumnIndex);
        /// <summary>
        /// Gets the value of the sort order
        /// </summary>
        public ref short SortOrder => ref Unsafe.AsRef<short>(&NativePtr->SortOrder);
        /// <summary>
        /// Gets the value of the sort direction
        /// </summary>
        public ref ImGuiSortDirection SortDirection => ref Unsafe.AsRef<ImGuiSortDirection>(&NativePtr->SortDirection);
        /// <summary>
        /// Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImGuiNative.ImGuiTableColumnSortSpecs_destroy((ImGuiTableColumnSortSpecs*)(NativePtr));
        }
    }
}
