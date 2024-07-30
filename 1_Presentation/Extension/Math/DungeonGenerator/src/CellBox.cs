//------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Box.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//------------------------------------------------------------------------------------------
namespace Alis.Extension.Math.DungeonGenerator
{
    /// <summary>
    /// The type cell box enum
    /// </summary>
    public enum CellBox
    {
        /// <summary>The empty</summary>
        Empty,

        /// <summary>The floor</summary>
        Floor,

        /// <summary>The wall down</summary>
        WallDown,

        /// <summary>The wall left</summary>
        WallLeft,

        /// <summary>The wall right</summary>
        WallRight,

        /// <summary>The wall top</summary>
        WallTop,

        /// <summary>The corner left up</summary>
        CornerLeftUp,

        /// <summary>The corner right up</summary>
        CornerRightUp,

        /// <summary>The corner left down</summary>
        CornerLeftDown,

        /// <summary>The corner right down</summary>
        CornerRightDown,

        /// <summary>The corner internal left down</summary>
        CornerInternalLeftDown,

        /// <summary>The corner internal left up</summary>
        CornerInternalLeftUp,

        /// <summary>The corner internal right down</summary>
        CornerInternalRightDown,

        /// <summary>The corner internal right up</summary>
        CornerInternalRightUp
    }
}