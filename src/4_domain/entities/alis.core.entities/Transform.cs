// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Transform.cs
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

namespace Alis.Core.Entities
{
    /// <summary>Control the object space in the game.</summary>
    public class Transform
    {
        /// <summary>The position</summary>
        private Vector3 position;

        /// <summary>The rotation</summary>
        private Vector3 rotation;

        /// <summary>The size</summary>
        private Vector3 scale;

        /// <summary>Initializes a new instance of the <see cref="Transform" /> class.</summary>
        public Transform()
        {
            scale = new Vector3(1.0f, 1.0f, 1.0f);
            position = new Vector3(0.0f, 0.0f, 0.0f);
            rotation = new Vector3(0.0f, 0.0f, 0.0f);
        }

        /// <summary>Initializes a new instance of the <see cref="Transform" /> class.</summary>
        /// <param name="size">The size.</param>
        public Transform(Vector3 size)
        {
            scale = size;
            position = new Vector3(0.0f, 0.0f, 0.0f);
            rotation = new Vector3(0.0f, 0.0f, 0.0f);
        }

        /// <summary>Initializes a new instance of the <see cref="Transform" /> class.</summary>
        /// <param name="size">The size.</param>
        /// <param name="position">The position.</param>
        /// <param name="rotation">The rotation.</param>
        [JsonConstructor]
        public Transform(Vector3 size, Vector3 position, Vector3 rotation)
        {
            scale = size;
            this.position = position;
            this.rotation = rotation;
        }

        /// <summary>Gets or sets the size.</summary>
        /// <value>The size.</value>
        [JsonPropertyName("_Size")]
        public Vector3 Scale
        {
            get => scale;
            set => scale = value;
        }

        /// <summary>Gets or sets the position.</summary>
        /// <value>The position.</value>
        [JsonPropertyName("_Position")]
        public Vector3 Position
        {
            get => position;
            set => position = value;
        }

        /// <summary>Gets or sets the rotation.</summary>
        /// <value>The rotation.</value>
        [JsonPropertyName("_Rotation")]
        public Vector3 Rotation
        {
            get => rotation;
            set => rotation = value;
        }
    }
}