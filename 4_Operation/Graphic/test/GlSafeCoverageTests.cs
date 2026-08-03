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
    /// <summary>
    /// The gl safe coverage tests class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    public class GlSafeCoverageTests : IDisposable
    {
        /// <summary>
        /// The static
        /// </summary>
        private static readonly FieldInfo Field = typeof(Gl).GetField("_getProcAddress", BindingFlags.NonPublic | BindingFlags.Static);
        /// <summary>
        /// The saved
        /// </summary>
        internal readonly object Saved;

        /// <summary>
        /// Initializes a new instance of the <see cref="GlSafeCoverageTests"/> class
        /// </summary>
        public GlSafeCoverageTests() => Saved = Field?.GetValue(null);
        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose() => Field?.SetValue(null, Saved);

        /// <summary>
        /// Inits this instance
        /// </summary>
        internal void Init() => Gl.Initialize(_ => IntPtr.Zero);

        /// <summary>
        /// Tests that initialize stores delegate
        /// </summary>
        [Fact] public void Initialize_StoresDelegate() { Gl.Initialize(_ => IntPtr.Zero); }
        /// <summary>
        /// Tests that gl get error throws external
        /// </summary>
        [Fact] public void GlGetError_ThrowsExternal() { Init(); Assert.Throws<ExternalException>(() => Gl.GlGetError()); }
        /// <summary>
        /// Tests that gl line width throws external
        /// </summary>
        [Fact] public void GlLineWidth_ThrowsExternal() { Init(); Assert.Throws<ExternalException>(() => Gl.GlLineWidth(1)); }
        /// <summary>
        /// Tests that gl active texture throws external
        /// </summary>
        [Fact] public void GlActiveTexture_ThrowsExternal() { Init(); Assert.Throws<ExternalException>(() => Gl.GlActiveTexture(TextureUnit.Texture0)); }
        /// <summary>
        /// Tests that gl get integerv throws external
        /// </summary>
        [Fact] public void GlGetIntegerv_ThrowsExternal() { Init(); Assert.Throws<ExternalException>(() => Gl.GlGetIntegerv(0, new int[4])); }
        /// <summary>
        /// Tests that gl get shader throws external
        /// </summary>
        [Fact] public void GlGetShader_ThrowsExternal() { Init(); Assert.Throws<ExternalException>(() => Gl.GlGetShader(1, ShaderParameter.CompileStatus, out _)); }
        /// <summary>
        /// Tests that gl get program throws external
        /// </summary>
        [Fact] public void GlGetProgram_ThrowsExternal() { Init(); Assert.Throws<ExternalException>(() => Gl.GlGetProgram(1, ProgramParameter.LinkStatus, out _)); }
        /// <summary>
        /// Tests that gl uniform matrix 2x 3 throws external
        /// </summary>
        [Fact] public void GlUniformMatrix2x3_ThrowsExternal() { Init(); Assert.Throws<ExternalException>(() => Gl.GlUniformMatrix2x3(0, false, stackalloc float[6])); }
        /// <summary>
        /// Tests that gen buffer throws external
        /// </summary>
        [Fact] public void GenBuffer_ThrowsExternal() { Init(); Assert.Throws<ExternalException>(() => Gl.GenBuffer()); }
        /// <summary>
        /// Tests that delete buffer throws external
        /// </summary>
        [Fact] public void DeleteBuffer_ThrowsExternal() { Init(); Assert.Throws<ExternalException>(() => Gl.DeleteBuffer(1)); }
        /// <summary>
        /// Tests that get shader info log throws external
        /// </summary>
        [Fact] public void GetShaderInfoLog_ThrowsExternal() { Init(); Assert.Throws<ExternalException>(() => Gl.GetShaderInfoLog(1)); }
        /// <summary>
        /// Tests that get program info log throws external
        /// </summary>
        [Fact] public void GetProgramInfoLog_ThrowsExternal() { Init(); Assert.Throws<ExternalException>(() => Gl.GetProgramInfoLog(1)); }
        /// <summary>
        /// Tests that get shader compile status throws external
        /// </summary>
        [Fact] public void GetShaderCompileStatus_ThrowsExternal() { Init(); Assert.Throws<ExternalException>(() => Gl.GetShaderCompileStatus(1)); }
        /// <summary>
        /// Tests that get program link status throws external
        /// </summary>
        [Fact] public void GetProgramLinkStatus_ThrowsExternal() { Init(); Assert.Throws<ExternalException>(() => Gl.GetProgramLinkStatus(1)); }
        /// <summary>
        /// Tests that shader source throws external
        /// </summary>
        [Fact] public void ShaderSource_ThrowsExternal() { Init(); Assert.Throws<ExternalException>(() => Gl.ShaderSource(1, "src")); }
        /// <summary>
        /// Tests that uniform matrix 4 fv throws external
        /// </summary>
        [Fact] public void UniformMatrix4Fv_ThrowsExternal() { Init(); Assert.Throws<ExternalException>(() => Gl.UniformMatrix4Fv(0, new Matrix4X4())); }
        /// <summary>
        /// Tests that gen vertex array throws external
        /// </summary>
        [Fact] public void GenVertexArray_ThrowsExternal() { Init(); Assert.Throws<ExternalException>(() => Gl.GenVertexArray()); }
        /// <summary>
        /// Tests that delete vertex array throws external
        /// </summary>
        [Fact] public void DeleteVertexArray_ThrowsExternal() { Init(); Assert.Throws<ExternalException>(() => Gl.DeleteVertexArray(1)); }
        /// <summary>
        /// Tests that gen texture throws external
        /// </summary>
        [Fact] public void GenTexture_ThrowsExternal() { Init(); Assert.Throws<ExternalException>(() => Gl.GenTexture()); }
        /// <summary>
        /// Tests that delete texture throws external
        /// </summary>
        [Fact] public void DeleteTexture_ThrowsExternal() { Init(); Assert.Throws<ExternalException>(() => Gl.DeleteTexture(1)); }
        /// <summary>
        /// Tests that generate mipmap throws external
        /// </summary>
        [Fact] public void GenerateMipmap_ThrowsExternal() { Init(); Assert.Throws<ExternalException>(() => Gl.GenerateMipmap(TextureTarget.Texture2D)); }
        /// <summary>
        /// Tests that gl get string throws external
        /// </summary>
        [Fact] public void GlGetString_ThrowsExternal() { Init(); Assert.Throws<ExternalException>(() => Gl.GlGetString(StringName.Version)); }
        /// <summary>
        /// Tests that vertex attrib pointer throws on negative
        /// </summary>
        [Fact] public void VertexAttribPointer_ThrowsOnNegative() { Assert.Throws<ArgumentOutOfRangeException>(() => Gl.VertexAttribPointer(-1, 0, 0, false, 0, IntPtr.Zero)); }
        /// <summary>
        /// Tests that enable vertex attrib array throws on negative
        /// </summary>
        [Fact] public void EnableVertexAttribArray_ThrowsOnNegative() { Assert.Throws<ArgumentOutOfRangeException>(() => Gl.EnableVertexAttribArray(-1)); }
        /// <summary>
        /// Tests that get command throws invalid op when not inited
        /// </summary>
        [Fact] public void GetCommand_ThrowsInvalidOp_WhenNotInited() { Assert.Throws<InvalidOperationException>(() => Gl.GlGetError()); }

        /// <summary>
        /// Tests that gl get string returns empty with get string delegate
        /// </summary>
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
