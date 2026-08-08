using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Delegates;
using Alis.Core.Graphic.OpenGL.Enums;
using Xunit;

namespace Alis.Core.Graphic.Test
{
    /// <summary>
    /// The gl cov tests class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    public class GlCovTests : IDisposable
    {
        /// <summary>
        /// The static
        /// </summary>
        private static readonly FieldInfo Field = typeof(Gl).GetField("_getProcAddress", BindingFlags.NonPublic | BindingFlags.Static);
        /// <summary>
        /// The saved
        /// </summary>
        private readonly object _saved;

        /// <summary>
        /// Initializes a new instance of the <see cref="GlCovTests"/> class
        /// </summary>
        public GlCovTests() => _saved = Field?.GetValue(null);
        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose() => Field?.SetValue(null, _saved);

        /// <summary>
        /// Inits the resolver
        /// </summary>
        /// <param name="resolver">The resolver</param>
        private void Init(Gl.GetProcAddressDelegate resolver) => Gl.Initialize(resolver);

        /// <summary>
        /// Tests that gen buffer returns value from mock
        /// </summary>
        [Fact]
        public void GenBuffer_ReturnsValueFromMock()
        {
            GenBuffers mock = (int n, uint[] buffers) => buffers[0] = 42;
            IntPtr fp = Marshal.GetFunctionPointerForDelegate(mock);
            Init(name => name == "glGenBuffers" ? fp : IntPtr.Zero);
            Assert.Equal(42u, Gl.GenBuffer());
        }

        /// <summary>
        /// Tests that delete buffer calls mock
        /// </summary>
        [Fact]
        public void DeleteBuffer_CallsMock()
        {
            bool called = false;
            DeleteBuffers mock = (int n, uint[] buffers) => called = true;
            IntPtr fp = Marshal.GetFunctionPointerForDelegate(mock);
            Init(name => name == "glDeleteBuffers" ? fp : IntPtr.Zero);
            Gl.DeleteBuffer(7);
            Assert.True(called);
        }

        /// <summary>
        /// Tests that get shader info log returns empty when length zero
        /// </summary>
        [Fact]
        public void GetShaderInfoLog_ReturnsEmpty_WhenLengthZero()
        {
            GetShaderiv ivMock = (uint shader, ShaderParameter pname, int[] p) => p[0] = 0;
            IntPtr ivFp = Marshal.GetFunctionPointerForDelegate(ivMock);
            Init(name => name == "glGetShaderiv" ? ivFp : IntPtr.Zero);
            string result = Gl.GetShaderInfoLog(1);
            Assert.Equal(string.Empty, result);
        }

        /// <summary>
        /// Tests that get shader info log returns string when length non zero
        /// </summary>
        [Fact]
        public void GetShaderInfoLog_ReturnsString_WhenLengthNonZero()
        {
            GetShaderiv ivMock = (uint shader, ShaderParameter pname, int[] p) => p[0] = 4;
            IntPtr ivFp = Marshal.GetFunctionPointerForDelegate(ivMock);

            GetShaderInfoLogDel logMock = (uint shader, int maxLen, int[] len, StringBuilder sb) => sb.Append("test");
            IntPtr logFp = Marshal.GetFunctionPointerForDelegate(logMock);

            Init(name => name switch
            {
                "glGetShaderiv" => ivFp,
                "glGetShaderInfoLog" => logFp,
                _ => IntPtr.Zero
            });

            Assert.Equal("test", Gl.GetShaderInfoLog(1));
        }

        /// <summary>
        /// Tests that shader source calls mock
        /// </summary>
        [Fact]
        public void ShaderSource_CallsMock()
        {
            string capturedSource = null;
            ShaderSourceDel mock = (uint shader, int count, string[] src, int[] len) => capturedSource = src[0];
            IntPtr fp = Marshal.GetFunctionPointerForDelegate(mock);
            Init(name => name == "glShaderSource" ? fp : IntPtr.Zero);
            Gl.ShaderSource(1, "hello");
            Assert.Equal("hello", capturedSource);
        }

        /// <summary>
        /// Tests that get shader compile status returns true when compiled
        /// </summary>
        [Fact]
        public void GetShaderCompileStatus_ReturnsTrue_WhenCompiled()
        {
            GetShaderiv mock = (uint shader, ShaderParameter pname, int[] p) => p[0] = 1;
            IntPtr fp = Marshal.GetFunctionPointerForDelegate(mock);
            Init(name => name == "glGetShaderiv" ? fp : IntPtr.Zero);
            Assert.True(Gl.GetShaderCompileStatus(1));
        }

        /// <summary>
        /// Tests that get shader compile status returns false when not compiled
        /// </summary>
        [Fact]
        public void GetShaderCompileStatus_ReturnsFalse_WhenNotCompiled()
        {
            GetShaderiv mock = (uint shader, ShaderParameter pname, int[] p) => p[0] = 0;
            IntPtr fp = Marshal.GetFunctionPointerForDelegate(mock);
            Init(name => name == "glGetShaderiv" ? fp : IntPtr.Zero);
            Assert.False(Gl.GetShaderCompileStatus(1));
        }

        /// <summary>
        /// Tests that get program info log returns empty when length zero
        /// </summary>
        [Fact]
        public void GetProgramInfoLog_ReturnsEmpty_WhenLengthZero()
        {
            GetProgramiv mock = (uint prog, ProgramParameter pname, int[] p) => p[0] = 0;
            IntPtr fp = Marshal.GetFunctionPointerForDelegate(mock);
            Init(name => name == "glGetProgramiv" ? fp : IntPtr.Zero);
            Assert.Equal(string.Empty, Gl.GetProgramInfoLog(1));
        }

        /// <summary>
        /// Tests that get program info log returns string when length non zero
        /// </summary>
        [Fact]
        public void GetProgramInfoLog_ReturnsString_WhenLengthNonZero()
        {
            GetProgramiv ivMock = (uint prog, ProgramParameter pname, int[] p) => p[0] = 5;
            IntPtr ivFp = Marshal.GetFunctionPointerForDelegate(ivMock);

            GetProgramInfoLogDel logMock = (uint prog, int maxLen, int[] len, StringBuilder sb) => sb.Append("hello");
            IntPtr logFp = Marshal.GetFunctionPointerForDelegate(logMock);

            Init(name => name switch
            {
                "glGetProgramiv" => ivFp,
                "glGetProgramInfoLog" => logFp,
                _ => IntPtr.Zero
            });

            Assert.Equal("hello", Gl.GetProgramInfoLog(1));
        }

        /// <summary>
        /// Tests that get program link status returns true when linked
        /// </summary>
        [Fact]
        public void GetProgramLinkStatus_ReturnsTrue_WhenLinked()
        {
            GetProgramiv mock = (uint prog, ProgramParameter pname, int[] p) => p[0] = 1;
            IntPtr fp = Marshal.GetFunctionPointerForDelegate(mock);
            Init(name => name == "glGetProgramiv" ? fp : IntPtr.Zero);
            Assert.True(Gl.GetProgramLinkStatus(1));
        }

        /// <summary>
        /// Tests that get program link status returns false when not linked
        /// </summary>
        [Fact]
        public void GetProgramLinkStatus_ReturnsFalse_WhenNotLinked()
        {
            GetProgramiv mock = (uint prog, ProgramParameter pname, int[] p) => p[0] = 0;
            IntPtr fp = Marshal.GetFunctionPointerForDelegate(mock);
            Init(name => name == "glGetProgramiv" ? fp : IntPtr.Zero);
            Assert.False(Gl.GetProgramLinkStatus(1));
        }

        /// <summary>
        /// Tests that uniform matrix 4 fv passes flattened values
        /// </summary>
        [Fact]
        public void UniformMatrix4Fv_PassesFlattenedValues()
        {
            float[] captured = null;
            UniformMatrix4FvDel mock = (int loc, int count, bool transpose, float[] val) => captured = (float[])val.Clone();
            IntPtr fp = Marshal.GetFunctionPointerForDelegate(mock);
            Init(name => name == "glUniformMatrix4fv" ? fp : IntPtr.Zero);

            Matrix4X4 mat = new Matrix4X4(
                1, 2, 3, 4,
                5, 6, 7, 8,
                9, 10, 11, 12,
                13, 14, 15, 16
            );
            Gl.UniformMatrix4Fv(0, mat);

            Assert.Equal(1f, captured[0], 5);
            Assert.Equal(2f, captured[1], 5);
            Assert.Equal(3f, captured[2], 5);
            Assert.Equal(4f, captured[3], 5);
            Assert.Equal(5f, captured[4], 5);
            Assert.Equal(6f, captured[5], 5);
            Assert.Equal(7f, captured[6], 5);
            Assert.Equal(8f, captured[7], 5);
            Assert.Equal(9f, captured[8], 5);
            Assert.Equal(10f, captured[9], 5);
            Assert.Equal(11f, captured[10], 5);
            Assert.Equal(12f, captured[11], 5);
            Assert.Equal(13f, captured[12], 5);
            Assert.Equal(14f, captured[13], 5);
            Assert.Equal(15f, captured[14], 5);
            Assert.Equal(16f, captured[15], 5);
        }

        /// <summary>
        /// Tests that gen vertex array returns value from mock
        /// </summary>
        [Fact]
        public void GenVertexArray_ReturnsValueFromMock()
        {
            GenVertexArrays mock = (int n, uint[] arrays) => arrays[0] = 99;
            IntPtr fp = Marshal.GetFunctionPointerForDelegate(mock);
            Init(name => name == "glGenVertexArrays" ? fp : IntPtr.Zero);
            Assert.Equal(99u, Gl.GenVertexArray());
        }

        /// <summary>
        /// Tests that delete vertex array calls mock
        /// </summary>
        [Fact]
        public void DeleteVertexArray_CallsMock()
        {
            uint captured = 0;
            DeleteVertexArrays mock = (int n, uint[] arrays) => captured = arrays[0];
            IntPtr fp = Marshal.GetFunctionPointerForDelegate(mock);
            Init(name => name == "glDeleteVertexArrays" ? fp : IntPtr.Zero);
            Gl.DeleteVertexArray(5);
            Assert.Equal(5u, captured);
        }

        /// <summary>
        /// Tests that gen texture returns value from mock
        /// </summary>
        [Fact]
        public void GenTexture_ReturnsValueFromMock()
        {
            GenTextures mock = (int n, uint[] textures) => textures[0] = 77;
            IntPtr fp = Marshal.GetFunctionPointerForDelegate(mock);
            Init(name => name == "glGenTextures" ? fp : IntPtr.Zero);
            Assert.Equal(77u, Gl.GenTexture());
        }

        /// <summary>
        /// Tests that delete texture calls mock
        /// </summary>
        [Fact]
        public void DeleteTexture_CallsMock()
        {
            uint captured = 0;
            DeleteTextures mock = (int n, uint[] textures) => captured = textures[0];
            IntPtr fp = Marshal.GetFunctionPointerForDelegate(mock);
            Init(name => name == "glDeleteTextures" ? fp : IntPtr.Zero);
            Gl.DeleteTexture(3);
            Assert.Equal(3u, captured);
        }

        /// <summary>
        /// Tests that gl get string returns value with valid ptr
        /// </summary>
        [Fact]
        public void GlGetString_ReturnsValue_WithValidPtr()
        {
            string expected = "OpenGL 4.1";
            byte[] bytes = Encoding.ASCII.GetBytes(expected);
            IntPtr mem = Marshal.AllocHGlobal(bytes.Length + 1);
            try
            {
                Marshal.Copy(bytes, 0, mem, bytes.Length);
                Marshal.WriteByte(mem, bytes.Length, 0);

                GetString mock = (StringName _) => mem;
                IntPtr fp = Marshal.GetFunctionPointerForDelegate(mock);
                Init(name => name == "glGetString" ? fp : IntPtr.Zero);
                Assert.Equal(expected, Gl.GlGetString(StringName.Version));
            }
            finally
            {
                Marshal.FreeHGlobal(mem);
            }
        }

        /// <summary>
        /// Tests that gl get shader returns value from mock
        /// </summary>
        [Fact]
        public void GlGetShader_ReturnsValueFromMock()
        {
            GetShaderiv mock = (uint shader, ShaderParameter pname, int[] p) => p[0] = 42;
            IntPtr fp = Marshal.GetFunctionPointerForDelegate(mock);
            Init(name => name == "glGetShaderiv" ? fp : IntPtr.Zero);
            Gl.GlGetShader(1, ShaderParameter.CompileStatus, out int result);
            Assert.Equal(42, result);
        }

        /// <summary>
        /// Tests that gl get program returns value from mock
        /// </summary>
        [Fact]
        public void GlGetProgram_ReturnsValueFromMock()
        {
            GetProgramiv mock = (uint prog, ProgramParameter pname, int[] p) => p[0] = 99;
            IntPtr fp = Marshal.GetFunctionPointerForDelegate(mock);
            Init(name => name == "glGetProgramiv" ? fp : IntPtr.Zero);
            Gl.GlGetProgram(1, ProgramParameter.LinkStatus, out int result);
            Assert.Equal(99, result);
        }

        /// <summary>
        /// Tests that gl uniform matrix 2x 3 calls mock
        /// </summary>
        [Fact]
        public void GlUniformMatrix2x3_CallsMock()
        {
            int capturedLocation = -1;
            bool capturedTranspose = false;
            Gl.UniformMatrix2x3FvDel mock = (int loc, int count, bool transpose, Span<float> val) =>
            {
                capturedLocation = loc;
                capturedTranspose = transpose;
            };
            IntPtr fp = Marshal.GetFunctionPointerForDelegate(mock);
            Init(name => name == "glUniformMatrix2x3fv" ? fp : IntPtr.Zero);

            Span<float> matrix = stackalloc float[6] { 1, 2, 3, 4, 5, 6 };
            Gl.GlUniformMatrix2x3(5, true, matrix);
            Assert.Equal(5, capturedLocation);
            Assert.True(capturedTranspose);
        }

        /// <summary>
        /// Tests that gl get error returns value from mock
        /// </summary>
        [Fact]
        public void GlGetError_ReturnsValueFromMock()
        {
            Alis.Core.Graphic.OpenGL.Gl.GetError mock = () => 1280;
            IntPtr fp = Marshal.GetFunctionPointerForDelegate(mock);
            Init(name => name == "glGetError" ? fp : IntPtr.Zero);
            Assert.Equal(1280, Gl.GlGetError());
        }

        /// <summary>
        /// Tests that gl line width calls mock
        /// </summary>
        [Fact]
        public void GlLineWidth_CallsMock()
        {
            float captured = 0;
            Gl.LineWidth mock = (float w) => captured = w;
            IntPtr fp = Marshal.GetFunctionPointerForDelegate(mock);
            Init(name => name == "glLineWidth" ? fp : IntPtr.Zero);
            Gl.GlLineWidth(2.5f);
            Assert.Equal(2.5f, captured, 5);
        }

        /// <summary>
        /// Tests that gl active texture calls mock
        /// </summary>
        [Fact]
        public void GlActiveTexture_CallsMock()
        {
            TextureUnit captured = 0;
            Gl.ActiveTexture mock = (TextureUnit t) => captured = t;
            IntPtr fp = Marshal.GetFunctionPointerForDelegate(mock);
            Init(name => name == "glActiveTexture" ? fp : IntPtr.Zero);
            Gl.GlActiveTexture(TextureUnit.Texture1);
            Assert.Equal(TextureUnit.Texture1, captured);
        }

        /// <summary>
        /// Tests that gl get integerv calls mock
        /// </summary>
        [Fact]
        public void GlGetIntegerv_CallsMock()
        {
            int[] captured = null;
            Gl.GetIntegerv mock = (int pname, int[] data) => captured = data;
            IntPtr fp = Marshal.GetFunctionPointerForDelegate(mock);
            Init(name => name == "glGetIntegerv" ? fp : IntPtr.Zero);
            int[] viewport = new int[4];
            Gl.GlGetIntegerv(0, viewport);
            Assert.Same(viewport, captured);
        }

        /// <summary>
        /// Tests that vertex attrib pointer calls mock with valid index
        /// </summary>
        [Fact]
        public void VertexAttribPointer_CallsMock_WithValidIndex()
        {
            uint capturedIndex = 999;
            VertexAttribPointerDel mock = (uint idx, int size, VertexAttribPointerType type, bool norm, int stride, IntPtr ptr) => capturedIndex = idx;
            IntPtr fp = Marshal.GetFunctionPointerForDelegate(mock);
            Init(name => name == "glVertexAttribPointer" ? fp : IntPtr.Zero);
            Gl.VertexAttribPointer(2, 3, VertexAttribPointerType.Float, false, 0, IntPtr.Zero);
            Assert.Equal(2u, capturedIndex);
        }

        /// <summary>
        /// Tests that enable vertex attrib array calls mock with valid index
        /// </summary>
        [Fact]
        public void EnableVertexAttribArray_CallsMock_WithValidIndex()
        {
            uint captured = 999;
            EnableVertexAttribArrayDel mock = (uint idx) => captured = idx;
            IntPtr fp = Marshal.GetFunctionPointerForDelegate(mock);
            Init(name => name == "glEnableVertexAttribArray" ? fp : IntPtr.Zero);
            Gl.EnableVertexAttribArray(4);
            Assert.Equal(4u, captured);
        }

        /// <summary>
        /// Tests that vertex attrib pointer throws on negative index
        /// </summary>
        [Fact]
        public void VertexAttribPointer_ThrowsOnNegativeIndex()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                Gl.VertexAttribPointer(-1, 0, 0, false, 0, IntPtr.Zero));
        }

        /// <summary>
        /// Tests that enable vertex attrib array throws on negative index
        /// </summary>
        [Fact]
        public void EnableVertexAttribArray_ThrowsOnNegativeIndex()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                Gl.EnableVertexAttribArray(-1));
        }

        /// <summary>
        /// Tests that all properties throw external when not resolved
        /// </summary>
        [Fact]
        public void AllProperties_ThrowExternal_WhenNotResolved()
        {
            Init(_ => IntPtr.Zero);
            Assert.Throws<ExternalException>(() => _ = Gl.GlViewport);
            Assert.Throws<ExternalException>(() => _ = Gl.GlClearColor);
            Assert.Throws<ExternalException>(() => _ = Gl.GlColor4F);
            Assert.Throws<ExternalException>(() => _ = Gl.GlEnd);
            Assert.Throws<ExternalException>(() => _ = Gl.GlClear);
            Assert.Throws<ExternalException>(() => _ = Gl.GlEnable);
            Assert.Throws<ExternalException>(() => _ = Gl.GlDisable);
            Assert.Throws<ExternalException>(() => _ = Gl.GlBlendEquation);
            Assert.Throws<ExternalException>(() => _ = Gl.GlBlendFunc);
            Assert.Throws<ExternalException>(() => _ = Gl.GlUseProgram);
            Assert.Throws<ExternalException>(() => _ = Gl.GlBegin);
            Assert.Throws<ExternalException>(() => _ = Gl.GlCreateShader);
            Assert.Throws<ExternalException>(() => _ = Gl.GlCompileShader);
            Assert.Throws<ExternalException>(() => _ = Gl.GlDeleteShader);
            Assert.Throws<ExternalException>(() => _ = Gl.GlCreateProgram);
            Assert.Throws<ExternalException>(() => _ = Gl.GlAttachShader);
            Assert.Throws<ExternalException>(() => _ = Gl.GlLinkProgram);
            Assert.Throws<ExternalException>(() => _ = Gl.GlGetUniformLocation);
            Assert.Throws<ExternalException>(() => _ = Gl.GlGetAttribLocation);
            Assert.Throws<ExternalException>(() => _ = Gl.GlDetachShader);
            Assert.Throws<ExternalException>(() => _ = Gl.GlDeleteProgram);
            Assert.Throws<ExternalException>(() => _ = Gl.GlGetActiveAttrib);
            Assert.Throws<ExternalException>(() => _ = Gl.GlGetActiveUniform);
            Assert.Throws<ExternalException>(() => _ = Gl.GlUniform1F);
            Assert.Throws<ExternalException>(() => _ = Gl.GlUniform2F);
            Assert.Throws<ExternalException>(() => _ = Gl.GlUniform3F);
            Assert.Throws<ExternalException>(() => _ = Gl.GlUniform4F);
            Assert.Throws<ExternalException>(() => _ = Gl.GlUniform1I);
            Assert.Throws<ExternalException>(() => _ = Gl.GlReadPixels);
            Assert.Throws<ExternalException>(() => _ = Gl.GlGenFramebuffer);
            Assert.Throws<ExternalException>(() => _ = Gl.GlFramebufferTexture2D);
            Assert.Throws<ExternalException>(() => _ = Gl.GlUniformMatrix3Fv);
            Assert.Throws<ExternalException>(() => _ = Gl.GlBindSampler);
            Assert.Throws<ExternalException>(() => _ = Gl.GlBindVertexArray);
            Assert.Throws<ExternalException>(() => _ = Gl.GlBindBuffer);
            Assert.Throws<ExternalException>(() => _ = Gl.GlVertex2F);
            Assert.Throws<ExternalException>(() => _ = Gl.GlTexCoord2F);
            Assert.Throws<ExternalException>(() => _ = Gl.GlDisableVertexAttribArray);
            Assert.Throws<ExternalException>(() => _ = Gl.GlBindFramebuffer);
            Assert.Throws<ExternalException>(() => _ = Gl.GlBindTexture);
            Assert.Throws<ExternalException>(() => _ = Gl.GlBufferData);
            Assert.Throws<ExternalException>(() => _ = Gl.GlScissor);
            Assert.Throws<ExternalException>(() => _ = Gl.GlDrawElementsBaseVertex);
            Assert.Throws<ExternalException>(() => _ = Gl.GlPixelStorei);
            Assert.Throws<ExternalException>(() => _ = Gl.GlTexImage2D);
            Assert.Throws<ExternalException>(() => _ = Gl.GlTexParameteri);
            Assert.Throws<ExternalException>(() => _ = Gl.GlDrawArrays);
            Assert.Throws<ExternalException>(() => _ = Gl.GlDrawElements);
            Assert.Throws<ExternalException>(() => _ = Gl.GlPolygonMode);
        }
    }
}
