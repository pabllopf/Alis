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
    /// <summary>
    ///     Tests the <see cref="RenderStates" /> struct.
    /// </summary>
    public class RenderStatesTest
    {
        [Fact]
        public void DefaultConstructor_SetsDefaults()
        {
            RenderStates state = default;
            Assert.Equal(default, state.BlendMode);
            Assert.Equal(default, state.Transform);
            Assert.Null(state.Texture);
            Assert.Null(state.Shader);
        }

        [Fact]
        public void Constructor_BlendMode_SetsBlendMode()
        {
            RenderStates state = new RenderStates(BlendMode.Add);
            Assert.Equal(BlendMode.Add, state.BlendMode);
            Assert.Equal(Transform.Identity, state.Transform);
            Assert.Null(state.Texture);
            Assert.Null(state.Shader);
        }

        [Fact]
        public void Constructor_Transform_SetsTransform()
        {
            Transform t = new Transform(2, 0, 0, 0, 2, 0, 0, 0, 1);
            RenderStates state = new RenderStates(t);
            Assert.Equal(BlendMode.Alpha, state.BlendMode);
            Assert.Equal(t, state.Transform);
            Assert.Null(state.Texture);
            Assert.Null(state.Shader);
        }

        [Fact]
        public void Constructor_Texture_SetsTextureNull()
        {
            RenderStates state = new RenderStates((Texture) null);
            Assert.Equal(BlendMode.Alpha, state.BlendMode);
            Assert.Equal(Transform.Identity, state.Transform);
            Assert.Null(state.Texture);
            Assert.Null(state.Shader);
        }

        [Fact]
        public void Constructor_Shader_SetsShaderNull()
        {
            RenderStates state = new RenderStates((Shader) null);
            Assert.Equal(BlendMode.Alpha, state.BlendMode);
            Assert.Equal(Transform.Identity, state.Transform);
            Assert.Null(state.Texture);
            Assert.Null(state.Shader);
        }

        [Fact]
        public void Constructor_Full_SetsAllFields()
        {
            RenderStates state = new RenderStates(BlendMode.Multiply, Transform.Identity, null, null);
            Assert.Equal(BlendMode.Multiply, state.BlendMode);
            Assert.Equal(Transform.Identity, state.Transform);
            Assert.Null(state.Texture);
            Assert.Null(state.Shader);
        }

        [Fact]
        public void CopyConstructor_CopiesAllFields()
        {
            RenderStates original = new RenderStates(BlendMode.Multiply);
            RenderStates copy = new RenderStates(original);
            Assert.Equal(original.BlendMode, copy.BlendMode);
            Assert.Equal(original.Transform, copy.Transform);
            Assert.Null(copy.Texture);
            Assert.Null(copy.Shader);
        }

        [Fact]
        public void Default_Property_ReturnsAlphaIdentity()
        {
            RenderStates state = RenderStates.Default;
            Assert.Equal(BlendMode.Alpha, state.BlendMode);
            Assert.Equal(Transform.Identity, state.Transform);
            Assert.Null(state.Texture);
            Assert.Null(state.Shader);
        }

        [Fact]
        public void Properties_AreSettable()
        {
            RenderStates state = default;
            state.BlendMode = BlendMode.None;
            state.Transform = new Transform(1, 0, 0, 0, 1, 0, 0, 0, 1);
            Assert.Equal(BlendMode.None, state.BlendMode);
            Assert.Equal(new Transform(1, 0, 0, 0, 1, 0, 0, 0, 1), state.Transform);
        }

        [Fact]
        public void BlendMode_PropertyRoundtrips()
        {
            RenderStates state = default;
            state.BlendMode = BlendMode.Add;
            Assert.Equal(BlendMode.Add, state.BlendMode);
        }
    }
}
