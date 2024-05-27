// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Transform.cs
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
using System.Runtime.Serialization;
using Alis.Core.Aspect.Data.Json;
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Core.Physic
{
    /// <summary>
    ///     A transform contains translation and rotation. It is used to represent the position and orientation of rigid
    ///     frames.
    /// </summary>
    [Serializable]
    public struct Transform : ISerializable
    {
        /// <summary>
        ///     The
        /// </summary>
        [JsonPropertyName("_Position_")]
        public Vector2 Position;
        
        /// <summary>
        ///     The scale
        /// </summary>
        [JsonPropertyName("_Scale_")]
        public Vector2 Scale;
        
        /// <summary>
        ///     The
        /// </summary>
        [JsonPropertyName("_Rotation_")]
        public Rotation Rotation;
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="Transform" /> class
        /// </summary>
        /// <param name="position">The position</param>
        /// <param name="rotation">The rotation</param>
        /// <param name="scale">The scale</param>
        [JsonConstructor]
        public Transform(Vector2 position, Rotation rotation, Vector2 scale)
        {
            Position = position;
            Rotation = rotation;
            Scale = scale;
        }
        
        
        /// <summary>
        /// Gets the object data using the specified info
        /// </summary>
        /// <param name="info">The info</param>
        /// <param name="context">The context</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("_Position_", Position);
            info.AddValue("_Scale_", Scale);
            info.AddValue("_Rotation_", Rotation);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Transform"/> class
        /// </summary>
        /// <param name="info">The info</param>
        /// <param name="context">The context</param>
        public Transform(SerializationInfo info, StreamingContext context)
        {
            Position = (Vector2)info.GetValue("_Position_", typeof(Vector2));
            Scale = (Vector2)info.GetValue("_Scale_", typeof(Vector2));
            Rotation = (Rotation)info.GetValue("_Rotation_", typeof(Rotation));
        }
        
        /// <summary>Set this to the identity transform.</summary>
        public void SetIdentity()
        {
            Position = Vector2.Zero;
            Rotation.SetIdentity();
        }
        
        /// <summary>Set this based on the position and angle.</summary>
        /// <param name="position">The position.</param>
        /// <param name="angle">The angle.</param>
        public void Set(Vector2 position, float angle)
        {
            Position = position;
            Rotation.Set(angle);
        }
    }
}