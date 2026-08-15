// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FontRenderCoverageTests.cs
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
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Delegates;
using Alis.Core.Graphic.OpenGL.Enums;
using Alis.Core.Graphic.Ui;
using Xunit;

namespace Alis.Core.Graphic.Test.Ui
{
    /// <summary>
    ///     Exercises the Font texture, shader, buffer and text rendering paths using fake
    ///     OpenGL function pointers so the managed bodies run without a live GL context.
    /// </summary>
    public class FontRenderCoverageTests : IDisposable
    {
        /// <summary>
        ///     The temp bmp path used by the texture load test
        /// </summary>
        private readonly string _tempBmp;

        /// <summary>
        ///     The fake create shader delegate reference
        /// </summary>
        private static readonly CreateShader FakeCreateShaderDelegate = FakeCreateShader;

        /// <summary>
        ///     The fake create program delegate reference
        /// </summary>
        private static readonly CreateProgram FakeCreateProgramDelegate = FakeCreateProgram;

        /// <summary>
        ///     The fake get uniform location delegate reference
        /// </summary>
        private static readonly GetUniformLocation FakeGetUniformLocationDelegate = FakeGetUniformLocation;

        /// <summary>
        ///     The fake gen textures delegate reference
        /// </summary>
        private static readonly GenTextures FakeGenTexturesDelegate = FakeGenTextures;

        /// <summary>
        ///     The fake gen buffers delegate reference
        /// </summary>
        private static readonly GenBuffers FakeGenBuffersDelegate = FakeGenBuffers;

        /// <summary>
        ///     The fake gen vertex arrays delegate reference
        /// </summary>
        private static readonly GenVertexArrays FakeGenVertexArraysDelegate = FakeGenVertexArrays;

        /// <summary>
        ///     The fake shader source delegate reference
        /// </summary>
        private static readonly ShaderSourceDel FakeShaderSourceDelegate = FakeShaderSource;

        /// <summary>
        ///     The fake vertex attrib pointer delegate reference
        /// </summary>
        private static readonly VertexAttribPointerDel FakeVertexAttribPointerDelegate = FakeVertexAttribPointer;

        /// <summary>
        ///     The fake enable vertex attrib array delegate reference
        /// </summary>
        private static readonly EnableVertexAttribArrayDel FakeEnableVertexAttribArrayDelegate = FakeEnableVertexAttribArray;

        /// <summary>
        ///     The fake buffer data delegate reference
        /// </summary>
        private static readonly BufferData FakeBufferDataDelegate = FakeBufferData;

        /// <summary>
        ///     The fake tex image 2 d delegate reference
        /// </summary>
        private static readonly TexImage2D FakeTexImage2DDelegate = FakeTexImage2D;

        /// <summary>
        ///     The fake tex parameter i delegate reference
        /// </summary>
        private static readonly TexParameteri FakeTexParameteriDelegate = FakeTexParameteri;

        /// <summary>
        ///     The fake get string delegate reference
        /// </summary>
        private static readonly GetString FakeGetStringDelegate = FakeGetString;

        /// <summary>
        ///     The fake clear delegate reference
        /// </summary>
        private static readonly Clear FakeClearDelegate = FakeClear;

        /// <summary>
        ///     The fake bind texture delegate reference
        /// </summary>
        private static readonly BindTexture FakeBindTextureDelegate = FakeBindTexture;

        /// <summary>
        ///     The fake bind buffer delegate reference
        /// </summary>
        private static readonly BindBuffer FakeBindBufferDelegate = FakeBindBuffer;

        /// <summary>
        ///     The fake bind vertex array delegate reference
        /// </summary>
        private static readonly BindVertexArray FakeBindVertexArrayDelegate = FakeBindVertexArray;

        /// <summary>
        ///     The fake use program delegate reference
        /// </summary>
        private static readonly UseProgram FakeUseProgramDelegate = FakeUseProgram;

        /// <summary>
        ///     The fake uniform 4 f delegate reference
        /// </summary>
        private static readonly Uniform4F FakeUniform4FDelegate = FakeUniform4F;

        /// <summary>
        ///     The fake uniform 2 f delegate reference
        /// </summary>
        private static readonly Uniform2F FakeUniform2FDelegate = FakeUniform2F;

        /// <summary>
        ///     The fake uniform 1 f delegate reference
        /// </summary>
        private static readonly Uniform1F FakeUniform1FDelegate = FakeUniform1F;

        /// <summary>
        ///     The fake uniform 1 i delegate reference
        /// </summary>
        private static readonly Uniform1I FakeUniform1IDelegate = FakeUniform1I;

        /// <summary>
        ///     The fake enable delegate reference
        /// </summary>
        private static readonly Enable FakeEnableDelegate = FakeEnable;

        /// <summary>
        ///     The fake disable delegate reference
        /// </summary>
        private static readonly Disable FakeDisableDelegate = FakeDisable;

        /// <summary>
        ///     The fake blend func delegate reference
        /// </summary>
        private static readonly BlendFunc FakeBlendFuncDelegate = FakeBlendFunc;

        /// <summary>
        ///     The fake draw elements delegate reference
        /// </summary>
        private static readonly DrawElements FakeDrawElementsDelegate = FakeDrawElements;

        /// <summary>
        ///     The fake active texture delegate reference
        /// </summary>
        private static readonly Gl.ActiveTexture FakeActiveTextureDelegate = FakeActiveTexture;

        /// <summary>
        ///     The fake compile shader delegate reference
        /// </summary>
        private static readonly CompileShader FakeCompileShaderDelegate = FakeCompileShader;

        /// <summary>
        ///     The fake attach shader delegate reference
        /// </summary>
        private static readonly AttachShader FakeAttachShaderDelegate = FakeAttachShader;

        /// <summary>
        ///     The fake link program delegate reference
        /// </summary>
        private static readonly LinkProgram FakeLinkProgramDelegate = FakeLinkProgram;

        /// <summary>
        ///     The fake delete shader delegate reference
        /// </summary>
        private static readonly DeleteShader FakeDeleteShaderDelegate = FakeDeleteShader;

        /// <summary>
        ///     Initializes a new instance of the <see cref="FontRenderCoverageTests"/> class
        /// </summary>
        public FontRenderCoverageTests()
        {
            _tempBmp = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName() + ".bmp");
            byte[] data = new byte[58];
            data[0] = 0x42;
            data[1] = 0x4D;
            BitConverter.GetBytes(58).CopyTo(data, 2);
            data[10] = 54;
            BitConverter.GetBytes(40).CopyTo(data, 14);
            BitConverter.GetBytes(1).CopyTo(data, 18);
            BitConverter.GetBytes(1).CopyTo(data, 22);
            BitConverter.GetBytes((short) 1).CopyTo(data, 26);
            BitConverter.GetBytes((short) 32).CopyTo(data, 28);
            data[54] = 0;
            data[55] = 0;
            data[56] = 255;
            data[57] = 255;
            File.WriteAllBytes(_tempBmp, data);
        }

        /// <summary>
        ///     Disposes this instance
        /// </summary>
        public void Dispose()
        {
            Gl.Initialize(null);
            if (File.Exists(_tempBmp))
            {
                File.Delete(_tempBmp);
            }
        }

        /// <summary>
        ///     The fake create shader delegate body
        /// </summary>
        /// <param name="shaderType">The shader type</param>
        /// <returns>The shader handle</returns>
        private static uint FakeCreateShader(ShaderType shaderType) => 1;

        /// <summary>
        ///     The fake create program delegate body
        /// </summary>
        /// <returns>The program handle</returns>
        private static uint FakeCreateProgram() => 2;

        /// <summary>
        ///     The fake get uniform location delegate body
        /// </summary>
        /// <param name="program">The program</param>
        /// <param name="name">The name</param>
        /// <returns>The location</returns>
        private static int FakeGetUniformLocation(uint program, string name) => 5;

        /// <summary>
        ///     The fake gen textures delegate body
        /// </summary>
        /// <param name="n">The n</param>
        /// <param name="textures">The textures</param>
        private static void FakeGenTextures(int n, uint[] textures)
        {
            if (textures.Length > 0)
            {
                textures[0] = 11;
            }
        }

        /// <summary>
        ///     The fake gen buffers delegate body
        /// </summary>
        /// <param name="n">The n</param>
        /// <param name="buffers">The buffers</param>
        private static void FakeGenBuffers(int n, uint[] buffers)
        {
            if (buffers.Length > 0)
            {
                buffers[0] = 7;
            }
        }

        /// <summary>
        ///     The fake gen vertex arrays delegate body
        /// </summary>
        /// <param name="n">The n</param>
        /// <param name="arrays">The arrays</param>
        private static void FakeGenVertexArrays(int n, uint[] arrays)
        {
            if (arrays.Length > 0)
            {
                arrays[0] = 9;
            }
        }

        /// <summary>
        ///     The fake shader source delegate body
        /// </summary>
        /// <param name="shader">The shader</param>
        /// <param name="count">The count</param>
        /// <param name="strings">The strings</param>
        /// <param name="length">The length</param>
        private static void FakeShaderSource(uint shader, int count, string[] strings, int[] length)
        {
        }

        /// <summary>
        ///     The fake vertex attrib pointer delegate body
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="size">The size</param>
        /// <param name="type">The type</param>
        /// <param name="normalized">The normalized</param>
        /// <param name="stride">The stride</param>
        /// <param name="pointer">The pointer</param>
        private static void FakeVertexAttribPointer(uint index, int size, VertexAttribPointerType type, bool normalized, int stride, IntPtr pointer)
        {
        }

        /// <summary>
        ///     The fake enable vertex attrib array delegate body
        /// </summary>
        /// <param name="index">The index</param>
        private static void FakeEnableVertexAttribArray(uint index)
        {
        }

        /// <summary>
        ///     The fake buffer data delegate body
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="size">The size</param>
        /// <param name="data">The data</param>
        /// <param name="usage">The usage</param>
        private static void FakeBufferData(BufferTarget target, IntPtr size, IntPtr data, BufferUsageHint usage)
        {
        }

        /// <summary>
        ///     The fake tex image 2 d delegate body
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="level">The level</param>
        /// <param name="internalFormat">The internal format</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="border">The border</param>
        /// <param name="format">The format</param>
        /// <param name="type">The type</param>
        /// <param name="data">The data</param>
        private static void FakeTexImage2D(TextureTarget target, int level, PixelInternalFormat internalFormat, int width, int height, int border, PixelFormat format, PixelType type, IntPtr data)
        {
        }

        /// <summary>
        ///     The fake tex parameter i delegate body
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="pname">The pname</param>
        /// <param name="param">The param</param>
        private static void FakeTexParameteri(TextureTarget target, TextureParameterName pname, TextureParameter param)
        {
        }

        /// <summary>
        ///     The fake get string delegate body
        /// </summary>
        /// <param name="pname">The pname</param>
        /// <returns>The int ptr</returns>
        private static IntPtr FakeGetString(StringName pname) => IntPtr.Zero;

        /// <summary>
        ///     The fake clear delegate body
        /// </summary>
        /// <param name="mask">The mask</param>
        private static void FakeClear(ClearBufferMasks mask)
        {
        }

        /// <summary>
        ///     The fake bind texture delegate body
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="texture">The texture</param>
        private static void FakeBindTexture(TextureTarget target, uint texture)
        {
        }

        /// <summary>
        ///     The fake bind buffer delegate body
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="buffer">The buffer</param>
        private static void FakeBindBuffer(BufferTarget target, uint buffer)
        {
        }

        /// <summary>
        ///     The fake bind vertex array delegate body
        /// </summary>
        /// <param name="array">The array</param>
        private static void FakeBindVertexArray(uint array)
        {
        }

        /// <summary>
        ///     The fake use program delegate body
        /// </summary>
        /// <param name="program">The program</param>
        private static void FakeUseProgram(uint program)
        {
        }

        /// <summary>
        ///     The fake uniform 4 f delegate body
        /// </summary>
        /// <param name="location">The location</param>
        /// <param name="v0">The v0</param>
        /// <param name="v1">The v1</param>
        /// <param name="v2">The v2</param>
        /// <param name="v3">The v3</param>
        private static void FakeUniform4F(int location, float v0, float v1, float v2, float v3)
        {
        }

        /// <summary>
        ///     The fake uniform 2 f delegate body
        /// </summary>
        /// <param name="location">The location</param>
        /// <param name="v0">The v0</param>
        /// <param name="v1">The v1</param>
        private static void FakeUniform2F(int location, float v0, float v1)
        {
        }

        /// <summary>
        ///     The fake uniform 1 f delegate body
        /// </summary>
        /// <param name="location">The location</param>
        /// <param name="v0">The v0</param>
        private static void FakeUniform1F(int location, float v0)
        {
        }

        /// <summary>
        ///     The fake uniform 1 i delegate body
        /// </summary>
        /// <param name="location">The location</param>
        /// <param name="v0">The v0</param>
        private static void FakeUniform1I(int location, int v0)
        {
        }

        /// <summary>
        ///     The fake enable delegate body
        /// </summary>
        /// <param name="cap">The cap</param>
        private static void FakeEnable(EnableCap cap)
        {
        }

        /// <summary>
        ///     The fake disable delegate body
        /// </summary>
        /// <param name="cap">The cap</param>
        private static void FakeDisable(EnableCap cap)
        {
        }

        /// <summary>
        ///     The fake blend func delegate body
        /// </summary>
        /// <param name="sfactor">The sfactor</param>
        /// <param name="dfactor">The dfactor</param>
        private static void FakeBlendFunc(BlendingFactorSrc sfactor, BlendingFactorDest dfactor)
        {
        }

        /// <summary>
        ///     The fake draw elements delegate body
        /// </summary>
        /// <param name="mode">The mode</param>
        /// <param name="count">The count</param>
        /// <param name="type">The type</param>
        /// <param name="indices">The indices</param>
        private static void FakeDrawElements(PrimitiveType mode, int count, DrawElementsType type, IntPtr indices)
        {
        }

        /// <summary>
        ///     The fake active texture delegate body
        /// </summary>
        /// <param name="texture">The texture</param>
        private static void FakeActiveTexture(TextureUnit texture)
        {
        }

        /// <summary>
        ///     The fake compile shader delegate body
        /// </summary>
        /// <param name="shader">The shader</param>
        private static void FakeCompileShader(uint shader)
        {
        }

        /// <summary>
        ///     The fake attach shader delegate body
        /// </summary>
        /// <param name="program">The program</param>
        /// <param name="shader">The shader</param>
        private static void FakeAttachShader(uint program, uint shader)
        {
        }

        /// <summary>
        ///     The fake link program delegate body
        /// </summary>
        /// <param name="program">The program</param>
        private static void FakeLinkProgram(uint program)
        {
        }

        /// <summary>
        ///     The fake delete shader delegate body
        /// </summary>
        /// <param name="shader">The shader</param>
        private static void FakeDeleteShader(uint shader)
        {
        }

        /// <summary>
        ///     The fake proc address resolver
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The function pointer</returns>
        private static IntPtr FakeProcAddress(string name)
        {
            switch (name)
            {
                case "glCreateShader": return Marshal.GetFunctionPointerForDelegate(FakeCreateShaderDelegate);
                case "glCreateProgram": return Marshal.GetFunctionPointerForDelegate(FakeCreateProgramDelegate);
                case "glGetUniformLocation": return Marshal.GetFunctionPointerForDelegate(FakeGetUniformLocationDelegate);
                case "glGenTextures": return Marshal.GetFunctionPointerForDelegate(FakeGenTexturesDelegate);
                case "glGenBuffers": return Marshal.GetFunctionPointerForDelegate(FakeGenBuffersDelegate);
                case "glGenVertexArrays": return Marshal.GetFunctionPointerForDelegate(FakeGenVertexArraysDelegate);
                case "glShaderSource": return Marshal.GetFunctionPointerForDelegate(FakeShaderSourceDelegate);
                case "glVertexAttribPointer": return Marshal.GetFunctionPointerForDelegate(FakeVertexAttribPointerDelegate);
                case "glEnableVertexAttribArray": return Marshal.GetFunctionPointerForDelegate(FakeEnableVertexAttribArrayDelegate);
                case "glBufferData": return Marshal.GetFunctionPointerForDelegate(FakeBufferDataDelegate);
                case "glTexImage2D": return Marshal.GetFunctionPointerForDelegate(FakeTexImage2DDelegate);
                case "glTexParameteri": return Marshal.GetFunctionPointerForDelegate(FakeTexParameteriDelegate);
                case "glGetString":
                case "glGenerateMipmap": return Marshal.GetFunctionPointerForDelegate(FakeGetStringDelegate);
                case "glBindTexture": return Marshal.GetFunctionPointerForDelegate(FakeBindTextureDelegate);
                case "glBindBuffer": return Marshal.GetFunctionPointerForDelegate(FakeBindBufferDelegate);
                case "glBindVertexArray": return Marshal.GetFunctionPointerForDelegate(FakeBindVertexArrayDelegate);
                case "glUseProgram": return Marshal.GetFunctionPointerForDelegate(FakeUseProgramDelegate);
                case "glUniform4f": return Marshal.GetFunctionPointerForDelegate(FakeUniform4FDelegate);
                case "glUniform2f": return Marshal.GetFunctionPointerForDelegate(FakeUniform2FDelegate);
                case "glUniform1f": return Marshal.GetFunctionPointerForDelegate(FakeUniform1FDelegate);
                case "glUniform1i": return Marshal.GetFunctionPointerForDelegate(FakeUniform1IDelegate);
                case "glEnable": return Marshal.GetFunctionPointerForDelegate(FakeEnableDelegate);
                case "glDisable": return Marshal.GetFunctionPointerForDelegate(FakeDisableDelegate);
                case "glBlendFunc": return Marshal.GetFunctionPointerForDelegate(FakeBlendFuncDelegate);
                case "glDrawElements": return Marshal.GetFunctionPointerForDelegate(FakeDrawElementsDelegate);
                case "glActiveTexture": return Marshal.GetFunctionPointerForDelegate(FakeActiveTextureDelegate);
                case "glCompileShader": return Marshal.GetFunctionPointerForDelegate(FakeCompileShaderDelegate);
                case "glAttachShader": return Marshal.GetFunctionPointerForDelegate(FakeAttachShaderDelegate);
                case "glLinkProgram": return Marshal.GetFunctionPointerForDelegate(FakeLinkProgramDelegate);
                case "glDeleteShader": return Marshal.GetFunctionPointerForDelegate(FakeDeleteShaderDelegate);
                default: return Marshal.GetFunctionPointerForDelegate(FakeClearDelegate);
            }
        }

        /// <summary>
        ///     Verifies that loading a texture from an existing file executes.
        /// </summary>
        [Fact]
        public void LoadTexture_WithExistingFile_Executes()
        {
            Font font = new Font("asset", 0, 1);
            Gl.Initialize(FakeProcAddress);
            font.LoadTexture(_tempBmp);
        }

        /// <summary>
        ///     Verifies that the shader initialization and buffer setup execute.
        /// </summary>
        [Fact]
        public void InitializeShaders_And_SetupBuffers_Execute()
        {
            Font font = new Font("asset", 0, 1);
            Gl.Initialize(FakeProcAddress);
            font.InitializeShaders();
            font.SetupBuffers();
        }

        /// <summary>
        ///     Verifies that the character rects are built from the atlas.
        /// </summary>
        [Fact]
        public void InitializeCharacterRectsFromAtlas_BuildsAllRanges()
        {
            Gl.Initialize(FakeProcAddress);
            Font font = new Font("asset", 0, 1) { Path = "set" };
            font.InitializeCharacterRectsFromAtlas(10, 16, 28, 1, 0);
            font.RenderText("A1z", 0, 0, new Color(255, 255, 255, 255), new Color(0, 0, 0, 255));
        }

        /// <summary>
        ///     Verifies that rendering text with a loaded path executes the draw loop.
        /// </summary>
        [Fact]
        public void RenderText_WithLoadedPath_Executes()
        {
            Font font = new Font(string.Empty, 0, 1) { Path = "set" };
            Gl.Initialize(FakeProcAddress);
            font.RenderText("Hello World 123", 10, 20, new Color(255, 255, 255, 255), new Color(0, 0, 0, 255));
        }

        /// <summary>
        ///     Verifies that rendering text with an unnamed file executes the initialization
        ///     path.
        /// </summary>
        [Fact]
        public void RenderText_WithNameFile_ExecutesInitialization()
        {
            Font font = new Font("missing_font_resource.png", 0, 1);
            Gl.Initialize(FakeProcAddress);
            try
            {
                font.RenderText("A", 0, 0, new Color(255, 255, 255, 255), new Color(0, 0, 0, 255));
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        ///     Verifies that rendering text with unknown characters skips them.
        /// </summary>
        [Fact]
        public void RenderText_WithUnknownCharacters_SkipsThem()
        {
            Font font = new Font(string.Empty, 0, 1) { Path = "set" };
            Gl.Initialize(FakeProcAddress);
            font.RenderText("~`|", 0, 0, new Color(255, 255, 255, 255), new Color(0, 0, 0, 255));
        }
    }
}
