using System;
using Alis.Core.Graphic.ImGui.Utils;

namespace Alis.Core.Graphic.Imgui
{
    /// <summary>
    /// The stb undo record ptr
    /// </summary>
    public unsafe struct StbUndoRecordPtr
    {
        /// <summary>
        /// Gets the value of the native ptr
        /// </summary>
        public StbUndoRecord* NativePtr { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="StbUndoRecordPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public StbUndoRecordPtr(StbUndoRecord* nativePtr) => NativePtr = nativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="StbUndoRecordPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public StbUndoRecordPtr(IntPtr nativePtr) => NativePtr = (StbUndoRecord*)nativePtr;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator StbUndoRecordPtr(StbUndoRecord* nativePtr) => new StbUndoRecordPtr(nativePtr);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator StbUndoRecord* (StbUndoRecordPtr wrappedPtr) => wrappedPtr.NativePtr;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator StbUndoRecordPtr(IntPtr nativePtr) => new StbUndoRecordPtr(nativePtr);
        /// <summary>
        /// Gets the value of the where
        /// </summary>
        public ref int Where => ref Unsafe.AsRef<int>(&NativePtr->Where);
        /// <summary>
        /// Gets the value of the insert length
        /// </summary>
        public ref int InsertLength => ref Unsafe.AsRef<int>(&NativePtr->InsertLength);
        /// <summary>
        /// Gets the value of the delete length
        /// </summary>
        public ref int DeleteLength => ref Unsafe.AsRef<int>(&NativePtr->DeleteLength);
        /// <summary>
        /// Gets the value of the char storage
        /// </summary>
        public ref int CharStorage => ref Unsafe.AsRef<int>(&NativePtr->CharStorage);
    }
}