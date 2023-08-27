using System.Runtime.CompilerServices;

namespace Alis.Core.Graphic.Imgui
{
    /// <summary>
    /// The stb undo record
    /// </summary>
    public struct StbUndoRecord
    {
        /// <summary>
        /// The where
        /// </summary>
        public int where;
        /// <summary>
        /// The insert length
        /// </summary>
        public int insert_length;
        /// <summary>
        /// The delete length
        /// </summary>
        public int delete_length;
        /// <summary>
        /// The char storage
        /// </summary>
        public int char_storage;
    }
}
