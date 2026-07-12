// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FragmentShaderTest.cs
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

using Alis.App.Engine.Shaders;
using Xunit;

namespace Alis.App.Engine.Test
{
    public class FragmentShaderTest
    {
        [Fact]
        public void Constructor_ShouldCreateInstance()
        {
            FragmentShader shader = new FragmentShader();

            Assert.NotNull(shader);
        }

        [Fact]
        public void Struct_ShouldBeReadOnly()
        {
            Assert.True(typeof(FragmentShader).IsValueType);
            Assert.True(typeof(FragmentShader).IsNotPublic == false);
        }

        [Fact]
        public void ShaderCode_ShouldReturnNonEmptyString()
        {
            FragmentShader shader = new FragmentShader();

            Assert.False(string.IsNullOrEmpty(shader.ShaderCode));
        }

        [Fact]
        public void ShaderCode_ShouldContainGLSLVersion()
        {
            FragmentShader shader = new FragmentShader();

            Assert.Contains("#version", shader.ShaderCode);
        }

        [Fact]
        public void Class_ShouldImplementIShader()
        {
            Assert.IsAssignableFrom<IShader>(new FragmentShader());
        }
    }
}
