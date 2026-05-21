

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The stb text
    /// </summary>
    public struct StbTexteditState
    {
        /// <summary>
        ///     The cursor
        /// </summary>
        public int Cursor { get; set; }

        /// <summary>
        ///     The select start
        /// </summary>
        public int SelectStart { get; set; }

        /// <summary>
        ///     The select end
        /// </summary>
        public int SelectEnd { get; set; }

        /// <summary>
        ///     The insert mode
        /// </summary>
        public byte InsertMode { get; set; }

        /// <summary>
        ///     The row count per page
        /// </summary>
        public int RowCountPerPage { get; set; }

        /// <summary>
        ///     The cursor at end of line
        /// </summary>
        public byte CursorAtEndOfLine { get; set; }

        /// <summary>
        ///     The initialized
        /// </summary>
        public byte Initialized { get; set; }

        /// <summary>
        ///     The has preferred
        /// </summary>
        public byte HasPreferredX { get; set; }

        /// <summary>
        ///     The single line
        /// </summary>
        public byte SingleLine { get; set; }

        /// <summary>
        ///     The padding
        /// </summary>
        public byte Padding1 { get; set; }

        /// <summary>
        ///     The padding
        /// </summary>
        public byte Padding2 { get; set; }

        /// <summary>
        ///     The padding
        /// </summary>
        public byte Padding3 { get; set; }

        /// <summary>
        ///     The preferred
        /// </summary>
        public float PreferredX { get; set; }

        /// <summary>
        ///     The undo
        /// </summary>
        public StbUndoState UndoState { get; set; }
    }
}