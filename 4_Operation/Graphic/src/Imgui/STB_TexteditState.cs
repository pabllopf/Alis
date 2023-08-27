using System.Runtime.CompilerServices;

namespace Alis.Core.Graphic.Imgui
{
    /// <summary>
    /// The stb texteditstate
    /// </summary>
    public unsafe struct STB_TexteditState
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
}
