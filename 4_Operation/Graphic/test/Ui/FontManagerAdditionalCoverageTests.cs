// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FontManagerAdditionalCoverageTests.cs
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
using System.IO.Compression;
using System.Reflection;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Aspect.Memory;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Delegates;
using Alis.Core.Graphic.OpenGL.Enums;
using Alis.Core.Graphic.Ui;
using Xunit;

namespace Alis.Core.Graphic.Test.Ui
{
    /// <summary>
    ///     Executes both <see cref="FontManager" /> render text overloads to completion
    ///     against a registered assets pack and fake OpenGL function pointers, covering
    ///     the full method bodies of the font manager static entry points.
    /// </summary>
    public class FontManagerAdditionalCoverageTests : IDisposable
    {
        /// <summary>
        ///     The previous active assembly
        /// </summary>
        private readonly string _previousActiveAssembly;

        /// <summary>
        ///     The registered assembly name
        /// </summary>
        private readonly string _registeredAssemblyName;

        /// <summary>
        ///     Initializes a new instance of the <see cref="FontManagerAdditionalCoverageTests"/> class
        /// </summary>
        public FontManagerAdditionalCoverageTests()
        {
            _previousActiveAssembly = SaveActiveAssembly();
            _registeredAssemblyName = "FontManagerAdditional_" + Guid.NewGuid().ToString("N");
            byte[] bmpData = CreateMinimalBmp24Bit(2, 2);
            byte[] zipBytes = CreateZipWithEntry("mono.bmp", bmpData);
            AssetRegistry.RegisterAssembly(_registeredAssemblyName, () => new MemoryStream(zipBytes, false));
            SetActiveAssembly(_registeredAssemblyName);
        }

        /// <summary>
        ///     Restores the asset registry and gl state
        /// </summary>
        public void Dispose()
        {
            RestoreActiveAssembly(_previousActiveAssembly);
            Gl.Initialize(null);
        }

        /// <summary>
        ///     Tests that render text with colors completes the full default font pipeline.
        /// </summary>
        [Fact]
        public void RenderText_WithColors_CompletesFullPipeline()
        {
            Gl.Initialize(FakeProcAddress);

            FontManager.RenderText("A", 0, 0, new Color(255, 255, 255, 255), new Color(0, 0, 0, 255));
        }

        /// <summary>
        ///     Tests that render text with default colors completes the full default font pipeline.
        /// </summary>
        [Fact]
        public void RenderText_WithDefaultColors_CompletesFullPipeline()
        {
            Gl.Initialize(FakeProcAddress);

            FontManager.RenderText("A", 0, 0);
        }

        /// <summary>
        ///     Tests that render text with colors forwards the expected colors to the default font.
        /// </summary>
        [Fact]
        public void RenderText_WithColors_ForwardsColorsToDefaultFont()
        {
            Gl.Initialize(FakeProcAddress);

            FontManager.RenderText("A", 0, 0, Color.White, Color.Transparent);
        }

        /// <summary>
        ///     Tests that render text with colors completes for an empty text.
        /// </summary>
        [Fact]
        public void RenderText_WithColors_CompletesForEmptyText()
        {
            Gl.Initialize(FakeProcAddress);

            FontManager.RenderText(string.Empty, 0, 0, new Color(255, 255, 255, 255), new Color(0, 0, 0, 255));
        }

        /// <summary>
        ///     Tests that render text with default colors completes for an empty text.
        /// </summary>
        [Fact]
        public void RenderText_WithDefaultColors_CompletesForEmptyText()
        {
            Gl.Initialize(FakeProcAddress);

            FontManager.RenderText(string.Empty, 0, 0);
        }

        /// <summary>
        ///     Tests that render text with default colors completes for a full sentence.
        /// </summary>
        [Fact]
        public void RenderText_WithDefaultColors_CompletesForFullSentence()
        {
            Gl.Initialize(FakeProcAddress);

            FontManager.RenderText("hello world", 10, 20);
        }

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
                case "glCompileShader": return Marshal.GetFunctionPointerForDelegate(FakeCompileShaderDelegate);
                case "glAttachShader": return Marshal.GetFunctionPointerForDelegate(FakeAttachShaderDelegate);
                case "glLinkProgram": return Marshal.GetFunctionPointerForDelegate(FakeLinkProgramDelegate);
                case "glDeleteShader": return Marshal.GetFunctionPointerForDelegate(FakeDeleteShaderDelegate);
                default: return Marshal.GetFunctionPointerForDelegate(FakeClearDelegate);
            }
        }

        /// <summary>
        ///     Saves the current active assembly
        /// </summary>
        /// <returns>The assembly name</returns>
        private static string SaveActiveAssembly()
        {
            FieldInfo activeField = typeof(AssetRegistry).GetField("<ActiveAssemblyName>k__BackingField", BindingFlags.NonPublic | BindingFlags.Static);
            return (string) activeField?.GetValue(null);
        }

        /// <summary>
        ///     Sets the active assembly
        /// </summary>
        /// <param name="name">The name</param>
        private static void SetActiveAssembly(string name)
        {
            FieldInfo activeField = typeof(AssetRegistry).GetField("<ActiveAssemblyName>k__BackingField", BindingFlags.NonPublic | BindingFlags.Static);
            activeField?.SetValue(null, name);
        }

        /// <summary>
        ///     Restores the active assembly
        /// </summary>
        /// <param name="previous">The previous</param>
        private static void RestoreActiveAssembly(string previous)
        {
            FieldInfo activeField = typeof(AssetRegistry).GetField("<ActiveAssemblyName>k__BackingField", BindingFlags.NonPublic | BindingFlags.Static);
            activeField?.SetValue(null, previous);
        }

        /// <summary>
        ///     Creates a zip in memory with a single entry
        /// </summary>
        /// <param name="entryName">The entry name</param>
        /// <param name="content">The content</param>
        /// <returns>The zip bytes</returns>
        private static byte[] CreateZipWithEntry(string entryName, byte[] content)
        {
            using MemoryStream zipMs = new MemoryStream();
            using (ZipArchive archive = new ZipArchive(zipMs, ZipArchiveMode.Create, true))
            {
                ZipArchiveEntry entry = archive.CreateEntry(entryName, CompressionLevel.Optimal);
                using Stream entryStream = entry.Open();
                entryStream.Write(content, 0, content.Length);
            }
            return zipMs.ToArray();
        }

        /// <summary>
        ///     Creates a minimal valid 24 bit bmp
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <returns>The bmp bytes</returns>
        private static byte[] CreateMinimalBmp24Bit(int width, int height)
        {
            int rowSize = (width * 3 + 3) / 4 * 4;
            int imageSize = rowSize * height;
            int fileSize = 54 + imageSize;
            byte[] bmp = new byte[fileSize];
            bmp[0] = (byte) 'B';
            bmp[1] = (byte) 'M';
            WriteLittleEndian(bmp, 2, (uint) fileSize);
            WriteLittleEndian(bmp, 6, 0);
            WriteLittleEndian(bmp, 10, 54);
            WriteLittleEndian(bmp, 14, 40);
            WriteLittleEndian(bmp, 18, (uint) width);
            WriteLittleEndian(bmp, 22, (uint) height);
            WriteLittleEndian(bmp, 26, (ushort) 1);
            WriteLittleEndian(bmp, 28, (ushort) 24);
            WriteLittleEndian(bmp, 32, 0);
            WriteLittleEndian(bmp, 36, (uint) imageSize);
            WriteLittleEndian(bmp, 40, 2835);
            WriteLittleEndian(bmp, 44, 2835);
            WriteLittleEndian(bmp, 48, 0);
            WriteLittleEndian(bmp, 52, 0);
            int pixelOffset = 54;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    bmp[pixelOffset++] = 255;
                    bmp[pixelOffset++] = 128;
                    bmp[pixelOffset++] = 64;
                }
                while ((pixelOffset % 4 != 0) && (pixelOffset < 54 + rowSize * (y + 1)))
                {
                    bmp[pixelOffset++] = 0;
                }
            }
            return bmp;
        }

        /// <summary>
        ///     Writes a little endian value into the buffer
        /// </summary>
        /// <param name="buffer">The buffer</param>
        /// <param name="offset">The offset</param>
        /// <param name="value">The value</param>
        private static void WriteLittleEndian(byte[] buffer, int offset, uint value)
        {
            buffer[offset] = (byte) (value & 0xFF);
            buffer[offset + 1] = (byte) ((value >> 8) & 0xFF);
            buffer[offset + 2] = (byte) ((value >> 16) & 0xFF);
            buffer[offset + 3] = (byte) ((value >> 24) & 0xFF);
        }

        /// <summary>
        ///     Writes a little endian ushort value into the buffer
        /// </summary>
        /// <param name="buffer">The buffer</param>
        /// <param name="offset">The offset</param>
        /// <param name="value">The value</param>
        private static void WriteLittleEndian(byte[] buffer, int offset, ushort value)
        {
            buffer[offset] = (byte) (value & 0xFF);
            buffer[offset + 1] = (byte) ((value >> 8) & 0xFF);
        }
    }
}
