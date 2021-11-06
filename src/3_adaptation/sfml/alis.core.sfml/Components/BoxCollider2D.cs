// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   BoxCollider2D.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System.Numerics;
using System.Text.Json.Serialization;

namespace Alis.Core.Sfml.Components
{
    /// <summary>
    ///     The box collider class
    /// </summary>
    /// <seealso cref="Collider" />
    public class BoxCollider2D : Collider
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="BoxCollider2D" /> class
        /// </summary>
        private BoxCollider2D()
        {
            Size = new Vector2(1.0f, 1.0f);
            RelativePosition = new Vector2(0.0f, 0.0f);
        }

        /// <summary>
        ///     Gets the value of the instance
        /// </summary>
        public static BoxCollider2D Instance { get; } = new BoxCollider2D();

        /// <summary>
        ///     Gets or sets the value of the auto tiling
        /// </summary>
        [JsonPropertyName("_AutoTiling")]
        public bool AutoTiling { get; set; }

        /// <summary>
        ///     Gets or sets the value of the relative position
        /// </summary>
        [JsonPropertyName("_RelativePosition")]
        public Vector2 RelativePosition { get; set; }

        /// <summary>
        ///     Gets or sets the value of the size
        /// </summary>
        [JsonPropertyName("_Size")]
        public Vector2 Size { get; set; }

        /// <summary>
        ///     Creates the instance
        /// </summary>
        /// <returns>The box collider</returns>
        public static BoxCollider2D CreateInstance() => Instance;

        /// <summary>
        ///     Starts this instance
        /// </summary>
        public override void Start()
        {
        }

        /// <summary>
        ///     Updates this instance
        /// </summary>
        public override void Update()
        {
        }
    }
}