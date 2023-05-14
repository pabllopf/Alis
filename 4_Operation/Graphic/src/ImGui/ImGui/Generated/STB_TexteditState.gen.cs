using System;
using System.Runtime.CompilerServices;

namespace ImGuiNET
{
    /// <summary>
    /// The stb texteditstate
    /// </summary>
    public unsafe partial struct STB_TexteditState
    {
        /// <summary>
        /// The cursor
        /// </summary>
        public int cursor;
        /// <summary>
        /// The select start
        /// </summary>
        public int select_start;
        /// <summary>
        /// The select end
        /// </summary>
        public int select_end;
        /// <summary>
        /// The insert mode
        /// </summary>
        public byte insert_mode;
        /// <summary>
        /// The row count per page
        /// </summary>
        public int row_count_per_page;
        /// <summary>
        /// The cursor at end of line
        /// </summary>
        public byte cursor_at_end_of_line;
        /// <summary>
        /// The initialized
        /// </summary>
        public byte initialized;
        /// <summary>
        /// The has preferred
        /// </summary>
        public byte has_preferred_x;
        /// <summary>
        /// The single line
        /// </summary>
        public byte single_line;
        /// <summary>
        /// The padding
        /// </summary>
        public byte padding1;
        /// <summary>
        /// The padding
        /// </summary>
        public byte padding2;
        /// <summary>
        /// The padding
        /// </summary>
        public byte padding3;
        /// <summary>
        /// The preferred
        /// </summary>
        public float preferred_x;
        /// <summary>
        /// The undostate
        /// </summary>
        public StbUndoState undostate;
    }
    /// <summary>
    /// The stb texteditstateptr
    /// </summary>
    public unsafe partial struct STB_TexteditStatePtr
    {
        /// <summary>
        /// Gets the value of the native ptr
        /// </summary>
        public STB_TexteditState* NativePtr { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="STB_TexteditStatePtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public STB_TexteditStatePtr(STB_TexteditState* nativePtr) => NativePtr = nativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="STB_TexteditStatePtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public STB_TexteditStatePtr(IntPtr nativePtr) => NativePtr = (STB_TexteditState*)nativePtr;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator STB_TexteditStatePtr(STB_TexteditState* nativePtr) => new STB_TexteditStatePtr(nativePtr);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator STB_TexteditState* (STB_TexteditStatePtr wrappedPtr) => wrappedPtr.NativePtr;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator STB_TexteditStatePtr(IntPtr nativePtr) => new STB_TexteditStatePtr(nativePtr);
        /// <summary>
        /// Gets the value of the cursor
        /// </summary>
        public ref int cursor => ref Unsafe.AsRef<int>(&NativePtr->cursor);
        /// <summary>
        /// Gets the value of the select start
        /// </summary>
        public ref int select_start => ref Unsafe.AsRef<int>(&NativePtr->select_start);
        /// <summary>
        /// Gets the value of the select end
        /// </summary>
        public ref int select_end => ref Unsafe.AsRef<int>(&NativePtr->select_end);
        /// <summary>
        /// Gets the value of the insert mode
        /// </summary>
        public ref byte insert_mode => ref Unsafe.AsRef<byte>(&NativePtr->insert_mode);
        /// <summary>
        /// Gets the value of the row count per page
        /// </summary>
        public ref int row_count_per_page => ref Unsafe.AsRef<int>(&NativePtr->row_count_per_page);
        /// <summary>
        /// Gets the value of the cursor at end of line
        /// </summary>
        public ref byte cursor_at_end_of_line => ref Unsafe.AsRef<byte>(&NativePtr->cursor_at_end_of_line);
        /// <summary>
        /// Gets the value of the initialized
        /// </summary>
        public ref byte initialized => ref Unsafe.AsRef<byte>(&NativePtr->initialized);
        /// <summary>
        /// Gets the value of the has preferred x
        /// </summary>
        public ref byte has_preferred_x => ref Unsafe.AsRef<byte>(&NativePtr->has_preferred_x);
        /// <summary>
        /// Gets the value of the single line
        /// </summary>
        public ref byte single_line => ref Unsafe.AsRef<byte>(&NativePtr->single_line);
        /// <summary>
        /// Gets the value of the padding 1
        /// </summary>
        public ref byte padding1 => ref Unsafe.AsRef<byte>(&NativePtr->padding1);
        /// <summary>
        /// Gets the value of the padding 2
        /// </summary>
        public ref byte padding2 => ref Unsafe.AsRef<byte>(&NativePtr->padding2);
        /// <summary>
        /// Gets the value of the padding 3
        /// </summary>
        public ref byte padding3 => ref Unsafe.AsRef<byte>(&NativePtr->padding3);
        /// <summary>
        /// Gets the value of the preferred x
        /// </summary>
        public ref float preferred_x => ref Unsafe.AsRef<float>(&NativePtr->preferred_x);
        /// <summary>
        /// Gets the value of the undostate
        /// </summary>
        public ref StbUndoState undostate => ref Unsafe.AsRef<StbUndoState>(&NativePtr->undostate);
    }
}
