using System;
using System.Text;

namespace Alis.Core.Graphic.ImGui.ImGui
{
    /// <summary>
    /// The im gui input text callback data
    /// </summary>
    public unsafe partial struct ImGuiInputTextCallbackData
    {
        /// <summary>
        /// The ctx
        /// </summary>
        public IntPtr Ctx;
        /// <summary>
        /// The event flag
        /// </summary>
        public ImGuiInputTextFlags EventFlag;
        /// <summary>
        /// The flags
        /// </summary>
        public ImGuiInputTextFlags Flags;
        /// <summary>
        /// The user data
        /// </summary>
        public void* UserData;
        /// <summary>
        /// The event char
        /// </summary>
        public ushort EventChar;
        /// <summary>
        /// The event key
        /// </summary>
        public ImGuiKey EventKey;
        /// <summary>
        /// The buf
        /// </summary>
        public byte* Buf;
        /// <summary>
        /// The buf text len
        /// </summary>
        public int BufTextLen;
        /// <summary>
        /// The buf size
        /// </summary>
        public int BufSize;
        /// <summary>
        /// The buf dirty
        /// </summary>
        public byte BufDirty;
        /// <summary>
        /// The cursor pos
        /// </summary>
        public int CursorPos;
        /// <summary>
        /// The selection start
        /// </summary>
        public int SelectionStart;
        /// <summary>
        /// The selection end
        /// </summary>
        public int SelectionEnd;
    }
    /// <summary>
    /// The im gui input text callback data ptr
    /// </summary>
    public unsafe partial struct ImGuiInputTextCallbackDataPtr
    {
        /// <summary>
        /// Gets the value of the native ptr
        /// </summary>
        public ImGuiInputTextCallbackData* NativePtr { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ImGuiInputTextCallbackDataPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiInputTextCallbackDataPtr(ImGuiInputTextCallbackData* nativePtr) => NativePtr = nativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="ImGuiInputTextCallbackDataPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiInputTextCallbackDataPtr(IntPtr nativePtr) => NativePtr = (ImGuiInputTextCallbackData*)nativePtr;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiInputTextCallbackDataPtr(ImGuiInputTextCallbackData* nativePtr) => new ImGuiInputTextCallbackDataPtr(nativePtr);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiInputTextCallbackData* (ImGuiInputTextCallbackDataPtr wrappedPtr) => wrappedPtr.NativePtr;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImGuiInputTextCallbackDataPtr(IntPtr nativePtr) => new ImGuiInputTextCallbackDataPtr(nativePtr);
        /// <summary>
        /// Gets the value of the ctx
        /// </summary>
        public ref IntPtr Ctx => ref Unsafe.AsRef<IntPtr>(&NativePtr->Ctx);
        /// <summary>
        /// Gets the value of the event flag
        /// </summary>
        public ref ImGuiInputTextFlags EventFlag => ref Unsafe.AsRef<ImGuiInputTextFlags>(&NativePtr->EventFlag);
        /// <summary>
        /// Gets the value of the flags
        /// </summary>
        public ref ImGuiInputTextFlags Flags => ref Unsafe.AsRef<ImGuiInputTextFlags>(&NativePtr->Flags);
        /// <summary>
        /// Gets or sets the value of the user data
        /// </summary>
        public IntPtr UserData { get => (IntPtr)NativePtr->UserData; set => NativePtr->UserData = (void*)value; }
        /// <summary>
        /// Gets the value of the event char
        /// </summary>
        public ref ushort EventChar => ref Unsafe.AsRef<ushort>(&NativePtr->EventChar);
        /// <summary>
        /// Gets the value of the event key
        /// </summary>
        public ref ImGuiKey EventKey => ref Unsafe.AsRef<ImGuiKey>(&NativePtr->EventKey);
        /// <summary>
        /// Gets or sets the value of the buf
        /// </summary>
        public IntPtr Buf { get => (IntPtr)NativePtr->Buf; set => NativePtr->Buf = (byte*)value; }
        /// <summary>
        /// Gets the value of the buf text len
        /// </summary>
        public ref int BufTextLen => ref Unsafe.AsRef<int>(&NativePtr->BufTextLen);
        /// <summary>
        /// Gets the value of the buf size
        /// </summary>
        public ref int BufSize => ref Unsafe.AsRef<int>(&NativePtr->BufSize);
        /// <summary>
        /// Gets the value of the buf dirty
        /// </summary>
        public ref bool BufDirty => ref Unsafe.AsRef<bool>(&NativePtr->BufDirty);
        /// <summary>
        /// Gets the value of the cursor pos
        /// </summary>
        public ref int CursorPos => ref Unsafe.AsRef<int>(&NativePtr->CursorPos);
        /// <summary>
        /// Gets the value of the selection start
        /// </summary>
        public ref int SelectionStart => ref Unsafe.AsRef<int>(&NativePtr->SelectionStart);
        /// <summary>
        /// Gets the value of the selection end
        /// </summary>
        public ref int SelectionEnd => ref Unsafe.AsRef<int>(&NativePtr->SelectionEnd);
        /// <summary>
        /// Clears the selection
        /// </summary>
        public void ClearSelection()
        {
            ImGuiNative.ImGuiInputTextCallbackData_ClearSelection((ImGuiInputTextCallbackData*)(NativePtr));
        }
        /// <summary>
        /// Deletes the chars using the specified pos
        /// </summary>
        /// <param name="pos">The pos</param>
        /// <param name="bytes_count">The bytes count</param>
        public void DeleteChars(int pos, int bytes_count)
        {
            ImGuiNative.ImGuiInputTextCallbackData_DeleteChars((ImGuiInputTextCallbackData*)(NativePtr), pos, bytes_count);
        }
        /// <summary>
        /// Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImGuiNative.ImGuiInputTextCallbackData_destroy((ImGuiInputTextCallbackData*)(NativePtr));
        }
        /// <summary>
        /// Describes whether this instance has selection
        /// </summary>
        /// <returns>The bool</returns>
        public bool HasSelection()
        {
            byte ret = ImGuiNative.ImGuiInputTextCallbackData_HasSelection((ImGuiInputTextCallbackData*)(NativePtr));
            return ret != 0;
        }
        /// <summary>
        /// Inserts the chars using the specified pos
        /// </summary>
        /// <param name="pos">The pos</param>
        /// <param name="text">The text</param>
        public void InsertChars(int pos, string text)
        {
            byte* native_text;
            int text_byteCount = 0;
            if (text != null)
            {
                text_byteCount = Encoding.UTF8.GetByteCount(text);
                if (text_byteCount > Util.StackAllocationSizeLimit)
                {
                    native_text = Util.Allocate(text_byteCount + 1);
                }
                else
                {
                    byte* native_text_stackBytes = stackalloc byte[text_byteCount + 1];
                    native_text = native_text_stackBytes;
                }
                int native_text_offset = Util.GetUtf8(text, native_text, text_byteCount);
                native_text[native_text_offset] = 0;
            }
            else { native_text = null; }
            byte* native_text_end = null;
            ImGuiNative.ImGuiInputTextCallbackData_InsertChars((ImGuiInputTextCallbackData*)(NativePtr), pos, native_text, native_text_end);
            if (text_byteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(native_text);
            }
        }
        /// <summary>
        /// Selects the all
        /// </summary>
        public void SelectAll()
        {
            ImGuiNative.ImGuiInputTextCallbackData_SelectAll((ImGuiInputTextCallbackData*)(NativePtr));
        }
    }
}
