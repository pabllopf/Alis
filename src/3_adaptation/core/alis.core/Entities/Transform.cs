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
            Tools.Logger.Trace();
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Transform"/> class
        /// </summary>
        /// <param name="scale">The scale</param>
        public Transform(Vector3 scale)
        {
            this.scale = scale;
            position = new Vector3(0.0f, 0.0f, 0.0f);
            rotation = new Vector3(0.0f, 0.0f, 0.0f);
            Tools.Logger.Trace(scale);
        }

        /// <summary>Initializes a new instance of the <see cref="Transform" /> class.</summary>
        /// <param name="scale">The size.</param>
        /// <param name="position">The position.</param>
        /// <param name="rotation">The rotation.</param>
        [JsonConstructor]
        public Transform(Vector3 scale, Vector3 position, Vector3 rotation)
        {
            this.scale = scale;
            this.position = position;
            this.rotation = rotation;
            Tools.Logger.Trace(scale, position, rotation);
        }
        
        /// <summary>
        /// Gets or sets the value of the scale
        /// </summary>
        [JsonPropertyName("_Scale")]
        public Vector3 Scale
        {
            get
            {
                Tools.Logger.Trace("Scale.Get()", "return scale:", scale);
                return scale;
            }
            set
            {
                Tools.Logger.Trace("Scale.Set(Vector3 scale)", "scale from:", scale, "scale to:", value);
                scale = value;
            }
        }

        /// <summary>
        /// Gets or sets the value of the position
        /// </summary>
        [JsonPropertyName("_Position")]
        public Vector3 Position
        {
            get
            {
                Tools.Logger.Trace("Position.Get()", "return position:", position);
                return position;
            }
            set
            {
                Tools.Logger.Trace("Position.Set(Vector3 position)", "position from:", position, "position to:", value);
                position = value;
            }
        }

        /// <summary>
        /// Gets or sets the value of the rotation
        /// </summary>
        [JsonPropertyName("_Rotation")]
        public Vector3 Rotation
        {
            get
            {
                Tools.Logger.Trace("Rotation.Get()", "return rotation:", rotation);
                return rotation;
            }
            set
            {
                Tools.Logger.Trace("Rotation.Set(Vector3 rotation)", "rotation from:", rotation, "rotation to:", value);
                rotation = value;
            }
        }
        
        ~Transform()
        {
            Tools.Logger.Trace("~Transform()");
        }
    }
}