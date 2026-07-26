// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RenderStatesTest.cs
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

using Alis.Extension.Graphic.Sfml.Render;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    public class RenderStatesTest
    {
        [Fact]
        public void Constructor_BlendModeOnly_SetsBlendMode()
        {
            BlendMode mode = BlendMode.Add;
            RenderStates states = new RenderStates(mode);

            Assert.Equal(mode, states.BlendMode);
            Assert.Equal(Transform.Identity, states.Transform);
            Assert.Null(states.Texture);
            Assert.Null(states.Shader);
        }

        [Fact]
        public void Constructor_TransformOnly_SetsTransform()
        {
            Transform transform = new Transform(2, 0, 0, 0, 2, 0, 0, 0, 1);
            RenderStates states = new RenderStates(transform);

            Assert.Equal(transform, states.Transform);
            Assert.Equal(BlendMode.Alpha, states.BlendMode);
            Assert.Null(states.Texture);
            Assert.Null(states.Shader);
        }

        [Fact]
        public void Constructor_TextureOnly_SetsTexture()
        {
            RenderStates states = new RenderStates((Texture)null);

            Assert.Equal(BlendMode.Alpha, states.BlendMode);
            Assert.Equal(Transform.Identity, states.Transform);
            Assert.Null(states.Texture);
            Assert.Null(states.Shader);
        }

        [Fact]
        public void Constructor_ShaderOnly_SetsShader()
        {
            RenderStates states = new RenderStates((Shader)null);

            Assert.Equal(BlendMode.Alpha, states.BlendMode);
            Assert.Equal(Transform.Identity, states.Transform);
            Assert.Null(states.Texture);
            Assert.Null(states.Shader);
        }

        [Fact]
        public void Constructor_Full_SetsAllProperties()
        {
            BlendMode mode = BlendMode.Multiply;
            Transform transform = new Transform(1, 2, 3, 4, 5, 6, 7, 8, 9);
            RenderStates states = new RenderStates(mode, transform, null, null);

            Assert.Equal(mode, states.BlendMode);
            Assert.Equal(transform, states.Transform);
            Assert.Null(states.Texture);
            Assert.Null(states.Shader);
        }

        [Fact]
        public void Constructor_Copy_CopiesAllProperties()
        {
            BlendMode mode = BlendMode.None;
            Transform transform = new Transform(0, 1, 2, 3, 4, 5, 6, 7, 8);
            RenderStates original = new RenderStates(mode, transform, null, null);
            RenderStates copy = new RenderStates(original);

            Assert.Equal(original.BlendMode, copy.BlendMode);
            Assert.Equal(original.Transform, copy.Transform);
            Assert.Equal(original.Texture, copy.Texture);
            Assert.Equal(original.Shader, copy.Shader);
        }

        [Fact]
        public void Default_ReturnsExpectedValues()
        {
            RenderStates states = RenderStates.Default;

            Assert.Equal(BlendMode.Alpha, states.BlendMode);
            Assert.Equal(Transform.Identity, states.Transform);
            Assert.Null(states.Texture);
            Assert.Null(states.Shader);
        }

        [Fact]
        public void BlendMode_GetSet_Works()
        {
            RenderStates states = new RenderStates(BlendMode.Alpha);
            BlendMode newMode = BlendMode.Add;
            states.BlendMode = newMode;
            Assert.Equal(newMode, states.BlendMode);
        }

        [Fact]
        public void Transform_GetSet_Works()
        {
            RenderStates states = new RenderStates(Transform.Identity);
            Transform newTransform = new Transform(9, 8, 7, 6, 5, 4, 3, 2, 1);
            states.Transform = newTransform;
            Assert.Equal(newTransform, states.Transform);
        }

        [Fact]
        public void Texture_GetSet_Works()
        {
            RenderStates states = new RenderStates(BlendMode.Alpha, Transform.Identity, null, null);
            states.Texture = null;
            Assert.Null(states.Texture);
        }

        [Fact]
        public void Shader_GetSet_Works()
        {
            RenderStates states = new RenderStates(BlendMode.Alpha, Transform.Identity, null, null);
            states.Shader = null;
            Assert.Null(states.Shader);
        }

        [Fact]
        public void Marshal_WithNullTextureAndShader_SetsIntPtrZero()
        {
            RenderStates states = new RenderStates(BlendMode.Alpha, Transform.Identity, null, null);
            RenderStates.MarshalData data = states.Marshal();

            Assert.Equal(BlendMode.Alpha, data.blendMode);
            Assert.Equal(Transform.Identity, data.transform);
            Assert.Equal(System.IntPtr.Zero, data.texture);
            Assert.Equal(System.IntPtr.Zero, data.shader);
        }

        [Fact]
        public void Marshal_ReturnsExpectedBlendModeAndTransform()
        {
            BlendMode mode = BlendMode.Multiply;
            Transform transform = new Transform(1, 0, 5, 0, 1, 10, 0, 0, 1);
            RenderStates states = new RenderStates(mode, transform, null, null);
            RenderStates.MarshalData data = states.Marshal();

            Assert.Equal(mode, data.blendMode);
            Assert.Equal(transform, data.transform);
        }
    }
}
