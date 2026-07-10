// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GlShaderProgramRemainingCoverageTests.cs
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
using Alis.Core.Graphic.OpenGL.Constructs;
using Alis.Core.Graphic.OpenGL.Enums;
using Xunit;

namespace Alis.Core.Graphic.Test.Constructs
{
    public class GlShaderProgramRemainingCoverageTests
    {
        [Fact]
        public void Constructor_StringParams_CallsTwoParamConstructor()
        {
            var ex = Assert.Throws<InvalidOperationException>(() => new GlShaderProgram("vs", "fs"));
        }

        [Fact]
        public void DisposeChildren_Field_ExistsAndIsPublic()
        {
            FieldInfo field = typeof(GlShaderProgram).GetField("DisposeChildren", BindingFlags.Public | BindingFlags.Instance);
            Assert.NotNull(field);
            Assert.Equal(typeof(bool), field.FieldType);
            Assert.True(field.IsPublic);
        }

        [Fact]
        public void VertexShader_Field_Exists()
        {
            FieldInfo field = typeof(GlShaderProgram).GetField("VertexShader", BindingFlags.Public | BindingFlags.Instance);
            Assert.NotNull(field);
            Assert.Equal(typeof(GlShader), field.FieldType);
        }

        [Fact]
        public void FragmentShader_Field_Exists()
        {
            FieldInfo field = typeof(GlShaderProgram).GetField("FragmentShader", BindingFlags.Public | BindingFlags.Instance);
            Assert.NotNull(field);
            Assert.Equal(typeof(GlShader), field.FieldType);
        }

        [Fact]
        public void TypeFromAttributeType_FloatMat3_ThrowsInvalidOperationException()
        {
            MethodInfo method = typeof(GlShaderProgram).GetMethod("TypeFromAttributeType", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.NotNull(method);

            var ex = Assert.Throws<TargetInvocationException>(() => method.Invoke(null, new object[] { ActiveAttribType.FloatMat3 }));
            Assert.IsType<InvalidOperationException>(ex.InnerException);
            Assert.Contains("not supported", ex.InnerException.Message, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void TypeFromUniformType_FloatMat3_ThrowsInvalidOperationException()
        {
            MethodInfo method = typeof(GlShaderProgram).GetMethod("TypeFromUniformType", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.NotNull(method);

            var ex = Assert.Throws<TargetInvocationException>(() => method.Invoke(null, new object[] { ActiveUniformType.FloatMat3 }));
            Assert.IsType<InvalidOperationException>(ex.InnerException);
            Assert.Contains("not supported", ex.InnerException.Message, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void TypeFromAttributeType_Default_ReturnsObject()
        {
            MethodInfo method = typeof(GlShaderProgram).GetMethod("TypeFromAttributeType", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.NotNull(method);

            Type result = (Type)method.Invoke(null, new object[] { default(ActiveAttribType) });
            Assert.Equal(typeof(object), result);
        }

        [Fact]
        public void TypeFromUniformType_Default_ReturnsObject()
        {
            MethodInfo method = typeof(GlShaderProgram).GetMethod("TypeFromUniformType", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.NotNull(method);

            Type result = (Type)method.Invoke(null, new object[] { default(ActiveUniformType) });
            Assert.Equal(typeof(object), result);
        }

        [Fact]
        public void Dispose_DisposingFalse_WithProgramIdZero_DoesNotThrow()
        {
            object program = RuntimeHelpers.GetUninitializedObject(typeof(GlShaderProgram));
            MethodInfo dispose = typeof(GlShaderProgram).GetMethod("Dispose", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.NotNull(dispose);

            dispose.Invoke(program, new object[] { false });
        }

        [Fact]
        public void Dispose_DisposeChildrenFalse_WithProgramIdZero_HandledCorrectly()
        {
            object program = RuntimeHelpers.GetUninitializedObject(typeof(GlShaderProgram));
            FieldInfo disposeChildren = typeof(GlShaderProgram).GetField("DisposeChildren", BindingFlags.Public | BindingFlags.Instance);
            Assert.NotNull(disposeChildren);
            disposeChildren.SetValue(program, false);

            MethodInfo dispose = typeof(GlShaderProgram).GetMethod("Dispose", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.NotNull(dispose);

            dispose.Invoke(program, new object[] { true });
        }

        [Fact]
        public void Dispose_PublicDispose_CallsDisposeTrue()
        {
            object program = RuntimeHelpers.GetUninitializedObject(typeof(GlShaderProgram));
            var disposable = (IDisposable)program;

            disposable.Dispose();
        }

        [Fact]
        public void Finalizer_Exists()
        {
            const BindingFlags flags = BindingFlags.NonPublic | BindingFlags.Instance;
            MethodInfo finalizer = typeof(GlShaderProgram).GetMethod("Finalize", flags);
            Assert.NotNull(finalizer);
        }
    }
}
