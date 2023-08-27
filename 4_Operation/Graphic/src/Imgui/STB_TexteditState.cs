using System.Runtime.CompilerServices;

namespace Alis.Core.Graphic.Imgui
{
    /// <summary>
    /// The stb texteditstate
    /// </summary>
    public struct StbTexteditState
    {
        /// <summary>
        /// The cursor
        /// </summary>
        public int Cursor;
        /// <summary>
        /// The select start
        /// </summary>
        public int SelectStart;
        /// <summary>
        /// The select end
        /// </summary>
        public int SelectEnd;
        /// <summary>
        /// The insert mode
        /// </summary>
        public byte InsertMode;
        /// <summary>
        /// The row count per page
        /// </summary>
        public int RowCountPerPage;
        /// <summary>
        /// The cursor at end of line
        /// </summary>
        public byte CursorAtEndOfLine;
        /// <summary>
        /// The initialized
        /// </summary>
        public byte Initialized;
        /// <summary>
        /// The has preferred
        /// </summary>
        public byte HasPreferredX;
        /// <summary>
        /// The single line
        /// </summary>
        public byte SingleLine;
        /// <summary>
        /// The padding
        /// </summary>
        public byte Padding1;
        /// <summary>
        /// The padding
        /// </summary>
        public byte Padding2;
        /// <summary>
        /// The padding
        /// </summary>
        public byte Padding3;
        /// <summary>
        /// The preferred
        /// </summary>
        public float PreferredX;
        /// <summary>
        /// The undostate
        /// </summary>
        public StbUndoState Undostate;
    }
}
