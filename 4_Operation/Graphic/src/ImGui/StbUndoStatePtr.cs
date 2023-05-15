using System;

namespace Alis.Core.Graphic.ImGui
{
    /// <summary>
    /// The stb undo state ptr
    /// </summary>
    public unsafe struct StbUndoStatePtr
    {
        /// <summary>
        /// Gets the value of the native ptr
        /// </summary>
        public StbUndoState* NativePtr { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="StbUndoStatePtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public StbUndoStatePtr(StbUndoState* nativePtr) => NativePtr = nativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="StbUndoStatePtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public StbUndoStatePtr(IntPtr nativePtr) => NativePtr = (StbUndoState*)nativePtr;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator StbUndoStatePtr(StbUndoState* nativePtr) => new StbUndoStatePtr(nativePtr);
        
        /// <summary>
        /// /
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator StbUndoState* (StbUndoStatePtr wrappedPtr) => wrappedPtr.NativePtr;
        
        /// <summary>
        /// /
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator StbUndoStatePtr(IntPtr nativePtr) => new StbUndoStatePtr(nativePtr);
        /// <summary>
        /// Gets the value of the undo rec
        /// </summary>
        public RangeAccessor<StbUndoRecord> undo_rec => new RangeAccessor<StbUndoRecord>(&NativePtr->undo_rec_0, 99);
        /// <summary>
        /// Gets the value of the undo char
        /// </summary>
        public RangeAccessor<ushort> undo_char => new RangeAccessor<ushort>(NativePtr->undo_char, 999);
        /// <summary>
        /// Gets the value of the undo point
        /// </summary>
        public ref short undo_point => ref Unsafe.AsRef<short>(&NativePtr->undo_point);
        /// <summary>
        /// Gets the value of the redo point
        /// </summary>
        public ref short redo_point => ref Unsafe.AsRef<short>(&NativePtr->redo_point);
        /// <summary>
        /// Gets the value of the undo char point
        /// </summary>
        public ref int undo_char_point => ref Unsafe.AsRef<int>(&NativePtr->undo_char_point);
        /// <summary>
        /// Gets the value of the redo char point
        /// </summary>
        public ref int redo_char_point => ref Unsafe.AsRef<int>(&NativePtr->redo_char_point);
    }
}