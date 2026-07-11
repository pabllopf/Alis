using System;
using System.Reflection;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Delegates;
using Alis.Core.Graphic.OpenGL.Enums;
using Xunit;

namespace Alis.Core.Graphic.Test
{
    public class GlFinalCoverageTests : IDisposable
    {
        private static readonly FieldInfo Field = typeof(Gl).GetField("_getProcAddress", BindingFlags.NonPublic | BindingFlags.Static);
        private readonly object _saved;
        public GlFinalCoverageTests() => _saved = Field?.GetValue(null);
        public void Dispose() => Field?.SetValue(null, _saved);

        private void InitWithPtrFor(string name, Delegate d)
        {
            IntPtr fp = Marshal.GetFunctionPointerForDelegate(d);
            Gl.Initialize(n => n == name ? fp : IntPtr.Zero);
        }

        [Fact] public void Initialize_With_Null_Clears() { Gl.Initialize(_ => IntPtr.Zero); Gl.Initialize(null); Assert.Throws<InvalidOperationException>(() => Gl.GlGetError()); }
        [Fact] public void GlGetError_ThrowsExternal() { Gl.Initialize(_ => IntPtr.Zero); Assert.Throws<ExternalException>(() => Gl.GlGetError()); }
        [Fact] public void GlLineWidth_ThrowsExternal() { Gl.Initialize(_ => IntPtr.Zero); Assert.Throws<ExternalException>(() => Gl.GlLineWidth(1)); }
        [Fact] public void GlActiveTexture_ThrowsExternal() { Gl.Initialize(_ => IntPtr.Zero); Assert.Throws<ExternalException>(() => Gl.GlActiveTexture(TextureUnit.Texture0)); }
        [Fact] public void GlGetIntegerv_ThrowsExternal() { Gl.Initialize(_ => IntPtr.Zero); Assert.Throws<ExternalException>(() => Gl.GlGetIntegerv(0, new int[4])); }
        [Fact] public void GenBuffer_ThrowsExternal() { Gl.Initialize(_ => IntPtr.Zero); Assert.Throws<ExternalException>(() => Gl.GenBuffer()); }
        [Fact] public void DeleteBuffer_ThrowsExternal() { Gl.Initialize(_ => IntPtr.Zero); Assert.Throws<ExternalException>(() => Gl.DeleteBuffer(1)); }
        [Fact] public void GetShaderInfoLog_ThrowsExternal() { Gl.Initialize(_ => IntPtr.Zero); Assert.Throws<ExternalException>(() => Gl.GetShaderInfoLog(1)); }
        [Fact] public void GetProgramInfoLog_ThrowsExternal() { Gl.Initialize(_ => IntPtr.Zero); Assert.Throws<ExternalException>(() => Gl.GetProgramInfoLog(1)); }
        [Fact] public void GetShaderCompileStatus_ThrowsExternal() { Gl.Initialize(_ => IntPtr.Zero); Assert.Throws<ExternalException>(() => Gl.GetShaderCompileStatus(1)); }
        [Fact] public void GetProgramLinkStatus_ThrowsExternal() { Gl.Initialize(_ => IntPtr.Zero); Assert.Throws<ExternalException>(() => Gl.GetProgramLinkStatus(1)); }
        [Fact] public void ShaderSource_ThrowsExternal() { Gl.Initialize(_ => IntPtr.Zero); Assert.Throws<ExternalException>(() => Gl.ShaderSource(1, "src")); }
        [Fact] public void UniformMatrix4Fv_ThrowsExternal() { Gl.Initialize(_ => IntPtr.Zero); Assert.Throws<ExternalException>(() => Gl.UniformMatrix4Fv(0, new Matrix4X4())); }
        [Fact] public void GenVertexArray_ThrowsExternal() { Gl.Initialize(_ => IntPtr.Zero); Assert.Throws<ExternalException>(() => Gl.GenVertexArray()); }
        [Fact] public void DeleteVertexArray_ThrowsExternal() { Gl.Initialize(_ => IntPtr.Zero); Assert.Throws<ExternalException>(() => Gl.DeleteVertexArray(1)); }
        [Fact] public void GenTexture_ThrowsExternal() { Gl.Initialize(_ => IntPtr.Zero); Assert.Throws<ExternalException>(() => Gl.GenTexture()); }
        [Fact] public void DeleteTexture_ThrowsExternal() { Gl.Initialize(_ => IntPtr.Zero); Assert.Throws<ExternalException>(() => Gl.DeleteTexture(1)); }
        [Fact] public void GenerateMipmap_ThrowsExternal() { Gl.Initialize(_ => IntPtr.Zero); Assert.Throws<ExternalException>(() => Gl.GenerateMipmap(TextureTarget.Texture2D)); }
        [Fact] public void GlUniformMatrix2x3_ThrowsExternal() { Gl.Initialize(_ => IntPtr.Zero); Assert.Throws<ExternalException>(() => Gl.GlUniformMatrix2x3(0, false, stackalloc float[6])); }
        [Fact] public void GlGetShader_ThrowsExternal() { Gl.Initialize(_ => IntPtr.Zero); Assert.Throws<ExternalException>(() => Gl.GlGetShader(1, ShaderParameter.CompileStatus, out _)); }
        [Fact] public void GlGetProgram_ThrowsExternal() { Gl.Initialize(_ => IntPtr.Zero); Assert.Throws<ExternalException>(() => Gl.GlGetProgram(1, ProgramParameter.LinkStatus, out _)); }
        [Fact] public void VertexAttribPointer_ThrowsOnNegative() { Assert.Throws<ArgumentOutOfRangeException>(() => Gl.VertexAttribPointer(-1, 0, 0, false, 0, IntPtr.Zero)); }
        [Fact] public void EnableVertexAttribArray_ThrowsOnNegative() { Assert.Throws<ArgumentOutOfRangeException>(() => Gl.EnableVertexAttribArray(-1)); }
        [Fact] public void GetCommand_ThrowsInvalidOp_NotInited() { Assert.Throws<InvalidOperationException>(() => Gl.GlGetError()); }

        [Fact]
        public void GlGetString_ReturnsEmpty_WithNullDelegate()
        {
            InitWithPtrFor("glGetString", (GetString)(_ => IntPtr.Zero));
            Assert.Equal(string.Empty, Gl.GlGetString(StringName.Version));
        }

        [Fact]
        public void GlGetString_ReturnsString_WithValidDelegate()
        {
            byte[] data = System.Text.Encoding.ASCII.GetBytes("OpenGL 4.6\0");
            GCHandle h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                InitWithPtrFor("glGetString", (GetString)(_ => h.AddrOfPinnedObject()));
                Assert.Equal("OpenGL 4.6", Gl.GlGetString(StringName.Version));
            }
            finally { h.Free(); }
        }

        [Fact]
        public void GetShaderCompileStatus_ReturnsTrue_WithMock()
        {
            InitWithPtrFor("glGetShaderiv", (GetShaderiv)((uint s, ShaderParameter p, int[] d) => { if (p == ShaderParameter.CompileStatus) d[0] = 1; }));
            Assert.True(Gl.GetShaderCompileStatus(1));
        }

        [Fact]
        public void GetProgramLinkStatus_ReturnsTrue_WithMock()
        {
            InitWithPtrFor("glGetProgramiv", (GetProgramiv)((uint p, ProgramParameter s, int[] d) => { if (s == ProgramParameter.LinkStatus) d[0] = 1; }));
            Assert.True(Gl.GetProgramLinkStatus(1));
        }

        [Fact]
        public void GetShaderInfoLog_ReturnsString_WithMock()
        {
            InitWithPtrFor("glGetShaderiv", (GetShaderiv)((uint s, ShaderParameter p, int[] d) => { if (p == ShaderParameter.InfoLogLength) d[0] = 10; }));
            InitWithPtrFor("glGetShaderInfoLog", (GetShaderInfoLogDel)((uint s, int m, int[] l, System.Text.StringBuilder log) => log.Append("test")));
            Assert.Equal("test", Gl.GetShaderInfoLog(1));
        }

        [Fact]
        public void GetProgramInfoLog_ReturnsString_WithMock()
        {
            InitWithPtrFor("glGetProgramiv", (GetProgramiv)((uint p, ProgramParameter s, int[] d) => { if (s == ProgramParameter.InfoLogLength) d[0] = 10; }));
            InitWithPtrFor("glGetProgramInfoLog", (GetProgramInfoLogDel)((uint p, int m, int[] l, System.Text.StringBuilder log) => log.Append("prog")));
            Assert.Equal("prog", Gl.GetProgramInfoLog(1));
        }

        [Fact]
        public void GlLineWidth_Calls_WithValue()
        {
            float cap = 0;
            InitWithPtrFor("glLineWidth", (Gl.LineWidth)((float w) => cap = w));
            Gl.GlLineWidth(3.5f);
            Assert.Equal(3.5f, cap);
        }

        [Fact]
        public void GenBuffer_Returns_Correct()
        {
            InitWithPtrFor("glGenBuffers", (GenBuffers)((int n, uint[] b) => b[0] = 42));
            Assert.Equal(42u, Gl.GenBuffer());
        }

        [Fact]
        public void GenVertexArray_Returns_Correct()
        {
            InitWithPtrFor("glGenVertexArrays", (GenVertexArrays)((int n, uint[] a) => a[0] = 77));
            Assert.Equal(77u, Gl.GenVertexArray());
        }

        [Fact]
        public void GenTexture_Returns_Correct()
        {
            InitWithPtrFor("glGenTextures", (GenTextures)((int n, uint[] t) => t[0] = 99));
            Assert.Equal(99u, Gl.GenTexture());
        }

        [Fact]
        public void ShaderSource_Calls_WithArgs()
        {
            uint shader = 0; string src = null;
            InitWithPtrFor("glShaderSource", (ShaderSourceDel)((uint s, int c, string[] sr, int[] l) => { shader = s; src = sr[0]; }));
            Gl.ShaderSource(5, "code");
            Assert.Equal(5u, shader);
            Assert.Equal("code", src);
        }

        [Fact]
        public void UniformMatrix4Fv_FlattensMatrix()
        {
            float[] vals = null;
            InitWithPtrFor("glUniformMatrix4fv", (UniformMatrix4FvDel)((int loc, int c, bool t, float[] v) => vals = v));
            Gl.UniformMatrix4Fv(3, new Matrix4X4 { M11 = 1, M22 = 2, M33 = 3, M44 = 4 });
            Assert.Equal(1, vals[0]);
            Assert.Equal(2, vals[5]);
            Assert.Equal(3, vals[10]);
            Assert.Equal(4, vals[15]);
        }
    }
}
