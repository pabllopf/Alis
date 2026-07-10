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
    public class GlSafeCoverageTests : IDisposable
    {
        private static readonly FieldInfo Field = typeof(Gl).GetField("_getProcAddress", BindingFlags.NonPublic | BindingFlags.Static);
        private readonly object _saved;

        public GlSafeCoverageTests() => _saved = Field?.GetValue(null);
        public void Dispose() => Field?.SetValue(null, _saved);

        private void Init() => Gl.Initialize(_ => IntPtr.Zero);

        [Fact] public void Initialize_StoresDelegate() { Gl.Initialize(_ => IntPtr.Zero); }
        [Fact] public void GlGetError_ThrowsExternal() { Init(); Assert.Throws<ExternalException>(() => Gl.GlGetError()); }
        [Fact] public void GlLineWidth_ThrowsExternal() { Init(); Assert.Throws<ExternalException>(() => Gl.GlLineWidth(1)); }
        [Fact] public void GlActiveTexture_ThrowsExternal() { Init(); Assert.Throws<ExternalException>(() => Gl.GlActiveTexture(TextureUnit.Texture0)); }
        [Fact] public void GlGetIntegerv_ThrowsExternal() { Init(); Assert.Throws<ExternalException>(() => Gl.GlGetIntegerv(0, new int[4])); }
        [Fact] public void GlGetShader_ThrowsExternal() { Init(); Assert.Throws<ExternalException>(() => Gl.GlGetShader(1, ShaderParameter.CompileStatus, out _)); }
        [Fact] public void GlGetProgram_ThrowsExternal() { Init(); Assert.Throws<ExternalException>(() => Gl.GlGetProgram(1, ProgramParameter.LinkStatus, out _)); }
        [Fact] public void GlUniformMatrix2x3_ThrowsExternal() { Init(); Assert.Throws<ExternalException>(() => Gl.GlUniformMatrix2x3(0, false, stackalloc float[6])); }
        [Fact] public void GenBuffer_ThrowsExternal() { Init(); Assert.Throws<ExternalException>(() => Gl.GenBuffer()); }
        [Fact] public void DeleteBuffer_ThrowsExternal() { Init(); Assert.Throws<ExternalException>(() => Gl.DeleteBuffer(1)); }
        [Fact] public void GetShaderInfoLog_ThrowsExternal() { Init(); Assert.Throws<ExternalException>(() => Gl.GetShaderInfoLog(1)); }
        [Fact] public void GetProgramInfoLog_ThrowsExternal() { Init(); Assert.Throws<ExternalException>(() => Gl.GetProgramInfoLog(1)); }
        [Fact] public void GetShaderCompileStatus_ThrowsExternal() { Init(); Assert.Throws<ExternalException>(() => Gl.GetShaderCompileStatus(1)); }
        [Fact] public void GetProgramLinkStatus_ThrowsExternal() { Init(); Assert.Throws<ExternalException>(() => Gl.GetProgramLinkStatus(1)); }
        [Fact] public void ShaderSource_ThrowsExternal() { Init(); Assert.Throws<ExternalException>(() => Gl.ShaderSource(1, "src")); }
        [Fact] public void UniformMatrix4Fv_ThrowsExternal() { Init(); Assert.Throws<ExternalException>(() => Gl.UniformMatrix4Fv(0, new Matrix4X4())); }
        [Fact] public void GenVertexArray_ThrowsExternal() { Init(); Assert.Throws<ExternalException>(() => Gl.GenVertexArray()); }
        [Fact] public void DeleteVertexArray_ThrowsExternal() { Init(); Assert.Throws<ExternalException>(() => Gl.DeleteVertexArray(1)); }
        [Fact] public void GenTexture_ThrowsExternal() { Init(); Assert.Throws<ExternalException>(() => Gl.GenTexture()); }
        [Fact] public void DeleteTexture_ThrowsExternal() { Init(); Assert.Throws<ExternalException>(() => Gl.DeleteTexture(1)); }
        [Fact] public void GenerateMipmap_ThrowsExternal() { Init(); Assert.Throws<ExternalException>(() => Gl.GenerateMipmap(TextureTarget.Texture2D)); }
        [Fact] public void GlGetString_ThrowsExternal() { Init(); Assert.Throws<ExternalException>(() => Gl.GlGetString(StringName.Version)); }
        [Fact] public void VertexAttribPointer_ThrowsOnNegative() { Assert.Throws<ArgumentOutOfRangeException>(() => Gl.VertexAttribPointer(-1, 0, 0, false, 0, IntPtr.Zero)); }
        [Fact] public void EnableVertexAttribArray_ThrowsOnNegative() { Assert.Throws<ArgumentOutOfRangeException>(() => Gl.EnableVertexAttribArray(-1)); }
        [Fact] public void GetCommand_ThrowsInvalidOp_WhenNotInited() { Assert.Throws<InvalidOperationException>(() => Gl.GlGetError()); }

        [Fact]
        public void GlGetString_ReturnsEmpty_WithGetStringDelegate()
        {
            GetString mock = (StringName _) => IntPtr.Zero;
            IntPtr fp = Marshal.GetFunctionPointerForDelegate(mock);
            Gl.Initialize(name => name == "glGetString" ? fp : IntPtr.Zero);
            string result = Gl.GlGetString(StringName.Version);
            Assert.Equal(string.Empty, result);
        }
    }
}
