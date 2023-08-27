using System.Numerics;
using System.Runtime.CompilerServices;

namespace Alis.Core.Graphic.Imgui
{
    /// <summary>
    /// The im gui viewport
    /// </summary>
    public unsafe struct ImGuiViewport
    {
        /// <summary>
        /// The id
        /// </summary>
        public uint ID;
        /// <summary>
        /// The flags
        /// </summary>
        public ImGuiViewportFlags Flags;
        /// <summary>
        /// The pos
        /// </summary>
        public Vector2 Pos;
        /// <summary>
        /// The size
        /// </summary>
        public Vector2 Size;
        /// <summary>
        /// The work pos
        /// </summary>
        public Vector2 WorkPos;
        /// <summary>
        /// The work size
        /// </summary>
        public Vector2 WorkSize;
        /// <summary>
        /// The dpi scale
        /// </summary>
        public float DpiScale;
        /// <summary>
        /// The parent viewport id
        /// </summary>
        public uint ParentViewportId;
        /// <summary>
        /// The draw data
        /// </summary>
        public ImDrawData* DrawData;
        /// <summary>
        /// The renderer user data
        /// </summary>
        public void* RendererUserData;
        /// <summary>
        /// The platform user data
        /// </summary>
        public void* PlatformUserData;
        /// <summary>
        /// The platform handle
        /// </summary>
        public void* PlatformHandle;
        /// <summary>
        /// The platform handle raw
        /// </summary>
        public void* PlatformHandleRaw;
        /// <summary>
        /// The platform window created
        /// </summary>
        public byte PlatformWindowCreated;
        /// <summary>
        /// The platform request move
        /// </summary>
        public byte PlatformRequestMove;
        /// <summary>
        /// The platform request resize
        /// </summary>
        public byte PlatformRequestResize;
        /// <summary>
        /// The platform request close
        /// </summary>
        public byte PlatformRequestClose;
    }
}
