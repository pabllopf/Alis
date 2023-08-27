using System.Runtime.CompilerServices;

namespace Alis.Core.Graphic.Imgui
{
    /// <summary>
    /// The im gui input text callback data
    /// </summary>
    public unsafe struct ImGuiInputTextCallbackData
    {
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
}
