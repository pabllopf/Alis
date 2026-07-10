// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GlShaderProgramParamRemainingCoverageTests2.cs
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
using System.Reflection;
using System.Runtime.CompilerServices;
using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Constructs;
using Xunit;

namespace Alis.Core.Graphic.Test.Constructs
{
    public class GlShaderProgramParamRemainingCoverageTests2
    {
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void SetValue_Bool_ThrowsWhenGlNotInitialized(bool value)
        {
            var param = new GlShaderProgramParam(typeof(bool), ParamType.Uniform, "test");
            param.Location = 0;

            Assert.ThrowsAny<Exception>(() => param.SetValue(value));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(42)]
        [InlineData(-1)]
        [InlineData(int.MaxValue)]
        public void SetValue_Int_ThrowsWhenGlNotInitialized(int value)
        {
            var param = new GlShaderProgramParam(typeof(int), ParamType.Uniform, "test");
            param.Location = 0;

            Assert.ThrowsAny<Exception>(() => param.SetValue(value));
        }

        [Theory]
        [InlineData(0.0f)]
        [InlineData(3.14f)]
        [InlineData(-1.0f)]
        [InlineData(float.MaxValue)]
        public void SetValue_Float_ThrowsWhenGlNotInitialized(float value)
        {
            var param = new GlShaderProgramParam(typeof(float), ParamType.Uniform, "test");
            param.Location = 0;

            Assert.ThrowsAny<Exception>(() => param.SetValue(value));
        }

        [Theory]
        [InlineData(16)]
        [InlineData(9)]
        [InlineData(4)]
        [InlineData(3)]
        [InlineData(2)]
        [InlineData(1)]
        public void SetValue_FloatArray_ThrowsWhenGlNotInitialized(int length)
        {
            Type expectedType = length switch
            {
                16 => typeof(Matrix4X4),
                9 => typeof(Exception),
                4 => typeof(Vector4F),
                3 => typeof(Vector3F),
                2 => typeof(Vector2F),
                1 => typeof(float),
                _ => typeof(object)
            };

            var param = new GlShaderProgramParam(expectedType, ParamType.Uniform, "arr");
            param.Location = 0;
            var array = new float[length];

            Assert.ThrowsAny<Exception>(() => param.SetValue(array));
        }

        [Fact]
        public void SetValue_Vector2F_ThrowsWhenGlNotInitialized()
        {
            var param = new GlShaderProgramParam(typeof(Vector2F), ParamType.Uniform, "v2");
            param.Location = 0;

            Assert.ThrowsAny<Exception>(() => param.SetValue(new Vector2F()));
        }

        [Fact]
        public void SetValue_Vector3F_ThrowsWhenGlNotInitialized()
        {
            var param = new GlShaderProgramParam(typeof(Vector3F), ParamType.Uniform, "v3");
            param.Location = 0;

            Assert.ThrowsAny<Exception>(() => param.SetValue(new Vector3F()));
        }

        [Fact]
        public void SetValue_Vector4F_ThrowsWhenGlNotInitialized()
        {
            var param = new GlShaderProgramParam(typeof(Vector4F), ParamType.Uniform, "v4");
            param.Location = 0;

            Assert.ThrowsAny<Exception>(() => param.SetValue(new Vector4F()));
        }

        [Fact]
        public void SetValue_Matrix4X4_ThrowsWhenGlNotInitialized()
        {
            var param = new GlShaderProgramParam(typeof(Matrix4X4), ParamType.Uniform, "m4");
            param.Location = 0;

            Assert.ThrowsAny<Exception>(() => param.SetValue(new Matrix4X4()));
        }

        [Fact]
        public void GetLocation_ThrowsWhenGlNotInitialized()
        {
            var param = new GlShaderProgramParam(typeof(int), ParamType.Uniform, "test");
            object program = RuntimeHelpers.GetUninitializedObject(typeof(GlShaderProgram));

            Assert.ThrowsAny<Exception>(() => param.GetLocation((GlShaderProgram)program));
        }

        [Fact]
        public void Program_DefaultIsZero()
        {
            var param = new GlShaderProgramParam(typeof(int), ParamType.Uniform, "test");
            Assert.Equal(0u, param.Program);
        }

        [Fact]
        public void Program_GetSet_Works()
        {
            var param = new GlShaderProgramParam(typeof(int), ParamType.Uniform, "test");
            param.Program = 42u;
            Assert.Equal(42u, param.Program);
            param.Program = 0u;
            Assert.Equal(0u, param.Program);
        }

        [Fact]
        public void ProgramId_DefaultIsZero()
        {
            var param = new GlShaderProgramParam(typeof(int), ParamType.Uniform, "test");
            Assert.Equal(0u, param.ProgramId);
        }

        [Fact]
        public void ProgramId_GetSet_Works()
        {
            var param = new GlShaderProgramParam(typeof(int), ParamType.Uniform, "test");
            param.ProgramId = 123u;
            Assert.Equal(123u, param.ProgramId);
        }

        [Fact]
        public void Location_DefaultIsZero()
        {
            var param = new GlShaderProgramParam(typeof(int), ParamType.Uniform, "test");
            Assert.Equal(0, param.Location);
        }
    }
}
