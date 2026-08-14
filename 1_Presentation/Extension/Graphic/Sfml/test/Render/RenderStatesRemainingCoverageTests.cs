// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RenderStatesRemainingCoverageTests.cs
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
using Alis.Extension.Graphic.Sfml.Render;
using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    ///     The render states remaining coverage tests class
    /// </summary>
    public class RenderStatesRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that constructor blend mode only sets blend mode and identity transform
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Constructor_BlendModeOnly_SetsBlendModeAndIdentityTransform()
        {
            RenderStates states = new RenderStates(BlendMode.Add);

            Assert.Equal(BlendMode.Add, states.BlendMode);
            Assert.Equal(1f, states.Transform.m00, 5);
            Assert.Equal(1f, states.Transform.m11, 5);
            Assert.Equal(1f, states.Transform.m22, 5);
            Assert.Null(states.Texture);
            Assert.Null(states.Shader);
        }

        /// <summary>
        ///     Tests that constructor transform only sets transform and alpha blend mode
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Constructor_TransformOnly_SetsTransformAndAlphaBlendMode()
        {
            Transform transform = new Transform(2, 0, 0, 0, 2, 0, 0, 0, 1);
            RenderStates states = new RenderStates(transform);

            Assert.Equal(2f, states.Transform.m00, 5);
            Assert.Equal(2f, states.Transform.m11, 5);
            Assert.Equal(1f, states.Transform.m22, 5);
            Assert.Equal(BlendMode.Alpha, states.BlendMode);
        }

        /// <summary>
        ///     Tests that constructor texture only sets null texture and defaults
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Constructor_TextureOnly_SetsDefaults()
        {
            RenderStates states = new RenderStates((Texture)null);

            Assert.Equal(BlendMode.Alpha, states.BlendMode);
            Assert.Equal(1f, states.Transform.m00, 5);
            Assert.Null(states.Texture);
            Assert.Null(states.Shader);
        }

        /// <summary>
        ///     Tests that constructor shader only sets null shader and defaults
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Constructor_ShaderOnly_SetsDefaults()
        {
            RenderStates states = new RenderStates((Shader)null);

            Assert.Equal(BlendMode.Alpha, states.BlendMode);
            Assert.Equal(1f, states.Transform.m00, 5);
            Assert.Null(states.Texture);
            Assert.Null(states.Shader);
        }

        /// <summary>
        ///     Tests that constructor full assigns every property
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Constructor_Full_AssignsEveryProperty()
        {
            Transform transform = new Transform(3, 0, 0, 0, 3, 0, 0, 0, 3);
            RenderStates states = new RenderStates(BlendMode.Multiply, transform, null, null);

            Assert.Equal(BlendMode.Multiply, states.BlendMode);
            Assert.Equal(3f, states.Transform.m00, 5);
            Assert.Equal(3f, states.Transform.m11, 5);
            Assert.Null(states.Texture);
            Assert.Null(states.Shader);
        }

        /// <summary>
        ///     Tests that constructor copy copies every property
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Constructor_Copy_CopiesEveryProperty()
        {
            Transform transform = new Transform(4, 0, 0, 0, 4, 0, 0, 0, 4);
            RenderStates original = new RenderStates(BlendMode.None, transform, null, null);
            RenderStates copy = new RenderStates(original);

            Assert.Equal(BlendMode.None, copy.BlendMode);
            Assert.Equal(4f, copy.Transform.m00, 5);
            Assert.Null(copy.Texture);
            Assert.Null(copy.Shader);
        }

        /// <summary>
        ///     Tests that default returns alpha blend mode and identity transform
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Default_ReturnsAlphaBlendModeAndIdentityTransform()
        {
            RenderStates states = RenderStates.Default;

            Assert.Equal(BlendMode.Alpha, states.BlendMode);
            Assert.Equal(1f, states.Transform.m00, 5);
            Assert.Equal(1f, states.Transform.m11, 5);
            Assert.Equal(1f, states.Transform.m22, 5);
            Assert.Null(states.Texture);
            Assert.Null(states.Shader);
        }

        /// <summary>
        ///     Tests that properties can be mutated and read back
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Properties_MutateAndReadBack()
        {
            RenderStates states = RenderStates.Default;
            Transform transform = new Transform(5, 0, 0, 0, 5, 0, 0, 0, 5);

            states.BlendMode = BlendMode.Add;
            states.Transform = transform;

            Assert.Equal(BlendMode.Add, states.BlendMode);
            Assert.Equal(5f, states.Transform.m00, 5);
            Assert.Equal(5f, states.Transform.m11, 5);
        }

        /// <summary>
        ///     Tests that marshal maps managed fields to native data
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Marshal_MapsFieldsToNativeData()
        {
            Transform transform = new Transform(6, 0, 0, 0, 6, 0, 0, 0, 6);
            RenderStates states = new RenderStates(BlendMode.Add, transform, null, null);
            RenderStates.MarshalData data = states.Marshal();

            Assert.Equal(BlendMode.Add, data.blendMode);
            Assert.Equal(6f, data.transform.m00, 5);
            Assert.Equal(6f, data.transform.m11, 5);
            Assert.Equal(IntPtr.Zero, data.texture);
            Assert.Equal(IntPtr.Zero, data.shader);
        }
    }
}
