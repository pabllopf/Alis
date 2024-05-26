// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Vector4.cs
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
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Alis.Core.Aspect.Math.Vector
{
    /// <summary>
    ///     The vector
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    [Serializable]
    public struct Vector4 : ISerializable
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Vector4" /> class
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="z">The </param>
        /// <param name="w">The </param>
        public Vector4(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Vector4"/> class
        /// </summary>
        /// <param name="info">The info</param>
        /// <param name="context">The context</param>
        private Vector4(SerializationInfo info, StreamingContext context)
        {
            X = info.GetSingle("X");
            Y = info.GetSingle("Y");
            Z = info.GetSingle("Z");
            W = info.GetSingle("W");
        }
        
        /// <summary>
        /// Gets the object data using the specified info
        /// </summary>
        /// <param name="info">The info</param>
        /// <param name="context">The context</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("X", X);
            info.AddValue("Y", Y);
            info.AddValue("Z", Z);
            info.AddValue("W", W);
        }

        
        
        /// <summary>
        ///     Gets the v
        /// </summary>
        /// <param name="v">The </param>
        /// <param name="index">The index</param>
        /// <returns>The float</returns>
        public static float Get(Vector4 v, int index)
        {
            switch (index)
            {
                case 0: return v.X;
                case 1: return v.Y;
                case 2: return v.Z;
                case 3: return v.W;
                default: return 0; // error case
            }
        }
        
        /// <summary>Horizontal component of the vector</summary>
        public float X;
        
        /// <summary>Vertical component of the vector</summary>
        public float Y;
        
        /// <summary>Depth component of the vector</summary>
        public float Z;
        
        /// <summary>Projective/Homogenous component of the vector</summary>
        public float W;
    }
}