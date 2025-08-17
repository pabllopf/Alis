// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BoardSquare.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Extension.Math.ProceduralDungeon
{
    /// <summary>
    /// The board square class
    /// </summary>
    [Serializable]
    public partial class BoardSquare(BoardSquareType type)
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BoardSquare"/> class
        /// </summary>
        public BoardSquare() : this(BoardSquareType.Empty)
        {
        }

        /// <summary>
        /// Gets or sets the value of the type
        /// </summary>
        [JsonNativePropertyName("type")]
        public BoardSquareType Type { get; set; } = type;
    }
}