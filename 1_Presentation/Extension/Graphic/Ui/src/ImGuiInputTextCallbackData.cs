

using System;

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The im gui input text callback data
    /// </summary>
    public struct ImGuiInputTextCallbackData
    {
        /// <summary>
        ///     The event flag
        /// </summary>
        public ImGuiInputTextFlags EventFlag { get; set; }

        /// <summary>
        ///     The flags
        /// </summary>
        public ImGuiInputTextFlags Flags { get; set; }

        /// <summary>
        ///     The user data
        /// </summary>
        public IntPtr UserData { get; set; }

        /// <summary>
        ///     The event char
        /// </summary>
        public ushort EventChar { get; set; }

        /// <summary>
        ///     The event key
        /// </summary>
        public ImGuiKey EventKey { get; set; }

        /// <summary>
        ///     The buf
        /// </summary>
        public IntPtr Buf { get; set; }

        /// <summary>
        ///     The buf text len
        /// </summary>
        public int BufTextLen { get; set; }

        /// <summary>
        ///     The buf size
        /// </summary>
        public int BufSize { get; set; }

        /// <summary>
        ///     The buf dirty
        /// </summary>
        public byte BufDirty { get; set; }

        /// <summary>
        ///     The cursor pos
        /// </summary>
        public int CursorPos { get; set; }

        /// <summary>
        ///     The selection start
        /// </summary>
        public int SelectionStart { get; set; }

        /// <summary>
        ///     The selection end
        /// </summary>
        public int SelectionEnd { get; set; }
    }
}