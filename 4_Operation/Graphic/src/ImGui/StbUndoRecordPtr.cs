using System;

namespace Alis.Core.Graphic.ImGui
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
        public ref int where => ref Unsafe.AsRef<int>(&NativePtr->where);
        /// <summary>
        /// Gets the value of the insert length
        /// </summary>
        public ref int insert_length => ref Unsafe.AsRef<int>(&NativePtr->insert_length);
        /// <summary>
        /// Gets the value of the delete length
        /// </summary>
        public ref int delete_length => ref Unsafe.AsRef<int>(&NativePtr->delete_length);
        /// <summary>
        /// Gets the value of the char storage
        /// </summary>
        public ref int char_storage => ref Unsafe.AsRef<int>(&NativePtr->char_storage);
    }
}
