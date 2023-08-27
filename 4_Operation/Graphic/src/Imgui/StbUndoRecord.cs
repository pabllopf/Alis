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
        public int Where;
        /// <summary>
        /// The insert length
        /// </summary>
        public int InsertLength;
        /// <summary>
        /// The delete length
        /// </summary>
        public int DeleteLength;
        /// <summary>
        /// The char storage
        /// </summary>
        public int CharStorage;
    }
}
