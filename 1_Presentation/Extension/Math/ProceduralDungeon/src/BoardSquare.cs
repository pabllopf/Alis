

using System;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Extension.Math.ProceduralDungeon
{
    /// <summary>
    ///     The board square class
    /// </summary>
    [Serializable]
    public partial class BoardSquare(BoardSquareType type)
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="BoardSquare" /> class
        /// </summary>
        public BoardSquare() : this(BoardSquareType.Empty)
        {
        }

        /// <summary>
        ///     Gets or sets the value of the type
        /// </summary>
        [JsonNativePropertyName("type")]
        public BoardSquareType Type { get; set; } = type;
    }
}