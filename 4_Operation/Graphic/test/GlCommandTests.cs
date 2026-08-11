// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GlCommandTests.cs
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
using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Enums;
using Xunit;

namespace Alis.Core.Graphic.Test
{
    /// <summary>
    ///     The gl command tests class
    /// </summary>
    public class GlCommandTests
    {
        /// <summary>
        ///     Tests that command properties throw invalid operation exception when gl is not initialized
        /// </summary>
        [Fact]
        public void CommandProperties_ThrowInvalidOperationException_WhenNotInitialized()
        {
            Gl.Initialize(null);

            Assert.Throws<InvalidOperationException>(() => Gl.GetString);
            Assert.Throws<InvalidOperationException>(() => Gl.GlGenBuffers);
            Assert.Throws<InvalidOperationException>(() => Gl.GlDeleteBuffers);
            Assert.Throws<InvalidOperationException>(() => Gl.GlGetIntegerV);
            Assert.Throws<InvalidOperationException>(() => Gl.GlViewport);
            Assert.Throws<InvalidOperationException>(() => Gl.GlClearColor);
            Assert.Throws<InvalidOperationException>(() => Gl.GlColor4F);
            Assert.Throws<InvalidOperationException>(() => Gl.GlEnd);
            Assert.Throws<InvalidOperationException>(() => Gl.GlClear);
            Assert.Throws<InvalidOperationException>(() => Gl.GlEnable);
            Assert.Throws<InvalidOperationException>(() => Gl.GlDisable);
            Assert.Throws<InvalidOperationException>(() => Gl.GlBlendEquation);
            Assert.Throws<InvalidOperationException>(() => Gl.GlBlendFunc);
            Assert.Throws<InvalidOperationException>(() => Gl.GlUseProgram);
            Assert.Throws<InvalidOperationException>(() => Gl.GlGetShaderIv);
            Assert.Throws<InvalidOperationException>(() => Gl.GlGetShaderInfoLog);
            Assert.Throws<InvalidOperationException>(() => Gl.GlCreateShader);
            Assert.Throws<InvalidOperationException>(() => Gl.GlBegin);
            Assert.Throws<InvalidOperationException>(() => Gl.GlShaderSource);
            Assert.Throws<InvalidOperationException>(() => Gl.GlCompileShader);
            Assert.Throws<InvalidOperationException>(() => Gl.GlDeleteShader);
            Assert.Throws<InvalidOperationException>(() => Gl.GlGetProgramiv);
            Assert.Throws<InvalidOperationException>(() => Gl.GlGetProgramInfoLog);
            Assert.Throws<InvalidOperationException>(() => Gl.GlCreateProgram);
            Assert.Throws<InvalidOperationException>(() => Gl.GlAttachShader);
            Assert.Throws<InvalidOperationException>(() => Gl.GlLinkProgram);
            Assert.Throws<InvalidOperationException>(() => Gl.GlGetUniformLocation);
            Assert.Throws<InvalidOperationException>(() => Gl.GlGetAttribLocation);
            Assert.Throws<InvalidOperationException>(() => Gl.GlDetachShader);
            Assert.Throws<InvalidOperationException>(() => Gl.GlDeleteProgram);
            Assert.Throws<InvalidOperationException>(() => Gl.GlUniform1F);
            Assert.Throws<InvalidOperationException>(() => Gl.GlUniform2F);
            Assert.Throws<InvalidOperationException>(() => Gl.GlUniform3F);
            Assert.Throws<InvalidOperationException>(() => Gl.GlUniform4F);
            Assert.Throws<InvalidOperationException>(() => Gl.GlUniform1I);
            Assert.Throws<InvalidOperationException>(() => Gl.GlReadPixels);
            Assert.Throws<InvalidOperationException>(() => Gl.GlGenFramebuffer);
            Assert.Throws<InvalidOperationException>(() => Gl.GlFramebufferTexture2D);
            Assert.Throws<InvalidOperationException>(() => Gl.GlUniformMatrix3Fv);
            Assert.Throws<InvalidOperationException>(() => Gl.GlUniformMatrix4Fv);
            Assert.Throws<InvalidOperationException>(() => Gl.GlBindSampler);
            Assert.Throws<InvalidOperationException>(() => Gl.GlBindVertexArray);
            Assert.Throws<InvalidOperationException>(() => Gl.GlBindBuffer);
            Assert.Throws<InvalidOperationException>(() => Gl.GlVertex2F);
            Assert.Throws<InvalidOperationException>(() => Gl.GlTexCoord2F);
            Assert.Throws<InvalidOperationException>(() => Gl.GlEnableVertexAttribArray);
            Assert.Throws<InvalidOperationException>(() => Gl.GlDisableVertexAttribArray);
            Assert.Throws<InvalidOperationException>(() => Gl.GlVertexAttribPointer);
            Assert.Throws<InvalidOperationException>(() => Gl.GlBindFramebuffer);
            Assert.Throws<InvalidOperationException>(() => Gl.GlBindTexture);
            Assert.Throws<InvalidOperationException>(() => Gl.GlBufferData);
            Assert.Throws<InvalidOperationException>(() => Gl.GlScissor);
            Assert.Throws<InvalidOperationException>(() => Gl.GlDrawElementsBaseVertex);
            Assert.Throws<InvalidOperationException>(() => Gl.GlDeleteVertexArrays);
            Assert.Throws<InvalidOperationException>(() => Gl.GlGenVertexArrays);
            Assert.Throws<InvalidOperationException>(() => Gl.GlGenTextures);
            Assert.Throws<InvalidOperationException>(() => Gl.GlPixelStorei);
            Assert.Throws<InvalidOperationException>(() => Gl.GlTexImage2D);
            Assert.Throws<InvalidOperationException>(() => Gl.GlTexParameteri);
            Assert.Throws<InvalidOperationException>(() => Gl.GlDeleteTextures);
            Assert.Throws<InvalidOperationException>(() => Gl.GlDrawArrays);
            Assert.Throws<InvalidOperationException>(() => Gl.GlDrawElements);
            Assert.Throws<InvalidOperationException>(() => Gl.GlPolygonMode);
            Assert.Throws<InvalidOperationException>(() => Gl.GlLineWidthDelegate);
            Assert.Throws<InvalidOperationException>(() => Gl.GlActiveTextureDelegate);
        }

        /// <summary>
        ///     Tests that wrapper methods throw invalid operation exception when gl is not initialized
        /// </summary>
        [Fact]
        public void WrapperMethods_ThrowInvalidOperationException_WhenNotInitialized()
        {
            Gl.Initialize(null);

            Assert.Throws<InvalidOperationException>(() => Gl.GlGetString(StringName.Renderer));
            Assert.Throws<InvalidOperationException>(() => Gl.GenBuffer());
            Assert.Throws<InvalidOperationException>(() => Gl.DeleteBuffer(1));
            Assert.Throws<InvalidOperationException>(() => Gl.GetShaderInfoLog(1));
            Assert.Throws<InvalidOperationException>(() => Gl.ShaderSource(1, "void main() {}"));
            Assert.Throws<InvalidOperationException>(() => Gl.GetShaderCompileStatus(1));
            Assert.Throws<InvalidOperationException>(() => Gl.GetProgramInfoLog(1));
            Assert.Throws<InvalidOperationException>(() => Gl.GetProgramLinkStatus(1));
            Assert.Throws<InvalidOperationException>(() => Gl.UniformMatrix4Fv(0, new Matrix4X4()));
            Assert.Throws<InvalidOperationException>(() => Gl.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, IntPtr.Zero));
            Assert.Throws<InvalidOperationException>(() => Gl.EnableVertexAttribArray(0));
            Assert.Throws<InvalidOperationException>(() => Gl.GenVertexArray());
            Assert.Throws<InvalidOperationException>(() => Gl.DeleteVertexArray(1));
            Assert.Throws<InvalidOperationException>(() => Gl.GenTexture());
            Assert.Throws<InvalidOperationException>(() => Gl.DeleteTexture(1));
            Assert.Throws<InvalidOperationException>(() => Gl.GenerateMipmap(TextureTarget.Texture2D));
            Assert.Throws<InvalidOperationException>(() => Gl.GlGetError());
            Assert.Throws<InvalidOperationException>(() => Gl.GlLineWidth(1f));
            Assert.Throws<InvalidOperationException>(() => Gl.GlActiveTexture(TextureUnit.Texture0));
            Assert.Throws<InvalidOperationException>(() => Gl.GlGetIntegerv(0, new int[4]));
            Assert.Throws<InvalidOperationException>(() => Gl.GlGetShader(1, ShaderParameter.CompileStatus, out _));
            Assert.Throws<InvalidOperationException>(() => Gl.GlGetProgram(1, ProgramParameter.LinkStatus, out _));
            Assert.Throws<InvalidOperationException>(() => Gl.GlUniformMatrix2x3(0, false, new float[6]));
        }

        /// <summary>
        ///     Tests that commands throw external exception when gl resolves to a zero pointer
        /// </summary>
        [Fact]
        public void Commands_ThrowExternalException_WhenPointerIsZero()
        {
            Gl.Initialize(_ => IntPtr.Zero);

            Assert.Throws<ExternalException>(() => Gl.GlClear);
            Assert.Throws<ExternalException>(() => Gl.GlGetString(StringName.Renderer));
            Assert.Throws<ExternalException>(() => Gl.GenBuffer());
            Assert.Throws<ExternalException>(() => Gl.GetShaderInfoLog(1));
            Assert.Throws<ExternalException>(() => Gl.UniformMatrix4Fv(0, new Matrix4X4()));
            Assert.Throws<ExternalException>(() => Gl.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, IntPtr.Zero));
            Assert.Throws<ExternalException>(() => Gl.EnableVertexAttribArray(0));
            Assert.Throws<ExternalException>(() => Gl.GenVertexArray());
            Assert.Throws<ExternalException>(() => Gl.GlGetError());
            Assert.Throws<ExternalException>(() => Gl.GlLineWidth(1f));
            Assert.Throws<ExternalException>(() => Gl.GlActiveTexture(TextureUnit.Texture0));
            Assert.Throws<ExternalException>(() => Gl.GlGetIntegerv(0, new int[4]));
            Assert.Throws<ExternalException>(() => Gl.GlUniformMatrix2x3(0, false, new float[6]));

            Gl.Initialize(null);
        }
    }
}
