using System.Numerics;

namespace Alis.Core.Graphic.ImGui
{
    /// <summary>
    /// The im gui size callback data
    /// </summary>
    public unsafe struct ImGuiSizeCallbackData
    {
        /// <summary>
        /// The user data
        /// </summary>
        public void* UserData;
        /// <summary>
        /// The pos
        /// </summary>
        public Vector2 Pos;
        /// <summary>
        /// The current size
        /// </summary>
        public Vector2 CurrentSize;
        /// <summary>
        /// The desired size
        /// </summary>
        public Vector2 DesiredSize;
    }
}
