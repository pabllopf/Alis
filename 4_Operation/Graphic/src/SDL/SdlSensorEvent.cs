// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SdlSensorEvent.cs
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

using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl sensorevent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SdlSensorEvent
    {
        /// <summary>
        ///     The type
        /// </summary>
        public readonly SdlEventType type;

        /// <summary>
        ///     The timestamp
        /// </summary>
        public readonly uint timestamp;

        /// <summary>
        ///     The which
        /// </summary>
        public readonly int which;

        /// <summary>
        ///     The data
        /// </summary>
        public readonly float float0;

        /// <summary>
        ///     The data
        /// </summary>
        public readonly float float1;

        /// <summary>
        ///     The data
        /// </summary>
        public readonly float float2;

        /// <summary>
        ///     The data
        /// </summary>
        public readonly float float3;

        /// <summary>
        ///     The data
        /// </summary>
        public readonly float float4;

        /// <summary>
        ///     The data
        /// </summary>
        public readonly float float5;

        /// <summary>
        ///     Gets or sets the value of the text
        /// </summary>
        public float[] Data
        {
            get
            {
                return new float[6]
                {
                    float0,
                    float1,
                    float2,
                    float3,
                    float4,
                    float5
                };
            }
        }
    }
}