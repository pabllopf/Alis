// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RenderStates.cs
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

namespace Alis.Core.Graphic.SFML.Graphics
{
    ////////////////////////////////////////////////////////////
    /// <summary>
    ///     Define the states used for drawing to a RenderTarget
    /// </summary>
    ////////////////////////////////////////////////////////////
    public struct RenderStates
    {
        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct a default set of render states with a custom blend mode
        /// </summary>
        /// <param name="blendMode">Blend mode to use</param>
        ////////////////////////////////////////////////////////////
        public RenderStates(BlendMode blendMode) :
            this(blendMode, Transform.Identity, null, null)
        {
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct a default set of render states with a custom transform
        /// </summary>
        /// <param name="transform">Transform to use</param>
        ////////////////////////////////////////////////////////////
        public RenderStates(Transform transform) :
            this(BlendMode.Alpha, transform, null, null)
        {
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct a default set of render states with a custom texture
        /// </summary>
        /// <param name="texture">Texture to use</param>
        ////////////////////////////////////////////////////////////
        public RenderStates(Texture texture) :
            this(BlendMode.Alpha, Transform.Identity, texture, null)
        {
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct a default set of render states with a custom shader
        /// </summary>
        /// <param name="shader">Shader to use</param>
        ////////////////////////////////////////////////////////////
        public RenderStates(Shader shader) :
            this(BlendMode.Alpha, Transform.Identity, null, shader)
        {
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct a set of render states with all its attributes
        /// </summary>
        /// <param name="blendMode">Blend mode to use</param>
        /// <param name="transform">Transform to use</param>
        /// <param name="texture">Texture to use</param>
        /// <param name="shader">Shader to use</param>
        ////////////////////////////////////////////////////////////
        public RenderStates(BlendMode blendMode, Transform transform, Texture texture, Shader shader)
        {
            BlendMode = blendMode;
            Transform = transform;
            Texture = texture;
            Shader = shader;
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Copy constructor
        /// </summary>
        /// <param name="copy">States to copy</param>
        ////////////////////////////////////////////////////////////
        public RenderStates(RenderStates copy)
        {
            BlendMode = copy.BlendMode;
            Transform = copy.Transform;
            Texture = copy.Texture;
            Shader = copy.Shader;
        }

        ////////////////////////////////////////////////////////////
        /// <summary>Special instance holding the default render states</summary>
        ////////////////////////////////////////////////////////////
        public static RenderStates Default => new RenderStates(BlendMode.Alpha, Transform.Identity, null, null);

        /// <summary>Blending mode</summary>
        public BlendMode BlendMode;

        /// <summary>Transform</summary>
        public Transform Transform;

        /// <summary>Texture</summary>
        public readonly Texture Texture;

        /// <summary>Shader</summary>
        public readonly Shader Shader;

        // Return a marshalled version of the instance, that can directly be passed to the C API
        /// <summary>
        ///     Marshals this instance
        /// </summary>
        /// <returns>The data</returns>
        internal MarshalData Marshal()
        {
            MarshalData data = new MarshalData();
            data.blendMode = BlendMode;
            data.transform = Transform;
            data.texture = Texture != null ? Texture.CPointer : IntPtr.Zero;
            data.shader = Shader != null ? Shader.CPointer : IntPtr.Zero;

            return data;
        }

        /// <summary>
        ///     The marshal data
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct MarshalData
        {
            /// <summary>
            ///     The blend mode
            /// </summary>
            public BlendMode blendMode;

            /// <summary>
            ///     The transform
            /// </summary>
            public Transform transform;

            /// <summary>
            ///     The texture
            /// </summary>
            public IntPtr texture;

            /// <summary>
            ///     The shader
            /// </summary>
            public IntPtr shader;
        }
    }
}